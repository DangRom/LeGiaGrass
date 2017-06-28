using Microsoft.EntityFrameworkCore.Migrations;

namespace LGG.Migrations
{
    public partial class AddSampleData2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            //article
            migrationBuilder.Sql("INSERT INTO Article (ArticleId, Content) VALUES (1, '<p>About</p>')");
            migrationBuilder.Sql("INSERT INTO Article (ArticleId, Content) VALUES (2, '<p>Privacy</p>')");
            migrationBuilder.Sql("INSERT INTO Article (ArticleId, Content) VALUES (3, '<p>Terms of Services</p>')");

            //company 16.054407, 108.202167 Latitude Longitude
            migrationBuilder.Sql("INSERT INTO Company (Id, AboutId, Address, Avatar, Email, Facebook, Google, Hotline, Instagram, LinkedIn, Logo, Name, Pinterest, PrivacyId, Sologan, TermsOfUseId, TimeWork, Twitter, Website, Description, OurClients, OurDifference1, OurDifference2, OurDifference3, OurDifference4, OurDifference5, OurMission, VideoPresentation, WhyChooseUs, Latitude, Longitude) VALUES(1, 1, 'Da Nang', '', 'contact@dev.com', '#', '#', '123 456 789', '#', '#', '', 'Tên Công Ty', '#', 2, 'Sologan', 3, '24/7', '#', 'http://dev.com', 'Starting out with just a single truck and mower, we have expanded our services and grown into one of the largest lawn maintenance companies in our area. Our expansion and stellar reputation is due, in part, to our exceptional reputation for quality and timely service. Our lawn care technicians utilize the latest technology and techniques to deliver beautiful results that will stand the test of time.', '\r\nOur clients count on our dependability, our drive, and our integrity and we take great pride in our accomplishments and build on them every day.', 'Clean, Branded Vehicles', 'Professional, Uniformed Personnel', 'Timely Response Guarantee', 'Safe, Reliable Equipment Maintained Daily', 'Status and Quality Reports Delivered Timely', 'Our mission is to provide our customers with the highest level of quality services. We pledge to establish lasting relationships with our clients by exceeding their expectations and gaining their trust through exceptional performance.', 'https://www.youtube.com/embed/NypiOFIGvdU', 'The single biggest difference between Lawn Care and other lawn care providers boils down to one simple premise: we care more. It’s the kind of caring that can only come from being the business owner. One that lives, works, and is a part of the community they serve.\r\n\r\nWe have the highest customer retention rate in the industry.\r\nWe have 50 years of experience.\r\nWe have the highest TrustPilot score in the industry.\r\nWe’re locally owned, so there’s no big business “run-around”.\r\nWe offer the best guarantee in the business: If you’re not 100% satisfied – we’ll make it right. It’s that simple.', '16.054407', '108.202167')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
