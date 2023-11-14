-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 14-11-2023 a las 10:18:53
-- Versión del servidor: 10.4.28-MariaDB
-- Versión de PHP: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `proyectosube`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tarjetainternacional`
--

CREATE TABLE `tarjetainternacional` (
  `Id` int(11) NOT NULL,
  `Saldo` decimal(10,2) DEFAULT NULL,
  `Viajes` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_bin DEFAULT NULL CHECK (json_valid(`Viajes`))
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `tarjetainternacional`
--

INSERT INTO `tarjetainternacional` (`Id`, `Saldo`, `Viajes`) VALUES
(5020, 0.00, '[]'),
(5034, 0.00, '[]'),
(5035, 0.00, '[]'),
(5036, 0.00, '[]'),
(5038, 1200.00, '[{\"MedioTransporte\":0,\"FechaHora\":\"2023-10-12T18:29:53.7217006-03:00\",\"ValorBoleto\":700.0},{\"MedioTransporte\":0,\"FechaHora\":\"2023-10-21T18:29:53.7219678-03:00\",\"ValorBoleto\":700.0},{\"MedioTransporte\":2,\"FechaHora\":\"2023-11-01T18:29:53.721973-03:00\",\"ValorBoleto\":1500.0},{\"MedioTransporte\":1,\"FechaHora\":\"2023-11-29T18:29:53.7219757-03:00\",\"ValorBoleto\":1100.0},{\"MedioTransporte\":2,\"FechaHora\":\"2023-10-18T18:29:53.7219769-03:00\",\"ValorBoleto\":1500.0},{\"MedioTransporte\":2,\"FechaHora\":\"2023-10-28T18:29:53.8346507-03:00\",\"ValorBoleto\":1500.0},{\"MedioTransporte\":2,\"FechaHora\":\"2023-12-01T18:29:53.8585695-03:00\",\"ValorBoleto\":1500.0},{\"MedioTransporte\":3,\"FechaHora\":\"2023-10-11T18:29:53.8856434-03:00\",\"ValorBoleto\":2000.0},{\"MedioTransporte\":1,\"FechaHora\":\"2023-11-27T18:29:53.9441761-03:00\",\"ValorBoleto\":1100.0},{\"MedioTransporte\":0,\"FechaHora\":\"2023-10-11T18:30:09.6713333-03:00\",\"ValorBoleto\":700.0},{\"MedioTransporte\":3,\"FechaHora\":\"2023-11-23T18:30:09.6713657-03:00\",\"ValorBoleto\":2000.0},{\"MedioTransporte\":1,\"FechaHora\":\"2023-12-06T18:30:09.6713716-03:00\",\"ValorBoleto\":1100.0},{\"MedioTransporte\":3,\"FechaHora\":\"2023-10-31T18:30:09.6713745-03:00\",\"ValorBoleto\":2000.0},{\"MedioTransporte\":3,\"FechaHora\":\"2023-11-16T18:30:09.6713772-03:00\",\"ValorBoleto\":2000.0},{\"MedioTransporte\":3,\"FechaHora\":\"2023-11-20T18:30:09.7128939-03:00\",\"ValorBoleto\":2000.0},{\"MedioTransporte\":1,\"FechaHora\":\"2023-12-01T18:30:09.814616-03:00\",\"ValorBoleto\":1100.0}]'),
(5041, 0.00, '[{\"MedioTransporte\":3,\"FechaHora\":\"2023-10-23T18:33:15.3493896-03:00\",\"ValorBoleto\":2000.0},{\"MedioTransporte\":3,\"FechaHora\":\"2023-11-28T18:33:15.3498533-03:00\",\"ValorBoleto\":2000.0},{\"MedioTransporte\":1,\"FechaHora\":\"2023-10-21T18:33:15.3498644-03:00\",\"ValorBoleto\":1100.0},{\"MedioTransporte\":3,\"FechaHora\":\"2023-10-26T18:33:15.3498692-03:00\",\"ValorBoleto\":2000.0},{\"MedioTransporte\":3,\"FechaHora\":\"2023-10-26T18:33:15.3498716-03:00\",\"ValorBoleto\":2000.0},{\"MedioTransporte\":3,\"FechaHora\":\"2023-11-24T18:33:15.4715025-03:00\",\"ValorBoleto\":2000.0},{\"MedioTransporte\":2,\"FechaHora\":\"2023-10-25T18:33:15.4988317-03:00\",\"ValorBoleto\":1500.0}]'),
(5044, 0.00, '[{\"MedioTransporte\":2,\"FechaHora\":\"2023-10-16T18:31:15.6610088-03:00\",\"ValorBoleto\":1500.0},{\"MedioTransporte\":1,\"FechaHora\":\"2023-11-02T18:31:15.661055-03:00\",\"ValorBoleto\":1100.0},{\"MedioTransporte\":1,\"FechaHora\":\"2023-10-27T18:31:15.6610579-03:00\",\"ValorBoleto\":1100.0},{\"MedioTransporte\":1,\"FechaHora\":\"2023-11-23T18:31:15.6610604-03:00\",\"ValorBoleto\":1100.0},{\"MedioTransporte\":2,\"FechaHora\":\"2023-10-25T18:31:15.6610636-03:00\",\"ValorBoleto\":1500.0},{\"MedioTransporte\":2,\"FechaHora\":\"2023-11-07T18:31:15.7130656-03:00\",\"ValorBoleto\":1500.0},{\"MedioTransporte\":2,\"FechaHora\":\"2023-11-13T18:31:15.7471793-03:00\",\"ValorBoleto\":1500.0},{\"MedioTransporte\":2,\"FechaHora\":\"2023-10-30T18:31:33.8049478-03:00\",\"ValorBoleto\":1500.0}]'),
(5047, 123500.00, '[{\"MedioTransporte\":0,\"FechaHora\":\"2023-10-23T21:42:47.7517716-03:00\",\"ValorBoleto\":700.0},{\"MedioTransporte\":0,\"FechaHora\":\"2023-10-27T21:42:40.4795072-03:00\",\"ValorBoleto\":700.0},{\"MedioTransporte\":3,\"FechaHora\":\"2023-10-28T21:42:49.4098423-03:00\",\"ValorBoleto\":2000.0},{\"MedioTransporte\":1,\"FechaHora\":\"2023-11-04T21:42:47.7517088-03:00\",\"ValorBoleto\":1100.0},{\"MedioTransporte\":2,\"FechaHora\":\"2023-11-04T21:42:47.7517655-03:00\",\"ValorBoleto\":1500.0},{\"MedioTransporte\":2,\"FechaHora\":\"2023-11-07T21:42:47.7517687-03:00\",\"ValorBoleto\":1500.0},{\"MedioTransporte\":1,\"FechaHora\":\"2023-12-08T21:42:47.7517435-03:00\",\"ValorBoleto\":1100.0},{\"MedioTransporte\":0,\"FechaHora\":\"2023-11-16T21:42:50.1376775-03:00\",\"ValorBoleto\":700.0}]');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tarjetanacional`
--

CREATE TABLE `tarjetanacional` (
  `Id` int(11) NOT NULL,
  `Saldo` decimal(10,0) DEFAULT NULL,
  `Viajes` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_bin DEFAULT NULL CHECK (json_valid(`Viajes`))
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `tarjetanacional`
--

INSERT INTO `tarjetanacional` (`Id`, `Saldo`, `Viajes`) VALUES
(1013, 0, '[{\"MedioTransporte\":1,\"FechaHora\":\"2023-10-23T09:42:46.6821664-03:00\",\"ValorBoleto\":35.0},{\"MedioTransporte\":3,\"FechaHora\":\"2023-11-03T09:42:48.9690606-03:00\",\"ValorBoleto\":120.0},{\"MedioTransporte\":2,\"FechaHora\":\"2023-11-02T09:42:49.6655399-03:00\",\"ValorBoleto\":80.0},{\"MedioTransporte\":2,\"FechaHora\":\"2023-10-07T09:42:50.2572009-03:00\",\"ValorBoleto\":80.0},{\"MedioTransporte\":1,\"FechaHora\":\"2023-11-06T09:42:50.9131707-03:00\",\"ValorBoleto\":35.0}]'),
(1015, 0, '[]'),
(1016, 0, '[]'),
(1017, 0, '[]'),
(1018, 0, '[]'),
(1031, 0, '[{\"MedioTransporte\":1,\"FechaHora\":\"2023-11-02T13:33:22.0924378-03:00\",\"ValorBoleto\":35.0},{\"MedioTransporte\":0,\"FechaHora\":\"2023-11-11T13:33:22.8198328-03:00\",\"ValorBoleto\":50.0},{\"MedioTransporte\":2,\"FechaHora\":\"2023-12-03T13:33:23.443472-03:00\",\"ValorBoleto\":80.0},{\"MedioTransporte\":3,\"FechaHora\":\"2023-11-14T13:33:23.8918642-03:00\",\"ValorBoleto\":120.0}]'),
(1034, 6000, '[{\"MedioTransporte\":0,\"FechaHora\":\"2023-10-12T13:37:11.5547858-03:00\",\"ValorBoleto\":50.0},{\"MedioTransporte\":2,\"FechaHora\":\"2023-11-27T13:37:11.8020982-03:00\",\"ValorBoleto\":80.0},{\"MedioTransporte\":1,\"FechaHora\":\"2023-12-07T13:37:12.0257854-03:00\",\"ValorBoleto\":35.0},{\"MedioTransporte\":3,\"FechaHora\":\"2023-11-30T13:37:12.2021891-03:00\",\"ValorBoleto\":120.0},{\"MedioTransporte\":1,\"FechaHora\":\"2023-11-16T13:37:12.3777076-03:00\",\"ValorBoleto\":35.0},{\"MedioTransporte\":0,\"FechaHora\":\"2023-10-17T13:37:12.5457879-03:00\",\"ValorBoleto\":50.0},{\"MedioTransporte\":3,\"FechaHora\":\"2023-11-08T13:37:12.7137781-03:00\",\"ValorBoleto\":120.0},{\"MedioTransporte\":2,\"FechaHora\":\"2023-11-28T17:51:09.6421576-03:00\",\"ValorBoleto\":80.0},{\"MedioTransporte\":0,\"FechaHora\":\"2023-12-08T17:51:09.6424297-03:00\",\"ValorBoleto\":50.0},{\"MedioTransporte\":0,\"FechaHora\":\"2023-11-10T17:51:09.6424372-03:00\",\"ValorBoleto\":50.0},{\"MedioTransporte\":1,\"FechaHora\":\"2023-11-05T17:51:09.6424413-03:00\",\"ValorBoleto\":35.0},{\"MedioTransporte\":1,\"FechaHora\":\"2023-11-15T17:51:09.642443-03:00\",\"ValorBoleto\":35.0},{\"MedioTransporte\":2,\"FechaHora\":\"2023-11-25T17:51:13.7204208-03:00\",\"ValorBoleto\":80.0},{\"MedioTransporte\":3,\"FechaHora\":\"2023-11-22T17:51:13.7204354-03:00\",\"ValorBoleto\":120.0},{\"MedioTransporte\":1,\"FechaHora\":\"2023-11-18T17:51:13.7204365-03:00\",\"ValorBoleto\":35.0},{\"MedioTransporte\":0,\"FechaHora\":\"2023-11-07T17:51:13.720439-03:00\",\"ValorBoleto\":50.0},{\"MedioTransporte\":2,\"FechaHora\":\"2023-11-17T17:51:13.7204406-03:00\",\"ValorBoleto\":80.0},{\"MedioTransporte\":2,\"FechaHora\":\"2023-10-28T17:51:17.4812838-03:00\",\"ValorBoleto\":80.0},{\"MedioTransporte\":1,\"FechaHora\":\"2023-12-06T17:51:19.464586-03:00\",\"ValorBoleto\":35.0},{\"MedioTransporte\":1,\"FechaHora\":\"2023-10-13T17:51:22.2727961-03:00\",\"ValorBoleto\":35.0}]'),
(1036, 600, '[{\"MedioTransporte\":3,\"FechaHora\":\"2023-10-27T18:05:02.4451644-03:00\",\"ValorBoleto\":120.0},{\"MedioTransporte\":0,\"FechaHora\":\"2023-11-04T18:05:02.4454249-03:00\",\"ValorBoleto\":50.0},{\"MedioTransporte\":0,\"FechaHora\":\"2023-12-03T18:05:02.4454334-03:00\",\"ValorBoleto\":50.0},{\"MedioTransporte\":2,\"FechaHora\":\"2023-11-05T18:05:02.4454348-03:00\",\"ValorBoleto\":80.0},{\"MedioTransporte\":2,\"FechaHora\":\"2023-11-27T18:05:02.445436-03:00\",\"ValorBoleto\":80.0},{\"MedioTransporte\":2,\"FechaHora\":\"2023-10-22T18:05:05.5899481-03:00\",\"ValorBoleto\":80.0},{\"MedioTransporte\":1,\"FechaHora\":\"2023-12-04T18:05:05.5948992-03:00\",\"ValorBoleto\":35.0},{\"MedioTransporte\":3,\"FechaHora\":\"2023-11-15T18:05:05.6582928-03:00\",\"ValorBoleto\":120.0},{\"MedioTransporte\":3,\"FechaHora\":\"2023-10-31T18:05:05.9050419-03:00\",\"ValorBoleto\":120.0},{\"MedioTransporte\":3,\"FechaHora\":\"2023-11-18T18:05:05.9136855-03:00\",\"ValorBoleto\":120.0},{\"MedioTransporte\":1,\"FechaHora\":\"2023-11-10T18:05:05.9208385-03:00\",\"ValorBoleto\":35.0},{\"MedioTransporte\":3,\"FechaHora\":\"2023-11-15T18:05:05.9271462-03:00\",\"ValorBoleto\":120.0},{\"MedioTransporte\":2,\"FechaHora\":\"2023-11-24T18:05:11.8347531-03:00\",\"ValorBoleto\":80.0},{\"MedioTransporte\":0,\"FechaHora\":\"2023-10-31T18:05:13.3864328-03:00\",\"ValorBoleto\":50.0},{\"MedioTransporte\":2,\"FechaHora\":\"2023-10-30T18:05:20.2981378-03:00\",\"ValorBoleto\":80.0},{\"MedioTransporte\":2,\"FechaHora\":\"2023-11-01T18:05:20.9940891-03:00\",\"ValorBoleto\":80.0},{\"MedioTransporte\":2,\"FechaHora\":\"2023-12-09T18:05:20.9941041-03:00\",\"ValorBoleto\":80.0},{\"MedioTransporte\":3,\"FechaHora\":\"2023-10-29T18:05:20.9941078-03:00\",\"ValorBoleto\":120.0},{\"MedioTransporte\":2,\"FechaHora\":\"2023-11-10T18:05:20.9941091-03:00\",\"ValorBoleto\":80.0},{\"MedioTransporte\":1,\"FechaHora\":\"2023-11-11T18:05:20.9941103-03:00\",\"ValorBoleto\":35.0},{\"MedioTransporte\":3,\"FechaHora\":\"2023-10-27T18:05:02.4451644-03:00\",\"ValorBoleto\":120.0},{\"MedioTransporte\":0,\"FechaHora\":\"2023-11-04T18:05:02.4454249-03:00\",\"ValorBoleto\":50.0},{\"MedioTransporte\":0,\"FechaHora\":\"2023-12-03T18:05:02.4454334-03:00\",\"ValorBoleto\":50.0},{\"MedioTransporte\":2,\"FechaHora\":\"2023-11-05T18:05:02.4454348-03:00\",\"ValorBoleto\":80.0},{\"MedioTransporte\":2,\"FechaHora\":\"2023-11-27T18:05:02.445436-03:00\",\"ValorBoleto\":80.0},{\"MedioTransporte\":2,\"FechaHora\":\"2023-10-22T18:05:05.5899481-03:00\",\"ValorBoleto\":80.0},{\"MedioTransporte\":1,\"FechaHora\":\"2023-12-04T18:05:05.5948992-03:00\",\"ValorBoleto\":35.0},{\"MedioTransporte\":3,\"FechaHora\":\"2023-11-15T18:05:05.6582928-03:00\",\"ValorBoleto\":120.0},{\"MedioTransporte\":3,\"FechaHora\":\"2023-10-31T18:05:05.9050419-03:00\",\"ValorBoleto\":120.0},{\"MedioTransporte\":3,\"FechaHora\":\"2023-11-18T18:05:05.9136855-03:00\",\"ValorBoleto\":120.0},{\"MedioTransporte\":1,\"FechaHora\":\"2023-11-10T18:05:05.9208385-03:00\",\"ValorBoleto\":35.0},{\"MedioTransporte\":3,\"FechaHora\":\"2023-11-15T18:05:05.9271462-03:00\",\"ValorBoleto\":120.0},{\"MedioTransporte\":2,\"FechaHora\":\"2023-11-24T18:05:11.8347531-03:00\",\"ValorBoleto\":80.0},{\"MedioTransporte\":0,\"FechaHora\":\"2023-10-31T18:05:13.3864328-03:00\",\"ValorBoleto\":50.0},{\"MedioTransporte\":2,\"FechaHora\":\"2023-10-30T18:05:20.2981378-03:00\",\"ValorBoleto\":80.0},{\"MedioTransporte\":2,\"FechaHora\":\"2023-11-01T18:05:20.9940891-03:00\",\"ValorBoleto\":80.0},{\"MedioTransporte\":2,\"FechaHora\":\"2023-12-09T18:05:20.9941041-03:00\",\"ValorBoleto\":80.0},{\"MedioTransporte\":3,\"FechaHora\":\"2023-10-29T18:05:20.9941078-03:00\",\"ValorBoleto\":120.0},{\"MedioTransporte\":2,\"FechaHora\":\"2023-11-10T18:05:20.9941091-03:00\",\"ValorBoleto\":80.0},{\"MedioTransporte\":1,\"FechaHora\":\"2023-11-11T18:05:20.9941103-03:00\",\"ValorBoleto\":35.0},{\"MedioTransporte\":2,\"FechaHora\":\"2023-11-14T18:07:46.2368116-03:00\",\"ValorBoleto\":80.0},{\"MedioTransporte\":2,\"FechaHora\":\"2023-10-22T18:07:49.0752094-03:00\",\"ValorBoleto\":80.0},{\"MedioTransporte\":0,\"FechaHora\":\"2023-12-10T18:07:51.7466104-03:00\",\"ValorBoleto\":50.0},{\"MedioTransporte\":0,\"FechaHora\":\"2023-10-24T18:07:54.1151518-03:00\",\"ValorBoleto\":50.0},{\"MedioTransporte\":3,\"FechaHora\":\"2023-10-16T18:07:54.1151645-03:00\",\"ValorBoleto\":120.0},{\"MedioTransporte\":1,\"FechaHora\":\"2023-11-12T18:07:54.1151658-03:00\",\"ValorBoleto\":35.0},{\"MedioTransporte\":3,\"FechaHora\":\"2023-10-11T18:07:54.1151671-03:00\",\"ValorBoleto\":120.0},{\"MedioTransporte\":2,\"FechaHora\":\"2023-10-26T18:07:54.1151683-03:00\",\"ValorBoleto\":80.0},{\"MedioTransporte\":3,\"FechaHora\":\"2023-11-19T18:20:57.9999333-03:00\",\"ValorBoleto\":120.0},{\"MedioTransporte\":0,\"FechaHora\":\"2023-10-24T18:20:58.000176-03:00\",\"ValorBoleto\":50.0},{\"MedioTransporte\":3,\"FechaHora\":\"2023-11-23T18:20:58.0001816-03:00\",\"ValorBoleto\":120.0},{\"MedioTransporte\":2,\"FechaHora\":\"2023-11-18T18:20:58.0001829-03:00\",\"ValorBoleto\":80.0},{\"MedioTransporte\":1,\"FechaHora\":\"2023-12-05T18:20:58.0001848-03:00\",\"ValorBoleto\":35.0},{\"MedioTransporte\":0,\"FechaHora\":\"2023-11-08T18:21:03.1318118-03:00\",\"ValorBoleto\":50.0},{\"MedioTransporte\":1,\"FechaHora\":\"2023-12-10T18:21:03.1331246-03:00\",\"ValorBoleto\":35.0},{\"MedioTransporte\":0,\"FechaHora\":\"2023-12-07T18:21:03.1342244-03:00\",\"ValorBoleto\":50.0},{\"MedioTransporte\":1,\"FechaHora\":\"2023-12-10T18:21:03.1360238-03:00\",\"ValorBoleto\":35.0},{\"MedioTransporte\":3,\"FechaHora\":\"2023-12-02T18:21:03.179458-03:00\",\"ValorBoleto\":120.0},{\"MedioTransporte\":3,\"FechaHora\":\"2023-12-10T18:21:03.20101-03:00\",\"ValorBoleto\":120.0},{\"MedioTransporte\":3,\"FechaHora\":\"2023-11-29T18:21:03.2286029-03:00\",\"ValorBoleto\":120.0},{\"MedioTransporte\":0,\"FechaHora\":\"2023-12-10T18:21:03.2518013-03:00\",\"ValorBoleto\":50.0},{\"MedioTransporte\":1,\"FechaHora\":\"2023-11-27T18:21:04.4138266-03:00\",\"ValorBoleto\":35.0},{\"MedioTransporte\":2,\"FechaHora\":\"2023-11-04T18:21:04.9175892-03:00\",\"ValorBoleto\":80.0},{\"MedioTransporte\":3,\"FechaHora\":\"2023-11-25T18:21:06.1895043-03:00\",\"ValorBoleto\":120.0},{\"MedioTransporte\":2,\"FechaHora\":\"2023-11-29T18:21:06.1896014-03:00\",\"ValorBoleto\":80.0},{\"MedioTransporte\":3,\"FechaHora\":\"2023-11-06T18:21:06.1896037-03:00\",\"ValorBoleto\":120.0},{\"MedioTransporte\":2,\"FechaHora\":\"2023-12-06T18:21:06.1896057-03:00\",\"ValorBoleto\":80.0},{\"MedioTransporte\":2,\"FechaHora\":\"2023-11-14T18:21:06.1896196-03:00\",\"ValorBoleto\":80.0},{\"MedioTransporte\":1,\"FechaHora\":\"2023-10-12T18:21:11.2354331-03:00\",\"ValorBoleto\":35.0},{\"MedioTransporte\":2,\"FechaHora\":\"2023-12-05T18:21:11.2368302-03:00\",\"ValorBoleto\":80.0},{\"MedioTransporte\":3,\"FechaHora\":\"2023-12-09T18:21:11.46302-03:00\",\"ValorBoleto\":120.0}]'),
(1037, 1200, '[{\"MedioTransporte\":1,\"FechaHora\":\"2023-10-26T18:15:30.7312684-03:00\",\"ValorBoleto\":35.0},{\"MedioTransporte\":3,\"FechaHora\":\"2023-11-22T18:15:30.7315-03:00\",\"ValorBoleto\":120.0},{\"MedioTransporte\":0,\"FechaHora\":\"2023-10-24T18:15:30.7315067-03:00\",\"ValorBoleto\":50.0},{\"MedioTransporte\":0,\"FechaHora\":\"2023-11-06T18:15:30.731508-03:00\",\"ValorBoleto\":50.0},{\"MedioTransporte\":2,\"FechaHora\":\"2023-11-03T18:15:30.7315092-03:00\",\"ValorBoleto\":80.0},{\"MedioTransporte\":3,\"FechaHora\":\"2023-11-29T18:15:33.7995713-03:00\",\"ValorBoleto\":120.0},{\"MedioTransporte\":2,\"FechaHora\":\"2023-12-01T18:15:33.801887-03:00\",\"ValorBoleto\":80.0},{\"MedioTransporte\":2,\"FechaHora\":\"2023-11-04T18:15:33.8111946-03:00\",\"ValorBoleto\":80.0},{\"MedioTransporte\":0,\"FechaHora\":\"2023-12-09T18:15:34.0651157-03:00\",\"ValorBoleto\":50.0},{\"MedioTransporte\":3,\"FechaHora\":\"2023-11-21T18:15:36.8302878-03:00\",\"ValorBoleto\":120.0},{\"MedioTransporte\":2,\"FechaHora\":\"2023-10-25T18:15:37.5022508-03:00\",\"ValorBoleto\":80.0},{\"MedioTransporte\":1,\"FechaHora\":\"2023-12-08T18:15:38.7261162-03:00\",\"ValorBoleto\":35.0},{\"MedioTransporte\":2,\"FechaHora\":\"2023-10-19T18:15:38.7262083-03:00\",\"ValorBoleto\":80.0},{\"MedioTransporte\":0,\"FechaHora\":\"2023-10-18T18:15:38.7262121-03:00\",\"ValorBoleto\":50.0},{\"MedioTransporte\":0,\"FechaHora\":\"2023-11-04T18:15:38.7262137-03:00\",\"ValorBoleto\":50.0},{\"MedioTransporte\":3,\"FechaHora\":\"2023-11-21T18:15:38.7262148-03:00\",\"ValorBoleto\":120.0},{\"MedioTransporte\":2,\"FechaHora\":\"2023-11-16T18:15:41.8209785-03:00\",\"ValorBoleto\":80.0},{\"MedioTransporte\":2,\"FechaHora\":\"2023-11-15T18:15:41.8223847-03:00\",\"ValorBoleto\":80.0},{\"MedioTransporte\":1,\"FechaHora\":\"2023-10-20T18:15:41.8396187-03:00\",\"ValorBoleto\":35.0},{\"MedioTransporte\":2,\"FechaHora\":\"2023-11-16T18:15:41.8719115-03:00\",\"ValorBoleto\":80.0},{\"MedioTransporte\":0,\"FechaHora\":\"2023-10-13T18:18:04.0643517-03:00\",\"ValorBoleto\":50.0},{\"MedioTransporte\":0,\"FechaHora\":\"2023-12-01T18:18:04.0646085-03:00\",\"ValorBoleto\":50.0},{\"MedioTransporte\":2,\"FechaHora\":\"2023-11-16T18:18:04.064614-03:00\",\"ValorBoleto\":80.0},{\"MedioTransporte\":0,\"FechaHora\":\"2023-11-16T18:18:04.0646155-03:00\",\"ValorBoleto\":50.0},{\"MedioTransporte\":0,\"FechaHora\":\"2023-11-29T18:18:04.0646174-03:00\",\"ValorBoleto\":50.0},{\"MedioTransporte\":1,\"FechaHora\":\"2023-12-04T18:18:09.1770947-03:00\",\"ValorBoleto\":35.0},{\"MedioTransporte\":1,\"FechaHora\":\"2023-11-13T18:18:09.1782449-03:00\",\"ValorBoleto\":35.0},{\"MedioTransporte\":2,\"FechaHora\":\"2023-12-07T18:18:09.1794472-03:00\",\"ValorBoleto\":80.0},{\"MedioTransporte\":1,\"FechaHora\":\"2023-10-14T18:18:09.1811073-03:00\",\"ValorBoleto\":35.0},{\"MedioTransporte\":1,\"FechaHora\":\"2023-10-24T18:18:09.2392152-03:00\",\"ValorBoleto\":35.0}]'),
(1040, 0, '[{\"MedioTransporte\":1,\"FechaHora\":\"2023-10-17T20:06:47.1993616-03:00\",\"ValorBoleto\":35.0},{\"MedioTransporte\":1,\"FechaHora\":\"2023-10-31T20:06:47.1993504-03:00\",\"ValorBoleto\":35.0},{\"MedioTransporte\":3,\"FechaHora\":\"2023-11-21T20:06:47.199358-03:00\",\"ValorBoleto\":120.0},{\"MedioTransporte\":3,\"FechaHora\":\"2023-11-24T20:06:47.1993634-03:00\",\"ValorBoleto\":120.0},{\"MedioTransporte\":0,\"FechaHora\":\"2023-11-30T20:06:47.2912696-03:00\",\"ValorBoleto\":50.0},{\"MedioTransporte\":1,\"FechaHora\":\"2023-12-04T20:06:47.1988353-03:00\",\"ValorBoleto\":35.0},{\"MedioTransporte\":3,\"FechaHora\":\"2023-10-17T20:06:47.3264835-03:00\",\"ValorBoleto\":120.0}]'),
(1042, 8050, '[{\"MedioTransporte\":3,\"FechaHora\":\"2023-10-23T00:11:05.386588-03:00\",\"ValorBoleto\":120.0},{\"MedioTransporte\":0,\"FechaHora\":\"2023-10-23T00:11:06.6744998-03:00\",\"ValorBoleto\":50.0},{\"MedioTransporte\":0,\"FechaHora\":\"2023-10-23T16:36:52.4599613-03:00\",\"ValorBoleto\":50.0},{\"MedioTransporte\":0,\"FechaHora\":\"2023-10-23T16:36:52.4599613-03:00\",\"ValorBoleto\":50.0},{\"MedioTransporte\":0,\"FechaHora\":\"2023-10-23T16:36:52.4599613-03:00\",\"ValorBoleto\":50.0},{\"MedioTransporte\":0,\"FechaHora\":\"2023-10-23T16:36:52.4599613-03:00\",\"ValorBoleto\":50.0},{\"MedioTransporte\":1,\"FechaHora\":\"2023-10-24T16:36:49.667818-03:00\",\"ValorBoleto\":35.0},{\"MedioTransporte\":1,\"FechaHora\":\"2023-10-24T16:36:49.667818-03:00\",\"ValorBoleto\":35.0},{\"MedioTransporte\":1,\"FechaHora\":\"2023-10-24T16:36:49.667818-03:00\",\"ValorBoleto\":35.0},{\"MedioTransporte\":1,\"FechaHora\":\"2023-10-24T16:36:49.667818-03:00\",\"ValorBoleto\":35.0},{\"MedioTransporte\":1,\"FechaHora\":\"2023-11-01T00:11:05.9788008-03:00\",\"ValorBoleto\":35.0},{\"MedioTransporte\":2,\"FechaHora\":\"2023-11-02T16:36:52.9959999-03:00\",\"ValorBoleto\":80.0},{\"MedioTransporte\":2,\"FechaHora\":\"2023-11-02T16:36:52.9959999-03:00\",\"ValorBoleto\":80.0},{\"MedioTransporte\":2,\"FechaHora\":\"2023-11-02T16:36:52.9959999-03:00\",\"ValorBoleto\":80.0},{\"MedioTransporte\":2,\"FechaHora\":\"2023-11-02T16:36:52.9959999-03:00\",\"ValorBoleto\":80.0},{\"MedioTransporte\":0,\"FechaHora\":\"2023-11-26T16:36:50.9800826-03:00\",\"ValorBoleto\":50.0},{\"MedioTransporte\":0,\"FechaHora\":\"2023-11-26T16:36:50.9800826-03:00\",\"ValorBoleto\":50.0},{\"MedioTransporte\":0,\"FechaHora\":\"2023-11-26T16:36:50.9800826-03:00\",\"ValorBoleto\":50.0},{\"MedioTransporte\":0,\"FechaHora\":\"2023-11-26T16:36:50.9800826-03:00\",\"ValorBoleto\":50.0},{\"MedioTransporte\":2,\"FechaHora\":\"2023-12-07T16:36:51.7721173-03:00\",\"ValorBoleto\":80.0},{\"MedioTransporte\":2,\"FechaHora\":\"2023-12-07T16:36:51.7721173-03:00\",\"ValorBoleto\":80.0},{\"MedioTransporte\":2,\"FechaHora\":\"2023-12-07T16:36:51.7721173-03:00\",\"ValorBoleto\":80.0},{\"MedioTransporte\":2,\"FechaHora\":\"2023-12-07T16:36:51.7721173-03:00\",\"ValorBoleto\":80.0},{\"MedioTransporte\":0,\"FechaHora\":\"2023-11-19T00:11:07.2899154-03:00\",\"ValorBoleto\":50.0}]');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuarioadministrador`
--

CREATE TABLE `usuarioadministrador` (
  `nombre` varchar(30) NOT NULL,
  `apellido` varchar(30) NOT NULL,
  `dni` varchar(30) NOT NULL,
  `clave` varchar(30) NOT NULL,
  `esadministrador` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `usuarioadministrador`
--

INSERT INTO `usuarioadministrador` (`nombre`, `apellido`, `dni`, `clave`, `esadministrador`) VALUES
('Carlos', 'Rua', '000', '1234', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuarioargentino`
--

CREATE TABLE `usuarioargentino` (
  `id` int(11) NOT NULL,
  `nombre` varchar(30) NOT NULL,
  `apellido` varchar(30) NOT NULL,
  `dni` varchar(8) NOT NULL,
  `clave` varchar(8) NOT NULL,
  `idSube` varchar(8) NOT NULL,
  `tienetarjeta` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `usuarioargentino`
--

INSERT INTO `usuarioargentino` (`id`, `nombre`, `apellido`, `dni`, `clave`, `idSube`, `tienetarjeta`) VALUES
(4, 'Pepe', 'Donda', '10000001', '1234', '1037', 127),
(5, 'Pepe', 'Sagalo', '30000000', '1234', '1040', 127),
(6, 'Ernesto', 'Fatala', '30555191', '1234', '1042', 127);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuarioextranjero`
--

CREATE TABLE `usuarioextranjero` (
  `id` int(11) NOT NULL,
  `nombre` varchar(30) NOT NULL,
  `apellido` varchar(30) NOT NULL,
  `dni` varchar(30) NOT NULL,
  `clave` varchar(8) NOT NULL,
  `idSube` varchar(8) NOT NULL,
  `tienetarjeta` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `usuarioextranjero`
--

INSERT INTO `usuarioextranjero` (`id`, `nombre`, `apellido`, `dni`, `clave`, `idSube`, `tienetarjeta`) VALUES
(2, 'Jhony', 'cash', '90000000', '1234', '5038', 1),
(3, 'CArl', 'seafg', '90000001', '1234', '5041', 1),
(4, 'Lolo', 'Das', '90000002', '1234', '5044', 1),
(5, 'Jhony', 'cash', '90000000', '1234', '5047', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuariosintarjeta`
--

CREATE TABLE `usuariosintarjeta` (
  `Id` int(11) NOT NULL,
  `nombre` varchar(255) NOT NULL,
  `apellido` varchar(255) NOT NULL,
  `dni` char(8) NOT NULL,
  `clave` varchar(255) NOT NULL,
  `tienetarjeta` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `usuariosintarjeta`
--

INSERT INTO `usuariosintarjeta` (`Id`, `nombre`, `apellido`, `dni`, `clave`, `tienetarjeta`) VALUES
(13, 'Carlos', 'Miguel', '10000000', '1234', 0);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `tarjetainternacional`
--
ALTER TABLE `tarjetainternacional`
  ADD PRIMARY KEY (`Id`);

--
-- Indices de la tabla `tarjetanacional`
--
ALTER TABLE `tarjetanacional`
  ADD PRIMARY KEY (`Id`);

--
-- Indices de la tabla `usuarioargentino`
--
ALTER TABLE `usuarioargentino`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `usuarioextranjero`
--
ALTER TABLE `usuarioextranjero`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `usuariosintarjeta`
--
ALTER TABLE `usuariosintarjeta`
  ADD PRIMARY KEY (`Id`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `usuarioargentino`
--
ALTER TABLE `usuarioargentino`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT de la tabla `usuarioextranjero`
--
ALTER TABLE `usuarioextranjero`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT de la tabla `usuariosintarjeta`
--
ALTER TABLE `usuariosintarjeta`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
