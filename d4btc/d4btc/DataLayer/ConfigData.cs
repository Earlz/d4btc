using System;
using Dapper;
using System.Linq;
using Earlz.Bitcoind;

namespace Earlz.d4btc
{
    public class ConfigData
    {
        public class Config
        {
            public int Id{get;set;}
            public string RpcUser{get;set;}
            public string RpcPassword{get;set;}
            public string RpcUrl{get;set;}
            public int Confirmations{get;set;}
            public int RedownloadWindow{get;set;}
            public string SiteName{get;set;}
            public bool Testnet{ get; set;}
        }
        static Config config;
        public static Config Get()
        {
            //assume this doesn't change for now
            if (config == null)
            {
                using (var c=DataLayer.Connection())
                {
                    config=c.Query<Config>("select * from config").Single();
                    config.Testnet = (bool)DataLayer.Bitcoind.Invoke("getinfo")["result"]["testnet"];
                }
            }
            return config;
        }
    }
}

