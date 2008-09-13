USE `OGen-NTier_UTs`;

CREATE TABLE `wordlanguage` (
  `IDWord` bigint(20) NOT NULL,
  `IDLanguage` bigint(20) NOT NULL,
  `Translation` varchar(2048) DEFAULT NULL,
  PRIMARY KEY (`IDWord`,`IDLanguage`),
  KEY `IDLanguage` (`IDLanguage`),
  CONSTRAINT `wordlanguage_ibfk_1` FOREIGN KEY (`IDWord`) REFERENCES `word` (`IDWord`),
  CONSTRAINT `wordlanguage_ibfk_2` FOREIGN KEY (`IDLanguage`) REFERENCES `language` (`IDLanguage`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


