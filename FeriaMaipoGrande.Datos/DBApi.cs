using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FeriaMaipoGrande.Datos
{
    public class DBApi
    {
       public dynamic Get()
        {
            HttpWebRequest myWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:3001/api/persona");
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

       public async Task<HttpStatusCode> DeletePersonaAsync(string numIdentificador)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.DeleteAsync(String.Concat("http://localhost:3001/api/persona/", numIdentificador));
            return response.StatusCode;
        }
        /*
        public async Task<Uri> CreateUserAsync(string url, Usuario usuario)
        {
            HttpClient client = new HttpClient();
            var response = await client.PostAsJsonAsync(url, usuario);
            response.EnsureSuccessStatusCode();
            // return URI of the created resource.
            return response.Headers.Location;
        }*/
    }
}
