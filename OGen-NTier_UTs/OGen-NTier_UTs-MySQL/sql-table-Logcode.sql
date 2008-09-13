USE `OGen-NTier_UTs`;

CREATE TABLE `logcode` (
  `IDLogcode` bigint(20) NOT NULL AUTO_INCREMENT,
  `Warning` bit(1) NOT NULL,
  `Error` bit(1) NOT NULL,
  `Code` varchar(50) NOT NULL,
  `Description` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`IDLogcode`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


