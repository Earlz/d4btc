//get index
require('./../config');
var bitcoin=require('bitcoin').bitcoin;
var knex=require('knex').knex;

//var bookshelf=require('bookshelf').bookshelf;

exports.index = function(req, res){
  var testnet='';
  bitcoin.getInfo(function(e, info){
    if(e){ return console.log(e);}
    if(info.testnet){
      testnet='bitcoin RPC is testnet';
    }else{
      testnet='nope.. you must be crazy';
    }
    var c=knex('config').select().then(function(k){
      res.render('index', { title: k[0].site_name, testnet: testnet });
    });
  });
  //var title=
};