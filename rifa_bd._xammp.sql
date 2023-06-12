-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 12-06-2023 a las 11:21:26
-- Versión del servidor: 10.4.28-MariaDB
-- Versión de PHP: 8.0.28

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `rifa_bd`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `boleto`
--

CREATE TABLE `boleto` (
  `idboleto` int(11) NOT NULL,
  `idcliente` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Volcado de datos para la tabla `boleto`
--

INSERT INTO `boleto` (`idboleto`, `idcliente`) VALUES
(1, 4),
(2, 5);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cliente`
--

CREATE TABLE `cliente` (
  `IdCliente` int(11) NOT NULL,
  `Nombres` varchar(100) NOT NULL,
  `Apellidos` varchar(100) NOT NULL,
  `Email` varchar(120) NOT NULL,
  `Clave` varchar(500) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Volcado de datos para la tabla `cliente`
--

INSERT INTO `cliente` (`IdCliente`, `Nombres`, `Apellidos`, `Email`, `Clave`) VALUES
(4, 'rodrigo', 'troconis', 'rod@gmail.com', '52c59993d8e149a1d70b65cb08abf692'),
(5, 'carlos', 'autenticado', 'c@gmail.com', '202cb962ac59075b964b07152d234b70'),
(9, 'juan', 'perez', 'juan@gmail.com', '81dc9bdb52d04dc20036dbd8313ed055'),
(10, 'luis', 'perez', 'luis@gmail.com', '827ccb0eea8a706c4c34a16891f84e7b'),
(14, 'pepe', 'perez', 'pepe@gmail.com', 'cdaeb1282d614772beb1e74c192bebda'),
(15, 'julio', 'perez', 'julio@gmail.com', 'a6df42c30dbbbcf63db6d0cb20c72799'),
(18, 'diego', 'perez', 'diego@gmail.com', '0b35f918b2d9f85185a03ff165e05179'),
(19, 'santiago', 'lucia', 'lucia@gmail.com', 'e1dd7fe8ce0a3cb4371b2172add67406'),
(20, 'luis', 'suarez', 'suarez@gmail.com', '701e021d1941f8eb67a07cd719953857'),
(21, 'mario', 'suarez', 'mario@gmail.com', '804a035d8d9710153f574e6a819e0d15');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `premio`
--

CREATE TABLE `premio` (
  `idpremio` int(11) NOT NULL,
  `nombre` varchar(500) NOT NULL,
  `idboleto` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `boleto`
--
ALTER TABLE `boleto`
  ADD PRIMARY KEY (`idboleto`),
  ADD UNIQUE KEY `idboletos_UNIQUE` (`idboleto`),
  ADD KEY `idcliente_idx` (`idcliente`);

--
-- Indices de la tabla `cliente`
--
ALTER TABLE `cliente`
  ADD PRIMARY KEY (`IdCliente`),
  ADD UNIQUE KEY `Email_UNIQUE` (`Email`),
  ADD UNIQUE KEY `Clave_UNIQUE` (`Clave`),
  ADD UNIQUE KEY `IdCliente_UNIQUE` (`IdCliente`);

--
-- Indices de la tabla `premio`
--
ALTER TABLE `premio`
  ADD PRIMARY KEY (`idpremio`),
  ADD UNIQUE KEY `idboletos_UNIQUE` (`idpremio`),
  ADD KEY `idboleto_idx` (`idboleto`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `cliente`
--
ALTER TABLE `cliente`
  MODIFY `IdCliente` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=27;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `boleto`
--
ALTER TABLE `boleto`
  ADD CONSTRAINT `idcliente` FOREIGN KEY (`idcliente`) REFERENCES `cliente` (`IdCliente`);

--
-- Filtros para la tabla `premio`
--
ALTER TABLE `premio`
  ADD CONSTRAINT `idboleto` FOREIGN KEY (`idboleto`) REFERENCES `boleto` (`idboleto`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
