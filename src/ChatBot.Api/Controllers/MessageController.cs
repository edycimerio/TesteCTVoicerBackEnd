using ChatBot.Application.Commands.SendMessage;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ChatBot.Api.Controllers
{
    // Controller responsável pelo envio de mensagens no chatbot
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MessageController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        public async Task<ActionResult<string>> SendMessage([FromBody] SendMessageCommand command)
        {
            if (command == null || command.ConversationId == Guid.Empty || string.IsNullOrWhiteSpace(command.Message))
            {
                return BadRequest("Dados da mensagem inválidos.");
            }
            
            try
            {
                var response = await _mediator.Send(command);
                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao processar a mensagem.");
            }
        }
    }
}
