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
    public class ListController : ControllerBase
    {
        private readonly PackContext _context;

        public ListController(PackContext context)
        {
            _context = context;

            if (_context.PackLists.Count() == 0)
            {
                // Create a new PackList if collection is empty,
                // which means you can't delete all PackList.
                PackList packList1 = new PackList { Description = "List1" };
                packList1.PackItems.Add(new PackItem { Description = "PackItem1ListItem1", Weight = 25, Volume = 30 } );
                packList1.PackItems.Add(new PackItem { Description = "PackItem1ListItem2", Weight = 5, Volume = 10 } );

                _context.PackLists.Add(packList1);
                
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PackList>>> GetPackLists()
        {
            return await _context.PackLists.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PackList>> GetPackList(long id)
        {
            var item = await _context.PackLists.FindAsync(id);

            if(item == null) 
            {
                return NotFound();
            }

            return item;
        }
    }
}