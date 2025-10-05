using Microsoft.AspNetCore.SignalR;

namespace WebAPI.Hubs;

public class WizerbHub : Hub
{
    public async Task JoinClass(int classId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, $"class-{classId}");
        
        // ✅ Enviar el userId (o ConnectionId como fallback)
        var userId = Context.UserIdentifier ?? Context.ConnectionId;
        
        await Clients.Group($"class-{classId}")
            .SendAsync("UserJoined", new { userId = userId });
        
        Console.WriteLine($"✅ Usuario {userId} se unió a clase {classId}");
    }

    public async Task LeaveClass(int classId)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, $"class-{classId}");
        
        var userId = Context.UserIdentifier ?? Context.ConnectionId;
        
        await Clients.Group($"class-{classId}")
            .SendAsync("UserLeft", new { userId = userId });
        
        Console.WriteLine($"👋 Usuario {userId} salió de clase {classId}");
    }
    
    public async Task SendClassMessage(int classId, string message)
    {
        var userId = Context.UserIdentifier ?? Context.ConnectionId;
        
        await Clients.Group($"class-{classId}")
            .SendAsync("ReceiveClassMessage", new { user = userId, message = message });
    }
}