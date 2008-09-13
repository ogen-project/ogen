USE `OGen-NTier_UTs`;

CREATE TABLE `grouppermition` (
  `IDGroup` bigint(20) NOT NULL,
  `IDPermition` bigint(20) NOT NULL,
  PRIMARY KEY (`IDGroup`,`IDPermition`),
  KEY `IDPermition` (`IDPermition`),
  CONSTRAINT `grouppermition_ibfk_1` FOREIGN KEY (`IDGroup`) REFERENCES `group` (`IDGroup`),
  CONSTRAINT `grouppermition_ibfk_2` FOREIGN KEY (`IDPermition`) REFERENCES `permition` (`IDPermition`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


