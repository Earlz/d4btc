//get index
require('./../config');
var bitcoin=require('bitcoin').bitcoin;

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
    res.render('index', { title: 'Express', testnet: testnet });
  });
  //var title=
};