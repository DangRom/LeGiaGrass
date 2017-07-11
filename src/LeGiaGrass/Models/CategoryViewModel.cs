namespace LeGiaGrass.Models{
    public class CategoryViewModel{
        public int Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Image { get; set; }
        public string Descriptions { get; set; }
        public string Content { get; set; }
        public bool Activated { get; set; }
        public bool Service { get; set; }
        public int Orders { get; set; }
    }
}