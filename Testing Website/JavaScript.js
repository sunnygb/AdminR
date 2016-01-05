alert("hello world");
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

function WinLoad(){
    alert("Alert on window load");
}
window.onload = function () {
    WinLoad();
}
//document.onclick=function(){
  //  alert("You click Anything");
//q}

var obj= document.getElementById("logo");
    obj.onclick = function () {
        alert("you have clicked image");
    }
    var emailField = document.getElementById("inputTxt");
    emailField.onfocus = function () {
        if (emailField.value = "Your Email")
            emailField.value = "";
    };
    emailField.onblur = function () {
        if (emailField.value = "")
            emailField.value = "Your Email";

    };