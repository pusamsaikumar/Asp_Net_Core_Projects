using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Webblog.Data;
using Webblog.Models;

namespace Webblog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueController : ControllerBase
    {
        private readonly IssueDbContext _dbContext;

        public IssueController(IssueDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        // get issues
        [HttpGet]
        public async Task<IEnumerable<Issue>> GetIssues()
        {
            return await _dbContext.Issues.ToListAsync();
        }

        // getbyid
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Issue), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById( int id)
        {
            var issue = await _dbContext.Issues.FindAsync(id);
            return  issue == null ? NotFound() : Ok(issue);
        }

        // created 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Issue issue)
        {
            await _dbContext.Issues.AddAsync(issue);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById),new {id = issue.Id} , issue);
        }

        //UPDATE  
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, Issue issue)
        {
            if (id != issue.Id) return BadRequest();
            _dbContext.Entry(issue).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        // deleted issues
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var del = await _dbContext.Issues.FindAsync(id);
            if (del == null) return NotFound(); 
            _dbContext.Issues.Remove(del);
            await _dbContext.SaveChangesAsync();
            return NoContent(); 
        }
    }
}
