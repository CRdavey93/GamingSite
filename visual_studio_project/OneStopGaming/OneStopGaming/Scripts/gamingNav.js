//Cody Davey and James Grams
//Javascript for the One Stop Gaming navigation
	
function toggleMenu() {
	if(document.getElementsByClassName("nav")[0].style.display != "block") {
		document.getElementsByClassName("nav")[0].style.display = "block";
	}
	else {
		document.getElementsByClassName("nav")[0].style.display = "none";
	}
}
	
function watchMediaQuery(mq) {
	if (mq.matches) {
		document.getElementsByClassName("nav")[0].style.display = "block";
	}
	else {
		document.getElementsByClassName("nav")[0].style.display = "none";
	}
}
	
var mq = window.matchMedia("screen and (min-width: 721px)");
mq.addListener(watchMediaQuery);

$(document).ready(function () {
    document.getElementsByClassName("menu")[0].onclick = function() {toggleMenu()};
} );
