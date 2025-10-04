using Application.DTOs;
using Application.Interfaces;
using Application.Notifications.Interfaces;
using Application.SchoolClasses.Commands;
using AutoMapper;
using MediatR;

namespace Application.SchoolClasses.Handlers;

public class JoinSchoolClassHandler : IRequestHandler<JoinSchoolClassCommand, SchoolClassDto>
{
    private readonly ISchoolClassRepository _repository;
    private readonly IMapper _mapper;
    private readonly IRealTimeNotifier _notifier;

    public JoinSchoolClassHandler(ISchoolClassRepository repository, IMapper mapper,  IRealTimeNotifier notifier)
    {
        _repository = repository;
        _mapper = mapper;
        _notifier = notifier;
    }
    
    public async Task<SchoolClassDto> Handle(JoinSchoolClassCommand request, CancellationToken cancellationToken)
    {
        var schoolClass = await _repository.JoinSchoolClassAsync(request.JoinCode, request.UserId);
        
        if (schoolClass == null)
        {
            throw new KeyNotFoundException($"Clase con ID {request.JoinCode} no encontrada");
        }
        var schoolClassDto = _mapper.Map<SchoolClassDto>(schoolClass);
        await _notifier.NotifyClassAsync(schoolClass.Id, "UserJoined", new { UserId = request.UserId });

        return schoolClassDto;
    }
}