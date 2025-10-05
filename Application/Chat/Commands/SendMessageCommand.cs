using Application.Chat.Dtos;
using MediatR;

namespace Application.Chat.Commands;

public class SendMessageCommand :IRequest<MessageDto>
{
    public MessageDto MessageDto { get; }
    
    public SendMessageCommand(MessageDto messageDto)
    {
        MessageDto = messageDto;
    }
}