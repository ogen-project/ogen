USE `OGen-NTier_UTs`;

CREATE TABLE `language` (
  `IDLanguage` bigint(20) NOT NULL AUTO_INCREMENT,
  `IDWord_name` bigint(20) NOT NULL,
  PRIMARY KEY (`IDLanguage`),
  KEY `IDWord_name` (`IDWord_name`),
  CONSTRAINT `language_ibfk_1` FOREIGN KEY (`IDWord_name`) REFERENCES `word` (`IDWord`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


