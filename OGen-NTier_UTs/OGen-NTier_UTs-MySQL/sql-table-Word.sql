USE `OGen-NTier_UTs`;

CREATE TABLE `word` (
  `IDWord` bigint(20) NOT NULL AUTO_INCREMENT,
  `DeleteThisTestField` bit(1) DEFAULT NULL,
  PRIMARY KEY (`IDWord`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


