using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PartesCampAPI.Models;
using PartesCampAPI.data;
using Microsoft.AspNetCore.Authorization;
using PartesCampAPI.Repository;
using PartesCampAPI.Extensions;
using AutoMapper;
using PartesCampAPI.Services;

namespace PartesCampAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;

        public ClientsController(IClientService clientService, IMapper mapper)
        {
            _clientService = clientService ?? throw new ArgumentNullException(nameof(clientService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        [HttpGet("user/{id}")]
        public async Task<ActionResult<IEnumerable<ClientGetDTO>>> GetByUserId(int id)
        {
            var clientEntity = await _clientService.FindByUserIdAsync(id);

            if (clientEntity == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ClientGetDTO>(clientEntity));
        }
        // GET: api/Clients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientGetDTO>> GetClient(int id)
        {
            var clientEntity = await _clientService.FindByIdAsync(id);

            if (clientEntity == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ClientGetDTO>(clientEntity));
        }

        // PUT: api/Clients/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ClientGetDTO>> PutClient(int id, ClientPostDTO clientDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var client = _mapper.Map<Client>(clientDTO);
            var result = await _clientService.UpdateAsync(id, client);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }


            return Ok(_mapper.Map<ClientGetDTO>(result.Client));
        }

        // POST: api/Clients
        [HttpPost]
        public async Task<ActionResult<ClientGetDTO>> PostClient(ClientPostDTO clientDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var clientEntity = _mapper.Map<Client>(clientDTO);

            var result = await _clientService.CreateAsync(clientEntity);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }


            return CreatedAtAction("GetClient", new { id = result.Client.ID }, _mapper.Map<ClientGetDTO>(result.Client));
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<ClientGetDTO>> DeleteClient(int id)
        {
            var result = await _clientService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var clientGetDTO = _mapper.Map<ClientGetDTO>(result.Client);

            return Ok(clientGetDTO);
        }
  
    }
}
