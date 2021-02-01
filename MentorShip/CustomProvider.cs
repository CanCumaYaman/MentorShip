using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorShip
{
    public class CustomProvider : IUserIdProvider
    {
        public string GetUserId(HubConnectionContext connection)
        {
            throw new NotImplementedException();
        }
    }
}
