using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using retrospect.Models;

namespace retrospect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly FeedbackContext _context;

        public FeedbackController(FeedbackContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Feedback>>> GetFeedbackItem()
        {
            return await _context.FeedbackItem.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Feedback>> GetFeedback(string id)
        {
            var feedback = await _context.FeedbackItem.FindAsync(id);

            if (feedback == null)
            {
                return NotFound();
            }

            return feedback;
        }

        [HttpPost]
        public async Task<ActionResult<Feedback>> PostFeedback(Feedback feedback)
        {
            _context.FeedbackItem.Add(feedback);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFeedbackItem), new { id = feedback.Id }, feedback);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeedback(string id)
        {
            var feedback = await _context.FeedbackItem.FindAsync(id);
            if (feedback == null)
                return NotFound();

            _context.FeedbackItem.Remove(feedback);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
