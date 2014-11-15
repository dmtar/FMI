module.exports = function(mongoose, dbData) {
    var Schema = mongoose.Schema;

    var Artist = new Schema({
        name: {
            type: String,
            index: true
        },
        founded: Date,
        address: {
            city: String,
            street: String
        },
        phone: String,
        yearRevenue: String,
        copiesSold: Number,
        twitter: String

    });

    var Album = new Schema({
        name: {
            type: String,
            index: true
        },
        artist: String,
        released: String,
        genres: [String],
        description: String
    });

    var models = {
        Artist: mongoose.model('Artist', Artist),
        Album: mongoose.model('Album', Album)
    };

    var artists = dbData[0];
    var albums = dbData[1];

    models.Artist.remove().exec().then(function(doc) {
        artists.forEach(function(artistInfo) {
            var artist = new models.Artist(artistInfo);
            artist.save(function(err) {
                if (err) {
                    console.log("Artist cannot be saved, Error: " + err);
                }
            });
        });
    });
    models.Album.remove().exec().then(function(doc) {
        albums.forEach(function(albumInfo) {
            models.Album.create(albumInfo,
                function(err, album) {
                    if (err) {
                        console.log("Album: " + album.name + " cannot be saved, Error: " + err);
                    }
                });
        });
    });

    return models;
}