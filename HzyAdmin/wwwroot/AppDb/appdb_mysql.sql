/*
Navicat MySQL Data Transfer

Source Server         : mysql_conn
Source Server Version : 50714
Source Host           : localhost:3306
Source Database       : appdb

Target Server Type    : MYSQL
Target Server Version : 50714
File Encoding         : 65001

Date: 2018-12-01 11:34:46
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `member`
-- ----------------------------
DROP TABLE IF EXISTS `member`;
CREATE TABLE `member` (
  `Member_ID` varchar(50) NOT NULL,
  `Member_Num` varchar(50) DEFAULT NULL,
  `Member_Name` varchar(50) DEFAULT NULL,
  `Member_Phone` varchar(50) DEFAULT NULL,
  `Member_Sex` varchar(10) DEFAULT NULL,
  `Member_Birthday` datetime DEFAULT NULL,
  `Member_Photo` varchar(200) DEFAULT NULL,
  `Member_UserID` varchar(50) DEFAULT NULL,
  `Member_Introduce` text,
  `Member_FilePath` varchar(200) DEFAULT NULL,
  `Member_CreateTime` datetime DEFAULT NULL,
  PRIMARY KEY (`Member_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of member
-- ----------------------------
INSERT INTO `member` VALUES ('9a604aa2-9ae6-4a2f-8ddb-d9e0289ead9e', '1', '测试会员', '131231', '男', '2018-04-25 00:00:00', '/Content/UpFile/89da9231-427c-47a6-8f68-642caa134b43.jpg', 'a7eae7ab-0de4-4026-8da9-6529f8a1c3e2', '<p>1231231<img src=\"/Resource/Admin/lib/neditor/net/upload/image/20180629/6366588141156673624264764.png\" alt=\"login2.png\"/><img src=\"/Admin/lib/nUeditor/upload/image/20180704/6366629778310116875946386.png\" alt=\"1242080_hao-zhi-ying.png\"/></p>', '/Content/UpFile/fc0ef283-b8c1-4fcf-851c-51141a2be661.txt', '2018-11-30 14:52:10');

-- ----------------------------
-- Table structure for `sys_function`
-- ----------------------------
DROP TABLE IF EXISTS `sys_function`;
CREATE TABLE `sys_function` (
  `Function_ID` varchar(50) NOT NULL,
  `Function_Num` varchar(50) DEFAULT NULL,
  `Function_Name` varchar(50) DEFAULT NULL,
  `Function_ByName` varchar(50) DEFAULT NULL,
  `Function_CreateTime` datetime DEFAULT NULL,
  PRIMARY KEY (`Function_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_function
-- ----------------------------
INSERT INTO `sys_function` VALUES ('e7ef2a05-8317-41c3-b588-99519fe88bf9', '30', '修改', 'Edit', '2018-11-30 14:59:28');
INSERT INTO `sys_function` VALUES ('2401f4d0-60b0-4e2e-903f-84c603373572', '70', '导出', 'GetExcel', '2018-11-30 14:59:46');
INSERT INTO `sys_function` VALUES ('bffefb1c-8988-4ddf-b4ac-81c2b30e80cd', '20', '添加', 'Add', '2018-11-30 14:59:51');
INSERT INTO `sys_function` VALUES ('9c388461-2704-4c5e-a729-72c17e9018e1', '40', '删除', 'Delete', '2018-11-30 14:59:55');
INSERT INTO `sys_function` VALUES ('383e7ee2-7690-46ac-9230-65155c84aa30', '50', '保存', 'Save', '2018-11-30 15:00:01');
INSERT INTO `sys_function` VALUES ('f27ecb0a-197d-47b1-b243-59a8c71302bf', '60', '检索', 'Search', '2018-11-30 15:00:05');
INSERT INTO `sys_function` VALUES ('c9518758-b2e1-4f51-b517-5282e273889c', '10', '能否拥有该菜单', 'Have', '2018-11-30 15:00:10');
INSERT INTO `sys_function` VALUES ('b6fd5425-504a-46a9-993b-2f8dc9158eb8', '80', '打印', 'Print', '2018-11-30 15:00:15');

-- ----------------------------
-- Table structure for `sys_menu`
-- ----------------------------
DROP TABLE IF EXISTS `sys_menu`;
CREATE TABLE `sys_menu` (
  `Menu_ID` varchar(50) NOT NULL,
  `Menu_Num` varchar(50) DEFAULT NULL,
  `Menu_Name` varchar(50) DEFAULT NULL,
  `Menu_Url` varchar(50) DEFAULT NULL,
  `Menu_Icon` varchar(50) DEFAULT NULL,
  `Menu_ParentID` varchar(50) DEFAULT NULL,
  `Menu_CreateTime` datetime DEFAULT NULL,
  PRIMARY KEY (`Menu_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_menu
-- ----------------------------
INSERT INTO `sys_menu` VALUES ('4ce21a81-1cae-44d2-b29e-07058ff04b3e', 'Z-160', '代码创建', '/Admin/CreateCode/Index', null, '9591f249-1471-44f7-86b5-6fdae8b93888', '2018-11-30 15:05:43');
INSERT INTO `sys_menu` VALUES ('e5d4da6b-aab0-4aaa-982f-43673e8152c0', 'Z-130', '菜单功能', '/Admin/MenuFunction/Index', null, '9591f249-1471-44f7-86b5-6fdae8b93888', '2018-11-30 15:05:49');
INSERT INTO `sys_menu` VALUES ('d721fc55-2174-40eb-bb37-5c54a158525a', 'Z-120', '功能管理', '/Admin/Function/Index', null, '9591f249-1471-44f7-86b5-6fdae8b93888', '2018-11-30 15:05:54');
INSERT INTO `sys_menu` VALUES ('9591f249-1471-44f7-86b5-6fdae8b93888', 'Z', '系统管理', null, 'fa fa-desktop', null, '2018-11-30 15:05:59');
INSERT INTO `sys_menu` VALUES ('38d864ff-f6e7-43af-8c5c-8bbcf9fa586d', 'Z-100', '用户管理', '/Admin/User/Index', null, '9591f249-1471-44f7-86b5-6fdae8b93888', '2018-11-30 15:06:04');
INSERT INTO `sys_menu` VALUES ('bd024f3a-99a7-4407-861c-a016f243f222', 'Z-140', '角色功能', '/Admin/RoleFunction/Index', null, '9591f249-1471-44f7-86b5-6fdae8b93888', '2018-11-30 15:06:09');
INSERT INTO `sys_menu` VALUES ('7c34c2fd-98ed-4655-aa04-bb00b915a751', 'A-100', '会员管理', '/Admin/Member/Index?id=1', null, '1ec76c4c-b9b3-4517-9854-f08cd11d653d', '2018-11-30 15:06:13');
INSERT INTO `sys_menu` VALUES ('60ae9382-31ab-4276-a379-d3876e9bb783', 'Z-110', '角色管理', '/Admin/Role/Index', null, '9591f249-1471-44f7-86b5-6fdae8b93888', '2018-11-30 15:06:18');
INSERT INTO `sys_menu` VALUES ('f35d64ae-ecb7-4d06-acfb-d91595966d9e', 'Z-150', '修改密码', '/Admin/ChangePwd/Index', null, '9591f249-1471-44f7-86b5-6fdae8b93888', '2018-11-30 15:06:23');
INSERT INTO `sys_menu` VALUES ('1ec76c4c-b9b3-4517-9854-f08cd11d653d', 'A', '基础信息', null, 'fa fa-cubes', null, '2018-11-30 15:06:29');

-- ----------------------------
-- Table structure for `sys_menufunction`
-- ----------------------------
DROP TABLE IF EXISTS `sys_menufunction`;
CREATE TABLE `sys_menufunction` (
  `MenuFunction_ID` varchar(50) NOT NULL,
  `MenuFunction_MenuID` varchar(50) DEFAULT NULL,
  `MenuFunction_FunctionID` varchar(50) DEFAULT NULL,
  `MenuFunction_CreateTime` datetime DEFAULT NULL,
  PRIMARY KEY (`MenuFunction_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_menufunction
-- ----------------------------
INSERT INTO `sys_menufunction` VALUES ('58d55c9f-eb0b-4e37-8729-018ba15add24', '7c34c2fd-98ed-4655-aa04-bb00b915a751', '2401f4d0-60b0-4e2e-903f-84c603373572', '2018-11-30 15:31:40');
INSERT INTO `sys_menufunction` VALUES ('c52908ae-68a7-447d-862a-1691e9191f46', '7c34c2fd-98ed-4655-aa04-bb00b915a751', '9c388461-2704-4c5e-a729-72c17e9018e1', '2018-11-30 15:31:54');
INSERT INTO `sys_menufunction` VALUES ('f7f796cd-7eef-44e5-8b72-16bbb103513d', '60ae9382-31ab-4276-a379-d3876e9bb783', '2401f4d0-60b0-4e2e-903f-84c603373572', '2018-11-30 15:31:59');
INSERT INTO `sys_menufunction` VALUES ('cbb4517a-d0a8-4c9e-a59f-18d6b88a5457', '7c34c2fd-98ed-4655-aa04-bb00b915a751', 'e7ef2a05-8317-41c3-b588-99519fe88bf9', '2018-11-30 15:32:05');
INSERT INTO `sys_menufunction` VALUES ('a49b958c-f00c-4c0d-b031-21190e5c74fa', 'f35d64ae-ecb7-4d06-acfb-d91595966d9e', 'c9518758-b2e1-4f51-b517-5282e273889c', '2018-11-30 15:32:10');
INSERT INTO `sys_menufunction` VALUES ('9c195f15-166f-41b6-969c-3fc1a7b16126', '38d864ff-f6e7-43af-8c5c-8bbcf9fa586d', '9c388461-2704-4c5e-a729-72c17e9018e1', '2018-11-30 15:32:14');
INSERT INTO `sys_menufunction` VALUES ('5851d23f-7de2-48b1-8340-4feef46b8a76', '60ae9382-31ab-4276-a379-d3876e9bb783', '9c388461-2704-4c5e-a729-72c17e9018e1', '2018-11-30 15:32:19');
INSERT INTO `sys_menufunction` VALUES ('f933b4df-e994-4366-916a-55610dab5d5e', '60ae9382-31ab-4276-a379-d3876e9bb783', '383e7ee2-7690-46ac-9230-65155c84aa30', '2018-11-30 15:32:23');
INSERT INTO `sys_menufunction` VALUES ('02061825-c0bd-4fa4-a2ea-57f57602c243', '7c34c2fd-98ed-4655-aa04-bb00b915a751', 'bffefb1c-8988-4ddf-b4ac-81c2b30e80cd', '2018-11-30 15:32:28');
INSERT INTO `sys_menufunction` VALUES ('5fa5c451-d682-459d-a148-5b9753e976d3', '60ae9382-31ab-4276-a379-d3876e9bb783', 'f27ecb0a-197d-47b1-b243-59a8c71302bf', '2018-11-30 15:32:32');
INSERT INTO `sys_menufunction` VALUES ('ceaf3543-525d-4b42-a6ff-64c9e602198e', '7c34c2fd-98ed-4655-aa04-bb00b915a751', 'f27ecb0a-197d-47b1-b243-59a8c71302bf', '2018-11-30 15:32:37');
INSERT INTO `sys_menufunction` VALUES ('45a6399c-5b26-4a47-9957-8ac8cb0c1ff7', '38d864ff-f6e7-43af-8c5c-8bbcf9fa586d', 'bffefb1c-8988-4ddf-b4ac-81c2b30e80cd', '2018-11-30 15:32:42');
INSERT INTO `sys_menufunction` VALUES ('779246d1-84ce-4daf-9a49-8fa4abb31404', '38d864ff-f6e7-43af-8c5c-8bbcf9fa586d', '383e7ee2-7690-46ac-9230-65155c84aa30', '2018-11-30 15:32:47');
INSERT INTO `sys_menufunction` VALUES ('7baab27f-74cc-4eb3-9d04-9e72f0cc8a94', '38d864ff-f6e7-43af-8c5c-8bbcf9fa586d', 'e7ef2a05-8317-41c3-b588-99519fe88bf9', '2018-11-30 15:32:51');
INSERT INTO `sys_menufunction` VALUES ('bb14769d-4760-4341-9faf-9fa82eeada65', '2ff9bb67-aa42-48cf-80c9-6d1cfb6b1ead', 'e7ef2a05-8317-41c3-b588-99519fe88bf9', '2018-11-30 15:32:57');
INSERT INTO `sys_menufunction` VALUES ('7861b618-0b12-4a56-abda-a5e8d17ac5d7', '2ff9bb67-aa42-48cf-80c9-6d1cfb6b1ead', 'bffefb1c-8988-4ddf-b4ac-81c2b30e80cd', '2018-11-30 15:33:02');
INSERT INTO `sys_menufunction` VALUES ('177ce01f-add8-4fd5-a2a6-a652803b0f38', '60ae9382-31ab-4276-a379-d3876e9bb783', 'bffefb1c-8988-4ddf-b4ac-81c2b30e80cd', '2018-11-30 15:33:07');
INSERT INTO `sys_menufunction` VALUES ('16cee2be-61db-4129-ba17-ad9f87167d37', '60ae9382-31ab-4276-a379-d3876e9bb783', 'e7ef2a05-8317-41c3-b588-99519fe88bf9', '2018-11-30 15:33:12');
INSERT INTO `sys_menufunction` VALUES ('ed266ed2-b722-4ecb-80d2-aee8ce94686a', '38d864ff-f6e7-43af-8c5c-8bbcf9fa586d', '2401f4d0-60b0-4e2e-903f-84c603373572', '2018-11-30 15:33:18');
INSERT INTO `sys_menufunction` VALUES ('aaa679ce-d68c-4563-b485-b5af5e3cd9b9', '38d864ff-f6e7-43af-8c5c-8bbcf9fa586d', 'f27ecb0a-197d-47b1-b243-59a8c71302bf', '2018-11-30 15:33:23');
INSERT INTO `sys_menufunction` VALUES ('f01a4a07-89fd-4324-bc72-c2fe144b7974', '7c34c2fd-98ed-4655-aa04-bb00b915a751', '383e7ee2-7690-46ac-9230-65155c84aa30', '2018-11-30 15:33:29');
INSERT INTO `sys_menufunction` VALUES ('0962a398-d4a5-455e-8d2f-c7c6b41fc9cf', '38d864ff-f6e7-43af-8c5c-8bbcf9fa586d', 'c9518758-b2e1-4f51-b517-5282e273889c', '2018-11-30 15:33:35');
INSERT INTO `sys_menufunction` VALUES ('259c0396-8390-4632-be02-d02dc1c17123', 'bd024f3a-99a7-4407-861c-a016f243f222', 'c9518758-b2e1-4f51-b517-5282e273889c', '2018-11-30 15:33:40');
INSERT INTO `sys_menufunction` VALUES ('b9776939-9f52-4938-be8a-e4b57d2503bf', '60ae9382-31ab-4276-a379-d3876e9bb783', 'c9518758-b2e1-4f51-b517-5282e273889c', '2018-11-30 15:33:46');
INSERT INTO `sys_menufunction` VALUES ('a70da34c-b1e6-48cf-a2de-f8d5b7b21324', '7c34c2fd-98ed-4655-aa04-bb00b915a751', 'c9518758-b2e1-4f51-b517-5282e273889c', '2018-11-30 15:33:52');

-- ----------------------------
-- Table structure for `sys_number`
-- ----------------------------
DROP TABLE IF EXISTS `sys_number`;
CREATE TABLE `sys_number` (
  `Number_ID` varchar(50) NOT NULL,
  `Number_Num` varchar(50) DEFAULT NULL,
  `Number_DataBase` varchar(50) DEFAULT NULL,
  `Number_TableName` varchar(50) DEFAULT NULL,
  `Number_NumField` varchar(50) DEFAULT NULL,
  `Number_CreateTime` datetime DEFAULT NULL,
  PRIMARY KEY (`Number_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_number
-- ----------------------------
INSERT INTO `sys_number` VALUES ('b5fcc999-85b9-4dce-a3fc-64b43ef82f68', '1', null, 'Member', 'Member_Num', '2018-11-30 15:35:07');

-- ----------------------------
-- Table structure for `sys_role`
-- ----------------------------
DROP TABLE IF EXISTS `sys_role`;
CREATE TABLE `sys_role` (
  `Role_ID` varchar(50) NOT NULL,
  `Role_Num` varchar(50) DEFAULT NULL,
  `Role_Name` varchar(50) DEFAULT NULL,
  `Role_Remark` varchar(100) DEFAULT NULL,
  `Role_IsDelete` int(1) DEFAULT NULL,
  `Role_CreateTime` datetime DEFAULT NULL,
  PRIMARY KEY (`Role_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_role
-- ----------------------------
INSERT INTO `sys_role` VALUES ('18fa4771-6f58-46a3-80d2-6f0f5e9972e3', '0001', '超级管理员', '拥有所有权限', '2', '2018-11-30 15:37:04');
INSERT INTO `sys_role` VALUES ('40ff1844-c099-4061-98e0-cd6e544fcfd3', '0002', '普通用户', null, '1', '2018-11-30 15:37:11');

-- ----------------------------
-- Table structure for `sys_rolemenufunction`
-- ----------------------------
DROP TABLE IF EXISTS `sys_rolemenufunction`;
CREATE TABLE `sys_rolemenufunction` (
  `RoleMenuFunction_ID` varchar(50) NOT NULL,
  `RoleMenuFunction_RoleID` varchar(50) DEFAULT NULL,
  `RoleMenuFunction_FunctionID` varchar(50) DEFAULT NULL,
  `RoleMenuFunction_MenuID` varchar(50) DEFAULT NULL,
  `RoleMenuFunction_CreateTime` datetime DEFAULT NULL,
  PRIMARY KEY (`RoleMenuFunction_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_rolemenufunction
-- ----------------------------
INSERT INTO `sys_rolemenufunction` VALUES ('a3979835-1be7-4c57-888c-0c1d2d7f47bb', '40ff1844-c099-4061-98e0-cd6e544fcfd3', 'f27ecb0a-197d-47b1-b243-59a8c71302bf', '38d864ff-f6e7-43af-8c5c-8bbcf9fa586d', '2018-11-30 15:39:41');
INSERT INTO `sys_rolemenufunction` VALUES ('9e747fd5-a9ab-4b54-8ce7-4a7c565a2a9c', '40ff1844-c099-4061-98e0-cd6e544fcfd3', 'c9518758-b2e1-4f51-b517-5282e273889c', '38d864ff-f6e7-43af-8c5c-8bbcf9fa586d', '2018-11-30 15:39:45');
INSERT INTO `sys_rolemenufunction` VALUES ('25945f65-b9fb-42d9-b6f8-82e43467ca58', '40ff1844-c099-4061-98e0-cd6e544fcfd3', 'c9518758-b2e1-4f51-b517-5282e273889c', 'f35d64ae-ecb7-4d06-acfb-d91595966d9e', '2018-11-30 15:39:51');
INSERT INTO `sys_rolemenufunction` VALUES ('72865097-bc7b-4385-b7e8-920f9d4306ce', '40ff1844-c099-4061-98e0-cd6e544fcfd3', 'c9518758-b2e1-4f51-b517-5282e273889c', '7c34c2fd-98ed-4655-aa04-bb00b915a751', '2018-11-30 15:39:57');
INSERT INTO `sys_rolemenufunction` VALUES ('860d2eb8-a2b1-4bb5-876b-be31f0d8eda1', '40ff1844-c099-4061-98e0-cd6e544fcfd3', '383e7ee2-7690-46ac-9230-65155c84aa30', '38d864ff-f6e7-43af-8c5c-8bbcf9fa586d', '2018-11-30 15:40:01');
INSERT INTO `sys_rolemenufunction` VALUES ('636b2efd-d85e-45f9-92a6-cba30e3e44e6', '40ff1844-c099-4061-98e0-cd6e544fcfd3', 'e7ef2a05-8317-41c3-b588-99519fe88bf9', '38d864ff-f6e7-43af-8c5c-8bbcf9fa586d', '2018-11-30 15:40:06');

-- ----------------------------
-- Table structure for `sys_user`
-- ----------------------------
DROP TABLE IF EXISTS `sys_user`;
CREATE TABLE `sys_user` (
  `User_ID` varchar(50) NOT NULL,
  `User_Name` varchar(50) DEFAULT NULL,
  `User_LoginName` varchar(50) DEFAULT NULL,
  `User_Pwd` varchar(50) DEFAULT NULL,
  `User_Email` varchar(50) DEFAULT NULL,
  `User_IsDelete` int(1) DEFAULT NULL,
  `User_CreateTime` datetime DEFAULT NULL,
  PRIMARY KEY (`User_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_user
-- ----------------------------
INSERT INTO `sys_user` VALUES ('0198459e-2034-4533-b843-5d227ad20740', '管理员', 'admin', '123', '1396510655@qq.com', '2', '2018-11-30 15:41:30');
INSERT INTO `sys_user` VALUES ('a7eae7ab-0de4-4026-8da9-6529f8a1c3e2', '普通用户', 'user', '123', null, '1', '2018-11-30 15:41:36');

-- ----------------------------
-- Table structure for `sys_userrole`
-- ----------------------------
DROP TABLE IF EXISTS `sys_userrole`;
CREATE TABLE `sys_userrole` (
  `UserRole_ID` varchar(50) NOT NULL,
  `UserRole_UserID` varchar(50) DEFAULT NULL,
  `UserRole_RoleID` varchar(50) DEFAULT NULL,
  `UserRole_CreateTime` datetime DEFAULT NULL,
  PRIMARY KEY (`UserRole_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_userrole
-- ----------------------------
INSERT INTO `sys_userrole` VALUES ('3a20ab84-cb46-47b9-a1de-34cf14b71c6f', '0198459e-2034-4533-b843-5d227ad20740', '18fa4771-6f58-46a3-80d2-6f0f5e9972e3', '2018-11-30 15:42:42');
INSERT INTO `sys_userrole` VALUES ('a3ddf66d-49ff-4981-8090-9caa326e13f9', 'a7eae7ab-0de4-4026-8da9-6529f8a1c3e2', '40ff1844-c099-4061-98e0-cd6e544fcfd3', '2018-11-30 15:42:46');
