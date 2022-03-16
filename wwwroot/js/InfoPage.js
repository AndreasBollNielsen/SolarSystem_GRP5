var socket;
var scheme = document.location.protocol === "https:" ? "wss" : "ws";
var port = document.location.port ? (":" + document.location.port) : "";
var connectionUrl = scheme + "://" + document.location.hostname + port + "/ws";

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

        $.ajax({
            type: "POST",
            url: "./PlanetInfo",
            data: { id: event.data },
            dataType: "text"

        });
    };


};