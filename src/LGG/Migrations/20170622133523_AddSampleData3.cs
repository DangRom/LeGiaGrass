using Microsoft.EntityFrameworkCore.Migrations;

namespace LGG.Migrations
{
    public partial class AddSampleData3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //services
            migrationBuilder.Sql("INSERT INTO Post (PostId, Title,Url, Description, Published,Image, SmallImage,CategoryId,PostedOn,CreatedOn, ModifiedOn) VALUES (1,'Title 1', 'post-url1','description 1',1,'https://images.pexels.com/photos/67636/rose-blue-flower-rose-blooms-67636.jpeg','https://images.pexels.com/photos/67636/rose-blue-flower-rose-blooms-67636.jpeg',2,'2017-06-22','2017-06-22','2017-06-22')");
            migrationBuilder.Sql("INSERT INTO Post (PostId, Title,Url, Description, Published,Image, SmallImage,CategoryId,PostedOn,CreatedOn, ModifiedOn) VALUES (2,'Title 2', 'post-url2','description 2',1,'https://images.pexels.com/photos/69937/rose-huang-plant-royalty-free-69937.jpeg','https://images.pexels.com/photos/69937/rose-huang-plant-royalty-free-69937.jpeg',2,'2017-06-22','2017-06-22','2017-06-22')");
            migrationBuilder.Sql("INSERT INTO Post (PostId, Title,Url, Description, Published,Image, SmallImage,CategoryId,PostedOn,CreatedOn, ModifiedOn) VALUES (3,'Title 5', 'post-url3','description 3',1,'https://images.pexels.com/photos/207962/pexels-photo-207962.jpeg','https://images.pexels.com/photos/207962/pexels-photo-207962.jpeg',2,'2017-06-22','2017-06-22','2017-06-22')");
            migrationBuilder.Sql("INSERT INTO Post (PostId, Title,Url, Description, Published,Image, SmallImage,CategoryId,PostedOn,CreatedOn, ModifiedOn) VALUES (4,'Title 3', 'post-url4','description 4',1,'https://images.pexels.com/photos/69059/poppy-pink-poppy-wildflowers-blossom-69059.jpeg','https://images.pexels.com/photos/69059/poppy-pink-poppy-wildflowers-blossom-69059.jpeg',2,'2017-06-22','2017-06-22','2017-06-22')");
            migrationBuilder.Sql("INSERT INTO Post (PostId, Title,Url, Description, Published,Image, SmallImage,CategoryId,PostedOn,CreatedOn, ModifiedOn) VALUES (5,'Title 4', 'post-url5','description 5',1,'https://images.pexels.com/photos/38265/flower-blossom-bloom-winter-38265.jpeg','https://images.pexels.com/photos/38265/flower-blossom-bloom-winter-38265.jpeg',2,'2017-06-22','2017-06-22','2017-06-22')");
            migrationBuilder.Sql("INSERT INTO Post (PostId, Title,Url, Description, Published,Image, SmallImage,CategoryId,PostedOn,CreatedOn, ModifiedOn) VALUES (6,'Title 6', 'post-url6','description 6',1,'https://images.pexels.com/photos/248744/pexels-photo-248744.jpeg','https://images.pexels.com/photos/248744/pexels-photo-248744.jpeg',2,'2017-06-22','2017-06-22','2017-06-22')");


            //blogs
            migrationBuilder.Sql("INSERT INTO Post (PostId, Title,Url, Description, Published,Image, SmallImage,CategoryId,PostedOn,CreatedOn, ModifiedOn) VALUES (7,'Title 7', 'post-url7','description 7',1,'https://images.pexels.com/photos/102973/pexels-photo-102973.jpeg','https://images.pexels.com/photos/102973/pexels-photo-102973.jpeg',1,'2017-06-22','2017-06-22','2017-06-22')");
            migrationBuilder.Sql("INSERT INTO Post (PostId, Title,Url, Description, Published,Image, SmallImage,CategoryId,PostedOn,CreatedOn, ModifiedOn) VALUES (8,'Title 8', 'post-url8','description 8',1,'https://images.pexels.com/photos/46968/cherry-blossom-blossom-bloom-spring-46968.jpeg','https://images.pexels.com/photos/46968/cherry-blossom-blossom-bloom-spring-46968.jpeg',1,'2017-06-22','2017-06-22','2017-06-22')");
            migrationBuilder.Sql("INSERT INTO Post (PostId, Title,Url, Description, Published,Image, SmallImage,CategoryId,PostedOn,CreatedOn, ModifiedOn) VALUES (9,'Title 9', 'post-url9','description 9',1,'https://images.pexels.com/photos/179132/pexels-photo-179132.jpeg','https://images.pexels.com/photos/179132/pexels-photo-179132.jpeg',1,'2017-06-22','2017-06-22','2017-06-22')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
