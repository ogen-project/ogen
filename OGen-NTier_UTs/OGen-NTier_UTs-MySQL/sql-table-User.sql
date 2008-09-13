USE `OGen-NTier_UTs`;

CREATE TABLE `user` (
  `IDUser` bigint(20) NOT NULL AUTO_INCREMENT,
  `Login` varchar(50) NOT NULL,
  `Password` varchar(50) NOT NULL,
  `SomeNullValue` int(11) DEFAULT NULL,
  PRIMARY KEY (`IDUser`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


