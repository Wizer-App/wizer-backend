using Application.Chat.Commands;
using Application.Chat.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/chat")]
public class ChatController : ControllerBase
{
    private readonly IMediator _mediator;

    public ChatController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("send")]
    public async Task<IActionResult> SendMessage([FromBody] SendMessageRequestDto messageDto)
    {
        var result = await _mediator.Send(new SendMessageCommand(messageDto));
        return Ok(result);
    }
}