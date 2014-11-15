/* GET home page. */
var mongoose = require('mongoose');
var dbData = require('../old_db_data')();

exports.index = function(req, res) {
	//Create the models and populate the database
	var models = require('../models')(mongoose, dbData);

	res.render('index', {
		title: "Test"
	});
};