using MentorShip.Models;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace MentorShip.Hubs
{
    public class SignalRChat:Hub
    {

       
        public async Task ClientSendMessage(string connectionId,string user, string message)
        {
            await Clients.Client(connectionId).SendAsync("ReceiveMessage",user, message);
        }
       

        public async override Task OnConnectedAsync()
        {

            await Clients.Caller.SendAsync("connected", Context.ConnectionId);
            
          
        }

    }
}
