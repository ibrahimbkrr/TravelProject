using TravelProject.Business.Abstract;
using TravelProject.DataAccess.Abstract;
using TravelProject.Dto.CommentDtos;
using TravelProject.Entity.Entities;

public class CommentManager : ICommentService
{
    private readonly IGenericRepository<Comment> _repository;
    private readonly ICommentRepository _commentRepository;

    public CommentManager(
        IGenericRepository<Comment> repository,
        ICommentRepository commentRepository)
    {
        _repository = repository;
        _commentRepository = commentRepository;
    }

    public async Task AddAsync(Comment comment)
    {
        await _repository.AddAsync(comment);
    }

    public async Task DeleteAsync(int id)
    {
        var comment = await _repository.GetByIdAsync(id);

        if (comment == null)
        {
            throw new Exception("Comment not found");
        }

        await _repository.DeleteAsync(comment);
    }

    public Task<List<Comment>> GetAllAsync()
    {
        return _repository.GetAllAsync();
    }

    public Task<Comment?> GetByIdAsync(int id)
    {
        return _repository.GetByIdAsync(id);
    }

    public Task UpdateAsync(Comment comment)
    {
        return _repository.UpdateAsync(comment);
    }

    public async Task<List<ResultCommentDto>> GetAllWithBlogAsync()
    {
        var comments = await _commentRepository.GetAllWithBlogAsync();

        return comments.Select(x => new ResultCommentDto
        {
            CommentId = x.CommentId,
            UserName = x.UserName,
            CommentText = x.CommentText,
            CreatedDate = x.CreatedDate,
            BlogId = x.BlogId,
            BlogName = x.Blog.Title
        }).ToList();
    }
}