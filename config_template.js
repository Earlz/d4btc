//for migrations
module.exports = {
  directory: './migrations',

  database: {
    client: 'pg',
    connection: {
      host     : '127.0.0.1',
      user     : 'your_database_user',
      password : 'your_database_password',
      database : 'myapp_test',
      charset  : 'utf8'
    }
  }
};

//bitcoind connection info
var Bitcoin=require('bitcoin');
Bitcoin.bitcoin = new Bitcoin.Client({ //is this safe?
  host: 'localhost',
  port: 8332,
  user: 'user',
  pass: 'pass'
});

//database connection info
var Bookshelf=require('bookshelf');
Bookshelf.bookshelf = Bookshelf.initialize({
  client: 'pg',
  connection: {
    host     : '127.0.0.1',
    user     : 'your_database_user',
    password : 'your_database_password',
    database : 'myapp_test',
    charset  : 'utf8'
  }
});