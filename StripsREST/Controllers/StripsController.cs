using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StripsBL.Exceptions;
using StripsBL.Managers;
using StripsBL.Model;
using StripsREST.Exceptions;
using StripsREST.Mappers;

namespace StripsREST.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class StripsController : ControllerBase {
        private StripsManager stripsManager;
        private string url = "http://localhost:5044/api/reeks";

        public StripsController(StripsManager stripsManager) {
            this.stripsManager = stripsManager;
        }

        [HttpGet("{id}")]
        // get list strips from reeks id
        public ActionResult GeefStripreeks(int id) {
            try {
                Reeks stripreeks = stripsManager.GeefStripreeks(id);
                return Ok(MapFromDomain.MapFromStripDomain(url, stripreeks));
            }
            catch (StripException ex) {
                return NotFound(ex.Message);
            }
        }
    }
}