
using Microsoft.EntityFrameworkCore;

namespace AuthApi;

public class ProductRepository(DbContextOptions<ContextBase> contextBase) : IProduct
{
    public async Task Add(Product product)
    {
        using var context = new ContextBase(contextBase);

        await context.Set<Product>().AddAsync(product);
        await context.SaveChangesAsync();
    }

    public async Task Delete(Product product)
    {
        using var context = new ContextBase(contextBase);

        context.Set<Product>().Remove(product);
        await context.SaveChangesAsync();
    }

    public async Task<Product?> GetById(int id)
    {
        using var context = new ContextBase(contextBase);

        return await context.Set<Product>().FindAsync(id);
    }

    public async Task<List<Product>> List()
    {
        using var context = new ContextBase(contextBase);

        return await context.Set<Product>().ToListAsync();
    }

    public async Task Update(Product product)
    {
        using var context = new ContextBase(contextBase);

        context.Set<Product>().Update(product);
        await context.SaveChangesAsync();
    }
}
