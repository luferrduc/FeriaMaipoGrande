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
using System.Windows;

namespace FeriaMaipoGrande.Datos
{
    public class DBApi
    {
        string url2 = "https://api-feria-web-production.up.railway.app/api/";
        string url = "http://localhost:3001/api/";
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
        /* 
         * 
         * 
         * METODOS PARA EL MANTENEDOR DE USUARIOS 
         * 
         * 
         */

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



        /*
         * 
         * 
         METODOS PARA EL MANTENEDOR DE VENTAS 
         *
         *
        */

        public async Task<Uri> CrearVentaAsync(string path, VentaDAO venta)
        {
            HttpClient client = new HttpClient();
            var response = await client.PostAsJsonAsync(string.Concat(url, path), venta);
            response.EnsureSuccessStatusCode();
            // return URI of the created resource.
            return response.Headers.Location;
        }

        public async Task<HttpStatusCode> DeleteVentaAsync(string path, string id_venta)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.DeleteAsync(String.Concat(url, path, id_venta));
            return response.StatusCode;
        }

        public async Task<Uri> ActualizarVentaAsync(string path, string id_venta, VentaDAO venta)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PutAsJsonAsync(string.Concat(url, path, id_venta), venta);
            response.EnsureSuccessStatusCode();

            return response.Headers.Location;
        }

        public dynamic GetVentas()
        {
            HttpWebRequest myWebRequest = (HttpWebRequest)WebRequest.Create(string.Concat(url, "ventas"));
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

        /* 
         * 
         * 
         * METODOS PARA EL MANTENEDOR DE SUBASTAS 
         * 
         * 
         */

        public async Task<Uri> CrearSubastaAsync(string path, SubastaDAO subasta)
        {
            HttpClient client = new HttpClient();
            var response = await client.PostAsJsonAsync(string.Concat(url, path), subasta);
            response.EnsureSuccessStatusCode();
            // return URI of the created resource.
            return response.Headers.Location;
        }

        public async Task<Uri> ActualizarSubastaAsync(string path, string id_subasta, SubastaDAO subasta)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PutAsJsonAsync(string.Concat(url, path, int.Parse(id_subasta)), subasta);
            response.EnsureSuccessStatusCode();

            return response.Headers.Location;
        }

        public dynamic GetSubastas()
        {
            HttpWebRequest myWebRequest = (HttpWebRequest)WebRequest.Create(string.Concat(url, "subastas"));
            myWebRequest.UserAgent = " Mozilla / 5.0 ( Windows NT 6.1 ; WOW64 ; rv : 23.0 ) Gecko / 20100101 Firefox / 23.0 ";
            //myWebRequest.CookieContainer = myCookie ;
            myWebRequest.Credentials = CredentialCache.DefaultCredentials;
            myWebRequest.Proxy = null;
            try
            {
                HttpWebResponse myHttpWebResponse = (HttpWebResponse)myWebRequest.GetResponse();
                Stream myStream = myHttpWebResponse.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myStream);
                // Leemos los datos
                string Datos = HttpUtility.HtmlDecode(myStreamReader.ReadToEnd());
                dynamic data = JsonConvert.DeserializeObject(Datos);
                return data;
            }
            catch(Exception ex)
            {
                return ex;
            }
            
        }

    }
}