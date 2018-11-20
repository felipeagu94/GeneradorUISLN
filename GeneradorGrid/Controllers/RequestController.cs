using Fachada;
using Microsoft.AspNetCore.Mvc;
using Modelos;
using System.Threading.Tasks;

namespace GeneradorGrid.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        FachadaModel _fachadaModel;

        [HttpPost]
        public async Task<ActionResult<string>> postGrid([FromBody] TableModel tableModel)
        {
            _fachadaModel = new FachadaModel(tableModel);

            return await _fachadaModel.GenerarHTML();
        }
    }
}