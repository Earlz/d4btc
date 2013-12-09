//get index

var bitcoin=require('bitcoin').bitcoin;
var bookshelf=require('bookshelf').bookshelf;

exports.index = function(req, res){
  var testnet='';
  if(bitcoin.getinfo().testnet){
    testnet='currently on bitcoin testnet!';
  }
  var title=
  res.render('index', { title: 'Express' });
};