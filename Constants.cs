using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ABL_Uploader.Util
{
    public class Constants
    {

        public static readonly string UrlTresaId = ConfigurationManager.AppSettings["url1"];
        public static readonly string UrlCerberusCore = ConfigurationManager.AppSettings["url1"];
        public static readonly string CaminhoCertificado = ConfigurationManager.AppSettings["CaminhoCertificado"];
        public static readonly string SenhaCertificado = "";// ConfigurationManager.AppSettings["SenhaCertificado"];

    }
}
