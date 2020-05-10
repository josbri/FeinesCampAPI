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
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly IMapper _mapper;

        public TasksController(ITaskService taskService, IMapper mapper)
        {
            _taskService = taskService ?? throw new ArgumentNullException(nameof(taskService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        // GET: api/Clients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TareaGetDTO>> GetTarea(int id)
        {
            var taskEntity = await _taskService.FindByIdAsync(id);

            if (taskEntity == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ClientGetDTO>(taskEntity));
        }

        // PUT: api/Clients/5
        [HttpPut("{id}")]
        public async Task<ActionResult<TareaGetDTO>> PutTarea(int id, TareaPostDTO tareaDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var tarea = _mapper.Map<Tarea>(tareaDTO);
            var result = await _taskService.UpdateAsync(id, tarea);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }


            return Ok(_mapper.Map<TareaGetDTO>(result.Task));
        }

        // POST: api/Clients
        [HttpPost]
        public async Task<ActionResult<TareaGetDTO>> PostTask(TareaPostDTO taskDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var taskEntity = _mapper.Map<Tarea>(taskDTO);

            var result = await _taskService.CreateAsync(taskEntity);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var taskGetDTO = _mapper.Map<TareaGetDTO>(result.Task);

            return Ok(taskGetDTO);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<TareaGetDTO>> DeleteTask(int id)
        {
            var result = await _taskService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var taskGetDTO = _mapper.Map<TareaGetDTO>(result.Task);

            return Ok(taskGetDTO);
        }

    }
}