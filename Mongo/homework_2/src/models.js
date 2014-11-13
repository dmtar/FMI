module.exports = function(mongoose) {
    var Schema = mongoose.Schema;

    var Artist = new Schema({
        name: {
            type: String,
            index: true
        },
        founded: String,
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
    return models;
}