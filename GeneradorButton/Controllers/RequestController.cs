using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fachada;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelos;

namespace GeneradorButton.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAll")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        FachadaModel _fachadaModel;

        [HttpPost]
        public async Task<ActionResult<string>> postButton([FromBody] ButtonModel buttonModel)
        {
            _fachadaModel = new FachadaModel(buttonModel);

            return await _fachadaModel.GenerarHTML();
        }
    }
}