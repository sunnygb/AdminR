var foo;
console.log("hello world");
var aray = [];
Array[1] = "je";
console.log(Array[1]);
aray=["hello",1,222.33,6,7];
console.log(aray.length);
var string="hello world thats a wonderful name";
console.log(string.toUpperCase());
console.log(string.split(" "));
var object = document.getElementsByTagName("a");
//document.onclick = function () {
  //  alert("you have clicked");
//}
var obj= document.getElementsByClassName("logo");
obj.onclick = function () {
    alert("you have clicked image");
}
