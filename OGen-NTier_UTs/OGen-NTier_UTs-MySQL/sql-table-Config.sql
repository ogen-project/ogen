USE `OGen-NTier_UTs`;

CREATE TABLE `config` (
  `Name` varchar(50) NOT NULL,
  `Config` varchar(50) NOT NULL,
  `Type` int(11) NOT NULL,
  `Description` varchar(50) NOT NULL,
  PRIMARY KEY (`Name`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


