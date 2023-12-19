using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ticket_support_app_server.Controllers;
using Ticket_support_app_server.Dal;
using Ticket_support_app_server.Models;
using Ticket_support_app_server.Providers;
using Xunit;

public class TicketsControllerTests
{
    [Fact]
    public async Task GetAllTodos_ReturnsListOfTickets()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<TicketsDbContext>()
            .UseInMemoryDatabase(databaseName: "TicketDatabase")
            .Options;

        using var dbContext = new TicketsDbContext(options);
        var ticketProvider = new TicketProvider(dbContext);

        var controller = new TicketsController(ticketProvider);

        var tickets = new List<Ticket>
    {
        new Ticket { Id = Guid.NewGuid(), Title = "Ticket 1", Description = "Description 1", DueDate = DateTime.Now, Priority = 1 },
        new Ticket { Id = Guid.NewGuid(), Title = "Ticket 2", Description = "Description 2", DueDate = DateTime.Now, Priority = 2 }
        // Add more sample tickets as needed
    };

        dbContext.Tickets.AddRange(tickets);
        dbContext.SaveChanges();

        // Act
        var result = await controller.GetAllTodos();

        // Assert
        var returnedTickets = Assert.IsType<List<Ticket>>(result);
        Assert.Equal(tickets.Count, returnedTickets.Count);
    }

    [Fact]
    public async Task AddTodo_WhenTicketDoesNotExist_ReturnsOkResult()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<TicketsDbContext>()
            .UseInMemoryDatabase(databaseName: "TicketDatabase")
            .Options;

        using var dbContext = new TicketsDbContext(options);
        var ticketProvider = new TicketProvider(dbContext);

        var controller = new TicketsController(ticketProvider);

        var newTicket = new Ticket
        {
            Id = Guid.NewGuid(),
            Description = "Test Description",
            DueDate = DateTime.Now,
            Title = "Test Title",
            Priority = 1
        };

        // Act
        var result = await controller.AddTodo(newTicket);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var addedTicket = Assert.IsType<Ticket>(okResult.Value);
        Assert.Equal(newTicket.Id, addedTicket.Id);
        Assert.Equal(newTicket.Description, addedTicket.Description);
    }

    [Fact]
    public async Task UpadteContact_WhenTicketExists_UpdatesTicket()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<TicketsDbContext>()
            .UseInMemoryDatabase(databaseName: "TicketDatabase")
            .Options;

        using var dbContext = new TicketsDbContext(options);
        var ticketProvider = new TicketProvider(dbContext);

        var controller = new TicketsController(ticketProvider);
        var existingTicket = new Ticket
        {
            Id = Guid.NewGuid(),
            Description = "Existing Ticket",
            DueDate = DateTime.Now,
            Title = "Existing Title",
            Priority = 2,
            Completed = false
        };

        dbContext.Tickets.Add(existingTicket);
        dbContext.SaveChanges();

        var updatedTicket = new Ticket
        {
            Id = existingTicket.Id,
            Description = "Updated Description",
            DueDate = DateTime.Now.AddDays(1),
            Title = "Updated Title",
            Priority = 3,
            Completed = true
        };

        // Act
        var result = await controller.UpadteTodo(existingTicket.Id, updatedTicket);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var updatedResult = Assert.IsType<Ticket>(okResult.Value);
        Assert.Equal(existingTicket.Id, updatedResult.Id);
        Assert.Equal(updatedTicket.Description, updatedResult.Description);
        Assert.Equal(updatedTicket.DueDate, updatedResult.DueDate);
    }

    [Fact]
    public async Task UpadteContact_WhenTicketDoesNotExist_ReturnsNotFound()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<TicketsDbContext>()
            .UseInMemoryDatabase(databaseName: "TicketDatabase")
            .Options;

        using var dbContext = new TicketsDbContext(options);
        var ticketProvider = new TicketProvider(dbContext);

        var controller = new TicketsController(ticketProvider);

        // Act
        var result = await controller.UpadteTodo(Guid.NewGuid(), new Ticket());

        // Assert
        Assert.IsType<NotFoundObjectResult>(result);
    }

    [Fact]
    public async Task Delete_WhenTicketExists_ReturnsOkResult()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<TicketsDbContext>()
            .UseInMemoryDatabase(databaseName: "TicketDatabase")
            .Options;

        using var dbContext = new TicketsDbContext(options);
        var ticketProvider = new TicketProvider(dbContext);

        var controller = new TicketsController(ticketProvider);

        var existingTicket = new Ticket
        {
            Id = Guid.NewGuid(),
            Description = "Existing Ticket",
            DueDate = DateTime.Now,
            Title = "Existing Title",
            Priority = 2,
            Completed = false
        };

        dbContext.Tickets.Add(existingTicket);
        dbContext.SaveChanges();

        // Act
        var result = await controller.Delete(existingTicket.Id);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var deletedTicket = Assert.IsType<Ticket>(okResult.Value);
        Assert.Equal(existingTicket.Id, deletedTicket.Id);
    }

    [Fact]
    public async Task Delete_WhenTicketDoesNotExist_ReturnsNotFound()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<TicketsDbContext>()
            .UseInMemoryDatabase(databaseName: "TicketDatabase")
            .Options;

        using var dbContext = new TicketsDbContext(options);
        var ticketProvider = new TicketProvider(dbContext);

        var controller = new TicketsController(ticketProvider);
        // Act
        var result = await controller.Delete(Guid.NewGuid());

        // Assert
        Assert.IsType<NotFoundObjectResult>(result);
    }
}