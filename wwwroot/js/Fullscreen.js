////window.onload = function () {
////    console.log("test1");
////    setTimeout(function () {
////        console.log("test2");
////        document.body.requestFullscreen();
////    }, 5000);
////}


function Full() {
    document.getElementsByClassName("Fullscreen")[0].style.display = "None"
    document.body.requestFullscreen();
}

addEventListener('fullscreenchange', event => {
    console.log(event.path[2].fullscreen);
    if (!event.path[2].fullscreen) {
        document.getElementsByClassName("Fullscreen")[0].style.display = "block"
    }
});
