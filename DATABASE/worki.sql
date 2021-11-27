SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";

CREATE TABLE `friends` (
  `my_friend_id` int(11) NOT NULL,
  `my_id` int(11) NOT NULL,
  `friends_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


INSERT INTO `friends` (`my_friend_id`, `my_id`, `friends_id`) VALUES
(1, 10, 0),
(11, 12, 0),
(12, 13, 0),
(13, 11, 0);

CREATE TABLE `members` (
  `member_id` int(11) NOT NULL,
  `firstname` varchar(100) NOT NULL,
  `lastname` varchar(100) NOT NULL,
  `middlename` varchar(100) NOT NULL,
  `address` varchar(100) NOT NULL,
  `email` varchar(100) NOT NULL,
  `contact_no` varchar(100) NOT NULL,
  `age` int(11) NOT NULL,
  `gender` varchar(100) NOT NULL,
  `username` varchar(100) NOT NULL,
  `password` varchar(100) NOT NULL,
  `image` varchar(100) NOT NULL,
  `birthdate` varchar(100) NOT NULL,
  `mobile` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


INSERT INTO `members` (`member_id`, `firstname`, `lastname`, `middlename`, `address`, `email`, `contact_no`, `age`, `gender`, `username`, `password`, `image`, `birthdate`, `mobile`, `status`, `work`, `religion`) VALUES
(11, 'Mauricio', 'Sevilla', '', 'Calle 45 #16-23', '', '', 0, 'Hombre', 'configuroweb', '1234abcd..', 'images/logo2.png', '1992-05-02', '3142450392', 'Activo', 'Técnico IT', 'No declarada'),
(12, 'usuario', 'usuario', '', 'Calle con Carrera', '', '', 0, 'Hombre', 'usuario', '1234abcd..', 'images/avatar.jpg', '1989-07-12', '3054679844', 'Activo', 'Técnico IT', 'No declarada'),
(13, 'Juan', 'Lee', '', 'Cualquier Calle', '', '', 0, 'Hombre', 'lee', '1234abcd..', 'images/avatar.jpg', '25-12-1997', '3167894167', 'Casado', 'Work IT', 'No declara');

CREATE TABLE `message` (
  `message_id` int(11) NOT NULL,
  `sender_id` int(11) NOT NULL,
  `reciever_id` int(11) NOT NULL,
  `content` varchar(100) NOT NULL,
  `date_sended` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;



INSERT INTO `message` (`message_id`, `sender_id`, `reciever_id`, `content`, `date_sended`) VALUES
(1, 10, 1, 'hello', '2021-02-27 18:12:48'),
(2, 11, 12, 'Hola amiguis', '2020-03-12 10:40:26'),
(3, 12, 11, 'hola man como vas', '2020-03-12 10:40:53'),
(4, 12, 11, 'Hola', '2020-03-12 11:21:30'),
(5, 11, 12, 'Bien man', '2020-03-12 11:22:58'),
(6, 12, 11, 'MP', '2020-03-12 20:04:44'),
(7, 13, 11, 'Hola amigo secreto', '2020-03-12 20:09:44');



CREATE TABLE `note` (
  `note_id` int(11) NOT NULL,
  `date` varchar(100) NOT NULL,
  `message` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

INSERT INTO `note` (`note_id`, `date`, `message`) VALUES
(6, '', 'Doc terry will be  out on august 3 2013');

CREATE TABLE `photos` (
  `photos_id` int(11) NOT NULL,
  `location` varchar(100) NOT NULL,
  `member_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

INSERT INTO `photos` (`photos_id`, `location`, `member_id`) VALUES
(1, 'upload/7918240442_4471d5b11e_b.jpg', 1),
(2, 'upload/Como dar Like Automatico por Palabra Clave en Twitter con Python.png', 11),
(3, 'upload/Como Aumentar tus Seguidores en Instagram con Instabot Python.png', 11),
(4, 'upload/como instalar wordpress en local con xampp.png', 11),
(7, 'upload/como descargar video de Instagram Facebook Twitter Youtube Linkedin desde el Movil.jpg', 12);

CREATE TABLE `post` (
  `post_id` int(11) NOT NULL,
  `member_id` int(11) NOT NULL,
  `content` varchar(1000) NOT NULL,
  `date_posted` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

INSERT INTO `post` (`post_id`, `member_id`, `content`, `date_posted`) VALUES
(5, 11, 'Hola a todos esto es una prueba !!!', '2020-03-12 09:19:12'),
(7, 12, 'Hola', '2020-03-12 10:31:09'),
(9, 11, 'Hola a todos estoy feliz de poder interactuar en esta red social', '2020-03-12 20:02:27'),
(10, 13, 'Me place mucho acceder a esta nueva gran red social', '2020-03-12 20:11:03');

CREATE TABLE `schedule` (
  `id` int(11) NOT NULL,
  `member_id` int(11) NOT NULL,
  `date` varchar(100) NOT NULL,
  `service_id` int(11) NOT NULL,
  `Number` int(11) NOT NULL,
  `status` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

INSERT INTO `schedule` (`id`, `member_id`, `date`, `service_id`, `Number`, `status`) VALUES
(76, 1, '11/09/2013', 1, 1, 'Done'),
(77, 1, '11/09/2013', 1, 1, 'Pending'),
(78, 1, '10/09/2013', 1, 1, 'Done');

CREATE TABLE `service` (
  `service_id` int(11) NOT NULL,
  `service_offer` varchar(100) NOT NULL,
  `price` decimal(11,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

INSERT INTO `service` (`service_id`, `service_offer`, `price`) VALUES
(1, 'Cleaning', '700.00'),
(2, 'q', '100.00');

CREATE TABLE `users` (
  `user_id` int(11) NOT NULL,
  `username` varchar(100) NOT NULL,
  `password` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

INSERT INTO `users` (`user_id`, `username`, `password`) VALUES
(5, 'configuroweb', '1234abcd..');

ALTER TABLE `friends`
  ADD PRIMARY KEY (`my_friend_id`);

ALTER TABLE `members`
  ADD PRIMARY KEY (`member_id`);

ALTER TABLE `message`
  ADD PRIMARY KEY (`message_id`);

ALTER TABLE `note`
  ADD PRIMARY KEY (`note_id`);

ALTER TABLE `photos`
  ADD PRIMARY KEY (`photos_id`);

ALTER TABLE `post`
  ADD PRIMARY KEY (`post_id`);

ALTER TABLE `schedule`
  ADD PRIMARY KEY (`id`);

ALTER TABLE `service`
  ADD PRIMARY KEY (`service_id`);

ALTER TABLE `users`
  ADD PRIMARY KEY (`user_id`);

ALTER TABLE `friends`
  MODIFY `my_friend_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

ALTER TABLE `members`
  MODIFY `member_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

ALTER TABLE `message`
  MODIFY `message_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

ALTER TABLE `note`
  MODIFY `note_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

ALTER TABLE `photos`
  MODIFY `photos_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

ALTER TABLE `post`
  MODIFY `post_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

ALTER TABLE `schedule`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=79;

ALTER TABLE `service`
  MODIFY `service_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

ALTER TABLE `users`
  MODIFY `user_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;
COMMIT;

