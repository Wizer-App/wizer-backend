using Microsoft.AspNetCore.SignalR;

namespace WebAPI.Hubs;

public class WizerbHub : Hub
{
    public async Task JoinClass(int classId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, $"class-{classId}");
        await Clients.Group($"class-{classId}")
            .SendAsync("UserJoined", Context.UserIdentifier);
    }
    
    public async Task SendClassMessage(int classId, string message)
    {
        await Clients.Group($"class-{classId}")
            .SendAsync("ReceiveClassMessage", new { User = Context.UserIdentifier, Message = message });
    }
}