/* GET home page. */
var mongoose = require('mongoose');
var models = require('../models')(mongoose);

exports.index = function(req, res){
  var artist = new models.Artist({'name':'Artist'});
  res.render('index', { title: artist.name });
};
