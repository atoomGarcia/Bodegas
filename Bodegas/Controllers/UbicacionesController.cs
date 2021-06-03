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

namespace Bodegas.Controllers
{
    [Produces("application/json")]
    [Route("api/Ubicaciones")]
    [ApiController]
    public class UbicacionesController : ControllerBase
    {
        private readonly UbiBodegasContext _context;

        public UbicacionesController(UbiBodegasContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<ExtraeUbicaciones> GetUbi()
        { 
            var ext= _context.ExtraeUbicaciones.FromSqlRaw("EXECUTE dbo.ExtraeUbicaciones").ToList();
            return ext;
        }

        [HttpPost("{producto}")]
        //[Route("api/Ubicaciones/{producto}")]
        public List<InsertarAsignaciones> AddUbi(string producto) 
        {
            var ext = _context.InsertarAsignaciones.FromSqlRaw("EXECUTE dbo.InsertarAsignaciones " + producto).ToList(); //1,2,20,'ESTANTE B',200,1").ToList();
            return ext;


        }

        public class ubi
        {

            public string NombreBodega { get; set; }
            public string DescripcionCorta { get; set; }
            public string NombreUbicacion { get; set; }
            public int Piezas { get; set; }

            public int PiezasMaximas { get; set; }

        }
    }
}
