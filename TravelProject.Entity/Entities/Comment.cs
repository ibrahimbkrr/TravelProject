namespace TravelProject.Entity.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string UserName { get; set; }
        public string CommentText { get; set; }
        public DateTime CreatedDate { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}