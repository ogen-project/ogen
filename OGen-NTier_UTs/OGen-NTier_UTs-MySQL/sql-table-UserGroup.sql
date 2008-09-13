USE `OGen-NTier_UTs`;

CREATE TABLE `usergroup` (
  `IDUser` bigint(20) NOT NULL,
  `IDGroup` bigint(20) NOT NULL,
  `Relationdate` datetime DEFAULT NULL,
  `Defaultrelation` bit(1) DEFAULT NULL,
  PRIMARY KEY (`IDUser`,`IDGroup`),
  KEY `IDGroup` (`IDGroup`),
  CONSTRAINT `usergroup_ibfk_1` FOREIGN KEY (`IDUser`) REFERENCES `user` (`IDUser`),
  CONSTRAINT `usergroup_ibfk_2` FOREIGN KEY (`IDGroup`) REFERENCES `group` (`IDGroup`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


