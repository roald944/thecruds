-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Sep 07, 2021 at 02:30 AM
-- Server version: 10.4.20-MariaDB
-- PHP Version: 8.0.8

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `mydatabase`
--

-- --------------------------------------------------------

--
-- Table structure for table `info_users`
--

CREATE TABLE `info_users` (
  `t_id` int(11) NOT NULL,
  `my_id` varchar(255) NOT NULL,
  `lastname` varchar(255) NOT NULL,
  `firstname` varchar(255) NOT NULL,
  `middlename` varchar(255) NOT NULL,
  `email` varchar(255) NOT NULL,
  `contact` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `info_users`
--

INSERT INTO `info_users` (`t_id`, `my_id`, `lastname`, `firstname`, `middlename`, `email`, `contact`) VALUES
(15, '0908202111040503ZS4S', 'Dela Cruz', 'Roald', 'Mohametano', 'hype7666@gmail.com', '09487288796'),
(16, '10082021113747EW42UU', 'Villanueva', 'Kenn Mark', 'Taroza', 'hype7666@gmail.com', '12345678900');

-- --------------------------------------------------------

--
-- Table structure for table `login_users`
--

CREATE TABLE `login_users` (
  `t_id` int(11) NOT NULL,
  `my_id` varchar(255) NOT NULL,
  `my_username` varchar(255) NOT NULL,
  `my_password` varchar(255) NOT NULL,
  `my_status` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `login_users`
--

INSERT INTO `login_users` (`t_id`, `my_id`, `my_username`, `my_password`, `my_status`) VALUES
(15, '0908202111040503ZS4S', 'roald12345', 'password', 'Offline'),
(16, '10082021113747EW42UU', 'kenny123', 'password', 'Offline');

-- --------------------------------------------------------

--
-- Stand-in structure for view `search_view`
-- (See below for the actual view)
--
CREATE TABLE `search_view` (
`t_id` int(11)
,`my_username` varchar(255)
,`my_password` varchar(255)
,`lastname` varchar(255)
,`firstname` varchar(255)
,`middlename` varchar(255)
,`email` varchar(255)
,`contact` varchar(255)
);

-- --------------------------------------------------------

--
-- Stand-in structure for view `user_view`
-- (See below for the actual view)
--
CREATE TABLE `user_view` (
`MYID` varchar(255)
,`FullName` text
,`EMAIL` varchar(255)
,`CONTACT` varchar(255)
,`STATUS` varchar(255)
);

-- --------------------------------------------------------

--
-- Structure for view `search_view`
--
DROP TABLE IF EXISTS `search_view`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `search_view`  AS SELECT `login_users`.`t_id` AS `t_id`, `login_users`.`my_username` AS `my_username`, `login_users`.`my_password` AS `my_password`, `info_users`.`lastname` AS `lastname`, `info_users`.`firstname` AS `firstname`, `info_users`.`middlename` AS `middlename`, `info_users`.`email` AS `email`, `info_users`.`contact` AS `contact` FROM (`info_users` join `login_users` on(`info_users`.`t_id` = `login_users`.`t_id`)) ;

-- --------------------------------------------------------

--
-- Structure for view `user_view`
--
DROP TABLE IF EXISTS `user_view`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `user_view`  AS SELECT `login_users`.`my_id` AS `MYID`, concat(`info_users`.`lastname`,', ',`info_users`.`firstname`,' ',substr(`info_users`.`middlename`,1,1),'.') AS `FullName`, `info_users`.`email` AS `EMAIL`, `info_users`.`contact` AS `CONTACT`, `login_users`.`my_status` AS `STATUS` FROM (`login_users` join `info_users` on(`login_users`.`my_id` = `info_users`.`my_id`)) ;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `info_users`
--
ALTER TABLE `info_users`
  ADD PRIMARY KEY (`t_id`,`my_id`);

--
-- Indexes for table `login_users`
--
ALTER TABLE `login_users`
  ADD PRIMARY KEY (`t_id`,`my_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `info_users`
--
ALTER TABLE `info_users`
  MODIFY `t_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- AUTO_INCREMENT for table `login_users`
--
ALTER TABLE `login_users`
  MODIFY `t_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
