using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wearhouse
{
    public partial class ProductPages : Form
    {
        private FlowLayoutPanel flowLayoutPanel;
        private List<ProductData> allProducts = new List<ProductData>();
        private List<string> productTypes = new List<string>();

        // Filter fields
        private DateTime? filterStartDate = null;
        private DateTime? filterEndDate = null;
        private decimal? filterMinPrice = null;
        private decimal? filterMaxPrice = null;
        private string filterProductType = null;

        public ProductPages()
        {
            InitializeComponent();
            ResponsiveHelper.EnableResponsive(this);
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            AddProduct addProductForm = new AddProduct();
            addProductForm.ShowDialog();
            
            // Refresh products after AddProduct is closed
            LoadAllProducts();
        }

        private void ProductPages_Load(object sender, EventArgs e)
        {
            InitializeProductDisplay();
            // Load aggregated products on initial load (grouped by product with total quantities)
            try
            {
                allProducts = GetAllProductsAggregatedFromDatabase();
                RefreshProductDisplay(string.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            InitializeSearch();
            InitializeFilters();
        }

        private void InitializeProductDisplay()
        {
            // Create FlowLayoutPanel
            flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.Dock = DockStyle.Fill;
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanel.WrapContents = true;
            flowLayoutPanel.Padding = new Padding(10);

            // Add to showproductpanel
            showproductpanel.Controls.Add(flowLayoutPanel);
        }

        private void InitializeSearch()
        {
            // Add TextChanged event for real-time search
            searchBox.TextChanged += SearchBox_TextChanged;
        }

        private void InitializeFilters()
        {
            // Load product types from database
            LoadProductTypes();
        }

        private void LoadProductTypes()
        {
            try
            {
                using (wearhouseEntities db = new wearhouseEntities())
                {
                    productTypes = db.producttype.Select(t => t.producttype_name).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading product types: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = searchBox.Text.ToLower().Trim();
            RefreshProductDisplay(searchTerm);
        }

        private void ButtonFilter_Click(object sender, EventArgs e)
        {
            // Open the advanced filter dialog
            ProductFilterDialog filterDialog = new ProductFilterDialog(productTypes);
            if (filterDialog.ShowDialog(this) == DialogResult.OK)
            {
                // If date filter is applied, use lot-based data (shows each lot separately)
                if (filterDialog.StartDate.HasValue && filterDialog.EndDate.HasValue)
                {
                    allProducts = GetAllProductsFromDatabase();
                    SetDateRangeFilter(filterDialog.StartDate.Value, filterDialog.EndDate.Value);
                }
                else
                {
                    // Otherwise, use aggregated data
                    allProducts = GetAllProductsAggregatedFromDatabase();
                    ClearAllFilters();
                }

                // Apply price filter
                if (filterDialog.MinPrice.HasValue || filterDialog.MaxPrice.HasValue)
                {
                    decimal minPrice = filterDialog.MinPrice ?? 0;
                    decimal maxPrice = filterDialog.MaxPrice ?? decimal.MaxValue;
                    SetPriceRangeFilter(minPrice, maxPrice);
                }

                // Apply product type filter
                if (!string.IsNullOrEmpty(filterDialog.SelectedProductType))
                {
                    SetProductTypeFilter(filterDialog.SelectedProductType);
                }

                RefreshProductDisplay(searchBox.Text);
            }
        }

        private void ButtonAllProducts_Click(object sender, EventArgs e)
        {
            // Clear all filters and search
            ClearAllFilters();
            searchBox.Clear();
            
            // Load aggregated products (grouped by product with total quantities)
            try
            {
                allProducts = GetAllProductsAggregatedFromDatabase();
                RefreshProductDisplay(string.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAllProducts()
        {
            try
            {
                allProducts = GetAllProductsFromDatabase();
                RefreshProductDisplay(string.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadProducts()
        {
            LoadAllProducts();
        }

        private void RefreshProductDisplay(string searchTerm)
        {
            // Clear current controls
            flowLayoutPanel.Controls.Clear();

            // Filter products based on search term and active filters
            List<ProductData> filteredProducts = allProducts;

            if (!string.IsNullOrEmpty(searchTerm))
            {
                filteredProducts = filteredProducts.Where(p =>
                    p.Id.ToString().Contains(searchTerm) ||
                    p.Name.ToLower().Contains(searchTerm)
                ).ToList();
            }

            // Apply date range filter
            if (filterStartDate.HasValue && filterEndDate.HasValue)
            {
                filteredProducts = filteredProducts.Where(p =>
                    p.ReceiveDate.Date >= filterStartDate.Value.Date && 
                    p.ReceiveDate.Date <= filterEndDate.Value.Date
                ).ToList();
            }

            // Apply price filter
            if (filterMinPrice.HasValue)
            {
                filteredProducts = filteredProducts.Where(p => p.Price >= filterMinPrice.Value).ToList();
            }
            if (filterMaxPrice.HasValue)
            {
                filteredProducts = filteredProducts.Where(p => p.Price <= filterMaxPrice.Value).ToList();
            }

            // Apply product type filter
            if (!string.IsNullOrEmpty(filterProductType))
            {
                filteredProducts = filteredProducts.Where(p => p.Type == filterProductType).ToList();
            }

            // Display filtered products
            if (filteredProducts.Count == 0)
            {
                Label noResultLabel = new Label();
                noResultLabel.Text = "ไม่พบสินค้า";
                noResultLabel.AutoSize = true;
                noResultLabel.Padding = new Padding(10);
                flowLayoutPanel.Controls.Add(noResultLabel);
            }
            else
            {
                foreach (var product in filteredProducts)
                {
                    ProductCard card = new ProductCard();
                    card.SetProductData(product.Id, product.Name, product.Quantity, product.Price, product.Image);
                    
                    // Subscribe to ProductDeleted event
                    card.ProductDeleted += (s, e) =>
                    {
                        LoadProducts();  // Refresh products after deletion
                    };

                    // Subscribe to ProductUpdated event
                    card.ProductUpdated += (s, e) =>
                    {
                        LoadProducts();  // Refresh products after update
                    };
                    
                    flowLayoutPanel.Controls.Add(card);
                }
            }
        }

        // Helper class for product data
        private class ProductData
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Quantity { get; set; }
            public decimal Price { get; set; }
            public Image Image { get; set; }
            public string Type { get; set; }
            public DateTime ReceiveDate { get; set; } // Add ReceiveDate property
        }

        private List<ProductData> GetAllProductsFromDatabase()
        {
            List<ProductData> products = new List<ProductData>();

            using (wearhouseEntities db = new wearhouseEntities())
            {
                // Get all lots (stock in records) instead of just products
                var lotList = db.lot.ToList();

                foreach (var lot in lotList)
                {
                    var item = lot.product;
                    
                    if (item == null) continue;

                    Image productImage = null;

                    // Convert byte array to Image
                    if (item.product_image != null && item.product_image.Length > 0)
                    {
                        try
                        {
                            using (System.IO.MemoryStream ms = new System.IO.MemoryStream(item.product_image))
                            {
                                productImage = Image.FromStream(ms);
                                productImage = new Bitmap(productImage);
                            }
                        }
                        catch
                        {
                            productImage = null;
                        }
                    }

                    // Get product type
                    string productType = "";
                    try
                    {
                        var type = db.producttype.FirstOrDefault(t => t.producttype_id == item.producttype_id);
                        if (type != null)
                            productType = type.producttype_name;
                    }
                    catch { }

                    products.Add(new ProductData
                    {
                        Id = item.product_id,
                        Name = item.product_name,
                        Quantity = lot.lot_balance_qty ?? 0,
                        Price = item.product_unitprice ?? 0,
                        Image = productImage,
                        Type = productType,
                        ReceiveDate = lot.lot_receive_date
                    });
                }
            }

            return products;
        }

        private List<ProductData> GetAllProductsAggregatedFromDatabase()
        {
            List<ProductData> products = new List<ProductData>();

            using (wearhouseEntities db = new wearhouseEntities())
            {
                // Group by product to get total quantities from all lots
                var productList = db.product.ToList();

                foreach (var item in productList)
                {
                    Image productImage = null;

                    // Convert byte array to Image
                    if (item.product_image != null && item.product_image.Length > 0)
                    {
                        try
                        {
                            using (System.IO.MemoryStream ms = new System.IO.MemoryStream(item.product_image))
                            {
                                productImage = Image.FromStream(ms);
                                productImage = new Bitmap(productImage);
                            }
                        }
                        catch
                        {
                            productImage = null;
                        }
                    }

                    // Calculate total stock from all lots for this product
                    int totalStock = db.lot
                        .Where(l => l.product_id == item.product_id)
                        .Sum(l => (int?)l.lot_balance_qty) ?? 0;

                    // Get product type
                    string productType = "";
                    try
                    {
                        var type = db.producttype.FirstOrDefault(t => t.producttype_id == item.producttype_id);
                        if (type != null)
                            productType = type.producttype_name;
                    }
                    catch { }

                    // Get the latest receive date for this product
                    DateTime receiveDate = DateTime.MinValue;
                    var latestLot = db.lot
                        .Where(l => l.product_id == item.product_id)
                        .OrderByDescending(l => l.lot_receive_date)
                        .FirstOrDefault();
                    
                    if (latestLot != null)
                    {
                        receiveDate = latestLot.lot_receive_date;
                    }

                    // Only add if there's stock available
                    if (totalStock > 0)
                    {
                        products.Add(new ProductData
                        {
                            Id = item.product_id,
                            Name = item.product_name,
                            Quantity = totalStock,
                            Price = item.product_unitprice ?? 0,
                            Image = productImage,
                            Type = productType,
                            ReceiveDate = receiveDate
                        });
                    }
                }
            }

            return products;
        }

        // ===== NEW FILTER METHODS =====

        public void SetDateRangeFilter(DateTime startDate, DateTime endDate)
        {
            filterStartDate = startDate;
            filterEndDate = endDate;
            RefreshProductDisplay(searchBox.Text);
        }

        public void SetPriceRangeFilter(decimal minPrice, decimal maxPrice)
        {
            filterMinPrice = minPrice > 0 ? minPrice : (decimal?)null;
            filterMaxPrice = maxPrice > 0 ? maxPrice : (decimal?)null;
            RefreshProductDisplay(searchBox.Text);
        }

        public void SetProductTypeFilter(string productType)
        {
            filterProductType = productType;
            RefreshProductDisplay(searchBox.Text);
        }

        public void ClearAllFilters()
        {
            filterStartDate = null;
            filterEndDate = null;
            filterMinPrice = null;
            filterMaxPrice = null;
            filterProductType = null;
            RefreshProductDisplay(searchBox.Text);
        }

        private void AddTypeBtn_Click(object sender, EventArgs e)
        {
            AddType addTypeForm = new AddType();
            addTypeForm.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Panel paint event handler
        }

        private void ButtonFilterDate_Click(object sender, EventArgs e)
        {
            // Create a simple date filter dialog
            Form dateFilterForm = new Form();
            dateFilterForm.Text = "กรองตามวันที่";
            dateFilterForm.Size = new System.Drawing.Size(350, 180);
            dateFilterForm.StartPosition = FormStartPosition.CenterParent;

            Label labelStart = new Label() { Text = "วันเริ่มต้น :", Location = new System.Drawing.Point(10, 20), AutoSize = true };
            DateTimePicker dtpStart = new DateTimePicker() { Location = new System.Drawing.Point(120, 20), Width = 200 };

            Label labelEnd = new Label() { Text = "วันสิ้นสุด :", Location = new System.Drawing.Point(10, 60), AutoSize = true };
            DateTimePicker dtpEnd = new DateTimePicker() { Location = new System.Drawing.Point(120, 60), Width = 200 };

            Button btnOK = new Button() { Text = "ตกลง", Location = new System.Drawing.Point(120, 110), Width = 90, DialogResult = DialogResult.OK };
            Button btnCancel = new Button() { Text = "ยกเลิก", Location = new System.Drawing.Point(220, 110), Width = 90, DialogResult = DialogResult.Cancel };

            dateFilterForm.Controls.Add(labelStart);
            dateFilterForm.Controls.Add(dtpStart);
            dateFilterForm.Controls.Add(labelEnd);
            dateFilterForm.Controls.Add(dtpEnd);
            dateFilterForm.Controls.Add(btnOK);
            dateFilterForm.Controls.Add(btnCancel);

            if (dateFilterForm.ShowDialog(this) == DialogResult.OK)
            {
                allProducts = GetAllProductsFromDatabase();
                SetDateRangeFilter(dtpStart.Value, dtpEnd.Value);
            }
        }

        private void ButtonFilterPrice_Click(object sender, EventArgs e)
        {
            // Create a simple price filter dialog
            Form priceFilterForm = new Form();
            priceFilterForm.Text = "กรองตามราคา";
            priceFilterForm.Size = new System.Drawing.Size(350, 180);
            priceFilterForm.StartPosition = FormStartPosition.CenterParent;

            Label labelMin = new Label() { Text = "ราคาน้อยสุด :", Location = new System.Drawing.Point(10, 20), AutoSize = true };
            TextBox tbMin = new TextBox() { Location = new System.Drawing.Point(120, 20), Width = 200 };

            Label labelMax = new Label() { Text = "ราคามากสุด :", Location = new System.Drawing.Point(10, 60), AutoSize = true };
            TextBox tbMax = new TextBox() { Location = new System.Drawing.Point(120, 60), Width = 200 };

            Button btnOK = new Button() { Text = "ตกลง", Location = new System.Drawing.Point(120, 110), Width = 90, DialogResult = DialogResult.OK };
            Button btnCancel = new Button() { Text = "ยกเลิก", Location = new System.Drawing.Point(220, 110), Width = 90, DialogResult = DialogResult.Cancel };

            priceFilterForm.Controls.Add(labelMin);
            priceFilterForm.Controls.Add(tbMin);
            priceFilterForm.Controls.Add(labelMax);
            priceFilterForm.Controls.Add(tbMax);
            priceFilterForm.Controls.Add(btnOK);
            priceFilterForm.Controls.Add(btnCancel);

            if (priceFilterForm.ShowDialog(this) == DialogResult.OK)
            {
                decimal minPrice = 0;
                decimal maxPrice = decimal.MaxValue;

                if (decimal.TryParse(tbMin.Text, out decimal min))
                    minPrice = min;

                if (decimal.TryParse(tbMax.Text, out decimal max))
                    maxPrice = max;

                allProducts = GetAllProductsAggregatedFromDatabase();
                SetPriceRangeFilter(minPrice, maxPrice);
            }
        }

        private void ButtonFilterType_Click(object sender, EventArgs e)
        {
            // Create a simple type filter dialog
            Form typeFilterForm = new Form();
            typeFilterForm.Text = "กรองตามประเภท";
            typeFilterForm.Size = new System.Drawing.Size(350, 150);
            typeFilterForm.StartPosition = FormStartPosition.CenterParent;

            Label labelType = new Label() { Text = "เลือกประเภท :", Location = new System.Drawing.Point(10, 20), AutoSize = true };
            ComboBox cbType = new ComboBox() { Location = new System.Drawing.Point(120, 20), Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };

            cbType.Items.Add("");
            foreach (var type in productTypes)
            {
                cbType.Items.Add(type);
            }
            cbType.SelectedIndex = 0;

            Button btnOK = new Button() { Text = "ตกลง", Location = new System.Drawing.Point(120, 70), Width = 90, DialogResult = DialogResult.OK };
            Button btnCancel = new Button() { Text = "ยกเลิก", Location = new System.Drawing.Point(220, 70), Width = 90, DialogResult = DialogResult.Cancel };

            typeFilterForm.Controls.Add(labelType);
            typeFilterForm.Controls.Add(cbType);
            typeFilterForm.Controls.Add(btnOK);
            typeFilterForm.Controls.Add(btnCancel);

            if (typeFilterForm.ShowDialog(this) == DialogResult.OK)
            {
                allProducts = GetAllProductsAggregatedFromDatabase();
                if (!string.IsNullOrEmpty(cbType.SelectedItem.ToString()))
                {
                    SetProductTypeFilter(cbType.SelectedItem.ToString());
                }
                else
                {
                    ClearAllFilters();
                }
            }
        }
    }
}
