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
            string htmlCode = "", scriptDate="";
            string html = "", rcHtml = "", cbHtml = "";

            switch (type.ToLower())
            {
                case "button":
                case "submit":
                    htmlCode = $"<v-btn color=\"info\">{label}</v-btn>";
                    break;
                case "image":
                    htmlCode = $"<v-layout row wrap><v-flex><v-img :src=\"`{src}`\"></v-img></v-flex></v-layout>";
                    break;
                case "radio":
                    foreach (var item in options)
                    {
                        rcHtml = String.Concat(rcHtml, $"<v-radio value=\"{item.value}\" label=\"{item.name}\"></v-radio>");
                    }

                    htmlCode = String.Concat($"<v-radio-group label=\"{label}\">", rcHtml, "</v-radio-group>");
                    break;
                case "checkbox":
                    foreach (var item in options)
                    {
                        cbHtml = String.Concat(cbHtml, $"<v-checkbox label=\"{item.name}\"></v-checkbox>");
                    }

                    htmlCode = String.Concat("<div>", cbHtml, "</div>");
                    break;
                case "date":
                    htmlCode ="<v-layout row wrap><v-flex xs12 sm6 md4 ><v-menu :close-on-content-click=\"false\" v-model = \"datemenu\" " +
                        ":nudge-right = \"40\" lazy transition = \"scale-transition\" offset-y full-width min-width = \"290px\" >" +
                        $"<v-text-field slot = \"activator\" v-model = \"date\" label = \"{label}\" prepend-icon = \"event\" readonly> " + 
                        "</v-text-field><v-date-picker v-model = \"date\" @input = \"datemenu = false\"></v-date-picker></v-menu>" +
                        "</v-flex><v-spacer></v-spacer></v- layout>";
                    break;
                default:
                    htmlCode = $"<v-text-field placeholder=\"{placeHolder}\" label=\"{label}\"></v-text-field>";
                    break;
            }

            scriptDate = dateScript();

            html = String.Concat(html, $"<div id=\"inputcontrol\"><v-app id=\"inspire\">", htmlCode, "</v-app></div>", scriptDate);


            return html;
        }

        private string dateScript()
        {
            string script = "<script type=\"text/javascript\">new Vue({el:'#inputcontrol', data:() => ({date: new Date().toISOString().substr(0,10), datemenu:false})});</script>";
            return script;
        }
    }

    public class InputOptions
    {
        public string name { get; set; }
        public string value { get; set; }
    }
}
