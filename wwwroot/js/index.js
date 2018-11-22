// var mouseMoveMap = [];
$(document).ready(function(){
    $("#buyButton").on("click", function(e) {
        console.log(mouseMoveMap);
    });

    $(".product-props li").on("click", function(e) {
        console.log("You clicked on: ", this.innerText);
    });

    var $loginToggle = $("#loginToggle");
    var $popupForm = $(".popup-form");

    $loginToggle.on("click", function(){
        $popupForm.fadeToggle(500);
    })
});

//console.log(listItems);
// document.addEventListener("mousemove", function(e){
//     mouseMoveMap.push([e.offsetX, e.offsetY]);
// });
