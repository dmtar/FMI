module.exports = function(db) {
	var dbData = [
		[{
			"name": "Alvin Ramsey",
			"founded": "1981",
			"address": {
				"city": "Pidofec",
				"street": "Urasa Mill"
			},
			"phone": "(961) 259-2606",
			"yearRevenue": "$8259231.75",
			"copiesSold": 36307,
			"twitter": "@jumaro"
		}, {
			"name": "Rose Walton",
			"founded": "1989",
			"address": {
				"city": "Vaadmec",
				"street": "Losne Glen"
			},
			"phone": "(843) 467-3957",
			"yearRevenue": "$5812716.75",
			"copiesSold": 15573,
			"twitter": "@olju"
		}, {
			"name": "Amy Stanley",
			"founded": "2000",
			"address": {
				"city": "Jikbooj",
				"street": "Fentic Street"
			},
			"phone": "(369) 465-3387",
			"yearRevenue": "$7122958.06",
			"copiesSold": 68784,
			"twitter": "@zikucfin"
		}, {
			"name": "Olivia Terry",
			"founded": "2001",
			"address": {
				"city": "Wepbugmom",
				"street": "Okvo Pike"
			},
			"phone": "(438) 562-4551",
			"yearRevenue": "$6875601.51",
			"copiesSold": 55603,
			"twitter": "@wiuda"
		}, {
			"name": "Lottie Wise",
			"founded": "1987",
			"address": {
				"city": "Fanruaz",
				"street": "Akav Loop"
			},
			"phone": "(380) 803-4293",
			"yearRevenue": "$5405927.86",
			"copiesSold": 79614,
			"twitter": "@fu"
		}, {
			"name": "Vernon Jenkins",
			"founded": "2010",
			"address": {
				"city": "Gerfaigo",
				"street": "Kewabi Junction"
			},
			"phone": "(931) 479-3197",
			"yearRevenue": "$5953951.71",
			"copiesSold": 15916,
			"twitter": "@ib"
		}, {
			"name": "Jennie Rodriquez",
			"founded": "2011",
			"address": {
				"city": "Sadapeepi",
				"street": "Hamu Heights"
			},
			"phone": "(978) 924-8791",
			"yearRevenue": "$3089498.96",
			"copiesSold": 99046,
			"twitter": "@cucuw"
		}, {
			"name": "Violet Soto",
			"founded": "2011",
			"address": {
				"city": "Bulnacbub",
				"street": "Uvep Loop"
			},
			"phone": "(962) 808-6935",
			"yearRevenue": "$7238691.65",
			"copiesSold": 72398,
			"twitter": "@osuiz"
		}, {
			"name": "Matthew Anderson",
			"founded": "1990",
			"address": {
				"city": "Ilewevjun",
				"street": "Hoec Point"
			},
			"phone": "(410) 371-6093",
			"yearRevenue": "$8268588.95",
			"copiesSold": 53045,
			"twitter": "@asoogeto"
		}, {
			"name": "Annie McKinney",
			"founded": "1995",
			"address": {
				"city": "Naudje",
				"street": "Vuwdal Parkway"
			},
			"phone": "(575) 296-2250",
			"yearRevenue": "$8844696.02",
			"copiesSold": 65469,
			"twitter": "@is"
		}],
		[{
			"name": "Tyler Glover",
			"artist": "Vernon Jenkins",
			"released": "2014",
			"genres": [
				"Death Metal",
				"Humour"
			],
			"description": "So ga mumu ejna lumek ela wejeffem hipta sivezme saduw fe edadifpes ib derzu zi cefzukag."
		}, {
			"name": "Nina Wade",
			"artist": "Amy Stanley",
			"released": "2008",
			"genres": [
				"Swing",
				"Duet",
				"Chamber Music",
				"Bass",
				"Folk"
			],
			"description": "Te huabfow pirolot giguki zi ukepe lojeiza la medat godanu ceic bugi mana suwatiri kavkecvad sigav."
		}, {
			"name": "Marion Gonzales",
			"artist": "Amy Stanley",
			"released": "2007",
			"genres": [
				"Bluegrass",
				"Porn Groove",
				"Acid"
			],
			"description": "Fupmunmut agifemhic lekot tohnuc asopotfim ebucat ufegore ro road fonvewbu ivko bosifmi ziuzi."
		}, {
			"name": "Isabelle Hodges",
			"artist": "Olivia Terry",
			"released": "2009",
			"genres": [
				"Jazz+Funk",
				"Big Band",
				"Instrumental Pop",
				"Ska",
				"Death Metal"
			],
			"description": "Uwa ticeg rul itnumos tazcij lohic ice nigevu pesu op be kamzu izozakun cakmer ewwedewi."
		}, {
			"name": "Mildred Townsend",
			"artist": "Matthew Anderson",
			"released": "2008",
			"genres": [
				"Industrial",
				"Comedy",
				"House",
				"Other",
				"Dance Hall"
			],
			"description": "Malowpaz donpemwe ki etatag aco bihdat wikleh sah vowiif iri se bel obelo."
		}, {
			"name": "Dale Moody",
			"artist": "Amy Stanley",
			"released": "2011",
			"genres": [
				"Slow Jam",
				"Primus",
				"Ska"
			],
			"description": "Uf saura eme kuap ivgadi wembup ba sioz gakafjel lohag jor olimi leenu."
		}, {
			"name": "Lydia Klein",
			"artist": "Jennie Rodriquez",
			"released": "2014",
			"genres": [
				"Comedy",
				"Meditative",
				"Vocal"
			],
			"description": "Sivte pac bumoddu co dehham vihetu noru ere uwo lohvockum ru ece tiftaf."
		}, {
			"name": "Charles Perez",
			"artist": "Vernon Jenkins",
			"released": "2014",
			"genres": [
				"Trance",
				"Death Metal",
				"Sound Clip",
				"Jazz+Funk"
			],
			"description": "Rifil debem anauku edur sauv mujuwtu enuze pewhawa ubo if zem pedew zo fomatko."
		}, {
			"name": "Addie Gibbs",
			"artist": "Annie McKinney",
			"released": "1998",
			"genres": [
				"Punk",
				"Booty Bass"
			],
			"description": "Kojiz pu tabefba hupre ve volhoref ragse cedkuuc udaur ne pijetlof ce vu kirurtu botjihid isemi cumnogbuh."
		}, {
			"name": "Pearl Patterson",
			"artist": "Amy Stanley",
			"released": "2008",
			"genres": [
				"Acid",
				"Tango",
				"Duet"
			],
			"description": "Vo maepe hawveaz ivimiv nawisatoz fomomwe silekhu zinir oj tuhcu ikhogze oj."
		}, {
			"name": "Harvey Mullins",
			"artist": "Annie McKinney",
			"released": "2008",
			"genres": [
				"Pop-Folk",
				"Sound Clip",
				"Psychedelic Rock",
				"Symphony"
			],
			"description": "Tiwati mejlehez zadcedte niwme bad nezna jekor rinif laabauna vopofew hacwin af luapoc fojapbaw sib kef pomse cosande."
		}, {
			"name": "Jessie Nunez",
			"artist": "Alvin Ramsey",
			"released": "1995",
			"genres": [
				"Tribal",
				"Bebob",
				"Dance"
			],
			"description": "Hivire jiesili ocuuppaz fupajkil ni ob we fuhrehiva hohkuz kukaus ubo aci hesu de."
		}, {
			"name": "Edward Curry",
			"artist": "Matthew Anderson",
			"released": "2006",
			"genres": [
				"Rock & Roll",
				"Dance",
				"Instrumental Pop",
				"Porn Groove"
			],
			"description": "Uvobe va pu fence soz ijeata vincolo mis di boifib ew hir culo taugadi apisiptop siuf eco."
		}, {
			"name": "Jeffery Ford",
			"artist": "Olivia Terry",
			"released": "2008",
			"genres": [
				"Gothic",
				"AlternRock"
			],
			"description": "Us ipamo bih enruvin kala uz sap puuw zabe id wus laj."
		}, {
			"name": "Emilie Mills",
			"artist": "Vernon Jenkins",
			"released": "2013",
			"genres": [
				"Celtic",
				"Oldies",
				"Ambient",
				"Dance"
			],
			"description": "Afsalud guvo sanifa or gi igu ciwbip baepluj ivu agseho paw dev."
		}, {
			"name": "Gilbert Gonzalez",
			"artist": "Alvin Ramsey",
			"released": "1989",
			"genres": [
				"Folk",
				"Acoustic",
				"Acapella",
				"Dance",
				"Celtic"
			],
			"description": "Azamutif toizri optijjo zimsuvag irziuci dihow iwitfo uhbe lisug hinvum egulivsa ohegeosu."
		}, {
			"name": "Lulu Atkins",
			"artist": "Jennie Rodriquez",
			"released": "2013",
			"genres": [
				"Gothic Rock",
				"Bass",
				"Ambient"
			],
			"description": "Nudot afi rudjibhi ogtomo silarlo umaawa nois was aruci bopzirnap so obawek."
		}, {
			"name": "Emilie Lee",
			"artist": "Alvin Ramsey",
			"released": "2001",
			"genres": [
				"Porn Groove",
				"Native American",
				"Dance",
				"Rhythmic Soul"
			],
			"description": "Nufinu derbul wul hejofo upuseli pebaf be gecuhu uli ak weksabo guhbe."
		}, {
			"name": "Linnie Lopez",
			"artist": "Annie McKinney",
			"released": "2007",
			"genres": [
				"Acid Jazz",
				"Cabaret"
			],
			"description": "Ve vawepu tundij oziwud tezavmil tidzevnut gikgovup jaf ja dit enmif nahu va ko evfoifu rigniob."
		}, {
			"name": "Florence Guzman",
			"artist": "Olivia Terry",
			"released": "2007",
			"genres": [
				"Musical",
				"Alternative",
				"Rhythmic Soul",
				"Club",
				"Metal"
			],
			"description": "Leogenu ikama lop ibesociv ese poldu hantofkip fip famidu rib kutmadnef kug eljik ali."
		}, {
			"name": "Kathryn Dennis",
			"artist": "Lottie Wise",
			"released": "2011",
			"genres": [
				"Trance",
				"Chamber Music",
				"Primus",
				"Southern Rock"
			],
			"description": "Giec uhe lu govseg co rehujim pucupfid bovlu taluazu rocgob feih vum kurtacaz talmikde."
		}, {
			"name": "Dean emilie Salazar",
			"artist": "Vernon Jenkins",
			"released": "2012",
			"genres": [
				"Porn Groove",
				"Bass",
				"Sound Clip"
			],
			"description": "Desfa mi huf ji ramed gap canka mapkuziz ga muhag kawzip ki ijjaob kijki."
		}, {
			"name": "William Mason",
			"artist": "Jennie Rodriquez",
			"released": "2014",
			"genres": [
				"Pop",
				"Celtic",
				"Folk",
				"Duet",
				"Metal"
			],
			"description": "Fi cupzoz wipazdu sikle gafor ufivaca gushogo poniop uvo si hu zojhod walej ok hebrak ipiturli bi gifbop."
		}, {
			"name": "Alex Chavez",
			"artist": "Jennie Rodriquez",
			"released": "2013",
			"genres": [
				"Punk",
				"Instrumental Pop",
				"Funk"
			],
			"description": "Ipwos mewotik alieperec erauv leftibmir gohuf ihoopovo kolozso ba po parpus wus olawo."
		}, {
			"name": "Kate Nelson",
			"artist": "Violet Soto",
			"released": "2013",
			"genres": [
				"Slow Jam",
				"Ballad",
				"Grunge",
				"Rhythmic Soul",
				"Drum Solo"
			],
			"description": "Odo numwo wi athiega pul foc te la cimozud wonsir fu pukitha rij sige si ena kig."
		}, {
			"name": "John Steele",
			"artist": "Annie McKinney",
			"released": "2014",
			"genres": [
				"Duet",
				"Bass"
			],
			"description": "Mow suipdoh gig tu iwohav bumtac pomeeme cuvsehwi riral donlojkep ako ju caztupas po bu age."
		}, {
			"name": "Myrtie Houston",
			"artist": "Violet Soto",
			"released": "2013",
			"genres": [
				"Other",
				"Chorus",
				"Euro-Techno",
				"Slow Rock",
				"Trance"
			],
			"description": "Cebiv ikje cutpak jisac jofow gibku wupov afmatuf wovan zoh sus fihemi cize."
		}, {
			"name": "Lora Mills",
			"artist": "Violet Soto",
			"released": "2014",
			"genres": [
				"Humour",
				"Pop-Folk",
				"Eurodance",
				"Rap",
				"Fast Fusion"
			],
			"description": "Dugum fobzit amutir gijjucfil rauhe zipagu ideted fe rerzecuz zet jaad cagcuepu gumanam bitiwo etu or ku bijjote."
		}, {
			"name": "Julia Vargas",
			"artist": "Rose Walton",
			"released": "1999",
			"genres": [
				"Chanson",
				"Chorus",
				"Rock & Roll",
				"Acid"
			],
			"description": "Zomhervoz mos zur re tezopfu sal kudevdic gu fak zino vekeheru wah lumhe."
		}, {
			"name": "Gussie Morgan",
			"artist": "Amy Stanley",
			"released": "2006",
			"genres": [
				"Folk",
				"Punk",
				"Sound Clip",
				"Power Ballad"
			],
			"description": "Ne efuwojupo pal cecgo kah aglasar dawe nuducaz koswe avhutlac gud jivwe ber muvi fi buken."
		}]
	];

	var artistsCollection = db.collection('artists');
	var albumsCollection = db.collection('albums');

	var artists = dbData[0];
	var albums = dbData[1];

	artists.forEach(function(artistInfo) {
		artistsCollection.insert(artistInfo, function(err, doc) {
			if (err) {
				console.error(err);
			}
		});
	});

	albums.forEach(function(albumInfo) {
		albumsCollection.insert(albumInfo, function(err, doc) {
			if (err) {
				console.error(err);
			}
		});
	});

	setTimeout(function(){
		return true;
	},2000);
};