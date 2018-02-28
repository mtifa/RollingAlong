/*
Navicat MariaDB Data Transfer

Source Server         : moops
Source Server Version : 100029
Source Host           : moops.ddns.net:3306
Source Database       : Rolling

Target Server Type    : MariaDB
Target Server Version : 100029
File Encoding         : 65001

Date: 2017-07-09 05:52:48
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for Bicycle
-- ----------------------------
DROP TABLE IF EXISTS `Bicycle`;
CREATE TABLE `Bicycle` (
  `Name` varchar(255) DEFAULT NULL,
  `State` int(11) DEFAULT NULL,
  `Price_per_hour` decimal(65,0) DEFAULT NULL,
  `Price_per_day` decimal(65,0) DEFAULT NULL,
  `Currency` varchar(255) DEFAULT NULL,
  `BicycleID` int(11) NOT NULL AUTO_INCREMENT,
  `Category` int(11) DEFAULT NULL,
  PRIMARY KEY (`BicycleID`),
  KEY `fk_Bicycle_Category_1` (`Category`),
  CONSTRAINT `fk_Bicycle_Category_1` FOREIGN KEY (`Category`) REFERENCES `Category` (`CategoryID`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=51 DEFAULT CHARSET=utf8mb4;

-- ----------------------------
-- Records of Bicycle
-- ----------------------------
INSERT INTO `Bicycle` VALUES ('52685-372', '1', '3', '77', 'HRK', '1', '14');
INSERT INTO `Bicycle` VALUES ('57691-115', '2', '4', '78', 'HRK', '2', '1');
INSERT INTO `Bicycle` VALUES ('60709-106', '1', '4', '78', 'HRK', '3', '14');
INSERT INTO `Bicycle` VALUES ('13537-524', '2', '5', '62', 'HRK', '4', '1');
INSERT INTO `Bicycle` VALUES ('98132-904', '1', '5', '84', 'HRK', '5', '15');
INSERT INTO `Bicycle` VALUES ('0187-5475', '3', '5', '86', 'HRK', '6', '8');
INSERT INTO `Bicycle` VALUES ('62756-437', '1', '2', '84', 'HRK', '7', '10');
INSERT INTO `Bicycle` VALUES ('0517-0372', '1', '3', '91', 'HRK', '8', '3');
INSERT INTO `Bicycle` VALUES ('68151-4068', '1', '3', '87', 'HRK', '9', '12');
INSERT INTO `Bicycle` VALUES ('54868-4248', '3', '4', '69', 'HRK', '10', '9');
INSERT INTO `Bicycle` VALUES ('52685-360', '3', '4', '83', 'HRK', '11', '2');
INSERT INTO `Bicycle` VALUES ('55714-4485', '2', '5', '94', 'HRK', '12', '8');
INSERT INTO `Bicycle` VALUES ('54868-3137', '1', '1', '81', 'HRK', '13', '1');
INSERT INTO `Bicycle` VALUES ('68382-098', '1', '5', '74', 'HRK', '14', '4');
INSERT INTO `Bicycle` VALUES ('57520-0527', '1', '4', '74', 'HRK', '15', '10');
INSERT INTO `Bicycle` VALUES ('49348-274', '3', '2', '85', 'HRK', '16', '10');
INSERT INTO `Bicycle` VALUES ('60561-0001', '2', '2', '84', 'HRK', '17', '14');
INSERT INTO `Bicycle` VALUES ('55154-5712', '3', '3', '51', 'HRK', '18', '14');
INSERT INTO `Bicycle` VALUES ('63739-471', '1', '3', '89', 'HRK', '19', '10');
INSERT INTO `Bicycle` VALUES ('66915-300', '2', '3', '57', 'HRK', '20', '9');
INSERT INTO `Bicycle` VALUES ('76237-157', '3', '3', '54', 'HRK', '21', '6');
INSERT INTO `Bicycle` VALUES ('0172-5034', '1', '3', '51', 'HRK', '22', '9');
INSERT INTO `Bicycle` VALUES ('0006-3919', '3', '2', '63', 'HRK', '23', '1');
INSERT INTO `Bicycle` VALUES ('52533-074', '3', '2', '96', 'HRK', '24', '15');
INSERT INTO `Bicycle` VALUES ('50181-0015', '1', '4', '50', 'HRK', '25', '8');
INSERT INTO `Bicycle` VALUES ('62756-553', '1', '3', '73', 'HRK', '26', '4');
INSERT INTO `Bicycle` VALUES ('64980-154', '3', '3', '75', 'HRK', '27', '15');
INSERT INTO `Bicycle` VALUES ('36987-2405', '1', '2', '56', 'HRK', '28', '3');
INSERT INTO `Bicycle` VALUES ('0172-2083', '3', '2', '88', 'HRK', '29', '9');
INSERT INTO `Bicycle` VALUES ('36800-419', '3', '2', '96', 'HRK', '30', '12');
INSERT INTO `Bicycle` VALUES ('55390-613', '3', '2', '85', 'HRK', '31', '8');
INSERT INTO `Bicycle` VALUES ('47335-836', '3', '3', '56', 'HRK', '32', '11');
INSERT INTO `Bicycle` VALUES ('53210-1002', '3', '3', '79', 'HRK', '33', '13');
INSERT INTO `Bicycle` VALUES ('16590-107', '1', '2', '75', 'HRK', '34', '9');
INSERT INTO `Bicycle` VALUES ('0173-0933', '2', '2', '71', 'HRK', '35', '11');
INSERT INTO `Bicycle` VALUES ('60429-273', '3', '4', '52', 'HRK', '36', '12');
INSERT INTO `Bicycle` VALUES ('55566-8403', '3', '4', '59', 'HRK', '37', '15');
INSERT INTO `Bicycle` VALUES ('55315-199', '3', '3', '52', 'HRK', '38', '14');
INSERT INTO `Bicycle` VALUES ('46122-125', '1', '4', '77', 'HRK', '39', '4');
INSERT INTO `Bicycle` VALUES ('36987-1580', '3', '2', '52', 'HRK', '40', '6');
INSERT INTO `Bicycle` VALUES ('0574-7112', '2', '4', '53', 'HRK', '41', '10');
INSERT INTO `Bicycle` VALUES ('0536-3479', '3', '2', '79', 'HRK', '42', '5');
INSERT INTO `Bicycle` VALUES ('50268-575', '3', '4', '82', 'HRK', '43', '5');
INSERT INTO `Bicycle` VALUES ('55154-9439', '3', '4', '79', 'HRK', '44', '3');
INSERT INTO `Bicycle` VALUES ('12258-223', '1', '4', '89', 'HRK', '45', '3');
INSERT INTO `Bicycle` VALUES ('54868-0034', '1', '5', '67', 'HRK', '46', '7');
INSERT INTO `Bicycle` VALUES ('11523-7325', '1', '4', '69', 'HRK', '47', '12');
INSERT INTO `Bicycle` VALUES ('55312-184', '1', '3', '67', 'HRK', '48', '10');
INSERT INTO `Bicycle` VALUES ('10544-057', '1', '3', '61', 'HRK', '49', '3');
INSERT INTO `Bicycle` VALUES ('50268-264', '1', '2', '99', 'HRK', '50', '5');

-- ----------------------------
-- Table structure for Category
-- ----------------------------
DROP TABLE IF EXISTS `Category`;
CREATE TABLE `Category` (
  `Name` varchar(255) DEFAULT NULL,
  `CategoryID` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`CategoryID`)
) ENGINE=InnoDB AUTO_INCREMENT=66 DEFAULT CHARSET=utf8mb4;

-- ----------------------------
-- Records of Category
-- ----------------------------
INSERT INTO `Category` VALUES ('Road bicycles', '1');
INSERT INTO `Category` VALUES ('Touring bicycles', '2');
INSERT INTO `Category` VALUES ('Randonneur ', '3');
INSERT INTO `Category` VALUES ('Hybrid bicycles', '4');
INSERT INTO `Category` VALUES ('Flat bar road bikes', '5');
INSERT INTO `Category` VALUES ('Cyclo-cross bike ', '6');
INSERT INTO `Category` VALUES ('Utility bicycles', '7');
INSERT INTO `Category` VALUES ('Freight bicycles', '8');
INSERT INTO `Category` VALUES ('Ice cycles ', '9');
INSERT INTO `Category` VALUES ('Mountain bicycles', '10');
INSERT INTO `Category` VALUES ('Military bicycles', '11');
INSERT INTO `Category` VALUES ('Racing bicycles', '12');
INSERT INTO `Category` VALUES ('BMX bikes', '13');
INSERT INTO `Category` VALUES ('Track bicycles', '14');
INSERT INTO `Category` VALUES ('Triathlon', '15');

-- ----------------------------
-- Table structure for Equipment
-- ----------------------------
DROP TABLE IF EXISTS `Equipment`;
CREATE TABLE `Equipment` (
  `Name` varchar(255) DEFAULT NULL,
  `State` int(11) DEFAULT NULL,
  `Price_per_hour` decimal(65,0) DEFAULT NULL,
  `Price_per_day` decimal(65,0) DEFAULT NULL,
  `Currency` varchar(255) DEFAULT NULL,
  `EquipmentID` int(11) NOT NULL AUTO_INCREMENT,
  `Category` int(11) DEFAULT NULL,
  PRIMARY KEY (`EquipmentID`),
  KEY `fk_Equipment_Category_1` (`Category`),
  CONSTRAINT `fk_Equipment_Category_1` FOREIGN KEY (`Category`) REFERENCES `Category` (`CategoryID`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=151 DEFAULT CHARSET=utf8mb4;

-- ----------------------------
-- Records of Equipment
-- ----------------------------
INSERT INTO `Equipment` VALUES ('EQ63459-548', '2', '4', '65', 'PLN', '101', '10');
INSERT INTO `Equipment` VALUES ('EQ35356-924', '1', '3', '59', 'EUR', '102', '15');
INSERT INTO `Equipment` VALUES ('EQ57691-170', '3', '1', '74', 'SEK', '103', '3');
INSERT INTO `Equipment` VALUES ('EQ68151-3120', '3', '4', '62', 'GHS', '104', '1');
INSERT INTO `Equipment` VALUES ('EQ64159-6993', '2', '3', '96', 'IDR', '105', '13');
INSERT INTO `Equipment` VALUES ('EQ0135-0129', '1', '2', '99', 'IDR', '106', '7');
INSERT INTO `Equipment` VALUES ('EQ62032-522', '2', '1', '69', 'BRL', '107', '3');
INSERT INTO `Equipment` VALUES ('EQ45725-001', '2', '2', '87', 'CNY', '108', '14');
INSERT INTO `Equipment` VALUES ('EQ41190-186', '2', '3', '67', 'CNY', '109', '3');
INSERT INTO `Equipment` VALUES ('EQ53808-0905', '1', '5', '55', 'CNY', '110', '11');
INSERT INTO `Equipment` VALUES ('EQ10631-110', '2', '4', '89', 'COP', '111', '3');
INSERT INTO `Equipment` VALUES ('EQ36987-1211', '2', '4', '74', 'CNY', '112', '14');
INSERT INTO `Equipment` VALUES ('EQ36987-1358', '2', '4', '86', 'EUR', '113', '11');
INSERT INTO `Equipment` VALUES ('EQ55910-977', '1', '4', '56', 'UZS', '114', '5');
INSERT INTO `Equipment` VALUES ('EQ11822-5649', '3', '2', '52', 'CNY', '115', '4');
INSERT INTO `Equipment` VALUES ('EQ55289-214', '2', '1', '72', 'NGN', '116', '14');
INSERT INTO `Equipment` VALUES ('EQ68382-065', '1', '5', '82', 'COP', '117', '3');
INSERT INTO `Equipment` VALUES ('EQ65044-2215', '3', '2', '60', 'ZAR', '118', '4');
INSERT INTO `Equipment` VALUES ('EQ61953-0001', '1', '2', '71', 'BRL', '119', '11');
INSERT INTO `Equipment` VALUES ('EQ63304-644', '2', '3', '64', 'ILS', '120', '13');
INSERT INTO `Equipment` VALUES ('EQ0338-1305', '2', '1', '80', 'AFN', '121', '15');
INSERT INTO `Equipment` VALUES ('EQ37012-127', '3', '3', '74', 'IDR', '122', '13');
INSERT INTO `Equipment` VALUES ('EQ13537-214', '3', '4', '100', 'JOD', '123', '12');
INSERT INTO `Equipment` VALUES ('EQ0159-2500', '3', '2', '60', 'CNY', '124', '5');
INSERT INTO `Equipment` VALUES ('EQ57520-0479', '3', '3', '68', 'AFN', '125', '11');
INSERT INTO `Equipment` VALUES ('EQ0268-6721', '3', '4', '76', 'CNY', '126', '4');
INSERT INTO `Equipment` VALUES ('EQ55289-463', '1', '5', '100', 'EUR', '127', '9');
INSERT INTO `Equipment` VALUES ('EQ53738-0711', '3', '4', '92', 'CNY', '128', '15');
INSERT INTO `Equipment` VALUES ('EQ64125-130', '2', '5', '79', 'GYD', '129', '8');
INSERT INTO `Equipment` VALUES ('EQ50268-617', '3', '3', '58', 'SLL', '130', '15');
INSERT INTO `Equipment` VALUES ('EQ43742-0368', '3', '2', '54', 'THB', '131', '15');
INSERT INTO `Equipment` VALUES ('EQ0113-0441', '3', '4', '59', 'CNY', '132', '15');
INSERT INTO `Equipment` VALUES ('EQ65044-9953', '1', '3', '56', 'EUR', '133', '14');
INSERT INTO `Equipment` VALUES ('EQ50563-149', '2', '3', '81', 'RSD', '134', '14');
INSERT INTO `Equipment` VALUES ('EQ55111-439', '3', '4', '66', 'CNY', '135', '1');
INSERT INTO `Equipment` VALUES ('EQ21130-511', '1', '2', '71', 'SEK', '136', '12');
INSERT INTO `Equipment` VALUES ('EQ53808-0361', '3', '3', '52', 'USD', '137', '7');
INSERT INTO `Equipment` VALUES ('EQ0143-9668', '3', '4', '66', 'IRR', '138', '12');
INSERT INTO `Equipment` VALUES ('EQ16590-065', '2', '5', '64', 'MAD', '139', '1');
INSERT INTO `Equipment` VALUES ('EQ21749-251', '3', '5', '91', 'ILS', '140', '11');
INSERT INTO `Equipment` VALUES ('EQ36987-1008', '2', '2', '84', 'ARS', '141', '15');
INSERT INTO `Equipment` VALUES ('EQ47593-169', '2', '4', '57', 'PHP', '142', '6');
INSERT INTO `Equipment` VALUES ('EQ55154-5065', '1', '3', '84', 'PHP', '143', '6');
INSERT INTO `Equipment` VALUES ('EQ49371-031', '1', '1', '63', 'IDR', '144', '13');
INSERT INTO `Equipment` VALUES ('EQ16781-389', '2', '4', '97', 'ZAR', '145', '12');
INSERT INTO `Equipment` VALUES ('EQ49349-012', '1', '4', '65', 'COP', '146', '15');
INSERT INTO `Equipment` VALUES ('EQ55714-4625', '3', '3', '63', 'CAD', '147', '1');
INSERT INTO `Equipment` VALUES ('EQ51672-4038', '3', '3', '58', 'RUB', '148', '5');
INSERT INTO `Equipment` VALUES ('EQ33992-8806', '1', '3', '73', 'SEK', '149', '2');
INSERT INTO `Equipment` VALUES ('EQ50499-200', '3', '4', '56', 'NGN', '150', '13');

-- ----------------------------
-- Table structure for Equipment_with_Rent
-- ----------------------------
DROP TABLE IF EXISTS `Equipment_with_Rent`;
CREATE TABLE `Equipment_with_Rent` (
  `EwRID` int(11) NOT NULL AUTO_INCREMENT,
  `Equipment` int(11) DEFAULT NULL,
  `Rent` int(11) DEFAULT NULL,
  PRIMARY KEY (`EwRID`),
  KEY `fk_Equipment_with_Rent_Equipment_1` (`Equipment`),
  KEY `fk_Equipment_with_Rent_Rent_1` (`Rent`),
  CONSTRAINT `fk_Equipment_with_Rent_Equipment_1` FOREIGN KEY (`Equipment`) REFERENCES `Equipment` (`EquipmentID`) ON DELETE CASCADE ON UPDATE NO ACTION,
  CONSTRAINT `fk_Equipment_with_Rent_Rent_1` FOREIGN KEY (`Rent`) REFERENCES `Rent` (`RentID`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=51 DEFAULT CHARSET=utf8mb4;

-- ----------------------------
-- Records of Equipment_with_Rent
-- ----------------------------
INSERT INTO `Equipment_with_Rent` VALUES ('1', '144', '70');
INSERT INTO `Equipment_with_Rent` VALUES ('2', '149', '93');
INSERT INTO `Equipment_with_Rent` VALUES ('3', '123', '60');
INSERT INTO `Equipment_with_Rent` VALUES ('4', '115', '80');
INSERT INTO `Equipment_with_Rent` VALUES ('5', '101', '99');
INSERT INTO `Equipment_with_Rent` VALUES ('6', '142', '83');
INSERT INTO `Equipment_with_Rent` VALUES ('7', '148', '74');
INSERT INTO `Equipment_with_Rent` VALUES ('8', '138', '83');
INSERT INTO `Equipment_with_Rent` VALUES ('9', '150', '67');
INSERT INTO `Equipment_with_Rent` VALUES ('10', '112', '78');
INSERT INTO `Equipment_with_Rent` VALUES ('11', '142', '79');
INSERT INTO `Equipment_with_Rent` VALUES ('12', '102', '51');
INSERT INTO `Equipment_with_Rent` VALUES ('13', '135', '75');
INSERT INTO `Equipment_with_Rent` VALUES ('14', '105', '87');
INSERT INTO `Equipment_with_Rent` VALUES ('15', '122', '65');
INSERT INTO `Equipment_with_Rent` VALUES ('16', '102', '96');
INSERT INTO `Equipment_with_Rent` VALUES ('17', '101', '78');
INSERT INTO `Equipment_with_Rent` VALUES ('18', '135', '72');
INSERT INTO `Equipment_with_Rent` VALUES ('19', '129', '56');
INSERT INTO `Equipment_with_Rent` VALUES ('20', '108', '75');
INSERT INTO `Equipment_with_Rent` VALUES ('21', '127', '89');
INSERT INTO `Equipment_with_Rent` VALUES ('22', '139', '75');
INSERT INTO `Equipment_with_Rent` VALUES ('23', '139', '81');
INSERT INTO `Equipment_with_Rent` VALUES ('24', '143', '59');
INSERT INTO `Equipment_with_Rent` VALUES ('25', '118', '79');
INSERT INTO `Equipment_with_Rent` VALUES ('26', '129', '80');
INSERT INTO `Equipment_with_Rent` VALUES ('27', '147', '67');
INSERT INTO `Equipment_with_Rent` VALUES ('28', '124', '58');
INSERT INTO `Equipment_with_Rent` VALUES ('29', '129', '85');
INSERT INTO `Equipment_with_Rent` VALUES ('30', '121', '73');
INSERT INTO `Equipment_with_Rent` VALUES ('31', '115', '62');
INSERT INTO `Equipment_with_Rent` VALUES ('32', '108', '57');
INSERT INTO `Equipment_with_Rent` VALUES ('33', '128', '93');
INSERT INTO `Equipment_with_Rent` VALUES ('34', '126', '92');
INSERT INTO `Equipment_with_Rent` VALUES ('35', '124', '68');
INSERT INTO `Equipment_with_Rent` VALUES ('36', '137', '69');
INSERT INTO `Equipment_with_Rent` VALUES ('37', '139', '64');
INSERT INTO `Equipment_with_Rent` VALUES ('38', '144', '77');
INSERT INTO `Equipment_with_Rent` VALUES ('39', '101', '66');
INSERT INTO `Equipment_with_Rent` VALUES ('40', '147', '80');
INSERT INTO `Equipment_with_Rent` VALUES ('41', '137', '97');
INSERT INTO `Equipment_with_Rent` VALUES ('42', '144', '63');
INSERT INTO `Equipment_with_Rent` VALUES ('43', '112', '95');
INSERT INTO `Equipment_with_Rent` VALUES ('44', '113', '99');
INSERT INTO `Equipment_with_Rent` VALUES ('45', '111', '89');
INSERT INTO `Equipment_with_Rent` VALUES ('46', '131', '86');
INSERT INTO `Equipment_with_Rent` VALUES ('47', '137', '76');
INSERT INTO `Equipment_with_Rent` VALUES ('48', '119', '52');
INSERT INTO `Equipment_with_Rent` VALUES ('49', '122', '71');
INSERT INTO `Equipment_with_Rent` VALUES ('50', '139', '96');

-- ----------------------------
-- Table structure for Issue
-- ----------------------------
DROP TABLE IF EXISTS `Issue`;
CREATE TABLE `Issue` (
  `Description` text,
  `State` int(255) DEFAULT NULL,
  `Date_created` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `Date_resolved` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `IssueID` int(11) NOT NULL AUTO_INCREMENT,
  `Rent` int(11) DEFAULT NULL,
  `Type` int(11) DEFAULT NULL,
  PRIMARY KEY (`IssueID`),
  KEY `fk_Issue_Issue_type_1` (`Type`),
  KEY `fk_Issue_Rent_1` (`Rent`),
  CONSTRAINT `fk_Issue_Issue_type_1` FOREIGN KEY (`Type`) REFERENCES `Issue_type` (`IssueTypeID`) ON DELETE CASCADE ON UPDATE NO ACTION,
  CONSTRAINT `fk_Issue_Rent_1` FOREIGN KEY (`Rent`) REFERENCES `Rent` (`RentID`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=103 DEFAULT CHARSET=utf8mb4;

-- ----------------------------
-- Records of Issue
-- ----------------------------
INSERT INTO `Issue` VALUES ('Fusion of Left Tarsal Joint with Synth Sub, Open Approach', '3', '2016-07-30 22:35:58', '2016-09-02 13:35:08', '51', '57', null);
INSERT INTO `Issue` VALUES ('Bypass L Hepatic Duct to R Hep Duc w Intralum Dev, Perc Endo', '2', '2016-12-12 05:48:23', '2016-12-14 07:20:56', '52', '66', null);
INSERT INTO `Issue` VALUES ('Release Right Foot Tendon, External Approach', '3', '2016-09-19 02:58:07', '2017-01-25 01:34:15', '53', '55', null);
INSERT INTO `Issue` VALUES ('Computerized Tomography (CT Scan) of Abdomen', '1', '2017-01-29 18:46:30', '2017-03-03 11:34:32', '54', '97', null);
INSERT INTO `Issue` VALUES ('Release Right Abdomen Bursa and Ligament, Open Approach', '3', '2017-05-18 00:18:57', '2017-06-12 15:44:50', '55', '58', null);
INSERT INTO `Issue` VALUES ('MRI of Bi Int Carotid using Oth Contrast, Unenh, Enhance', '3', '2016-08-14 08:36:05', '2016-07-09 11:09:13', '56', '62', null);
INSERT INTO `Issue` VALUES ('Extirpation of Matter from Ampulla of Vater, Via Opening', '1', '2016-09-17 20:29:27', '2016-10-30 18:22:33', '57', '86', null);
INSERT INTO `Issue` VALUES ('Bypass Lower Esophagus to Stomach with Synth Sub, Endo', '3', '2016-08-30 07:39:02', '2016-10-04 03:06:37', '58', '81', null);
INSERT INTO `Issue` VALUES ('Extirpation of Matter from Right Foot Tendon, Perc Approach', '3', '2016-12-18 08:32:24', '2017-04-29 01:34:41', '59', '67', null);
INSERT INTO `Issue` VALUES ('Removal of Nonaut Sub from Spinal Cord, Open Approach', '1', '2017-04-22 14:31:25', '2017-03-11 10:56:01', '60', '53', null);
INSERT INTO `Issue` VALUES ('Repair of Upper Tooth, All, External Approach', '3', '2016-07-22 22:31:39', '2016-12-12 08:44:35', '61', '91', null);
INSERT INTO `Issue` VALUES ('Removal of Other Device from Abd Wall, Perc Endo Approach', '2', '2016-09-12 02:56:10', '2016-07-14 10:48:52', '62', '63', null);
INSERT INTO `Issue` VALUES ('Restrict of L Int Carotid with Intralum Dev, Perc Approach', '1', '2016-09-03 01:32:49', '2017-03-20 01:34:22', '63', '61', null);
INSERT INTO `Issue` VALUES ('Excision of Right Hip Tendon, Percutaneous Approach', '1', '2016-10-05 17:37:22', '2016-09-24 12:53:45', '64', '59', null);
INSERT INTO `Issue` VALUES ('Drainage of Esophagogastric Junction, Endo', '2', '2017-06-01 02:40:00', '2017-05-08 11:43:12', '65', '95', null);
INSERT INTO `Issue` VALUES ('Motor Function Treatment of Integu Body', '1', '2016-09-20 20:36:34', '2017-05-06 09:19:03', '66', '88', null);
INSERT INTO `Issue` VALUES ('Insert of Infusion Dev into L Less Saphenous, Open Approach', '1', '2016-11-04 03:25:27', '2017-04-07 01:32:31', '67', '94', null);
INSERT INTO `Issue` VALUES ('Revision of Nonaut Sub in L Ear, Perc Endo Approach', '2', '2016-12-06 21:17:59', '2016-08-04 20:57:59', '68', '90', null);
INSERT INTO `Issue` VALUES ('Revision of Synth Sub in Sacrococcygeal Jt, Extern Approach', '3', '2016-10-11 03:01:22', '2017-01-14 19:00:24', '69', '84', null);
INSERT INTO `Issue` VALUES ('Dilate L Colic Art, Bifurc, w Drug-elut Intra, Perc Endo', '2', '2017-02-18 15:22:17', '2017-06-26 18:20:26', '70', '77', null);
INSERT INTO `Issue` VALUES ('Revision of Drainage Device in Right Lung, External Approach', '3', '2016-07-18 14:17:14', '2016-10-29 09:50:02', '71', '78', null);
INSERT INTO `Issue` VALUES ('Resection of Uvula, Open Approach', '1', '2017-06-08 19:53:28', '2017-06-06 20:10:36', '72', '67', null);
INSERT INTO `Issue` VALUES ('Extirpate matter from L Radial Art, Bifurc, Perc Endo', '1', '2016-08-12 10:19:52', '2017-06-29 17:33:31', '73', '52', null);
INSERT INTO `Issue` VALUES ('Ultrasonography of Bi Com Carotid, Intravasc', '1', '2017-02-17 18:43:13', '2016-12-07 18:54:53', '74', '51', null);
INSERT INTO `Issue` VALUES ('Supplement Left Elbow Region with Autol Sub, Open Approach', '1', '2017-06-11 08:16:35', '2017-05-30 02:16:10', '75', '78', null);
INSERT INTO `Issue` VALUES ('Supplement Right Carpal with Nonaut Sub, Perc Approach', '2', '2017-02-05 00:08:36', '2016-08-11 05:30:44', '76', '53', null);
INSERT INTO `Issue` VALUES ('Dilation of Left Foot Artery, Open Approach', '2', '2016-08-30 03:42:32', '2017-05-23 03:00:43', '77', '56', null);
INSERT INTO `Issue` VALUES ('Excision of Right Scapula, Percutaneous Approach, Diagnostic', '2', '2017-04-21 08:11:53', '2016-09-14 15:14:47', '78', '97', null);
INSERT INTO `Issue` VALUES ('Supplement L Ext Iliac Art with Nonaut Sub, Open Approach', '2', '2017-04-21 05:58:01', '2016-07-17 23:32:48', '79', '94', null);
INSERT INTO `Issue` VALUES ('Revision of Nonaut Sub in Tracheobronc Tree, Via Opening', '1', '2016-11-10 20:50:19', '2016-11-29 10:19:47', '80', '55', null);
INSERT INTO `Issue` VALUES ('Destruction of Right Abdomen Muscle, Percutaneous Approach', '1', '2016-10-11 09:12:39', '2016-12-06 04:52:16', '81', '91', null);
INSERT INTO `Issue` VALUES ('Removal of Drain Dev from Vas Deferens, Perc Endo Approach', '1', '2017-03-05 13:13:22', '2016-09-03 08:49:27', '82', '55', null);
INSERT INTO `Issue` VALUES ('Bypass L Axilla Art to R Up Leg Art w Nonaut Sub, Open', '1', '2016-08-13 20:46:52', '2016-12-06 18:31:45', '83', '62', null);
INSERT INTO `Issue` VALUES ('Supplement Left Basilic Vein with Synth Sub, Open Approach', '1', '2017-06-17 18:37:40', '2016-09-12 03:35:20', '84', '79', null);
INSERT INTO `Issue` VALUES ('Supplement L Ext Iliac Vein with Nonaut Sub, Perc Approach', '2', '2017-04-15 14:49:41', '2017-02-05 23:39:12', '85', '75', null);
INSERT INTO `Issue` VALUES ('LDR Brachytherapy of Salivary Gland using Californium 252', '3', '2016-07-14 17:32:01', '2016-09-07 15:34:34', '86', '99', null);
INSERT INTO `Issue` VALUES ('Occlusion Hepatic Vein w Intralum Dev, Perc Endo', '1', '2017-01-13 19:18:18', '2017-01-12 10:28:19', '87', '91', null);
INSERT INTO `Issue` VALUES ('Bypass Thor Aorta Desc to L Pulm Art w Autol Art, Open', '1', '2017-03-13 19:14:30', '2017-06-06 06:08:30', '88', '94', null);
INSERT INTO `Issue` VALUES ('Dilate R Verteb Art w 4+ Intralum Dev, Perc Endo', '2', '2016-09-26 11:08:19', '2017-04-18 21:42:14', '89', '65', null);
INSERT INTO `Issue` VALUES ('Ultrasonography of Heart with Aorta', '1', '2016-08-25 18:25:31', '2017-04-03 15:32:54', '90', '51', null);
INSERT INTO `Issue` VALUES ('Bypass Innominate Artery to R Low Arm Art, Open Approach', '3', '2016-07-05 19:56:31', '2017-04-20 09:50:43', '91', '89', null);
INSERT INTO `Issue` VALUES ('Excision of Scrotum, Percutaneous Endoscopic Approach', '2', '2016-11-17 14:58:51', '2016-11-04 16:42:57', '92', '98', null);
INSERT INTO `Issue` VALUES ('Supplement Colic Vein with Synth Sub, Perc Approach', '2', '2017-05-06 01:48:17', '2016-10-04 12:36:35', '93', '73', null);
INSERT INTO `Issue` VALUES ('Dilate 4+ Cor Art, Bifurc, w 2 Drug-elut, Perc', '3', '2016-10-08 14:26:44', '2016-10-24 00:15:27', '94', '58', null);
INSERT INTO `Issue` VALUES ('Revision of Nonaut Sub in Mouth/Throat, Endo', '1', '2017-05-07 15:28:11', '2016-08-29 18:06:17', '95', '78', null);
INSERT INTO `Issue` VALUES ('Revision of Ext Fix in L Tarsal Jt, Perc Approach', '3', '2017-06-27 14:22:01', '2017-03-09 19:51:11', '96', '84', null);
INSERT INTO `Issue` VALUES ('Exercise Treatment of Resp Low Back/LE using Physical Agent', '2', '2016-08-08 14:18:42', '2016-07-15 02:11:01', '97', '91', null);
INSERT INTO `Issue` VALUES ('Planar Nucl Med Imag of Head & Neck using Thallium 201', '3', '2017-05-30 06:53:47', '2017-04-02 23:40:09', '98', '61', null);
INSERT INTO `Issue` VALUES ('Revision of Int Fix in L Metatarsal, Perc Endo Approach', '1', '2016-08-01 20:04:17', '2017-03-19 15:28:12', '99', '58', null);
INSERT INTO `Issue` VALUES ('Bypass R Com Iliac Art to L Renal A w Nonaut Sub, Open', '2', '2017-06-17 09:54:45', '2017-03-09 01:19:52', '100', '83', null);
INSERT INTO `Issue` VALUES ('', null, '2017-07-09 05:51:49', null, '101', '55', null);
INSERT INTO `Issue` VALUES ('wo2', null, '2017-07-09 05:51:53', null, '102', '55', null);

-- ----------------------------
-- Table structure for Issue_type
-- ----------------------------
DROP TABLE IF EXISTS `Issue_type`;
CREATE TABLE `Issue_type` (
  `Name` varchar(255) DEFAULT NULL,
  `IssueTypeID` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`IssueTypeID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4;

-- ----------------------------
-- Records of Issue_type
-- ----------------------------
INSERT INTO `Issue_type` VALUES ('Account', '1');
INSERT INTO `Issue_type` VALUES ('Broken', '2');

-- ----------------------------
-- Table structure for Location
-- ----------------------------
DROP TABLE IF EXISTS `Location`;
CREATE TABLE `Location` (
  `Latitude` varchar(255) DEFAULT NULL,
  `Longitude` varchar(255) DEFAULT NULL,
  `Location` varchar(255) DEFAULT NULL,
  `LocationID` int(11) NOT NULL AUTO_INCREMENT,
  `Bicycle` int(11) DEFAULT NULL,
  PRIMARY KEY (`LocationID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4;

-- ----------------------------
-- Records of Location
-- ----------------------------
INSERT INTO `Location` VALUES ('test', 'test', 'test', '1', null);

-- ----------------------------
-- Table structure for Rent
-- ----------------------------
DROP TABLE IF EXISTS `Rent`;
CREATE TABLE `Rent` (
  `User` int(11) NOT NULL,
  `Date_from` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `Date_to` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `Status` int(11) DEFAULT NULL,
  `RentID` int(11) NOT NULL AUTO_INCREMENT,
  `Bicycle` int(11) DEFAULT NULL,
  `Review` int(11) DEFAULT NULL,
  `Location` int(11) DEFAULT NULL,
  PRIMARY KEY (`RentID`),
  KEY `fk_Rent_Bicycle_1` (`Bicycle`),
  KEY `fk_Rent_Location_1` (`Location`),
  KEY `fk_Rent_Reviews_1` (`Review`),
  KEY `fk_Rent_User_1` (`User`),
  CONSTRAINT `fk_Rent_Bicycle_1` FOREIGN KEY (`Bicycle`) REFERENCES `Bicycle` (`BicycleID`) ON DELETE CASCADE ON UPDATE NO ACTION,
  CONSTRAINT `fk_Rent_Location_1` FOREIGN KEY (`Location`) REFERENCES `Location` (`LocationID`) ON DELETE CASCADE ON UPDATE NO ACTION,
  CONSTRAINT `fk_Rent_Reviews_1` FOREIGN KEY (`Review`) REFERENCES `Reviews` (`ReviewsID`) ON DELETE CASCADE ON UPDATE NO ACTION,
  CONSTRAINT `fk_Rent_User_1` FOREIGN KEY (`User`) REFERENCES `User` (`UserID`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=101 DEFAULT CHARSET=utf8mb4;

-- ----------------------------
-- Records of Rent
-- ----------------------------
INSERT INTO `Rent` VALUES ('1', '2017-07-09 05:00:10', '2017-07-09 05:00:10', '1', '51', '2', '58', '1');
INSERT INTO `Rent` VALUES ('1', '2017-07-09 05:00:13', '2017-07-09 05:00:13', '3', '52', '3', '66', '1');
INSERT INTO `Rent` VALUES ('1', '2017-07-09 04:48:35', '2017-07-09 04:48:35', '1', '53', '4', '56', null);
INSERT INTO `Rent` VALUES ('1', '2017-07-09 04:48:37', '2017-07-09 04:48:37', '2', '54', '5', '77', null);
INSERT INTO `Rent` VALUES ('1', '2017-07-09 04:48:39', '2017-07-09 04:48:39', '2', '55', '6', '65', null);
INSERT INTO `Rent` VALUES ('1', '2017-07-09 04:51:08', '2017-07-09 04:51:08', '2', '56', '1', '66', null);
INSERT INTO `Rent` VALUES ('1', '2017-07-09 05:17:06', '2017-07-09 05:17:06', '1', '57', '4', '95', null);
INSERT INTO `Rent` VALUES ('30', '2017-07-09 04:38:20', '2017-07-09 04:38:20', '3', '58', '30', '85', null);
INSERT INTO `Rent` VALUES ('26', '2017-07-09 04:38:21', '2017-07-09 04:38:21', '3', '59', '34', '78', null);
INSERT INTO `Rent` VALUES ('47', '2017-07-09 04:38:29', '2017-07-09 04:38:29', '2', '60', '31', '91', null);
INSERT INTO `Rent` VALUES ('45', '2017-07-09 04:38:40', '2017-07-09 04:38:40', '1', '61', '16', '73', null);
INSERT INTO `Rent` VALUES ('37', '2017-07-09 04:38:44', '2017-07-09 04:38:44', '2', '62', '7', '77', null);
INSERT INTO `Rent` VALUES ('26', '2017-07-09 04:38:51', '2017-07-09 04:38:51', '3', '63', '31', '67', null);
INSERT INTO `Rent` VALUES ('2', '2017-07-09 04:39:09', '2017-07-09 04:39:09', '1', '64', '7', '84', null);
INSERT INTO `Rent` VALUES ('28', '0000-00-00 23:41:40', '0000-00-00 04:31:46', '2', '65', '48', null, null);
INSERT INTO `Rent` VALUES ('15', '0000-00-00 04:43:10', '0000-00-00 13:08:15', '1', '66', '38', null, null);
INSERT INTO `Rent` VALUES ('38', '0000-00-00 01:31:57', '0000-00-00 13:15:06', '1', '67', '11', null, null);
INSERT INTO `Rent` VALUES ('5', '0000-00-00 22:05:39', '0000-00-00 15:17:34', '1', '68', '17', null, null);
INSERT INTO `Rent` VALUES ('43', '0000-00-00 02:53:42', '0000-00-00 20:53:33', '3', '69', '25', null, null);
INSERT INTO `Rent` VALUES ('8', '0000-00-00 14:31:14', '0000-00-00 08:09:24', '3', '70', '2', null, null);
INSERT INTO `Rent` VALUES ('14', '0000-00-00 17:23:47', '0000-00-00 09:48:09', '1', '71', '38', null, null);
INSERT INTO `Rent` VALUES ('32', '0000-00-00 05:16:40', '0000-00-00 15:22:03', '2', '72', '33', null, null);
INSERT INTO `Rent` VALUES ('46', '0000-00-00 01:44:56', '0000-00-00 17:10:53', '3', '73', '18', null, null);
INSERT INTO `Rent` VALUES ('11', '0000-00-00 17:31:50', '0000-00-00 14:11:53', '1', '74', '31', null, null);
INSERT INTO `Rent` VALUES ('26', '0000-00-00 07:03:56', '0000-00-00 22:17:28', '3', '75', '12', null, null);
INSERT INTO `Rent` VALUES ('33', '0000-00-00 06:34:42', '0000-00-00 12:49:33', '3', '76', '18', null, null);
INSERT INTO `Rent` VALUES ('9', '0000-00-00 17:43:59', '0000-00-00 10:35:35', '3', '77', '12', null, null);
INSERT INTO `Rent` VALUES ('50', '0000-00-00 10:30:49', '0000-00-00 10:40:22', '1', '78', '14', null, null);
INSERT INTO `Rent` VALUES ('50', '0000-00-00 06:33:38', '0000-00-00 13:38:22', '2', '79', '42', null, null);
INSERT INTO `Rent` VALUES ('15', '0000-00-00 15:50:00', '0000-00-00 23:40:27', '3', '80', '24', null, null);
INSERT INTO `Rent` VALUES ('41', '0000-00-00 04:54:44', '0000-00-00 21:11:24', '1', '81', '17', null, null);
INSERT INTO `Rent` VALUES ('18', '0000-00-00 20:43:45', '0000-00-00 03:03:44', '1', '82', '36', null, null);
INSERT INTO `Rent` VALUES ('41', '0000-00-00 02:13:31', '0000-00-00 04:39:23', '3', '83', '23', null, null);
INSERT INTO `Rent` VALUES ('1', '2017-07-09 05:17:04', '2017-07-09 05:17:04', '3', '84', '2', null, null);
INSERT INTO `Rent` VALUES ('45', '0000-00-00 18:24:29', '0000-00-00 04:54:03', '3', '85', '15', null, null);
INSERT INTO `Rent` VALUES ('33', '0000-00-00 18:08:26', '0000-00-00 14:33:00', '1', '86', '21', null, null);
INSERT INTO `Rent` VALUES ('34', '0000-00-00 19:38:14', '0000-00-00 01:49:04', '3', '87', '4', null, null);
INSERT INTO `Rent` VALUES ('32', '0000-00-00 17:53:09', '0000-00-00 19:59:24', '1', '88', '16', null, null);
INSERT INTO `Rent` VALUES ('28', '0000-00-00 09:13:09', '0000-00-00 06:11:46', '1', '89', '14', null, null);
INSERT INTO `Rent` VALUES ('31', '0000-00-00 09:08:34', '0000-00-00 00:36:32', '1', '90', '38', null, null);
INSERT INTO `Rent` VALUES ('12', '0000-00-00 08:55:59', '0000-00-00 18:40:27', '3', '91', '39', null, null);
INSERT INTO `Rent` VALUES ('3', '0000-00-00 03:54:11', '0000-00-00 08:24:34', '1', '92', '28', null, null);
INSERT INTO `Rent` VALUES ('43', '0000-00-00 10:29:21', '0000-00-00 14:59:17', '2', '93', '42', null, null);
INSERT INTO `Rent` VALUES ('24', '0000-00-00 20:45:44', '0000-00-00 05:09:58', '2', '94', '8', null, null);
INSERT INTO `Rent` VALUES ('21', '0000-00-00 08:40:34', '0000-00-00 22:13:47', '1', '95', '14', null, null);
INSERT INTO `Rent` VALUES ('40', '0000-00-00 00:28:26', '0000-00-00 00:43:25', '3', '96', '5', null, null);
INSERT INTO `Rent` VALUES ('36', '0000-00-00 12:16:19', '0000-00-00 12:49:58', '1', '97', '31', null, null);
INSERT INTO `Rent` VALUES ('30', '0000-00-00 03:10:00', '0000-00-00 04:50:24', '1', '98', '10', null, null);
INSERT INTO `Rent` VALUES ('21', '0000-00-00 08:51:51', '0000-00-00 22:25:02', '3', '99', '4', null, null);
INSERT INTO `Rent` VALUES ('27', '0000-00-00 08:57:44', '0000-00-00 07:59:37', '3', '100', '9', null, null);

-- ----------------------------
-- Table structure for Reviews
-- ----------------------------
DROP TABLE IF EXISTS `Reviews`;
CREATE TABLE `Reviews` (
  `Description` text,
  `Stars` int(11) DEFAULT NULL,
  `ReviewsID` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`ReviewsID`)
) ENGINE=InnoDB AUTO_INCREMENT=101 DEFAULT CHARSET=utf8mb4;

-- ----------------------------
-- Records of Reviews
-- ----------------------------
INSERT INTO `Reviews` VALUES ('CT Scan of Abd & Pelvis using Oth Contrast, Unenh, Enhance', '5', '51');
INSERT INTO `Reviews` VALUES ('Subcutaneous Tissue and Fascia, Repair', '1', '52');
INSERT INTO `Reviews` VALUES ('Revision of Synth Sub in R Femur Shaft, Open Approach', '5', '53');
INSERT INTO `Reviews` VALUES ('Occlusion of Left Hepatic Duct, Via Opening', '2', '54');
INSERT INTO `Reviews` VALUES ('Supplement Thor Jt with Synth Sub, Perc Approach', '2', '55');
INSERT INTO `Reviews` VALUES ('Release Left External Carotid Artery, Perc Endo Approach', '3', '56');
INSERT INTO `Reviews` VALUES ('Introduction of Oth Therap Subst into Low GI, Endo', '3', '57');
INSERT INTO `Reviews` VALUES ('Reposition Right Toe Phalangeal Joint, External Approach', '4', '58');
INSERT INTO `Reviews` VALUES ('Drainage of R Up Extrem Lymph with Drain Dev, Open Approach', '1', '59');
INSERT INTO `Reviews` VALUES ('Excision of Right Upper Femur, Open Approach, Diagnostic', '3', '60');
INSERT INTO `Reviews` VALUES ('Auditory Processing Assessment', '3', '61');
INSERT INTO `Reviews` VALUES ('Removal of Other Device from POC, Via Opening', '4', '62');
INSERT INTO `Reviews` VALUES ('Transfer Left Lower Arm and Wrist Muscle, Perc Endo Approach', '5', '63');
INSERT INTO `Reviews` VALUES ('Supplement Chordae Tendineae with Zooplastic, Perc Approach', '2', '64');
INSERT INTO `Reviews` VALUES ('Dilation of Left Lacrimal Duct, Endo', '4', '65');
INSERT INTO `Reviews` VALUES ('Drainage of Right Ankle Tendon, Open Approach, Diagnostic', '2', '66');
INSERT INTO `Reviews` VALUES ('Release Left Upper Femur, Percutaneous Approach', '4', '67');
INSERT INTO `Reviews` VALUES ('Removal of Drainage Device from L Knee Jt, Open Approach', '3', '68');
INSERT INTO `Reviews` VALUES ('Restriction of Bladder with Intraluminal Device, Endo', '2', '69');
INSERT INTO `Reviews` VALUES ('Inspection of Upper Artery, Percutaneous Approach', '5', '70');
INSERT INTO `Reviews` VALUES ('Division of Left Toe Phalanx, Percutaneous Approach', '3', '71');
INSERT INTO `Reviews` VALUES ('Replacement of R Ant Tib Art with Synth Sub, Open Approach', '2', '72');
INSERT INTO `Reviews` VALUES ('Removal of Monitoring Device from Upper Vein, Perc Approach', '1', '73');
INSERT INTO `Reviews` VALUES ('Fluoroscopy of Superior Vena Cava using Low Osmolar Contrast', '2', '74');
INSERT INTO `Reviews` VALUES ('Release Intracranial Artery, Perc Endo Approach', '5', '75');
INSERT INTO `Reviews` VALUES ('Supplement Left Renal Artery with Synth Sub, Open Approach', '3', '76');
INSERT INTO `Reviews` VALUES ('Remove Synth Sub from Epididymis/Sperm Cord, Perc Endo', '1', '77');
INSERT INTO `Reviews` VALUES ('Detachment at Right Lower Arm, High, Open Approach', '5', '78');
INSERT INTO `Reviews` VALUES ('Repair Left 4th Toe, Open Approach', '4', '79');
INSERT INTO `Reviews` VALUES ('Fusion of L Acromioclav Jt with Autol Sub, Perc Approach', '4', '80');
INSERT INTO `Reviews` VALUES ('Chiropractic Manipulation of Head, Non-Manual', '5', '81');
INSERT INTO `Reviews` VALUES ('Removal of Intraluminal Device from Nose, Open Approach', '5', '82');
INSERT INTO `Reviews` VALUES ('Insertion of Airway into Esophagus, Endo', '4', '83');
INSERT INTO `Reviews` VALUES ('Drainage of Cervix with Drainage Device, Perc Approach', '1', '84');
INSERT INTO `Reviews` VALUES ('Insertion of Tissue Expander into R Breast, Perc Approach', '2', '85');
INSERT INTO `Reviews` VALUES ('Revision of Synth Sub in L Finger Phalanx, Extern Approach', '4', '86');
INSERT INTO `Reviews` VALUES ('Dilation of Jejunum, Percutaneous Endoscopic Approach', '4', '87');
INSERT INTO `Reviews` VALUES ('Reposition Right Renal Artery, Perc Endo Approach', '2', '88');
INSERT INTO `Reviews` VALUES ('Insert of Hybrid Ext Fix into L Humeral Head, Open Approach', '1', '89');
INSERT INTO `Reviews` VALUES ('Dilate L Com Iliac Art, Bifurc, w Drug-elut Intra, Perc', '4', '90');
INSERT INTO `Reviews` VALUES ('Excision of Right Common Iliac Artery, Percutaneous Approach', '4', '91');
INSERT INTO `Reviews` VALUES ('Release Left Shoulder Tendon, External Approach', '5', '92');
INSERT INTO `Reviews` VALUES ('Division of Right Knee Tendon, Perc Endo Approach', '2', '93');
INSERT INTO `Reviews` VALUES ('Dilation of L Popl Art with 4+ Intralum Dev, Open Approach', '3', '94');
INSERT INTO `Reviews` VALUES ('Inspection of Left Buttock, External Approach', '1', '95');
INSERT INTO `Reviews` VALUES ('Supplement R Up Extrem Lymph with Autol Sub, Open Approach', '4', '96');
INSERT INTO `Reviews` VALUES ('Replace of Back Subcu/Fascia with Synth Sub, Open Approach', '4', '97');
INSERT INTO `Reviews` VALUES ('Insertion of Cardiac Lead into R Atrium, Perc Endo Approach', '3', '98');
INSERT INTO `Reviews` VALUES ('Removal of Nonaut Sub from L Pelvic Bone, Perc Endo Approach', '1', '99');
INSERT INTO `Reviews` VALUES ('Repair Right Axillary Artery, Open Approach', '4', '100');

-- ----------------------------
-- Table structure for User
-- ----------------------------
DROP TABLE IF EXISTS `User`;
CREATE TABLE `User` (
  `Username` varchar(20) DEFAULT NULL,
  `Name` varchar(255) DEFAULT NULL,
  `Surname` varchar(255) DEFAULT NULL,
  `Email` varchar(255) DEFAULT NULL,
  `Password` varchar(255) DEFAULT NULL,
  `Apikey` varchar(255) DEFAULT NULL,
  `UserID` int(255) NOT NULL AUTO_INCREMENT,
  `Type` int(255) DEFAULT NULL,
  PRIMARY KEY (`UserID`),
  UNIQUE KEY `UsernameUniQ` (`Username`) USING BTREE,
  KEY `fk_User_User_type_1` (`Type`),
  CONSTRAINT `fk_User_User_type_1` FOREIGN KEY (`Type`) REFERENCES `User_type` (`UserTypeID`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=53 DEFAULT CHARSET=utf8mb4;

-- ----------------------------
-- Records of User
-- ----------------------------
INSERT INTO `User` VALUES ('1', 'Stjepan', 'Maricevic', 'copy.gene@gmail.com', '1', '1', '1', '1');
INSERT INTO `User` VALUES ('wgentric1d', 'Welsh', 'Gentric', 'wgentric1d@google.nl', 'iFb9Vwc', 'bf628b85-fcc6-4842-b721-55aaca98d618', '2', '2');
INSERT INTO `User` VALUES ('smushart0', 'Stevana', 'Mushart', 'smushart0@nationalgeographic.com', 'D20259P', '1045a0cf-d6d2-4cd7-aa4c-54bd80886c05', '3', '1');
INSERT INTO `User` VALUES ('ablondell1', 'Amalea', 'Blondell', 'ablondell1@examiner.com', 'saDBXZ6', 'c1dbc7b7-92d9-43e0-b809-11bc76971046', '4', '3');
INSERT INTO `User` VALUES ('llympany2', 'Lamond', 'Lympany', 'llympany2@indiatimes.com', '9OvyFkAO0w', '15c72f9f-460a-4df6-b4c6-5db3e17037a4', '5', '3');
INSERT INTO `User` VALUES ('bcheng3', 'Bay', 'Cheng', 'bcheng3@dion.ne.jp', 'fMK7FbzyVTQ', '471f3922-7172-4df4-b76d-2ab24d77bc94', '6', '2');
INSERT INTO `User` VALUES ('ablaskett4', 'Ardath', 'Blaskett', 'ablaskett4@cisco.com', 'AISP6RQQ', '34b7f62d-728e-41d8-ab12-96e6fa4a96f7', '7', '2');
INSERT INTO `User` VALUES ('kryton5', 'Kile', 'Ryton', 'kryton5@lulu.com', 'y4LpXtkX5AH6', 'd39b76ba-cab2-44d3-80ee-60009772acf7', '8', '1');
INSERT INTO `User` VALUES ('cstandbrooke6', 'Cori', 'Standbrooke', 'cstandbrooke6@bigcartel.com', 'PPKLPqBZE', 'b06cd48f-1fed-408b-abfb-c0f043f2e5f9', '9', '3');
INSERT INTO `User` VALUES ('cmckinna7', 'Chantalle', 'McKinna', 'cmckinna7@wired.com', '8Y7NWCd', '303af9e2-99ae-4297-9c64-f29e37f0bfd8', '10', '2');
INSERT INTO `User` VALUES ('kjaimez8', 'Katha', 'Jaimez', 'kjaimez8@cornell.edu', '58goqN3CJnq', '86076c18-6ac7-4ad3-a29e-50d77eb903c6', '11', '3');
INSERT INTO `User` VALUES ('lcresser9', 'Liz', 'Cresser', 'lcresser9@liveinternet.ru', 'gCOxyr', '33392887-a598-4a52-ad4e-81e0c79d4141', '12', '2');
INSERT INTO `User` VALUES ('rsorensena', 'Richard', 'Sorensen', 'rsorensena@about.com', 'LEPGwCYZFwZ', '23a2b724-6441-41a2-b8ca-c43f4fb34395', '13', '1');
INSERT INTO `User` VALUES ('adanielsb', 'Adriane', 'Daniels', 'adanielsb@webmd.com', 'q0OsA4REWQA', 'cecd7f5c-1653-47f1-80c5-452d3f1f8cac', '14', '3');
INSERT INTO `User` VALUES ('roswickc', 'Riane', 'Oswick', 'roswickc@whitehouse.gov', 'uTcXupqq', '770a48e1-db1f-4d3d-b8e2-884de70166b4', '15', '2');
INSERT INTO `User` VALUES ('hhuxtond', 'Hillary', 'Huxton', 'hhuxtond@hatena.ne.jp', 'Jq0DlrnmXH', '8cfd4567-6e2c-477d-bfc4-e16c978ecf00', '16', '2');
INSERT INTO `User` VALUES ('pblenkinsope', 'Paddie', 'Blenkinsop', 'pblenkinsope@apache.org', '47iUicBkGkZE', '03710ebc-bfaa-4a42-9d0e-5ac6096adf65', '17', '2');
INSERT INTO `User` VALUES ('bloisif', 'Bearnard', 'Loisi', 'bloisif@a8.net', 'vQbJbdCR', '0c61696e-5623-4a1a-9ed2-b371ea51fce5', '18', '3');
INSERT INTO `User` VALUES ('lgoodrumg', 'Lazaro', 'Goodrum', 'lgoodrumg@imageshack.us', 'W6eN0Jelv', '6519359a-3b7f-482d-97f0-5f51bfc4e616', '19', '3');
INSERT INTO `User` VALUES ('hgrayerh', 'Hetti', 'Grayer', 'hgrayerh@jiathis.com', 'fxQgLWijTXj', 'd6cfa764-a074-42f2-95e9-ae2339bccbdd', '20', '3');
INSERT INTO `User` VALUES ('hcaraheri', 'Homerus', 'Caraher', 'hcaraheri@wisc.edu', '0atmZbqXZAQj', '4847917c-9c21-43e2-a3b2-c0312d2476ea', '21', '3');
INSERT INTO `User` VALUES ('sbeardwellj', 'Steve', 'Beardwell', 'sbeardwellj@senate.gov', 'KfZAi8L', '9a934676-d53f-49f9-9c4f-9d3b54484cb4', '22', '2');
INSERT INTO `User` VALUES ('gblackaderk', 'Gracia', 'Blackader', 'gblackaderk@spiegel.de', 'LOLpg3Zcg8', '35fa5268-97e2-4133-9bf4-d937a00e4008', '23', '2');
INSERT INTO `User` VALUES ('aameerbegl', 'Augusta', 'Ameer-Beg', 'aameerbegl@foxnews.com', 'b2WO3Y', 'f86e4613-cb83-45ca-834e-1fa64e83adbc', '24', '2');
INSERT INTO `User` VALUES ('mbasekm', 'Morley', 'Basek', 'mbasekm@taobao.com', 'z2a8qa', '1a6b670b-c23d-44e0-9cb1-e2303953276d', '25', '1');
INSERT INTO `User` VALUES ('abasilen', 'Antonina', 'Basile', 'abasilen@hud.gov', 'vRVtfxrd', '644acd62-6da5-4126-830f-10278e308f59', '26', '2');
INSERT INTO `User` VALUES ('lkerro', 'Lidia', 'Kerr', 'lkerro@imdb.com', 'balOAuOGK', 'b3eda9a8-fab6-488e-9282-4adced0771f2', '27', '3');
INSERT INTO `User` VALUES ('bsavinp', 'Bernadene', 'Savin', 'bsavinp@cbc.ca', '0c4ZVqG1Iz2J', 'b312dc9b-9517-4e29-8b51-2fc2f3532b00', '28', '2');
INSERT INTO `User` VALUES ('ngettingsq', 'Nappie', 'Gettings', 'ngettingsq@github.com', 'rQNhZJZse', 'bf018a5c-98b3-421e-b948-505827271f27', '29', '3');
INSERT INTO `User` VALUES ('aderwinr', 'Abra', 'Derwin', 'aderwinr@usatoday.com', '8MsuwsEZb6', 'dc8b84b2-f311-4936-a05e-4ad84860c8c5', '30', '3');
INSERT INTO `User` VALUES ('agoforths', 'Anna', 'Goforth', 'agoforths@ucoz.com', 'VIsycLTDAj', '1370126f-1f40-4f0d-9ae2-d7191dc06c40', '31', '1');
INSERT INTO `User` VALUES ('bkofaxt', 'Boony', 'Kofax', 'bkofaxt@sphinn.com', '0VOsFALk', '88f109f7-101a-42dc-8a40-6c5d0728277e', '32', '1');
INSERT INTO `User` VALUES ('mmcspirronu', 'Magnum', 'McSpirron', 'mmcspirronu@umn.edu', 'aTzcNmlr', 'd5b97b14-795c-4db7-adea-05e250f898d0', '33', '2');
INSERT INTO `User` VALUES ('mblountv', 'Marybelle', 'Blount', 'mblountv@spiegel.de', 'oxldtCR', 'd359f197-0ad2-420c-a2f7-841b0fcaf768', '34', '2');
INSERT INTO `User` VALUES ('dpicotw', 'Dicky', 'Picot', 'dpicotw@cam.ac.uk', 'mMQIKVjf3pv', '388e0aa5-4713-43fc-8880-5351684e4009', '35', '1');
INSERT INTO `User` VALUES ('emaffionex', 'Emmy', 'Maffione', 'emaffionex@elegantthemes.com', 'dORswKf3cB', 'd7ef636e-ca57-4d31-b9f4-bc1927eb110e', '36', '2');
INSERT INTO `User` VALUES ('fgildeay', 'Felicio', 'Gildea', 'fgildeay@noaa.gov', 'QBhA7IJ5re', '3e318fa2-d1df-4904-b474-ea61ad0233b9', '37', '1');
INSERT INTO `User` VALUES ('lsturrorz', 'Leland', 'Sturror', 'lsturrorz@nhs.uk', 'vmi5p1V', '4b2177c0-171a-44b8-88a6-d2a47759e04d', '38', '3');
INSERT INTO `User` VALUES ('lanselmi10', 'Lauri', 'Anselmi', 'lanselmi10@weebly.com', 'j0pFfpFq0', '3c27637a-0890-4dd9-852b-8e4c0dae83fa', '39', '2');
INSERT INTO `User` VALUES ('nheliot11', 'Nola', 'Heliot', 'nheliot11@gravatar.com', 'aeAQA1bKtg1', 'bdbbc246-ad94-481e-80f2-caa40e155d4a', '40', '3');
INSERT INTO `User` VALUES ('middiens12', 'Mora', 'Iddiens', 'middiens12@nasa.gov', 'vdVzwj1w9', 'ea7cc825-5642-4e26-a122-937f602c68fc', '41', '3');
INSERT INTO `User` VALUES ('hroly13', 'Hortensia', 'Roly', 'hroly13@apple.com', '7ghDgh', '86a9bbb4-1e3b-4f5d-bb58-c24210326948', '42', '1');
INSERT INTO `User` VALUES ('rgraalmans14', 'Renelle', 'Graalmans', 'rgraalmans14@oracle.com', 'k4uPkAQ1PR', '3d4430d6-2017-4daf-8352-94bc3418ad59', '43', '3');
INSERT INTO `User` VALUES ('fconklin15', 'Flora', 'Conklin', 'fconklin15@gnu.org', 'h5aZksZy7', 'a7800722-bfd1-4da9-ba4b-e659a621940d', '44', '3');
INSERT INTO `User` VALUES ('dreneke16', 'Dorothee', 'Reneke', 'dreneke16@list-manage.com', 'q0m02MnC3tE', '46d03882-12b2-4526-aade-036d3ecc97e2', '45', '1');
INSERT INTO `User` VALUES ('hkeerl17', 'Heather', 'Keerl', 'hkeerl17@google.fr', 'EjkcCgJ4', '2ed52625-7bf7-4dfd-a748-dbd9fc350b3b', '46', '2');
INSERT INTO `User` VALUES ('ekaesmakers18', 'Ebba', 'Kaesmakers', 'ekaesmakers18@wufoo.com', '7OJgA1', '27edc6a5-06c3-46ca-9e1f-918d1289f3d5', '47', '1');
INSERT INTO `User` VALUES ('phay19', 'Petey', 'Hay', 'phay19@dmoz.org', 'GSGWQfA9', 'e65ce796-64a2-47a2-9dd3-49d23192040a', '48', '3');
INSERT INTO `User` VALUES ('asilverton1a', 'Amber', 'Silverton', 'asilverton1a@prnewswire.com', 'vEYMLhytSrr', '652018d2-55e9-4252-8e8d-402d9eeda0c9', '49', '3');
INSERT INTO `User` VALUES ('fdocharty1b', 'Felizio', 'Docharty', 'fdocharty1b@wikia.com', 'v08pgLMVsxve', '118017c6-89ff-418a-a218-66b9751f7685', '50', '2');
INSERT INTO `User` VALUES ('owooldridge1c', 'Odelle', 'Wooldridge', 'owooldridge1c@redcross.org', '644WVm', '736f0e13-7434-463e-a67d-98a5304cba64', '51', '2');

-- ----------------------------
-- Table structure for User_type
-- ----------------------------
DROP TABLE IF EXISTS `User_type`;
CREATE TABLE `User_type` (
  `UserTypeID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`UserTypeID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4;

-- ----------------------------
-- Records of User_type
-- ----------------------------
INSERT INTO `User_type` VALUES ('1', 'Admin');
INSERT INTO `User_type` VALUES ('2', 'Moderator');
INSERT INTO `User_type` VALUES ('3', 'User');
