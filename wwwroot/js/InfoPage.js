var socket;
var scheme = document.location.protocol === "https:" ? "wss" : "ws";
var port = document.location.port ? (":" + document.location.port) : "";
var ip = "192.168.1.141";
var local = document.location.hostname;
var connectionUrl = scheme + "://" + local + port + "/ws";

window.onload = function () {

    //establish connection via websockt
    socket = new WebSocket(connectionUrl);
    console.log(connectionUrl);
    //test connectivity
    socket.onopen = function (event) {

        
        console.log("connection established...");
    };

     //recieve echo message
    socket.onmessage = function (event) {
        console.log(event.data);

        $.ajax({
            type: "POST",
            url: "./PlanetInfo",
            data: { id: event.data },
            dataType: "text"

        });
    };


};