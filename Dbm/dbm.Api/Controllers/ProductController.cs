using dbm.Api.DTO;
using dbm.Api.Models;
using dbm.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace dbm.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var produtos = await _productService.GetAllAsync();
        return Ok(produtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var produto = await _productService.GetByIdAsync(id);
        if (produto == null)
            return NotFound();

        return Ok(produto);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ProductDTO productDto)
    {
        if (productDto == null)
            return BadRequest();

        await _productService.AddAsync(productDto);
        return CreatedAtAction(nameof(GetById), new { id = productDto.Id }, productDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] ProductDTO productDto)
    {
        if (productDto == null || id != productDto.Id)
            return BadRequest();

        await _productService.UpdateAsync(productDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var produto = await _productService.GetByIdAsync(id);
        if (produto == null)
            return NotFound();

        await _productService.DeleteAsync(id);
        return NoContent();
    }
}

