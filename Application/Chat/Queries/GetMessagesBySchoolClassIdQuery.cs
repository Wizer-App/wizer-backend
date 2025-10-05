using Application.Chat.Dtos;
using MediatR;

namespace Application.Chat.Queries;

public class GetMessagesBySchoolClassIdQuery : IRequest<IEnumerable<MessageDto>>
{
    public int SchoolClassId { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }

    public GetMessagesBySchoolClassIdQuery(int schoolClassId, int page, int pageSize)
    {
        SchoolClassId = schoolClassId;
        Page = page;
        PageSize = pageSize;
    }
}