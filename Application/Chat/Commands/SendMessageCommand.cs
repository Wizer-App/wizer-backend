using Application.Chat.Dtos;
using MediatR;

namespace Application.Chat.Commands;

public class SendMessageCommand :IRequest<MessageDto>
{
    public SendMessageRequestDto Message { get; }
    
    public SendMessageCommand(SendMessageRequestDto messageDto)
    {
        Message = messageDto;
    }
}