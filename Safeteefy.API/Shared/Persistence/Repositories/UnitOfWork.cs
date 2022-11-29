using Safeteefy.API.Shared.Domain.Repositories;
using Safeteefy.API.Shared.Persistence.Contexts;

namespace Safeteefy.API.Shared.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context) { _context = context; }

    public async Task CompleteAsync() { await _context.SaveChangesAsync(); }
}