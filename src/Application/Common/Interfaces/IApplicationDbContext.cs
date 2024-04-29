using CartingService.Domain.Entities;

namespace CartingService.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }
    DbSet<Cart> Carts{ get; }

    DbSet<Item> Items{ get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
