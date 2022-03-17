////window.onload = function () {
////    console.log("test1");
////    setTimeout(function () {
////        console.log("test2");
////        document.body.requestFullscreen();
////    }, 5000);
////}

$(window).on("load", function () {
        document.body.requestFullscreen();
});

function Full() {
    document.body.requestFullscreen();
}