using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InventoryAPI.Data;
using InventoryAPI.Models;

namespace InventoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ItemsController : ControllerBase
    {
        private readonly InventoryAPIContext _context;

        public ItemsController(InventoryAPIContext context)
        {
            _context = context;
        }


        // GET: api/items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InventoryItem >>> GetItems()
        {
            if (_context.InventoryItems == null)
            {
                return NotFound();
            }
            return await _context.InventoryItems.ToListAsync();
        }

        // GET: api/items/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InventoryItem >> GetItem(int id)
        {
            if (_context.InventoryItems == null)
            {
                return NotFound();
            }
            var inventoryDetail = await _context.InventoryItems.FindAsync(id);

            if (inventoryDetail == null)
            {
                return NotFound();
            }

            return inventoryDetail;
        }


        // POST: api/items
        [HttpPost]
        public async Task<ActionResult<InventoryItem >> PostItem(InventoryItem  inventoryItem)
        {
            if (_context.InventoryItems == null)
            {
                return Problem("Entity Not Found");
            }
            _context.InventoryItems.Add(inventoryItem);
            await _context.SaveChangesAsync();

            return Ok(await _context.InventoryItems.ToListAsync());
        }

        // PUT: api/items/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(int id, InventoryItem  inventoryItem)
        {
            if (id != inventoryItem.ItemID)
            {
                return BadRequest();
            }

            _context.Entry(inventoryItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(await _context.InventoryItems.ToListAsync());
        }

        // DELETE: api/items/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            if (_context.InventoryItems == null)
            {
                return NotFound();
            }
            var inventoryDetail = await _context.InventoryItems.FindAsync(id);
            if (inventoryDetail == null)
            {
                return NotFound();
            }

            _context.InventoryItems.Remove(inventoryDetail);
            await _context.SaveChangesAsync();

            return Ok(await _context.InventoryItems.ToListAsync());
        }

        private bool ItemExists(int id)
        {
            return (_context.InventoryItems?.Any(e => e.ItemID == id)).GetValueOrDefault();
        }
    }
}
