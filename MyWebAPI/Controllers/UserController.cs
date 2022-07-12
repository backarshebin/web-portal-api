using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using my_services;
using portal_domain;

namespace MyWebAPI.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this._mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string? search = "", [FromQuery] bool searchAll = false, [FromQuery] int offset = 0, [FromQuery] int limit = 50)
        {
            if (string.IsNullOrEmpty(search))
            {
                search = string.Empty;
            }
            var response = await userService.GeUsersAsync(search, searchAll, offset, limit);
            List<UserDTO> userlist = _mapper.Map<List<UserDTO>>(response.Data);
            return Ok(new
            {
                Data = userlist,
                Total = response.Total,
                Limit = response.Limit,
                Offset = response.Offset


            });
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromForm] UserDTO request)
        {
            if (string.IsNullOrEmpty(request.FirstName))
            {
                return BadRequest("Name is required");
            }
            var user = _mapper.Map<User>(request);
            user = await userService.UpdateUserAsync(id, user);
            var userDTO = _mapper.Map<UserDTO>(user);
            return Ok(userDTO);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromForm] UserDTO request)
        {
            if (string.IsNullOrEmpty(request.FirstName))
            {
                return BadRequest("Name is required");
            }
            var user = _mapper.Map<User>(request);
            user = await userService.CreeateUserAsync(user);
            var userDTO = _mapper.Map<UserDTO>(user);
            return Ok(userDTO);
        }
    }
}

