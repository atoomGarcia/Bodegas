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
    [Route("api/ExtraeArticulos")]
    [ApiController]
    public class ExtraeArticulosController : ControllerBase
    {
        private readonly UbiBodegasContext _context;

        public ExtraeArticulosController(UbiBodegasContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<ExtraeArticulos> GetArt()
        {
            var ext = _context.ExtraeArticulos.FromSqlRaw("EXECUTE dbo.ExtraeArticulos").ToList();
            return ext;
        }
    }
}
