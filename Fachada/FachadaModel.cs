using Modelos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fachada
{
    public class FachadaModel
    {
        IGenerate _model;

        public FachadaModel(IGenerate model)
        {
            _model = model;
        }

        public async Task<string> GenerarHTML()
        {
            return await _model.GenerateHTML();
        }
    }
}
