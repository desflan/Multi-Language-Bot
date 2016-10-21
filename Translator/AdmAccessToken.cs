using System;

namespace HotelBot.Translator
{
    [System.Runtime.Serialization.DataContract]
    public class AdmAccessToken
    {
        [System.Runtime.Serialization.DataMember]
        public string access_token { get; set; }
        [System.Runtime.Serialization.DataMember]
        public string token_type { get; set; }
        private int _expires_in;
        [System.Runtime.Serialization.DataMember]
        public int expires_in
        {
            get { return _expires_in; }
            set
            {
                _expires_in = value;
                _expirationDate = DateTime.Now.AddSeconds(value);
            }
        }
        private DateTime _expirationDate = DateTime.MinValue;
        public bool IsExpired { get { return _expirationDate < DateTime.Now; } }
        [System.Runtime.Serialization.DataMember]
        public string scope { get; set; }
        
        public string Header => $"Bearer {access_token}";
    }
}