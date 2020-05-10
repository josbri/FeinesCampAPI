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
    public class LandsController : ControllerBase
    {
        private readonly ILandService _landService;
        private readonly IMapper _mapper;

        public LandsController(ILandService landService, IMapper mapper)
        {
            _landService = landService ?? throw new ArgumentNullException(nameof(landService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        // PUT: api/Land/5
        [HttpPut("{id}")]
        public async Task<ActionResult<LandGetDTO>> PutClient(int id, LandPostDTO landDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var land = _mapper.Map<Land>(landDTO);
            var result = await _landService.UpdateAsync(id, land);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }


            return Ok(_mapper.Map<LandGetDTO>(result.Land));
        }

        // POST: api/Clients
        [HttpPost]
        public async Task<ActionResult<LandGetDTO>> PostClient(LandPostDTO landDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var landEntity = _mapper.Map<Land>(landDTO);

            var result = await _landService.CreateAsync(landEntity);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var landGetDTO = _mapper.Map<LandGetDTO>(result.Land);

            return Ok(landGetDTO);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<ClientGetDTO>> DeleteClient(int id)
        {
            var result = await _landService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var landGetDTO = _mapper.Map<LandGetDTO>(result.Land);

            return Ok(landGetDTO);
        }


    }
}