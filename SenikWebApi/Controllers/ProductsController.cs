using Application.IRepositories;
using AutoMapper;
using Domain;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SenikWebApi.Models;

namespace SenikWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductsController(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    // GET: api/Products?name=abc
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductVM>>> GetProducts([FromQuery]string? name)
    {
        try
        {
            var products = new List<Product>();
            if (!name.IsNullOrEmpty())
            {
                products = await _productRepository.GetProductByNameAsync(name!);
            } else
            {
                products = await _productRepository.GetAllProductsAsync();
            }

            products = products.OrderByDescending(x => x.CreationDate).ToList();

            return Ok(_mapper.Map<List<ProductVM>>(products));
        }
        catch (Exception ex)
        {
            return BadRequest(new { ErrorMessage = ex.Message });
        }
    }

    // GET: api/Products/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductVM>> GetProduct(int id)
    {
        var product = await _productRepository.GetProductByIdAsync(id);

        if (product == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<ProductVM>(product));
    }

    // PUT: api/Products/5    
    [HttpPut("{id}")]
    [Authorize(Roles = "Staff")]
    public async Task<IActionResult> PutProduct(int id, ProductModel model)
    {
        try
        {
            var product = _mapper.Map<Product>(model);
            product.Id = id;
            await _productRepository.UpdateProductAsync(product);
        }
        catch (ArgumentException ex)
        {
            return NotFound(new { ErrorMessage = ex.Message });
        }
        catch (Exception ex)
        {
            return BadRequest(new { ErrorMessage = ex.Message });
        }

        return NoContent();
    }

    // POST: api/Products    
    [HttpPost]
    [Authorize(Roles = "Staff")]    
    public async Task<ActionResult<Product>> PostProduct(ProductModel model)
    {
        var product = _mapper.Map<Product>(model);
        try
        {
            await _productRepository.AddProductAsync(product);
        }
        catch (Exception ex)
        {
            return BadRequest(new { ErrorMessage = ex.Message });
        }

        return CreatedAtAction("GetProduct", new { id = product.Id }, _mapper.Map<ProductVM>(product));
    }

    // DELETE: api/Products/5
    [HttpDelete("{id}")]
    [Authorize(Roles = "Staff")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        try
        {
            await _productRepository.DeleteProductAsync(id);
        }
        catch (ArgumentException ex)
        {
            return NotFound(new { ErrorMessage = ex.Message });
        }
        catch (Exception ex)
        {
            return BadRequest(new { ErrorMessage = ex.Message });
        }

        return NoContent();
    }

    // GET: api/products/categories
    [HttpGet("categories")]
    public ActionResult<IEnumerable<CategoryVM>> GetProductCategories()
    {
        try
        {
            var categories = new List<CategoryVM>();
            int i = 0;
            foreach(var category in _productRepository.GetAllCategories())
            {
                categories.Add(new CategoryVM { Id = i++, Name = category });
            }
            return Ok(categories);
        }
        catch (Exception ex)
        {
            return BadRequest(new { ErrorMessage = ex.Message });
        }
    }

    // GET: api/products/status
    [HttpGet("status")]
    public ActionResult<IEnumerable<CategoryVM>> GetProductStatus()
    {
        try
        {
            var status = new List<CategoryVM>();
            int i = 0;
            foreach (var s in _productRepository.GetAllStatus())
            {
                status.Add(new CategoryVM { Id = i++, Name = s });
            }
            return Ok(status);
        }
        catch (Exception ex)
        {
            return BadRequest(new { ErrorMessage = ex.Message });
        }
    }

    // DELETE: api/Products/harddelete/5
    [HttpDelete("harddelete/{id}")]
    [Authorize(Roles = "Staff")]
    public async Task<IActionResult> HardDeleteProduct(int id)
    {
        try
        {
            await _productRepository.HardDeleteProductAsync(id);
        }
        catch (ArgumentException ex)
        {
            return NotFound(new { ErrorMessage = ex.Message });
        }
        catch (Exception ex)
        {
            return BadRequest(new { ErrorMessage = ex.Message });
        }

        return NoContent();
    }

    // GET: api/Products/Cactus
    [HttpGet("cactus")]
    public async Task<ActionResult<IEnumerable<ProductVM>>> GetCactusProducts([FromQuery] string? name)
    {
        try
        {
            var products = new List<Product>();
            if (!name.IsNullOrEmpty())
            {
                products = await _productRepository.GetProductByNameAsync(name!);
            }
            else
            {
                products = await _productRepository.GetAllProductsAsync();
            }

            products = products.Where(x => x.Category == CategoryEnum.Cactus)
                       .OrderByDescending(x => x.CreationDate).ToList();

            return Ok(_mapper.Map<List<ProductVM>>(products));
        }
        catch (Exception ex)
        {
            return BadRequest(new { ErrorMessage = ex.Message });
        }
    }

    // GET: api/Products/Succulent
    [HttpGet("succulent")]
    public async Task<ActionResult<IEnumerable<ProductVM>>> GetSucculentProducts([FromQuery] string? name)
    {
        try
        {
            var products = new List<Product>();
            if (!name.IsNullOrEmpty())
            {
                products = await _productRepository.GetProductByNameAsync(name!);
            }
            else
            {
                products = await _productRepository.GetAllProductsAsync();
            }

            products = products.Where(x => x.Category == CategoryEnum.Succulent)
                       .OrderByDescending(x => x.CreationDate).ToList();

            return Ok(_mapper.Map<List<ProductVM>>(products));
        }
        catch (Exception ex)
        {
            return BadRequest(new { ErrorMessage = ex.Message });
        }
    }

    // GET: api/Products/vase
    [HttpGet("vase")]
    public async Task<ActionResult<IEnumerable<ProductVM>>> GetVaseProducts([FromQuery] string? name)
    {
        try
        {
            var products = new List<Product>();
            if (!name.IsNullOrEmpty())
            {
                products = await _productRepository.GetProductByNameAsync(name!);
            }
            else
            {
                products = await _productRepository.GetAllProductsAsync();
            }

            products = products.Where(x => x.Category == CategoryEnum.Vase)
                       .OrderByDescending(x => x.CreationDate).ToList();

            return Ok(_mapper.Map<List<ProductVM>>(products));
        }
        catch (Exception ex)
        {
            return BadRequest(new { ErrorMessage = ex.Message });
        }
    }

    // GET: api/Products/decoration
    [HttpGet("decoration")]
    public async Task<ActionResult<IEnumerable<ProductVM>>> GetDecorationProducts([FromQuery] string? name)
    {
        try
        {
            var products = new List<Product>();
            if (!name.IsNullOrEmpty())
            {
                products = await _productRepository.GetProductByNameAsync(name!);
            }
            else
            {
                products = await _productRepository.GetAllProductsAsync();
            }

            products = products.Where(x => x.Category == CategoryEnum.Decoration)
                       .OrderByDescending(x => x.CreationDate).ToList();

            return Ok(_mapper.Map<List<ProductVM>>(products));
        }
        catch (Exception ex)
        {
            return BadRequest(new { ErrorMessage = ex.Message });
        }
    }

    // GET: api/Products/plant
    [HttpGet("plant")]
    public async Task<ActionResult<IEnumerable<ProductVM>>> GetPlantProducts([FromQuery] string? name)
    {
        try
        {
            var products = new List<Product>();
            if (!name.IsNullOrEmpty())
            {
                products = await _productRepository.GetProductByNameAsync(name!);
            }
            else
            {
                products = await _productRepository.GetAllProductsAsync();
            }

            products = products.Where(x => x.Category == CategoryEnum.Succulent 
                                        || x.Category == CategoryEnum.Cactus)
                       .OrderByDescending(x => x.CreationDate).ToList();

            return Ok(_mapper.Map<List<ProductVM>>(products));
        }
        catch (Exception ex)
        {
            return BadRequest(new { ErrorMessage = ex.Message });
        }
    }

}
