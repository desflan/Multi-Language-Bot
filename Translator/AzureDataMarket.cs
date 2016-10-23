using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using HotelBot.Utilities;

namespace HotelBot.Translator
{
    public class AzureDataMarket
    {
        private readonly string _request;
        private readonly string _tokenUri;

        internal AzureDataMarket()
        {
            _tokenUri = Settings.GetTokenUri();
            _request =
               $"grant_type=client_credentials&client_id={HttpUtility.UrlEncode(Settings.GetTranslatorClientId())}&client_secret={HttpUtility.UrlEncode(Settings.GetTranslatorClientSecret())} &scope=http://api.microsofttranslator.com";
            
        }

        public async Task<AdmAccessToken> GetAccessToken()
        {
            WebRequest webRequest = WebRequest.Create(_tokenUri);
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.Method = "POST";
            byte[] bytes = Encoding.ASCII.GetBytes(_request);
            webRequest.ContentLength = bytes.Length;
            try
            {
                using (Stream outputStream = webRequest.GetRequestStream())
                {
                    outputStream.Write(bytes, 0, bytes.Length);
                }

                using (WebResponse webResponse = await webRequest.GetResponseAsync())
                {
                    DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(AdmAccessToken));
                    AdmAccessToken _token = await Task.Run(() => (AdmAccessToken)serializer.ReadObject(webResponse.GetResponseStream()));

                    return _token;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}