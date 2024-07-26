using Microsoft.AspNetCore.SignalR;

namespace SignalR_App_API.HubConfig
{
    public class MyHub : Hub
    {
        public async Task AskServer(string someTextFromClient)
        {
            string tempString;

            if(someTextFromClient == "hey")
            {
                tempString = "message was 'hey'";
            }
            else
            {
                tempString = "messagge was something else";
            }

            await Clients.Clients(this.Context.ConnectionId).SendAsync("AskServerResponse", tempString);
        }
    }
}
