using System;
using Npgsql;
using Earlz.Bitcoind;
using System.Net;

namespace Earlz.d4btc
{
    public static class DataLayer
    {
        const string ConnectionString = "Server=127.0.0.1;Database=d4btc;User=earlz"; //meh change later to load from web.config
        public static NpgsqlConnection Connection()
        {
            var c = new NpgsqlConnection(ConnectionString);
            c.Open();
            return c;
        }
        static IBitcoind bitcoind;
        static public IBitcoind Bitcoind
        {
            get
            {
                if (bitcoind == null)
                {
                    var cred = new NetworkCredential(ConfigData.Get().RpcUser, ConfigData.Get().RpcPassword);
                    bitcoind = new Btcd(ConfigData.Get().RpcUrl, cred);
                }
                return bitcoind;
            }
        }
    }
}

