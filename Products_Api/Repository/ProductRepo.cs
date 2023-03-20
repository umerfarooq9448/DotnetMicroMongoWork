using Customer_Api.Models;
using Products_Api.Data_Access;

namespace Products_Api.Repository
{
    public class ProductRepo : IProductcs
    {
        public readonly MicroserviceContext _context;

        public ProductRepo(MicroserviceContext context)
        {
            _context = context;
            
        }
        public List<ProductsTable> addProducts(ProductsTable product)
        {
            _context.ProductsTables.Add(product);
            _context.SaveChanges();
            return _context.ProductsTables.ToList();
        }

        public void deleteProduct(int ProductId)
        {
            var data = _context.ProductsTables.FirstOrDefault(x => x.ProductId == ProductId);

            if (data != null)
            {

                _context.ProductsTables.Remove(data);
                _context.SaveChanges();
            }

        }

        public List<ProductsTable> getAllProducts()
        {
            return _context.ProductsTables.ToList();
            
        }

        public void updateProduct(ProductsTable product)
        {
            var findproduct = _context.ProductsTables.Find(product.ProductId);
            findproduct.ProductName = product.ProductName;
            findproduct.ProductDescription = product.ProductDescription;
            findproduct.ProductPrice = product.ProductPrice;
            

            _context.SaveChanges();

        }
    }
}
