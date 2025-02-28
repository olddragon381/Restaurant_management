﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantManager.Server.Database;
using RestaurantManager.Server.Models;

namespace RestaurantManager.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DishesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Dishes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dishes>>> GetDishes()
        {
            return await _context.Dishes.ToListAsync();
        }

        // GET: api/Dishes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dishes>> GetDishes(int id)
        {
            var dishes = await _context.Dishes.FindAsync(id);

            if (dishes == null)
            {
                return NotFound();
            }

            return dishes;
        }

        // PUT: api/Dishes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDishes(int id, Dishes dishes)
        {
            if (id != dishes.DishId)
            {
                return BadRequest();
            }

            _context.Entry(dishes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DishesExists(id))
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

        // POST: api/Dishes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Dishes>> PostDishes(Dishes dishes)
        {
            _context.Dishes.Add(dishes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDishes", new { id = dishes.DishId }, dishes);
        }

        // DELETE: api/Dishes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDishes(int id)
        {
            var dishes = await _context.Dishes.FindAsync(id);
            if (dishes == null)
            {
                return NotFound();
            }

            _context.Dishes.Remove(dishes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DishesExists(int id)
        {
            return _context.Dishes.Any(e => e.DishId == id);
        }
    }
}
