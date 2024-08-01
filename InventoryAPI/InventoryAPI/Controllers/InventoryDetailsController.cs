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

    public class InventoryDetailsController : ControllerBase
    {
        private readonly InventoryAPIContext _context;

        public InventoryDetailsController(InventoryAPIContext context)
        {
            _context = context;
        }


        // GET: api/items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InventoryDetail>>> GetInventoryItems()
        {
            if (_context.InventoryDetails == null)
            {
                return NotFound();
            }
            return await _context.InventoryDetails.ToListAsync();
        }

        // GET: api/items/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InventoryDetail>> GetInventoryItem(int id)
        {
            if (_context.InventoryDetails == null)
            {
                return NotFound();
            }
            var inventoryDetail = await _context.InventoryDetails.FindAsync(id);

            if (inventoryDetail == null)
            {
                return NotFound();
            }

            return inventoryDetail;
        }


        // POST: api/items
        [HttpPost]
        public async Task<ActionResult<InventoryDetail>> PostInventoryItem(InventoryDetail inventoryItem)
        {
            if (_context.InventoryDetails == null)
            {
                return Problem("Entity Not Found");
            }
            _context.InventoryDetails.Add(inventoryItem);
            await _context.SaveChangesAsync();

            return Ok(await _context.InventoryDetails.ToListAsync());
        }

        // PUT: api/items/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInventoryItem(int id, InventoryDetail inventoryItem)
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
                if (!InventoryItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(await _context.InventoryDetails.ToListAsync());
        }

        // DELETE: api/items/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventoryItem(int id)
        {
            if (_context.InventoryDetails == null)
            {
                return NotFound();
            }
            var inventoryDetail = await _context.InventoryDetails.FindAsync(id);
            if (inventoryDetail == null)
            {
                return NotFound();
            }

            _context.InventoryDetails.Remove(inventoryDetail);
            await _context.SaveChangesAsync();

            return Ok(await _context.InventoryDetails.ToListAsync());
        }

        private bool InventoryItemExists(int id)
        {
            return (_context.InventoryDetails?.Any(e => e.ItemID == id)).GetValueOrDefault();
        }
    }
}
