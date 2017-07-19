namespace LeGiaGrass.Services.Models{
    public class CategoryModel{
        public int Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public bool Activated { get; set; }
        public bool Service { get; set; }
        public int Orders { get; set; }
        public bool News { get; set; }
    }
}