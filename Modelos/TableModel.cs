using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class TableModel : IGenerate
    {
        public string url { get; set; }
        public String title { get; set; }
        public List<Encabezado> encabezados { get; set; }

        public async Task<string> GenerateHTML()
        {

            return $"{await RetornarBody()}<script>{await RetornarVue()}</script>";
        }

        private async Task<string> RetornarBody()
        {
            String response = "<div id='tablespace'><v-app id='inspire'><v-card><v-card-title>{{title}}<v-spacer></v-spacer><v-text-field v-model=\"search\" append-icon=\"search\" label=\"Search\" single-line hide-details></v-text-field></v-card-title><v-data-table :headers=\"headers\" :items=\"dataBody\" :search=\"search\"><template slot=\"items\" slot-scope=\"props\">";
            foreach (var encabezado in encabezados)
            {
                response += String.Concat("<td>{{ props.item.", encabezado.value, " }}</td>");
            }
            response += "</template><v-alert slot=\"no-results\" :value=\"true\" color='error' icon='warning'>No hay resultados para la busqueda \"{{ search }}\".</v-alert></v-data-table></v-card></v-app></div>";
            return response;
        }

        private async Task<string> RetornarVue()
        {
            String response = "new Vue({ el: '#tablespace', data() { return { search: '',";
            response += $"title: '{title}', headers: [";
            foreach (var encabezado in encabezados)
            {
                response += String.Concat("{ ", $"text: '{encabezado.text}', value: '{encabezado.value}'", " },");
            }
            response = $"{response.TrimEnd(',')}], dataBody: []";
            response += "}},methods: { ListarCategorias: function () { axios({ method: 'get', ";
            response += $"url: '{url}', data: '', ";
            response += "headers: { 'Content-Type': 'application/json; charset=utf-8' }}).then(response => { this.dataBody = response.data; }).catch(function (error) { console.log('Error get: ' + error); });}}, created() { this.ListarCategorias(); }});";
            return response;
        }
    }

    public class Encabezado
    {
        public String text { get; set; }
        public String value { get; set; }
    }
}
