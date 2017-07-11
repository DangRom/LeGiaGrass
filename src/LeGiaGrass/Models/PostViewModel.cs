using System;

namespace LeGiaGrass.Models{
    public class PostViewModel{
       public string Name { get; set; }
       public string Alias { get; set; }
       public string Image { get; set; }
       public string ShortDescription { get; set; }
       public string Content { get; set; }
       public DateTime CreateDate { get; set; }
       public string CreateDay { get; set; }
       public string CreateMonth { get; set; }
       public int CategoryId { get; set; }
       public string CategoryName { get; set; }
    }
}