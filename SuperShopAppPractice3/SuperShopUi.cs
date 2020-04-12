using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperShopAppPractice3
{
    public partial class SuperShopUi : Form
    {
        public SuperShopUi()
        {
            InitializeComponent();
        }
        Shop aShop;
        Product product;
        private void ShopSaveButton_Click(object sender, EventArgs e)
        {
            aShop = new Shop();
            aShop.Name = nameTextBox.Text;
            aShop.Address = addressTextBox.Text;
        }

        private void ProductSaveButton_Click(object sender, EventArgs e)
        {
            product = new Product();
            product.item_id = Convert.ToInt32(itemTextBox.Text);
            product.quantity = Convert.ToInt32(quantityTextBox.Text);
            aShop.AddProduct(product);
        }

        private void ShowDetailsButton_Click(object sender, EventArgs e)
        {
            if (product == null)
            {
                MessageBox.Show("Please Insert Item");
            }
            else
            {
                MessageBox.Show(aShop.GetResult());
            }
        }
    }
}
