using Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Fachada
{
    public class FachadaUI
    {
        String _urlInput = "https://localhost:44378/";
        String _urlButton = "https://localhost:44344/";
        String _urlSelect = "https://localhost:44333/";

        public async Task<string> GenerarHTML(DefaultModel model)
        {
            String response = String.Empty;
            String json = String.Empty;
            String claseCols = await GenerarCols(model.cols);
            foreach (var input in model.input)
            {
                json = JsonConvert.SerializeObject(input);
                response = $"{response} <v-flex {claseCols}>{await HacerPost(json,$"{_urlInput}api/request")}</v-flex>";
            }
            foreach (var select in model.select)
            {
                json = JsonConvert.SerializeObject(select);
                response = $"{response} <v-flex {claseCols}>{await HacerPost(json, $"{_urlSelect}api/request")}</v-flex>";
            }
            foreach (var button in model.button)
            {
                response = $"{response} <v-flex {claseCols}>{await HacerPost(json, $"{_urlButton}api/request")}</v-flex>";
            }
            response = $"<div id='{model.formId}'><v-app><v-layout row wrap>{response}</v-layout></v-app></div>";


            return response;
        }

        public async Task<string> GenerarScript(DefaultModel model)
        {
            return $"<script>{await GenerarVuejs(model)}</script>";
        }

        private async Task<string> GenerarVuejs(DefaultModel model)
        {
            string response = "var demo = new Vue({";
            response = $"{response}el: '#{model.formId}',";
            // variables del objeto Vue
            response += "data: {datemenu:false, items:[],";
            response = await GenerarDatos(model, response);
            response += "}, methods: {";
            // envio Axios del formulario
            response += "submit: function (){axios({";
            response = $"{response} method: '{model.method}',url: '{model.action}',";
            response += "data: {";
            response = await GenerarDataObjet(model, response);
            response += "}, headers: { 'Content-Type': 'application/json; charset=utf-8' }}).then(response => {alert('Se ha guardado exitosamente!');}).catch(function (error) {console.log(error); alert('Ocurrio un Error!');});}";

            response += "}});";
            return response;
        }

        private async Task<string> GenerarSelectOptions(List<SelectOptions> so)
        {
            string selectItems = "";
            foreach (var item in so)
            {
                selectItems += String.Concat("'", item.text, "'");
            }
            selectItems = String.Concat("[", selectItems.Replace("''", "','"), "]");
            return selectItems;
        }

        private async Task<string> GenerarDatos(DefaultModel model, string response)
        {
            foreach (var name in model.input)
            {
                response = $"{response} {name.name}: '',";
            }
            foreach (var name in model.select)
            {
                response = $"{response} {name.name}: '',";
            }
            response = response.TrimEnd(',');
            return response;
        }

        private async Task<string> GenerarDataObjet(DefaultModel model, string response)
        {
            foreach (var name in model.input)
            {
                response = $"{response} {name.name}: this.{name.name},";
            }
            foreach (var name in model.select)
            {
                response = $"{response} {name.name}: this.{name.name},";
            }
            response = response.TrimEnd(',');
            return response;
        }

        private async Task<String> GenerarCols(String cols)
        {
            string claseCols = String.Empty;
            switch (cols)
            {
                case "2":
                    claseCols = "xs6";
                    break;
                case "3":
                    claseCols = "xs4";
                    break;
                case "4":
                    claseCols = "xs3";
                    break;
                case "6":
                    claseCols = "xs2";
                    break;
                default:
                    claseCols = "xs12";
                    break;
            }

            return claseCols;
        }

        private async Task<String> HacerPost(String json, String url)
        {
            WebRequest request = WebRequest.Create(url);
            request.Method = "POST";
            string postData = json;
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentType = "application/json";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            WebResponse response = request.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            response.Close();

            return responseFromServer;
        }
    }
}
