using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class InputModel : IGenerate
    {
        public string type { get; set; }
        public string name { get; set; }
        public string placeHolder { get; set; }
        public string label { get; set; }
        public string src { get; set; }
        public List<InputOptions> options { get; set; }

        public async Task<string> GenerateHTML()
        {
            string html = "", rcHtml = "", cbHtml = "";

            {
                case "button":
                case "submit":
                    break;
                case "image":
                    break;
                case "radio":
                    foreach (var item in options)
                    {
                    }

                    break;
                case "checkbox":
                    foreach (var item in options)
                    {
                    }

                    htmlCode = String.Concat("<div>", cbHtml, "</div>");
                    break;
                default:
                    break;
            }


            return html;
        }
    }

    public class InputOptions
    {
        public string name { get; set; }
        public string value { get; set; }
    }
}
