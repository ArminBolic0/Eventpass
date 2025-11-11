using EventPass.Application.Commands.Users.Delete;
using EventPass.Application.Commands.Users.Login;
using EventPass.Application.Commands.Users.Update;
using EventPass.Application.DTOs.Users;
using EventPass.Application.DTOs.VenueDTOs;
using EventPass.Application.Queries.Users.GetAll;
using EventPass.Application.Queries.Users.GetByEmail;
using EventPass.Application.Queries.Users.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<ActionResult> Register(RegisterUserCommand command)
    {
        var userId = await _mediator.Send(command);
        if (userId == -1) return BadRequest(new { Message = "Account already exists with given email." });
        return Ok(new { Message = "User registered successfully", UserId = userId });
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login([FromBody]LoginUserCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command);
        if(result == null)
        {
            return Unauthorized(new { Message = "Invalid name or password." });
        }
        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ResponseUserDto>>> getAll(CancellationToken ct)
    {
        return await _mediator.Send(new GetAllUsersQuery(), ct);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ResponseUserDto>> getUserById(int id, CancellationToken ct)
    {
        var response = await _mediator.Send(new GetUserByIdQuery { Id = id }, ct);
        if (response == null) return NotFound();
        return Ok(response);
    }

    [HttpGet("{email}")]
    public async Task<ActionResult<ResponseUserDto>> getUserByEmail(string email, CancellationToken ct)
    {
        var response = await _mediator.Send(new GetUserByEmailQuery { email = email }, ct);
        if(response == null) return NotFound(); 
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id, CancellationToken ct)
    {
        if(!await _mediator.Send(new DeleteUserCommand { Id = id }, ct)) return NotFound();
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ResponseVenueDto>> Update(int id, UpdateUserDto userDto,  CancellationToken ct)
    {
        var response = await _mediator.Send(new UpdateUserCommand { id = id, dto = userDto }, ct);
        return Ok(response);
    }

}
