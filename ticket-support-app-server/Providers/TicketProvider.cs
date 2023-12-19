using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;
using Ticket_support_app_server.Dal;
using Ticket_support_app_server.Interface;
using Ticket_support_app_server.Models;

namespace Ticket_support_app_server.Providers
{
    public class TicketProvider : ITicketProvider
    {
        private readonly TicketsDbContext dbContext;

        public TicketProvider(TicketsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Ticket> AddTicket(Ticket addToDoRequest)
        {
            var ticket = await dbContext.Tickets.FindAsync(addToDoRequest.Id);
            
            if (ticket != null)
            {
                throw new Exception($"A user with the same id - {addToDoRequest.Id} already exists");

            }
            var newTicket = new Ticket
            {
                Id = addToDoRequest.Id,
                Description = addToDoRequest.Description,
                DueDate = addToDoRequest.DueDate,
                Title = addToDoRequest.Title,
                Priority = addToDoRequest.Priority
            };

            await dbContext.Tickets.AddAsync(newTicket);
            dbContext.SaveChanges();
            return newTicket;
        }

        public async Task<IEnumerable<Ticket>> GetAllTickets()
        {
            return await dbContext.Tickets.ToListAsync();
        }

        public async Task<Ticket> DeleteTicket(Guid id)
        {
            var ticket = await dbContext.Tickets.FindAsync(id);

            if (ticket == null)
            {
                throw new Exception($"A user with the same id - {id} does not exists");
            }

            dbContext.Remove(ticket);
            await dbContext.SaveChangesAsync();
            return ticket;
        }

        public async Task<Ticket> UpdateTicket(Guid id, Ticket updateTicket)
        {
            var ticket = await dbContext.Tickets.FindAsync(id);
            if (ticket == null)
            {
               throw new Exception($"A user with the id {id} does not exist.");

            }

            ticket.Description = updateTicket.Description;
            ticket.DueDate = updateTicket.DueDate;
            ticket.Title = updateTicket.Title;
            ticket.Priority = updateTicket.Priority;
            ticket.Completed = updateTicket.Completed;

            await dbContext.SaveChangesAsync();
            return ticket;

        }
    }
}
