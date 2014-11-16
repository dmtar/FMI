var express = require('express');
var path = require('path');
var bodyParser = require('body-parser');
var MongoClient = require('mongodb').MongoClient;
var populateDatabase = require('./old_db_data');

var app = express();

MongoClient.connect('mongodb://localhost/musicians', function(err, db) {
    if (err) {
        console.error('Cannot connect to the database', err);
        return;
    }
    populateDatabase(db);
    init(app, db);
});

var init = function(app, db) {
    var index = require('./routes/index');
    app.use(bodyParser.json());
    app.set('view engine', 'jade');
    app.use(express.static(path.join(__dirname, 'public')));

    app.use('/', index(db));

    // catch 404 and forward to error handler
    app.use(function(req, res, next) {
        var err = new Error('Not Found');
        err.status = 404;
        next(err);
    });

    // error handlers

    // development error handler
    // will print stacktrace
    app.use(function(err, req, res, next) {
        res.status(err.status || 500);
        res.render('error', {
            message: err.message,
            error: err
        });
    });
};

module.exports = app;
