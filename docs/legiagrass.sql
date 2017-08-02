/*
Navicat MySQL Data Transfer

Source Server         : mysql server local
Source Server Version : 50719
Source Host           : localhost:3306
Source Database       : legiagrass

Target Server Type    : MYSQL
Target Server Version : 50719
File Encoding         : 65001

Date: 2017-08-02 20:30:01
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for category
-- ----------------------------
DROP TABLE IF EXISTS `category`;
CREATE TABLE `category` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` tinytext COLLATE utf8_unicode_ci,
  `Alias` tinytext COLLATE utf8_unicode_ci,
  `Image` tinytext COLLATE utf8_unicode_ci,
  `Description` tinytext COLLATE utf8_unicode_ci,
  `Activated` bit(1) DEFAULT NULL,
  `Service` bit(1) DEFAULT NULL,
  `Orders` int(11) DEFAULT NULL,
  `Content` longtext COLLATE utf8_unicode_ci,
  `News` bit(1) DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of category
-- ----------------------------
INSERT INTO `category` VALUES ('3', 'Dịch Vụ', 'khoa-hoc', 'khoahoc', 'Lawn Care, is a locally owned and operated lawn care company providing environmentally responsible', '', '', '2', '<p>dfdf</p>', null);
INSERT INTO `category` VALUES ('4', 'Bài viết', 'bai-viet', null, 'tin tức 123', '', '\0', '3', null, '');
INSERT INTO `category` VALUES ('7', 'Videos', 'videos', null, 'Lawn Care, is a locally owned and operated lawn care company providing environmentally responsible', '', '\0', '2', null, null);

-- ----------------------------
-- Table structure for company
-- ----------------------------
DROP TABLE IF EXISTS `company`;
CREATE TABLE `company` (
  `Name` tinytext COLLATE utf8_unicode_ci,
  `Address` tinytext COLLATE utf8_unicode_ci,
  `Phone` tinytext COLLATE utf8_unicode_ci,
  `Hotline` tinytext COLLATE utf8_unicode_ci,
  `Email` tinytext COLLATE utf8_unicode_ci,
  `TaxCode` tinytext COLLATE utf8_unicode_ci,
  `Facebook` tinytext COLLATE utf8_unicode_ci,
  `Google` tinytext COLLATE utf8_unicode_ci,
  `Twitter` tinytext COLLATE utf8_unicode_ci,
  `Description` text COLLATE utf8_unicode_ci,
  `About` longtext COLLATE utf8_unicode_ci,
  `Slogan` text COLLATE utf8_unicode_ci,
  `BusinessHours` text COLLATE utf8_unicode_ci,
  `Logo` text COLLATE utf8_unicode_ci,
  `Latitude` double DEFAULT NULL,
  `Longitude` double DEFAULT NULL,
  `WhyChooseUs` text COLLATE utf8_unicode_ci
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of company
-- ----------------------------
INSERT INTO `company` VALUES ('Công Ty Lê Gia-', 'Đà Nẵng-', 'chưa có', '911', 'legiagrass@gmail.com', 'chưa có', 'chưa tạo', 'chưa tạo', 'chưa tạo', '<h2 class=\"text-center lined\">About Us</h2>\r\n<p class=\"text-center info-text\">Starting out with just a single truck and mower, we have expanded our services and grown into one of the largest lawn maintenance companies in our area. Our expansion and stellar reputation is due, in part, to our exceptional reputation for quality and timely service. Our lawn care technicians utilize the latest technology and techniques to deliver beautiful results that will stand the test of time.</p>\r\n<div class=\"row\">\r\n<div class=\"col-sm-6 animation\" data-animation=\"fadeInLeft\" data-animation-delay=\"0.5s\">\r\n<div class=\"text-icon__title\">Our Mission</div>\r\n<div class=\"text-icon last\">\r\n<div class=\"text-icon__icon\">&nbsp;</div>\r\n<div class=\"text-icon__info\">\r\n<p>Our mission is to provide our customers with the highest level of quality services. We pledge to establish lasting relationships with our clients by exceeding their expectations and gaining their trust through exceptional performance.</p>\r\n</div>\r\n</div>\r\n</div>\r\n<div class=\"col-sm-6 animation\" data-animation=\"fadeInRight\" data-animation-delay=\"0.5s\">\r\n<div class=\"text-icon__title\">Our Clients</div>\r\n<div class=\"text-icon last\">\r\n<div class=\"text-icon__icon\">&nbsp;</div>\r\n<div class=\"text-icon__info\">\r\n<p>Our clients count on our dependability, our drive, and our integrity and we take great pride in our accomplishments and build on them every day.</p>\r\n</div>\r\n</div>\r\n</div>\r\n</div>', '<div class=\"container\">\r\n<h1 class=\"text-center lined\">About Us</h1>\r\n<p class=\"text-center info-text\">Starting out with just a single truck and mower, we have expanded our services and grown into one of the largest lawn maintenance companies in our area. Our expansion and stellar reputation is due, in part, to our exceptional reputation for quality and timely service. Our lawn care technicians utilize the latest technology and techniques to deliver beautiful results that will stand the test of time.</p>\r\n<div class=\"divider divider--sm\">&nbsp;</div>\r\n<div class=\"animation\" data-animation=\"fadeIn\"><img class=\"img-responsive\" src=\"../../images/img-about-4.jpg\" alt=\"\" /></div>\r\n<div class=\"divider divider--md\">&nbsp;</div>\r\n<div class=\"row\">\r\n<div class=\"col-sm-6 animation\" data-animation=\"fadeInLeft\" data-animation-delay=\"0.5s\">\r\n<div class=\"text-icon__title\">Our Mission</div>\r\n<div class=\"text-icon last\">\r\n<div class=\"text-icon__icon\">&nbsp;</div>\r\n<div class=\"text-icon__info\">\r\n<p>Our mission is to provide our customers with the highest level of quality services. We pledge to establish lasting relationships with our clients by exceeding their expectations and gaining their trust through exceptional performance.</p>\r\n</div>\r\n</div>\r\n</div>\r\n<div class=\"col-sm-6 animation\" data-animation=\"fadeInRight\" data-animation-delay=\"0.5s\">\r\n<div class=\"text-icon__title\">Our Clients</div>\r\n<div class=\"text-icon last\">\r\n<div class=\"text-icon__icon\">&nbsp;</div>\r\n<div class=\"text-icon__info\">\r\n<p>Our clients count on our dependability, our drive, and our integrity and we take great pride in our accomplishments and build on them every day.</p>\r\n</div>\r\n</div>\r\n</div>\r\n</div>\r\n<div class=\"divider divider--md\">&nbsp;</div>\r\n<h2 class=\"text-center lined\">Our Advantages</h2>\r\n<div class=\"advantages-block\">\r\n<div class=\"row\">\r\n<div class=\"col-sm-4\">Affordable Pricing</div>\r\n<div class=\"col-sm-4\">Fast Online Ordering</div>\r\n<div class=\"col-sm-4\">Satisfaction Guaranteed</div>\r\n</div>\r\n</div>\r\n<div class=\"row\">\r\n<div class=\"col-sm-4\"><img class=\"img-responsive\" src=\"../../images/img-about-1.jpg\" alt=\"\" /></div>\r\n<div class=\"divider divider--xs visible-xs\">&nbsp;</div>\r\n<div class=\"col-sm-4\"><img class=\"img-responsive\" src=\"../../images/img-about-2.jpg\" alt=\"\" /></div>\r\n<div class=\"divider divider--xs visible-xs\">&nbsp;</div>\r\n<div class=\"col-sm-4\"><img class=\"img-responsive\" src=\"../../images/img-about-3.jpg\" alt=\"\" /></div>\r\n</div>\r\n<div class=\"divider divider--md\">&nbsp;</div>\r\n<div class=\"text-center\">\r\n<p>We are a full service landscape maintenance company who commit to fulfilling all your landscape and lawn related needs. Our team of experts have over 28 years of experience in the landscape industry, which helps us develop and deliver custom made programs and solutions for you and your lawn. Through constant communication between our lawn care, landscape maintenance, and irrigation managers, we are able to provide you with a solution for any landscape. Our maintenance team completes a full property analysis during each visit and resolves any landscape related issues immediately to ensure your lawn is at its healthiest and looks its best. Lawn Care provides professional and quality landscaping services for both residential and commercial properties. From start to finish, we offer a wide range of lawn care services to accommodate your needs every step along the way.</p>\r\n<p>We take pride in providing customers satisfaction that is second-to-none. Our team of professionals is fully licensed, insured, and well trained to provide you with consistent and high-quality value and services.</p>\r\n</div>\r\n<div class=\"divider divider--md\">&nbsp;</div>\r\n<h2 class=\"text-center lined\">Lawn Care Team</h2>\r\n<div class=\"row\">\r\n<div class=\"col-sm-6 col-md-3\">\r\n<div class=\"person animation\" data-animation=\"fadeInLeft\" data-animation-delay=\"0.3s\">\r\n<div class=\"person__image\"><img class=\"img-responsive\" src=\"../../images/person-01.jpg\" alt=\"\" /></div>\r\n<div class=\"person__title\">Mark Ronson</div>\r\n<div class=\"person__position\">Customer Service Manager</div>\r\n<div class=\"person__text\">\r\n<p>He joined our team 3 years ago and we are excited to have him as our lead technician</p>\r\n</div>\r\n</div>\r\n</div>\r\n<div class=\"col-sm-6 col-md-3\">\r\n<div class=\"person animation\" data-animation=\"fadeInLeft\" data-animation-delay=\"0s\">\r\n<div class=\"person__image\"><img class=\"img-responsive\" src=\"../../images/person-02.jpg\" alt=\"\" /></div>\r\n<div class=\"person__title\">Christopher Stoudt</div>\r\n<div class=\"person__position\">Fertilizer Technician</div>\r\n<div class=\"person__text\">\r\n<p>Over 6 years of experience in the lawn care industry and an interest in organic solutions</p>\r\n</div>\r\n</div>\r\n</div>\r\n<div class=\"col-sm-6 col-md-3\">\r\n<div class=\"person animation\" data-animation=\"fadeInRight\" data-animation-delay=\"0s\">\r\n<div class=\"person__image\"><img class=\"img-responsive\" src=\"../../images/person-03.jpg\" alt=\"\" /></div>\r\n<div class=\"person__title\">Joe Saboe</div>\r\n<div class=\"person__position\">Technician</div>\r\n<div class=\"person__text\">\r\n<p>He has worked as a certified technician for the past 7 years</p>\r\n</div>\r\n</div>\r\n</div>\r\n<div class=\"col-sm-6 col-md-3\">\r\n<div class=\"person animation last\" data-animation=\"fadeInRight\" data-animation-delay=\"0.3s\">\r\n<div class=\"person__image\"><img class=\"img-responsive\" src=\"../../images/person-04.jpg\" alt=\"\" /></div>\r\n<div class=\"person__title\">Alisa Madden</div>\r\n<div class=\"person__position\">Administrative Assistant</div>\r\n<div class=\"person__text\">\r\n<p>She is always available for customer\'s needs and answers the phone with a smile</p>\r\n</div>\r\n</div>\r\n</div>\r\n</div>\r\n<div class=\"divider divider--md\">&nbsp;</div>\r\n<div class=\"text-center\"><a class=\"btn btn--wd\">MEET ALL TEAM</a></div>\r\n</div>', 'slogan', '7 DAYS A WEEK FROM 9:00 AM TO 7:00 PM', null, null, null, '<div class=\"container\">\r\n<div class=\"row\">\r\n<div class=\"col-md-8 animated\" style=\"animation-delay: 0.6s;\" data-animation=\"fadeIn\" data-animation-delay=\"0.6s\">\r\n<h2 class=\"text-center lined\">Video Presentation</h2>\r\n<div class=\"video-responsive\"><iframe src=\"http://www.youtube.com/embed/-PWxUQCNGtg?wmode=opaque\" width=\"300\" height=\"150\" allowfullscreen=\"allowfullscreen\"></iframe></div>\r\n</div>\r\n<div class=\"divider divider--md visible-sm visible-xs\">&nbsp;</div>\r\n<div class=\"col-md-4 animated\" style=\"animation-delay: 0.9s;\" data-animation=\"fadeIn\" data-animation-delay=\"0.9s\">\r\n<h2 class=\"text-center lined\">Why Choose Us?</h2>\r\n<p>The single biggest difference between Lawn Care and other lawn care providers boils down to one simple premise: we care more. It&rsquo;s the kind of caring that can only come from being the business owner. One that lives, works, and is a part of the community they serve.</p>\r\n<ul class=\"marker-list-sm\">\r\n<li>We have the highest customer retention rate in the industry.</li>\r\n<li>We have 50 years of experience.</li>\r\n<li>We have the highest TrustPilot score in the industry.</li>\r\n<li>We&rsquo;re locally owned, so there&rsquo;s no big business &ldquo;run-around&rdquo;.</li>\r\n<li>We offer the best guarantee in the business: If you&rsquo;re not 100% satisfied &ndash; we&rsquo;ll make it right. It&rsquo;s that simple.</li>\r\n</ul>\r\n</div>\r\n</div>\r\n</div>');

-- ----------------------------
-- Table structure for feedbacks
-- ----------------------------
DROP TABLE IF EXISTS `feedbacks`;
CREATE TABLE `feedbacks` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FullName` tinytext COLLATE utf8_unicode_ci NOT NULL,
  `Avatar` tinytext COLLATE utf8_unicode_ci NOT NULL,
  `Content` text COLLATE utf8_unicode_ci NOT NULL,
  `CreateDate` datetime NOT NULL,
  `ServiceId` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  KEY `ServiceId` (`ServiceId`) USING BTREE,
  CONSTRAINT `Feedbacks_ibfk_1` FOREIGN KEY (`ServiceId`) REFERENCES `services` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of feedbacks
-- ----------------------------
INSERT INTO `feedbacks` VALUES ('1', 'Hs A', 'http://res.cloudinary.com/degic-vn/image/upload/v1499497904/avatar-3_apebsz.jpg', '<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Quas vel sint, ut. Quisquam doloremque minus possimus eligendi dolore ad.</p>', '2017-07-09 00:42:46', '7');
INSERT INTO `feedbacks` VALUES ('2', 'Hs B', 'http://res.cloudinary.com/degic-vn/image/upload/v1499497904/avatar-2_vp24ev.jpg', '<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Quas vel sint, ut. Quisquam doloremque minus possimus eligendi dolore ad.</p>', '2017-07-09 00:43:18', '5');
INSERT INTO `feedbacks` VALUES ('3', 'Hs C', 'http://res.cloudinary.com/degic-vn/image/upload/v1499497903/avatar-1_u2zaq0.jpg', '<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Quas vel sint, ut. Quisquam doloremque minus possimus eligendi dolore ad.</p>', '2017-07-09 00:43:45', '4');

-- ----------------------------
-- Table structure for images
-- ----------------------------
DROP TABLE IF EXISTS `images`;
CREATE TABLE `images` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` tinytext,
  `Image` text,
  `Customer` bit(1) DEFAULT NULL,
  `Gallery` bit(1) DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of images
-- ----------------------------
INSERT INTO `images` VALUES ('4', 'Cỏ 1', 'http://res.cloudinary.com/legiatrans-com/image/upload/v1500501956/gallery-img-03_hzp3yb.jpg', '\0', '');
INSERT INTO `images` VALUES ('5', 'Cỏ 2', 'http://res.cloudinary.com/legiatrans-com/image/upload/v1500501956/gallery-img-04_uulvgv.jpg', '\0', '');
INSERT INTO `images` VALUES ('13', 'Cỏ 3', 'http://res.cloudinary.com/legiatrans-com/image/upload/v1500501956/gallery-img-14_lssibl.jpg', '\0', '');
INSERT INTO `images` VALUES ('14', 'Cỏ 4', 'http://res.cloudinary.com/legiatrans-com/image/upload/v1500501956/gallery-img-15_ts25pn.jpg', '\0', '');
INSERT INTO `images` VALUES ('15', 'Cỏ 5', 'http://res.cloudinary.com/legiatrans-com/image/upload/v1500501956/gallery-img-16_nde7ei.jpg', '\0', '');
INSERT INTO `images` VALUES ('16', 'Cỏ 6', 'http://res.cloudinary.com/legiatrans-com/image/upload/v1500501956/gallery-img-17_vca65f.jpg', '\0', '');
INSERT INTO `images` VALUES ('17', 'Cỏ 7', 'http://res.cloudinary.com/legiatrans-com/image/upload/v1500501956/gallery-img-18_rhlp4f.jpg', '\0', '');

-- ----------------------------
-- Table structure for posts
-- ----------------------------
DROP TABLE IF EXISTS `posts`;
CREATE TABLE `posts` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` tinytext COLLATE utf8_unicode_ci NOT NULL,
  `Alias` tinytext COLLATE utf8_unicode_ci NOT NULL,
  `Image` tinytext COLLATE utf8_unicode_ci,
  `ShortDescription` tinytext COLLATE utf8_unicode_ci,
  `Content` longtext COLLATE utf8_unicode_ci,
  `Activated` bit(1) DEFAULT NULL,
  `CategoryId` int(11) DEFAULT NULL,
  `CreateDate` datetime NOT NULL,
  `HomePage` bit(1) DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  KEY `CategoryId` (`CategoryId`) USING BTREE,
  CONSTRAINT `Posts_ibfk_1` FOREIGN KEY (`CategoryId`) REFERENCES `category` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of posts
-- ----------------------------
INSERT INTO `posts` VALUES ('1', 'Bài viết a', 'bai-viet-a', 'http://res.cloudinary.com/degic-vn/image/upload/v1499497909/new-2_fqu3cj.jpg', 'Lorem ipsum dolor sit amet, consectetur adipisi cing elit. Molestias eius illum libero dolor nobis deleniti, sint assumenda Pariatur iste.', '<p><i>If your lawn is looking thin or bare, it might be time to sow it with a layer of grass seed to restore it to its lush, green state. The cool-season grasses of Pennsylvania fare best in the fall when the air is cooling down but the soil is still warm, giving grass a few months to grow before winter comes around. Read on to learn more about why fall is the best time to reseed your lawn.</i></p>\r\r\n										<h4>Why Fall?</h4>\r\r\n										<p>In Pennsylvania, early fall is the best time to sow grass seeds for a number of reasons. Seeding in the fall allows cool-season grasses to establish before winter. Try to sow two months before the first frost of the season. There are fewer active lawn diseases during fall, and weeds tend to taper off, meaning your grass won’t have to compete as much for access to sun and water. Sunlight begins to increase during fall as the tree leaves begin to drop. Moisture is key to growing a healthy lawn of grass, making spring the second-most popular (but less ideal) season for seeding.</p>\r\r\n										<h4>Why Not Spring?</h4>\r\r\n										<p>Though the moisture and warm air are beneficial to grass growth, there are a few things about spring that make it less-than-ideal for reseeding. Weeds are more prevalent in the spring, which causes grass to have to compete for the nutrients it needs to thrive. Spring also means that summer is right around the corner. The summer’s hot temperatures and drought conditions can introduce undesirable stress to your new lawn.</p>\r\r\n										<h4>Remember:</h4>\r\r\n										<ul>\r\r\n											<li>Mow low: this will help grass seeds reach the soil more easily.</li>\r\r\n											<li>Aerate and dethatch: break up soil compaction and remove excessive thatch with a dethatcher.</li>\r\r\n											<li>Fertilize: help your lawn develop a healthy root system by applying</li>\r\r\n											<li>a seed-starting fertilizer with a fertilizer spreader.</li>\r\r\n											<li>Use a seed spreader: apply after carefully reading the manufacturer’s instructions.</li>\r\r\n											<li>Water: try to keep your soil moist in the weeks after you reseed.</li>\r\r\n										</ul>\r\r\n										<ul class=\"tags-list\">\r\r\n											<li><a href=\"#\">Lawn care</a></li>\r\r\n											<li><a href=\"#\">Pennsylvania</a></li>\r\r\n											<li><a href=\"#\">Moisture</a></li>\r\r\n\r\r\n										</ul>', '', '4', '0001-01-01 00:00:00', '');
INSERT INTO `posts` VALUES ('2', 'Bài viết b', 'bai-viet-b', 'http://res.cloudinary.com/degic-vn/image/upload/v1499497910/new-3_ltij75.jpg', 'Lorem ipsum dolor sit amet, consectetur adipisi cing elit. Molestias eius illum libero dolor nobis deleniti, sint assumenda Pariatur iste.', '<p><i>If your lawn is looking thin or bare, it might be time to sow it with a layer of grass seed to restore it to its lush, green state. The cool-season grasses of Pennsylvania fare best in the fall when the air is cooling down but the soil is still warm, giving grass a few months to grow before winter comes around. Read on to learn more about why fall is the best time to reseed your lawn.</i></p>\r\r\n										<h4>Why Fall?</h4>\r\r\n										<p>In Pennsylvania, early fall is the best time to sow grass seeds for a number of reasons. Seeding in the fall allows cool-season grasses to establish before winter. Try to sow two months before the first frost of the season. There are fewer active lawn diseases during fall, and weeds tend to taper off, meaning your grass won’t have to compete as much for access to sun and water. Sunlight begins to increase during fall as the tree leaves begin to drop. Moisture is key to growing a healthy lawn of grass, making spring the second-most popular (but less ideal) season for seeding.</p>\r\r\n										<h4>Why Not Spring?</h4>\r\r\n										<p>Though the moisture and warm air are beneficial to grass growth, there are a few things about spring that make it less-than-ideal for reseeding. Weeds are more prevalent in the spring, which causes grass to have to compete for the nutrients it needs to thrive. Spring also means that summer is right around the corner. The summer’s hot temperatures and drought conditions can introduce undesirable stress to your new lawn.</p>\r\r\n										<h4>Remember:</h4>\r\r\n										<ul>\r\r\n											<li>Mow low: this will help grass seeds reach the soil more easily.</li>\r\r\n											<li>Aerate and dethatch: break up soil compaction and remove excessive thatch with a dethatcher.</li>\r\r\n											<li>Fertilize: help your lawn develop a healthy root system by applying</li>\r\r\n											<li>a seed-starting fertilizer with a fertilizer spreader.</li>\r\r\n											<li>Use a seed spreader: apply after carefully reading the manufacturer’s instructions.</li>\r\r\n											<li>Water: try to keep your soil moist in the weeks after you reseed.</li>\r\r\n										</ul>\r\r\n										<ul class=\"tags-list\">\r\r\n											<li><a href=\"#\">Lawn care</a></li>\r\r\n											<li><a href=\"#\">Pennsylvania</a></li>\r\r\n											<li><a href=\"#\">Moisture</a></li>\r\r\n\r\r\n										</ul>', '', '4', '2017-07-09 14:41:57', '');
INSERT INTO `posts` VALUES ('3', 'Bài viết c', 'bai-viet-c', 'http://res.cloudinary.com/degic-vn/image/upload/v1499497907/new-1_pldzdo.jpg', 'Lorem ipsum dolor sit amet, consectetur adipisi cing elit. Molestias eius illum libero dolor nobis deleniti, sint assumenda Pariatur iste.', '<p><i>If your lawn is looking thin or bare, it might be time to sow it with a layer of grass seed to restore it to its lush, green state. The cool-season grasses of Pennsylvania fare best in the fall when the air is cooling down but the soil is still warm, giving grass a few months to grow before winter comes around. Read on to learn more about why fall is the best time to reseed your lawn.</i></p>\r\r\n										<h4>Why Fall?</h4>\r\r\n										<p>In Pennsylvania, early fall is the best time to sow grass seeds for a number of reasons. Seeding in the fall allows cool-season grasses to establish before winter. Try to sow two months before the first frost of the season. There are fewer active lawn diseases during fall, and weeds tend to taper off, meaning your grass won’t have to compete as much for access to sun and water. Sunlight begins to increase during fall as the tree leaves begin to drop. Moisture is key to growing a healthy lawn of grass, making spring the second-most popular (but less ideal) season for seeding.</p>\r\r\n										<h4>Why Not Spring?</h4>\r\r\n										<p>Though the moisture and warm air are beneficial to grass growth, there are a few things about spring that make it less-than-ideal for reseeding. Weeds are more prevalent in the spring, which causes grass to have to compete for the nutrients it needs to thrive. Spring also means that summer is right around the corner. The summer’s hot temperatures and drought conditions can introduce undesirable stress to your new lawn.</p>\r\r\n										<h4>Remember:</h4>\r\r\n										<ul>\r\r\n											<li>Mow low: this will help grass seeds reach the soil more easily.</li>\r\r\n											<li>Aerate and dethatch: break up soil compaction and remove excessive thatch with a dethatcher.</li>\r\r\n											<li>Fertilize: help your lawn develop a healthy root system by applying</li>\r\r\n											<li>a seed-starting fertilizer with a fertilizer spreader.</li>\r\r\n											<li>Use a seed spreader: apply after carefully reading the manufacturer’s instructions.</li>\r\r\n											<li>Water: try to keep your soil moist in the weeks after you reseed.</li>\r\r\n										</ul>\r\r\n										<ul class=\"tags-list\">\r\r\n											<li><a href=\"#\">Lawn care</a></li>\r\r\n											<li><a href=\"#\">Pennsylvania</a></li>\r\r\n											<li><a href=\"#\">Moisture</a></li>\r\r\n\r\r\n										</ul>', '', '4', '2017-07-09 14:42:29', '');
INSERT INTO `posts` VALUES ('4', 'video-1', 'video-1', 'http://res.cloudinary.com/degic-vn/image/upload/v1499497909/new-2_fqu3cj.jpg', 'Lorem ipsum dolor sit amet, consectetur adipisi cing elit. Molestias eius illum libero dolor nobis deleniti, sint assumenda Pariatur iste.', '<div class=\"post-teaser\">\r\n										<p><i>If your lawn is looking thin or bare, it might be time to sow it with a layer of grass seed to restore it to its lush, green state. The cool-season grasses of Pennsylvania fare best in the fall when the air is cooling down but the soil is still warm, giving grass a few months to grow before winter comes around. Read on to learn more about why fall is the best time to reseed your lawn.</i></p>\r\n										<h4>Why Fall?</h4>\r\n										<p>In Pennsylvania, early fall is the best time to sow grass seeds for a number of reasons. Seeding in the fall allows cool-season grasses to establish before winter. Try to sow two months before the first frost of the season. There are fewer active lawn diseases during fall, and weeds tend to taper off, meaning your grass won’t have to compete as much for access to sun and water. Sunlight begins to increase during fall as the tree leaves begin to drop. Moisture is key to growing a healthy lawn of grass, making spring the second-most popular (but less ideal) season for seeding.</p>\r\n										<h4>Why Not Spring?</h4>\r\n										<p>Though the moisture and warm air are beneficial to grass growth, there are a few things about spring that make it less-than-ideal for reseeding. Weeds are more prevalent in the spring, which causes grass to have to compete for the nutrients it needs to thrive. Spring also means that summer is right around the corner. The summer’s hot temperatures and drought conditions can introduce undesirable stress to your new lawn.</p>\r\n										<h4>Remember:</h4>\r\n										<ul>\r\n											<li>Mow low: this will help grass seeds reach the soil more easily.</li>\r\n											<li>Aerate and dethatch: break up soil compaction and remove excessive thatch with a dethatcher.</li>\r\n											<li>Fertilize: help your lawn develop a healthy root system by applying</li>\r\n											<li>a seed-starting fertilizer with a fertilizer spreader.</li>\r\n											<li>Use a seed spreader: apply after carefully reading the manufacturer’s instructions.</li>\r\n											<li>Water: try to keep your soil moist in the weeks after you reseed.</li>\r\n										</ul>\r\n										<ul class=\"tags-list\">\r\n											<li><a href=\"#\">Lawn care</a></li>\r\n											<li><a href=\"#\">Pennsylvania</a></li>\r\n											<li><a href=\"#\">Moisture</a></li>\r\n\r\n										</ul>\r\n									</div>', '', '7', '2017-07-20 03:29:20', null);
INSERT INTO `posts` VALUES ('5', 'video-b', 'video-b', 'http://res.cloudinary.com/degic-vn/image/upload/v1499497909/new-2_fqu3cj.jpg', 'Lorem ipsum dolor sit amet, consectetur adipisi cing elit. Molestias eius illum libero dolor nobis deleniti, sint assumenda Pariatur iste.', '<div class=\"post-teaser\">\r\n										<p><i>If your lawn is looking thin or bare, it might be time to sow it with a layer of grass seed to restore it to its lush, green state. The cool-season grasses of Pennsylvania fare best in the fall when the air is cooling down but the soil is still warm, giving grass a few months to grow before winter comes around. Read on to learn more about why fall is the best time to reseed your lawn.</i></p>\r\n										<h4>Why Fall?</h4>\r\n										<p>In Pennsylvania, early fall is the best time to sow grass seeds for a number of reasons. Seeding in the fall allows cool-season grasses to establish before winter. Try to sow two months before the first frost of the season. There are fewer active lawn diseases during fall, and weeds tend to taper off, meaning your grass won’t have to compete as much for access to sun and water. Sunlight begins to increase during fall as the tree leaves begin to drop. Moisture is key to growing a healthy lawn of grass, making spring the second-most popular (but less ideal) season for seeding.</p>\r\n										<h4>Why Not Spring?</h4>\r\n										<p>Though the moisture and warm air are beneficial to grass growth, there are a few things about spring that make it less-than-ideal for reseeding. Weeds are more prevalent in the spring, which causes grass to have to compete for the nutrients it needs to thrive. Spring also means that summer is right around the corner. The summer’s hot temperatures and drought conditions can introduce undesirable stress to your new lawn.</p>\r\n										<h4>Remember:</h4>\r\n										<ul>\r\n											<li>Mow low: this will help grass seeds reach the soil more easily.</li>\r\n											<li>Aerate and dethatch: break up soil compaction and remove excessive thatch with a dethatcher.</li>\r\n											<li>Fertilize: help your lawn develop a healthy root system by applying</li>\r\n											<li>a seed-starting fertilizer with a fertilizer spreader.</li>\r\n											<li>Use a seed spreader: apply after carefully reading the manufacturer’s instructions.</li>\r\n											<li>Water: try to keep your soil moist in the weeks after you reseed.</li>\r\n										</ul>\r\n										<ul class=\"tags-list\">\r\n											<li><a href=\"#\">Lawn care</a></li>\r\n											<li><a href=\"#\">Pennsylvania</a></li>\r\n											<li><a href=\"#\">Moisture</a></li>\r\n\r\n										</ul>\r\n									</div>', '', '7', '2017-07-20 03:29:37', null);
INSERT INTO `posts` VALUES ('6', 'video-c', 'video-c', 'http://res.cloudinary.com/degic-vn/image/upload/v1499497909/new-2_fqu3cj.jpg', 'Lorem ipsum dolor sit amet, consectetur adipisi cing elit. Molestias eius illum libero dolor nobis deleniti, sint assumenda Pariatur iste.', '<div class=\"post-teaser\">\r\n										<p><i>If your lawn is looking thin or bare, it might be time to sow it with a layer of grass seed to restore it to its lush, green state. The cool-season grasses of Pennsylvania fare best in the fall when the air is cooling down but the soil is still warm, giving grass a few months to grow before winter comes around. Read on to learn more about why fall is the best time to reseed your lawn.</i></p>\r\n										<h4>Why Fall?</h4>\r\n										<p>In Pennsylvania, early fall is the best time to sow grass seeds for a number of reasons. Seeding in the fall allows cool-season grasses to establish before winter. Try to sow two months before the first frost of the season. There are fewer active lawn diseases during fall, and weeds tend to taper off, meaning your grass won’t have to compete as much for access to sun and water. Sunlight begins to increase during fall as the tree leaves begin to drop. Moisture is key to growing a healthy lawn of grass, making spring the second-most popular (but less ideal) season for seeding.</p>\r\n										<h4>Why Not Spring?</h4>\r\n										<p>Though the moisture and warm air are beneficial to grass growth, there are a few things about spring that make it less-than-ideal for reseeding. Weeds are more prevalent in the spring, which causes grass to have to compete for the nutrients it needs to thrive. Spring also means that summer is right around the corner. The summer’s hot temperatures and drought conditions can introduce undesirable stress to your new lawn.</p>\r\n										<h4>Remember:</h4>\r\n										<ul>\r\n											<li>Mow low: this will help grass seeds reach the soil more easily.</li>\r\n											<li>Aerate and dethatch: break up soil compaction and remove excessive thatch with a dethatcher.</li>\r\n											<li>Fertilize: help your lawn develop a healthy root system by applying</li>\r\n											<li>a seed-starting fertilizer with a fertilizer spreader.</li>\r\n											<li>Use a seed spreader: apply after carefully reading the manufacturer’s instructions.</li>\r\n											<li>Water: try to keep your soil moist in the weeks after you reseed.</li>\r\n										</ul>\r\n										<ul class=\"tags-list\">\r\n											<li><a href=\"#\">Lawn care</a></li>\r\n											<li><a href=\"#\">Pennsylvania</a></li>\r\n											<li><a href=\"#\">Moisture</a></li>\r\n\r\n										</ul>\r\n									</div>', '', '7', '2017-07-20 03:29:46', null);

-- ----------------------------
-- Table structure for services
-- ----------------------------
DROP TABLE IF EXISTS `services`;
CREATE TABLE `services` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` tinytext COLLATE utf8_unicode_ci NOT NULL,
  `Alias` tinytext COLLATE utf8_unicode_ci NOT NULL,
  `Image` tinytext COLLATE utf8_unicode_ci,
  `Status` tinytext COLLATE utf8_unicode_ci NOT NULL,
  `Price` int(11) DEFAULT NULL,
  `ShortDescription` tinytext COLLATE utf8_unicode_ci NOT NULL,
  `Content` longtext COLLATE utf8_unicode_ci,
  `Activated` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of services
-- ----------------------------
INSERT INTO `services` VALUES ('4', 'dịch vụ', 'dich-vu', 'http://res.cloudinary.com/legiatrans-com/image/upload/v1500402163/service-4-bg_xoa7ia.jpg', '', '0', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit', '<p>Snow plowing and removal priorities are based on traffic volume, usage and location within the transportation system. We will design and build a your custom outdoor living area with quality materials and superior installation. In Pennsylvania, early fall is the best time to sow grass seeds for a number of reasons. Seeding in the fall allows cool-season grasses to establish before winter.</p>\r\n<p>Try to sow two months before the first frost of the season. There are fewer active lawn diseases during fall, and weeds tend to taper off, meaning your grass won&rsquo;t have to compete as much for access to sun and water. Sunlight begins to increase during fall as the tree leaves begin to drop. Moisture is key to growing a healthy lawn of grass, making spring the second-most popular (but less ideal) season for seeding.</p>\r\n<p>There are fewer active lawn diseases during fall, and weeds tend to taper off, meaning your grass won&rsquo;t have to compete as much for access to sun and water. Sunlight begins to increase during fall as the tree leaves begin to drop. Moisture is key to growing a healthy lawn of grass, making spring the second-most popular (but less ideal) season for seeding.</p>', '1');
INSERT INTO `services` VALUES ('5', 'Cỏ sân vườn', 'co-san-vuon', 'http://res.cloudinary.com/legiatrans-com/image/upload/v1500402163/service-2-bg_zzrdob.jpg', '', '0', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit', '<p>Snow plowing and removal priorities are based on traffic volume, usage and location within the transportation system. We will design and build a your custom outdoor living area with quality materials and superior installation. In Pennsylvania, early fall is the best time to sow grass seeds for a number of reasons. Seeding in the fall allows cool-season grasses to establish before winter.</p>\r\n<p>Try to sow two months before the first frost of the season. There are fewer active lawn diseases during fall, and weeds tend to taper off, meaning your grass won&rsquo;t have to compete as much for access to sun and water. Sunlight begins to increase during fall as the tree leaves begin to drop. Moisture is key to growing a healthy lawn of grass, making spring the second-most popular (but less ideal) season for seeding.</p>\r\n<p>There are fewer active lawn diseases during fall, and weeds tend to taper off, meaning your grass won&rsquo;t have to compete as much for access to sun and water. Sunlight begins to increase during fall as the tree leaves begin to drop. Moisture is key to growing a healthy lawn of grass, making spring the second-most popular (but less ideal) season for seeding.</p>', '1');
INSERT INTO `services` VALUES ('7', 'Tái tạo vườn', 'tai-tao-vuon', 'http://res.cloudinary.com/legiatrans-com/image/upload/v1500402163/service-6-bg_cixbkt.jpg', '', '0', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit', '<p>Snow plowing and removal priorities are based on traffic volume, usage and location within the transportation system. We will design and build a your custom outdoor living area with quality materials and superior installation. In Pennsylvania, early fall is the best time to sow grass seeds for a number of reasons. Seeding in the fall allows cool-season grasses to establish before winter.</p>\r\n<p>Try to sow two months before the first frost of the season. There are fewer active lawn diseases during fall, and weeds tend to taper off, meaning your grass won&rsquo;t have to compete as much for access to sun and water. Sunlight begins to increase during fall as the tree leaves begin to drop. Moisture is key to growing a healthy lawn of grass, making spring the second-most popular (but less ideal) season for seeding.</p>\r\n<p>There are fewer active lawn diseases during fall, and weeds tend to taper off, meaning your grass won&rsquo;t have to compete as much for access to sun and water. Sunlight begins to increase during fall as the tree leaves begin to drop. Moisture is key to growing a healthy lawn of grass, making spring the second-most popular (but less ideal) season for seeding.</p>', '1');

-- ----------------------------
-- Table structure for slides
-- ----------------------------
DROP TABLE IF EXISTS `slides`;
CREATE TABLE `slides` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` tinytext COLLATE utf8_unicode_ci NOT NULL,
  `Alias` tinytext COLLATE utf8_unicode_ci NOT NULL,
  `Image` tinytext COLLATE utf8_unicode_ci NOT NULL,
  `ButtonViewer` tinyint(1) DEFAULT '0',
  `LinkViewer` tinytext COLLATE utf8_unicode_ci,
  `Activated` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of slides
-- ----------------------------
INSERT INTO `slides` VALUES ('1', 'Cỏ sân nhà phố', 'co-san-nha-pho', 'http://res.cloudinary.com/legiatrans-com/image/upload/v1500378351/slide-1_o1kvsf.jpg', '0', null, '1');
INSERT INTO `slides` VALUES ('2', 'Sân cỏ biệt thự', 'san-co-biet-thu', 'http://res.cloudinary.com/degic-vn/image/upload/v1499587220/slide-2_disfo9.jpg', '0', null, '1');
INSERT INTO `slides` VALUES ('3', 'Cỏ cho sân nhầ', 'co-cho-san-nha', 'http://res.cloudinary.com/legiatrans-com/image/upload/v1500378499/slide-4_myc7ij.jpg', '0', null, '1');

-- ----------------------------
-- Table structure for users
-- ----------------------------
DROP TABLE IF EXISTS `users`;
CREATE TABLE `users` (
  `UserName` varchar(25) COLLATE utf8_unicode_ci NOT NULL,
  `Password` tinytext COLLATE utf8_unicode_ci NOT NULL,
  `FullName` tinytext COLLATE utf8_unicode_ci NOT NULL,
  `Activated` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`UserName`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of users
-- ----------------------------
INSERT INTO `users` VALUES ('dang', 'c4ca4238a0b923820dcc509a6f75849b', 'tan dang', '1');
INSERT INTO `users` VALUES ('dangrom', 'c4ca4238a0b923820dcc509a6f75849b', '1', '1');

-- ----------------------------
-- Procedure structure for changePassword
-- ----------------------------
DROP PROCEDURE IF EXISTS `changePassword`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `changePassword`(IN pUserName VARCHAR(255), IN pPassword TINYTEXT)
BEGIN
    UPDATE Users
      SET Password = pPassword COLLATE utf8_unicode_ci
    WHERE UserName = pUserName COLLATE utf8_unicode_ci;
  END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for deleteCategory
-- ----------------------------
DROP PROCEDURE IF EXISTS `deleteCategory`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `deleteCategory`(
    IN pId INT
  )
BEGIN
    DELETE FROM Category WHERE Id = pId;
  END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for deleteFeedback
-- ----------------------------
DROP PROCEDURE IF EXISTS `deleteFeedback`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `deleteFeedback`(IN pId INT)
BEGIN 
    DELETE FROM Feedbacks WHERE Id = pId;
  END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for deleteImage
-- ----------------------------
DROP PROCEDURE IF EXISTS `deleteImage`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `deleteImage`(IN pId INT)
BEGIN 
    DELETE FROM Images WHERE Id = pId;
  END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for deletePost
-- ----------------------------
DROP PROCEDURE IF EXISTS `deletePost`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `deletePost`(IN pId INT)
BEGIN 
    DELETE FROM Posts WHERE Id = pId;
  END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for deleteService
-- ----------------------------
DROP PROCEDURE IF EXISTS `deleteService`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `deleteService`(IN pId INT)
BEGIN 
    DELETE FROM Services WHERE Id = pId;
  END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for deleteSlide
-- ----------------------------
DROP PROCEDURE IF EXISTS `deleteSlide`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `deleteSlide`(IN pId INT)
BEGIN
    DELETE FROM Slides WHERE Id = pId;
  END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for deleteUser
-- ----------------------------
DROP PROCEDURE IF EXISTS `deleteUser`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `deleteUser`(IN pUserName VARCHAR(25))
BEGIN 
    DELETE FROM Users WHERE UserName = pUserName COLLATE utf8_unicode_ci;
  END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for findCategoryByAlias
-- ----------------------------
DROP PROCEDURE IF EXISTS `findCategoryByAlias`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `findCategoryByAlias`(IN pAlias TINYTEXT)
BEGIN
    DECLARE _find INT;
    SET _find = (SELECT count(Id) FROM Category WHERE Alias = pAlias COLLATE utf8_unicode_ci LIMIT 1);
    IF _find = 0 THEN
      SELECT 0;
    ELSE
      SELECT 1;
    END IF;
  END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for findPostByAlias
-- ----------------------------
DROP PROCEDURE IF EXISTS `findPostByAlias`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `findPostByAlias`(IN pAlias TINYTEXT)
BEGIN
    DECLARE _find INT;
    SET _find = (SELECT count(Id) FROM Posts WHERE Alias = pAlias COLLATE utf8_unicode_ci LIMIT 1);
    if _find = 0 THEN
      SELECT 0;
    ELSE 
      SELECT 1;
    END IF;
  END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for findServiceByAlias
-- ----------------------------
DROP PROCEDURE IF EXISTS `findServiceByAlias`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `findServiceByAlias`(IN pAlias TINYTEXT)
BEGIN
    DECLARE _find INT;
    SET _find = (SELECT COUNT(Id) FROM Services WHERE Alias = pAlias  COLLATE utf8_unicode_ci LIMIT 1 );
    SELECT _find;
  END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for findSlideByAlias
-- ----------------------------
DROP PROCEDURE IF EXISTS `findSlideByAlias`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `findSlideByAlias`(IN pAlias TINYTEXT)
BEGIN
    DECLARE _find INT;
    SET _find = (SELECT COUNT(Id)
                 FROM Slides WHERE Alias = pAlias COLLATE utf8_unicode_ci LIMIT 1);
    IF _find = 0 THEN
      SELECT 0;
    ELSE 
      SELECT 1;
    END IF;
  END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for findUserByUserName
-- ----------------------------
DROP PROCEDURE IF EXISTS `findUserByUserName`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `findUserByUserName`(IN pUserName VARCHAR(25))
BEGIN
    DECLARE _find INT;
    SET _find = (SELECT count(UserName) FROM Users WHERE UserName = pUserName COLLATE utf8_unicode_ci LIMIT 1);
    IF _find = 0 THEN
      SELECT 0;
    ELSE
      SELECT 1;
    END IF;
  END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for getAllCategory
-- ----------------------------
DROP PROCEDURE IF EXISTS `getAllCategory`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getAllCategory`()
BEGIN
    SELECT Id, Name, Activated, Service, Orders, Alias
    FROM Category
    ORDER BY Name, Id;
  END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for getAllCategoryForPost
-- ----------------------------
DROP PROCEDURE IF EXISTS `getAllCategoryForPost`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getAllCategoryForPost`()
BEGIN 
    SELECT Id, Name
    FROM Category
    ORDER BY Name;
  END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for getAllCustomer
-- ----------------------------
DROP PROCEDURE IF EXISTS `getAllCustomer`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getAllCustomer`()
BEGIN 
    SELECT Name, Image
    FROM Images
    WHERE Customer = 1;
  END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for getAllFeedback
-- ----------------------------
DROP PROCEDURE IF EXISTS `getAllFeedback`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getAllFeedback`()
BEGIN 
    SELECT f.Id, f.FullName, c.Name as ServiceName
    FROM Feedbacks f
    INNER JOIN Services c on f.ServiceId = c.Id
    ORDER BY Id;
  END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for getAllFeedbackForHomePage
-- ----------------------------
DROP PROCEDURE IF EXISTS `getAllFeedbackForHomePage`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getAllFeedbackForHomePage`()
BEGIN
    SELECT FullName, Avatar, Content
    FROM Feedbacks;
  END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for getAllGallery
-- ----------------------------
DROP PROCEDURE IF EXISTS `getAllGallery`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getAllGallery`()
BEGIN
    SELECT Name, Image
    FROM Images
    WHERE Gallery = 1;
  END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for getAllImage
-- ----------------------------
DROP PROCEDURE IF EXISTS `getAllImage`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getAllImage`()
BEGIN
    SELECT Id, Name, Gallery, Customer
    FROM Images
    ORDER BY Name;
  END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for getAllPost
-- ----------------------------
DROP PROCEDURE IF EXISTS `getAllPost`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getAllPost`()
BEGIN
    SELECT p.Id, p.Name, p.CategoryId, c.Name AS CategoryName, p.Activated, p.HomePage
    FROM Posts p
    INNER JOIN Category c on p.CategoryId = c.Id
    ORDER BY Name, Id;
  END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for getAllPostByCategoryByAlias
-- ----------------------------
DROP PROCEDURE IF EXISTS `getAllPostByCategoryByAlias`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getAllPostByCategoryByAlias`(IN pAlias TINYTEXT)
BEGIN   
	SELECT p.Name, p.Alias, p.Image, p.ShortDescription
    FROM Posts p
	INNER JOIN Category c on p.CategoryId = c.Id 
	AND p.Activated = 1 
	AND c.Alias = pAlias COLLATE utf8_unicode_ci
	ORDER BY CreateDate DESC;
  END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for getAllPostForMenuLine
-- ----------------------------
DROP PROCEDURE IF EXISTS `getAllPostForMenuLine`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getAllPostForMenuLine`()
BEGIN
    SELECT Name, Alias, CategoryId
    FROM Posts
    WHERE Activated = 1;
  END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for getAllService
-- ----------------------------
DROP PROCEDURE IF EXISTS `getAllService`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getAllService`()
BEGIN 
    SELECT Id, Name, Alias, Image, Status, Price, ShortDescription, Activated, Content
    FROM Services
    ORDER BY Id;
  END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for getAllServiceForFeedback
-- ----------------------------
DROP PROCEDURE IF EXISTS `getAllServiceForFeedback`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getAllServiceForFeedback`()
BEGIN 
    SELECT Id, Name
    FROM Services
    ORDER BY Name;
  END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for getAllServiceForHomePage
-- ----------------------------
DROP PROCEDURE IF EXISTS `getAllServiceForHomePage`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getAllServiceForHomePage`()
BEGIN
    SELECT Id, Name, Alias, Image, Status, Price, ShortDescription
    FROM Services
    WHERE Activated = 1
    LIMIT 6;
  END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for GetAllServiceForList
-- ----------------------------
DROP PROCEDURE IF EXISTS `GetAllServiceForList`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetAllServiceForList`()
BEGIN
	SELECT Name, Alias, Image, ShortDescription
	FROM Services
	WHERE Activated = 1;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for getAllServiceForMenuLine
-- ----------------------------
DROP PROCEDURE IF EXISTS `getAllServiceForMenuLine`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getAllServiceForMenuLine`()
BEGIN 
    SELECT Name, Alias
    FROM Services
    WHERE Activated = 1;
  END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for getAllServiceForServicePage
-- ----------------------------
DROP PROCEDURE IF EXISTS `getAllServiceForServicePage`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getAllServiceForServicePage`()
BEGIN
    SELECT Id, Name, Alias, Image, Status, Price, ShortDescription
    FROM Services
    WHERE Activated = 1
    LIMIT 3;
  END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for getAllSlide
-- ----------------------------
DROP PROCEDURE IF EXISTS `getAllSlide`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getAllSlide`()
BEGIN
    SELECT Id, Name, Alias, Image, ButtonViewer, LinkViewer, Activated
    FROM Slides
    ORDER BY Name;
  END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for getAllSlideForHome
-- ----------------------------
DROP PROCEDURE IF EXISTS `getAllSlideForHome`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getAllSlideForHome`()
BEGIN
    SELECT Name, Alias, Image, ButtonViewer, LinkViewer
    FROM Slides
    WHERE Activated = 1;
  END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for getAllUser
-- ----------------------------
DROP PROCEDURE IF EXISTS `getAllUser`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getAllUser`()
BEGIN 
    SELECT UserName, FullName, Activated
    FROM Users
    ORDER BY UserName;
  END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for getCategoryById
-- ----------------------------
DROP PROCEDURE IF EXISTS `getCategoryById`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getCategoryById`(IN pId INT)
BEGIN 
    SELECT Id, Name, Alias, Image, Activated, Description, Service, Content, Orders
    FROM Category
    WHERE Id = pId
    LIMIT 1;
  END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for getCompany
-- ----------------------------
DROP PROCEDURE IF EXISTS `getCompany`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getCompany`()
BEGIN 
    SELECT Name, Address, Phone, Hotline, Email, TaxCode, Google, Twitter, Facebook, Description, About, Slogan, BusinessHours, Logo, Latitude , Longitude, WhyChooseUs
    FROM Company
    LIMIT 1;
  END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for getCompanyForAbout
-- ----------------------------
DROP PROCEDURE IF EXISTS `getCompanyForAbout`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getCompanyForAbout`()
BEGIN 
    SELECT About, WhyChooseUs
    FROM Company
    LIMIT 1;
  END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for getCompanyForFooter
-- ----------------------------
DROP PROCEDURE IF EXISTS `getCompanyForFooter`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getCompanyForFooter`()
BEGIN
    SELECT Name, Address, Phone, Hotline, Email,Slogan, BusinessHours,Logo, Facebook, Google, Twitter, TaxCode, Latitude , Longitude
    FROM Company
    LIMIT 1;
  END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for getCompanyForHead
-- ----------------------------
DROP PROCEDURE IF EXISTS `getCompanyForHead`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getCompanyForHead`()
BEGIN
    SELECT Slogan, BusinessHours, Logo, Hotline, Facebook, Twitter, Google, Latitude , Longitude
    FROM Company
    LIMIT 1;
  END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for getCompanyForHome
-- ----------------------------
DROP PROCEDURE IF EXISTS `getCompanyForHome`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getCompanyForHome`()
BEGIN 
    SELECT Description, WhyChooseUs
    FROM Company
    LIMIT 1;
  END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for getFeedbackById
-- ----------------------------
DROP PROCEDURE IF EXISTS `getFeedbackById`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getFeedbackById`(IN pId INT)
BEGIN 
    SELECT Id, FullName, Avatar, Content, CreateDate, ServiceId
    FROM Feedbacks
    WHERE Id = pId
    LIMIT 1;
  END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for getImageById
-- ----------------------------
DROP PROCEDURE IF EXISTS `getImageById`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getImageById`(IN pId INT)
BEGIN
    SELECT Id, Name, Image, Gallery, Customer
    FROM Images
    WHERE Id = pId
    LIMIT 1;
  END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for getMenuHead
-- ----------------------------
DROP PROCEDURE IF EXISTS `getMenuHead`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getMenuHead`()
BEGIN
    SELECT Id, Name, Alias, Service, News
    FROM Category
    WHERE Activated = 1
    ORDER BY Orders;
  END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for getNewPostOfCategoryId
-- ----------------------------
DROP PROCEDURE IF EXISTS `getNewPostOfCategoryId`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getNewPostOfCategoryId`(IN `pCategoryId` int)
BEGIN
	SELECT Name, Alias, Image, ShortDescription
	FROM posts
	WHERE CategoryId = pCategoryId AND Activated = 1
	LIMIT 6;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for getPostByAlias
-- ----------------------------
DROP PROCEDURE IF EXISTS `getPostByAlias`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getPostByAlias`(IN pAlias TINYTEXT)
BEGIN
    SELECT Id, Name, Alias, Image, ShortDescription, Activated, Content, CategoryId, HomePage
    FROM Posts
    WHERE Alias = pAlias COLLATE utf8_unicode_ci 
    LIMIT 1;
  END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for getPostById
-- ----------------------------
DROP PROCEDURE IF EXISTS `getPostById`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getPostById`(IN pId INT)
BEGIN
    SELECT Id, Name, Alias, Image, ShortDescription, Activated, Content, CategoryId, HomePage
    FROM Posts
    WHERE Id = pId
    LIMIT 1;
  END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for getPostForFooter
-- ----------------------------
DROP PROCEDURE IF EXISTS `getPostForFooter`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getPostForFooter`()
BEGIN
    SELECT p.Name, p.Alias
    FROM Posts p
    INNER JOIN Category c ON p.CategoryId = c.Id
    AND c.News = 1 AND p.Activated = 1
    LIMIT 3;
  END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for getPostForHome
-- ----------------------------
DROP PROCEDURE IF EXISTS `getPostForHome`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getPostForHome`()
BEGIN
    SELECT p.Name, p.Alias, p.Image, p.ShortDescription, p.CreateDate
    FROM Posts p
    INNER JOIN Category c ON p.CategoryId = c.Id
    WHERE c.News = 1 AND  p.Activated = 1 AND p.HomePage = 1
    ORDER BY CreateDate DESC
    LIMIT 3;
  END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for getServiceByAlias
-- ----------------------------
DROP PROCEDURE IF EXISTS `getServiceByAlias`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getServiceByAlias`(IN pAlias TINYTEXT)
BEGIN
    SELECT Id, Name, Alias, Image, Status, Price, ShortDescription, Activated, Content
    FROM Services
    WHERE Alias = pAlias COLLATE utf8_unicode_ci 
    LIMIT 1;
  END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for getServiceById
-- ----------------------------
DROP PROCEDURE IF EXISTS `getServiceById`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getServiceById`(IN pId INT)
BEGIN
    SELECT Id, Name, Alias, Image, Status, Price, ShortDescription, Activated, Content
    FROM Services
    WHERE Id = pId
    LIMIT 1;
  END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for getServiceForFooter
-- ----------------------------
DROP PROCEDURE IF EXISTS `getServiceForFooter`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getServiceForFooter`()
BEGIN
    SELECT Name, Alias FROM Services WHERE Activated = 1 LIMIT 5;
  END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for getSlideById
-- ----------------------------
DROP PROCEDURE IF EXISTS `getSlideById`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getSlideById`(IN pId INT)
BEGIN
    SELECT Id, Name, Alias, Image, ButtonViewer, LinkViewer, Activated
    FROM Slides
    WHERE  Id = pId
    LIMIT 1;
  END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for getUserByUserName
-- ----------------------------
DROP PROCEDURE IF EXISTS `getUserByUserName`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getUserByUserName`(IN pUserName VARCHAR(25))
BEGIN 
    SELECT UserName, Password, FullName, Activated
    FROM Users
    WHERE UserName = pUserName COLLATE utf8_unicode_ci
    LIMIT 1;
  END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for insertUser
-- ----------------------------
DROP PROCEDURE IF EXISTS `insertUser`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `insertUser`(IN pUserName VARCHAR(25), IN pPassword TINYTEXT, IN pFullName TINYTEXT, IN pActivated BIT)
BEGIN
	INSERT INTO users(UserName, Password, FullName, Activated)
	VALUES (pUserName, pPassword, pFullName, pActivated);
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for login
-- ----------------------------
DROP PROCEDURE IF EXISTS `login`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `login`(IN pUserName VARCHAR(255), IN pPassword TINYTEXT)
BEGIN 
    DECLARE _find INT;
    SET _find = (SELECT count(UserName) FROM Users WHERE UserName = pUserName COLLATE utf8_unicode_ci AND Password = pPassword COLLATE utf8_unicode_ci LIMIT 1);
    IF _find = 0 THEN 
      SELECT 0;
    ELSE 
      SELECT 1;
    END IF;
  END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for updateUser
-- ----------------------------
DROP PROCEDURE IF EXISTS `updateUser`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `updateUser`(IN pUserName VARCHAR(25), IN pPassword TINYTEXT, IN pFullName TINYTEXT, IN pActivated BIT)
BEGIN
    UPDATE Users
      SET Password = pPassword, FullName = pFullName, Activated = pActivated
    WHERE UserName = pUserName COLLATE utf8_unicode_ci;
  END
;;
DELIMITER ;
