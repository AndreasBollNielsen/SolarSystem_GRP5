
var socket;
var scheme = document.location.protocol === "https:" ? "wss" : "ws";
var port = document.location.port ? (":" + document.location.port) : "";
var ip = "192.168.1.141";
var local = document.location.hostname;
var connectionUrl = scheme + "://" + local + port + "/ws";

window.onload = function () {

    //create connection on page startup
    SetupConnection();
};

function SendData(data) {

    var id = data;
    socket.send(id);
    
}

//click event from divs
$('div[name="planet"]').click(function () {

    SendData(this.id);

});

//click event from buttons
$('button[name="planet"]').click(function () {

    SendData(this.id);

});

//click event to quiz page
$("#quiz").click(function ()
{
    window.location.href = "./Quiz";

});

//setup websocket connection
function SetupConnection() {

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

    //reconnect if socket closes
    socket.onclose = function () {
        console.log("reconnecting...");
        setTimeout(SetupConnection, 500);
    }
}







