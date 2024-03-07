using Domain.Abstract;

namespace Domain.Entities
{
    public class About:IEntity
    {
        public int AboutID { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
