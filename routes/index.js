//get index
require('./../config');
async=require('async');
var bitcoin=require('bitcoin').bitcoin;
var knex=require('knex').knex;

//var bookshelf=require('bookshelf').bookshelf;

exports.index = function(req, res){
  testnet: async.parallel({
    testnet: function(callback){
      bitcoin.getInfo(function(e, info){
        if(e){ return console.log(e);}
        if(info.testnet){
          callback(null, 'bitcoin RPC is testnet');
        }else{
          callback(null, 'nope.. you must be crazy');
        }
      });
    },
    name: function(callback){
      var c=knex('config').select().then(function(r){
        callback(null, r[0].site_name);
      });
    }
  },
  function(err, r){
      res.render('index', { title: r.name, testnet: r.testnet });
  });
  
};