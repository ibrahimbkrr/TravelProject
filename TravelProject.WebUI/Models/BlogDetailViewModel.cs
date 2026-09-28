using TravelProject.Dto.BlogDtos;
using TravelProject.Dto.CommentDtos;

namespace TravelProject.WebUI.Models
{
    public class BlogDetailViewModel
    {
        public ResultBlogDto Blog { get; set; }

        public List<ResultCommentDto> Comments { get; set; }

        public CreateCommentDto NewComment { get; set; }

        public List<ResultBlogDto> RecentBlogs { get; set; }

        public List<ResultCommentDto> RecentComments { get; set; }
    }
}