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
            string labelHtml = "", htmlCode = "";
            string html = "", rcHtml = "", cbHtml = "";

            labelHtml = $"<label>{label}</label>";
            htmlCode = $"<input type=\"{type}\" name=\"{name}\" ";

            switch (type)
            {
                case "button":
                    htmlCode = String.Concat(htmlCode, $" class='form-control' value=\"{label}\" />");
                    break;
                case "submit":
                    htmlCode = String.Concat(htmlCode, $" class='form-control' value=\"{label}\" />");
                    break;
                case "image":
                    htmlCode = String.Concat(htmlCode, $" src=\"{src}\" />");
                    break;
                case "radio":
                    foreach (var item in options)
                    {
                        rcHtml = String.Concat(rcHtml, "<div class='radio-inline'>", htmlCode, $" value=\"{item.value}\" /> {item.name} </div>");
                    }

                    htmlCode = String.Concat("<div class='form-control' >", rcHtml, "</div>");
                    break;
                case "checkbox":
                    foreach (var item in options)
                    {
                        cbHtml = String.Concat(cbHtml, "<div class='checkbox-inline'>", htmlCode, $" value=\"{item.value}\" /> {item.name} </div>");
                    }

                    htmlCode = String.Concat("<div>", cbHtml, "</div>");
                    break;
                default:
                    htmlCode = String.Concat(htmlCode, $" class='form-control' placeholder=\"{placeHolder}\" v-model=\"{name}\" />");
                    break;
            }

            html = String.Concat(html, $"<div>", labelHtml, htmlCode, "</div>");

            return html;
        }
    }

    public class InputOptions
    {
        public string name { get; set; }
        public string value { get; set; }
    }
}
