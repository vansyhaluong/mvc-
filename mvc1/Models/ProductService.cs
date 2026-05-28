namespace mvc1.Models
{
    public class ProductService
    {
        public static List<Product> _products = new List<Product>
            {
                new Product { Id = 1, Name = "Laptop", Price = 1200 },
                new Product { Id = 2, Name = "Smartphone", Price = 1000 },
                new Product { Id = 3, Name = "Headphones", Price = 6000 }
            };
        
        public List<Product> GetAllProducts()
        {
            return _products;
        }
        public Product? GetProductById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }
        public void AddProduct(Product product)
        {
            _products.Add(product);
        }
        public void removeProduct(int id)
        {
            var product = GetProductById(id);
            if (product != null)
            {
                _products.Remove(product);
            }
        }
        public void updateProduct(Product p)
        {
            var product = GetProductById(p.Id);
            if (product != null)
            {
                product.Name = p.Name;
                product.Price = p.Price;
            }
        }
    }
}
