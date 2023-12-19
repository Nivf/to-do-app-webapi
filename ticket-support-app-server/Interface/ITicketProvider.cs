using Microsoft.AspNetCore.Mvc;
using Ticket_support_app_server.Models;

namespace Ticket_support_app_server.Interface
{
    public interface ITicketProvider :IServiceProvider
    {
        Task<IEnumerable<Ticket>> GetAllTickets();
        Task<Ticket> AddTicket(Ticket ticket);
        Task<Ticket> UpdateTicket(Guid id, Ticket ticket);
        Task<Ticket> DeleteTicket(Guid id);
    }
}
