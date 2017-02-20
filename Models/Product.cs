using System.Collections.Generic;
 
namespace PrototypeApi.DbModels
{
    public class Product
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Prix { get; set; }
        public string Image { get; set; }
        public List<Product> Products { get; set; }
    }
}