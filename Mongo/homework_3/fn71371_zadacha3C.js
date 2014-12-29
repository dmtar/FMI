var musiciansDb = db.getSiblingDB('musicians');
/*
Add rating property to every album
 */
musiciansDb.albums.find().forEach(function(doc) {
	var random = Math.floor((Math.random() * 100) + 1);
	db.albums.update({ _id: doc._id },{ $set: { rating:  random} } );
});

/*
Subtask 1 
За всеки жанр на албум да се намери броят албуми в които се среща, средният
им рейтинг и списък на имената им. Да се запишат в друга колекция трите
най­често използвани жанра. Записването на резултатите трябва да става като
част от заявката ­ не на отделна стъпка.
 */
musiciansDb.albums.aggregate([
	{$unwind: "$genres"},
	{$group: {_id:"$genres", count: {$sum: 1}, avgRating: {$avg: "$rating"}}},
	{$sort: {count: -1}},
	{$limit: 3},
	{$out: "resultCollection"}
]);

/*
Subtask 2
Да се върнат имената на изпълнителите, като се групират по това кой е
по­вероятно да ги слуша според годината им на създаване. Т.е. да се върнат
изпълнителите които е по­вероятно да бъдат слушани от “Yuriy” (преди 1968 (1995)),
“Georgi1” (между 1969(1995) и 1987(2005)) или “Georgi2” (от 1988(2005) нататък). 
 */
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

musiciansDb.runCommand({
	mapReduce: "artists",
	map: mapFunction,
	reduce: reduceFunction,
	out: "mapReduceCollection"
});