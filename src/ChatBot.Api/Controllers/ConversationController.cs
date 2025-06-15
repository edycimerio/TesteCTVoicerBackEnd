using ChatBot.Application.Commands.EndConversation;
using ChatBot.Application.Commands.StartConversation;
using ChatBot.Application.Queries.GetActiveConversations;
using ChatBot.Application.Queries.GetConversation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatBot.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConversationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ConversationController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> StartConversation()
        {
            var command = new StartConversationCommand();
            var conversationId = await _mediator.Send(command);
            
            return Ok(conversationId);
        }

        [HttpGet]
        public async Task<ActionResult<List<ConversationSummaryDto>>> GetActiveConversations()
        {
            var query = new GetActiveConversationsQuery();
            var conversations = await _mediator.Send(query);
            
            return Ok(conversations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ConversationDto>> GetConversation(Guid id)
        {
            var query = new GetConversationQuery { ConversationId = id };
            var conversation = await _mediator.Send(query);
            
            if (conversation == null)
            {
                return NotFound();
            }
            
            return Ok(conversation);
        }

        [HttpPost("{id}/end")]
        public async Task<ActionResult> EndConversation(Guid id)
        {
            var command = new EndConversationCommand { ConversationId = id };
            var result = await _mediator.Send(command);
            
            if (!result)
            {
                return BadRequest("Não foi possível encerrar a conversa.");
            }
            
            return NoContent();
        }
    }
}
