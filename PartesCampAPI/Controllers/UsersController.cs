using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PartesCampAPI.Extensions;
using PartesCampAPI.Models;
using PartesCampAPI.Services;

namespace PartesCampAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        [HttpGet("jwt/{id}")]
        public async Task<ActionResult<UserGetDTO>> GetByJwtId(string id)
        {
            var userEntity = await _userService.FindByJwtId(id);

            if (userEntity == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<UserGetDTO>(userEntity));
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<UserGetDTO>> PostUser(UserPostDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var userEntity = _mapper.Map<User>(userDTO);

            var result = await _userService.CreateAsync(userEntity);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }


            var userGetDTO = _mapper.Map<UserGetDTO>(result.User);

            return Ok(userGetDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserGetDTO>> DeleteClient(int id)
        {
            var result = await _userService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var userGetDTO = _mapper.Map<UserGetDTO>(result.User);

            return Ok(userGetDTO);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<ActionResult<UserGetDTO>> PutClient(int id, UserPostDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var user = _mapper.Map<User>(userDTO);
            var result = await _userService.UpdateAsync(id, user);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }


            return Ok(_mapper.Map<ClientGetDTO>(result.User));
        }
    }



}