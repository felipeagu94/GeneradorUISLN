using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fachada;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelos;

namespace GeneradorSelect.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAll")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        FachadaModel _fachadaModel;

        [HttpPost]
        public async Task<ActionResult<string>> postSelect([FromBody] SelectModel selectModel)
        {
            _fachadaModel = new FachadaModel(selectModel);

            return await _fachadaModel.GenerarHTML();
        }
    }
}