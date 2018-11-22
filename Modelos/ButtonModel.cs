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
            return GenerarTipo();
        }

        // Crea el tipo de Etiqueta requerida
        String GenerarTipo()
        {
            string codigoHTML = string.Empty;
            if (type == null) type = String.Empty;
            switch (type.ToLower())
            {
                case "link":
                    codigoHTML = $"<a {GenerarEstilo()} {events}>{value}</a>";
                    break;
                default:
                    codigoHTML = $"<v-btn {GenerarEstilo()} {events}>{value}</v-btn>";
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
                    claseEstilo = "color=\"yellow\"";
                    break;
                case "guardar":
                    claseEstilo = "color=\"success\"";
                    break;
                case "regresar":
                    claseEstilo = "color=\"blue\"";
                    break;
                case "cancelar":
                    claseEstilo = "color=\"warning\"";
                    break;
                case "link":
                    claseEstilo = "color=\"blue\"";
                    break;
                default:
                    claseEstilo = "color=\"blue\"";
                    break;
            }
            return claseEstilo;
        }

    }
}
