using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelProject.Dto.CommentDtos;
using TravelProject.Entity.Entities;

namespace TravelProject.Business.Abstract
{
    public interface ICommentService
    {
        Task<List<Comment>> GetAllAsync();
        Task<Comment?> GetByIdAsync(int id);
        Task AddAsync(Comment comment);
        Task UpdateAsync(Comment comment);
        Task DeleteAsync(int id);

        Task<List<ResultCommentDto>> GetAllWithBlogAsync();
    }
}
