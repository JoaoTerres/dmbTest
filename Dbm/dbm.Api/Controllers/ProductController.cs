using dbm.Api.DTO;
using dbm.Api.Services.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;

namespace dbm.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly IValidator<ProductDTO> _productValidator;

    public ProductController(IProductService productService, IValidator<ProductDTO> productValidator)
    {
        _productService = productService;
        _productValidator = productValidator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAll()
    {
        var productsDto = await _productService.GetAllAsync();
        if (productsDto == null) 
            return NotFound("Products not found");
        

        return Ok(productsDto);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDTO>> GetById(int id)
    {
        var productDto = await _productService.GetByIdAsync(id);
        if (productDto == null)
            return NotFound();

        return Ok(productDto);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ProductDTO productDto)
    {
        //if (productDto == null)
        //    return BadRequest("Data Invalid");

        ValidationResult validationResult = await _productValidator.ValidateAsync(productDto);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        await _productService.AddAsync(productDto);
        return CreatedAtAction(nameof(GetById), new { id = productDto.Id }, productDto);
    }

    [HttpPut]
    public async Task<IActionResult> Update(int id, [FromBody] ProductDTO productDto)
    {
        if (productDto == null || id != productDto.Id)
            return BadRequest();


        ValidationResult validationResult = await _productValidator.ValidateAsync(productDto);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        await _productService.UpdateAsync(productDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ProductDTO>> Delete(int id)
    {
        var productDto = await _productService.GetByIdAsync(id);
        if (productDto == null)
            return NotFound("Product not found");

        await _productService.DeleteAsync(id);

        return Ok(productDto);
    }
}

