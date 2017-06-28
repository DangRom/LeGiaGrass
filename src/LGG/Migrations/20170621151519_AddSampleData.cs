using Microsoft.EntityFrameworkCore.Migrations;

namespace LGG.Migrations
{
    public partial class AddSampleData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Tag (TagId, Name, Url) VALUES(1,'Tag1', 'tag-tag1')");
            migrationBuilder.Sql("INSERT INTO Tag (TagId, Name, Url) VALUES(2,'Tag2', 'tag-tag2')");
            migrationBuilder.Sql("INSERT INTO Tag (TagId, Name, Url) VALUES(3,'Tag3', 'tag-tag3')");
            migrationBuilder.Sql("INSERT INTO Tag (TagId, Name, Url) VALUES(4,'Tag4', 'tag-tag4')");
            migrationBuilder.Sql("INSERT INTO Tag (TagId, Name, Url) VALUES(5,'Tag5', 'tag-tag5')");

            migrationBuilder.Sql("INSERT INTO Category (CategoryId, Name, Url) VALUES(1,'Blog', 'category-blogs')");
            migrationBuilder.Sql("INSERT INTO Category (CategoryId, Name, Url) VALUES(2,'Service', 'category-services')");
            migrationBuilder.Sql("INSERT INTO Category (CategoryId, Name, Url) VALUES(3,'Slide', 'category-slides')");
            migrationBuilder.Sql("INSERT INTO Category (CategoryId, Name, Url) VALUES(4,'Event', 'category-events')");
            migrationBuilder.Sql("INSERT INTO Category (CategoryId, Name, Url) VALUES(5,'Testimonial', 'category-testimonials')");

            //Galleries for Slide 
            migrationBuilder.Sql("INSERT INTO Gallery (GalleryId, CategoryId, Image, Name, Description) VALUES(1,3,'https://drive.google.com/uc?id=0B4NZzlONf1itcy1hYmc3UWJSN0E','Lawn Service','We offer total lawn care and routine maintenance to keep your lawn looking brand new')");
            migrationBuilder.Sql("INSERT INTO Gallery (GalleryId, CategoryId, Image, Name, Description) VALUES(2,3,'https://drive.google.com/uc?id=0B4NZzlONf1itcy1hYmc3UWJSN0E','Leaf Removal','Our crew blows leaves to an area of your choice ie: woods, garden, or compost pile')");
            migrationBuilder.Sql("INSERT INTO Gallery (GalleryId, CategoryId, Image, Name, Description) VALUES(3,3,'https://drive.google.com/uc?id=0B4NZzlONf1itcy1hYmc3UWJSN0E','Snow Removal','We don’t miss a beat when it comes to digging your home or office out from under the snow.')");

            //Galleries for Event
            migrationBuilder.Sql("INSERT INTO Gallery (GalleryId, CategoryId, Image, Name, Description) VALUES(4,4,'https://drive.google.com/uc?id=0B4NZzlONf1itcy1hYmc3UWJSN0E','Get Your Lawn Ready for Summer 2017!','Contact us for a free no obligation Lawn Care Survey worth $25 and we will agree a convenient time to meet you and survey your lawn.')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
