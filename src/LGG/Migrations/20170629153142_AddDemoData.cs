using Microsoft.EntityFrameworkCore.Migrations;

namespace LGG.Migrations
{
    public partial class AddDemoData : Migration
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
            migrationBuilder.Sql("INSERT INTO Category (CategoryId, Name, Url) VALUES(6,'Gallery', 'category-Galleries')");
            migrationBuilder.Sql("INSERT INTO Category (CategoryId, Name, Url) VALUES(7,'Diffirence', 'category-Diffirences')");

            //Galleries for Slide 
            migrationBuilder.Sql("INSERT INTO Gallery (GalleryId, CategoryId, Image, Name, Description) VALUES(1,3,'','Lawn Service','We offer total lawn care and routine maintenance to keep your lawn looking brand new')");
            migrationBuilder.Sql("INSERT INTO Gallery (GalleryId, CategoryId, Image, Name, Description) VALUES(2,3,'','Leaf Removal','Our crew blows leaves to an area of your choice ie: woods, garden, or compost pile')");
            migrationBuilder.Sql("INSERT INTO Gallery (GalleryId, CategoryId, Image, Name, Description) VALUES(3,3,'','Snow Removal','We don’t miss a beat when it comes to digging your home or office out from under the snow.')");

            //Galleries for Event
            migrationBuilder.Sql("INSERT INTO Gallery (GalleryId, CategoryId, Image, Name, Description) VALUES(4,4,'','Get Your Lawn Ready for Summer 2017!','Contact us for a free no obligation Lawn Care Survey worth $25 and we will agree a convenient time to meet you and survey your lawn.')");

            //Galleies for Diffirence
            migrationBuilder.Sql("INSERT INTO Gallery (GalleryId, CategoryId, Image, Name, Description) VALUES(5,7,'','Get Your Lawn Ready for Summer 2017!','Contact us for a free no obligation Lawn Care Survey worth $25 and we will agree a convenient time to meet you and survey your lawn.')");

            //article
            migrationBuilder.Sql("INSERT INTO Article (ArticleId, Content) VALUES (1, '<p>About</p>')");
            migrationBuilder.Sql("INSERT INTO Article (ArticleId, Content) VALUES (2, '<p>Privacy</p>')");
            migrationBuilder.Sql("INSERT INTO Article (ArticleId, Content) VALUES (3, '<p>Terms of Services</p>')");
            //ExcerptId
            migrationBuilder.Sql("INSERT INTO Excerpt (ExcerptId, Content) VALUES (1, 'We have been with Lawn Care several years and we have had great service winter, spring, summer and fall. Today was a hi-light when our yard was finished with the landscaping.')");

            //company 16.054407, 108.202167 Latitude Longitude
            migrationBuilder.Sql("INSERT INTO Company (Id, AboutId, Address, Avatar, Email, ContactEmail, SupportEmail, Facebook, Google, Hotline, Phone, Instagram, LinkedIn, Logo, Name, Pinterest, PrivacyId, Sologan, TermsOfUseId, TimeWork, Twitter, Website, Description, OurClients, OurDifference1, OurDifference2, OurDifference3, OurDifference4, OurDifference5, OurMission, VideoPresentation, WhyChooseUs, Latitude, Longitude) VALUES(1, 1, 'Da Nang', '', 'admin@dev.com', 'contact@dev.com', 'support@dev.com', '', '', '(+84)989183193', '(+84) 511 3 123 456', '', '', '', 'Tên Công Ty', '', 2, 'Sologan', 3, '24/7', '', 'http://dev.com', 'Starting out with just a single truck and mower, we have expanded our services and grown into one of the largest lawn maintenance companies in our area. Our expansion and stellar reputation is due, in part, to our exceptional reputation for quality and timely service. Our lawn care technicians utilize the latest technology and techniques to deliver beautiful results that will stand the test of time.', '\r\nOur clients count on our dependability, our drive, and our integrity and we take great pride in our accomplishments and build on them every day.', 'Clean, Branded Vehicles', 'Professional, Uniformed Personnel', 'Timely Response Guarantee', 'Safe, Reliable Equipment Maintained Daily', 'Status and Quality Reports Delivered Timely', 'Our mission is to provide our customers with the highest level of quality services. We pledge to establish lasting relationships with our clients by exceeding their expectations and gaining their trust through exceptional performance.', 'https://www.youtube.com/embed/NypiOFIGvdU', 'The single biggest difference between Lawn Care and other lawn care providers boils down to one simple premise: we care more. It’s the kind of caring that can only come from being the business owner. One that lives, works, and is a part of the community they serve.\r\n\r\nWe have the highest customer retention rate in the industry.\r\nWe have 50 years of experience.\r\nWe have the highest TrustPilot score in the industry.\r\nWe’re locally owned, so there’s no big business “run-around”.\r\nWe offer the best guarantee in the business: If you’re not 100% satisfied – we’ll make it right. It’s that simple.', '16.054407', '108.202167')");


            //services
            migrationBuilder.Sql("INSERT INTO Post (PostId, Title,Url, Description, Published,Image, SmallImage,CategoryId,PostedOn,CreatedOn, ModifiedOn) VALUES (1,'Title 1', 'post-url1','description 1',1,'','',2,'2017-06-22','2017-06-22','2017-06-22')");
            migrationBuilder.Sql("INSERT INTO Post (PostId, Title,Url, Description, Published,Image, SmallImage,CategoryId,PostedOn,CreatedOn, ModifiedOn) VALUES (2,'Title 2', 'post-url2','description 2',1,'','',2,'2017-06-22','2017-06-22','2017-06-22')");
            migrationBuilder.Sql("INSERT INTO Post (PostId, Title,Url, Description, Published,Image, SmallImage,CategoryId,PostedOn,CreatedOn, ModifiedOn) VALUES (3,'Title 5', 'post-url3','description 3',1,'','',2,'2017-06-22','2017-06-22','2017-06-22')");
            migrationBuilder.Sql("INSERT INTO Post (PostId, Title,Url, Description, Published,Image, SmallImage,CategoryId,PostedOn,CreatedOn, ModifiedOn) VALUES (4,'Title 3', 'post-url4','description 4',1,'','',2,'2017-06-22','2017-06-22','2017-06-22')");
            migrationBuilder.Sql("INSERT INTO Post (PostId, Title,Url, Description, Published,Image, SmallImage,CategoryId,PostedOn,CreatedOn, ModifiedOn) VALUES (5,'Title 4', 'post-url5','description 5',1,'','',2,'2017-06-22','2017-06-22','2017-06-22')");
            migrationBuilder.Sql("INSERT INTO Post (PostId, Title,Url, Description, Published,Image, SmallImage,CategoryId,PostedOn,CreatedOn, ModifiedOn) VALUES (6,'Title 6', 'post-url6','description 6',1,'','',2,'2017-06-22','2017-06-22','2017-06-22')");

            //blogs
            migrationBuilder.Sql("INSERT INTO Post (PostId, Title,Url, Description, Published,Image, SmallImage,CategoryId,PostedOn,CreatedOn, ModifiedOn) VALUES (7,'Title 7', 'post-url7','description 7',1,'https://images.pexels.com/photos/102973/pexels-photo-102973.jpeg','https://images.pexels.com/photos/102973/pexels-photo-102973.jpeg',1,'2017-06-22','2017-06-22','2017-06-22')");
            migrationBuilder.Sql("INSERT INTO Post (PostId, Title,Url, Description, Published,Image, SmallImage,CategoryId,PostedOn,CreatedOn, ModifiedOn) VALUES (8,'Title 8', 'post-url8','description 8',1,'https://images.pexels.com/photos/46968/cherry-blossom-blossom-bloom-spring-46968.jpeg','https://images.pexels.com/photos/46968/cherry-blossom-blossom-bloom-spring-46968.jpeg',1,'2017-06-22','2017-06-22','2017-06-22')");
            migrationBuilder.Sql("INSERT INTO Post (PostId, Title,Url, Description, Published,Image, SmallImage,CategoryId,PostedOn,CreatedOn, ModifiedOn) VALUES (9,'Title 9', 'post-url9','description 9',1,'https://images.pexels.com/photos/179132/pexels-photo-179132.jpeg','https://images.pexels.com/photos/179132/pexels-photo-179132.jpeg',1,'2017-06-22','2017-06-22','2017-06-22')");

            //testimonials
            migrationBuilder.Sql("INSERT INTO Post (PostId, Title,Url, Description, Published,Image, SmallImage,CategoryId,PostedOn,CreatedOn, ModifiedOn, ExcerptId) VALUES (10,'Alex', 'post-url10','Chu nha',1,'','',5,'2017-06-22','2017-06-22','2017-06-22',1)");
            migrationBuilder.Sql("INSERT INTO Post (PostId, Title,Url, Description, Published,Image, SmallImage,CategoryId,PostedOn,CreatedOn, ModifiedOn, ExcerptId) VALUES (11,'Jonh', 'post-url11','Chu nha',1,'','',5,'2017-06-22','2017-06-22','2017-06-22', 1)");
            migrationBuilder.Sql("INSERT INTO Post (PostId, Title,Url, Description, Published,Image, SmallImage,CategoryId,PostedOn,CreatedOn, ModifiedOn, ExcerptId) VALUES (12,'Max', 'post-url12','Chu san bong',1,'','',5,'2017-06-22','2017-06-22','2017-06-22',1)");
            migrationBuilder.Sql("INSERT INTO Post (PostId, Title,Url, Description, Published,Image, SmallImage,CategoryId,PostedOn,CreatedOn, ModifiedOn, ExcerptId) VALUES (13,'Piter', 'post-url13','chu san bong mini',1,'','',5,'2017-06-22','2017-06-22','2017-06-22',1)");
            migrationBuilder.Sql("INSERT INTO Post (PostId, Title,Url, Description, Published,Image, SmallImage,CategoryId,PostedOn,CreatedOn, ModifiedOn, ExcerptId) VALUES (14,'Karen', 'post-url14','Ong chu cty A',1,'','',5,'2017-06-22','2017-06-22','2017-06-22',1)");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
