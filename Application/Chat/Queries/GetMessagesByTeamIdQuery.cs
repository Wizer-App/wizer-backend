using Application.Chat.Dtos;
using MediatR;

namespace Application.Chat.Queries;

public class GetMessagesByTeamIdQuery : IRequest<IEnumerable<MessageDto>>
{
    public int TeamId { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }

    public GetMessagesByTeamIdQuery(int teamId, int page, int pageSize)
    {
        TeamId = teamId;
        Page = page;
        PageSize = pageSize;
    }
}