using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bodegas.Models;
using Bodegas.SPs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Data.Entity;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Bodegas.Controllers
{
    [Produces("application/json")]
    [Route("api/InsertaUbi")]
    [ApiController]
    public class InsertarUbicacionController : ControllerBase
    {
        private readonly UbiBodegasContext _context;

        public InsertarUbicacionController(UbiBodegasContext context)
        {
            _context = context;
        }


        /* public async Task<InsertarAsignaciones> Post([FromBody] InsertarAsignaciones articulo)
         {
                 var parameters = new
                 {
                     ClaveUbicaion = articulo.ClaveUbicaion,
                     ClaveArticulo = articulo.ClaveArticulo,
                     Piezas = articulo.Piezas,
                     NombreUbicacion = articulo.NombreUbicacion,
                     PiezasMaximas = articulo.PiezasMaximas,
                     ClaveBodega = articulo.ClaveBodega
             };
              _context.InsertarAsignaciones.FromSqlRaw("EXECUTE dbo.InsertarAsignaciones ", parameters);

             return NoContentResult();
         }*/
        [HttpPost]
        public List<InsertarAsignaciones> AddUbi(InsertarAsignaciones articulo)
        {
            var ext = _context.InsertarAsignaciones.FromSqlRaw("EXECUTE dbo.InsertarAsignaciones", articulo).ToList();

            //_context.InsertarAsignaciones.FromSqlRaw("EXECUTE dbo.InsertarAsignaciones " + articulo.ClaveUbicaion + "," + articulo.ClaveArticulo + "," + articulo.Piezas + "," + articulo.NombreUbicacion + "," + articulo.PiezasMaximas + "," + articulo.ClaveBodega);
             _context.SaveChanges();

            return ext;
        }
    }
}
