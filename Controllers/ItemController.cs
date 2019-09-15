using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StuffPack.Models;

namespace StuffPack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly PackContext _context;

        public ItemController(PackContext context)
        {
            _context = context;

            if (_context.PackItems.Count() == 0)
            {
                // Create a new PackItem if collection is empty,
                // which means you can't delete all PackItem.
                _context.PackItems.Add(new PackItem { Description = "Item1" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PackItem>>> GetPackItems()
        {
            return await _context.PackItems.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PackItem>> GetPackItem(long id)
        {
            var item = await _context.PackItems.FindAsync(id);

            if(item == null) 
            {
                return NotFound();
            }

            return item;
        }

        [HttpPost]
        public async Task<ActionResult<PackItem>> PostPackItem(PackItem item)
        {
            _context.PackItems.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPackItem), new { id = item.Id }, item);
        }
    }
}