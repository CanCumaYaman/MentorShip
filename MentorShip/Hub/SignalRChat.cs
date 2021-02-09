using MentorShip.Models;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace MentorShip.Hubs
{
    public class SignalRChat:Hub
    {
        
        Context c = new Context();
        public async Task setUserEmail(string email)
        {
            string id = Context.ConnectionId;
            c.EmailConnectionIds.Where(a => a.connection_id == id).FirstOrDefault().email = email;
        }
        
        public async Task ClientSendMessage(string connectionId,string user, string message)
        {
           var deger= c.EmailConnectionIds.Where(a => a.connection_id ==
            connectionId).FirstOrDefault();
            

            await Clients.Client(deger.connection_id).SendAsync("ReceiveMessage",user, message);
        }


        public override async Task OnConnectedAsync()
        {

            EmailConnectionId val = new EmailConnectionId();
            val.connection_id = Context.ConnectionId; ;
            val.email = "";
           
            c.EmailConnectionIds.Add(val);
            c.SaveChanges();

           await  base.OnConnectedAsync();


        }
        public override Task OnDisconnectedAsync(Exception exception)
        {
            var connection = c.EmailConnectionIds.Where(a => a.connection_id ==
            Context.ConnectionId).FirstOrDefault();

            if (connection != null)
            {
                c.EmailConnectionIds.Remove(connection);
            }

            return base.OnDisconnectedAsync(exception);
        }

    }
}
