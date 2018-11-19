using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fachada;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelos;

namespace GeneradorInput.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAll")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        FachadaModel _fachadaModel;

        [HttpPost]
        public async Task<ActionResult<string>> postInput([FromBody] InputModel inputModel)
        {
            _fachadaModel = new FachadaModel(inputModel);

            return await _fachadaModel.GenerarHTML();
        }
    }
}