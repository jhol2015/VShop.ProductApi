﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.Services;

namespace VShop.ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]//localhost/api/categories
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            var categoriesDto = await _categoryService.GetCategories();

            if (categoriesDto == null)
                return NotFound("Categories not found");
            return Ok(categoriesDto);
        }

        [HttpGet("{products}")]//localhost/api/categories/products
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategoriasProducts()
        {
            var categoriesDto = await _categoryService.GetCategoriesProducts();

            if (categoriesDto == null)
                return NotFound("Categories not found");
            return Ok(categoriesDto);
        }

        [HttpGet("{id:int}", Name = "GetCategory")]//localhost/api/categories/1
        public async Task<ActionResult<CategoryDTO>> Get(int id)
        {
            var categoryDto = await _categoryService.GetCategoryById(id);

            if (categoryDto == null)
                return NotFound("Category not found");
            return Ok(categoryDto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoryDTO categoryDto)
        {
            if (categoryDto == null)
                return BadRequest("Invalid Data");

            await _categoryService.AddCategory(categoryDto);

            return new CreatedAtRouteResult("GetCategory", new { id = categoryDto.CategoryId }, categoryDto);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] CategoryDTO categoryDto)
        {
            if (categoryDto == null || categoryDto.CategoryId != id)
                return BadRequest("Invalid Data");

            if (categoryDto == null)
                return BadRequest("CategoryDto null");

            await _categoryService.UpdateCategory(categoryDto);

            return Ok(categoryDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var categoryDto = await _categoryService.GetCategoryById(id);

            if (categoryDto == null)
                return NotFound("Category not found");

            await _categoryService.RemoveCategory(id);

            return Ok(categoryDto);
        }
    }
}

