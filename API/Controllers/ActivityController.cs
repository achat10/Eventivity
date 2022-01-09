using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Domain;
using MediatR;
using Application.Activities;

namespace API.Controllers
{
    public class ActivityController : BaseApiController
    {

        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities() {
            return await Mediator.Send(new List.Query());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivity(Guid id) {
            return await Mediator.Send(new Details.Query { Id = id });
        }
        [HttpPost]
        public async Task<IActionResult> CreateActivity([FromBody] Activity Activity)
        {
            return Ok(await Mediator.Send(new Create.Command { activity = Activity }));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditActivity([FromRoute] Guid id,[FromBody] Activity Activity)
        {
            Activity.Id = id;
            return Ok(await Mediator.Send(new Edit.Command { activity = Activity }));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity([FromRoute] Guid id)
        {
            return Ok(await Mediator.Send(new Delete.Command { Id = id }));
        }
    }
}