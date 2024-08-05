namespace AuthApi;

public interface IProduct
{
    Task Add(Product product);
    Task Update(Product product);
    Task Delete(Product product);
    Task<Product?> GetById(int id);
    Task<List<Product>> List();
}
