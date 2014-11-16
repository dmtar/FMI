/* GET home page. */
var express = require('express'),
	async = require('async'),
	ObjectID = require('mongodb').ObjectID,
	router = express.Router();

var albumsUpdate = function(albums, callback) {
	albums.update({
		artist: "Amy Stanley"
	}, {
		$set: {
			favorite: true
		},
		$addToSet: {
			genres: "Pop-Additional"
		}
	}, {
		multi: true
	}, function(err, count, status) {
		if (err) {
			callback(null, count);
		} else {
			callback(err, count);
		}
	});
};

var aggregateQuery = function(artists, callback) {
	artists.aggregate([{
		$project: {
			name: 1,
			founded: 1,
			insensitive: {
				$toLower: "$name"
			}
		}
	}, {
		$match: {
			founded: {
				$gte: "2001",
				$lte: "2011"
			}
		}
	}, {
		$sort: {
			insensitive: -1
		}
	}], function(err, result) {
		if (err) {
			callback(err, result);
		} else {
			callback(null, result);
		}
	});
};

var albumsCount = function(albums, callback) {
	albums.count({
		genres: {
			$in: ["Dance"]
		},
		artist: "Alvin Ramsey"
	}, function(err, count) {
		if (err) {
			callback(err, count);
		} else {
			callback(null, count);
		}
	});
};

var albumsRemove = function(albums, callback) {
	albums.remove({
		name: /.*emilie.*/i
	}, function(err, result) {
		if (err) {
			callback(err, result);
		} else {
			callback(null, result);
		}
	});
};

module.exports = function(database) {
	var albums = database.collection('albums');
	var artists = database.collection('artists');

	router.get('/', function(req, res) {
		async.series({
			albumsUpdate: albumsUpdate.bind(null, albums),
			albumsCount: albumsCount.bind(null, albums),
			aggregateQuery: aggregateQuery.bind(null, artists),
			albumsRemove: albumsRemove.bind(null, albums)
		}, function(err, results) {
			if (err) {
				res.status(500).send();
			} else {
				res.render('index', {
					albumsUpdate: results.albumsUpdate,
					albumsCount: results.albumsCount,
					aggregateQuery: results.aggregateQuery,
					albumsRemove: results.albumsRemove,
				});
			}
		});
	});

	return router;
};