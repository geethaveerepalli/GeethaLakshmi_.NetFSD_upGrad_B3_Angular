using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication12.Models;
using WebApplication12.Repository;

namespace WebApplication12.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _repo;
        public ContactsController(IContactRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _repo.GetAllAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var contact = await _repo.GetByIdAsync(id);
            if (contact == null)
            {
                return NotFound("Contact Not Found");

            }
            else
            {
                return Ok(contact);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ContactInfo contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var created = await _repo.AddAsync(contact);
                return CreatedAtAction(nameof(GetById), new { id = created.ContactId }, created);

            }

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ContactInfo contact)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _repo.UpdateAsync(id, contact);
            if (!result)
                return NotFound("Contact not found");

            return Ok("Updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _repo.DeleteAsync(id);
            if (!result)
                return NotFound("Contact not found");

            return Ok("Deleted successfully");
        }
    }
}
