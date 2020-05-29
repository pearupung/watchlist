using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace WebApp.Hubs
{
    public class InstructorListHub : Hub
    {
        public async Task SendNewInstructor(string instructorName)
        {
            await Clients.All.SendAsync("NewInstructor", instructorName);
        }
    }
}