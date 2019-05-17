/*
Navicat MySQL Data Transfer

Source Server         : ckb-DB
Source Server Version : 50711
Source Host           : localhost:3306
Source Database       : jxcar

Target Server Type    : MYSQL
Target Server Version : 50711
File Encoding         : 65001

Date: 2019-05-09 21:14:20
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `checkinfo`
-- ----------------------------
DROP TABLE IF EXISTS `checkinfo`;
CREATE TABLE `checkinfo` (
  `RecordId` int(11) DEFAULT NULL,
  `TesterNO` varchar(50) DEFAULT NULL,
  `TesterName` varchar(50) DEFAULT NULL,
  `BeginTime` timestamp NULL DEFAULT NULL,
  `EndTime` timestamp NULL DEFAULT NULL,
  `TestTimes` int(11) DEFAULT NULL,
  `Score` varchar(50) DEFAULT NULL,
  `CheckerNO` varchar(20) DEFAULT NULL,
  `CheckerName` varchar(50) DEFAULT NULL,
  `Memo` longtext
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of checkinfo
-- ----------------------------
INSERT INTO `checkinfo` VALUES ('1', '20141220', '张三', '2014-12-24 08:00:00', '2014-12-24 09:30:00', '3', '8.5', '20141224', '国泰安', '提示信息');
INSERT INTO `checkinfo` VALUES ('4', '20141220', '张三', '2014-12-24 08:00:00', '2014-12-24 09:30:00', '3', '8.5', '20141224', '国泰安', '提示信息');
INSERT INTO `checkinfo` VALUES ('26', '20141220', 'ckb', '2015-02-11 11:16:28', '2015-02-11 11:17:37', '0', '3', '200901800', '程坤波', null);
INSERT INTO `checkinfo` VALUES ('27', '20141220', 'ckb', '2015-02-11 11:33:37', '2015-02-11 11:34:27', '0', '3', '200901800', '程坤波', null);
INSERT INTO `checkinfo` VALUES ('28', '20141220', 'ckb', '2015-02-11 14:16:46', '2015-02-11 14:17:46', '0', '1', '200901800', '程坤波', null);
INSERT INTO `checkinfo` VALUES ('29', '20141220', 'ckb', '2015-02-11 14:22:12', '2015-02-11 14:22:49', '0', '1', '200901800', '程坤波', null);
INSERT INTO `checkinfo` VALUES ('30', '20141220', 'ckb', '2015-02-11 15:34:11', '2015-02-11 15:37:06', '0', '1', '200901800', '程坤波', null);
INSERT INTO `checkinfo` VALUES ('66', '20141220', 'ckb', '2015-03-02 15:00:18', '2015-03-02 15:01:00', '4', '1', '200901800', '程坤波', null);
INSERT INTO `checkinfo` VALUES ('67', '20141220', 'ckb', '2015-03-02 15:06:24', '2015-03-02 15:06:59', '4', '1', '200901800', '程坤波', null);
INSERT INTO `checkinfo` VALUES ('68', '20141220', 'ckb', '2015-03-02 15:09:30', '2015-03-02 15:10:04', '4', '0', '200901800', '程坤波', null);
INSERT INTO `checkinfo` VALUES ('69', '20141220', 'ckb', '2015-03-02 15:16:22', '2015-03-02 15:17:00', '4', '1', '200901800', '程坤波', null);
INSERT INTO `checkinfo` VALUES ('70', '20141220', 'ckb', '2015-03-02 15:23:12', '2015-03-02 15:24:01', '4', '2', '200901800', '程坤波', null);
INSERT INTO `checkinfo` VALUES ('71', '20141220', 'ckb', '2015-03-03 16:03:59', '2015-03-03 16:04:58', '4', '2', '200901800', '程坤波', null);
INSERT INTO `checkinfo` VALUES ('72', '20141220', 'ckb', '2015-12-15 22:59:22', '2015-12-15 23:00:02', '3', '1', '200901800', '程坤波', '');

-- ----------------------------
-- Table structure for `faultpattern`
-- ----------------------------
DROP TABLE IF EXISTS `faultpattern`;
CREATE TABLE `faultpattern` (
  `OrderId` int(11) DEFAULT NULL,
  `OrderName` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of faultpattern
-- ----------------------------
INSERT INTO `faultpattern` VALUES ('1', '通路');
INSERT INTO `faultpattern` VALUES ('2', '断路');
INSERT INTO `faultpattern` VALUES ('3', '不稳定状态');
INSERT INTO `faultpattern` VALUES ('4', '虚接');
INSERT INTO `faultpattern` VALUES ('5', '短路');

-- ----------------------------
-- Table structure for `faultpoint`
-- ----------------------------
DROP TABLE IF EXISTS `faultpoint`;
CREATE TABLE `faultpoint` (
  `Id` int(11) DEFAULT NULL,
  `Name` varchar(100) DEFAULT NULL,
  `ModuleId` int(11) DEFAULT NULL,
  `PatternList` varchar(50) DEFAULT NULL,
  `NormalIsBreak` tinyint(1) DEFAULT NULL,
  `PointMemo` longtext
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of faultpoint
-- ----------------------------
INSERT INTO `faultpoint` VALUES ('1', '发动机转速信号线路', '1', '1,2,3,4,5', '0', null);
INSERT INTO `faultpoint` VALUES ('2', '2缸点火控制信号线路', '1', '1,2,3,4', '0', null);
INSERT INTO `faultpoint` VALUES ('3', '4缸点火控制信号线路', '1', '1,2,3,4', '0', null);
INSERT INTO `faultpoint` VALUES ('1', '燃油泵继电器控制线路', '2', '1,2,3,4,5', '0', '');
INSERT INTO `faultpoint` VALUES ('2', '1缸喷油嘴控制线路', '2', '1,2,3,4', '0', null);
INSERT INTO `faultpoint` VALUES ('3', '3缸喷油嘴控制线路', '2', '1,2,3,4', '0', null);
INSERT INTO `faultpoint` VALUES ('1', '节气门角度传感器1信号线路', '3', '1,2,3,4,5', '0', '');
INSERT INTO `faultpoint` VALUES ('2', '节气门角度传感器信号线路', '3', '1,2,3,4,5', '0', null);
INSERT INTO `faultpoint` VALUES ('3', '油门踏板位置传感器2 信号线路', '3', '1,2,3,4,5', '0', '');
INSERT INTO `faultpoint` VALUES ('4', '油门踏板位置传感器信号线路', '3', '1,2,3,4,5', '0', null);
INSERT INTO `faultpoint` VALUES ('1', '进气压力传感器信号线路', '4', '1,2,3,4,5', '0', '');
INSERT INTO `faultpoint` VALUES ('2', '进气温度传感器信号线路', '4', '1,2,3,4,5', '0', null);
INSERT INTO `faultpoint` VALUES ('3', '冷却液温度传器信号线路', '4', '1,2,3,4,5', '0', null);
INSERT INTO `faultpoint` VALUES ('1', '后氧传感器信号线路', '5', '1,2,3,4,5', '0', '');
INSERT INTO `faultpoint` VALUES ('2', '前氧传感器信号线路', '5', '1,2,3,4,5', '0', null);
INSERT INTO `faultpoint` VALUES ('1', '活性炭罐电磁阀控制线路', '6', '1,2,3,4', '0', '');
INSERT INTO `faultpoint` VALUES ('2', '爆震传感器信号线路', '6', '1,2,3,4,5', '0', null);
INSERT INTO `faultpoint` VALUES ('3', '霍尔传感器信号线路', '6', '1,2,3,4,5', '0', null);
INSERT INTO `faultpoint` VALUES ('1', '输入转速传感器信号线路', '7', '1,2,3,4,5', '0', '');
INSERT INTO `faultpoint` VALUES ('2', '输出转速传感器信号线路', '7', '1,2,3,4,5', '0', null);
INSERT INTO `faultpoint` VALUES ('3', '齿轮油温度传感器信号线路', '7', '1,2,3,4,5', '0', null);
INSERT INTO `faultpoint` VALUES ('4', '多功能开关信号线路', '7', '1,2,3,4', '0', null);
INSERT INTO `faultpoint` VALUES ('1', '空调继电器控制线路', '8', '1,2,3,4', '0', '');
INSERT INTO `faultpoint` VALUES ('2', '空调高压传感器信号线路', '8', '1,2,3,4,5', '0', null);
INSERT INTO `faultpoint` VALUES ('3', '空调器ECU和发动机ECU信号线', '8', '1,2,3,4', '0', null);
INSERT INTO `faultpoint` VALUES ('4', '蒸发器出风口温度传感器线路 ', '8', '1,2,3,4,5', '0', null);
INSERT INTO `faultpoint` VALUES ('1', '鼓风机开关三档线路', '9', '1,2,3', '1', '');
INSERT INTO `faultpoint` VALUES ('2', '鼓风机电阻一档线路', '9', '1,2,3', '1', null);
INSERT INTO `faultpoint` VALUES ('1', '左前转速传感器线路', '10', '1,2,3,4,5', '0', '');
INSERT INTO `faultpoint` VALUES ('2', '左后转速传感器线路', '10', '1,2,3,4,5', '0', null);
INSERT INTO `faultpoint` VALUES ('3', '右后转速传感器线路', '10', '1,2,3,4,5', '0', null);
INSERT INTO `faultpoint` VALUES ('4', 'ABS系统 CAN-L线路', '10', '1,2,3', '0', null);
INSERT INTO `faultpoint` VALUES ('1', '组合仪表CAN-H线路', '11', '1,2,3', '0', '');
INSERT INTO `faultpoint` VALUES ('2', '燃油存量传感器线路', '11', '1,2,3,4,5', '0', null);
INSERT INTO `faultpoint` VALUES ('3', '车外温度传感器线路', '11', '1,2,3,4,5', '0', null);
INSERT INTO `faultpoint` VALUES ('4', '机油油压开关线路', '11', '1,2,3,4,5', '0', null);
INSERT INTO `faultpoint` VALUES ('1', '左前低音喇叭线路', '12', '1,2,3', '1', '');
INSERT INTO `faultpoint` VALUES ('2', '右前低音喇叭线路', '12', '1,2,3', '1', null);
INSERT INTO `faultpoint` VALUES ('1', '左转向开关信号线路', '13', '1,2,3,5', '0', '');
INSERT INTO `faultpoint` VALUES ('2', '左转向开关信号线路', '13', '1,2,3,5', '0', null);
INSERT INTO `faultpoint` VALUES ('3', '危险警告灯开关信号线路', '13', '1,2,3', '0', null);
INSERT INTO `faultpoint` VALUES ('4', '右侧转向信号灯线路', '13', '1,2,3', '1', null);
INSERT INTO `faultpoint` VALUES ('1', '倒车灯线路', '14', '1,2,3', '1', '');
INSERT INTO `faultpoint` VALUES ('2', '制动灯线路', '14', '1,2,3', '1', null);
INSERT INTO `faultpoint` VALUES ('3', '刹车制动信号线路', '14', '1,2,3', '0', null);
INSERT INTO `faultpoint` VALUES ('1', '驾驶员侧中央门锁开关线路', '16', '1,2,3,4', '0', '');
INSERT INTO `faultpoint` VALUES ('2', '左后车窗升降开关线路', '16', '1,2,3,4', '0', null);
INSERT INTO `faultpoint` VALUES ('3', '左前车窗升降开关线路', '16', '1,2,3,4', '0', null);
INSERT INTO `faultpoint` VALUES ('1', '副驾驶员车窗升降开关线路', '17', '1,2,3,4', '0', '');
INSERT INTO `faultpoint` VALUES ('2', '副驾驶员侧中央门锁上锁单元线路', '17', '1,2,3,4', '0', null);
INSERT INTO `faultpoint` VALUES ('3', '副驾驶员侧车门接触开关线路', '17', '1,2,3,4', '0', null);
INSERT INTO `faultpoint` VALUES ('1', '左后车门车窗升降器开关线路', '18', '1,2,3,4', '0', '');
INSERT INTO `faultpoint` VALUES ('2', '左后车门中控锁马达线路', '18', '1,2,3', '0', null);
INSERT INTO `faultpoint` VALUES ('3', '左后车门接触开关线路 ', '18', '1,2,3,4', '0', null);
INSERT INTO `faultpoint` VALUES ('1', '右后车门车窗升降器开关', '19', '1,2,3,4', '0', '');
INSERT INTO `faultpoint` VALUES ('2', '右后车门接触开关线路', '19', '1,2,3,4', '0', null);
INSERT INTO `faultpoint` VALUES ('3', '右后车门中控锁电机线路', '19', '1,2,3', '0', null);
INSERT INTO `faultpoint` VALUES ('1', '车外灯开关大灯线路', '15', '1,2,3', '1', '');
INSERT INTO `faultpoint` VALUES ('2', '左侧后雾灯线路', '15', '1,2,3', '1', null);
INSERT INTO `faultpoint` VALUES ('1', '车前挡风玻璃清洗泵控制线', '20', '1,2,3', '1', '');
INSERT INTO `faultpoint` VALUES ('2', '雨刮刮水器控制线', '20', '1,2,3', '1', null);
INSERT INTO `faultpoint` VALUES ('4', '发动机转速信号线路', '2', '1,2,3,4,5', '0', null);

-- ----------------------------
-- Table structure for `hisdata`
-- ----------------------------
DROP TABLE IF EXISTS `hisdata`;
CREATE TABLE `hisdata` (
  `Id` int(11) DEFAULT NULL,
  `ModuleId` int(11) DEFAULT NULL,
  `DataTypeId` int(11) DEFAULT NULL,
  `DataTypeName` varchar(50) DEFAULT NULL,
  `Value` varchar(50) DEFAULT NULL,
  `Time` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of hisdata
-- ----------------------------
INSERT INTO `hisdata` VALUES ('1', '0', '1', '发动机冷却液温度', '70℃', '2015-03-31 11:25:53');
INSERT INTO `hisdata` VALUES ('2', '0', '2', '发动机转速', '600rpm', '2015-03-31 11:25:53');
INSERT INTO `hisdata` VALUES ('3', '0', '1', '发动机冷却液温度', '70℃', '2015-03-31 11:25:56');
INSERT INTO `hisdata` VALUES ('4', '0', '2', '发动机转速', '600rpm', '2015-03-31 11:25:56');
INSERT INTO `hisdata` VALUES ('5', '0', '1', '发动机冷却液温度', '70℃', '2015-03-31 11:25:58');
INSERT INTO `hisdata` VALUES ('6', '0', '2', '发动机转速', '600rpm', '2015-03-31 11:25:58');
INSERT INTO `hisdata` VALUES ('7', '0', '1', '发动机冷却液温度', '70℃', '2015-03-31 11:26:00');
INSERT INTO `hisdata` VALUES ('8', '0', '2', '发动机转速', '600rpm', '2015-03-31 11:26:00');
INSERT INTO `hisdata` VALUES ('9', '0', '1', '发动机冷却液温度', '70℃', '2015-03-31 11:26:03');
INSERT INTO `hisdata` VALUES ('10', '0', '2', '发动机转速', '600rpm', '2015-03-31 11:26:03');
INSERT INTO `hisdata` VALUES ('11', '0', '1', '发动机冷却液温度', '70℃', '2015-03-31 11:26:58');
INSERT INTO `hisdata` VALUES ('12', '0', '2', '发动机转速', '600rpm', '2015-03-31 11:26:58');
INSERT INTO `hisdata` VALUES ('13', '0', '1', '发动机冷却液温度', '70℃', '2015-03-31 11:27:36');
INSERT INTO `hisdata` VALUES ('14', '0', '2', '发动机转速', '600rpm', '2015-03-31 11:27:36');
INSERT INTO `hisdata` VALUES ('15', '0', '1', '发动机冷却液温度', '70℃', '2015-03-31 11:27:38');
INSERT INTO `hisdata` VALUES ('16', '0', '2', '发动机转速', '600rpm', '2015-03-31 11:27:38');
INSERT INTO `hisdata` VALUES ('17', '0', '1', '发动机冷却液温度', '70℃', '2015-03-31 11:27:40');
INSERT INTO `hisdata` VALUES ('18', '0', '2', '发动机转速', '600rpm', '2015-03-31 11:27:40');
INSERT INTO `hisdata` VALUES ('19', '0', '1', '发动机冷却液温度', '70℃', '2015-03-31 11:27:43');
INSERT INTO `hisdata` VALUES ('20', '0', '2', '发动机转速', '600rpm', '2015-03-31 11:27:43');
INSERT INTO `hisdata` VALUES ('21', '0', '1', '发动机冷却液温度', '70℃', '2015-03-31 11:27:45');
INSERT INTO `hisdata` VALUES ('22', '0', '2', '发动机转速', '600rpm', '2015-03-31 11:27:45');
INSERT INTO `hisdata` VALUES ('23', '0', '1', '发动机冷却液温度', '70℃', '2015-03-31 11:27:47');
INSERT INTO `hisdata` VALUES ('24', '0', '2', '发动机转速', '600rpm', '2015-03-31 11:27:47');
INSERT INTO `hisdata` VALUES ('25', '0', '1', '发动机冷却液温度', '70℃', '2015-03-31 11:27:58');

-- ----------------------------
-- Table structure for `itempool`
-- ----------------------------
DROP TABLE IF EXISTS `itempool`;
CREATE TABLE `itempool` (
  `Id` int(11) DEFAULT NULL,
  `ModuleId` int(11) DEFAULT NULL,
  `FaultPointId` int(11) DEFAULT NULL,
  `TypeNO` int(11) DEFAULT NULL,
  `TypeName` varchar(50) DEFAULT NULL,
  `Question` longtext,
  `OptionA` longtext,
  `OptionB` longtext,
  `OptionC` longtext,
  `OptionD` longtext,
  `Answer` varchar(50) DEFAULT NULL,
  `ScorePoint` double DEFAULT NULL,
  `CheckerNO` varchar(50) DEFAULT NULL,
  `CheckerName` varchar(50) DEFAULT NULL,
  `MemoReminder` longtext,
  `Time` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of itempool
-- ----------------------------
INSERT INTO `itempool` VALUES ('1', '1', '1', '1', '单项选择题                                             ', '你哪一年出生（）', '1989', '1999', '1987', '1988', 'A                   ', '1', '20141224            ', '国泰安                                               ', '若不知道可以回家问你父母', '2014-12-24 00:00:00');
INSERT INTO `itempool` VALUES ('2', '1', '2', '1', '单项选择题', 'aa', null, null, null, null, 'aa', '2', '200901800', '程坤波', 'a', '2015-01-08 17:01:52');
INSERT INTO `itempool` VALUES ('4', '1', '2', '3', '判断题', 'aa', null, null, null, null, 'aa', '2', '200901800', '程坤波', null, '2015-01-08 17:08:50');

-- ----------------------------
-- Table structure for `operatelog`
-- ----------------------------
DROP TABLE IF EXISTS `operatelog`;
CREATE TABLE `operatelog` (
  `RecordId` int(11) DEFAULT NULL,
  `OperaterName` varchar(50) DEFAULT NULL,
  `Message` longtext,
  `Time` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of operatelog
-- ----------------------------
INSERT INTO `operatelog` VALUES ('1', 'ckb', '切换模块[发动机燃油喷射系统]失败', '2015-03-31 15:51:30');
INSERT INTO `operatelog` VALUES ('2', 'ckb', '切换模块[发动机燃油喷射系统]失败', '2015-03-31 15:51:53');
INSERT INTO `operatelog` VALUES ('3', 'ckb', '切换模块[发动机燃油喷射系统]成功', '2015-03-31 15:52:07');
INSERT INTO `operatelog` VALUES ('4', 'ckb', '切换模块[发动机点火系统]失败', '2015-03-31 15:52:28');
INSERT INTO `operatelog` VALUES ('5', 'ckb', '成功设置故障[断路]:模块为[发动机燃油喷射系统],故障点为[燃油泵继电器控制线路]', '2015-03-31 15:56:27');
INSERT INTO `operatelog` VALUES ('6', 'ckb', '成功设置故障[通路]:模块为[发动机燃油喷射系统],故障点为[1缸喷油嘴控制线路]', '2015-03-31 15:56:27');
INSERT INTO `operatelog` VALUES ('7', 'ckb', '成功设置故障[断路]:模块为[发动机燃油喷射系统],故障点为[3缸喷油嘴控制线路]', '2015-03-31 15:56:27');
INSERT INTO `operatelog` VALUES ('8', 'ckb', '成功设置故障[不稳定状态]:模块为[发动机燃油喷射系统],故障点为[发动机转速信号线路]', '2015-03-31 15:56:27');
INSERT INTO `operatelog` VALUES ('9', 'ckb', '成功设置故障[断路]:模块为[发动机燃油喷射系统],故障点为[燃油泵继电器控制线路]', '2015-03-31 15:56:43');
INSERT INTO `operatelog` VALUES ('10', 'ckb', '成功设置故障[通路]:模块为[发动机燃油喷射系统],故障点为[1缸喷油嘴控制线路]', '2015-03-31 15:56:43');
INSERT INTO `operatelog` VALUES ('11', 'ckb', '成功设置故障[断路]:模块为[发动机燃油喷射系统],故障点为[3缸喷油嘴控制线路]', '2015-03-31 15:56:43');
INSERT INTO `operatelog` VALUES ('12', 'ckb', '成功设置故障[不稳定状态]:模块为[发动机燃油喷射系统],故障点为[发动机转速信号线路]', '2015-03-31 15:56:43');
INSERT INTO `operatelog` VALUES ('13', 'ckb', '成功设置故障[通路]:模块为[发动机燃油喷射系统],故障点为[燃油泵继电器控制线路]', '2015-03-31 15:56:59');
INSERT INTO `operatelog` VALUES ('14', 'ckb', '成功设置故障[通路]:模块为[发动机燃油喷射系统],故障点为[1缸喷油嘴控制线路]', '2015-03-31 15:56:59');
INSERT INTO `operatelog` VALUES ('15', 'ckb', '成功设置故障[断路]:模块为[发动机燃油喷射系统],故障点为[3缸喷油嘴控制线路]', '2015-03-31 15:56:59');
INSERT INTO `operatelog` VALUES ('16', 'ckb', '成功设置故障[不稳定状态]:模块为[发动机燃油喷射系统],故障点为[发动机转速信号线路]', '2015-03-31 15:56:59');
INSERT INTO `operatelog` VALUES ('17', 'ckb', '成功设置故障[断路]:模块为[发动机燃油喷射系统],故障点为[燃油泵继电器控制线路]', '2015-03-31 15:57:08');
INSERT INTO `operatelog` VALUES ('18', 'ckb', '成功设置故障[断路]:模块为[发动机燃油喷射系统],故障点为[1缸喷油嘴控制线路]', '2015-03-31 15:57:08');
INSERT INTO `operatelog` VALUES ('19', 'ckb', '成功设置故障[断路]:模块为[发动机燃油喷射系统],故障点为[3缸喷油嘴控制线路]', '2015-03-31 15:57:08');
INSERT INTO `operatelog` VALUES ('20', 'ckb', '成功设置故障[断路]:模块为[发动机燃油喷射系统],故障点为[发动机转速信号线路]', '2015-03-31 15:57:08');
INSERT INTO `operatelog` VALUES ('21', 'ckb', '成功设置故障[通路]:模块为[发动机燃油喷射系统],故障点为[燃油泵继电器控制线路]', '2015-03-31 15:57:58');
INSERT INTO `operatelog` VALUES ('22', 'ckb', '成功设置故障[虚接]:模块为[发动机燃油喷射系统],故障点为[1缸喷油嘴控制线路]', '2015-03-31 15:57:58');
INSERT INTO `operatelog` VALUES ('23', 'ckb', '成功设置故障[不稳定状态]:模块为[发动机燃油喷射系统],故障点为[3缸喷油嘴控制线路]', '2015-03-31 15:57:58');
INSERT INTO `operatelog` VALUES ('24', 'ckb', '成功设置故障[短路]:模块为[发动机燃油喷射系统],故障点为[发动机转速信号线路]', '2015-03-31 15:57:58');
INSERT INTO `operatelog` VALUES ('25', 'ckb', '切换模块[发动机燃油喷射系统]成功', '2015-03-31 16:10:26');
INSERT INTO `operatelog` VALUES ('26', 'ckb', '成功设置故障[断路]:模块为[发动机燃油喷射系统],故障点为[燃油泵继电器控制线路]', '2015-03-31 16:11:39');
INSERT INTO `operatelog` VALUES ('27', 'ckb', '成功设置故障[虚接]:模块为[发动机燃油喷射系统],故障点为[1缸喷油嘴控制线路]', '2015-03-31 16:11:39');
INSERT INTO `operatelog` VALUES ('28', 'ckb', '成功设置故障[断路]:模块为[发动机燃油喷射系统],故障点为[3缸喷油嘴控制线路]', '2015-03-31 16:11:39');
INSERT INTO `operatelog` VALUES ('29', 'ckb', '成功设置故障[不稳定状态]:模块为[发动机燃油喷射系统],故障点为[发动机转速信号线路]', '2015-03-31 16:11:39');
INSERT INTO `operatelog` VALUES ('30', 'ckb', '切换模块[发动机燃油喷射系统]成功', '2015-03-31 16:14:31');
INSERT INTO `operatelog` VALUES ('31', 'ckb', '成功设置故障[通路]:模块为[发动机燃油喷射系统],故障点为[燃油泵继电器控制线路]', '2015-03-31 16:15:26');
INSERT INTO `operatelog` VALUES ('32', 'ckb', '成功设置故障[断路]:模块为[发动机燃油喷射系统],故障点为[1缸喷油嘴控制线路]', '2015-03-31 16:15:27');
INSERT INTO `operatelog` VALUES ('33', 'ckb', '成功设置故障[不稳定状态]:模块为[发动机燃油喷射系统],故障点为[3缸喷油嘴控制线路]', '2015-03-31 16:15:27');
INSERT INTO `operatelog` VALUES ('34', 'ckb', '成功设置故障[短路]:模块为[发动机燃油喷射系统],故障点为[发动机转速信号线路]', '2015-03-31 16:15:27');
INSERT INTO `operatelog` VALUES ('35', '平板用户', '成功设置故障[]:模块为[发动机燃油喷射系统],故障点为[1]', '2015-03-31 16:17:45');
INSERT INTO `operatelog` VALUES ('36', '平板用户', '成功设置故障[]:模块为[发动机燃油喷射系统],故障点为[1]', '2015-03-31 16:17:48');
INSERT INTO `operatelog` VALUES ('37', '平板用户', '成功设置故障[]:模块为[发动机燃油喷射系统],故障点为[1]', '2015-03-31 16:17:48');
INSERT INTO `operatelog` VALUES ('38', '平板用户', '成功设置故障[]:模块为[发动机燃油喷射系统],故障点为[1]', '2015-03-31 16:17:48');
INSERT INTO `operatelog` VALUES ('39', '平板用户', '成功设置故障[]:模块为[发动机燃油喷射系统],故障点为[1]', '2015-03-31 16:17:59');
INSERT INTO `operatelog` VALUES ('40', '平板用户', '成功设置故障[]:模块为[发动机燃油喷射系统],故障点为[1]', '2015-03-31 16:18:04');
INSERT INTO `operatelog` VALUES ('41', '平板用户', '成功设置故障[不稳定状态]:模块为[发动机燃油喷射系统],故障点为[1]', '2015-03-31 16:18:25');
INSERT INTO `operatelog` VALUES ('42', '平板用户', '成功设置故障[]:模块为[发动机燃油喷射系统],故障点为[1]', '2015-03-31 16:18:32');
INSERT INTO `operatelog` VALUES ('43', '平板用户', '成功设置故障[不稳定状态]:模块为[发动机燃油喷射系统],故障点为[2]', '2015-03-31 16:18:55');
INSERT INTO `operatelog` VALUES ('44', '平板用户', '成功设置故障[不稳定状态]:模块为[发动机燃油喷射系统],故障点为[2]', '2015-03-31 16:18:55');
INSERT INTO `operatelog` VALUES ('45', '平板用户', '成功设置故障[断路]:模块为[发动机燃油喷射系统],故障点为[3]', '2015-03-31 16:19:29');
INSERT INTO `operatelog` VALUES ('46', '平板用户', '成功设置故障[不稳定状态]:模块为[发动机燃油喷射系统],故障点为[3]', '2015-03-31 16:20:31');
INSERT INTO `operatelog` VALUES ('47', '平板用户', '成功设置故障[断路]:模块为[发动机燃油喷射系统],故障点为[3]', '2015-03-31 16:20:47');
INSERT INTO `operatelog` VALUES ('48', '平板用户', '成功设置故障[]:模块为[发动机燃油喷射系统],故障点为[3]', '2015-03-31 16:20:57');
INSERT INTO `operatelog` VALUES ('49', '平板用户', '成功设置故障[]:模块为[发动机燃油喷射系统],故障点为[2]', '2015-03-31 16:21:18');
INSERT INTO `operatelog` VALUES ('50', '平板用户', '成功设置故障[]:模块为[发动机燃油喷射系统],故障点为[1]', '2015-03-31 16:21:48');
INSERT INTO `operatelog` VALUES ('51', '平板用户', '成功设置故障[不稳定状态]:模块为[发动机燃油喷射系统],故障点为[1]', '2015-03-31 16:22:17');
INSERT INTO `operatelog` VALUES ('52', '平板用户', '成功设置故障[]:模块为[发动机燃油喷射系统],故障点为[1]', '2015-03-31 16:22:27');
INSERT INTO `operatelog` VALUES ('53', '平板用户', '成功设置故障[]:模块为[发动机燃油喷射系统],故障点为[1]', '2015-03-31 16:22:28');
INSERT INTO `operatelog` VALUES ('54', '平板用户', '成功设置故障[通路]:模块为[发动机燃油喷射系统],故障点为[1]', '2015-03-31 16:23:09');
INSERT INTO `operatelog` VALUES ('55', '平板用户', '成功设置故障[通路]:模块为[发动机燃油喷射系统],故障点为[1]', '2015-03-31 16:23:10');
INSERT INTO `operatelog` VALUES ('56', '平板用户', '成功设置故障[通路]:模块为[发动机燃油喷射系统],故障点为[1]', '2015-03-31 16:23:47');
INSERT INTO `operatelog` VALUES ('57', '平板用户', '设置故障[通路]失败:模块为[未连接],故障点为[3]', '2015-03-31 17:36:30');
INSERT INTO `operatelog` VALUES ('58', '平板用户', '设置故障[通路]失败:模块为[未连接],故障点为[3]', '2015-03-31 17:36:33');
INSERT INTO `operatelog` VALUES ('59', '平板用户', '设置故障[通路]失败:模块为[未连接],故障点为[3]', '2015-03-31 17:36:35');
INSERT INTO `operatelog` VALUES ('60', '平板用户', '设置故障[通路]失败:模块为[未连接],故障点为[3]', '2015-03-31 17:36:37');
INSERT INTO `operatelog` VALUES ('61', '平板用户', '设置故障[通路]失败:模块为[未连接],故障点为[3]', '2015-03-31 17:36:39');
INSERT INTO `operatelog` VALUES ('62', '平板用户', '设置故障[通路]失败:模块为[未连接],故障点为[3]', '2015-03-31 17:36:42');
INSERT INTO `operatelog` VALUES ('63', '平板用户', '设置故障[通路]失败:模块为[未连接],故障点为[1]', '2015-03-31 17:40:53');
INSERT INTO `operatelog` VALUES ('64', '平板用户', '设置故障[断路]失败:模块为[未连接],故障点为[1]', '2015-03-31 17:40:58');
INSERT INTO `operatelog` VALUES ('65', '平板用户', '设置故障[虚接]失败:模块为[未连接],故障点为[1]', '2015-03-31 17:41:03');
INSERT INTO `operatelog` VALUES ('66', '平板用户', '设置故障[不稳定状态]失败:模块为[未连接],故障点为[1]', '2015-03-31 17:41:07');
INSERT INTO `operatelog` VALUES ('67', '平板用户', '设置故障[短路]失败:模块为[未连接],故障点为[1]', '2015-03-31 17:41:12');
INSERT INTO `operatelog` VALUES ('68', '平板用户', '设置故障[通路]失败:模块为[未连接],故障点为[1]', '2015-03-31 17:41:17');
INSERT INTO `operatelog` VALUES ('69', '平板用户', '设置故障[通路]失败:模块为[未连接],故障点为[2]', '2015-03-31 17:41:32');
INSERT INTO `operatelog` VALUES ('70', '平板用户', '设置故障[断路]失败:模块为[未连接],故障点为[2]', '2015-03-31 17:41:36');
INSERT INTO `operatelog` VALUES ('71', '平板用户', '设置故障[虚接]失败:模块为[未连接],故障点为[3]', '2015-03-31 17:41:55');
INSERT INTO `operatelog` VALUES ('72', '平板用户', '设置故障[短路]失败:模块为[未连接],故障点为[3]', '2015-03-31 17:41:57');
INSERT INTO `operatelog` VALUES ('73', '平板用户', '设置故障[通路]失败:模块为[未连接],故障点为[3]', '2015-03-31 17:42:00');
INSERT INTO `operatelog` VALUES ('74', '平板用户', '设置故障[断路]失败:模块为[未连接],故障点为[2]', '2015-03-31 18:01:58');
INSERT INTO `operatelog` VALUES ('75', '平板用户', '设置故障[通路]失败:模块为[未连接],故障点为[2]', '2015-03-31 18:02:02');
INSERT INTO `operatelog` VALUES ('76', '平板用户', '设置故障[不稳定状态]失败:模块为[未连接],故障点为[2]', '2015-03-31 18:02:05');
INSERT INTO `operatelog` VALUES ('77', '平板用户', '设置故障[通路]失败:模块为[未连接],故障点为[1]', '2015-03-31 18:02:57');
INSERT INTO `operatelog` VALUES ('78', '平板用户', '设置故障[断路]失败:模块为[未连接],故障点为[1]', '2015-03-31 18:03:00');
INSERT INTO `operatelog` VALUES ('79', '平板用户', '设置故障[不稳定状态]失败:模块为[未连接],故障点为[1]', '2015-03-31 18:03:02');
INSERT INTO `operatelog` VALUES ('80', '平板用户', '设置故障[通路]失败:模块为[未连接],故障点为[2]', '2015-03-31 18:03:07');
INSERT INTO `operatelog` VALUES ('81', '平板用户', '设置故障[断路]失败:模块为[未连接],故障点为[2]', '2015-03-31 18:03:14');
INSERT INTO `operatelog` VALUES ('82', '平板用户', '设置故障[不稳定状态]失败:模块为[未连接],故障点为[2]', '2015-03-31 18:03:16');
INSERT INTO `operatelog` VALUES ('83', '平板用户', '设置故障[通路]失败:模块为[未连接],故障点为[1]', '2015-03-31 18:03:59');
INSERT INTO `operatelog` VALUES ('84', '平板用户', '设置故障[断路]失败:模块为[未连接],故障点为[1]', '2015-03-31 18:04:02');
INSERT INTO `operatelog` VALUES ('85', '平板用户', '设置故障[不稳定状态]失败:模块为[未连接],故障点为[1]', '2015-03-31 18:04:04');
INSERT INTO `operatelog` VALUES ('86', '平板用户', '设置故障[虚接]失败:模块为[未连接],故障点为[1]', '2015-03-31 18:04:06');
INSERT INTO `operatelog` VALUES ('87', '平板用户', '设置故障[短路]失败:模块为[未连接],故障点为[1]', '2015-03-31 18:04:09');
INSERT INTO `operatelog` VALUES ('88', '平板用户', '设置故障[通路]失败:模块为[未连接],故障点为[2]', '2015-03-31 18:04:11');
INSERT INTO `operatelog` VALUES ('89', '平板用户', '设置故障[断路]失败:模块为[未连接],故障点为[2]', '2015-03-31 18:04:13');
INSERT INTO `operatelog` VALUES ('90', '平板用户', '设置故障[不稳定状态]失败:模块为[未连接],故障点为[2]', '2015-03-31 18:04:16');
INSERT INTO `operatelog` VALUES ('91', '平板用户', '设置故障[虚接]失败:模块为[未连接],故障点为[2]', '2015-03-31 18:04:18');
INSERT INTO `operatelog` VALUES ('92', '平板用户', '设置故障[短路]失败:模块为[未连接],故障点为[2]', '2015-03-31 18:04:20');
INSERT INTO `operatelog` VALUES ('93', '平板用户', '设置故障[通路]失败:模块为[未连接],故障点为[3]', '2015-03-31 18:04:27');
INSERT INTO `operatelog` VALUES ('94', '平板用户', '设置故障[断路]失败:模块为[未连接],故障点为[3]', '2015-03-31 18:04:31');
INSERT INTO `operatelog` VALUES ('95', '平板用户', '设置故障[不稳定状态]失败:模块为[未连接],故障点为[3]', '2015-03-31 18:04:34');
INSERT INTO `operatelog` VALUES ('96', '平板用户', '设置故障[断路]失败:模块为[未连接],故障点为[3]', '2015-03-31 18:10:36');
INSERT INTO `operatelog` VALUES ('97', '平板用户', '设置故障[不稳定状态]失败:模块为[未连接],故障点为[3]', '2015-03-31 18:10:39');
INSERT INTO `operatelog` VALUES ('98', '平板用户', '设置故障[虚接]失败:模块为[未连接],故障点为[3]', '2015-03-31 18:10:42');
INSERT INTO `operatelog` VALUES ('99', '平板用户', '设置故障[短路]失败:模块为[未连接],故障点为[3]', '2015-03-31 18:11:03');
INSERT INTO `operatelog` VALUES ('100', '平板用户', '设置故障[通路]失败:模块为[未连接],故障点为[4]', '2015-03-31 18:11:05');
INSERT INTO `operatelog` VALUES ('101', '平板用户', '设置故障[断路]失败:模块为[未连接],故障点为[4]', '2015-03-31 18:11:07');
INSERT INTO `operatelog` VALUES ('102', '平板用户', '设置故障[虚接]失败:模块为[未连接],故障点为[4]', '2015-03-31 18:11:10');
INSERT INTO `operatelog` VALUES ('103', '平板用户', '设置故障[不稳定状态]失败:模块为[未连接],故障点为[4]', '2015-03-31 18:11:12');
INSERT INTO `operatelog` VALUES ('104', '平板用户', '设置故障[通路]失败:模块为[未连接],故障点为[3]', '2015-03-31 18:11:14');
INSERT INTO `operatelog` VALUES ('105', '平板用户', '设置故障[短路]失败:模块为[未连接],故障点为[4]', '2015-03-31 18:11:17');
INSERT INTO `operatelog` VALUES ('106', '平板用户', '设置故障[通路]失败:模块为[未连接],故障点为[1]', '2015-03-31 18:11:47');
INSERT INTO `operatelog` VALUES ('107', '平板用户', '设置故障[断路]失败:模块为[未连接],故障点为[1]', '2015-03-31 18:11:52');
INSERT INTO `operatelog` VALUES ('108', '平板用户', '设置故障[不稳定状态]失败:模块为[未连接],故障点为[1]', '2015-03-31 18:11:55');
INSERT INTO `operatelog` VALUES ('109', '平板用户', '设置故障[虚接]失败:模块为[未连接],故障点为[1]', '2015-03-31 18:11:57');
INSERT INTO `operatelog` VALUES ('110', '平板用户', '设置故障[通路]失败:模块为[未连接],故障点为[2]', '2015-03-31 18:12:04');
INSERT INTO `operatelog` VALUES ('111', '平板用户', '设置故障[断路]失败:模块为[未连接],故障点为[2]', '2015-03-31 18:12:06');
INSERT INTO `operatelog` VALUES ('112', '平板用户', '设置故障[虚接]失败:模块为[未连接],故障点为[2]', '2015-03-31 18:12:08');
INSERT INTO `operatelog` VALUES ('113', '平板用户', '设置故障[不稳定状态]失败:模块为[未连接],故障点为[2]', '2015-03-31 18:12:10');
INSERT INTO `operatelog` VALUES ('114', '平板用户', '设置故障[通路]失败:模块为[未连接],故障点为[3]', '2015-03-31 18:12:13');
INSERT INTO `operatelog` VALUES ('115', '平板用户', '设置故障[断路]失败:模块为[未连接],故障点为[3]', '2015-03-31 18:12:16');
INSERT INTO `operatelog` VALUES ('116', '平板用户', '设置故障[不稳定状态]失败:模块为[未连接],故障点为[3]', '2015-03-31 18:12:19');
INSERT INTO `operatelog` VALUES ('117', '平板用户', '设置故障[虚接]失败:模块为[未连接],故障点为[3]', '2015-03-31 18:12:21');
INSERT INTO `operatelog` VALUES ('118', '平板用户', '设置故障[断路]失败:模块为[未连接],故障点为[1]', '2015-03-31 18:13:41');
INSERT INTO `operatelog` VALUES ('119', '平板用户', '设置故障[不稳定状态]失败:模块为[未连接],故障点为[1]', '2015-03-31 18:13:44');
INSERT INTO `operatelog` VALUES ('120', '平板用户', '设置故障[虚接]失败:模块为[未连接],故障点为[1]', '2015-03-31 18:13:46');
INSERT INTO `operatelog` VALUES ('121', '平板用户', '设置故障[通路]失败:模块为[未连接],故障点为[1]', '2015-03-31 18:13:48');
INSERT INTO `operatelog` VALUES ('122', '平板用户', '设置故障[通路]失败:模块为[未连接],故障点为[2]', '2015-03-31 18:14:30');
INSERT INTO `operatelog` VALUES ('123', '平板用户', '设置故障[通路]失败:模块为[未连接],故障点为[2]', '2015-03-31 18:14:40');
INSERT INTO `operatelog` VALUES ('124', '平板用户', '设置故障[断路]失败:模块为[未连接],故障点为[2]', '2015-03-31 18:14:42');
INSERT INTO `operatelog` VALUES ('125', '平板用户', '设置故障[不稳定状态]失败:模块为[未连接],故障点为[2]', '2015-03-31 18:14:44');
INSERT INTO `operatelog` VALUES ('126', '平板用户', '设置故障[虚接]失败:模块为[未连接],故障点为[2]', '2015-03-31 18:14:47');
INSERT INTO `operatelog` VALUES ('127', '平板用户', '设置故障[]失败:模块为[未连接],故障点为[3]', '2015-03-31 18:14:50');
INSERT INTO `operatelog` VALUES ('128', '平板用户', '设置故障[断路]失败:模块为[未连接],故障点为[3]', '2015-03-31 18:15:07');
INSERT INTO `operatelog` VALUES ('129', '平板用户', '设置故障[不稳定状态]失败:模块为[未连接],故障点为[3]', '2015-03-31 18:15:10');
INSERT INTO `operatelog` VALUES ('130', '平板用户', '设置故障[虚接]失败:模块为[未连接],故障点为[3]', '2015-03-31 18:15:12');
INSERT INTO `operatelog` VALUES ('131', '平板用户', '设置故障[通路]失败:模块为[未连接],故障点为[3]', '2015-03-31 18:15:15');
INSERT INTO `operatelog` VALUES ('132', '平板用户', '设置故障[通路]失败:模块为[未连接],故障点为[3]', '2015-03-31 18:17:28');
INSERT INTO `operatelog` VALUES ('133', '平板用户', '设置故障[通路]失败:模块为[未连接],故障点为[3]', '2015-03-31 18:17:31');
INSERT INTO `operatelog` VALUES ('134', '平板用户', '设置故障[断路]失败:模块为[未连接],故障点为[3]', '2015-03-31 18:17:33');
INSERT INTO `operatelog` VALUES ('135', '平板用户', '设置故障[不稳定状态]失败:模块为[未连接],故障点为[3]', '2015-03-31 18:17:37');
INSERT INTO `operatelog` VALUES ('136', '平板用户', '设置故障[虚接]失败:模块为[未连接],故障点为[3]', '2015-03-31 18:17:39');
INSERT INTO `operatelog` VALUES ('137', '平板用户', '设置故障[通路]失败:模块为[未连接],故障点为[1]', '2015-03-31 18:19:14');
INSERT INTO `operatelog` VALUES ('138', '平板用户', '设置故障[]失败:模块为[未连接],故障点为[1]', '2015-03-31 18:19:17');
INSERT INTO `operatelog` VALUES ('139', '平板用户', '设置故障[不稳定状态]失败:模块为[未连接],故障点为[1]', '2015-03-31 18:19:22');
INSERT INTO `operatelog` VALUES ('140', '平板用户', '设置故障[断路]失败:模块为[未连接],故障点为[1]', '2015-03-31 18:19:26');
INSERT INTO `operatelog` VALUES ('141', '平板用户', '设置故障[通路]失败:模块为[未连接],故障点为[1]', '2015-03-31 18:19:34');
INSERT INTO `operatelog` VALUES ('142', 'ckb', '成功设置故障[断路]:模块为[未连接],故障点为[3缸喷油嘴控制线路]', '2015-12-13 14:26:20');
INSERT INTO `operatelog` VALUES ('143', 'ckb', '成功设置故障[断路]:模块为[未连接],故障点为[燃油泵继电器控制线路]', '2015-12-13 14:26:43');
INSERT INTO `operatelog` VALUES ('144', 'ckb', '成功设置故障[通路]:模块为[未连接],故障点为[3缸喷油嘴控制线路]', '2015-12-13 14:26:50');

-- ----------------------------
-- Table structure for `serverinfo`
-- ----------------------------
DROP TABLE IF EXISTS `serverinfo`;
CREATE TABLE `serverinfo` (
  `Id` int(11) DEFAULT NULL,
  `IP` varchar(50) DEFAULT NULL,
  `Port1` int(11) DEFAULT NULL,
  `Port2` int(11) DEFAULT NULL,
  `ShareAddress` varchar(50) DEFAULT NULL,
  `Memo` longtext
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of serverinfo
-- ----------------------------
INSERT INTO `serverinfo` VALUES ('1', '192.168.0.101', '8080', '8081', 'www.hao123.com', '通信配置信息');

-- ----------------------------
-- Table structure for `sysmodule`
-- ----------------------------
DROP TABLE IF EXISTS `sysmodule`;
CREATE TABLE `sysmodule` (
  `Id` int(11) DEFAULT NULL,
  `ModuleName` varchar(50) DEFAULT NULL,
  `CarClass` varchar(50) DEFAULT NULL,
  `schematic` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sysmodule
-- ----------------------------
INSERT INTO `sysmodule` VALUES ('1', '发动机点火系统', '2013款桑塔纳1.6L 自动 舒适版', '发动机点火系统.swf');
INSERT INTO `sysmodule` VALUES ('2', '发动机燃油喷射系统', '2013款桑塔纳1.6L 自动 舒适版', '发动机燃油喷射系统.swf');
INSERT INTO `sysmodule` VALUES ('3', '节气门控制单元与油门踏板', '2013款桑塔纳1.6L 自动 舒适版', '节气门控制单元与油门踏板.swf');
INSERT INTO `sysmodule` VALUES ('4', '进气压力进气温度和水温度传感器', '2013款桑塔纳1.6L 自动 舒适版', '进气压力进气温度和水温度传感器.swf');
INSERT INTO `sysmodule` VALUES ('5', '前后氧传感器', '2013款桑塔纳1.6L 自动 舒适版', '前后氧传感器.png');
INSERT INTO `sysmodule` VALUES ('6', '霍尔爆震传感器和碳罐电磁阀', '2013款桑塔纳1.6L 自动 舒适版', '霍尔爆震传感器和碳罐电磁阀.png');
INSERT INTO `sysmodule` VALUES ('7', '变速器系统', '2013款桑塔纳1.6L 自动 舒适版', '变速器系统.png');
INSERT INTO `sysmodule` VALUES ('8', '空调控制系统', '2013款桑塔纳1.6L 自动 舒适版', '空调控制系统.png');
INSERT INTO `sysmodule` VALUES ('9', '空调鼓风机控制系统', '2013款桑塔纳1.6L 自动 舒适版', '空调鼓风机控制系统.png');
INSERT INTO `sysmodule` VALUES ('10', 'ABS系统', '2013款桑塔纳1.6L 自动 舒适版', 'ABS系统.png');
INSERT INTO `sysmodule` VALUES ('11', '组合仪表系统', '2013款桑塔纳1.6L 自动 舒适版', '组合仪表系统.png');
INSERT INTO `sysmodule` VALUES ('12', '音响系统', '2013款桑塔纳1.6L 自动 舒适版', '音响系统.png');
INSERT INTO `sysmodule` VALUES ('13', '危险及转向信号灯', '2013款桑塔纳1.6L 自动 舒适版', '危险及转向信号灯.png');
INSERT INTO `sysmodule` VALUES ('14', '倒车刹车灯控制系统', '2013款桑塔纳1.6L 自动 舒适版', '倒车刹车灯控制系统.png');
INSERT INTO `sysmodule` VALUES ('15', '车外灯光控制系统', '2013款桑塔纳1.6L 自动 舒适版', '车外灯光控制系统.png');
INSERT INTO `sysmodule` VALUES ('16', '驾驶员侧车门控制系统', '2013款桑塔纳1.6L 自动 舒适版', '驾驶员侧车门控制系统.png');
INSERT INTO `sysmodule` VALUES ('17', '副驾驶员侧车门控制系统', '2013款桑塔纳1.6L 自动 舒适版', '副驾驶员侧车门控制系统.png');
INSERT INTO `sysmodule` VALUES ('18', '左后车门控制系统', '2013款桑塔纳1.6L 自动 舒适版', '左后车门控制系统.png');
INSERT INTO `sysmodule` VALUES ('19', '右后车门控制系统', '2013款桑塔纳1.6L 自动 舒适版', '右后车门控制系统.png');
INSERT INTO `sysmodule` VALUES ('20', '雨刮系统', '2013款桑塔纳1.6L 自动 舒适版', '雨刮系统.png');

-- ----------------------------
-- Table structure for `userinfo`
-- ----------------------------
DROP TABLE IF EXISTS `userinfo`;
CREATE TABLE `userinfo` (
  `StudyNO` varchar(50) DEFAULT NULL,
  `StudyName` varchar(50) DEFAULT NULL,
  `IsMan` tinyint(1) DEFAULT NULL,
  `UserName` varchar(50) DEFAULT NULL,
  `PassWord` varchar(100) DEFAULT NULL,
  `RoleId` int(11) DEFAULT NULL,
  `RoleName` varchar(50) DEFAULT NULL,
  `Mail` varchar(100) DEFAULT NULL,
  `Userable` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of userinfo
-- ----------------------------
INSERT INTO `userinfo` VALUES ('02145', '张老师', '1', 'teacher1', '123456', '1', '教师', '811823922@qq.com', '1');
INSERT INTO `userinfo` VALUES ('200901800', 'admin', '1', 'admin', '123456', '0', '管理员', '811823922@qq.com', '1');
INSERT INTO `userinfo` VALUES ('2656', '李四', '1', 'student1', '123456', '2', '学生', '811823922@qq.com', '1');
