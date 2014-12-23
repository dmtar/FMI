db.albums.aggregate([
	{$unwind: "$genres"},
	{$group: {_id:"$genres", count: {$sum: 1}, avgRating: {$avg: "$rating"}}},
	{$sort: {count: -1}},
	{$limit: 3},
	{$out: "resultCollection"}
]);

db.albums.find().forEach(function(doc) {
	var random = Math.floor((Math.random() * 100) + 1);
	db.albums.update({ _id: doc._id },{ $set: { rating:  random} } );
});

var mapFunction = function() {
	if(this.founded < 1995) {
		emit("Yuriy", this.name);
	} else if(this.founded >= 1995 && this.founded <= 2005) {
		emit("Georgi1", this.name);
	} else if(this.founded > 2005) {
		emit("Georgi2", this.name);
	} 
};

var reduceFunction = function(key, values) {
	return values.join(",");
};

db.runCommand({
	mapReduce: "artists",
	map: mapFunction,
	reduce: reduceFunction,
	out: "mapReduceCollection"
});