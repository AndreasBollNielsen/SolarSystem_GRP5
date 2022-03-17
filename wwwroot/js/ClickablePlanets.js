
var socket;
var scheme = document.location.protocol === "https:" ? "wss" : "ws";
var port = document.location.port ? (":" + document.location.port) : "";
var ip = "192.168.1.141";
var local = document.location.hostname;
var connectionUrl = scheme + "://" + ip + port + "/ws";

window.onload = function () {

    //establish connection via websockt
    socket = new WebSocket(connectionUrl);

    //test connectivity
    socket.onopen = function (event) {

        console.log("connection established...");

    };

    //recieve echo message
    socket.onmessage = function (event) {
        console.log(event.data);
    };


};

function SendData(data) {

    var id = data;
    console.log("clicked " + id);
    socket.send(id);

}


$('div[name="planet"]').click(function () {

    SendData(this.id);

});

$('button[name="planet"]').click(function () {

    SendData(this.id);

});

$("#quiz").click(function ()
{
    window.location.href = "./Quiz";

});


//$('div[name="planet"]').click(function () {

//    var id = this.id;
//    console.log("clicked " + id);
//    socket.send(id);

//    //$.ajax({
//    //    type: "POST",
//    //    url: "./test",
//    //    data: { id: id},
//    //    dataType: "text"

//    //});
//});





