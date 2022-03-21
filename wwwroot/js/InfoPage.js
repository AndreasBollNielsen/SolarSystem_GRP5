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

        //setup form
        form = document.createElement('form');
        document.body.appendChild(form);
        var input = document.createElement('input');
        input.type = 'text';
        input.name = "id";
        input.value = event.data;

        form.appendChild(input);

        //post form data
        form.method = 'post';
        form.action = "./PlanetInfo";
        form.submit();

    };


};