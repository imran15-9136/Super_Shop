using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperShopAppPractice3
{
    public class Shop
    {
        public string Name { get; set; }
        public string Address { get; set; }
        private List<Product> _products;
        public Shop()
        {
            _products = new List<Product>();
        }

        public string GetProductId()
        {
            
        }
        public bool AddProduct(Product product)
        {
            if (_products.Count != 0)
            {
               
                    if (_products.item_id == product.item_id)
                    {
                        _products.quantity += product.quantity;
                        break;
                    }
                    else
                    {
                        _products.Add(product);
                    }
                
            }
            else
            {
                _products.Add(product);
            }
            return true;
        }

public string GetResult()
{
    string message = "";
    message += "Shop Name: " + Name + "\t\t" + "Address: " + Address + Environment.NewLine;
    message += "Product Id" + "\t\t" + "Product Quantity" + Environment.NewLine;
    foreach (var item in _products)
    {
        message += item.item_id + "\t\t" + item.quantity + Environment.NewLine;
    }
    return message;
}
    }
}
