using Microsoft.EntityFrameworkCore;
using TravelProject.DataAccess.Abstract;
using TravelProject.DataAccess.Context;
using TravelProject.Entity.Entities;

namespace TravelProject.DataAccess.Concrete
{
    public class CommentRepository : ICommentRepository
    {
        private readonly AppDbContext _context;

        public CommentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Comment>> GetAllWithBlogAsync()
        {
            return await _context.Comments
                .Include(x => x.Blog)
                .OrderByDescending(x => x.CreatedDate)
                .ToListAsync();
        }
    }
}