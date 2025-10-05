using Application.Chat.Commands;
using Application.Chat.Dtos;
using Application.Chat.Interfaces;
using Application.Notifications.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Chat.Handlers;

public class SendMessageHandler: IRequestHandler<SendMessageCommand, MessageDto>
{
    public readonly IChatRepository _Repository;
    public readonly IMapper _Mapper;
    public readonly IRealTimeNotifier _Notifier;

    public SendMessageHandler(IChatRepository repository, IMapper mapper, IRealTimeNotifier notifier)
    {
        _Repository = repository;
        _Mapper = mapper;
        _Notifier = notifier;
    }
    
    public async Task<MessageDto> Handle(SendMessageCommand request, CancellationToken cancellationToken)
    {
        var messageEntity = new Message
        {
            Content = request.Message.Content,
            SentAt = DateTime.UtcNow,
            SenderId = request.Message.SenderId,
            SchoolClassId = request.Message.SchoolClassId.Value,
            TeamId = request.Message.TeamId
        };

        var saveMessage = await _Repository.SendMessageAsync(messageEntity);
        var messageDto = _Mapper.Map<MessageDto>(saveMessage);

        if (messageDto.SchoolClass != null && messageDto.Team == null)
        {
            await _Notifier.NotifyClassAsync(
                messageDto.SchoolClass.Id,
                "ReceiveClassMessage",
                messageDto
            );
        }
        else if (messageDto.Team != null)
        {
            await _Notifier.NotifyTeamAsync(
                messageDto.Team.Id,
                "ReceiveTeamMessage",
                messageDto
            );
        }

        return messageDto;
    }
}