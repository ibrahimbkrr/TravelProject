namespace TravelProject.Dto.BlogDtos
{
    public class CreateBlogDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}