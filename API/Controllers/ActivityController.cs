using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Domain;

namespace API.Controllers
{
    public class ActivityController:BaseApiController
    {
        public ActivityController(DataContext context){
            _context=context;
        }
        private readonly DataContext _context;
        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities(){
              return  await _context.Activites.ToListAsync();
        }
       [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivity(Guid id){
              return  await _context.Activites.FindAsync(id);
        }
    }
}