using System.ComponentModel.DataAnnotations;

namespace LeGiaGrass.Models{
    public class ServiceViewModel{
        public int Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Image { get; set; }
        public string Status { get; set; }
        public int Price { get; set; }
        public string ShortDescription { get; set; }
        public string Content { get; set; }
        public bool Activated { get; set; }
    }
}