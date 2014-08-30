-- phpMyAdmin SQL Dump
-- version 4.1.14
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Aug 30, 2014 at 05:07 PM
-- Server version: 5.6.17
-- PHP Version: 5.5.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `battlenetshop`
--

-- --------------------------------------------------------

--
-- Table structure for table `salereports`
--

CREATE TABLE IF NOT EXISTS `salereports` (
  `report_id` int(11) NOT NULL AUTO_INCREMENT,
  `product_id` int(11) NOT NULL,
  `productName` varchar(500) NOT NULL,
  `vendorName` varchar(500) NOT NULL,
  `totalQuantitySold` int(11) NOT NULL,
  `totalIncomes` int(11) NOT NULL,
  PRIMARY KEY (`report_id`),
  KEY `product_id` (`product_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=3 ;

--
-- Dumping data for table `salereports`
--

INSERT INTO `salereports` (`report_id`, `product_id`, `productName`, `vendorName`, `totalQuantitySold`, `totalIncomes`) VALUES
(1, 1, 'Sword of Justice', 'Blizzard', 222, 333),
(2, 2, 'AwesomeItem', 'Blizzard', 111, 222);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
