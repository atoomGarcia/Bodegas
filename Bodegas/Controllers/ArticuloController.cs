using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bodegas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bodegas.Controllers
{
    [Produces("application/json")]
    [Route("api/Articulo")]
    [ApiController]
    public class ArticuloController : Controller
    {
        private readonly UbiBodegasContext _context;

        public ArticuloController(UbiBodegasContext context)
        {
           _context = context;
        }

        [HttpGet]
        public List<Articulo> Get()
        {
            return _context.Articulos.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Articulo>> GetArticulo( int id)
        {
            var producto = await _context.Articulos.FindAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            return producto;


        }

        [HttpPost]
        public async Task<ActionResult<Articulo>> PostArticulo(Articulo articulo)
        {
            _context.Articulos.Add(articulo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArticulo", new { id = articulo.ClaveArticulo }, articulo);
        }

        [HttpPut("{id}")]
        public IActionResult PutArticulos(int id, [FromBody] Articulo producto)
        {

            var target = _context.Articulos.FirstOrDefault(ct => ct.ClaveArticulo == id);
            if (target == null)
            {
                return NotFound();
            }
            else
            {
                target.ClaveArticulo = producto.ClaveArticulo;
                target.DescripcionCorta= producto.DescripcionCorta;
                target.Descripcion = producto.Descripcion;
                target.CodigoBarras = producto.CodigoBarras;

                _context.Articulos.Update(target);
                _context.SaveChanges();
                return new NoContentResult();
            }

        }


    }

    public class Art
    {
        public int ClaveArticulo { get; set; }
        public string DescripcionCorta { get; set; }
        public string Descripcion { get; set; }
        public int CodigoBarras { get; set; }

    }
    public class newArticulo
    {
        public string DescripcionCorta { get; set; }
        public string Descripcion { get; set; }
        public int CodigoBarras { get; set; }

    }
    

}
