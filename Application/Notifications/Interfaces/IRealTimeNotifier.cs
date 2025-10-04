namespace Application.Notifications.Interfaces;

public interface IRealTimeNotifier
{
    Task NotifyClassAsync(int classId, string method, object payload);
    Task NotifyTeamAsync(int teamId, string method, object payload);
}