using System;
using Newtonsoft.Json.Linq;
using System.Net;
using Newtonsoft.Json;
using System.Text;
using System.IO;

namespace Earlz.Bitcoind
{
    public class Bitcoind : IBitcoind
    {
        public Bitcoind (string url, ICredentials credentials)
        {
            Url = url;
            Credentials = credentials;
        }
        ICredentials Credentials;
        string Url;
        public JObject Invoke (string method, params object[] _params)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(Url);
            webRequest.Credentials = Credentials;

            webRequest.ContentType = "application/json-rpc";
            webRequest.Method = "POST";

            JObject jo = new JObject ();
            jo ["jsonrpc"] = "1.0";
            jo ["id"] = "bitcoind";
            jo ["method"] = method;

            if (_params != null) {
                if (_params.Length > 0) {
                    JArray props = new JArray ();
                    foreach (var p in _params) {
                        props.Add (p);
                    }
                    jo.Add (new JProperty ("params", props));
                }
            }

            string s = JsonConvert.SerializeObject (jo);
            // serialize json for the request
            byte[] byteArray = Encoding.UTF8.GetBytes (s);
            webRequest.ContentLength = byteArray.Length;

            using (Stream dataStream = webRequest.GetRequestStream()) {
                dataStream.Write (byteArray, 0, byteArray.Length);
            }

            using (WebResponse webResponse = webRequest.GetResponse()) {
                using (Stream str = webResponse.GetResponseStream()) {
                    using (StreamReader sr = new StreamReader(str)) {
                        return JsonConvert.DeserializeObject<JObject> (sr.ReadToEnd ());
                    }
                }
            }
        }

    }
}

