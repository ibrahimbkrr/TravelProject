using TravelProject.Entity.Entities;

namespace TravelProject.DataAccess.Abstract
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllWithBlogAsync();
    }
}