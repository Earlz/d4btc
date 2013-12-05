using System;
using Npgsql;

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
    }
}

