namespace LeGiaGrass.Models{
    public class FeedbackViewModel{
       public int Id { get; set; }
        public string FullName { get; set; }
        public string Avatar { get; set; }
        public string Content { get; set; }
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
    }
}