
//bitcoind connection info
var Bitcoin=require('bitcoin');
Bitcoin.bitcoin = new Bitcoin.Client({ //is this safe?
  host: 'localhost',
  port: 8332,
  user: 'user',
  pass: 'pass'
});

//database connection info
var Knex=require('knex');
Knex.knex = Knex.initialize({
  client: 'pg',
  connection: {
    host     : '127.0.0.1',
    user     : 'your_database_user',
    password : 'your_database_password',
    database : 'myapp_test',
    charset  : 'utf8'
  }
});