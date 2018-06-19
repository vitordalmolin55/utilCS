using System;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace ABL_Uploader.Util
{
    class RestService
    {

        private string UrlTresaId = Constants.UrlTresaId;
        private string UrlCerberusCore = Constants.UrlCerberusCore;

        private string DefineServer(string route)
        {
            string[] routes = route.Split("/".ToCharArray());
            string urlBase = "", url ="";
            switch (routes[0])
            {
                case "link1":
                    routes[0] = "";
                    url = UrlTresaId + string.Join("/", routes);
                    break;
                case "link2":
                    routes[0] = "";
                    url = UrlCerberusCore + string.Join("/", routes);
                    break;
                default:
                    url = route;
                    break;
            }
            Console.Write(url);
            return url;
        }

        internal string DoService(string url, string requisition, string method, bool sendCert = false)
        {

            string mUrl = DefineServer(url);
            string reply = "";


            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(mUrl);

            if (sendCert) {
                X509Certificate2 cert = new X509Certificate2(@Constants.CaminhoCertificado, Constants.SenhaCertificado, X509KeyStorageFlags.MachineKeySet);
                request.ClientCertificates.Add(cert);
            }
            request.Method = method;
            request.ContentType = @"application/json; charset=utf-8";
            request.ServerCertificateValidationCallback += (s, certificate, chain, sslPolicyErrors) => true;

            if (!requisition.Equals(""))
            {
                using (Stream stm = request.GetRequestStream())
                {
                    using (StreamWriter stmw = new StreamWriter(stm))
                    {
                        stmw.Write(requisition);
                        stmw.Close();
                    }
                }
            }

            try
            {
                StreamReader responseReader = new StreamReader(request.GetResponse().GetResponseStream());
                reply = responseReader.ReadToEnd();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return reply;
        }

        //Metodo de serialização

        public JavaScriptSerializer GetSerializer()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = js.MaxJsonLength * 100;
            return js;
        }

    }
}
