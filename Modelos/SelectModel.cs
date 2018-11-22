using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class SelectModel : IGenerate
    {
        public string name { get; set; }
        public string label { get; set; }
        public List<SelectOptions> options { get; set; }


        public async Task<string> GenerateHTML()
        {            
            String codigoHtml = $"<v-combobox v-model=\"{name}\" :items=\"items\" label = \"{label}\"></v-combobox>";
            return codigoHtml;
        }
    }

    public class SelectOptions
    {
        public string text { get; set; }
        public string value { get; set; }
    }
}
