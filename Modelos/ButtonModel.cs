using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class ButtonModel : IGenerate
    {
        public string type { get; set; }
        public string name { get; set; }
        public string value { get; set; }
        public string events { get; set; }
        public string style { get; set; }

        public async Task<string> GenerateHTML()
        {
            codigoHTML = GenerarTipo(codigoHTML);

            return codigoHTML;
        }

        // Crea el tipo de Etiqueta requerida
        String GenerarTipo(string codigoHTML)
        {
            if (type == null) type = String.Empty;
            switch (type.ToLower())
            {
                case "link":
                    codigoHTML = $"<a {codigoHTML}>{value}</a>";
                    break;
                default:
                    break;
            }
            return codigoHTML;
        }

        // Seleccionar el formato del boton
        String GenerarEstilo()
        {
            String claseEstilo = String.Empty;
            if (style == null) style = String.Empty;
            switch (style.ToLower())
            {
                case "ayuda":
                    break;
                case "guardar":
                    break;
                case "regresar":
                    break;
                case "cancelar":
                    break;
                case "link":
                    claseEstilo = "class='btn btn-link'";
                    break;
                default:
                    claseEstilo = "class='btn'";
                    break;
            }
            return claseEstilo;
        }
    }
}
