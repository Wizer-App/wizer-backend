using Application.Chat.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Chat.Mapping;

public class ChatProfile : Profile
{
    public ChatProfile()
    {
        CreateMap<Message, MessageDto>();
        CreateMap<MessageDto, Message>();
    }
}