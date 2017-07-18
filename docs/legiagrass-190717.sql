/*
 Navicat Premium Data Transfer

 Source Server         : local mysql
 Source Server Type    : MySQL
 Source Server Version : 50718
 Source Host           : localhost:3306
 Source Schema         : legiagrass

 Target Server Type    : MySQL
 Target Server Version : 50718
 File Encoding         : 65001

 Date: 19/07/2017 01:36:47
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for Category
-- ----------------------------
DROP TABLE IF EXISTS `Category`;
CREATE TABLE `Category`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` tinytext CHARACTER SET utf8 COLLATE utf8_unicode_ci,
  `Alias` tinytext CHARACTER SET utf8 COLLATE utf8_unicode_ci,
  `Image` tinytext CHARACTER SET utf8 COLLATE utf8_unicode_ci,
  `Description` tinytext CHARACTER SET utf8 COLLATE utf8_unicode_ci,
  `Activated` bit(1) DEFAULT NULL,
  `Service` bit(1) DEFAULT NULL,
  `Orders` int(11) DEFAULT NULL,
  `Content` longtext CHARACTER SET utf8 COLLATE utf8_unicode_ci,
  `News` bit(1) DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 7 CHARACTER SET = utf8 COLLATE = utf8_unicode_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of Category
-- ----------------------------
INSERT INTO `Category` VALUES (4, 'Bài viết', 'bai-viet', NULL, 'tin tức 123', b'1', b'0', 3, NULL, b'1');
INSERT INTO `Category` VALUES (5, 'Giới thiệu', 'gioi-thieu', NULL, 'giới thiệu', b'1', b'0', 1, NULL, NULL);
INSERT INTO `Category` VALUES (6, 'Liên hệ', 'lien-he', NULL, 'liên hệ', b'1', b'0', 4, NULL, NULL);

-- ----------------------------
-- Table structure for Company
-- ----------------------------
DROP TABLE IF EXISTS `Company`;
CREATE TABLE `Company`  (
  `Name` tinytext CHARACTER SET utf8 COLLATE utf8_unicode_ci,
  `Address` tinytext CHARACTER SET utf8 COLLATE utf8_unicode_ci,
  `Phone` tinytext CHARACTER SET utf8 COLLATE utf8_unicode_ci,
  `Hotline` tinytext CHARACTER SET utf8 COLLATE utf8_unicode_ci,
  `Email` tinytext CHARACTER SET utf8 COLLATE utf8_unicode_ci,
  `TaxCode` tinytext CHARACTER SET utf8 COLLATE utf8_unicode_ci,
  `Facebook` tinytext CHARACTER SET utf8 COLLATE utf8_unicode_ci,
  `Google` tinytext CHARACTER SET utf8 COLLATE utf8_unicode_ci,
  `Twitter` tinytext CHARACTER SET utf8 COLLATE utf8_unicode_ci,
  `Description` text CHARACTER SET utf8 COLLATE utf8_unicode_ci,
  `About` longtext CHARACTER SET utf8 COLLATE utf8_unicode_ci,
  `Slogan` text CHARACTER SET utf8 COLLATE utf8_unicode_ci,
  `BusinessHours` text CHARACTER SET utf8 COLLATE utf8_unicode_ci,
  `Logo` text CHARACTER SET utf8 COLLATE utf8_unicode_ci,
  `WhyChooseUs` text CHARACTER SET utf8 COLLATE utf8_unicode_ci
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_unicode_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of Company
-- ----------------------------
INSERT INTO `Company` VALUES ('Công Ty Lê Gia', 'Đà Nẵng', 'not yet', '911', 'legiagrass@gmail.com', 'not yet', 'chưa tạo facebook', 'chưa tạo google', 'chưa tạo Twitter', '<h2 class=\"text-center lined\">About Us</h2>\r\n<p class=\"text-center info-text\">Starting out with just a single truck and mower, we have expanded our services and grown into one of the largest lawn maintenance companies in our area. Our expansion and stellar reputation is due, in part, to our exceptional reputation for quality and timely service. Our lawn care technicians utilize the latest technology and techniques to deliver beautiful results that will stand the test of time.</p>\r\n<div class=\"row\">\r\n<div class=\"col-sm-6 animation\" data-animation=\"fadeInLeft\" data-animation-delay=\"0.5s\">\r\n<div class=\"text-icon__title\">Our Mission</div>\r\n<div class=\"text-icon last\">\r\n<div class=\"text-icon__icon\">&nbsp;</div>\r\n<div class=\"text-icon__info\">\r\n<p>Our mission is to provide our customers with the highest level of quality services. We pledge to establish lasting relationships with our clients by exceeding their expectations and gaining their trust through exceptional performance.</p>\r\n</div>\r\n</div>\r\n</div>\r\n<div class=\"col-sm-6 animation\" data-animation=\"fadeInRight\" data-animation-delay=\"0.5s\">\r\n<div class=\"text-icon__title\">Our Clients</div>\r\n<div class=\"text-icon last\">\r\n<div class=\"text-icon__icon\">&nbsp;</div>\r\n<div class=\"text-icon__info\">\r\n<p>Our clients count on our dependability, our drive, and our integrity and we take great pride in our accomplishments and build on them every day.</p>\r\n</div>\r\n</div>\r\n</div>\r\n</div>', '<section class=\"content content--fill content--fill--light top-null\">\r\n<div class=\"container\">\r\n<h1 class=\"text-center lined\">About Us</h1>\r\n<p class=\"text-center info-text\">Starting out with just a single truck and mower, we have expanded our services and grown into one of the largest lawn maintenance companies in our area. Our expansion and stellar reputation is due, in part, to our exceptional reputation for quality and timely service. Our lawn care technicians utilize the latest technology and techniques to deliver beautiful results that will stand the test of time.</p>\r\n<div class=\"divider divider--sm\">&nbsp;</div>\r\n<div class=\"animation\" data-animation=\"fadeIn\"><img class=\"img-responsive\" src=\"images/img-about-4.jpg\" alt=\"\" /></div>\r\n<div class=\"divider divider--md\">&nbsp;</div>\r\n<div class=\"row\">\r\n<div class=\"col-sm-6 animation\" data-animation=\"fadeInLeft\" data-animation-delay=\"0.5s\">\r\n<div class=\"text-icon__title\">Our Mission</div>\r\n<div class=\"text-icon last\">\r\n<div class=\"text-icon__icon\">&nbsp;</div>\r\n<div class=\"text-icon__info\">\r\n<p>Our mission is to provide our customers with the highest level of quality services. We pledge to establish lasting relationships with our clients by exceeding their expectations and gaining their trust through exceptional performance.</p>\r\n</div>\r\n</div>\r\n</div>\r\n<div class=\"col-sm-6 animation\" data-animation=\"fadeInRight\" data-animation-delay=\"0.5s\">\r\n<div class=\"text-icon__title\">Our Clients</div>\r\n<div class=\"text-icon last\">\r\n<div class=\"text-icon__icon\">&nbsp;</div>\r\n<div class=\"text-icon__info\">\r\n<p>Our clients count on our dependability, our drive, and our integrity and we take great pride in our accomplishments and build on them every day.</p>\r\n</div>\r\n</div>\r\n</div>\r\n</div>\r\n<div class=\"divider divider--md\">&nbsp;</div>\r\n<h2 class=\"text-center lined\">Our Advantages</h2>\r\n<div class=\"advantages-block\">\r\n<div class=\"row\">\r\n<div class=\"col-sm-4\">Affordable Pricing</div>\r\n<div class=\"col-sm-4\">Fast Online Ordering</div>\r\n<div class=\"col-sm-4\">Satisfaction Guaranteed</div>\r\n</div>\r\n</div>\r\n<div class=\"row\">\r\n<div class=\"col-sm-4\"><img class=\"img-responsive\" src=\"images/img-about-1.jpg\" alt=\"\" /></div>\r\n<div class=\"divider divider--xs visible-xs\">&nbsp;</div>\r\n<div class=\"col-sm-4\"><img class=\"img-responsive\" src=\"images/img-about-2.jpg\" alt=\"\" /></div>\r\n<div class=\"divider divider--xs visible-xs\">&nbsp;</div>\r\n<div class=\"col-sm-4\"><img class=\"img-responsive\" src=\"images/img-about-3.jpg\" alt=\"\" /></div>\r\n</div>\r\n<div class=\"divider divider--md\">&nbsp;</div>\r\n<div class=\"text-center\">\r\n<p>We are a full service landscape maintenance company who commit to fulfilling all your landscape and lawn related needs. Our team of experts have over 28 years of experience in the landscape industry, which helps us develop and deliver custom made programs and solutions for you and your lawn. Through constant communication between our lawn care, landscape maintenance, and irrigation managers, we are able to provide you with a solution for any landscape. Our maintenance team completes a full property analysis during each visit and resolves any landscape related issues immediately to ensure your lawn is at its healthiest and looks its best. Lawn Care provides professional and quality landscaping services for both residential and commercial properties. From start to finish, we offer a wide range of lawn care services to accommodate your needs every step along the way.</p>\r\n<p>We take pride in providing customers satisfaction that is second-to-none. Our team of professionals is fully licensed, insured, and well trained to provide you with consistent and high-quality value and services.</p>\r\n</div>\r\n<div class=\"divider divider--md\">&nbsp;</div>\r\n<h2 class=\"text-center lined\">Lawn Care Team</h2>\r\n<div class=\"row\">\r\n<div class=\"col-sm-6 col-md-3\">\r\n<div class=\"person animation\" data-animation=\"fadeInLeft\" data-animation-delay=\"0.3s\">\r\n<div class=\"person__image\"><img class=\"img-responsive\" src=\"images/person-01.jpg\" alt=\"\" /></div>\r\n<div class=\"person__title\">Mark Ronson</div>\r\n<div class=\"person__position\">Customer Service Manager</div>\r\n<div class=\"person__text\">\r\n<p>He joined our team 3 years ago and we are excited to have him as our lead technician</p>\r\n</div>\r\n</div>\r\n</div>\r\n<div class=\"col-sm-6 col-md-3\">\r\n<div class=\"person animation\" data-animation=\"fadeInLeft\" data-animation-delay=\"0s\">\r\n<div class=\"person__image\"><img class=\"img-responsive\" src=\"images/person-02.jpg\" alt=\"\" /></div>\r\n<div class=\"person__title\">Christopher Stoudt</div>\r\n<div class=\"person__position\">Fertilizer Technician</div>\r\n<div class=\"person__text\">\r\n<p>Over 6 years of experience in the lawn care industry and an interest in organic solutions</p>\r\n</div>\r\n</div>\r\n</div>\r\n<div class=\"col-sm-6 col-md-3\">\r\n<div class=\"person animation\" data-animation=\"fadeInRight\" data-animation-delay=\"0s\">\r\n<div class=\"person__image\"><img class=\"img-responsive\" src=\"images/person-03.jpg\" alt=\"\" /></div>\r\n<div class=\"person__title\">Joe Saboe</div>\r\n<div class=\"person__position\">Technician</div>\r\n<div class=\"person__text\">\r\n<p>He has worked as a certified technician for the past 7 years</p>\r\n</div>\r\n</div>\r\n</div>\r\n<div class=\"col-sm-6 col-md-3\">\r\n<div class=\"person animation last\" data-animation=\"fadeInRight\" data-animation-delay=\"0.3s\">\r\n<div class=\"person__image\"><img class=\"img-responsive\" src=\"images/person-04.jpg\" alt=\"\" /></div>\r\n<div class=\"person__title\">Alisa Madden</div>\r\n<div class=\"person__position\">Administrative Assistant</div>\r\n<div class=\"person__text\">\r\n<p>She is always available for customer\'s needs and answers the phone with a smile</p>\r\n</div>\r\n</div>\r\n</div>\r\n</div>\r\n<div class=\"divider divider--md\">&nbsp;</div>\r\n<div class=\"text-center\"><a class=\"btn btn--wd\">MEET ALL TEAM</a></div>\r\n</div>\r\n</section>', 'slogan', '7 DAYS A WEEK FROM 9:00 AM TO 7:00 PM', NULL, '<section class=\"content content--fill content--fill--light top-null\">\r\n<div class=\"container\">\r\n<div class=\"row\">\r\n<div class=\"col-md-8 animated\" style=\"animation-delay: 0.6s;\" data-animation=\"fadeIn\" data-animation-delay=\"0.6s\">\r\n<h2 class=\"text-center lined\">Video Presentation</h2>\r\n<div class=\"video-responsive\"><iframe src=\"http://www.youtube.com/embed/-PWxUQCNGtg?wmode=opaque\" width=\"300\" height=\"150\" allowfullscreen=\"allowfullscreen\"></iframe></div>\r\n</div>\r\n<div class=\"divider divider--md visible-sm visible-xs\">&nbsp;</div>\r\n<div class=\"col-md-4 animated\" style=\"animation-delay: 0.9s;\" data-animation=\"fadeIn\" data-animation-delay=\"0.9s\">\r\n<h2 class=\"text-center lined\">Why Choose Us?</h2>\r\n<p>The single biggest difference between Lawn Care and other lawn care providers boils down to one simple premise: we care more. It&rsquo;s the kind of caring that can only come from being the business owner. One that lives, works, and is a part of the community they serve.</p>\r\n<ul class=\"marker-list-sm\">\r\n<li>We have the highest customer retention rate in the industry.</li>\r\n<li>We have 50 years of experience.</li>\r\n<li>We have the highest TrustPilot score in the industry.</li>\r\n<li>We&rsquo;re locally owned, so there&rsquo;s no big business &ldquo;run-around&rdquo;.</li>\r\n<li>We offer the best guarantee in the business: If you&rsquo;re not 100% satisfied &ndash; we&rsquo;ll make it right. It&rsquo;s that simple.</li>\r\n</ul>\r\n</div>\r\n</div>\r\n</div>\r\n</section>');

-- ----------------------------
-- Table structure for Feedbacks
-- ----------------------------
DROP TABLE IF EXISTS `Feedbacks`;
CREATE TABLE `Feedbacks`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FullName` tinytext CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `Avatar` tinytext CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `Content` text CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `CreateDate` datetime(0) NOT NULL,
  `ServiceId` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `ServiceId`(`ServiceId`) USING BTREE,
  CONSTRAINT `Feedbacks_ibfk_1` FOREIGN KEY (`ServiceId`) REFERENCES `Services` (`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 4 CHARACTER SET = utf8 COLLATE = utf8_unicode_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of Feedbacks
-- ----------------------------
INSERT INTO `Feedbacks` VALUES (1, 'Hs A', 'http://res.cloudinary.com/degic-vn/image/upload/v1499497904/avatar-3_apebsz.jpg', '<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Quas vel sint, ut. Quisquam doloremque minus possimus eligendi dolore ad.</p>', '2017-07-09 00:42:46', 7);
INSERT INTO `Feedbacks` VALUES (2, 'Hs B', 'http://res.cloudinary.com/degic-vn/image/upload/v1499497904/avatar-2_vp24ev.jpg', '<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Quas vel sint, ut. Quisquam doloremque minus possimus eligendi dolore ad.</p>', '2017-07-09 00:43:18', 5);
INSERT INTO `Feedbacks` VALUES (3, 'Hs C', 'http://res.cloudinary.com/degic-vn/image/upload/v1499497903/avatar-1_u2zaq0.jpg', '<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Quas vel sint, ut. Quisquam doloremque minus possimus eligendi dolore ad.</p>', '2017-07-09 00:43:45', 4);

-- ----------------------------
-- Table structure for Images
-- ----------------------------
DROP TABLE IF EXISTS `Images`;
CREATE TABLE `Images`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` tinytext CHARACTER SET utf8 COLLATE utf8_general_ci,
  `Image` text CHARACTER SET utf8 COLLATE utf8_general_ci,
  `Customer` bit(1) DEFAULT NULL,
  `Gallery` bit(1) DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 27 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of Images
-- ----------------------------
INSERT INTO `Images` VALUES (4, 'Dã ngoại', 'http://res.cloudinary.com/degic-vn/image/upload/v1499497910/new-3_ltij75.jpg', b'0', b'1');
INSERT INTO `Images` VALUES (5, 'Dã ngoại', 'http://res.cloudinary.com/degic-vn/image/upload/v1499497905/g-4_pwujal.jpg', NULL, b'1');
INSERT INTO `Images` VALUES (6, 'Trên lớp', 'http://res.cloudinary.com/degic-vn/image/upload/v1499497905/g-4_pwujal.jpg', NULL, b'1');
INSERT INTO `Images` VALUES (7, 'Trên lớp', 'http://res.cloudinary.com/degic-vn/image/upload/v1499497906/g-1_ivatwc.jpg', NULL, b'1');
INSERT INTO `Images` VALUES (8, 'Trên lớp', 'http://res.cloudinary.com/degic-vn/image/upload/v1499497906/g-2_van5dp.jpg', NULL, b'1');
INSERT INTO `Images` VALUES (9, 'Trên lớp', 'http://res.cloudinary.com/degic-vn/image/upload/v1499497906/g-7_qbx23s.jpg', NULL, b'1');
INSERT INTO `Images` VALUES (10, 'Trên lớp', 'http://res.cloudinary.com/degic-vn/image/upload/v1499497907/g-10_ioknfe.jpg', NULL, b'1');
INSERT INTO `Images` VALUES (11, 'Trên lớp', 'http://res.cloudinary.com/degic-vn/image/upload/v1499497907/g-12_mk1ltm.jpg', NULL, b'1');
INSERT INTO `Images` VALUES (12, 'Trên lớp', 'http://res.cloudinary.com/degic-vn/image/upload/v1499497907/g-5_ydasts.jpg', NULL, b'1');
INSERT INTO `Images` VALUES (13, 'Dã ngoại', 'http://res.cloudinary.com/degic-vn/image/upload/v1499497908/g-3_kjt3xo.jpg', NULL, b'1');
INSERT INTO `Images` VALUES (14, 'Dã ngoại', 'http://res.cloudinary.com/degic-vn/image/upload/v1499497908/g-6_omrhrv.jpg', NULL, b'1');
INSERT INTO `Images` VALUES (15, 'Dã ngoại', 'http://res.cloudinary.com/degic-vn/image/upload/v1499497909/g-8_mc9nxr.jpg', NULL, b'1');
INSERT INTO `Images` VALUES (16, 'Dã ngoại', 'http://res.cloudinary.com/degic-vn/image/upload/v1499497909/g-9_h1vc2j.jpg', NULL, b'1');
INSERT INTO `Images` VALUES (17, 'Dã ngoại', 'http://res.cloudinary.com/degic-vn/image/upload/v1499497911/g-11_qoefzf.jpg', NULL, b'1');
INSERT INTO `Images` VALUES (18, 'kh1', 'http://res.cloudinary.com/degic-vn/image/upload/v1499540635/c-9_xirm2i.png', b'1', NULL);
INSERT INTO `Images` VALUES (19, 'kh2', 'http://res.cloudinary.com/degic-vn/image/upload/v1499540636/c-8_gxibqw.png', b'1', NULL);
INSERT INTO `Images` VALUES (20, 'kh3', 'http://res.cloudinary.com/degic-vn/image/upload/v1499540635/c-7_i2ah1b.png', b'1', NULL);
INSERT INTO `Images` VALUES (21, 'kh4', 'http://res.cloudinary.com/degic-vn/image/upload/v1499540635/c-5_m3wcgs.png', b'1', NULL);
INSERT INTO `Images` VALUES (22, 'kh5', 'http://res.cloudinary.com/degic-vn/image/upload/v1499540635/c-4_aak0ar.png', b'1', NULL);
INSERT INTO `Images` VALUES (23, 'kh6', 'http://res.cloudinary.com/degic-vn/image/upload/v1499540635/c-3_zinkvl.png', b'1', NULL);
INSERT INTO `Images` VALUES (24, 'kh7', 'http://res.cloudinary.com/degic-vn/image/upload/v1499540635/c-2_hmh57i.png', b'1', NULL);
INSERT INTO `Images` VALUES (25, 'kh8', 'http://res.cloudinary.com/degic-vn/image/upload/v1499540635/c-2_hmh57i.png', b'1', NULL);
INSERT INTO `Images` VALUES (26, 'kh9', 'http://res.cloudinary.com/degic-vn/image/upload/v1499540635/c-1_d2mn8y.png', b'1', NULL);

-- ----------------------------
-- Table structure for Posts
-- ----------------------------
DROP TABLE IF EXISTS `Posts`;
CREATE TABLE `Posts`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` tinytext CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `Alias` tinytext CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `Image` tinytext CHARACTER SET utf8 COLLATE utf8_unicode_ci,
  `ShortDescription` tinytext CHARACTER SET utf8 COLLATE utf8_unicode_ci,
  `Content` longtext CHARACTER SET utf8 COLLATE utf8_unicode_ci,
  `Activated` tinyint(1) DEFAULT NULL,
  `CategoryId` int(11) DEFAULT NULL,
  `CreateDate` datetime(0) NOT NULL,
  `HomePage` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `CategoryId`(`CategoryId`) USING BTREE,
  CONSTRAINT `Posts_ibfk_1` FOREIGN KEY (`CategoryId`) REFERENCES `Category` (`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 4 CHARACTER SET = utf8 COLLATE = utf8_unicode_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of Posts
-- ----------------------------
INSERT INTO `Posts` VALUES (1, 'Bài viết a', 'bai-viet-a', 'http://res.cloudinary.com/degic-vn/image/upload/v1499497909/new-2_fqu3cj.jpg', 'Lorem ipsum dolor sit amet, consectetur adipisi cing elit. Molestias eius illum libero dolor nobis deleniti, sint assumenda Pariatur iste.', '<p>sdsd</p>', 1, 4, '0001-01-01 00:00:00', 1);
INSERT INTO `Posts` VALUES (2, 'Bài viết b', 'bai-viet-b', 'http://res.cloudinary.com/degic-vn/image/upload/v1499497910/new-3_ltij75.jpg', 'Lorem ipsum dolor sit amet, consectetur adipisi cing elit. Molestias eius illum libero dolor nobis deleniti, sint assumenda Pariatur iste.', NULL, 1, 4, '2017-07-09 14:41:57', 1);
INSERT INTO `Posts` VALUES (3, 'Bài viết c', 'bai-viet-c', 'http://res.cloudinary.com/degic-vn/image/upload/v1499497907/new-1_pldzdo.jpg', 'Lorem ipsum dolor sit amet, consectetur adipisi cing elit. Molestias eius illum libero dolor nobis deleniti, sint assumenda Pariatur iste.', NULL, 1, 4, '2017-07-09 14:42:29', 1);

-- ----------------------------
-- Table structure for Services
-- ----------------------------
DROP TABLE IF EXISTS `Services`;
CREATE TABLE `Services`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` tinytext CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `Alias` tinytext CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `Image` tinytext CHARACTER SET utf8 COLLATE utf8_unicode_ci,
  `Status` tinytext CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `Price` int(11) DEFAULT NULL,
  `ShortDescription` tinytext CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `Content` longtext CHARACTER SET utf8 COLLATE utf8_unicode_ci,
  `Activated` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 8 CHARACTER SET = utf8 COLLATE = utf8_unicode_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of Services
-- ----------------------------
INSERT INTO `Services` VALUES (4, 'Thiết kế sân cỏ', 'thiet-ke-san-co', 'http://res.cloudinary.com/legiatrans-com/image/upload/v1500402163/service-6-bg_cixbkt.jpg', 'comming soon', 650000, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam aliquam ipsum quis ipsum facilisis sit amet.', NULL, 1);
INSERT INTO `Services` VALUES (5, 'Lắt đặt cỏ', 'lat-dat-co', 'http://res.cloudinary.com/legiatrans-com/image/upload/v1500402163/service-4-bg_xoa7ia.jpg', '', 0, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam aliquam ipsum quis ipsum facilisis sit amet.', NULL, 1);
INSERT INTO `Services` VALUES (7, 'Chăm sóc - bảo trì', 'cham-soc-bao-tri', 'http://res.cloudinary.com/legiatrans-com/image/upload/v1500402163/service-2-bg_zzrdob.jpg', '', 0, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam aliquam ipsum quis ipsum facilisis sit amet.', NULL, 1);

-- ----------------------------
-- Table structure for Slides
-- ----------------------------
DROP TABLE IF EXISTS `Slides`;
CREATE TABLE `Slides`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` tinytext CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `Alias` tinytext CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `Image` tinytext CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `ButtonViewer` tinyint(1) DEFAULT NULL,
  `LinkViewer` tinytext CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `Activated` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 4 CHARACTER SET = utf8 COLLATE = utf8_unicode_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of Slides
-- ----------------------------
INSERT INTO `Slides` VALUES (1, 'Sân cỏ vườn nhà', 'san-co-vuon-nha', 'http://res.cloudinary.com/legiatrans-com/image/upload/v1500378500/slide-1_b0oizg.jpg', 1, 'copy link toi post', 1);
INSERT INTO `Slides` VALUES (2, 'Sân cỏ vườn - biệt thự', 'san-co-vuon-biet-thu', 'http://res.cloudinary.com/legiatrans-com/image/upload/v1500378500/slide-2_vl1ixo.jpg', 0, 'copy link toi post', 1);
INSERT INTO `Slides` VALUES (3, 'Sân cỏ trước nhà', 'san-co-truoc-nha', 'http://res.cloudinary.com/legiatrans-com/image/upload/v1500378350/slide-4_pzxnff.jpg', 1, 'copy link toi post', 1);

-- ----------------------------
-- Table structure for Users
-- ----------------------------
DROP TABLE IF EXISTS `Users`;
CREATE TABLE `Users`  (
  `UserName` varchar(25) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `Password` tinytext CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `FullName` tinytext CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `Activated` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`UserName`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_unicode_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of Users
-- ----------------------------
INSERT INTO `Users` VALUES ('dang', 'c4ca4238a0b923820dcc509a6f75849b', 'tan dang', 1);

-- ----------------------------
-- Procedure structure for changePassword
-- ----------------------------
DROP PROCEDURE IF EXISTS `changePassword`;
delimiter ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `changePassword`(IN pUserName VARCHAR(255), IN pPassword TINYTEXT)
BEGIN
    UPDATE Users
      SET Password = pPassword COLLATE utf8_unicode_ci
    WHERE UserName = pUserName COLLATE utf8_unicode_ci;
  END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for deleteCategory
-- ----------------------------
DROP PROCEDURE IF EXISTS `deleteCategory`;
delimiter ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `deleteCategory`(
    IN pId INT
  )
BEGIN
    DELETE FROM Category WHERE Id = pId;
  END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for deleteFeedback
-- ----------------------------
DROP PROCEDURE IF EXISTS `deleteFeedback`;
delimiter ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `deleteFeedback`(IN pId INT)
BEGIN 
    DELETE FROM Feedbacks WHERE Id = pId;
  END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for deleteImage
-- ----------------------------
DROP PROCEDURE IF EXISTS `deleteImage`;
delimiter ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `deleteImage`(IN pId INT)
BEGIN 
    DELETE FROM Images WHERE Id = pId;
  END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for deletePost
-- ----------------------------
DROP PROCEDURE IF EXISTS `deletePost`;
delimiter ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `deletePost`(IN pId INT)
BEGIN 
    DELETE FROM Posts WHERE Id = pId;
  END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for deleteService
-- ----------------------------
DROP PROCEDURE IF EXISTS `deleteService`;
delimiter ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `deleteService`(IN pId INT)
BEGIN 
    DELETE FROM Services WHERE Id = pId;
  END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for deleteSlide
-- ----------------------------
DROP PROCEDURE IF EXISTS `deleteSlide`;
delimiter ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `deleteSlide`(IN pId INT)
BEGIN
    DELETE FROM Slides WHERE Id = pId;
  END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for deleteUser
-- ----------------------------
DROP PROCEDURE IF EXISTS `deleteUser`;
delimiter ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `deleteUser`(IN pUserName VARCHAR(25))
BEGIN 
    DELETE FROM Users WHERE UserName = pUserName COLLATE utf8_unicode_ci;
  END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for findCategoryByAlias
-- ----------------------------
DROP PROCEDURE IF EXISTS `findCategoryByAlias`;
delimiter ;;
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
delimiter ;

-- ----------------------------
-- Procedure structure for findPostByAlias
-- ----------------------------
DROP PROCEDURE IF EXISTS `findPostByAlias`;
delimiter ;;
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
delimiter ;

-- ----------------------------
-- Procedure structure for findServiceByAlias
-- ----------------------------
DROP PROCEDURE IF EXISTS `findServiceByAlias`;
delimiter ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `findServiceByAlias`(IN pAlias TINYTEXT)
BEGIN
    DECLARE _find INT;
    SET _find = (SELECT COUNT(Id) FROM Services WHERE Alias = pAlias  COLLATE utf8_unicode_ci LIMIT 1 );
    SELECT _find;
  END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for findSlideByAlias
-- ----------------------------
DROP PROCEDURE IF EXISTS `findSlideByAlias`;
delimiter ;;
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
delimiter ;

-- ----------------------------
-- Procedure structure for findUserByUserName
-- ----------------------------
DROP PROCEDURE IF EXISTS `findUserByUserName`;
delimiter ;;
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
delimiter ;

-- ----------------------------
-- Procedure structure for getAllCategory
-- ----------------------------
DROP PROCEDURE IF EXISTS `getAllCategory`;
delimiter ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getAllCategory`()
BEGIN
    SELECT Id, Name, Activated, Service, Orders, Alias
    FROM Category
    ORDER BY Name, Id;
  END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for getAllCategoryForPost
-- ----------------------------
DROP PROCEDURE IF EXISTS `getAllCategoryForPost`;
delimiter ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getAllCategoryForPost`()
BEGIN 
    SELECT Id, Name
    FROM Category
    ORDER BY Name;
  END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for getAllCustomer
-- ----------------------------
DROP PROCEDURE IF EXISTS `getAllCustomer`;
delimiter ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getAllCustomer`()
BEGIN 
    SELECT Name, Image
    FROM Images
    WHERE Customer = 1;
  END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for getAllFeedback
-- ----------------------------
DROP PROCEDURE IF EXISTS `getAllFeedback`;
delimiter ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getAllFeedback`()
BEGIN 
    SELECT f.Id, f.FullName, c.Name as ServiceName
    FROM Feedbacks f
    INNER JOIN Services c on f.ServiceId = c.Id
    ORDER BY Id;
  END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for getAllFeedbackForHomePage
-- ----------------------------
DROP PROCEDURE IF EXISTS `getAllFeedbackForHomePage`;
delimiter ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getAllFeedbackForHomePage`()
BEGIN
    SELECT FullName, Avatar, Content
    FROM Feedbacks;
  END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for getAllGallery
-- ----------------------------
DROP PROCEDURE IF EXISTS `getAllGallery`;
delimiter ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getAllGallery`()
BEGIN
    SELECT Name, Image
    FROM Images
    WHERE Gallery = 1;
  END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for getAllImage
-- ----------------------------
DROP PROCEDURE IF EXISTS `getAllImage`;
delimiter ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getAllImage`()
BEGIN
    SELECT Id, Name, Gallery, Customer
    FROM Images
    ORDER BY Name;
  END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for getAllPost
-- ----------------------------
DROP PROCEDURE IF EXISTS `getAllPost`;
delimiter ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getAllPost`()
BEGIN
    SELECT p.Id, p.Name, p.CategoryId, c.Name AS CategoryName, p.Activated, p.HomePage
    FROM Posts p
    INNER JOIN Category c on p.CategoryId = c.Id
    ORDER BY Name, Id;
  END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for getAllPostByCategoryByAlias
-- ----------------------------
DROP PROCEDURE IF EXISTS `getAllPostByCategoryByAlias`;
delimiter ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getAllPostByCategoryByAlias`(IN pAlias TINYTEXT)
BEGIN   
	SELECT p.Id, p.Name, p.Alias, p.Image, p.ShortDescription, p.Activated, p.Content, p.CategoryId, p.HomePage
    FROM Posts p
	INNER JOIN Category c on p.CategoryId = c.Id 
	AND p.Activated = 1 
	AND c.Alias = pAlias COLLATE utf8_unicode_ci
	ORDER BY CreateDate DESC;
  END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for getAllPostForMenuLine
-- ----------------------------
DROP PROCEDURE IF EXISTS `getAllPostForMenuLine`;
delimiter ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getAllPostForMenuLine`()
BEGIN
    SELECT Name, Alias, CategoryId
    FROM Posts
    WHERE Activated = 1;
  END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for getAllService
-- ----------------------------
DROP PROCEDURE IF EXISTS `getAllService`;
delimiter ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getAllService`()
BEGIN 
    SELECT Id, Name, Alias, Image, Status, Price, ShortDescription, Activated, Content
    FROM Services
    ORDER BY Id;
  END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for getAllServiceForFeedback
-- ----------------------------
DROP PROCEDURE IF EXISTS `getAllServiceForFeedback`;
delimiter ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getAllServiceForFeedback`()
BEGIN 
    SELECT Id, Name
    FROM Services
    ORDER BY Name;
  END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for getAllServiceForHomePage
-- ----------------------------
DROP PROCEDURE IF EXISTS `getAllServiceForHomePage`;
delimiter ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getAllServiceForHomePage`()
BEGIN
    SELECT Id, Name, Alias, Image, Status, Price, ShortDescription
    FROM Services
    WHERE Activated = 1
    LIMIT 6;
  END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for getAllServiceForMenuLine
-- ----------------------------
DROP PROCEDURE IF EXISTS `getAllServiceForMenuLine`;
delimiter ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getAllServiceForMenuLine`()
BEGIN 
    SELECT Name, Alias
    FROM Services
    WHERE Activated = 1;
  END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for getAllServiceForServicePage
-- ----------------------------
DROP PROCEDURE IF EXISTS `getAllServiceForServicePage`;
delimiter ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getAllServiceForServicePage`()
BEGIN
    SELECT Id, Name, Alias, Image, Status, Price, ShortDescription
    FROM Services
    WHERE Activated = 1
    LIMIT 3;
  END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for getAllSlide
-- ----------------------------
DROP PROCEDURE IF EXISTS `getAllSlide`;
delimiter ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getAllSlide`()
BEGIN
    SELECT Id, Name, Alias, Image, ButtonViewer, LinkViewer, Activated
    FROM Slides
    ORDER BY Name;
  END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for getAllSlideForHome
-- ----------------------------
DROP PROCEDURE IF EXISTS `getAllSlideForHome`;
delimiter ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getAllSlideForHome`()
BEGIN
    SELECT Name, Alias, Image, ButtonViewer, LinkViewer
    FROM Slides
    WHERE Activated = 1;
  END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for getAllUser
-- ----------------------------
DROP PROCEDURE IF EXISTS `getAllUser`;
delimiter ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getAllUser`()
BEGIN 
    SELECT UserName, FullName, Activated
    FROM Users
    ORDER BY UserName;
  END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for getCategoryById
-- ----------------------------
DROP PROCEDURE IF EXISTS `getCategoryById`;
delimiter ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getCategoryById`(IN pId INT)
BEGIN 
    SELECT Id, Name, Alias, Image, Activated, Description, Service, Content, Orders
    FROM Category
    WHERE Id = pId
    LIMIT 1;
  END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for getCompany
-- ----------------------------
DROP PROCEDURE IF EXISTS `getCompany`;
delimiter ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getCompany`()
BEGIN 
    SELECT Name, Address, Phone, Hotline, Email, TaxCode, Google, Twitter, Facebook, Description, WhyChooseUs, About, Slogan, BusinessHours, Logo
    FROM Company
    LIMIT 1;
  END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for getCompanyForAbout
-- ----------------------------
DROP PROCEDURE IF EXISTS `getCompanyForAbout`;
delimiter ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getCompanyForAbout`()
BEGIN 
    SELECT About
    FROM Company
    LIMIT 1;
  END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for getCompanyForFooter
-- ----------------------------
DROP PROCEDURE IF EXISTS `getCompanyForFooter`;
delimiter ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getCompanyForFooter`()
BEGIN
    SELECT Name, Address, Phone, Hotline, Email,Slogan, BusinessHours,Logo, Facebook, Google, Twitter, TaxCode
    FROM Company
    LIMIT 1;
  END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for getCompanyForHead
-- ----------------------------
DROP PROCEDURE IF EXISTS `getCompanyForHead`;
delimiter ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getCompanyForHead`()
BEGIN
    SELECT Slogan, BusinessHours, Logo, Hotline, Facebook, Twitter, Google
    FROM Company
    LIMIT 1;
  END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for getCompanyForHome
-- ----------------------------
DROP PROCEDURE IF EXISTS `getCompanyForHome`;
delimiter ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getCompanyForHome`()
BEGIN 
    SELECT Description, WhyChooseUs
    FROM Company
    LIMIT 1;
  END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for getFeedbackById
-- ----------------------------
DROP PROCEDURE IF EXISTS `getFeedbackById`;
delimiter ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getFeedbackById`(IN pId INT)
BEGIN 
    SELECT Id, FullName, Avatar, Content, CreateDate, ServiceId
    FROM Feedbacks
    WHERE Id = pId
    LIMIT 1;
  END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for getImageById
-- ----------------------------
DROP PROCEDURE IF EXISTS `getImageById`;
delimiter ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getImageById`(IN pId INT)
BEGIN
    SELECT Id, Name, Image, Gallery, Customer
    FROM Images
    WHERE Id = pId
    LIMIT 1;
  END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for getMenuHead
-- ----------------------------
DROP PROCEDURE IF EXISTS `getMenuHead`;
delimiter ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getMenuHead`()
BEGIN
    SELECT Id, Name, Alias, Service, News
    FROM Category
    WHERE Activated = 1
    ORDER BY Orders;
  END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for getPostByAlias
-- ----------------------------
DROP PROCEDURE IF EXISTS `getPostByAlias`;
delimiter ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getPostByAlias`(IN pAlias TINYTEXT)
BEGIN
    SELECT Id, Name, Alias, Image, ShortDescription, Activated, Content, CategoryId, HomePage, CreateDate
    FROM Posts
    WHERE Alias = pAlias COLLATE utf8_unicode_ci 
    LIMIT 1;
  END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for getPostById
-- ----------------------------
DROP PROCEDURE IF EXISTS `getPostById`;
delimiter ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getPostById`(IN pId INT)
BEGIN
    SELECT Id, Name, Alias, Image, ShortDescription, Activated, Content, CategoryId, HomePage
    FROM Posts
    WHERE Id = pId
    LIMIT 1;
  END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for getPostForFooter
-- ----------------------------
DROP PROCEDURE IF EXISTS `getPostForFooter`;
delimiter ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getPostForFooter`()
BEGIN
    SELECT p.Name, p.Alias
    FROM Posts p
    INNER JOIN Category c ON p.CategoryId = c.Id
    AND c.News = 1 AND p.Activated = 1
    LIMIT 3;
  END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for getPostForHome
-- ----------------------------
DROP PROCEDURE IF EXISTS `getPostForHome`;
delimiter ;;
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
delimiter ;

-- ----------------------------
-- Procedure structure for getServiceByAlias
-- ----------------------------
DROP PROCEDURE IF EXISTS `getServiceByAlias`;
delimiter ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getServiceByAlias`(IN pAlias TINYTEXT)
BEGIN
    SELECT Id, Name, Alias, Image, Status, Price, ShortDescription, Activated, Content
    FROM Services
    WHERE Alias = pAlias COLLATE utf8_unicode_ci 
    LIMIT 1;
  END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for getServiceById
-- ----------------------------
DROP PROCEDURE IF EXISTS `getServiceById`;
delimiter ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getServiceById`(IN pId INT)
BEGIN
    SELECT Id, Name, Alias, Image, Status, Price, ShortDescription, Activated, Content
    FROM Services
    WHERE Id = pId
    LIMIT 1;
  END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for getServiceForFooter
-- ----------------------------
DROP PROCEDURE IF EXISTS `getServiceForFooter`;
delimiter ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getServiceForFooter`()
BEGIN
    SELECT Name, Alias FROM Services WHERE Activated = 1 LIMIT 5;
  END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for getSlideById
-- ----------------------------
DROP PROCEDURE IF EXISTS `getSlideById`;
delimiter ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getSlideById`(IN pId INT)
BEGIN
    SELECT Id, Name, Alias, Image, ButtonViewer, LinkViewer, Activated
    FROM Slides
    WHERE  Id = pId
    LIMIT 1;
  END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for getUserByUserName
-- ----------------------------
DROP PROCEDURE IF EXISTS `getUserByUserName`;
delimiter ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getUserByUserName`(IN pUserName VARCHAR(25))
BEGIN 
    SELECT UserName, Password, FullName, Activated
    FROM Users
    WHERE UserName = pUserName COLLATE utf8_unicode_ci
    LIMIT 1;
  END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for insertCategory
-- ----------------------------
DROP PROCEDURE IF EXISTS `insertCategory`;

-- ----------------------------
-- Procedure structure for insertFeedback
-- ----------------------------
DROP PROCEDURE IF EXISTS `insertFeedback`;

-- ----------------------------
-- Procedure structure for insertImage
-- ----------------------------
DROP PROCEDURE IF EXISTS `insertImage`;

-- ----------------------------
-- Procedure structure for insertPost
-- ----------------------------
DROP PROCEDURE IF EXISTS `insertPost`;

-- ----------------------------
-- Procedure structure for insertService
-- ----------------------------
DROP PROCEDURE IF EXISTS `insertService`;

-- ----------------------------
-- Procedure structure for insertSlide
-- ----------------------------
DROP PROCEDURE IF EXISTS `insertSlide`;

-- ----------------------------
-- Procedure structure for insertUser
-- ----------------------------
DROP PROCEDURE IF EXISTS `insertUser`;

-- ----------------------------
-- Procedure structure for login
-- ----------------------------
DROP PROCEDURE IF EXISTS `login`;
delimiter ;;
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
delimiter ;

-- ----------------------------
-- Procedure structure for updateCategory
-- ----------------------------
DROP PROCEDURE IF EXISTS `updateCategory`;

-- ----------------------------
-- Procedure structure for updateCompany
-- ----------------------------
DROP PROCEDURE IF EXISTS `updateCompany`;

-- ----------------------------
-- Procedure structure for updateFeedback
-- ----------------------------
DROP PROCEDURE IF EXISTS `updateFeedback`;

-- ----------------------------
-- Procedure structure for updateImage
-- ----------------------------
DROP PROCEDURE IF EXISTS `updateImage`;

-- ----------------------------
-- Procedure structure for updatePost
-- ----------------------------
DROP PROCEDURE IF EXISTS `updatePost`;

-- ----------------------------
-- Procedure structure for updateService
-- ----------------------------
DROP PROCEDURE IF EXISTS `updateService`;

-- ----------------------------
-- Procedure structure for updateSlide
-- ----------------------------
DROP PROCEDURE IF EXISTS `updateSlide`;

-- ----------------------------
-- Procedure structure for updateUser
-- ----------------------------
DROP PROCEDURE IF EXISTS `updateUser`;
delimiter ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `updateUser`(IN pUserName VARCHAR(25), IN pPassword TINYTEXT, IN pFullName TINYTEXT, IN pActivated BIT)
BEGIN
    UPDATE Users
      SET Password = pPassword, FullName = pFullName, Activated = pActivated
    WHERE UserName = pUserName COLLATE utf8_unicode_ci;
  END
;;
delimiter ;

SET FOREIGN_KEY_CHECKS = 1;
