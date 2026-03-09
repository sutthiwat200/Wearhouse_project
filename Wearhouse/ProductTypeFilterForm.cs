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
    public partial class ProductTypeFilterForm : Form
    {
        public string SelectedProductType { get; set; }
        private List<string> productTypes;

        public ProductTypeFilterForm(List<string> types)
        {
            InitializeComponent();
            this.productTypes = types ?? new List<string>();
        }

        private void ProductTypeFilterForm_Load(object sender, EventArgs e)
        {
            // Load product types into ComboBox
            comboBoxProductType.Items.Clear();
            comboBoxProductType.Items.Add(""); // Empty option
            
            foreach (var type in productTypes)
            {
                comboBoxProductType.Items.Add(type);
            }
            
            comboBoxProductType.SelectedIndex = 0;
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            try
            {
                SelectedProductType = comboBoxProductType.SelectedItem?.ToString() ?? "";
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ข้อผิดพลาด: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
