
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SolarSystem_GRP5.Websocket
{
    public class SocketHandler: IwebsocketHandler
    {
        public ConcurrentDictionary<string, WebSocket> _sockets = new ConcurrentDictionary<string, WebSocket>();

        public async Task Handle(string _culture, WebSocket webSocket)
        {

          //  Console.WriteLine(_sockets.Count);

            _sockets.TryAdd(Guid.NewGuid().ToString(), webSocket);
            

           // await SendMessageToSockets($"User with id <b>{id}</b> has joined the chat");

            while (webSocket.State == WebSocketState.Open)
            {
                string culture = _culture;
                var message = await ReceiveMessage(culture, webSocket);
                if (message != null)
                    await SendMessageToSockets(message);
            }
        }

        private async Task<string> ReceiveMessage(string culture, WebSocket webSocket)
        {
            var arraySegment = new ArraySegment<byte>(new byte[4096]);
            var receivedMessage = await webSocket.ReceiveAsync(arraySegment, CancellationToken.None);
            if (receivedMessage.MessageType == WebSocketMessageType.Text)
            {

                var message = Encoding.Default.GetString(arraySegment).TrimEnd('\0');
                if (!string.IsNullOrWhiteSpace(message))
                    return $"{culture}/{message}";
            }
            return null;
        }

        private async Task SendMessageToSockets(string message)
        {
            IEnumerable<WebSocket> toSentTo;
            toSentTo = _sockets.Values;


            var tasks = _sockets.Select(async websocketConnection =>
            {
                var bytes = Encoding.Default.GetBytes(message);
                var arraySegment = new ArraySegment<byte>(bytes);
                await websocketConnection.Value.SendAsync(arraySegment, WebSocketMessageType.Text, true, CancellationToken.None);
            });
            await Task.WhenAll(tasks);
        }
    }
}
