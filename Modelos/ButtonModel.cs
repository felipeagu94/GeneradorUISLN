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
            String codigoHTML = $"{GenerarEstilo()} {events}";
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
                //case "input":
                //    codigoHTML = $"<input type='submit' {codigoHTML} value='{value}'/>";
                //    break;
                default:
                    codigoHTML = $"<div id=\"buttoncontrol\"><v-app id=\"inspire\"><v-btn {codigoHTML}>{value}</v-btn></v-app></div>" +
                        "<script type=\"text/javascript\">new Vue({el:'#buttoncontrol'});</script>";
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
                    claseEstilo = "color=\"info\"";
                    break;
                case "guardar":
                    claseEstilo = "color=\"success\"";
                    break;
                case "regresar":
                    claseEstilo = "color=\"info\"";
                    break;
                case "cancelar":
                    claseEstilo = "color=\"warning\"";
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
