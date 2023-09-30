using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiApi.Context;
using MiApi.Models;

namespace MiApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EleccionesController : ControllerBase
    {
        private readonly MyDbContext _context;

        public EleccionesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Blog
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Elecciones>>> GetElecci()
        {
          if (_context.Elecciones == null)
          {
              return NotFound();
          }
            return await _context.Elecciones.ToListAsync();
        }

        // GET: api/Blog/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Elecciones>> GetBlog(int id)
        {
          if (_context.Elecciones == null)
          {
              return NotFound();
          }
            var blog = await _context.Elecciones.FindAsync(id);

            if (blog == null)
            {
                return NotFound();
            }

            return blog;
        }

    }
}
 