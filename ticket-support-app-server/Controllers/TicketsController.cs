using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;
using Ticket_support_app_server.Dal;
using Ticket_support_app_server.Interface;
using Ticket_support_app_server.Models;


namespace Ticket_support_app_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketProvider ticketProvider;


        public TicketsController(ITicketProvider ticketProvider)
        {
            this.ticketProvider = ticketProvider;

        }

        [HttpGet]
        public async Task<IEnumerable<Ticket>> GetAllTodos()
        {
            return await ticketProvider.GetAllTickets();
        }

        [HttpPost]
        public async Task<IActionResult> AddTodo(Ticket addToDoRequest)
        {
            try
            {
                var newTicket = await ticketProvider.AddTicket(addToDoRequest);
                return Ok(newTicket);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, null, 404);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpadteTodo(Guid id, [FromBody] Ticket updateToDoRequest)
        {

            try
            {
                var updatedTicket = await ticketProvider.UpdateTicket(id,updateToDoRequest);
                return Ok(updatedTicket);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var deletedTicket = await ticketProvider.DeleteTicket(id);
                return Ok(deletedTicket);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
