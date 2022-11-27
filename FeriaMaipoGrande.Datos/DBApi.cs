using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows;
using Hanssens.Net;
using System.Runtime.Remoting.Messaging;

namespace FeriaMaipoGrande.Datos
{
    public class DBApi
    {
        private dynamic user;
        public dynamic storage = new LocalStorage();
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
            catch (Exception ex)
            {
                return ex;
            }
        }



       public async Task<HttpStatusCode> DeletePersonaAsync(string path, string numIdentificador)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.DeleteAsync(String.Concat(url, path, numIdentificador));
            if (response.StatusCode == HttpStatusCode.OK)
            {
                response.EnsureSuccessStatusCode();
                return HttpStatusCode.Accepted;
            }
            else
            {
                return HttpStatusCode.Conflict;
            }
        }
        
        public async Task<Uri> CrearPersonaAsync(string path, PersonaDAO persona)
        {
            HttpClient client = new HttpClient();
            var response = await client.PostAsJsonAsync(string.Concat(url, path), persona);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                response.EnsureSuccessStatusCode();
                return response.Headers.Location;
            }
            else
            {
                return response.Headers.Location;
            }
        }

        public async Task<Uri> ActualizarPersonaAsync(string path, string numIdentificador, PersonaDAO persona)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PutAsJsonAsync(string.Concat(url, path, numIdentificador), persona);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                response.EnsureSuccessStatusCode();
                return response.Headers.Location;
            }
            else
            {
                return response.Headers.Location;
            }
        }

        /* 
         * 
         * 
         * METODOS PARA EL MANTENEDOR DE USUARIOS 
         * 
         * 
         */

        public dynamic GetUsuarios()
        {
            HttpWebRequest myWebRequest = (HttpWebRequest)WebRequest.Create(string.Concat(url, "usuarios/"));
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
            catch (Exception ex)
            {
                return ex;
            }
        }

        public dynamic GetUsuario(string path)
        {
            HttpWebRequest myWebRequest = (HttpWebRequest)WebRequest.Create(string.Concat(url, "usuarios/", path));
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
            catch (Exception ex)
            {
                return ex;
            }
        }

        public dynamic GetRoles()
        {
            HttpWebRequest myWebRequest = (HttpWebRequest)WebRequest.Create(string.Concat(url, "usuarios/rol/rol_usuarios"));
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
            catch (Exception ex)
            {
                return ex;
            }
        }

        public async Task<Uri> CrearUsuarioAsync(string path, UsuarioDAO usuario)
        {
            HttpClient client = new HttpClient();
            var response = await client.PostAsJsonAsync(string.Concat(url, path), usuario);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                response.EnsureSuccessStatusCode();
                return response.Headers.Location;
            }
            else
            {
                return response.Headers.Location;
            }
        }

        public async Task<HttpStatusCode> DeleteUsuarioAsync(string path, string username)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.DeleteAsync(String.Concat(url, path, username));
            if (response.StatusCode == HttpStatusCode.OK)
            {
                response.EnsureSuccessStatusCode();
                return HttpStatusCode.Accepted;
            }
            else
            {
                return HttpStatusCode.Conflict;
            }
        }

        public async Task<Uri> ActualizarUsuarioAsync(string path, string username, UsuarioDAO usuario)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PutAsJsonAsync(string.Concat(url, path, username), usuario);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                response.EnsureSuccessStatusCode();
                return response.Headers.Location;
            }
            else
            {
                return response.Headers.Location;
            }
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
            if (response.StatusCode == HttpStatusCode.OK)
            {
                response.EnsureSuccessStatusCode();
                return response.Headers.Location;
            }
            else
            {
                return response.Headers.Location;
            }
        }

        public async Task<HttpStatusCode> DeleteVentaAsync(string path, string id_venta)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.DeleteAsync(String.Concat(url, path, id_venta));
            if (response.StatusCode == HttpStatusCode.OK)
            {
                response.EnsureSuccessStatusCode();
                return HttpStatusCode.Accepted;
            }
            else
            {
                return HttpStatusCode.Conflict;
            }
        }

        public async Task<Uri> ActualizarVentaAsync(string path, string id_venta, VentaDAO venta)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PutAsJsonAsync(string.Concat(url, path, id_venta), venta);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                response.EnsureSuccessStatusCode();
                return response.Headers.Location;
            }
            else
            {
                return response.Headers.Location;
            }
        }

        public dynamic GetVentas()
        {
            HttpWebRequest myWebRequest = (HttpWebRequest)WebRequest.Create(string.Concat(url, "ventas"));
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
            catch (Exception ex)
            {
                return ex;
            }
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
            if (response.StatusCode == HttpStatusCode.OK)
            {
                response.EnsureSuccessStatusCode();
                return response.Headers.Location;
            }
            else
            {
                return response.Headers.Location;
            }
        }

        public async Task<Uri> ActualizarSubastaAsync(string path, string id_subasta, SubastaDAO subasta)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PutAsJsonAsync(string.Concat(url, path, int.Parse(id_subasta)), subasta);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                response.EnsureSuccessStatusCode();
                return response.Headers.Location;
            }
            else
            {
                return response.Headers.Location;
            }
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

        /* 
         * 
         * 
         * METODOS PARA EL MANTENEDOR DE CONTRATOS
         * 
         * 
         */

        public async Task<Uri> CrearContratoAsync(string path, ContratoDAO contratos)
        {
            HttpClient client = new HttpClient();
            var response = await client.PostAsJsonAsync(string.Concat(url, path), contratos);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                response.EnsureSuccessStatusCode();
                return response.Headers.Location;
            }
            else
            {
                return response.Headers.Location;
            }
        }

        public async Task<Uri> ActualizarContratoAsync(string path, string id_contratos, ContratoDAO contratos)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PutAsJsonAsync(string.Concat(url, path, int.Parse(id_contratos)), contratos);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                response.EnsureSuccessStatusCode();
                return response.Headers.Location;
            }
            else
            {
                return response.Headers.Location;
            }
        }

        public dynamic GetContratos()
        {
            HttpWebRequest myWebRequest = (HttpWebRequest)WebRequest.Create(string.Concat(url, "contratos"));
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
            catch (Exception ex)
            {
                return ex;
            }

        }

        /* 
         * 
         * 
         * METODOS PARA EL INICIO DE SESION
         * 
         * 
         */


        public async Task<string> IniciarSesionAsync(LoginDAO login)
        {

            HttpClient client = new HttpClient();
            var response = await client.PostAsJsonAsync(String.Concat(url, "auth/login"), login);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                response.EnsureSuccessStatusCode();
                dynamic respuesta = await response.Content.ReadAsStringAsync();
                LogUserDAO loginUser = new LogUserDAO();
                loginUser.User = respuesta;
                return respuesta;
            }
            else
            {
                return response.Headers.ToString();
            }
        }

    }

}