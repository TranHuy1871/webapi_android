using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.Commands.UserCommands;
using WebAPI.Application.Queries.UserQueries;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserCommand command)
        {
            var user = await _mediator.Send(command);
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserCommand command)
        {
            var user = await _mediator.Send(command);
            if (user == null)
                return BadRequest("Login fail!");
            
            return Ok(user);
        }

        [HttpGet("list_user")]
        public async Task<IActionResult> GetListUser()
        {
            var query = new GetUsersQuery();
            var listUser = await _mediator.Send(query);
            return Ok(listUser);
        }
    }
}
