using Customer_Api.Models;

namespace Products_Api.Data_Access
{
    public interface IProductcs
    {
        public List<ProductsTable> getAllProducts();

        public List<ProductsTable> addProducts(ProductsTable product);

        public void deleteProduct(int ProductId);

        public void updateProduct(ProductsTable product);
    }
}
