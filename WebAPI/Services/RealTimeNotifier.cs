using Application.Notifications.Interfaces;
using Microsoft.AspNetCore.SignalR;
using WebAPI.Hubs;

namespace WebAPI.Services;

public class RealTimeNotifier : IRealTimeNotifier
{
    private readonly IHubContext<WizerbHub> _hub;

    public RealTimeNotifier(IHubContext<WizerbHub> hub)
    {
        _hub = hub;
    }

    
    public Task NotifyClassAsync(int classId, string method, object payload)
        => _hub.Clients.Group($"class-{classId}").SendAsync(method, payload);
    

    public Task NotifyTeamAsync(int teamId, string method, object payload)
        => _hub.Clients.Group($"team-{teamId}").SendAsync(method, payload);
    
}