using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FeriaMaipoGrande.Datos
{
    public class DBApi
    {
        string url = "https://api-feria-web-production.up.railway.app/api/";
        string url2 = "http://localhost:3001/api/";
        /* METODOS PARA EL MANTENEDOR DE PERSONAS */
        public dynamic GetPersonas(string path)
        {
            HttpWebRequest myWebRequest = (HttpWebRequest)WebRequest.Create(string.Concat(url, path));
            myWebRequest.UserAgent = " Mozilla / 5.0 ( Windows NT 6.1 ; WOW64 ; rv : 23.0 ) Gecko / 20100101 Firefox / 23.0 ";
            //myWebRequest.CookieContainer = myCookie ;
            myWebRequest.Credentials = CredentialCache.DefaultCredentials;
            myWebRequest.Proxy = null;
            HttpWebResponse myHttpWebResponse = (HttpWebResponse)myWebRequest.GetResponse();
            Stream myStream = myHttpWebResponse.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myStream);
            // Leemos los datos
            string Datos = HttpUtility.HtmlDecode(myStreamReader.ReadToEnd());
            dynamic data = JsonConvert.DeserializeObject(Datos);
            return data;
        }

       public async Task<HttpStatusCode> DeletePersonaAsync(string path, string numIdentificador)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.DeleteAsync(String.Concat(url, path, numIdentificador));
            return response.StatusCode;
        }
        
        public async Task<Uri> CrearPersonaAsync(string path, PersonaDAO persona)
        {
            HttpClient client = new HttpClient();
            var response = await client.PostAsJsonAsync(string.Concat(url,path), persona);
            response.EnsureSuccessStatusCode();
            // return URI of the created resource.
            return response.Headers.Location;
        }

        public async Task<Uri> ActualizarPersonaAsync(string path, string numIdentificador, PersonaDAO persona)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PutAsJsonAsync(string.Concat(url, path, numIdentificador), persona);
            response.EnsureSuccessStatusCode();

            return response.Headers.Location;
        }
        /* METODOS PARA EL MANTENEDOR DE USUARIOS */

        public dynamic GetUsuarios(string path)
        {
            HttpWebRequest myWebRequest = (HttpWebRequest)WebRequest.Create(string.Concat(url, path));
            myWebRequest.UserAgent = " Mozilla / 5.0 ( Windows NT 6.1 ; WOW64 ; rv : 23.0 ) Gecko / 20100101 Firefox / 23.0 ";
            //myWebRequest.CookieContainer = myCookie ;
            myWebRequest.Credentials = CredentialCache.DefaultCredentials;
            myWebRequest.Proxy = null;
            HttpWebResponse myHttpWebResponse = (HttpWebResponse)myWebRequest.GetResponse();
            Stream myStream = myHttpWebResponse.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myStream);
            // Leemos los datos
            string Datos = HttpUtility.HtmlDecode(myStreamReader.ReadToEnd());
            dynamic data = JsonConvert.DeserializeObject(Datos);
            return data;
        }

        public dynamic GetRoles()
        {
            HttpWebRequest myWebRequest = (HttpWebRequest)WebRequest.Create(string.Concat(url, "usuarios/rol/rol_usuarios"));
            myWebRequest.UserAgent = " Mozilla / 5.0 ( Windows NT 6.1 ; WOW64 ; rv : 23.0 ) Gecko / 20100101 Firefox / 23.0 ";
            //myWebRequest.CookieContainer = myCookie ;
            myWebRequest.Credentials = CredentialCache.DefaultCredentials;
            myWebRequest.Proxy = null;
            HttpWebResponse myHttpWebResponse = (HttpWebResponse)myWebRequest.GetResponse();
            Stream myStream = myHttpWebResponse.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myStream);
            // Leemos los datos
            string Datos = HttpUtility.HtmlDecode(myStreamReader.ReadToEnd());
            dynamic data = JsonConvert.DeserializeObject(Datos);
            return data;
        }

        public async Task<Uri> CrearUsuarioAsync(string path, UsuarioDAO usuario)
        {
            HttpClient client = new HttpClient();
            var response = await client.PostAsJsonAsync(string.Concat(url, path), usuario);
            response.EnsureSuccessStatusCode();
            // return URI of the created resource.
            return response.Headers.Location;
        }

        public async Task<HttpStatusCode> DeleteUsuarioAsync(string path, string username)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.DeleteAsync(String.Concat(url, path, username));
            return response.StatusCode;
        }

        public async Task<Uri> ActualizarUsuarioAsync(string path, string username, UsuarioDAO usuario)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PutAsJsonAsync(string.Concat(url, path, username), usuario);
            response.EnsureSuccessStatusCode();

            return response.Headers.Location;
        }

    }
}
