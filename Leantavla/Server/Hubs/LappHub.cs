using Leantavla.Shared;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leantavla.Server.Hubs
{
    public class LappHub : Hub
    {
        public async Task SkickaLapp(Lapp lapp)
        {
            await Clients.All.SendAsync("HämtaLapp", lapp);
        }
    }
}
