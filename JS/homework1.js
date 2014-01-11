Function.prototype.times = function (n) {
	var that=this;
	return function (x) {
		var i;
		if (x<=1)
		{
			return that(x);
		}
		for (i=0;i<n;i++){
			x=that(x);
		}
		return x;
	}
}
Array.prototype.unique = function () {
	var uniqueArray= new Array();
	var i;
	for  (i=0; i<this.length; i++) {
		if(uniqueArray.indexOf(this[i])==-1){
			uniqueArray.push(this[i]);
		}
	}
	return uniqueArray;
}
Array.prototype.intersect = function (inputArray) {
	var uniqueArray=this.unique();
	var intersect= new Array();
	var i;
	for (i=0;i<uniqueArray.length;i++){
		if(inputArray.indexOf(uniqueArray[i])>=0){
			intersect.push(uniqueArray[i]);
		}
	}
	return intersect;
}
var some_numbers = [1, 2, 3, 4, 5];
var some_other_numbers = [5, 4, 7,7,7,7,7,7,10, 12, 2, 1];
console.log(some_other_numbers.unique())
console.log(some_other_numbers)
console.log(some_numbers.intersect(some_other_numbers));
console.log(some_numbers);
console.log(some_other_numbers);