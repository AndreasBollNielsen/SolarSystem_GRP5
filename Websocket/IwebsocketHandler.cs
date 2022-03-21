using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace SolarSystem_GRP5.Websocket
{
    public interface IwebsocketHandler
    {
        //interface for websocket handler
        public async Task Handle(string culture, WebSocket webSocket)
        {

        }
    }
}
