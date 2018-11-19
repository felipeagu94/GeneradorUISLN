using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class SelectModel : IGenerate
    {
        public string name { get; set; }
        public String label { get; set; }
        public List<SelectOptions> options { get; set; }

        public async Task<string> GenerateHTML()
        {
            String codigoHtml = $"<label for='{name}'>{label}</label><select class='selectpicker form-control' data-live-search='true' id='{name}' title='Seleccione una opción' v-model='{name}'>";
            foreach (var datoActual in options)
            {
                codigoHtml = $"{codigoHtml}<option value='{datoActual.value}'>{datoActual.text}</option>";
            }
            codigoHtml = $"{codigoHtml}</select>";
            return codigoHtml;
        }
    }

    public class SelectOptions
    {
        public string text { get; set; }
        public string value { get; set; }
    }
}
