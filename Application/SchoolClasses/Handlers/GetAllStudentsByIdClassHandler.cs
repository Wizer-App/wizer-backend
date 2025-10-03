using Application.DTOs;
using Application.Interfaces;
using Application.SchoolClasses.Queries;
using AutoMapper;
using MediatR;

namespace Application.SchoolClasses.Handlers;

public class GetAllStudentsByIdClassHandler : IRequestHandler<GetAllStudentsByIdClassQuery, IEnumerable<UserDto>>
{
    private readonly ISchoolClassRepository _repository;
    private readonly IMapper _mapper;

    public GetAllStudentsByIdClassHandler(ISchoolClassRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<UserDto>> Handle(GetAllStudentsByIdClassQuery request, CancellationToken cancellationToken)
    {
        var users = await _repository.GetAllStudentsByIdClassAsync(request.ClassId);
        var usersDto = _mapper.Map<IEnumerable<UserDto>>(users);
        return usersDto;
    }
}