﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace SolarSystem_GRP5.Websocket
{
    public interface IwebsocketHandler
    {
        public async Task Handle(Guid id, WebSocket webSocket)
        {

        }
    }
}