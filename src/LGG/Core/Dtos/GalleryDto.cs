namespace LGG.Core.Dtos
{
    public class GalleryDto
    {
        public int GalleryId { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public CategoryDto Category { get; set; }

        public GalleryDto()
        {
            Category = new CategoryDto();
        }
    }
}
