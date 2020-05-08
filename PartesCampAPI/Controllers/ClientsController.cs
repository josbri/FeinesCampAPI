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
using AutoMapper;

namespace PartesCampAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class ClientsController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public ClientsController(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        // GET: api/Clients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientGetDTO>> GetClient(int id)
        {
            var clientEntity = await _clientRepository.GetByIdAsync(id);

            if (clientEntity == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ClientGetDTO>(clientEntity));
        }

        // PUT: api/Clients/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient(int id, Client client)
        {
            //if (id != client.ID)
            //{
            //    return BadRequest();
            //}

            //_context.Entry(client).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!ClientExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            return NoContent();
        }

        // POST: api/Clients
        [HttpPost]
        public async Task<ActionResult<ClientGetDTO>> PostClient(ClientPostDTO clientDTO)
        {
            var clientEntity = _mapper.Map<Client>(clientDTO);
            _clientRepository.Create(clientEntity);

            await _clientRepository.SaveChangesAsync();
            await _clientRepository.GetByIdAsync(clientEntity.ID);

            return CreatedAtAction("GetClient", new { id = clientEntity.ID }, _mapper.Map<ClientGetDTO>(clientEntity));
        }

  
    }
}
