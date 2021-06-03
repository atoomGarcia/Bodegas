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
    [Route("api/Bodega")]
    [ApiController]
    public class BodegaController : ControllerBase
    {
        private readonly UbiBodegasContext _context;

        public BodegaController(UbiBodegasContext context)
        {
            _context = context;
        }


        [HttpGet]
        public List<ExtraeBodegas> Get()
        {
            var ext = _context.ExtraeBodegas.FromSqlRaw("EXECUTE dbo.ExtraeBodegas").ToList();
            return ext;
        }
    }
}
