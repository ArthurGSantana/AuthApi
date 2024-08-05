using Microsoft.AspNetCore.Mvc;

namespace AuthApi;

[ApiController]
[Route("api/[controller]")]
public class ProductController(IProduct _product) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> List()
    {
        var products = await _product.List();

        return Ok(products);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Product product)
    {
        await _product.Add(product);

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update(Product product)
    {
        await _product.Update(product);

        return Ok();
    }
}
