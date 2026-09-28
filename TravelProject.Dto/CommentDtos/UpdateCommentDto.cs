using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelProject.Dto.CommentDtos
{
    public class UpdateCommentDto
    {
        public int CommentId { get; set; }
        public string UserName { get; set; }
        public string CommentText { get; set; }
        public DateTime CreatedDate { get; set; }

        public int BlogId { get; set; }
    }
}
