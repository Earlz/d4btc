//get index
require('./../config');
var Promise = require("bluebird");

var bitcoin=require('bitcoin').bitcoin;
var knex=require('knex').knex;
Promise.promisifyAll(require('bitcoin').Client.prototype);
//var bookshelf=require('bookshelf').bookshelf;

exports.index = function(req, res){
  var info = bitcoin.getInfoAsync();
  var config = knex('config').select();
  Promise.all([info, config]).spread(function(info, config) {
      res.render('index', {
          title: config[0].site_name,
          testnet: info.testnet ? 'bitcoin RPC is testnet' : 'nope.. you must be crazy'
      });
    }).catch(function(e){
      console.log(e);
    });
};
