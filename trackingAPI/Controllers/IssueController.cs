//using System.Data.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using trackingAPI.Data;
using trackingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace trackingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueController : ControllerBase
    {
        private readonly IssueDbContext _context;
        public IssueController(IssueDbContext context) => _context = context;
        //turn on docker before testing
        
        [HttpGet]
        public async Task<IEnumerable<Issue>> Get()
            =>await _context.Issues.ToListAsync();
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var Issue = await _context.Issues.FindAsync(id);
            return Issue == null ? NotFound() : Ok(Issue);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Issue issue)
        {
            await _context.Issues.AddAsync(issue);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new {id=issue.id}, issue);
        }
        
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        public async Task<IActionResult> Update(int id, Issue issue)
        {
            if (id != issue.id) return BadRequest();
            _context.Entry(issue).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(new {name="aa"});
        }
        
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            var issuetoDelete = await _context.Issues.FindAsync(id);
            if (issuetoDelete == null) return BadRequest();
            
             _context.Issues.Remove(issuetoDelete);
             await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}