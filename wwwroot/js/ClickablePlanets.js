﻿
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
        console.log("connection established...");
    };


};



$('div[name="planet"]').click(function () {

    var id = this.id;
   
    socket.send(id);

    //$.ajax({
    //    type: "POST",
    //    url: "./test",
    //    data: { id: id},
    //    dataType: "text"
       
    //});
});



