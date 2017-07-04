using System.ComponentModel;

namespace LGG.Core.Helpers
{
    public enum BaseCategoryName
    {
        [Description("Tin Tức")]
        Blog = 1,
        [Description("Dịch Vụ")]
        Service = 2,
        Slide = 3,
        Event = 4,
        Testimonial = 5,
        Diffirence = 6,
        Gallery = 7
    }

    public enum AboutType
    {
        [Description("Thông Tin")]
        About = 1,
        [Description("Chính Sách")]
        Privacy = 2,
        [Description("Điều Khoản Sử Dụng")]
        TermsOfUse = 3,
        [Description("Dữ Liệu Không Tồn Tại!")]
        Null = 4
    }
}
