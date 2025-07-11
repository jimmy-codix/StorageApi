﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StorageApi.Data;
using StorageApi.DTOs;
using StorageApi.Models;

namespace StorageApi.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly StorageApiContext _context;

        public ProductsController(StorageApiContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProduct()
        {
            var dtoList = await _context.Product.Select(item => new ProductDto
            {
                Id = item.Id,
                Count = item.Count,
                Name = item.Name,
                Price = item.Price,
            }
            ).ToListAsync();

            return Ok(dtoList);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var product = await _context.Product.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            ProductDto dto = new ProductDto() { 
                Name = product.Name,
                Price= product.Price,
                Id = id,
                Count = product.Count
            };

            return Ok(dto);
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, UpdateProductDto productDto)
        {
            //Fail safe
            if (id != productDto.Id)
            {
                return BadRequest();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            //TODO replace with AutoMapper later.
            product.Id = productDto.Id;
            product.Name = productDto.Name;
            product.Price = productDto.Price;
            product.Count = productDto.Count;
            product.Shelf = productDto.Shelf;
            product.Description = productDto.Description;
            product.Category = productDto.Category;

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductDto>> PostProduct(CreateProductDto dto)
        {

            var product = new Product()
            {
                Name = dto.Name,
                Price = dto.Price,
                Category = dto.Category,
                Shelf = dto.Shelf,
                Description = dto.Description,
                Count = dto.Count
            };

            _context.Product.Add(product);
            await _context.SaveChangesAsync();

            var productDto = new ProductDto() 
            { 
                Id = product.Id, 
                Count = product.Count, 
                Name = product.Name, 
                Price = product.Price 
            }; 

            return CreatedAtAction(nameof(GetProduct), new { id = productDto.Id }, productDto);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/products/stats
        [Route("stats")]
        [HttpGet]
        public async Task<ActionResult<ProductStatsDto>> GetStats()
        {
            var dto = new ProductStatsDto();

            await _context.Product.ForEachAsync(x =>
                {
                    dto.NrOfProducts += x.Count;
                    dto.InventoryValue += x.Price;
                }
            );

            return Ok(dto);
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }
    }
}
