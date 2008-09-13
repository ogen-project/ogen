USE `OGen-NTier_UTs`;

CREATE TABLE `log` (
  `IDLog` bigint(20) NOT NULL AUTO_INCREMENT,
  `IDLogcode` bigint(20) NOT NULL,
  `IDUser_posted` bigint(20) NOT NULL,
  `Date_posted` datetime NOT NULL,
  `Logdata` varchar(1024) NOT NULL,
  PRIMARY KEY (`IDLog`),
  KEY `IDLogcode` (`IDLogcode`),
  KEY `IDUser_posted` (`IDUser_posted`),
  CONSTRAINT `log_ibfk_1` FOREIGN KEY (`IDLogcode`) REFERENCES `logcode` (`IDLogcode`),
  CONSTRAINT `log_ibfk_2` FOREIGN KEY (`IDUser_posted`) REFERENCES `user` (`IDUser`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


