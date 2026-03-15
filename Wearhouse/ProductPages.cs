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

            // Enable double buffering to reduce flicker
            try
            {
                var prop = typeof(Panel).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                if (prop != null)
                    prop.SetValue(flowLayoutPanel, true, null);
            }
            catch { }

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
                    productTypes = db.producttype.AsNoTracking().Select(t => t.producttype_name).ToList();
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
                allProducts = GetAllProductsAggregatedFromDatabase();
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
            if (flowLayoutPanel == null) return;

            // Suspend layout to improve performance while updating controls
            flowLayoutPanel.SuspendLayout();
            try
            {
                flowLayoutPanel.Controls.Clear();

                // Filter products based on search term and active filters
                List<ProductData> filteredProducts = allProducts;

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    filteredProducts = filteredProducts.Where(p =>
                        p.Id.ToString().Contains(searchTerm) ||
                        (!string.IsNullOrEmpty(p.Name) && p.Name.ToLower().Contains(searchTerm))
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
                    // Build controls into a list then add to the panel to reduce layout passes
                    var controlsToAdd = new List<Control>(filteredProducts.Count);

                    foreach (var product in filteredProducts)
                    {
                        ProductCard card = new ProductCard();

                        // แสดงเฉพาะชื่อสินค้า
                        string displayName = product.Name;

                        card.SetProductData(product.Id, displayName, product.Quantity, product.Price, product.Image);

                        // Set product unit
                        card.SetProductUnit(product.Unit);

                        // แสดงวันที่รับเข้าเมื่อมีการกรองวันที่
                        if (filterStartDate.HasValue && filterEndDate.HasValue)
                        {
                            card.SetReceiveDate(product.ReceiveDate);
                        }

                        // Show "New" badge if product received within last 1 day
                        bool isNew = false;
                        try
                        {
                            if (product.ReceiveDate > DateTime.MinValue)
                            {
                                var age = DateTime.Now - product.ReceiveDate;
                                if (age.TotalDays <= 1)
                                    isNew = true;
                            }
                        }
                        catch { }
                        card.SetIsNew(isNew);

                        // Subscribe to ProductDeleted/Updated events to refresh list
                        card.ProductDeleted += (s, e) => { LoadProducts(); };
                        card.ProductUpdated += (s, e) => { LoadProducts(); };

                        controlsToAdd.Add(card);
                    }

                    flowLayoutPanel.Controls.AddRange(controlsToAdd.ToArray());
                }
            }
            finally
            {
                flowLayoutPanel.ResumeLayout();
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
            public DateTime ReceiveDate { get; set; }
            public string Unit { get; set; }
        }

        private List<ProductData> GetAllProductsFromDatabase()
        {
            var products = new List<ProductData>();

            using (wearhouseEntities db = new wearhouseEntities())
            {
                // Load lots with their product and product type in a single projection
                var lotProj = db.lot
                    .AsNoTracking()
                    .Select(l => new
                    {
                        LotBalance = l.lot_balance_qty,
                        l.lot_receive_date,
                        Product = l.product == null ? null : new
                        {
                            l.product.product_id,
                            l.product.product_name,
                            UnitPrice = l.product.product_unitprice,
                            l.product.product_image,
                            l.product.product_unit,
                            ProductTypeName = l.product.producttype == null ? "" : l.product.producttype.producttype_name
                        }
                    })
                    .ToList();

                foreach (var lot in lotProj)
                {
                    var item = lot.Product;
                    if (item == null) continue;

                    Image productImage = null;
                    if (item.product_image != null && item.product_image.Length > 0)
                    {
                        try
                        {
                            using (var ms = new System.IO.MemoryStream(item.product_image))
                            {
                                using (var img = Image.FromStream(ms))
                                {
                                    productImage = new Bitmap(img);
                                }
                            }
                        }
                        catch { productImage = null; }
                    }

                    products.Add(new ProductData
                    {
                        Id = item.product_id,
                        Name = item.product_name,
                        Quantity = lot.LotBalance ?? 0,
                        Price = item.UnitPrice ?? 0,
                        Image = productImage,
                        Type = item.ProductTypeName,
                        ReceiveDate = lot.lot_receive_date,
                        Unit = item.product_unit
                    });
                }
            }

            return products;
        }

        private List<ProductData> GetProductsByDateRange(DateTime startDate, DateTime endDate)
        {
            var products = new List<ProductData>();

            using (wearhouseEntities db = new wearhouseEntities())
            {
                DateTime startOfDay = startDate.Date;
                DateTime endOfNextDay = endDate.Date.AddDays(1);

                var lotProj = db.lot
                    .AsNoTracking()
                    .Where(l => l.lot_receive_date >= startOfDay && l.lot_receive_date < endOfNextDay)
                    .Select(l => new
                    {
                        LotBalance = l.lot_balance_qty,
                        l.lot_receive_date,
                        Product = l.product == null ? null : new
                        {
                            l.product.product_id,
                            l.product.product_name,
                            UnitPrice = l.product.product_unitprice,
                            l.product.product_image,
                            l.product.product_unit,
                            ProductTypeName = l.product.producttype == null ? "" : l.product.producttype.producttype_name
                        }
                    })
                    .ToList();

                foreach (var lot in lotProj)
                {
                    var item = lot.Product;
                    if (item == null) continue;

                    Image productImage = null;
                    if (item.product_image != null && item.product_image.Length > 0)
                    {
                        try
                        {
                            using (var ms = new System.IO.MemoryStream(item.product_image))
                            {
                                using (var img = Image.FromStream(ms))
                                {
                                    productImage = new Bitmap(img);
                                }
                            }
                        }
                        catch { productImage = null; }
                    }

                    products.Add(new ProductData
                    {
                        Id = item.product_id,
                        Name = item.product_name,
                        Quantity = lot.LotBalance ?? 0,
                        Price = item.UnitPrice ?? 0,
                        Image = productImage,
                        Type = item.ProductTypeName,
                        ReceiveDate = lot.lot_receive_date,
                        Unit = item.product_unit
                    });
                }
            }

            return products;
        }

        private List<ProductData> GetAllProductsAggregatedFromDatabase()
        {
            var products = new List<ProductData>();

            using (wearhouseEntities db = new wearhouseEntities())
            {
                // ดึงข้อมูลจากตาราง product โดยตรง โดยใช้ product_stock_qty
                var prodProj = db.product
                    .AsNoTracking()
                    .Where(p => p.product_stock_qty > 0)  // แสดงเฉพาะสินค้าที่มีจำนวน > 0
                    .Select(p => new
                    {
                        p.product_id,
                        p.product_name,
                        p.product_stock_qty,
                        UnitPrice = p.product_unitprice,
                        p.product_image,
                        p.product_unit,
                        ProductTypeName = p.producttype == null ? "" : p.producttype.producttype_name,
                        LatestReceiveDate = p.lot.Max(l => (DateTime?)l.lot_receive_date) ?? DateTime.MinValue
                    })
                    .ToList();

                foreach (var item in prodProj)
                {
                    Image productImage = null;
                    if (item.product_image != null && item.product_image.Length > 0)
                    {
                        try
                        {
                            using (var ms = new System.IO.MemoryStream(item.product_image))
                            {
                                using (var img = Image.FromStream(ms))
                                {
                                    productImage = new Bitmap(img);
                                }
                            }
                        }
                        catch { productImage = null; }
                    }

                    products.Add(new ProductData
                    {
                        Id = item.product_id,
                        Name = item.product_name,
                        Quantity = item.product_stock_qty ?? 0,
                        Price = item.UnitPrice ?? 0,
                        Image = productImage,
                        Type = item.ProductTypeName,
                        ReceiveDate = item.LatestReceiveDate,
                        Unit = item.product_unit
                    });
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
            DateFilterForm dateFilterForm = new DateFilterForm();

            if (dateFilterForm.ShowDialog(this) == DialogResult.OK)
            {
                // Get only products within the selected date range
                allProducts = GetProductsByDateRange(dateFilterForm.StartDate, dateFilterForm.EndDate);
                SetDateRangeFilter(dateFilterForm.StartDate, dateFilterForm.EndDate);
            }
        }

        private void ButtonFilterPrice_Click(object sender, EventArgs e)
        {
            PriceFilterForm priceFilterForm = new PriceFilterForm();

            if (priceFilterForm.ShowDialog(this) == DialogResult.OK)
            {
                allProducts = GetAllProductsAggregatedFromDatabase();
                SetPriceRangeFilter(priceFilterForm.MinPrice, priceFilterForm.MaxPrice);
            }
        }

        private void ButtonFilterType_Click(object sender, EventArgs e)
        {
            ProductTypeFilterForm typeFilterForm = new ProductTypeFilterForm(productTypes);

            if (typeFilterForm.ShowDialog(this) == DialogResult.OK)
            {
                allProducts = GetAllProductsAggregatedFromDatabase();
                if (!string.IsNullOrEmpty(typeFilterForm.SelectedProductType))
                {
                    SetProductTypeFilter(typeFilterForm.SelectedProductType);
                }
                else
                {
                    ClearAllFilters();
                }
            }
        }

        private void showproductpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboFilterType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BackBtn_Return_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
