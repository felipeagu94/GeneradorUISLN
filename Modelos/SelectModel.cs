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
            String codigoHtml = $"<v-select v-model=\"{name}\" :items=\"{name}_items\" label = \"{label}\"></v-select>";
            return codigoHtml;
        }
    }

    public class SelectOptions
    {
        public string text { get; set; }
        public string value { get; set; }
    }
}
