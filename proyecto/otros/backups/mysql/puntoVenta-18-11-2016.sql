-- MySQL dump 10.13  Distrib 5.7.12, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: punto_venta
-- ------------------------------------------------------
-- Server version	5.6.34-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `almacen`
--

DROP TABLE IF EXISTS `almacen`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `almacen` (
  `codigo` int(11) NOT NULL,
  `nombre` varchar(100) COLLATE utf8_bin DEFAULT NULL,
  `cod_sucursal` int(11) NOT NULL,
  `estado` tinyint(3) unsigned NOT NULL,
  PRIMARY KEY (`codigo`),
  KEY `almacen_sucursal_idx` (`cod_sucursal`),
  CONSTRAINT `almacen_sucursal` FOREIGN KEY (`cod_sucursal`) REFERENCES `sucursal` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `almacen`
--

LOCK TABLES `almacen` WRITE;
/*!40000 ALTER TABLE `almacen` DISABLE KEYS */;
INSERT INTO `almacen` VALUES (1,'ALMACEN PRINCIPAL',4,1);
/*!40000 ALTER TABLE `almacen` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `caja`
--

DROP TABLE IF EXISTS `caja`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `caja` (
  `codigo` int(11) NOT NULL,
  `nombre` varchar(100) COLLATE utf8_bin NOT NULL,
  `secuencia` varchar(100) COLLATE utf8_bin DEFAULT NULL,
  `cod_sucursal` int(11) NOT NULL,
  `activo` tinyint(3) unsigned NOT NULL DEFAULT '0',
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `caja`
--

LOCK TABLES `caja` WRITE;
/*!40000 ALTER TABLE `caja` DISABLE KEYS */;
INSERT INTO `caja` VALUES (1,'CAJA PRINCIPAL','001',4,1),(2,'CAJA SECUNDARIA','002',4,1),(3,'ejemplo','004',4,1);
/*!40000 ALTER TABLE `caja` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cajero`
--

DROP TABLE IF EXISTS `cajero`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cajero` (
  `codigo` int(11) NOT NULL,
  `cod_empleado` int(11) DEFAULT NULL,
  `cod_caja` int(11) DEFAULT NULL,
  `activo` tinyint(3) unsigned DEFAULT '1',
  PRIMARY KEY (`codigo`),
  KEY `cajero_caja_idx` (`cod_caja`),
  CONSTRAINT `cajero_caja` FOREIGN KEY (`cod_caja`) REFERENCES `caja` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `cajero_empleado` FOREIGN KEY (`codigo`) REFERENCES `empleado` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cajero`
--

LOCK TABLES `cajero` WRITE;
/*!40000 ALTER TABLE `cajero` DISABLE KEYS */;
INSERT INTO `cajero` VALUES (5,5,1,1);
/*!40000 ALTER TABLE `cajero` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cargo`
--

DROP TABLE IF EXISTS `cargo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cargo` (
  `codigo` int(11) NOT NULL,
  `nombre` varchar(50) CHARACTER SET utf8 NOT NULL,
  `estado` tinyint(3) unsigned NOT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cargo`
--

LOCK TABLES `cargo` WRITE;
/*!40000 ALTER TABLE `cargo` DISABLE KEYS */;
INSERT INTO `cargo` VALUES (1,'ADMINISTRADOR',1),(2,'GERENTE',1),(3,'CAJERO',1);
/*!40000 ALTER TABLE `cargo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `catalogo_cuentas`
--

DROP TABLE IF EXISTS `catalogo_cuentas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `catalogo_cuentas` (
  `codigo` int(11) NOT NULL,
  `descripcion` varchar(150) COLLATE utf8_bin DEFAULT NULL,
  `numero_cuenta` varchar(150) COLLATE utf8_bin DEFAULT NULL,
  `cuenta_master` tinyint(4) DEFAULT NULL,
  `cuenta_sub_master` tinyint(4) DEFAULT NULL,
  `cuenta_acumulativa` tinyint(4) DEFAULT NULL,
  `cuenta_movimiento` tinyint(4) DEFAULT NULL,
  `origen_credito` tinyint(4) DEFAULT NULL,
  `origen_debito` tinyint(4) DEFAULT NULL,
  `estado` tinyint(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `catalogo_cuentas`
--

LOCK TABLES `catalogo_cuentas` WRITE;
/*!40000 ALTER TABLE `catalogo_cuentas` DISABLE KEYS */;
/*!40000 ALTER TABLE `catalogo_cuentas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `categoria_producto`
--

DROP TABLE IF EXISTS `categoria_producto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `categoria_producto` (
  `codigo` int(11) NOT NULL,
  `nombre` varchar(100) COLLATE utf8_bin NOT NULL,
  `estado` tinyint(3) unsigned NOT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categoria_producto`
--

LOCK TABLES `categoria_producto` WRITE;
/*!40000 ALTER TABLE `categoria_producto` DISABLE KEYS */;
INSERT INTO `categoria_producto` VALUES (1,'GENERAL',1),(2,'COMESTIBLE',1),(3,'BEBIDAS',1),(4,'LIMPIEZA',1),(5,'CABALLEROS',1),(6,'DAMAS',1);
/*!40000 ALTER TABLE `categoria_producto` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cliente`
--

DROP TABLE IF EXISTS `cliente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cliente` (
  `codigo` int(11) NOT NULL DEFAULT '0',
  `nombre` varchar(100) COLLATE utf8_bin DEFAULT NULL,
  `limite_credito` decimal(20,2) DEFAULT NULL,
  `cod_categoria` int(11) DEFAULT NULL,
  `activo` tinyint(3) unsigned NOT NULL,
  `fecha_creado` date DEFAULT NULL,
  `abrir_credito` tinyint(3) unsigned DEFAULT '1',
  `cod_sucursal_creado` int(11) DEFAULT NULL,
  `cliente_contado` tinyint(3) unsigned DEFAULT '0',
  `telefono1` varchar(45) COLLATE utf8_bin NOT NULL DEFAULT '',
  `telefono2` varchar(45) COLLATE utf8_bin NOT NULL DEFAULT '',
  PRIMARY KEY (`codigo`),
  KEY `cliente_categoria_cliente_idx` (`cod_categoria`),
  KEY `cliente_sucursal_idx` (`cod_sucursal_creado`),
  CONSTRAINT `cliente_categoria_cliente` FOREIGN KEY (`cod_categoria`) REFERENCES `cliente_categoria` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `cliente_sucursal` FOREIGN KEY (`cod_sucursal_creado`) REFERENCES `sucursal` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cliente`
--

LOCK TABLES `cliente` WRITE;
/*!40000 ALTER TABLE `cliente` DISABLE KEYS */;
INSERT INTO `cliente` VALUES (1,NULL,0.00,1,1,'2016-07-23',1,4,0,'',''),(2,NULL,50000.00,1,1,'2016-07-23',1,4,1,'',''),(3,NULL,0.00,1,1,'2016-07-23',1,4,0,'',''),(5,NULL,10000000000.00,1,1,'2016-07-23',1,4,0,'',''),(7,NULL,0.00,1,1,'2016-07-23',1,4,0,'',''),(8,NULL,0.00,1,1,'2016-07-23',1,4,0,'',''),(9,NULL,0.00,1,1,'2016-07-23',1,4,0,'',''),(10,NULL,0.00,1,1,'2016-07-23',1,4,0,'',''),(11,NULL,0.00,1,1,'2016-07-23',1,4,0,'',''),(12,NULL,0.00,1,1,'2016-07-23',1,4,0,'',''),(13,NULL,0.00,1,1,'2016-07-23',1,4,0,'',''),(14,NULL,0.00,1,1,'2016-07-23',1,4,0,'',''),(15,NULL,0.00,1,1,'2016-07-23',1,4,0,'',''),(16,NULL,0.00,1,1,'2016-07-23',1,4,0,'',''),(17,NULL,0.00,1,1,'2016-07-23',1,4,0,'',''),(18,NULL,0.00,1,1,'2016-07-23',1,4,0,'',''),(19,NULL,0.00,1,1,'2016-07-23',1,4,0,'',''),(20,NULL,0.00,1,1,'2016-07-23',1,4,0,'',''),(21,NULL,0.00,1,1,'2016-07-23',1,4,0,'',''),(22,NULL,0.00,1,1,'2016-07-23',1,4,0,'',''),(23,NULL,0.00,1,1,'2016-07-23',1,4,0,'',''),(24,NULL,1.00,1,1,'2016-07-23',1,4,0,'',''),(25,NULL,1.00,1,1,'2016-07-23',1,4,0,'',''),(26,NULL,1.00,1,1,'2016-07-23',1,4,0,'',''),(27,NULL,1.00,1,1,'2016-07-23',1,4,0,'',''),(28,NULL,1.00,1,1,'2016-07-23',1,4,0,'',''),(29,NULL,1.00,1,1,'2016-07-23',1,4,0,'',''),(30,NULL,1.00,1,1,'2016-07-23',1,4,0,'',''),(31,NULL,1.00,1,1,'2016-07-23',1,4,0,'',''),(32,NULL,1.00,1,1,'2016-07-23',1,4,0,'',''),(33,NULL,1.00,1,1,'2016-07-23',1,4,0,'',''),(34,NULL,1.00,1,1,'2016-07-23',1,4,0,'',''),(35,NULL,1.00,1,1,'2016-07-23',1,4,0,'',''),(36,NULL,1.00,1,1,'2016-07-23',1,4,0,'',''),(37,NULL,1.00,1,1,'2016-07-23',1,4,0,'',''),(38,NULL,1.00,1,1,'2016-07-23',1,4,0,'','');
/*!40000 ALTER TABLE `cliente` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cliente_categoria`
--

DROP TABLE IF EXISTS `cliente_categoria`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cliente_categoria` (
  `codigo` int(11) NOT NULL,
  `nombre` varchar(50) COLLATE utf8_bin DEFAULT NULL,
  `activo` tinyint(3) unsigned DEFAULT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cliente_categoria`
--

LOCK TABLES `cliente_categoria` WRITE;
/*!40000 ALTER TABLE `cliente_categoria` DISABLE KEYS */;
INSERT INTO `cliente_categoria` VALUES (1,'GENERAL',1);
/*!40000 ALTER TABLE `cliente_categoria` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cobros`
--

DROP TABLE IF EXISTS `cobros`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cobros` (
  `codigo` int(11) NOT NULL,
  `efectivo` decimal(20,2) DEFAULT '0.00',
  `devuelta` decimal(20,2) DEFAULT '0.00',
  `descuento` decimal(20,2) DEFAULT '0.00',
  `fecha` datetime DEFAULT NULL,
  `detalle` longtext CHARACTER SET utf8,
  `cod_empleado` int(11) NOT NULL,
  `activo` tinyint(3) unsigned DEFAULT '0',
  `cod_empleado_anular` int(11) DEFAULT '0',
  `motivo_anulado` longtext CHARACTER SET utf8,
  `cuadrado` tinyint(3) unsigned DEFAULT '0',
  PRIMARY KEY (`codigo`),
  KEY `cobro_empleado_idx` (`cod_empleado`),
  CONSTRAINT `cobro_empleado` FOREIGN KEY (`cod_empleado`) REFERENCES `empleado` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cobros`
--

LOCK TABLES `cobros` WRITE;
/*!40000 ALTER TABLE `cobros` DISABLE KEYS */;
INSERT INTO `cobros` VALUES (1,0.00,0.00,0.00,'2016-10-23 00:00:00','',5,1,0,'',0),(2,0.00,0.00,0.00,'2016-10-23 00:00:00','',5,1,0,'',0);
/*!40000 ALTER TABLE `cobros` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cobros_detalles`
--

DROP TABLE IF EXISTS `cobros_detalles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cobros_detalles` (
  `codigo` int(11) NOT NULL,
  `cod_cobro` int(11) NOT NULL,
  `cod_factura` int(11) NOT NULL,
  `cod_metodo_pago` int(11) NOT NULL,
  `monto_pagado` decimal(20,2) DEFAULT '0.00',
  `monto_descontado` decimal(20,2) DEFAULT '0.00',
  `cod_empleado_anular` int(11) DEFAULT NULL,
  `motivo_anulado` longtext CHARACTER SET utf8,
  `estado` tinyint(3) unsigned DEFAULT '1',
  PRIMARY KEY (`codigo`),
  KEY `cobro_detalles_cobro_idx` (`cod_cobro`),
  KEY `cobros_detalle_factura_idx` (`cod_factura`),
  KEY `cobro_detalle_metodo_cobro_idx` (`cod_metodo_pago`),
  CONSTRAINT `cobro_detalle_cobro` FOREIGN KEY (`cod_cobro`) REFERENCES `cobros` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `cobro_detalle_metodo_pago` FOREIGN KEY (`cod_metodo_pago`) REFERENCES `metodo_pago` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `cobros_detalles_factura` FOREIGN KEY (`cod_factura`) REFERENCES `factura` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cobros_detalles`
--

LOCK TABLES `cobros_detalles` WRITE;
/*!40000 ALTER TABLE `cobros_detalles` DISABLE KEYS */;
/*!40000 ALTER TABLE `cobros_detalles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `compra`
--

DROP TABLE IF EXISTS `compra`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `compra` (
  `codigo` int(11) NOT NULL,
  `num_factura` varchar(100) CHARACTER SET utf8 NOT NULL,
  `cod_suplidor` int(11) NOT NULL,
  `fecha` date DEFAULT NULL,
  `fecha_limite` date DEFAULT NULL,
  `ncf` varchar(50) COLLATE utf8_bin DEFAULT NULL,
  `rnc` varchar(50) COLLATE utf8_bin DEFAULT NULL,
  `cod_tipo` varchar(5) CHARACTER SET utf8 NOT NULL,
  `estado` int(11) DEFAULT '1',
  `pagada` tinyint(3) unsigned DEFAULT '0',
  `cod_sucursal` int(11) DEFAULT NULL,
  `efectivo` decimal(20,5) DEFAULT '0.00000',
  `devuelta` decimal(20,5) DEFAULT '0.00000',
  `codigo_empleado` int(11) DEFAULT NULL,
  `codigo_empleado_anular` int(11) DEFAULT NULL,
  `motivo_anulado` varchar(200) COLLATE utf8_bin DEFAULT NULL,
  `compracol` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`codigo`),
  KEY `compra_suplidor_idx` (`cod_suplidor`),
  KEY `compra_sucursal_idx` (`cod_sucursal`),
  KEY `compra_empleado_idx` (`codigo_empleado`),
  CONSTRAINT `compra_empleado` FOREIGN KEY (`codigo_empleado`) REFERENCES `empleado` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `compra_sucursal` FOREIGN KEY (`cod_sucursal`) REFERENCES `sucursal` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `compra_suplidor` FOREIGN KEY (`cod_suplidor`) REFERENCES `suplidor` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `compra`
--

LOCK TABLES `compra` WRITE;
/*!40000 ALTER TABLE `compra` DISABLE KEYS */;
INSERT INTO `compra` VALUES (1,'1',7,'2016-10-27','2016-10-27','','22222222222','CRE',1,0,4,0.00000,0.00000,5,NULL,NULL,NULL),(2,'',7,'2016-10-27','2016-10-27','','22222222222','CRE',1,0,4,0.00000,0.00000,5,NULL,NULL,NULL);
/*!40000 ALTER TABLE `compra` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `compra_detalle`
--

DROP TABLE IF EXISTS `compra_detalle`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `compra_detalle` (
  `codigo` int(11) NOT NULL,
  `cod_compra` int(11) NOT NULL,
  `cod_producto` int(11) NOT NULL,
  `cod_unidad` int(11) NOT NULL,
  `precio` decimal(20,2) NOT NULL,
  `cantidad` decimal(20,2) NOT NULL,
  `monto` decimal(20,2) NOT NULL,
  `descuento` decimal(20,2) NOT NULL DEFAULT '0.00',
  `estado` int(11) NOT NULL DEFAULT '1',
  KEY `compra_detalle_unidad_idx` (`cod_unidad`),
  KEY `compra_detalle_compra_idx` (`cod_compra`),
  KEY `compra_detalle_producto_idx` (`cod_producto`),
  CONSTRAINT `compra_detalle` FOREIGN KEY (`cod_compra`) REFERENCES `compra` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `compra_detalle_producto` FOREIGN KEY (`cod_producto`) REFERENCES `producto` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `compra_detalle_unidad` FOREIGN KEY (`cod_unidad`) REFERENCES `unidad` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `compra_detalle`
--

LOCK TABLES `compra_detalle` WRITE;
/*!40000 ALTER TABLE `compra_detalle` DISABLE KEYS */;
/*!40000 ALTER TABLE `compra_detalle` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `comprobante_fiscal`
--

DROP TABLE IF EXISTS `comprobante_fiscal`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `comprobante_fiscal` (
  `codigo` int(11) NOT NULL,
  `cod_serie` int(11) DEFAULT NULL,
  `cod_caja` int(11) DEFAULT NULL,
  `codigo_tipo` int(11) DEFAULT NULL,
  `desde_numero` int(11) DEFAULT NULL,
  `hasta_numero` int(11) DEFAULT NULL,
  `contador` int(11) DEFAULT '0',
  `avisar` int(11) DEFAULT '0',
  `fecha` date DEFAULT NULL,
  PRIMARY KEY (`codigo`),
  KEY `comprobante_serie_idx` (`cod_serie`),
  KEY `comprobante_caja_idx` (`cod_caja`),
  KEY `comprobante_tipo_idx` (`codigo_tipo`),
  CONSTRAINT `comprobante_caja` FOREIGN KEY (`cod_caja`) REFERENCES `caja` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `comprobante_serie` FOREIGN KEY (`cod_serie`) REFERENCES `comprobante_serie` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `comprobante_tipo` FOREIGN KEY (`codigo_tipo`) REFERENCES `tipo_comprobante_fiscal` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `comprobante_fiscal`
--

LOCK TABLES `comprobante_fiscal` WRITE;
/*!40000 ALTER TABLE `comprobante_fiscal` DISABLE KEYS */;
INSERT INTO `comprobante_fiscal` VALUES (1,1,1,1,0,20,20,10,'2016-05-28'),(2,1,1,2,0,20,19,10,'2016-05-28'),(3,1,1,2,500,1050,0,50,'2016-10-02');
/*!40000 ALTER TABLE `comprobante_fiscal` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `comprobante_serie`
--

DROP TABLE IF EXISTS `comprobante_serie`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `comprobante_serie` (
  `codigo` int(11) NOT NULL,
  `serie` varchar(1) COLLATE utf8_bin NOT NULL,
  `nombre` varchar(100) COLLATE utf8_bin DEFAULT NULL,
  `estado` int(11) DEFAULT '1',
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `comprobante_serie`
--

LOCK TABLES `comprobante_serie` WRITE;
/*!40000 ALTER TABLE `comprobante_serie` DISABLE KEYS */;
INSERT INTO `comprobante_serie` VALUES (1,'A','NORMAL',1);
/*!40000 ALTER TABLE `comprobante_serie` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `comprobante_ventas`
--

DROP TABLE IF EXISTS `comprobante_ventas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `comprobante_ventas` (
  `codigo` int(11) NOT NULL,
  `cod_tipo_comprobante` int(11) DEFAULT NULL,
  `cod_caja` int(11) DEFAULT NULL,
  `contador` int(11) DEFAULT '0',
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `comprobante_ventas`
--

LOCK TABLES `comprobante_ventas` WRITE;
/*!40000 ALTER TABLE `comprobante_ventas` DISABLE KEYS */;
INSERT INTO `comprobante_ventas` VALUES (1,1,1,95),(2,2,1,19);
/*!40000 ALTER TABLE `comprobante_ventas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `correo_electronicos`
--

DROP TABLE IF EXISTS `correo_electronicos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `correo_electronicos` (
  `codigo` int(11) NOT NULL,
  `correo` longtext COLLATE utf8_bin,
  `clave` longtext COLLATE utf8_bin NOT NULL,
  `ssl_activo` tinyint(3) unsigned NOT NULL DEFAULT '1',
  `host` longtext COLLATE utf8_bin NOT NULL,
  `puerto` int(11) NOT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `correo_electronicos`
--

LOCK TABLES `correo_electronicos` WRITE;
/*!40000 ALTER TABLE `correo_electronicos` DISABLE KEYS */;
INSERT INTO `correo_electronicos` VALUES (1,'dextroyex21@gmail.com','wilmerlomas',1,'smtp.gmail.com',587);
/*!40000 ALTER TABLE `correo_electronicos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cuadre_caja`
--

DROP TABLE IF EXISTS `cuadre_caja`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cuadre_caja` (
  `codigo` int(11) NOT NULL,
  `cod_cajero` int(11) NOT NULL,
  `fecha` date NOT NULL,
  `turno` int(11) NOT NULL,
  `activo` tinyint(4) NOT NULL DEFAULT '1',
  `faltante` decimal(20,2) NOT NULL DEFAULT '0.00',
  `sobrante` decimal(20,2) NOT NULL DEFAULT '0.00',
  PRIMARY KEY (`codigo`,`cod_cajero`,`fecha`,`turno`),
  KEY `cuadre_cajero_idx` (`cod_cajero`),
  CONSTRAINT `cuadre_cajero` FOREIGN KEY (`cod_cajero`) REFERENCES `cajero` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cuadre_caja`
--

LOCK TABLES `cuadre_caja` WRITE;
/*!40000 ALTER TABLE `cuadre_caja` DISABLE KEYS */;
INSERT INTO `cuadre_caja` VALUES (1,5,'2016-08-28',1,1,0.00,0.00),(2,5,'2016-08-28',2,1,0.00,0.00),(3,5,'2016-10-26',1,1,0.00,0.00);
/*!40000 ALTER TABLE `cuadre_caja` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cuadre_caja_detalles`
--

DROP TABLE IF EXISTS `cuadre_caja_detalles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cuadre_caja_detalles` (
  `codigo_cuadre` int(11) NOT NULL,
  `cod_metodo_pago` int(11) NOT NULL,
  `monto` decimal(20,2) NOT NULL,
  PRIMARY KEY (`codigo_cuadre`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cuadre_caja_detalles`
--

LOCK TABLES `cuadre_caja_detalles` WRITE;
/*!40000 ALTER TABLE `cuadre_caja_detalles` DISABLE KEYS */;
/*!40000 ALTER TABLE `cuadre_caja_detalles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cuenta_bancaria`
--

DROP TABLE IF EXISTS `cuenta_bancaria`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cuenta_bancaria` (
  `codigo` int(11) NOT NULL,
  `descripcion` varchar(50) COLLATE utf8_bin NOT NULL,
  `numero_cuenta` longtext COLLATE utf8_bin,
  `cod_tipo` int(11) NOT NULL,
  `estado` tinyint(3) unsigned NOT NULL,
  `TRIAL_COLUMN6` int(11) DEFAULT NULL,
  `TRIAL_COLUMN7` int(11) DEFAULT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cuenta_bancaria`
--

LOCK TABLES `cuenta_bancaria` WRITE;
/*!40000 ALTER TABLE `cuenta_bancaria` DISABLE KEYS */;
/*!40000 ALTER TABLE `cuenta_bancaria` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `departamento`
--

DROP TABLE IF EXISTS `departamento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `departamento` (
  `codigo` int(11) NOT NULL,
  `cod_sucursal` int(11) NOT NULL,
  `nombre` varchar(200) COLLATE utf8_bin DEFAULT NULL,
  `activo` tinyint(3) unsigned DEFAULT '0',
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `departamento`
--

LOCK TABLES `departamento` WRITE;
/*!40000 ALTER TABLE `departamento` DISABLE KEYS */;
INSERT INTO `departamento` VALUES (1,4,'GERENCIA',1);
/*!40000 ALTER TABLE `departamento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `direccion`
--

DROP TABLE IF EXISTS `direccion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `direccion` (
  `codigo` int(11) NOT NULL,
  `cod_sector` int(11) NOT NULL,
  `detalle` mediumtext COLLATE utf8_bin NOT NULL,
  `estado` tinyint(3) unsigned NOT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `direccion`
--

LOCK TABLES `direccion` WRITE;
/*!40000 ALTER TABLE `direccion` DISABLE KEYS */;
INSERT INTO `direccion` VALUES (1,1,'CALLE ESO LO OTRO AQUELOO CASI ESQUINA AQUI TMBIEN Y BAJANDO POR LA DERECHA',1),(2,3,'SDFGBHN',1);
/*!40000 ALTER TABLE `direccion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `egresos_caja`
--

DROP TABLE IF EXISTS `egresos_caja`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `egresos_caja` (
  `codigo` int(11) NOT NULL,
  `cod_concepto` int(11) NOT NULL,
  `fecha` date NOT NULL,
  `cod_cajero` int(11) NOT NULL,
  `monto` decimal(20,2) NOT NULL,
  `detalles` longtext CHARACTER SET utf8,
  `afecta_cuadre` tinyint(4) NOT NULL DEFAULT '1',
  `activo` tinyint(4) DEFAULT '1',
  `cuadrado` int(11) DEFAULT '0',
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `egresos_caja`
--

LOCK TABLES `egresos_caja` WRITE;
/*!40000 ALTER TABLE `egresos_caja` DISABLE KEYS */;
INSERT INTO `egresos_caja` VALUES (1,1,'2016-08-28',5,750.00,'vbcvb',1,1,1);
/*!40000 ALTER TABLE `egresos_caja` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `egresos_conceptos`
--

DROP TABLE IF EXISTS `egresos_conceptos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `egresos_conceptos` (
  `codigo` int(11) NOT NULL,
  `nombre` longtext CHARACTER SET utf8 NOT NULL,
  `activo` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `egresos_conceptos`
--

LOCK TABLES `egresos_conceptos` WRITE;
/*!40000 ALTER TABLE `egresos_conceptos` DISABLE KEYS */;
INSERT INTO `egresos_conceptos` VALUES (1,'MATERIALES GASTABLES',1),(2,'COMBUSTIBLE',1),(3,'DEVOLUCION VENTAS EFECTIVO',1),(4,'VENTAS POR COMISION',1),(5,'DESCUENTO POR FALTANTE EN CUADRE DE CAJA',1),(6,'DESCUENTO POR DEUDAS DE FATURAS',1),(7,'HORAS EXTRAS TRABAJADAS',1);
/*!40000 ALTER TABLE `egresos_conceptos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `empleado`
--

DROP TABLE IF EXISTS `empleado`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `empleado` (
  `codigo` int(11) NOT NULL DEFAULT '0',
  `nombre` varchar(100) COLLATE utf8_bin NOT NULL,
  `login` varchar(30) COLLATE utf8_bin NOT NULL,
  `clave` varchar(30) COLLATE utf8_bin NOT NULL,
  `sueldo` decimal(20,2) NOT NULL,
  `cod_situacion` int(11) DEFAULT NULL,
  `activo` tinyint(3) unsigned NOT NULL,
  `cod_sucursal` int(11) DEFAULT NULL,
  `cod_departamento` int(11) DEFAULT NULL,
  `cod_cargo` int(11) DEFAULT NULL,
  `cod_grupo_usuario` int(11) DEFAULT '0',
  `fecha_ingreso` date DEFAULT NULL,
  `permiso` varchar(1) CHARACTER SET utf8 DEFAULT 'G',
  `cod_tipo_nomina` int(11) DEFAULT NULL,
  `identificacion` varchar(50) COLLATE utf8_bin NOT NULL DEFAULT '',
  `pasaporte` varchar(50) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`codigo`),
  KEY `empleado_cargo_idx` (`cod_cargo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `empleado`
--

LOCK TABLES `empleado` WRITE;
/*!40000 ALTER TABLE `empleado` DISABLE KEYS */;
INSERT INTO `empleado` VALUES (1,'','admin','admin',0.00,NULL,1,NULL,NULL,NULL,0,NULL,'G',NULL,'',NULL),(2,'','cajero','MQAyADMA',4500.00,1,1,4,1,3,3,'2016-05-05','G',2,'',NULL),(5,'','WILMER','MQAyADMA',20000.00,1,1,4,1,1,1,'2016-05-05','G',1,'',NULL),(40,'','karen','MQAyADMA',1500001.00,1,1,4,1,1,1,'2016-05-05','G',1,'',NULL);
/*!40000 ALTER TABLE `empleado` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `empleado_historial_datos`
--

DROP TABLE IF EXISTS `empleado_historial_datos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `empleado_historial_datos` (
  `codigo` int(11) NOT NULL AUTO_INCREMENT,
  `cod_empleado` int(11) NOT NULL,
  `nombre` varchar(100) CHARACTER SET utf8 NOT NULL,
  `identificacion` varchar(15) CHARACTER SET utf8 NOT NULL,
  `fecha_nacimiento` date DEFAULT NULL,
  `usuario` varchar(30) CHARACTER SET utf8 DEFAULT NULL,
  `clave` varchar(30) CHARACTER SET utf8 DEFAULT NULL,
  `cod_situacion` int(11) NOT NULL,
  `cod_sexo` int(11) DEFAULT NULL,
  `cod_cargo` int(11) NOT NULL,
  `cod_sucursal` int(11) NOT NULL,
  `cod_departamento` int(11) DEFAULT NULL,
  `sueldo` decimal(20,2) DEFAULT NULL,
  `cod_empleado_cambio` int(11) DEFAULT NULL,
  `fecha` date NOT NULL,
  `fecha_ingreso` date DEFAULT NULL,
  `cod_tipo_nomina` int(11) DEFAULT NULL,
  KEY `ix_empleado_historial_datos_autoinc` (`codigo`),
  KEY `empleado_empleado_idx` (`cod_empleado`),
  KEY `empleado_situacion_idx` (`cod_situacion`),
  KEY `empleado_sexo_idx` (`cod_sexo`),
  KEY `empleado_cargo_idx` (`cod_cargo`),
  KEY `empleado_sucursal_idx` (`cod_sucursal`),
  KEY `empleado_departamento_idx` (`cod_departamento`),
  KEY `empleado_empleado_cambio_idx` (`cod_empleado_cambio`),
  KEY `empleado_nomina_idx` (`cod_tipo_nomina`),
  CONSTRAINT `empleado_empleado` FOREIGN KEY (`cod_empleado`) REFERENCES `empleado` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `empleado_empleado_cambio` FOREIGN KEY (`cod_empleado_cambio`) REFERENCES `empleado` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `empleado_sexo` FOREIGN KEY (`cod_sexo`) REFERENCES `sexo` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `empleado_situacion` FOREIGN KEY (`cod_situacion`) REFERENCES `situacion_empleado` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `empleado_sucursal` FOREIGN KEY (`cod_sucursal`) REFERENCES `sucursal` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `empleado_tipo_nomina` FOREIGN KEY (`cod_tipo_nomina`) REFERENCES `nomina_tipos` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `empleeado_departamento` FOREIGN KEY (`cod_departamento`) REFERENCES `departamento` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=2009 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `empleado_historial_datos`
--

LOCK TABLES `empleado_historial_datos` WRITE;
/*!40000 ALTER TABLE `empleado_historial_datos` DISABLE KEYS */;
INSERT INTO `empleado_historial_datos` VALUES (1,5,'WILMER','03105685832','1996-03-04','WILMER','MQAyADMA',1,1,1,6,1,1500.00,5,'2016-05-28','2016-05-05',2),(2,5,'WILMER','03105685832','1996-03-04','WILMER','MQAyADMA',1,1,1,4,1,1500.00,5,'2016-05-28','2016-05-05',2),(3,5,'WILMER','03105685832','1996-03-04','WILMER','MQAyADMA',1,1,1,4,1,1500.00,5,'2016-05-30','2016-05-05',2),(4,5,'WILMER','03105685832','1996-03-04','WILMER','MQAyADMA',1,1,1,4,1,1500.00,1,'2016-05-31','2016-05-05',2),(5,2,'Cliente','11111111111','2016-05-28','cajero','MQAyADMA',1,1,3,4,1,4500.00,5,'2016-06-07','2016-05-05',2),(6,2,'Cliente','11111111111','2016-05-28','cajero','MQAyADMA',1,1,3,4,1,4500.00,2,'2016-06-07','2016-05-05',2),(1005,5,'WILMER','03105685832','1996-03-04','WILMER','MQAyADMA',1,1,1,4,1,1500.00,5,'2016-08-06','2016-05-05',2),(1006,5,'WILMER','03105685832','1996-03-04','WILMER','MQAyADMA',1,1,1,4,1,1500.00,1,'2016-08-06','2016-05-05',2),(1007,40,'karen','52163216132','2016-08-06','karen','MQAyADMA',1,2,1,4,1,1500001.00,5,'2016-08-06','2016-05-05',1),(1008,5,'WILMER','03105685832','1996-03-04','WILMER','MQAyADMA',1,1,1,4,1,20000.00,5,'2016-08-10','2016-05-05',2),(2008,5,'WILMER','03105685832','1996-03-04','WILMER','MQAyADMA',1,1,1,4,1,20000.00,5,'2016-08-17','2016-05-05',1);
/*!40000 ALTER TABLE `empleado_historial_datos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `empleado_vs_cargo`
--

DROP TABLE IF EXISTS `empleado_vs_cargo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `empleado_vs_cargo` (
  `cod_empleado` int(11) NOT NULL,
  `cod_cargo` int(11) NOT NULL,
  PRIMARY KEY (`cod_empleado`,`cod_cargo`),
  KEY `empleado_cargo_idx` (`cod_cargo`),
  CONSTRAINT `empleado_cargo_cargo` FOREIGN KEY (`cod_cargo`) REFERENCES `cargo` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `empleado_cargo_empleado` FOREIGN KEY (`cod_empleado`) REFERENCES `empleado` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `empleado_vs_cargo`
--

LOCK TABLES `empleado_vs_cargo` WRITE;
/*!40000 ALTER TABLE `empleado_vs_cargo` DISABLE KEYS */;
/*!40000 ALTER TABLE `empleado_vs_cargo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `empleado_vs_conceptos_nomina`
--

DROP TABLE IF EXISTS `empleado_vs_conceptos_nomina`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `empleado_vs_conceptos_nomina` (
  `cod_nomina` int(11) DEFAULT NULL,
  `cod_empleado` int(11) DEFAULT NULL,
  `cod_concepto` int(11) DEFAULT NULL,
  `monto` decimal(20,2) DEFAULT NULL,
  `cod_empleado_modifico` int(11) DEFAULT '0',
  KEY `empleado_concepto_nomina_nomina_idx` (`cod_nomina`),
  KEY `empleado_concepto_nomina_empleado_idx` (`cod_empleado`),
  KEY `empleado_concepto_nomina_concepto_idx` (`cod_concepto`),
  KEY `empleado_concepto_nomina_empelado_modifico_idx` (`cod_empleado_modifico`),
  CONSTRAINT `empleado_concepto_nomina_concepto` FOREIGN KEY (`cod_concepto`) REFERENCES `nomina_conceptos` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `empleado_concepto_nomina_empelado_modifico` FOREIGN KEY (`cod_empleado_modifico`) REFERENCES `empleado` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `empleado_vs_conceptos_nomina`
--

LOCK TABLES `empleado_vs_conceptos_nomina` WRITE;
/*!40000 ALTER TABLE `empleado_vs_conceptos_nomina` DISABLE KEYS */;
INSERT INTO `empleado_vs_conceptos_nomina` VALUES (5,5,1,1500.00,5),(5,5,2,0.00,5),(5,5,3,0.00,5),(5,5,4,0.00,5),(5,5,5,0.00,5);
/*!40000 ALTER TABLE `empleado_vs_conceptos_nomina` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `empresa`
--

DROP TABLE IF EXISTS `empresa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `empresa` (
  `codigo` int(11) NOT NULL DEFAULT '0',
  `secuencia` varchar(50) COLLATE utf8_bin DEFAULT NULL,
  `division` varchar(2) COLLATE utf8_bin DEFAULT NULL,
  `estado` tinyint(3) unsigned NOT NULL DEFAULT '0',
  `rnc` varchar(45) COLLATE utf8_bin NOT NULL DEFAULT '',
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `empresa`
--

LOCK TABLES `empresa` WRITE;
/*!40000 ALTER TABLE `empresa` DISABLE KEYS */;
INSERT INTO `empresa` VALUES (3,'000','01',1,'');
/*!40000 ALTER TABLE `empresa` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `entrada_salida_inventario`
--

DROP TABLE IF EXISTS `entrada_salida_inventario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `entrada_salida_inventario` (
  `codigo` int(11) NOT NULL,
  `tipo_movimiento` varchar(5) CHARACTER SET utf8 DEFAULT 'ENT',
  `cod_producto` int(11) NOT NULL,
  `cod_unidad` int(11) NOT NULL,
  `cantidad` decimal(20,2) DEFAULT NULL,
  `fecha` date DEFAULT NULL,
  `cod_almacen` int(11) DEFAULT NULL,
  `cod_empleado_cambio` int(11) DEFAULT NULL,
  `motivo` mediumtext CHARACTER SET utf8,
  PRIMARY KEY (`codigo`),
  KEY `entrada_salida_inventario_producto_idx` (`cod_producto`),
  KEY `entrada_salida_inventario_unidad_idx` (`cod_unidad`),
  KEY `entrada_salida_inventario_almacen_idx` (`cod_almacen`),
  KEY `entrada_salida_inventario_empleado_idx` (`cod_empleado_cambio`),
  CONSTRAINT `entrada_salida_inventario_almacen` FOREIGN KEY (`cod_almacen`) REFERENCES `almacen` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `entrada_salida_inventario_producto` FOREIGN KEY (`cod_producto`) REFERENCES `producto` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `entrada_salida_inventario_unidad` FOREIGN KEY (`cod_unidad`) REFERENCES `unidad` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `entrada_salida_inventario`
--

LOCK TABLES `entrada_salida_inventario` WRITE;
/*!40000 ALTER TABLE `entrada_salida_inventario` DISABLE KEYS */;
INSERT INTO `entrada_salida_inventario` VALUES (1,'E',2,4,40.00,'2016-06-13',NULL,5,'klk'),(2,'E',2,4,40.00,'2016-06-13',NULL,5,'klk'),(3,'E',2,4,40.00,'2016-06-13',NULL,5,'klk'),(4,'E',2,1,2.00,'2016-06-13',NULL,5,'klk'),(5,'E',2,1,2.00,'2016-06-13',NULL,5,'klk'),(6,'E',2,1,2.00,'2016-06-13',NULL,5,'klk'),(7,'E',1,4,10.00,'2016-06-14',NULL,5,'hmhgjghj'),(8,'S',1,4,13.00,'2016-06-14',NULL,5,'hmhgjghj'),(9,'E',1,4,13.00,'2016-06-14',NULL,5,'hmhgjghj');
/*!40000 ALTER TABLE `entrada_salida_inventario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `estados`
--

DROP TABLE IF EXISTS `estados`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `estados` (
  `id` int(11) NOT NULL,
  `nombre` varchar(100) DEFAULT NULL,
  `activo` tinyint(4) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `estados`
--

LOCK TABLES `estados` WRITE;
/*!40000 ALTER TABLE `estados` DISABLE KEYS */;
/*!40000 ALTER TABLE `estados` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `estados_reparacion`
--

DROP TABLE IF EXISTS `estados_reparacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `estados_reparacion` (
  `codigo` int(11) NOT NULL,
  `nombre` longtext CHARACTER SET utf8 NOT NULL,
  `estado` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `estados_reparacion`
--

LOCK TABLES `estados_reparacion` WRITE;
/*!40000 ALTER TABLE `estados_reparacion` DISABLE KEYS */;
INSERT INTO `estados_reparacion` VALUES (1,'RECIVIDO',1),(2,'REPARANDO',1),(3,'OBSERVACION',1),(4,'EN ESPERA',1),(5,'ENTREGADO',1);
/*!40000 ALTER TABLE `estados_reparacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `factura`
--

DROP TABLE IF EXISTS `factura`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `factura` (
  `codigo` int(11) NOT NULL,
  `num_factura` varchar(50) COLLATE utf8_bin DEFAULT NULL,
  `fecha` datetime DEFAULT NULL,
  `fecha_limite` datetime DEFAULT NULL,
  `codigo_empleado` int(11) DEFAULT NULL,
  `codigo_cliente` int(11) DEFAULT NULL,
  `rnc` varchar(50) COLLATE utf8_bin DEFAULT NULL,
  `ncf` varchar(50) COLLATE utf8_bin DEFAULT NULL,
  `codigo_tipo_factura` varchar(5) COLLATE utf8_bin DEFAULT NULL,
  `cod_sucursal` int(11) DEFAULT NULL,
  `activo` tinyint(4) DEFAULT '1',
  `pagada` tinyint(4) DEFAULT NULL,
  `cod_empleado_anular` int(11) DEFAULT NULL,
  `devuelta` decimal(20,2) DEFAULT NULL,
  `itebis` decimal(20,2) DEFAULT NULL,
  `efectivo` decimal(20,2) DEFAULT NULL,
  `motivo_anulada` varchar(500) COLLATE utf8_bin DEFAULT NULL,
  `monto_propina` decimal(20,2) DEFAULT NULL,
  `cod_vendedor` int(11) DEFAULT NULL,
  `despachado` int(11) DEFAULT NULL,
  `autorizar_pedido` int(11) DEFAULT NULL,
  `cuadrado` int(11) DEFAULT NULL,
  `descuento` decimal(20,2) DEFAULT NULL,
  `detalles` varchar(500) COLLATE utf8_bin DEFAULT NULL,
  `codigo_comprobante` int(11) DEFAULT NULL,
  PRIMARY KEY (`codigo`),
  KEY `factura_empleado_idx` (`codigo_empleado`),
  KEY `factura_cliente_idx` (`codigo_cliente`),
  KEY `factura_sucursal_idx` (`cod_sucursal`),
  KEY `factura_comprobante_idx` (`codigo_comprobante`),
  CONSTRAINT `factura_cliente` FOREIGN KEY (`codigo_cliente`) REFERENCES `cliente` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `factura_comprobante` FOREIGN KEY (`codigo_comprobante`) REFERENCES `tipo_comprobante_fiscal` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `factura_empleado` FOREIGN KEY (`codigo_empleado`) REFERENCES `empleado` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `factura_sucursal` FOREIGN KEY (`cod_sucursal`) REFERENCES `sucursal` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `factura`
--

LOCK TABLES `factura` WRITE;
/*!40000 ALTER TABLE `factura` DISABLE KEYS */;
/*!40000 ALTER TABLE `factura` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `factura_detalle`
--

DROP TABLE IF EXISTS `factura_detalle`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `factura_detalle` (
  `cod_factura` int(11) NOT NULL DEFAULT '0',
  `cod_producto` int(11) NOT NULL DEFAULT '0',
  `cod_unidad` int(11) NOT NULL DEFAULT '0',
  `cantidad` decimal(20,2) NOT NULL DEFAULT '0.00',
  `precio` decimal(20,2) NOT NULL DEFAULT '0.00',
  `monto` decimal(20,2) NOT NULL DEFAULT '0.00',
  `itebis` decimal(20,2) NOT NULL DEFAULT '0.00',
  `descuento` decimal(20,2) NOT NULL DEFAULT '0.00',
  `estado` tinyint(3) unsigned DEFAULT NULL,
  KEY `factura_detalle_producto_idx` (`cod_producto`),
  KEY `factura_detalle_factura_idx` (`cod_factura`),
  KEY `factura_detalle_unidad_idx` (`cod_unidad`),
  CONSTRAINT `factura_detalle_factura` FOREIGN KEY (`cod_factura`) REFERENCES `factura` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `factura_detalle_producto` FOREIGN KEY (`cod_producto`) REFERENCES `producto` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `factura_detalle_unidad` FOREIGN KEY (`cod_unidad`) REFERENCES `unidad` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `factura_detalle`
--

LOCK TABLES `factura_detalle` WRITE;
/*!40000 ALTER TABLE `factura_detalle` DISABLE KEYS */;
/*!40000 ALTER TABLE `factura_detalle` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `grupo_usuarios`
--

DROP TABLE IF EXISTS `grupo_usuarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `grupo_usuarios` (
  `codigo` int(11) NOT NULL DEFAULT '0',
  `nombre` varchar(50) CHARACTER SET utf8 NOT NULL,
  `activo` tinyint(3) unsigned NOT NULL DEFAULT '1',
  `detalles` varchar(200) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `grupo_usuarios`
--

LOCK TABLES `grupo_usuarios` WRITE;
/*!40000 ALTER TABLE `grupo_usuarios` DISABLE KEYS */;
INSERT INTO `grupo_usuarios` VALUES (1,'ADMINISTRADORES',1,NULL),(2,'CAJEROS',1,NULL),(3,'VENDEDORES',1,NULL);
/*!40000 ALTER TABLE `grupo_usuarios` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `grupo_usuarios_permisos`
--

DROP TABLE IF EXISTS `grupo_usuarios_permisos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `grupo_usuarios_permisos` (
  `cod_grupo` int(11) NOT NULL,
  `cod_permiso` int(11) NOT NULL,
  KEY `grupo_usuarios_permisos_grupo_idx` (`cod_grupo`),
  KEY `grupo_usuarios_permisos_permiso_idx` (`cod_permiso`),
  CONSTRAINT `grupo_usuarios_permisos_grupo` FOREIGN KEY (`cod_grupo`) REFERENCES `grupo_usuarios` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `grupo_usuarios_permisos_permiso` FOREIGN KEY (`cod_permiso`) REFERENCES `permiso` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `grupo_usuarios_permisos`
--

LOCK TABLES `grupo_usuarios_permisos` WRITE;
/*!40000 ALTER TABLE `grupo_usuarios_permisos` DISABLE KEYS */;
INSERT INTO `grupo_usuarios_permisos` VALUES (1,1),(1,2),(1,3),(1,4),(1,5),(1,6),(1,7),(1,8),(1,10),(1,12),(1,14),(1,15),(1,16),(1,17),(1,18),(1,19),(1,20),(1,22),(1,23),(1,24),(1,25),(1,26),(1,27),(1,28),(1,29),(1,30),(1,31),(1,32),(1,33),(1,34),(1,35),(1,36),(1,37),(1,38),(1,39),(1,40),(1,41),(1,42),(1,43),(1,44),(1,45),(1,46),(1,47),(3,40),(2,1),(2,3),(2,8),(3,41),(3,1),(3,13);
/*!40000 ALTER TABLE `grupo_usuarios_permisos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `identificacion`
--

DROP TABLE IF EXISTS `identificacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `identificacion` (
  `codigo` int(11) NOT NULL,
  `identificacion` varchar(50) COLLATE utf8_bin NOT NULL,
  `cod_tipo` int(11) NOT NULL,
  PRIMARY KEY (`codigo`,`identificacion`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `identificacion`
--

LOCK TABLES `identificacion` WRITE;
/*!40000 ALTER TABLE `identificacion` DISABLE KEYS */;
/*!40000 ALTER TABLE `identificacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ingresos_caja`
--

DROP TABLE IF EXISTS `ingresos_caja`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ingresos_caja` (
  `codigo` int(11) NOT NULL,
  `cod_concepto` int(11) NOT NULL,
  `fecha` date DEFAULT NULL,
  `cod_cajero` int(11) NOT NULL,
  `monto` decimal(20,2) NOT NULL,
  `detalles` longtext CHARACTER SET utf8,
  `afecta_cuadre` tinyint(4) DEFAULT '1',
  `activo` tinyint(4) DEFAULT '1',
  `cuadrado` tinyint(4) DEFAULT '0',
  PRIMARY KEY (`codigo`),
  KEY `ingresos_caja_cajero_idx` (`cod_cajero`),
  KEY `ingresos_caja_concepto_idx` (`cod_concepto`),
  CONSTRAINT `ingresos_caja_cajero` FOREIGN KEY (`cod_cajero`) REFERENCES `cajero` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `ingresos_caja_concepto` FOREIGN KEY (`cod_concepto`) REFERENCES `ingresos_conceptos` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ingresos_caja`
--

LOCK TABLES `ingresos_caja` WRITE;
/*!40000 ALTER TABLE `ingresos_caja` DISABLE KEYS */;
INSERT INTO `ingresos_caja` VALUES (1,1,'2016-08-28',5,1000.00,'vvcnv',1,1,1);
/*!40000 ALTER TABLE `ingresos_caja` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ingresos_conceptos`
--

DROP TABLE IF EXISTS `ingresos_conceptos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ingresos_conceptos` (
  `codigo` int(11) NOT NULL,
  `nombre` longtext CHARACTER SET utf8 NOT NULL,
  `estado` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ingresos_conceptos`
--

LOCK TABLES `ingresos_conceptos` WRITE;
/*!40000 ALTER TABLE `ingresos_conceptos` DISABLE KEYS */;
INSERT INTO `ingresos_conceptos` VALUES (1,'GENERAL',1),(2,'PARA NOMINA',1);
/*!40000 ALTER TABLE `ingresos_conceptos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `inventario`
--

DROP TABLE IF EXISTS `inventario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `inventario` (
  `codigo` int(11) NOT NULL,
  `codigo_producto` int(11) NOT NULL,
  `codigo_unidad` int(11) NOT NULL,
  `cantidad` decimal(20,2) NOT NULL DEFAULT '0.00',
  `fecha_entrada` date DEFAULT NULL,
  `fecha_vencimiento` date DEFAULT NULL,
  PRIMARY KEY (`codigo`),
  KEY `inventario_producto_idx` (`codigo_producto`),
  KEY `inventario_producto_klk_idx` (`codigo_producto`),
  KEY `inventario_unidad_idx` (`codigo_unidad`),
  CONSTRAINT `inventario_producto` FOREIGN KEY (`codigo_producto`) REFERENCES `producto` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `inventario_unidad` FOREIGN KEY (`codigo_unidad`) REFERENCES `unidad` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `inventario`
--

LOCK TABLES `inventario` WRITE;
/*!40000 ALTER TABLE `inventario` DISABLE KEYS */;
/*!40000 ALTER TABLE `inventario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `inventario_reparacion`
--

DROP TABLE IF EXISTS `inventario_reparacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `inventario_reparacion` (
  `codigo` int(11) NOT NULL,
  `codigo_producto` int(11) DEFAULT NULL,
  `codigo_unidad` int(11) DEFAULT NULL,
  `cod_marca` int(11) DEFAULT NULL,
  `cod_modelo` int(11) DEFAULT NULL,
  `imei` longtext CHARACTER SET utf8,
  `matricula` longtext CHARACTER SET utf8,
  `serial` longtext CHARACTER SET utf8,
  `cantidad` decimal(20,2) DEFAULT NULL,
  `fecha_entrada` datetime DEFAULT NULL,
  `cod_empleado` int(11) DEFAULT '0',
  `cod_cliente_titular` int(11) DEFAULT '0',
  `estado_reparacion` int(11) NOT NULL,
  `detalles` longtext CHARACTER SET utf8,
  `activo` tinyint(4) DEFAULT '1',
  PRIMARY KEY (`codigo`),
  UNIQUE KEY `codigo_producto_UNIQUE` (`codigo_producto`),
  KEY `inventario_reparacion_producto_idx` (`codigo_producto`),
  KEY `inventario_reparacion_unidad_idx` (`codigo_unidad`),
  KEY `inventario_reparacion_marca_idx` (`cod_marca`),
  KEY `inventario_reparacion_modelo_idx` (`cod_modelo`),
  KEY `inventario_reparacion_cliente_idx` (`cod_cliente_titular`),
  KEY `inventario_reparacion_estado_reparacion_idx` (`estado_reparacion`),
  CONSTRAINT `inventario_reparacion_cliente` FOREIGN KEY (`cod_cliente_titular`) REFERENCES `cliente` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `inventario_reparacion_estado_reparacion` FOREIGN KEY (`estado_reparacion`) REFERENCES `estados_reparacion` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `inventario_reparacion_marca` FOREIGN KEY (`cod_marca`) REFERENCES `marcas` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `inventario_reparacion_modelo` FOREIGN KEY (`cod_modelo`) REFERENCES `modelo` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `inventario_reparacion_producto` FOREIGN KEY (`codigo_producto`) REFERENCES `producto` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `inventario_reparacion_unidad` FOREIGN KEY (`codigo_unidad`) REFERENCES `unidad` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `inventario_reparacion`
--

LOCK TABLES `inventario_reparacion` WRITE;
/*!40000 ALTER TABLE `inventario_reparacion` DISABLE KEYS */;
/*!40000 ALTER TABLE `inventario_reparacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `itebis`
--

DROP TABLE IF EXISTS `itebis`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `itebis` (
  `codigo` int(11) NOT NULL,
  `descripcion` varchar(50) COLLATE utf8_bin NOT NULL,
  `porciento` int(11) NOT NULL DEFAULT '0',
  `activo` tinyint(3) unsigned NOT NULL DEFAULT '1',
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `itebis`
--

LOCK TABLES `itebis` WRITE;
/*!40000 ALTER TABLE `itebis` DISABLE KEYS */;
INSERT INTO `itebis` VALUES (1,'itbis 18%',18,1),(2,'itbis 16%',16,1),(3,'itbis 13%',13,1),(4,'itbis 0%',0,1);
/*!40000 ALTER TABLE `itebis` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `marcas`
--

DROP TABLE IF EXISTS `marcas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `marcas` (
  `codigo` int(11) NOT NULL,
  `nombre` longtext CHARACTER SET utf8 NOT NULL,
  `activo` tinyint(4) NOT NULL DEFAULT '1',
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `marcas`
--

LOCK TABLES `marcas` WRITE;
/*!40000 ALTER TABLE `marcas` DISABLE KEYS */;
INSERT INTO `marcas` VALUES (1,'SAMSUNG',1),(2,'HTC',1),(3,'IPHONE',1),(4,'ALCATEL',1),(5,'MOTOROLA',1),(6,'MOTOROLA',1),(7,'MOTOROLA',1),(8,'MOTOROLA',1),(9,'MOTOROLA',1),(10,'LENOVO',1),(11,'ONE PLUS',1),(12,'NOKIA',1),(13,'ZTE',1),(14,'BLU',1),(15,'SONY',1),(16,'XIAOMI',1),(17,'CAT',1),(18,'HUAWEI',1),(19,'LG',1),(20,'ASUS',1),(21,'MEIZU',1),(22,'LANIX',1),(23,'OPPO',1),(24,'TOYOTA',1),(25,'HONDA',1),(26,'MERCEDES',1),(27,'MITSUBISHI',1);
/*!40000 ALTER TABLE `marcas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `mesas`
--

DROP TABLE IF EXISTS `mesas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `mesas` (
  `codigo` int(11) NOT NULL,
  `nombre` longtext COLLATE utf8_bin,
  `activo` tinyint(4) DEFAULT '1',
  `cod_sucursal` int(11) DEFAULT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `mesas`
--

LOCK TABLES `mesas` WRITE;
/*!40000 ALTER TABLE `mesas` DISABLE KEYS */;
INSERT INTO `mesas` VALUES (1,'MESA DOBLE',1,4);
/*!40000 ALTER TABLE `mesas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `mesas_detalles`
--

DROP TABLE IF EXISTS `mesas_detalles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `mesas_detalles` (
  `codigo_mesa` int(11) NOT NULL,
  `cod_detalle` int(11) NOT NULL,
  `descripcion` longtext COLLATE utf8_bin,
  KEY `mesas_detalles_mesa_idx` (`codigo_mesa`),
  KEY `mesas_detalles_detalle_idx` (`cod_detalle`),
  CONSTRAINT `mesas_detalles_detalle` FOREIGN KEY (`cod_detalle`) REFERENCES `producto_detalle` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `mesas_detalles_mesa` FOREIGN KEY (`codigo_mesa`) REFERENCES `mesas` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `mesas_detalles`
--

LOCK TABLES `mesas_detalles` WRITE;
/*!40000 ALTER TABLE `mesas_detalles` DISABLE KEYS */;
INSERT INTO `mesas_detalles` VALUES (1,5,'4 SILLAS');
/*!40000 ALTER TABLE `mesas_detalles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `metodo_pago`
--

DROP TABLE IF EXISTS `metodo_pago`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `metodo_pago` (
  `codigo` int(11) NOT NULL,
  `metodo` longtext COLLATE utf8_bin,
  `descripcion` longtext COLLATE utf8_bin,
  `activo` tinyint(3) unsigned DEFAULT '1',
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `metodo_pago`
--

LOCK TABLES `metodo_pago` WRITE;
/*!40000 ALTER TABLE `metodo_pago` DISABLE KEYS */;
INSERT INTO `metodo_pago` VALUES (1,'EFECTIVO','DINERO EN EFECTIVO',1),(2,'DEPOSITO','DEPOSITO BANCARIO',1),(3,'CHEQUE','CHEQUE BANCARIO',1),(4,'TARJETA','TARJETA',1);
/*!40000 ALTER TABLE `metodo_pago` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `modelo`
--

DROP TABLE IF EXISTS `modelo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `modelo` (
  `codigo` int(11) NOT NULL,
  `codigo_marca` int(11) NOT NULL,
  `nombre_modelo` longtext CHARACTER SET utf8 NOT NULL,
  `activo` tinyint(4) NOT NULL DEFAULT '1',
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `modelo`
--

LOCK TABLES `modelo` WRITE;
/*!40000 ALTER TABLE `modelo` DISABLE KEYS */;
/*!40000 ALTER TABLE `modelo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `moneda`
--

DROP TABLE IF EXISTS `moneda`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `moneda` (
  `codigo` int(11) NOT NULL,
  `nombre` longtext CHARACTER SET utf8 NOT NULL,
  `tasa_actual` decimal(20,2) NOT NULL DEFAULT '0.00',
  `activo` tinyint(4) DEFAULT '1',
  `monedacol` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `moneda`
--

LOCK TABLES `moneda` WRITE;
/*!40000 ALTER TABLE `moneda` DISABLE KEYS */;
INSERT INTO `moneda` VALUES (1,'PESOS RD',1.00,1,NULL),(2,'DOLLAR AMERICANO',45.50,1,NULL);
/*!40000 ALTER TABLE `moneda` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `moneda_historial`
--

DROP TABLE IF EXISTS `moneda_historial`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `moneda_historial` (
  `codigo` int(11) NOT NULL,
  `cod_moneda` int(11) NOT NULL,
  `tasa` decimal(20,2) NOT NULL DEFAULT '0.00',
  `fecha` date NOT NULL,
  PRIMARY KEY (`codigo`),
  KEY `moneda_historial_moneda_idx` (`cod_moneda`),
  CONSTRAINT `moneda_historial_moneda` FOREIGN KEY (`cod_moneda`) REFERENCES `moneda` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `moneda_historial`
--

LOCK TABLES `moneda_historial` WRITE;
/*!40000 ALTER TABLE `moneda_historial` DISABLE KEYS */;
/*!40000 ALTER TABLE `moneda_historial` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `nomina`
--

DROP TABLE IF EXISTS `nomina`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `nomina` (
  `codigo` int(11) NOT NULL,
  `fecha_inicial` date NOT NULL,
  `fecha_final` date NOT NULL,
  `cod_empleado` int(11) NOT NULL,
  `cod_tipo` int(11) NOT NULL,
  `cod_sucursal` int(11) NOT NULL,
  `activo` tinyint(4) DEFAULT '1',
  `abierta_cerrada` varchar(5) CHARACTER SET utf8 DEFAULT 'A' COMMENT 'C--> cerrada\nA-->abierta',
  `cod_empleado_cerrada` int(11) DEFAULT '0',
  PRIMARY KEY (`codigo`),
  KEY `nomina_tipo_nomina_idx` (`cod_tipo`),
  KEY `nomina_empleado_idx` (`cod_empleado`),
  KEY `nomina_sucursal_idx` (`cod_sucursal`),
  CONSTRAINT `nomina_empleado` FOREIGN KEY (`cod_empleado`) REFERENCES `empleado` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `nomina_sucursal` FOREIGN KEY (`cod_sucursal`) REFERENCES `sucursal` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `nomina_tipo_nomina` FOREIGN KEY (`cod_tipo`) REFERENCES `nomina_tipos` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `nomina`
--

LOCK TABLES `nomina` WRITE;
/*!40000 ALTER TABLE `nomina` DISABLE KEYS */;
INSERT INTO `nomina` VALUES (1,'2016-05-01','2016-05-15',5,2,4,1,'C',5),(2,'2016-05-16','2016-05-31',5,2,4,1,'C',5),(3,'2016-05-01','2016-05-31',5,1,4,1,'A',0),(4,'2016-06-01','2016-05-15',5,2,4,1,'C',5),(5,'2016-07-16','2016-07-16',5,2,4,1,'A',0);
/*!40000 ALTER TABLE `nomina` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `nomina_conceptos`
--

DROP TABLE IF EXISTS `nomina_conceptos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `nomina_conceptos` (
  `codigo` int(11) NOT NULL,
  `nombre` longtext CHARACTER SET utf8 NOT NULL,
  `aumenta_sueldo` tinyint(4) NOT NULL DEFAULT '1',
  `activo` tinyint(4) DEFAULT '1',
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `nomina_conceptos`
--

LOCK TABLES `nomina_conceptos` WRITE;
/*!40000 ALTER TABLE `nomina_conceptos` DISABLE KEYS */;
INSERT INTO `nomina_conceptos` VALUES (1,'SUELDO BASE',1,1),(2,'COMISION POR VENTAS',1,1),(3,'HORAS EXTRAS TRABAJADAS',1,1),(4,'DESCUENTO POR FALTANTE EN CUADRE DE CAJA',0,1),(5,'DESCUENTO POR DEUDAS DE FACTURAS',0,1);
/*!40000 ALTER TABLE `nomina_conceptos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `nomina_detalle`
--

DROP TABLE IF EXISTS `nomina_detalle`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `nomina_detalle` (
  `cod_nomina` int(11) NOT NULL,
  `cod_empleado` int(11) NOT NULL,
  `cod_concepto` int(11) NOT NULL,
  `monto_sueldo` decimal(20,2) NOT NULL DEFAULT '0.00',
  `cod_empleado_modifico` int(11) DEFAULT '0',
  `activo` tinyint(4) DEFAULT '1',
  KEY `nomina_detalle_empleado_idx` (`cod_empleado`),
  KEY `nomina_detalle_concepto_idx` (`cod_concepto`),
  KEY `nomina_detalle_nomina_idx` (`cod_nomina`),
  CONSTRAINT `nomina_detalle_concepto` FOREIGN KEY (`cod_concepto`) REFERENCES `nomina_conceptos` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `nomina_detalle_empleado` FOREIGN KEY (`cod_empleado`) REFERENCES `empleado` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `nomina_detalle_nomina` FOREIGN KEY (`cod_nomina`) REFERENCES `nomina` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `nomina_detalle`
--

LOCK TABLES `nomina_detalle` WRITE;
/*!40000 ALTER TABLE `nomina_detalle` DISABLE KEYS */;
INSERT INTO `nomina_detalle` VALUES (1,2,1,4500.00,5,1),(1,2,2,50.00,5,1),(1,2,3,0.00,5,1),(1,2,4,0.00,5,1),(1,2,5,0.00,5,1),(1,5,1,4500.00,5,1),(1,5,2,50.00,5,1),(1,5,3,0.00,5,1),(1,5,4,0.00,5,1),(1,5,5,0.00,5,1),(2,2,1,1500.00,5,1),(2,2,2,650.00,5,1),(2,2,3,0.00,5,1),(2,2,4,0.00,5,1),(2,2,5,0.00,5,1),(2,5,1,1500.00,5,1),(2,5,2,650.00,5,1),(2,5,3,0.00,5,1),(2,5,4,0.00,5,1),(2,5,5,0.00,5,1),(4,2,1,1500.00,5,1),(4,2,2,0.00,5,1),(4,2,3,0.00,5,1),(4,2,4,0.00,5,1),(4,2,5,0.00,5,1),(4,5,1,1500.00,5,1),(4,5,2,0.00,5,1),(4,5,3,0.00,5,1),(4,5,4,0.00,5,1),(4,5,5,0.00,5,1),(5,5,1,1500.00,5,1),(5,5,2,0.00,5,1),(5,5,3,0.00,5,1),(5,5,4,0.00,5,1),(5,5,5,0.00,5,1);
/*!40000 ALTER TABLE `nomina_detalle` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `nomina_tipos`
--

DROP TABLE IF EXISTS `nomina_tipos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `nomina_tipos` (
  `codigo` int(11) NOT NULL,
  `nombre` longtext CHARACTER SET utf8 NOT NULL,
  `activo` tinyint(4) NOT NULL DEFAULT '1',
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `nomina_tipos`
--

LOCK TABLES `nomina_tipos` WRITE;
/*!40000 ALTER TABLE `nomina_tipos` DISABLE KEYS */;
INSERT INTO `nomina_tipos` VALUES (1,'MENSUAL',1),(2,'QUINCENAL',1),(3,'SEMANAL',1);
/*!40000 ALTER TABLE `nomina_tipos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `oferta_producto_categoria_detalle`
--

DROP TABLE IF EXISTS `oferta_producto_categoria_detalle`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `oferta_producto_categoria_detalle` (
  `cod_oferta` int(11) NOT NULL,
  `cod_categoria` int(11) NOT NULL,
  `activo` tinyint(4) NOT NULL DEFAULT '1',
  KEY `oferta_producto_subcate_detalle_categoria_idx` (`cod_categoria`),
  CONSTRAINT `oferta_producto_subcate_detalle_categoria` FOREIGN KEY (`cod_categoria`) REFERENCES `categoria_producto` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `oferta_producto_categoria_detalle`
--

LOCK TABLES `oferta_producto_categoria_detalle` WRITE;
/*!40000 ALTER TABLE `oferta_producto_categoria_detalle` DISABLE KEYS */;
/*!40000 ALTER TABLE `oferta_producto_categoria_detalle` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `oferta_producto_detalle`
--

DROP TABLE IF EXISTS `oferta_producto_detalle`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `oferta_producto_detalle` (
  `cod_oferta` int(11) NOT NULL,
  `cod_prod` int(11) NOT NULL,
  `activo` tinyint(4) NOT NULL DEFAULT '1',
  KEY `oferta_producto_detalle_producto_idx` (`cod_prod`),
  KEY `oferta_producto_detalle_oferta_idx` (`cod_oferta`),
  CONSTRAINT `oferta_producto_detalle_oferta` FOREIGN KEY (`cod_oferta`) REFERENCES `producto_oferta` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `oferta_producto_detalle_producto` FOREIGN KEY (`cod_prod`) REFERENCES `producto` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `oferta_producto_detalle`
--

LOCK TABLES `oferta_producto_detalle` WRITE;
/*!40000 ALTER TABLE `oferta_producto_detalle` DISABLE KEYS */;
/*!40000 ALTER TABLE `oferta_producto_detalle` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pagos`
--

DROP TABLE IF EXISTS `pagos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `pagos` (
  `codigo` int(11) NOT NULL,
  `fecha` datetime NOT NULL,
  `detalle` longtext COLLATE utf8_bin,
  `cod_empleado` int(11) NOT NULL,
  `activo` tinyint(3) unsigned DEFAULT '0',
  `cod_empleado_anular` int(11) DEFAULT '0',
  `motivo_anulado` longtext CHARACTER SET utf8,
  `cuadrado` tinyint(3) unsigned DEFAULT '0',
  PRIMARY KEY (`codigo`),
  KEY `pagos_empleado_idx` (`cod_empleado`),
  CONSTRAINT `pagos_empleado` FOREIGN KEY (`cod_empleado`) REFERENCES `empleado` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pagos`
--

LOCK TABLES `pagos` WRITE;
/*!40000 ALTER TABLE `pagos` DISABLE KEYS */;
/*!40000 ALTER TABLE `pagos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pagos_detalles`
--

DROP TABLE IF EXISTS `pagos_detalles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `pagos_detalles` (
  `codigo` int(11) NOT NULL,
  `cod_pago` int(11) NOT NULL,
  `cod_compra` int(11) NOT NULL,
  `cod_metodo_pago` int(11) NOT NULL,
  `monto_pagado` decimal(20,2) DEFAULT '0.00',
  `monto_descontado` decimal(20,2) DEFAULT '0.00',
  `estado` tinyint(3) unsigned DEFAULT '1',
  PRIMARY KEY (`codigo`),
  KEY `pagos_detalles_pago_idx` (`cod_pago`),
  KEY `pagos_detalles_factura_idx` (`cod_compra`),
  KEY `pagos_detalles_metodo_pago_idx` (`cod_metodo_pago`),
  CONSTRAINT `pagos_detalles_factura` FOREIGN KEY (`cod_compra`) REFERENCES `compra` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `pagos_detalles_metodo_pago` FOREIGN KEY (`cod_metodo_pago`) REFERENCES `metodo_pago` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `pagos_detalles_pago` FOREIGN KEY (`cod_pago`) REFERENCES `pagos` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pagos_detalles`
--

LOCK TABLES `pagos_detalles` WRITE;
/*!40000 ALTER TABLE `pagos_detalles` DISABLE KEYS */;
/*!40000 ALTER TABLE `pagos_detalles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pais`
--

DROP TABLE IF EXISTS `pais`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `pais` (
  `codigo` int(11) NOT NULL,
  `nombre` varchar(50) COLLATE utf8_bin NOT NULL,
  `estado` tinyint(3) unsigned NOT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pais`
--

LOCK TABLES `pais` WRITE;
/*!40000 ALTER TABLE `pais` DISABLE KEYS */;
INSERT INTO `pais` VALUES (1,'REPUBLICA DOMINICANA',1);
/*!40000 ALTER TABLE `pais` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `permiso`
--

DROP TABLE IF EXISTS `permiso`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `permiso` (
  `codigo` int(11) NOT NULL,
  `descripcion` varchar(50) COLLATE utf8_bin NOT NULL,
  `activo` tinyint(3) unsigned NOT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `permiso`
--

LOCK TABLES `permiso` WRITE;
/*!40000 ALTER TABLE `permiso` DISABLE KEYS */;
INSERT INTO `permiso` VALUES (1,'PUEDE FACTURAR',1),(2,'CREAR Y MODIFICAR PRODCUTOS',1),(3,'BUSCAR EXISTENCIA',1),(4,'ANULAR PAGOS A SUPLIDORES',1),(5,'CAMBIAR PRECIO EN FACTURACION',1),(6,'HACER COMPRAS',1),(7,'ANULAR COMPRAS',1),(8,'ANULAR FACTURAS DE VENTAS',1),(9,'FACTURAR CON PRECIO MAYOR',0),(10,'PONER CREDITO AL CLIENTE',1),(11,'TRANSFERIR PRODUCTOS A OTRA SUCURSAL',0),(12,'ENTRADA Y SALIDA DE INVENTARIO',1),(13,'VER LAS VENTAS EN EL CUADRE DE CAJA',0),(14,'MODULO INVENTARIO',1),(15,'MODULO CUENTAS POR PAGAR',1),(16,'MODULO CUENTAS POR COBRAR',1),(17,'MODULO NOMINA',1),(18,'MODULO FACTURACION',1),(19,'MODULO EMPRESA',1),(20,'MODULO OPCIONES',1),(21,'MODULO PRESTAMOS',1),(22,'CREAR Y MODIFICAR SUCURSALES',1),(23,'CAMBIAR CLAVE DE USUARIO',1),(24,'VER LAS VENTAS DEL DIA',1),(25,'DEVOLUCION DE COMPRAS',1),(26,'OBSERVACION A EMPLEADOS',1),(27,'HACER PAGOS A CUENTAS POR PAGAR',1),(28,'PUEDE CAMBIAR LA FECHA EN FACTURACION',1),(29,'HACER COBROS DE CLIENTES',1),(30,'DEVOLUCION DE VENTAS',1),(31,'PONER PRECIOS A PRODUCTOS UNIDADES',1),(32,'MODULO ADMINISTRADOR',1),(33,'ANULAR COBROS DE CLIENTES',1),(34,'CAMBIAR FECHA EN CUADRE DE CAJA',1),(35,'PUEDE ASIGNAR PERMISOS',1),(36,'PUEDE ASIGNAR PERMISOS A GRUPOS',1),(37,'PUEDE HACER CUADRE DE CAJA',1),(38,'PUEDE AUTORIZAR PEDIDOS',1),(39,'PUEDE DESPACHAR PEDIDOS',1),(40,'PUEDE ANULAR PEDIDOS',1),(41,'PUEDE CREAR PEDIDOS',1),(42,'PUEDE CAMBIAR FECHA EN EGRESOS DE CAJA',1),(43,'PUEDE CREAR EGRESOS DE CAJA',1),(44,'PUEDE CREAR Y MODIFICAR EMPLEADOS',1),(45,'PUEDE MODIFICAR DATOS DE SISTEMA',1),(46,'PUEDE MODIFICAR DATOS DE EMPRESA',1),(47,'PUEDE GENERAR LA NOMINA',1),(48,'PUEDE REALIZAR INGRESOS A CAJA',1);
/*!40000 ALTER TABLE `permiso` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `persona`
--

DROP TABLE IF EXISTS `persona`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `persona` (
  `codigo` int(11) NOT NULL,
  `apellido` varchar(50) COLLATE utf8_bin DEFAULT NULL,
  `fecha_nacimiento` date NOT NULL,
  `activo` tinyint(3) unsigned NOT NULL,
  PRIMARY KEY (`codigo`),
  CONSTRAINT `persona_tercero` FOREIGN KEY (`codigo`) REFERENCES `tercero` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `persona`
--

LOCK TABLES `persona` WRITE;
/*!40000 ALTER TABLE `persona` DISABLE KEYS */;
INSERT INTO `persona` VALUES (1,'ADMIN','2016-05-28',1),(2,'General','2016-05-28',1),(3,NULL,'2016-07-23',1),(4,NULL,'2016-07-23',1),(5,'DE LA ROSA','1996-03-04',1),(6,NULL,'2016-07-23',1),(7,'.','2016-05-29',1),(8,'dgdg','2016-07-23',1),(9,'dffd','2016-07-23',1),(10,'fdhgfh','2016-07-23',1),(11,'gfghg','2016-07-23',1),(12,'jgf','2016-07-23',1),(13,'jgffg','2016-07-23',1),(14,'jgfjf','2016-07-23',1),(15,'jh','2016-07-23',1),(16,'jgfj','2016-07-23',1),(17,'gfj','2016-07-23',1),(18,'k','2016-07-23',1),(19,'uk','2016-07-23',1),(20,'fhm','2016-07-23',1),(21,'d','2016-07-23',1),(22,'rhrhrh rh e','2016-07-23',1),(23,'rh h','2016-07-23',1),(24,'dfhdfhdf','2016-07-23',1),(25,' hfdhfdh','2016-07-23',1),(26,'hdfhdfh','2016-07-23',1),(27,'hfhdfhdf','2016-07-23',1),(28,'dfhfh','2016-07-23',1),(29,'fhfd','2016-07-23',1),(30,'dfh','2016-07-23',1),(31,'fh','2016-07-23',1),(32,'dfh','2016-07-23',1),(33,'dfh','2016-07-23',1),(34,'fgjfk','2016-07-23',1),(35,'krerg','2016-07-23',1),(36,'esgdsds','2016-07-23',1),(37,NULL,'2016-07-23',1),(38,'dngmhk','2016-07-23',1),(40,'loca','2016-08-06',1);
/*!40000 ALTER TABLE `persona` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `producto`
--

DROP TABLE IF EXISTS `producto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `producto` (
  `codigo` int(11) NOT NULL,
  `nombre` varchar(300) CHARACTER SET utf8 NOT NULL,
  `referencia` varchar(50) COLLATE utf8_bin DEFAULT NULL,
  `estado` bit(1) DEFAULT NULL,
  `reorden` decimal(20,2) NOT NULL DEFAULT '0.00',
  `punto_maximo` decimal(20,2) NOT NULL DEFAULT '0.00',
  `cod_itebis` int(11) NOT NULL,
  `cod_categoria` int(11) NOT NULL,
  `cod_subcategoria` int(11) NOT NULL,
  `cod_almacen` int(11) NOT NULL,
  `imagen` varchar(999) COLLATE utf8_bin DEFAULT NULL,
  `cod_unidad_minima` int(11) NOT NULL,
  PRIMARY KEY (`codigo`),
  KEY `producto_categoria_idx` (`cod_categoria`),
  KEY `producto_subcategoria_idx` (`cod_subcategoria`),
  KEY `producto_almacen_idx` (`cod_almacen`),
  KEY `producto_unidad_minima_idx` (`cod_unidad_minima`),
  KEY `producto_itebis_idx` (`cod_itebis`),
  CONSTRAINT `producto_almacen` FOREIGN KEY (`cod_almacen`) REFERENCES `almacen` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `producto_categoria` FOREIGN KEY (`cod_categoria`) REFERENCES `categoria_producto` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `producto_itebis` FOREIGN KEY (`cod_itebis`) REFERENCES `itebis` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `producto_subcategoria` FOREIGN KEY (`cod_subcategoria`) REFERENCES `subcategoria_producto` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `producto_unidad_minima` FOREIGN KEY (`cod_unidad_minima`) REFERENCES `unidad` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `producto`
--

LOCK TABLES `producto` WRITE;
/*!40000 ALTER TABLE `producto` DISABLE KEYS */;
/*!40000 ALTER TABLE `producto` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `producto_codigobarra`
--

DROP TABLE IF EXISTS `producto_codigobarra`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `producto_codigobarra` (
  `cod_producto` int(11) NOT NULL,
  `cod_unidad` int(11) NOT NULL,
  `codigo_barra` varchar(150) CHARACTER SET utf8 NOT NULL,
  KEY `producto_codigobarra_producto_idx` (`cod_producto`),
  KEY `producto_codigobarra_unidad_idx` (`cod_unidad`),
  CONSTRAINT `producto_codigobarra_producto` FOREIGN KEY (`cod_producto`) REFERENCES `producto` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `producto_codigobarra_unidad` FOREIGN KEY (`cod_unidad`) REFERENCES `unidad` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `producto_codigobarra`
--

LOCK TABLES `producto_codigobarra` WRITE;
/*!40000 ALTER TABLE `producto_codigobarra` DISABLE KEYS */;
/*!40000 ALTER TABLE `producto_codigobarra` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `producto_detalle`
--

DROP TABLE IF EXISTS `producto_detalle`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `producto_detalle` (
  `codigo` int(11) NOT NULL,
  `descripcion` varchar(100) COLLATE utf8_bin NOT NULL,
  `activo` tinyint(3) unsigned DEFAULT '1',
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `producto_detalle`
--

LOCK TABLES `producto_detalle` WRITE;
/*!40000 ALTER TABLE `producto_detalle` DISABLE KEYS */;
INSERT INTO `producto_detalle` VALUES (1,'COLOR',1),(2,'ALTURA',1),(3,'ANCHO',1),(4,'MODELO',1),(5,'SILLAS',1);
/*!40000 ALTER TABLE `producto_detalle` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `producto_oferta`
--

DROP TABLE IF EXISTS `producto_oferta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `producto_oferta` (
  `codigo` int(11) NOT NULL,
  `nombre` longtext CHARACTER SET utf8 NOT NULL,
  `descuento` float NOT NULL DEFAULT '0',
  `fecha_inicial` date DEFAULT NULL,
  `fecha_final` date DEFAULT NULL,
  `estado` int(11) DEFAULT '1',
  `cod_sucursal` int(11) NOT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `producto_oferta`
--

LOCK TABLES `producto_oferta` WRITE;
/*!40000 ALTER TABLE `producto_oferta` DISABLE KEYS */;
/*!40000 ALTER TABLE `producto_oferta` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `producto_oferta_historial`
--

DROP TABLE IF EXISTS `producto_oferta_historial`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `producto_oferta_historial` (
  `codigo` int(11) NOT NULL,
  `nombre` longtext COLLATE utf8_bin,
  `descuento` decimal(20,2) DEFAULT '0.00',
  `fecha_inicial` date DEFAULT NULL,
  `fecha_final` date DEFAULT NULL,
  `estado` int(11) DEFAULT '1',
  `fecha_actualizada` date DEFAULT NULL,
  `cod_empleado_actualiza` int(11) DEFAULT '0',
  `cod_sucursal` int(11) NOT NULL,
  KEY `producto_oferta_historial_empleado_idx` (`cod_empleado_actualiza`),
  KEY `producto_oferta_historial_sucursal_idx` (`cod_sucursal`),
  CONSTRAINT `producto_oferta_historial_empleado` FOREIGN KEY (`cod_empleado_actualiza`) REFERENCES `empleado` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `producto_oferta_historial_sucursal` FOREIGN KEY (`cod_sucursal`) REFERENCES `sucursal` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `producto_oferta_historial`
--

LOCK TABLES `producto_oferta_historial` WRITE;
/*!40000 ALTER TABLE `producto_oferta_historial` DISABLE KEYS */;
/*!40000 ALTER TABLE `producto_oferta_historial` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `producto_permisos`
--

DROP TABLE IF EXISTS `producto_permisos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `producto_permisos` (
  `codigo` int(11) NOT NULL,
  `nombre` varchar(50) CHARACTER SET utf8 NOT NULL,
  `activo` tinyint(3) unsigned NOT NULL DEFAULT '1',
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `producto_permisos`
--

LOCK TABLES `producto_permisos` WRITE;
/*!40000 ALTER TABLE `producto_permisos` DISABLE KEYS */;
INSERT INTO `producto_permisos` VALUES (1,'VENDER A PRECIO DIFERENTE',1),(2,'NO CONTROLA INVENTARIO',1);
/*!40000 ALTER TABLE `producto_permisos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `producto_productos_requisitos`
--

DROP TABLE IF EXISTS `producto_productos_requisitos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `producto_productos_requisitos` (
  `codpro_titular` int(11) DEFAULT NULL,
  `codpro_requisito` int(11) DEFAULT NULL,
  `cod_unidad` int(11) DEFAULT NULL,
  `cantidad` decimal(20,2) DEFAULT NULL,
  KEY `producto_productos_requisitos_producto_titular_idx` (`codpro_titular`),
  KEY `producto_productos_requisitos_producto_requisito_idx` (`codpro_requisito`),
  KEY `producto_productos_requisitos_unidad_idx` (`cod_unidad`),
  CONSTRAINT `producto_productos_requisitos_producto_requisito` FOREIGN KEY (`codpro_requisito`) REFERENCES `producto` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `producto_productos_requisitos_producto_titular` FOREIGN KEY (`codpro_titular`) REFERENCES `producto` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `producto_productos_requisitos_unidad` FOREIGN KEY (`cod_unidad`) REFERENCES `unidad` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `producto_productos_requisitos`
--

LOCK TABLES `producto_productos_requisitos` WRITE;
/*!40000 ALTER TABLE `producto_productos_requisitos` DISABLE KEYS */;
/*!40000 ALTER TABLE `producto_productos_requisitos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `producto_unidad`
--

DROP TABLE IF EXISTS `producto_unidad`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `producto_unidad` (
  `cod_producto` int(11) NOT NULL,
  `cod_unidad` int(11) NOT NULL,
  PRIMARY KEY (`cod_producto`,`cod_unidad`),
  KEY `producto_unidad_unidad_idx` (`cod_unidad`),
  CONSTRAINT `producto_unidad_producto` FOREIGN KEY (`cod_producto`) REFERENCES `producto` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `producto_unidad_unidad` FOREIGN KEY (`cod_unidad`) REFERENCES `unidad` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `producto_unidad`
--

LOCK TABLES `producto_unidad` WRITE;
/*!40000 ALTER TABLE `producto_unidad` DISABLE KEYS */;
/*!40000 ALTER TABLE `producto_unidad` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `producto_unidad_conversion`
--

DROP TABLE IF EXISTS `producto_unidad_conversion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `producto_unidad_conversion` (
  `cod_producto` int(11) NOT NULL,
  `cod_unidad` int(11) NOT NULL,
  `cantidad` decimal(20,2) DEFAULT '1.00',
  `precio_venta` decimal(20,2) DEFAULT NULL,
  `costo` decimal(20,2) DEFAULT NULL,
  PRIMARY KEY (`cod_producto`,`cod_unidad`),
  KEY `producto_unidad_conversion_unidad_idx` (`cod_unidad`),
  CONSTRAINT `producto_unidad_conversion_producto` FOREIGN KEY (`cod_producto`) REFERENCES `producto` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `producto_unidad_conversion_unidad` FOREIGN KEY (`cod_unidad`) REFERENCES `unidad` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `producto_unidad_conversion`
--

LOCK TABLES `producto_unidad_conversion` WRITE;
/*!40000 ALTER TABLE `producto_unidad_conversion` DISABLE KEYS */;
/*!40000 ALTER TABLE `producto_unidad_conversion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `producto_vs_detalle`
--

DROP TABLE IF EXISTS `producto_vs_detalle`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `producto_vs_detalle` (
  `codigo_producto` int(11) NOT NULL,
  `codigo_detalle` int(11) NOT NULL,
  `descripcion` mediumtext COLLATE utf8_bin,
  PRIMARY KEY (`codigo_producto`,`codigo_detalle`),
  KEY `producto_vs_detalle_productoDetalle_idx` (`codigo_detalle`),
  CONSTRAINT `producto_vs_detalle_producto` FOREIGN KEY (`codigo_producto`) REFERENCES `producto` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `producto_vs_detalle_producto_Detalle` FOREIGN KEY (`codigo_detalle`) REFERENCES `producto_detalle` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `producto_vs_detalle`
--

LOCK TABLES `producto_vs_detalle` WRITE;
/*!40000 ALTER TABLE `producto_vs_detalle` DISABLE KEYS */;
/*!40000 ALTER TABLE `producto_vs_detalle` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `producto_vs_permisos`
--

DROP TABLE IF EXISTS `producto_vs_permisos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `producto_vs_permisos` (
  `codigo` int(11) NOT NULL,
  `cod_producto` int(11) NOT NULL,
  `cod_permiso` int(11) NOT NULL,
  PRIMARY KEY (`codigo`),
  KEY `producto_vs_permisos_producto_idx` (`cod_producto`),
  KEY `producto_vs_permisos_permiso_idx` (`cod_permiso`),
  CONSTRAINT `producto_vs_permisos_permiso` FOREIGN KEY (`cod_permiso`) REFERENCES `producto_permisos` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `producto_vs_permisos_producto` FOREIGN KEY (`cod_producto`) REFERENCES `producto` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `producto_vs_permisos`
--

LOCK TABLES `producto_vs_permisos` WRITE;
/*!40000 ALTER TABLE `producto_vs_permisos` DISABLE KEYS */;
/*!40000 ALTER TABLE `producto_vs_permisos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `provincia`
--

DROP TABLE IF EXISTS `provincia`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `provincia` (
  `codigo` int(11) NOT NULL,
  `cod_region` int(11) NOT NULL,
  `nombre` varchar(50) COLLATE utf8_bin NOT NULL,
  `activo` tinyint(3) unsigned NOT NULL,
  PRIMARY KEY (`codigo`),
  KEY `provincia_region_idx` (`cod_region`),
  CONSTRAINT `provincia_region` FOREIGN KEY (`cod_region`) REFERENCES `region` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `provincia`
--

LOCK TABLES `provincia` WRITE;
/*!40000 ALTER TABLE `provincia` DISABLE KEYS */;
INSERT INTO `provincia` VALUES (1,1,'SANTIAGO DE LOS CABALLEROS',1),(2,2,'SAN PEDRO DE MACORIS',1),(3,3,'SANTO DOMINGO',1);
/*!40000 ALTER TABLE `provincia` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `region`
--

DROP TABLE IF EXISTS `region`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `region` (
  `codigo` int(11) NOT NULL,
  `cod_pais` int(11) NOT NULL,
  `nombre` varchar(50) COLLATE utf8_bin NOT NULL,
  `activo` tinyint(3) unsigned NOT NULL,
  PRIMARY KEY (`codigo`),
  KEY `region_pais_idx` (`cod_pais`),
  CONSTRAINT `region_pais` FOREIGN KEY (`cod_pais`) REFERENCES `pais` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `region`
--

LOCK TABLES `region` WRITE;
/*!40000 ALTER TABLE `region` DISABLE KEYS */;
INSERT INTO `region` VALUES (1,1,'NORTE',1),(2,1,'ESTE',1),(3,1,'SUR',1);
/*!40000 ALTER TABLE `region` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sector`
--

DROP TABLE IF EXISTS `sector`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sector` (
  `codigo` int(11) NOT NULL,
  `cod_provincia` int(11) NOT NULL,
  `nombre` varchar(50) COLLATE utf8_bin NOT NULL,
  `activo` tinyint(3) unsigned NOT NULL,
  PRIMARY KEY (`codigo`),
  KEY `sector_provincia_idx` (`cod_provincia`),
  CONSTRAINT `sector_provincia` FOREIGN KEY (`cod_provincia`) REFERENCES `provincia` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sector`
--

LOCK TABLES `sector` WRITE;
/*!40000 ALTER TABLE `sector` DISABLE KEYS */;
INSERT INTO `sector` VALUES (1,1,'CENTRO DE LA CIUDAD',1),(2,2,'EL ABANICO',1),(3,3,'VILLA FRANCISCA',1);
/*!40000 ALTER TABLE `sector` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sexo`
--

DROP TABLE IF EXISTS `sexo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sexo` (
  `codigo` int(11) NOT NULL,
  `sexo` varchar(50) COLLATE utf8_bin NOT NULL,
  `activo` tinyint(3) unsigned NOT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sexo`
--

LOCK TABLES `sexo` WRITE;
/*!40000 ALTER TABLE `sexo` DISABLE KEYS */;
INSERT INTO `sexo` VALUES (1,'MASCULINO',1),(2,'FEMENINO',1);
/*!40000 ALTER TABLE `sexo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sistema`
--

DROP TABLE IF EXISTS `sistema`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sistema` (
  `codigo` int(11) NOT NULL AUTO_INCREMENT,
  `ruta_imagen_productos` varchar(999) CHARACTER SET utf8 NOT NULL,
  `ruta_backup` varchar(999) CHARACTER SET utf8 NOT NULL,
  `ruta_logo_empresa` varchar(999) CHARACTER SET utf8 NOT NULL,
  `codigo_moneda` int(11) NOT NULL DEFAULT '1',
  `permisos_por_grupos_usuarios` tinyint(4) NOT NULL DEFAULT '1',
  `autorizar_pedidos_apartir` decimal(20,2) NOT NULL DEFAULT '0.00',
  `limite_egreso_caja` decimal(20,2) NOT NULL DEFAULT '0.00',
  `usar_comprobantes` tinyint(4) NOT NULL DEFAULT '0',
  `fecha_vencimiento` date DEFAULT NULL,
  `ver_imagen_fact_touch` tinyint(4) NOT NULL DEFAULT '1',
  `ver_nombre_fact_touch` tinyint(4) NOT NULL DEFAULT '1',
  `porciento_propina` decimal(20,2) DEFAULT '0.00',
  PRIMARY KEY (`codigo`),
  KEY `sistema_moneda_idx` (`codigo_moneda`),
  CONSTRAINT `sistema_moneda` FOREIGN KEY (`codigo_moneda`) REFERENCES `moneda` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sistema`
--

LOCK TABLES `sistema` WRITE;
/*!40000 ALTER TABLE `sistema` DISABLE KEYS */;
/*!40000 ALTER TABLE `sistema` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sistema_modulo`
--

DROP TABLE IF EXISTS `sistema_modulo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sistema_modulo` (
  `id` int(11) NOT NULL,
  `nombre` varchar(100) COLLATE utf8_bin NOT NULL,
  `activo` tinyint(4) DEFAULT NULL,
  `nombre_modulo_proyecto` varchar(100) COLLATE utf8_bin NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sistema_modulo`
--

LOCK TABLES `sistema_modulo` WRITE;
/*!40000 ALTER TABLE `sistema_modulo` DISABLE KEYS */;
INSERT INTO `sistema_modulo` VALUES (1,'Inventario',1,'modulo_inventario');
/*!40000 ALTER TABLE `sistema_modulo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sistema_modulo_opciones`
--

DROP TABLE IF EXISTS `sistema_modulo_opciones`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sistema_modulo_opciones` (
  `codigo` int(11) NOT NULL,
  `descripcion` longtext COLLATE utf8_bin,
  `cod_modulo` int(11) NOT NULL,
  `nombre_logico` longtext CHARACTER SET utf8 NOT NULL,
  `imagen` longtext COLLATE utf8_bin,
  `activo` tinyint(3) unsigned NOT NULL DEFAULT '1',
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sistema_modulo_opciones`
--

LOCK TABLES `sistema_modulo_opciones` WRITE;
/*!40000 ALTER TABLE `sistema_modulo_opciones` DISABLE KEYS */;
INSERT INTO `sistema_modulo_opciones` VALUES (1,'Catalogo Cuentas',1,'catalogo_cuentas','categoria.png',1);
/*!40000 ALTER TABLE `sistema_modulo_opciones` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `situacion_empleado`
--

DROP TABLE IF EXISTS `situacion_empleado`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `situacion_empleado` (
  `codigo` int(11) NOT NULL,
  `descripcion` varchar(50) CHARACTER SET utf8 DEFAULT NULL,
  `activo` tinyint(3) unsigned NOT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `situacion_empleado`
--

LOCK TABLES `situacion_empleado` WRITE;
/*!40000 ALTER TABLE `situacion_empleado` DISABLE KEYS */;
INSERT INTO `situacion_empleado` VALUES (1,'LABORANDO',1),(2,'DESPEDIDO',1),(3,'VACACIONES',1),(4,'LICENCIA',1);
/*!40000 ALTER TABLE `situacion_empleado` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `subcategoria_producto`
--

DROP TABLE IF EXISTS `subcategoria_producto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `subcategoria_producto` (
  `codigo` int(11) NOT NULL,
  `nombre` varchar(100) CHARACTER SET utf8 NOT NULL,
  `cod_categoria` int(11) NOT NULL,
  `activo` tinyint(3) unsigned NOT NULL DEFAULT '1',
  PRIMARY KEY (`codigo`),
  KEY `subcategoria_producto_Categoria_idx` (`cod_categoria`),
  CONSTRAINT `subcategoria_producto_Categoria` FOREIGN KEY (`cod_categoria`) REFERENCES `categoria_producto` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `subcategoria_producto`
--

LOCK TABLES `subcategoria_producto` WRITE;
/*!40000 ALTER TABLE `subcategoria_producto` DISABLE KEYS */;
INSERT INTO `subcategoria_producto` VALUES (1,'GENERAL',1,1),(2,'CARNES',2,1),(3,'VEGETALES',2,1),(4,'CEREALES',2,1),(5,'ALCOHOLICAS',3,1);
/*!40000 ALTER TABLE `subcategoria_producto` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sucursal`
--

DROP TABLE IF EXISTS `sucursal`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sucursal` (
  `codigo` int(11) NOT NULL DEFAULT '0',
  `codigo_empresa` int(11) NOT NULL,
  `secuencia` varchar(3) COLLATE utf8_bin NOT NULL,
  `activo` tinyint(3) unsigned NOT NULL DEFAULT '1',
  `direccion` varchar(200) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sucursal`
--

LOCK TABLES `sucursal` WRITE;
/*!40000 ALTER TABLE `sucursal` DISABLE KEYS */;
INSERT INTO `sucursal` VALUES (4,3,'001',1,NULL),(6,3,'002',1,NULL);
/*!40000 ALTER TABLE `sucursal` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `suplidor`
--

DROP TABLE IF EXISTS `suplidor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `suplidor` (
  `codigo` int(11) NOT NULL DEFAULT '0',
  `nombre` varchar(100) COLLATE utf8_bin NOT NULL,
  `rnc` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `fecha_creacion` date NOT NULL,
  `cod_sucursal_creado` int(11) NOT NULL,
  `limite_credito` decimal(20,2) DEFAULT NULL,
  `activo` tinyint(3) unsigned NOT NULL,
  `direccion` varchar(200) COLLATE utf8_bin DEFAULT NULL,
  `telefono1` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `telefono2` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`codigo`),
  KEY `suplidor_sucursal_idx` (`cod_sucursal_creado`),
  CONSTRAINT `suplidor_sucursal` FOREIGN KEY (`cod_sucursal_creado`) REFERENCES `sucursal` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `suplidor`
--

LOCK TABLES `suplidor` WRITE;
/*!40000 ALTER TABLE `suplidor` DISABLE KEYS */;
INSERT INTO `suplidor` VALUES (5,'',NULL,'2016-05-28',0,NULL,1,NULL,NULL,NULL),(7,'',NULL,'2016-05-29',0,NULL,1,NULL,NULL,NULL);
/*!40000 ALTER TABLE `suplidor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `suplidores_dgii`
--

DROP TABLE IF EXISTS `suplidores_dgii`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `suplidores_dgii` (
  `identificacion` longtext COLLATE utf8_bin,
  `nombre` longtext COLLATE utf8_bin,
  `nombre_comercial` longtext COLLATE utf8_bin
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `suplidores_dgii`
--

LOCK TABLES `suplidores_dgii` WRITE;
/*!40000 ALTER TABLE `suplidores_dgii` DISABLE KEYS */;
INSERT INTO `suplidores_dgii` VALUES ('1','1','1'),('1','1','1'),('1','1','1'),('1','1','1'),('1','1','1'),('1','1','1'),('1','1','1'),('1','1','1'),('1','1','1'),('1','1','1'),('1','1','1'),('1','1','1'),('1','1','1'),('1','1','1'),('1','1','1'),('1','1','1'),('1','1','1'),('1','1','1'),('1','1','1'),('1','1','1'),('1','1','1'),('1','1','1'),('1','1','1'),('1','1','1'),('1','1','1'),('1','1','1'),('1','1','1'),('1','1','1'),('1','1','1'),('1','1','1'),('1','1','1'),('1','1','1'),('1','1','1'),('1','1','1'),('1','1','1'),('1','1','1'),('1','1','1'),('1','1','1'),('1','1','1'),('1','1','1'),('1','1','1'),('1','1','1'),('1','1','1'),('1','1','1'),('1','1','1'),('1','1','1'),('1','1','1'),('1','1','1'),('1','1','1'),('1','1','1');
/*!40000 ALTER TABLE `suplidores_dgii` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sysdiagrams`
--

DROP TABLE IF EXISTS `sysdiagrams`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sysdiagrams` (
  `diagram_id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(128) CHARACTER SET utf8 NOT NULL,
  `principal_id` int(11) NOT NULL,
  `version` int(11) DEFAULT NULL,
  `definition` longblob,
  PRIMARY KEY (`diagram_id`),
  UNIQUE KEY `UK_principal_name` (`principal_id`,`name`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sysdiagrams`
--

LOCK TABLES `sysdiagrams` WRITE;
/*!40000 ALTER TABLE `sysdiagrams` DISABLE KEYS */;
INSERT INTO `sysdiagrams` VALUES (1,'Diagram_0',1,1,'\�\�ࡱ\Z\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0>\0\0��	\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0����\0\0\0\0\0\0\0\0<\0\0\0\0\0\0\0\0����������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\Z\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0 \0\0\0!\0\0\0\"\0\0\0#\0\0\0$\0\0\0%\0\0\0&\0\0\0\'\0\0\0(\0\0\0)\0\0\0*\0\0\0+\0\0\0,\0\0\0-\0\0\0.\0\0\0/\0\0\00\0\0\01\0\0\02\0\0\03\0\0\04\0\0\05\0\0\06\0\0\07\0\0\08\0\0\09\0\0\0:\0\0\0;\0\0\0��������>\0\0\0?\0\0\0@\0\0\0A\0\0\0B\0\0\0C\0\0\0D\0\0\0E\0\0\0F\0\0\0G\0\0\0H\0\0\0I\0\0\0J\0\0\0K\0\0\0L\0\0\0M\0\0\0N\0\0\0O\0\0\0P\0\0\0Q\0\0\0R\0\0\0S\0\0\0T\0\0\0U\0\0\0V\0\0\0W\0\0\0X\0\0\0Y\0\0\0Z\0\0\0[\0\0\0\\\0\0\0]\0\0\0^\0\0\0_\0\0\0`\0\0\0a\0\0\0b\0\0\0c\0\0\0d\0\0\0e\0\0\0f\0\0\0g\0\0\0h\0\0\0i\0\0\0j\0\0\0k\0\0\0l\0\0\0m\0\0\0n\0\0\0o\0\0\0p\0\0\0q\0\0\0r\0\0\0s\0\0\0t\0\0\0u\0\0\0v\0\0\0w\0\0\0x\0\0\0y\0\0\0z\0\0\0{\0\0\0|\0\0\0}\0\0\0~\0\0\0\0\0\0�\0\0\0R\0o\0o\0t\0 \0E\0n\0t\0r\0y\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0��������\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�g�&\�\0\0\0\0\0\0\0\0\0f\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0������������\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�s\0\0\0\0\0\0o\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0����\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0=\0\0\0��\0\0\0\0\0\0C\0o\0m\0p\0O\0b\0j\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0������������\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0_\0\0\0\0\0\0\0\00\0\n\0\0��\0\0\0���\0\0\0}\0\00�\0\0�H\0\0\'\�\0ه\0�\0\0*\0ހ[�\���\0�\0�\�\\\0\0\00\0\0\0\0\0\0\0\0\0<\0k\0\0\0	\0\0\0\0\0\0\0\�\�\��\��Q\0�\�W9�;�a\�C�5)�\�\�R��2}�\�b�B��\'<%�\�-\0\0(\0C\0\0\0\0\0\0\0SDM\�\��c\0`�\�\�H4\�\�wyw\��p\0[�\r�\0\0(\0C\0\0\0\0\0\0\0QDM\�\��c\0`�\�\�H4\�\�wyw\��p\0[�\r�r\0\0\�r\0\0\0�\0�\0�\0\0\0\00\0�	\0\0\0\0�\0\0\0�\0\0\0�\0\0\0\0�SchGrid\0<�\0\0��\0almacen\0\0\00\0�	\0\0\0\0�\0\0\0�\0\0\0�\0\0\0\0�SchGrid\0RB\0�N\0bancoid\0\0\0,\0�	\0\0\0\0�\0\0\0�\0\0\0�\0\0\0\0�SchGrid\0Br\0\0\�\0\0caja\0\00\0�	\0\0\0\0�\0\0\0�\0\0\0�\0\0\0\0�SchGrid\0Br\0\0\�\0\0cajerod\0\0\0d\0�	\0\0\0\0�\0\0\0R\0\0\0�\0\09\0\0�Control\0c|\0\0G\�\0\0Relationship \'FK_cajero_caja\' between \'caja\' and \'cajero\'\0\0\0\0\0$\0�\0\0\0\0�\0\0\0O\0\0\0�\0\0Control\0�t\0\0\�\0\0\0\00\0�	\0\0\0\0�\0\0\0�\0\0\0�\0\0\0\0�SchGrid\0��\0\0xi\0\0cargoid\0\0\0<\0�	\0\0\0\0�\0\0\0�\0\0\0�\0\0\0\0�SchGrid\0\0\0\0\0jv\0categoria_producto\0\0\0\00\0�	\0\0\0\0�	\0\0\0�\0\0\0�\0\0\0\0�SchGrid\0\�k\0X�\0cliente\0\0\0<\0�	\0\0\0\0�\n\0\0\0�\0\0\0�\0\0\0\0�SchGrid\0v�\0<\�\0cliente_categoriao\0\0\0\0�\0�	\0\0\0\0�\0\0\0b\0\0\0�\0\0U\0\0�Control\0Gw\0u�\0Relationship \'FK_cliente_cliente_categoria\' between \'cliente_categoria\' and \'cliente\'\0\0\0\0\0$\0�\0\0\0\0�\0\0\0k\0\0\0�\0\0Control\0=j\0\�\�\0\0\0<\0�	\0\0\0\0�\r\0\0\0�\0\0\0�\0\0\0\0�SchGrid\0��\0\�\0cliente_subcategoria\0\0�\0�	\0\0\0\0�\0\0\0R\0\0\0�\0\0o\0\0�Control\0��\0\�\0Relationship \'FK_cliente_subcategoria_cliente_categoria\' between \'cliente_categoria\' and \'cliente_subcategoria\'\0\0\0$\0�\0\0\0\0�\0\0\0�\0\0\0�\0\0Control\0\'�\0�\�\0\0\0�\0�	\0\0\0\0�\0\0\0b\0\0\0�\0\0[\0\0�Control\0�u\0u�\0Relationship \'FK_cliente_cliente_subcategoria\' between \'cliente_subcategoria\' and \'cliente\'\0\0\0$\0�\0\0\0\0�\0\0\0q\0\0\0�\0\0Control\0�d\0\�\0\0\00\0�	\0\0\0\0�\0\0\0�\0\0\0�\0\0\0\0�SchGrid\0��\0ڹ\0comboid\0\0\00\0�	\0\0\0\0�\0\0\0�\0\0\0�\0\0\0\0�SchGrid\0t\0�\�\0comprad\0\0\08\0�	\0\0\0\0�\0\0\0�\0\0\0�\0\0\0\0�SchGrid\0\nA\0\0po\0compra_detalle\0\0\0\0<\0�	\0\0\0\0�\0\0\0�\0\0\0�\0\0\0\0�SchGrid\0t\0��\0compra_pago_anulados\0\0�\0�	\0\0\0\0�\0\0\0R\0\0\0�\0\0Y\0\0�Control\03~\0P\�\0Relationship \'FK_compra_pago_anulados_compra\' between \'compra\' and \'compra_pago_anulados\'e\'\0\0\0$\0�\0\0\0\0�\Z\0\0\0o\0\0\0�\0\0Control\0y�\0\�\�\0\0\08\0�	\0\0\0\0�\0\0\0�\0\0\0�\0\0\0\0�SchGrid\0\�\0�\�\0compra_vs_pagos\0\0\0x\0�	\0\0\0\0�\0\0\0R\0\0\0�\0\0O\0\0�Control\0\'�\0O\�\0Relationship \'FK_compra_vs_pagos_compra\' between \'compra\' and \'compra_vs_pagos\'\0\0\0$\0�\0\0\0\0�\0\0\0e\0\0\0�\0\0Control\0�\0�\�\0\0\0<\0�	\0\0\0\0�\0\0\0�\0\0\0�\0\0\0\0�SchGrid\0\�a\0\0,-\0comprobante_fiscalos\0\0<\0�	\0\0\0\0�\0\0\0�\0\0\0�\0\0\0\0�SchGrid\0\nA\0\0�3\0comprobante_serielos\0\0�\0�	\0\0\0\0� \0\0\0R\0\0\0�\0\0k\0\0�Control\0W\0\0�9\0Relationship \'FK_comprobante_fiscal_comprobante_serie\' between \'comprobante_serie\' and \'comprobante_fiscal\'r\0\0$\0�\0\0\0\0�!\0\0\0�\0\0\0�\0\0Control\0MQ\0\0\�;\0\0\0<\0�	\0\0\0\0�\"\0\0\0�\0\0\0�\0\0\0\0�SchGrid\0Br\0\0\�\0\0comprobante_ventasos\0\0|\0�	\0\0\0\0�#\0\0\0R\0\0\0�\0\0Q\0\0�Control\0c|\0\0�\�\0\0Relationship \'FK_comprobante_ventas_caja\' between \'caja\' and \'comprobante_ventas\'nte\0\0$\0�\0\0\0\0�$\0\0\0g\0\0\0�\0\0Control\0�~\0\0Q\�\0\0\0\04\0�	\0\0\0\0�%\0\0\0�\0\0\0�\0\0\n\0\0�SchGrid\0�K\0��\0cotizacionpa\0\0p\0�	\0\0\0\0�&\0\0\0b\0\0\0�\0\0G\0\0�Control\0�a\0�\0Relationship \'FK_cotizacion_cliente\' between \'cliente\' and \'cotizacion\'\0\0\0$\0�\0\0\0\0�\'\0\0\0]\0\0\0�\0\0Control\0�X\0 �\0\0\0<\0�	\0\0\0\0�(\0\0\0�\0\0\0�\0\0\0\0�SchGrid\0�K\0ּ\0cotizacion_detalless\0\0�\0�	\0\0\0\0�)\0\0\0R\0\0\0�\0\0_\0\0�Control\0\�U\0��\0Relationship \'FK_cotizacion_detalles_cotizacion\' between \'cotizacion\' and \'cotizacion_detalles\'\0\0\0$\0�\0\0\0\0�*\0\0\0u\0\0\0�\0\0Control\0�D\0\0�\0\0\04\0�	\0\0\0\0�+\0\0\0�\0\0\0�\0\0\0\0�SchGrid\0L�\0\0�\�\0\0cuadre_cajaa\0\08\0�	\0\0\0\0�,\0\0\0�\0\0\0�\0\0\0\0�SchGrid\0\�\0\0�U\0\0cuenta_bancaria\0\0\04\0�	\0\0\0\0�-\0\0\0�\0\0\0�\0\0\0\0�SchGrid\0f�\0\0:x\0departamento\0\04\0�	\0\0\0\0�.\0\0\0�\0\0\0�\0\0	\0\0�SchGrid\0�.\0H\0direccionnto\0\04\0�	\0\0\0\0�/\0\0\0�\0\0\0�\0\0\0\0�SchGrid\0Jy\0\0n	\0egresos_caja\0\0t\0�	\0\0\0\0�0\0\0\0R\0\0\0�\0\0I\0\0�Control\0c|\0\0��\0\0Relationship \'FK_egresos_caja_cajero\' between \'cajero\' and \'egresos_caja\'pag\0\0$\0�\0\0\0\0�1\0\0\0_\0\0\0�\0\0Control\0p\0\0^\0\0\0<\0�	\0\0\0\0�2\0\0\0�\0\0\0�\0\0\0\0�SchGrid\0t!\0<�\0\0egresos_conceptosess\0\00\0�	\0\0\0\0�3\0\0\0�\0\0\0�\0\0\0\0�SchGrid\0�\0\0\�\�\0\0empleado\0\0x\0�	\0\0\0\0�4\0\0\0b\0\0\0�\0\0M\0\0�Controlo��\0\0^\0Relationship \'FK_empleado_departamento\' between \'departamento\' and \'empleado\'s\'\0\0\0$\0�\0\0\0\0�5\0\0\0c\0\0\0�\0\0Controlo\�\�\0\0|f\0\0\0t\0�	\0\0\0\0�6\0\0\0R\0\0\0�\0\0K\0\0�Controlo\'�\0\09\0\0Relationship \'FK_cuadre_caja_empleado\' between \'empleado\' and \'cuadre_caja\'o\0\0$\0�\0\0\0\0�7\0\0\0a\0\0\0�\0\0ControloB�\0\0\0\0\0l\0�	\0\0\0\0�8\0\0\0b\0\0\0�\0\0A\0\0�ControloW�\0\03�\0\0Relationship \'FK_cajero_empleado\' between \'empleado\' and \'cajero\'aci\0\0$\0�\0\0\0\0�9\0\0\0W\0\0\0�\0\0Controlo�\0\0�\0\0\0\0t\0�	\0\0\0\0�:\0\0\0b\0\0\0�\0\0I\0\0�Controlo\�\0\0b\0Relationship \'FK_cotizacion_empleado\' between \'empleado\' and \'cotizacion\'a\'o\0\0$\0�\0\0\0\0�;\0\0\0_\0\0\0�\0\0ControloI\0\�#\0\0\0@\0�	\0\0\0\0�<\0\0\0\�\0\0\0�\0\0\0\0�SchGrido�\0\0�\0\0empleado_historial_datos\0\0�\0�	\0\0\0\0�=\0\0\0R\0\0\0�\0\0_\0\0�Controlo5�\0\0�s\0\0Relationship \'FK_empleado_historial_datos_cargo\' between \'cargo\' and \'empleado_historial_datos\'\0\0\0$\0�\0\0\0\0�>\0\0\0u\0\0\0�\0\0Controlo�y\0\0�z\0\0\0\0�\0�	\0\0\0\0�?\0\0\0b\0\0\0�\0\0f\0\0�Controlo\�\0\0\"�\0\0Relationship \'FK_empleado_historial_datos_empleado1\' between \'empleado\' and \'empleado_historial_datos\'\0\0\0\0$\0�\0\0\0\0�@\0\0\0}\0\0\0�\0\0Controlo\�\0\0-\�\0\0\0\0�\0�	\0\0\0\0�A\0\0\0b\0\0\0�\0\0e\0\0�Controlo%�\0\0\"�\0\0Relationship \'FK_empleado_historial_datos_empleado\' between \'empleado\' and \'empleado_historial_datos\'\'\0\0\0\0$\0�\0\0\0\0�B\0\0\0{\0\0\0�\0\0Controlo!�\0\0+\�\0\0\0\0<\0�	\0\0\0\0�C\0\0\0�\0\0\0�\0\0\0\0�SchGrido��\0\0�U\0\0empleado_vs_cargol_d\0\0|\0�	\0\0\0\0�D\0\0\0R\0\0\0�\0\0Q\0\0�Controloˌ\0\0B]\0\0Relationship \'FK_empleado_vs_cargo_cargo\' between \'cargo\' and \'empleado_vs_cargo\'nte\0\0$\0�\0\0\0\0�E\0\0\0g\0\0\0�\0\0Controlo�\0\0\�c\0\0\0\0D\0�	\0\0\0\0�F\0\0\0\�\0\0\0�\0\0\0\0�SchGridoF1\0\�`\0empleado_vs_conceptos_nomina\0\0�\0�	\0\0\0\0�G\0\0\0b\0\0\0�\0\0m\0\0�Controlo!�\0\0b\0Relationship \'FK_empleado_vs_conceptos_nomina_empleado\' between \'empleado\' and \'empleado_vs_conceptos_nomina\'a\'\0\0\0$\0�\0\0\0\0�H\0\0\0�\0\0\0�\0\0Controlo$&\0Sg\0\0\00\0�	\0\0\0\0�I\0\0\0�\0\0\0�\0\0\0\0�SchGrido\n\0��\0empresao\0\0D\0�	\0\0\0\0�J\0\0\0\�\0\0\0�\0\0\0\0�SchGrido\\W\0�.\0entrada_salida_inventarioina\0\0�\0�	\0\0\0\0�K\0\0\0b\0\0\0�\0\0g\0\0�Controlo��\0\0b\0Relationship \'FK_entrada_salida_inventario_empleado\' between \'empleado\' and \'entrada_salida_inventario\'\0\0\0$\0�\0\0\0\0�L\0\0\0}\0\0\0�\0\0Controlo�E\0K\0\0\0<\0�	\0\0\0\0�M\0\0\0�\0\0\0�\0\0\0\0�SchGridoT�\0\0�4\0\0estados_reparacion_d\0\00\0�	\0\0\0\0�N\0\0\0�\0\0\0�\0\0\0\0�SchGridonT\0\�\0facturao\0\0l\0�	\0\0\0\0�O\0\0\0b\0\0\0�\0\0A\0\0�Controlo�^\0y�\0Relationship \'FK_factura_cliente\' between \'cliente\' and \'factura\'aci\0\0$\0�\0\0\0\0�P\0\0\0W\0\0\0�\0\0Contrololj\0�\�\0\0\08\0�	\0\0\0\0�Q\0\0\0�\0\0\0�\0\0\0\0�SchGrido�D\0p1\0factura_detalle\0\0\0|\0�	\0\0\0\0�R\0\0\0b\0\0\0�\0\0Q\0\0�Controlo\�N\0H%\0Relationship \'FK_factura_detalle_factura\' between \'factura\' and \'factura_detalle\'nte\0\0$\0�\0\0\0\0�S\0\0\0g\0\0\0�\0\0Controlo|J\0-\0\0\0<\0�	\0\0\0\0�T\0\0\0�\0\0\0�\0\0\0\0�SchGrido\�d\0p1\0facturas_anuladasn_d\0\0�\0�	\0\0\0\0�U\0\0\0b\0\0\0�\0\0U\0\0�Controlo%_\0H%\0Relationship \'FK_facturas_anuladas_factura\' between \'factura\' and \'facturas_anuladas\'\0\0\0\0\0$\0�\0\0\0\0�V\0\0\0k\0\0\0�\0\0Controlo\�T\0\�/\0\0\08\0�	\0\0\0\0�W\0\0\0�\0\0\0�\0\0\0\0�SchGridop\0��\0grupo_usuariose\0\0\0@\0�	\0\0\0\0�X\0\0\0�\0\0\0�\0\0\0\0�SchGridop\0З\0grupo_usuarios_permisoss\0\0�\0�	\0\0\0\0�Y\0\0\0R\0\0\0�\0\0o\0\0�Controlo\'z\0��\0Relationship \'FK_grupo_usuarios_permisos_grupo_usuarios\' between \'grupo_usuarios\' and \'grupo_usuarios_permisos\'\0\0\0$\0�\0\0\0\0�Z\0\0\0�\0\0\0�\0\0Controlom|\0��\0\0\0D\0�	\0\0\0\0�[\0\0\0\�\0\0\0�\0\0\0\0�SchGrido\�\0\0R\0historial_devolucion_compras\0\0�\0�	\0\0\0\0�\\\0\0\0b\0\0\0�\0\0m\0\0�Controlo\�\0\0b\0Relationship \'FK_historial_devolucion_compras_empleado\' between \'empleado\' and \'historial_devolucion_compras\'s\'\0\0\0$\0�\0\0\0\0�]\0\0\0�\0\0\0�\0\0Controlo}\0\0n6\0\0\0D\0�	\0\0\0\0�^\0\0\0\�\0\0\0�\0\0\0\0�SchGrido\�1\0��\0historial_devolucion_ventass\0\0�\0�	\0\0\0\0�_\0\0\0R\0\0\0�\0\0i\0\0�Controlo7J\0�\0\0Relationship \'FK_historial_devolucion_ventas_factura\' between \'factura\' and \'historial_devolucion_ventas\'ras\0\0$\0�\0\0\0\0�`\0\0\0\0\0\0�\0\0ControloE\0�\0\0\0\0D\0�	\0\0\0\0�a\0\0\0\�\0\0\0�\0\0\0\0�SchGridoU\0\�S\0historial_inventario_agotado\0\08\0�	\0\0\0\0�b\0\0\0�\0\0\0�\0\0\0\0�SchGrido֐\0\09\0identificacione\0\0\04\0�	\0\0\0\0�c\0\0\0�\0\0\0�\0\0\n\0\0�SchGrido`\0\0>u\0inventarioci\0\00\0�	\0\0\0\0�d\0\0\0�\0\0\0�\0\0\0\0�SchGrido\nA\0\0Z�\0itebisdo\0\0@\0�	\0\0\0\0�e\0\0\0�\0\0\0�\0\0\0\0�SchGrido$\�\0\0<�\0\0loteria_real_quinielaoss\0\00\0�	\0\0\0\0�f\0\0\0�\0\0\0�\0\0\0\0�SchGridoR\�\0\0\0\0marcasdo\0\00\0�	\0\0\0\0�g\0\0\0�\0\0\0�\0\0\0\0�SchGrido\0\0\0\0��\0mesasido\0\08\0�	\0\0\0\0�h\0\0\0�\0\0\0�\0\0\0\0�SchGrido\0\0\0\0|�\0mesas_detallese\0\0\0t\0�	\0\0\0\0�i\0\0\0R\0\0\0�\0\0K\0\0�Controlo!\n\0\0��\0Relationship \'FK_mesas_detalles_mesas\' between \'mesas\' and \'mesas_detalles\'o\0\0$\0�\0\0\0\0�j\0\0\0a\0\0\0�\0\0Controlog\0\0��\0\0\00\0�	\0\0\0\0�k\0\0\0�\0\0\0�\0\0\0\0�SchGridoU\0�U\0\0monedado\0\08\0�	\0\0\0\0�l\0\0\0�\0\0\0�\0\0\0\0�SchGridoU\0H?\0\0moneda_historial\0\0|\0�	\0\0\0\0�m\0\0\0R\0\0\0�\0\0Q\0\0�Controlo%_\0yI\0\0Relationship \'FK_moneda_historial_moneda\' between \'moneda\' and \'moneda_historial\'das\0\0$\0�\0\0\0\0�n\0\0\0g\0\0\0�\0\0Controloka\0�O\0\0\0\00\0�	\0\0\0\0�o\0\0\0�\0\0\0�\0\0\0\0�SchGrido@\0\�|\0nominado\0\0�\0�	\0\0\0\0�p\0\0\0Z\0\0\0�\0\0i\0\0�ControloU/\0�o\0Relationship \'FK_empleado_vs_conceptos_nomina_nomina\' between \'nomina\' and \'empleado_vs_conceptos_nomina\'ras\0\0$\0�\0\0\0\0�q\0\0\0\0\0\0�\0\0Controlo\�7\0��\0\0\0l\0�	\0\0\0\0�r\0\0\0b\0\0\0�\0\0A\0\0�Controlo��\0\0b\0Relationship \'FK_nomina_empleado\' between \'empleado\' and \'nomina\'aci\0\0$\0�\0\0\0\0�s\0\0\0W\0\0\0�\0\0Controlo�\0k�\0\0\08\0�	\0\0\0\0�t\0\0\0�\0\0\0�\0\0\0\0�SchGrido�<\00�\0nomina_conceptos\0\0�\0�	\0\0\0\0�u\0\0\0R\0\0\0�\0\0}\0\0�ControloG\0�o\0Relationship \'FK_empleado_vs_conceptos_nomina_nomina_conceptos\' between \'nomina_conceptos\' and \'empleado_vs_conceptos_nomina\'\0\0\0\0\0$\0�\0\0\0\0�v\0\0\0�\0\0\0�\0\0ControloeI\0-y\0\0\08\0�	\0\0\0\0�w\0\0\0�\0\0\0�\0\0\0\0�SchGrido�<\0̚\0nomina_detalleos\0\0x\0�	\0\0\0\0�x\0\0\0b\0\0\0�\0\0M\0\0�ControloU/\0��\0Relationship \'FK_nomina_detalle_nomina\' between \'nomina\' and \'nomina_detalle\'s\'\0\0\0$\0�\0\0\0\0�y\0\0\0c\0\0\0�\0\0ControloL8\0D�\0\0\0�\0�	\0\0\0\0�z\0\0\0R\0\0\0�\0\0a\0\0�ControloG\0\��\0Relationship \'FK_nomina_detalle_nomina_conceptos\' between \'nomina_conceptos\' and \'nomina_detalle\'tar\0\0$\0�\0\0\0\0�{\0\0\0w\0\0\0�\0\0Controlo03\0�\0\0\04\0�	\0\0\0\0�|\0\0\0�\0\0\0�\0\0\0\0�SchGrido@\0j�\0nomina_tipos\0\0t\0�	\0\0\0\0�}\0\0\0R\0\0\0�\0\0I\0\0�Controloa#\0��\0Relationship \'FK_nomina_nomina_tipos\' between \'nomina_tipos\' and \'nomina\'lle\0\0$\0�\0\0\0\0�~\0\0\0_\0\0\0�\0\0Controlo�%\0��\0\0\0@\0�	\0\0\0\0�\0\0\0�\0\0\0�\0\0\0\0�SchGrido\0�=\0\0oferta_producto_detalles\0\0H\0�	\0\0\0\0��\0\0\0\�\0\0\0�\0\0\0\0�SchGrido\0,\0Y\0\0oferta_producto_subcate_detalle\0\0\0,\0�	\0\0\0\0��\0\0\0�\0\0\0�\0\0\0\0�SchGrido\�O\0t\0pais\0\08\0�	\0\0\0\0��\0\0\0�\0\0\0�\0\0\0\0�SchGrido\�*\0b|\0pedido_detalleos\0\00\0�	\0\0\0\0��\0\0\0�\0\0\0�\0\0\0\0�SchGrido\�*\0\�O\0pedidoso\0\0l\0�	\0\0\0\0��\0\0\0b\0\0\0�\0\0A\0\0�Controlo\�@\0�_\0Relationship \'FK_pedidos_cliente\' between \'cliente\' and \'pedidos\'aci\0\0$\0�\0\0\0\0��\0\0\0W\0\0\0�\0\0Controloqe\0i\0\0\0x\0�	\0\0\0\0��\0\0\0R\0\0\0�\0\0O\0\0�Controlo�4\0bp\0Relationship \'FK_pedido_detalle_pedidos\' between \'pedidos\' and \'pedido_detalle\'\0\0\0$\0�\0\0\0\0��\0\0\0e\0\0\0�\0\0Controlo;7\0�v\0\0\0l\0�	\0\0\0\0��\0\0\0b\0\0\0�\0\0C\0\0�Controlo_�\0\0b\0Relationship \'FK_pedidos_empleado\' between \'empleado\' and \'pedidos\'i\0\0$\0�\0\0\0\0��\0\0\0Y\0\0\0�\0\0Controlo\�)\0�\�\0\0\00\0�	\0\0\0\0��\0\0\0�\0\0\0�\0\0\0\0�SchGrido6O\0ơ\0permisoo\0\0�\0�	\0\0\0\0��\0\0\0b\0\0\0�\0\0a\0\0�ControloKe\0��\0Relationship \'FK_grupo_usuarios_permisos_permiso\' between \'permiso\' and \'grupo_usuarios_permisos\'tar\0\0$\0�\0\0\0\0��\0\0\0w\0\0\0�\0\0Controlo�n\0\�\0\0\00\0�	\0\0\0\0��\0\0\0�\0\0\0�\0\0\0\0�SchGrido�c\0\0personao\0\0l\0�	\0\0\0\0��\0\0\0b\0\0\0�\0\0C\0\0�Controloҥ\0\0\�\0Relationship \'FK_empleado_persona\' between \'persona\' and \'empleado\'i\0\0$\0�\0\0\0\0��\0\0\0Y\0\0\0�\0\0Controlop\0�\0\0\0l\0�	\0\0\0\0��\0\0\0R\0\0\0�\0\0A\0\0�Controlo�u\07-\0Relationship \'FK_cliente_persona\' between \'persona\' and \'cliente\'o\'i\0\0$\0�\0\0\0\0��\0\0\0W\0\0\0�\0\0ControloQl\0�Z\0\0\00\0�	\0\0\0\0��\0\0\0�\0\0\0�\0\0\0\0�SchGrido\� \0\0�^\0producto\0\0|\0�	\0\0\0\0��\0\0\0b\0\0\0�\0\0T\0\0�Controlo\0\0�o\0Relationship \'FK_producto_tipo_producto\' between \'categoria_producto\' and \'producto\'\0\0$\0�\0\0\0\0��\0\0\0e\0\0\0�\0\0Controlo\�	\0\0�r\0\0\0l\0�	\0\0\0\0��\0\0\0b\0\0\0�\0\0C\0\0�Controlo\�6\0\0�o\0Relationship \'FK_producto_almacen\' between \'almacen\' and \'producto\'i\0\0$\0�\0\0\0\0��\0\0\0Y\0\0\0�\0\0Controlo�:\0\0�I\0\0\0l\0�	\0\0\0\0��\0\0\0b\0\0\0�\0\0A\0\0�Controlo�+\0\0~\0Relationship \'FK_producto_itebis\' between \'itebis\' and \'producto\'o\'i\0\0$\0�\0\0\0\0��\0\0\0W\0\0\0�\0\0Controlo\�-\0\0@\0\0\0h\0�	\0\0\0\0��\0\0\0b\0\0\0�\0\0?\0\0�Controlo\�6\0\0Oq\0Relationship \'FK_combo_producto\' between \'producto\' and \'combo\'\0\0\0$\0�\0\0\0\0��\0\0\0U\0\0\0�\0\0Controlo\�7\0\0\'\�\0\0\0t\0�	\0\0\0\0��\0\0\0b\0\0\0�\0\0I\0\0�Controlo\�6\0\0?c\0Relationship \'FK_inventario_producto\' between \'producto\' and \'inventario\'tal\0\0$\0�\0\0\0\0��\0\0\0_\0\0\0�\0\0Controlo\�?\0\0\\~\0\0\0�\0�	\0\0\0\0��\0\0\0b\0\0\0�\0\0[\0\0�ControloZ5\0\0Wx\0Relationship \'FK_cotizacion_detalles_producto\' between \'producto\' and \'cotizacion_detalles\'t\0\0$\0�\0\0\0\0��\0\0\0q\0\0\0�\0\0Controlo_$\0\03\0\0\0�\0�	\0\0\0\0��\0\0\0b\0\0\0�\0\0m\0\0�Controlo\�6\0\0]\0Relationship \'FK_historial_devolucion_compras_producto\' between \'producto\' and \'historial_devolucion_compras\'s\'\0\0\0$\0�\0\0\0\0��\0\0\0�\0\0\0�\0\0Controlo�R\0\0�_\0\0\0�\0�	\0\0\0\0��\0\0\0b\0\0\0�\0\0m\0\0�Controlo\�6\0\0\�f\0Relationship \'FK_historial_inventario_agotado_producto\' between \'producto\' and \'historial_inventario_agotado\'s\'\0\0\0$\0�\0\0\0\0��\0\0\0�\0\0\0�\0\0Controlo�C\0\0�_\0\0\0�\0�	\0\0\0\0��\0\0\0b\0\0\0�\0\0k\0\0�Controlo\�4\0\0z\0Relationship \'FK_historial_devolucion_ventas_producto\' between \'producto\' and \'historial_devolucion_ventas\'o\0\0$\0�\0\0\0\0��\0\0\0�\0\0\0�\0\0Controlo\�\0\0\nU\0\0\0|\0�	\0\0\0\0��\0\0\0b\0\0\0�\0\0Q\0\0�ControloZ5\0\0�v\0Relationship \'FK_pedido_detalle_producto\' between \'producto\' and \'pedido_detalle\'to\'\0\0$\0�\0\0\0\0��\0\0\0g\0\0\0�\0\0Controlo;P\0\03�\0\0\0|\0�	\0\0\0\0��\0\0\0b\0\0\0�\0\0S\0\0�Controlo)4\0\0\�{\0Relationship \'FK_factura_detalle_producto\' between \'producto\' and \'factura_detalle\'\'\0\0$\0�\0\0\0\0��\0\0\0i\0\0\0�\0\0Controlo\�$\0\0*e\0\0\0�\0�	\0\0\0\0��\0\0\0b\0\0\0�\0\0U\0\0�Controlo\�6\0\0Gj\0Relationship \'FK_compra_vs_producto_producto\' between \'producto\' and \'compra_detalle\'\0\0\0\0\0$\0�\0\0\0\0��\0\0\0o\0\0\0�\0\0Controlo�(\0\0��\0\0\0�\0�	\0\0\0\0��\0\0\0b\0\0\0�\0\0g\0\0�Controlo\�6\0\0e\0Relationship \'FK_entrada_salida_inventario_producto\' between \'producto\' and \'entrada_salida_inventario\'\0\0\0$\0�\0\0\0\0��\0\0\0}\0\0\0�\0\0Controlo>F\0\0�=\0\0\0<\0�	\0\0\0\0��\0\0\0�\0\0\0�\0\0\0\0�SchGrido\�x\0�\0producto_codigobarra\0\0�\0�	\0\0\0\0��\0\0\0b\0\0\0�\0\0]\0\0�Controlo\�6\0\0	l\0Relationship \'FK_producto_codigobarra_producto\' between \'producto\' and \'producto_codigobarra\'s\'\0\0\0$\0�\0\0\0\0��\0\0\0s\0\0\0�\0\0ControloJ3\0\0Y�\0\0\08\0�	\0\0\0\0��\0\0\0�\0\0\0�\0\0\0\0�SchGrido\� \0\0��\0producto_detalle\0\0�\0�	\0\0\0\0��\0\0\0b\0\0\0�\0\0a\0\0�Controlo\0\0s�\0Relationship \'FK_mesas_detalles_producto_detalle\' between \'producto_detalle\' and \'mesas_detalles\'tar\0\0$\0�\0\0\0\0��\0\0\0w\0\0\0�\0\0Controlo�\0\0å\0\0\08\0�	\0\0\0\0��\0\0\0�\0\0\0�\0\0\0\0�SchGrido0\0�U\0\0producto_ofertae\0\0�\0�	\0\0\0\0��\0\0\0R\0\0\0�\0\0�\0\0�ControloE!\0_\0\0Relationship \'FK_oferta_producto_subcate_detalle_producto_oferta\' between \'producto_oferta\' and \'oferta_producto_subcate_detalle\'\0\0\0\0\0$\0�\0\0\0\0��\0\0\0�\0\0\0�\0\0Controlo\�\0]a\0\0\0\0�\0�	\0\0\0\0��\0\0\0R\0\0\0�\0\0q\0\0�ControloQ\0�G\0\0Relationship \'FK_oferta_producto_detalle_producto_oferta\' between \'producto_oferta\' and \'oferta_producto_detalle\'\0e\0\0\0$\0�\0\0\0\0��\0\0\0�\0\0\0�\0\0Controlo�\0�N\0\0\0\0D\0�	\0\0\0\0��\0\0\0\�\0\0\0�\0\0\0\0�SchGrido0\0\�u\0\0producto_oferta_historialeta\0\0�\0�	\0\0\0\0��\0\0\0R\0\0\0�\0\0u\0\0�ControloQ\0�i\0\0Relationship \'FK_producto_oferta_historial_producto_oferta\' between \'producto_oferta\' and \'producto_oferta_historial\'\0\0\0\0\0$\0�\0\0\0\0��\0\0\0�\0\0\0�\0\0Controlo\��\0\0\nq\0\0\0\0<\0�	\0\0\0\0��\0\0\0�\0\0\0�\0\0\0\0�SchGrido81\0\0H?\0\0producto_permisosrra\0\08\0�	\0\0\0\0��\0\0\0�\0\0\0�\0\0\0\0�SchGrido�W\0 t\0producto_unidade\0\0|\0�	\0\0\0\0��\0\0\0b\0\0\0�\0\0S\0\0�Controlo\�6\0\0�h\0Relationship \'FK_producto_unidad_producto\' between \'producto\' and \'producto_unidad\'e\0\0$\0�\0\0\0\0��\0\0\0i\0\0\0�\0\0Controlo�.\0\0z\0\0\0D\0�	\0\0\0\0��\0\0\0\�\0\0\0�\0\0\Z\0\0�SchGrido\��\0\0`\0\0producto_unidad_conversionta\0\0<\0�	\0\0\0\0�\�\0\0\0�\0\0\0�\0\0\0\0�SchGrido\� \0\0Z�\0producto_vs_detallea\0\0�\0�	\0\0\0\0�\�\0\0\0R\0\0\0�\0\0o\0\0�Controlo�*\0\0��\0Relationship \'FK_producto_detalle_producto_especificacion\' between \'producto_detalle\' and \'producto_vs_detalle\'\0\0\0$\0�\0\0\0\0�\�\0\0\0�\0\0\0�\0\0Controlo7-\0\0\0�\0\0\0�\0�	\0\0\0\0�\�\0\0\0b\0\0\0�\0\0X\0\0�Controlo\�)\0\0�\0Relationship \'FK_producto_detalle_producto\' between \'producto\' and \'producto_vs_detalle\'\0\0$\0�\0\0\0\0�\�\0\0\0k\0\0\0�\0\0Controlo\Z\0\05\0\0\0<\0�	\0\0\0\0�\�\0\0\0�\0\0\0�\0\0\0\0�SchGridoh\0\0H?\0\0producto_vs_permisos\0\0�\0�	\0\0\0\0�\�\0\0\0R\0\0\0�\0\0o\0\0�Controlo}&\0\0#D\0\0Relationship \'FK_producto_vs_permisos_producto_permisos\' between \'producto_permisos\' and \'producto_vs_permisos\'\0\0\0$\0�\0\0\0\0�\�\0\0\0�\0\0\0�\0\0Controlo�\"\0\0�C\0\0\0\0�\0�	\0\0\0\0�\�\0\0\0b\0\0\0�\0\0]\0\0�Controlo�\Z\0\0yI\0\0Relationship \'FK_producto_vs_permisos_producto\' between \'producto\' and \'producto_vs_permisos\'s\'\0\0\0$\0�\0\0\0\0�\�\0\0\0s\0\0\0�\0\0Controlo7-\0\0�\�\0\0\0\04\0�	\0\0\0\0�\�\0\0\0�\0\0\0�\0\0	\0\0�SchGrido\�O\0�\�\0provinciauni\0\00\0�	\0\0\0\0�\�\0\0\0�\0\0\0�\0\0\0\0�SchGrido\�O\0B\�\0regiondo\0\0l\0�	\0\0\0\0�\�\0\0\0R\0\0\0�\0\0C\0\0�Controlo\�Y\0R\�\0Relationship \'FK_provincia_region\' between \'region\' and \'provincia\'i\0\0$\0�\0\0\0\0�\�\0\0\0Y\0\0\0�\0\0Controlo\�O\0\�\0\0\0d\0�	\0\0\0\0�\�\0\0\0R\0\0\0�\0\09\0\0�Controlo\�Y\0\��\0Relationship \'FK_region_pais\' between \'pais\' and \'region\'com\0\0$\0�\0\0\0\0�\�\0\0\0O\0\0\0�\0\0Controlo3\\\0\��\0\0\00\0�	\0\0\0\0�\�\0\0\0�\0\0\0�\0\0\0\0�SchGrido�.\0\�\0sectordo\0\0l\0�	\0\0\0\0�\�\0\0\0b\0\0\0�\0\0C\0\0�ControloE\0�\�\0Relationship \'FK_sector_provincia\' between \'provincia\' and \'sector\'i\0\0$\0�\0\0\0\0�\�\0\0\0Y\0\0\0�\0\0ControlorB\0	\�\0\0\0l\0�	\0\0\0\0�\�\0\0\0R\0\0\0�\0\0C\0\0�Controlo9\0\��\0Relationship \'FK_direccion_sector\' between \'sector\' and \'direccion\'i\0\0$\0�\0\0\0\0�\�\0\0\0Y\0\0\0�\0\0Controlo5/\0��\0\0\0,\0�	\0\0\0\0�\�\0\0\0�\0\0\0�\0\0\0\0�SchGridopC\0d \0sexo\0\0d\0�	\0\0\0\0�\�\0\0\0R\0\0\0�\0\0;\0\0�Controlo�Y\0?%\0Relationship \'FK_persona_sexo\' between \'sexo\' and \'persona\'m\0\0$\0�\0\0\0\0�\�\0\0\0Q\0\0\0�\0\0ControloTZ\0�\'\0\0\00\0�	\0\0\0\0�\�\0\0\0�\0\0\0�\0\0\0\0�SchGrido(#\0\0\0\0\0\0sistemao\0\0<\0�	\0\0\0\0�\�\0\0\0�\0\0\0�\0\0\0\0�SchGridoz�\0\0|�\0\0situacion_empleadoos\0\0�\0�	\0\0\0\0�\�\0\0\0R\0\0\0�\0\0y\0\0�Controlo��\0\0W�\0\0Relationship \'FK_empleado_historial_datos_situacion_empleado\' between \'situacion_empleado\' and \'empleado_historial_datos\'ina\0\0$\0�\0\0\0\0�\�\0\0\0�\0\0\0�\0\0Controlo$�\0\0\�\0\0\0\0�\0�	\0\0\0\0�\�\0\0\0b\0\0\0�\0\0Y\0\0�Controlo{�\0\0��\0\0Relationship \'FK_empleado_situacion_empleado\' between \'situacion_empleado\' and \'empleado\'sos\0\0$\0�\0\0\0\0�\�\0\0\0o\0\0\0�\0\0ControloΌ\0\0!�\0\0\0\0@\0�	\0\0\0\0�\�\0\0\0�\0\0\0�\0\0\0\0�SchGrido\0\0\0\08]\0subcategoria_productoles\0\0�\0�	\0\0\0\0�\�\0\0\0b\0\0\0�\0\0_\0\0�Controlo\0\0?c\0Relationship \'FK_producto_subcategoria_producto\' between \'subcategoria_producto\' and \'producto\'\0\0\0$\0�\0\0\0\0�\�\0\0\0u\0\0\0�\0\0Controlo�\0\0m\0\0\0�\0�	\0\0\0\0�\�\0\0\0R\0\0\0�\0\0s\0\0�Controlo!\n\0\0\�i\0Relationship \'FK_subcategoria_producto_categoria_producto\' between \'categoria_producto\' and \'subcategoria_producto\'l\0\0$\0�\0\0\0\0�\�\0\0\0�\0\0\0�\0\0Controlog\0\0\�p\0\0\00\0�	\0\0\0\0�\�\0\0\0�\0\0\0�\0\0\0\0�SchGrido�\�\0\0:x\0sucursal\0\0t\0�	\0\0\0\0�\�\0\0\0b\0\0\0�\0\0I\0\0�Controll�\�\0\0Ł\0Relationship \'FK_cotizacion_sucursal\' between \'sucursal\' and \'cotizacion\'tal\0\0$\0�\0\0\0\0�\�\0\0\0_\0\0\0�\0\0Controll\�\�\0\0�@\0\0\0l\0�	\0\0\0\0�\�\0\0\0b\0\0\0�\0\0A\0\0�Controll�\�\0\0A~\0Relationship \'FK_compra_sucursal\' between \'sucursal\' and \'compra\'n\'i\0\0$\0�\0\0\0\0�\�\0\0\0W\0\0\0�\0\0Controll\��\0\0�\�\0\0\0l\0�	\0\0\0\0�\�\0\0\0b\0\0\0�\0\0C\0\0�Controll�\�\0\0�\0Relationship \'FK_pedidos_sucursal\' between \'sucursal\' and \'pedidos\'i\0\0$\0�\0\0\0\0�\�\0\0\0Y\0\0\0�\0\0Controll�\�\0\0w\n\0\0\0p\0�	\0\0\0\0�\�\0\0\0b\0\0\0�\0\0E\0\0�Controll5�\0\0^\0Relationship \'FK_empleado_sucursal\' between \'sucursal\' and \'empleado\'n\'\0\0\0$\0�\0\0\0\0�\�\0\0\0[\0\0\0�\0\0Controll\�\0\0\0�\0\0\0l\0�	\0\0\0\0�\�\0\0\0b\0\0\0�\0\0A\0\0�Controll�\�\0\0|\0Relationship \'FK_nomina_sucursal\' between \'sucursal\' and \'nomina\'ado\0\0$\0�\0\0\0\0�\�\0\0\0W\0\0\0�\0\0Controll(�\0\0��\0\0\0l\0�	\0\0\0\0��\0\0\0b\0\0\0�\0\0D\0\0�Controll5\�\0\0\�\0Relationship \'FK_sucursal_empresa1\' between \'empresa\' and \'sucursal\'\0\0$\0�\0\0\0\0��\0\0\0[\0\0\0�\0\0Controll�\�\0\0[�\0\0\0l\0�	\0\0\0\0��\0\0\0b\0\0\0�\0\0C\0\0�Controlly�\0\0\�\0Relationship \'FK_almacen_sucursal\' between \'sucursal\' and \'almacen\'\'\0\0$\0�\0\0\0\0��\0\0\0Y\0\0\0�\0\0Controll\�\0\0�\0\0\0x\0�	\0\0\0\0��\0\0\0R\0\0\0�\0\0M\0\0�Controll{\�\0\0A~\0Relationship \'FK_departamento_sucursal\' between \'sucursal\' and \'departamento\'e\'\0\0\0$\0�\0\0\0\0��\0\0\0c\0\0\0�\0\0Controll\�\�\0\0\�}\0\0\0<\0�	\0\0\0\0��\0\0\0�\0\0\0�\0\0\0\0�SchGridlp�\0\0bP\0sucursal_vs_empleado\0\0�\0�	\0\0\0\0��\0\0\0b\0\0\0�\0\0]\0\0�Controllۚ\0\0b\0Relationship \'FK_sucursal_vs_empleado_empleado\' between \'empleado\' and \'sucursal_vs_empleado\'o\'\0\0\0$\0�\0\0\0\0��\0\0\0s\0\0\0�\0\0Controlll\�\0\0�\0\0\0�\0�	\0\0\0\0��\0\0\0b\0\0\0�\0\0]\0\0�Controll�\�\0\0YU\0Relationship \'FK_sucursal_vs_empleado_sucursal\' between \'sucursal\' and \'sucursal_vs_empleado\'o\'\0\0\0$\0�\0\0\0\0��\0\0\0s\0\0\0�\0\0Controll��\0\0`i\0\0\00\0�	\0\0\0\0��\0\0\0�\0\0\0�\0\0\0\0�SchGridlz�\0\�\0suplidor\0\0l\0�	\0\0\0\0��\0\0\0b\0\0\0�\0\0C\0\0�Controlr�y\0\r\0Relationship \'FK_suplidor_persona\' between \'persona\' and \'suplidor\'\'\0\0$\0�\0\0\0\0��\0\0\0Y\0\0\0�\0\0ControlrY}\0G\0\0\0l\0�	\0\0\0\0��\0\0\0b\0\0\0�\0\0A\0\0�ControlrO~\0t�\0Relationship \'FK_compra_suplidor\' between \'suplidor\' and \'compra\'r\'\'\0\0$\0�\0\0\0\0��\0\0\0W\0\0\0�\0\0Controlr��\0��\0\0\08\0�	\0\0\0\0�\0\0�\0\0\0�\0\0\0\0�SchGridr\�\�\0\0��\0\0tarjetas_credito\0\00\0�	\0\0\0\0�\0\0�\0\0\0�\0\0\0\0�SchGridrp\0�=\0terceror\0\0l\0�	\0\0\0\0�\0\0b\0\0\0�\0\0A\0\0�Controlr \0 �\0Relationship \'FK_empresa_tercero\' between \'tercero\' and \'empresa\'r\'\'\0\0$\0�\0\0\0\0�\0\0W\0\0\0�\0\0Controlr\n\0E�\0\0\0x\0�	\0\0\0\0�	\0\0b\0\0\0�\0\0P\0\0�Controlr�\0#?\0Relationship \'FK_identificacion_tercero1\' between \'tercero\' and \'identificacion\'\0\0$\0�\0\0\0\0�\n\0\0g\0\0\0�\0\0Controlr�\0B\0\0\0l\0�	\0\0\0\0�\0\0b\0\0\0�\0\0A\0\0�Controlr�y\0@&\0Relationship \'FK_persona_tercero\' between \'tercero\' and \'persona\'r\'\'\0\0$\0�\0\0\0\0�\0\0W\0\0\0�\0\0Controlr_\0e%\0\0\0l\0�	\0\0\0\0�\r\0\0b\0\0\0�\0\0C\0\0�Controlr��\0\r\0Relationship \'FK_suplidor_tercero\' between \'tercero\' and \'suplidor\'\'\0\0$\0�\0\0\0\0�\0\0Y\0\0\0�\0\0Controlr\"\n\03\0\0\0h\0�	\0\0\0\0�\0\0Z\0\0\0�\0\0=\0\0�Controlr�Q\0�J\0Relationship \'FK_banco_tercero\' between \'tercero\' and \'banco\'o\'\0\0\0$\0�\0\0\0\0�\0\0S\0\0\0�\0\0Controlr\�U\0OJ\0\0\0@\0�	\0\0\0\0�\0\0�\0\0\0�\0\0\0\0�SchGridr\�O\0�2\0tercero_observacionesles\0\0�\0�	\0\0\0\0�\0\0b\0\0\0�\0\0]\0\0�Controlr\�e\0�:\0Relationship \'FK_tercero_observaciones_tercero\' between \'tercero\' and \'tercero_observaciones\'o\'\0\0\0$\0�\0\0\0\0�\0\0s\0\0\0�\0\0Controlr�k\0\�\0\0\0<\0�	\0\0\0\0�\0\0�\0\0\0�\0\0\0\0�SchGridr�.\0\�\0tercero_vs_direccion\0\0�\0�	\0\0\0\0�\0\0R\0\0\0�\0\0_\0\0�Controlr9\0�\r\0Relationship \'FK_tercero_vs_direccion_direccion\' between \'direccion\' and \'tercero_vs_direccion\'\0\0\0$\0�\0\0\0\0�\0\0u\0\0\0�\0\0ControlrR\'\0�\0\0\0�\0�	\0\0\0\0�\0\0b\0\0\0�\0\0[\0\0�ControlrE\0 \0Relationship \'FK_tercero_vs_direccion_tercero\' between \'tercero\' and \'tercero_vs_direccion\'i\0\0$\0�\0\0\0\0�\0\0q\0\0\0�\0\0Controlril\05�\0\0\08\0�	\0\0\0\0�\0\0�\0\0\0�\0\0\0\0�SchGridr֐\0b�\0tercero_vs_email\0\0|\0�	\0\0\0\0�\Z\0\0b\0\0\0�\0\0S\0\0�Controlr�z\0�\�\0Relationship \'FK_tercero_vs_email_tercero\' between \'tercero\' and \'tercero_vs_email\'a\0\0$\0�\0\0\0\0�\0\0i\0\0\0�\0\0Controlr}\0\�M\0\0\0<\0�	\0\0\0\0�\0\0�\0\0\0�\0\0\0\0�SchGridr6O\0\n�\0tercero_vs_permisoon\0\0�\0�	\0\0\0\0�\0\0R\0\0\0�\0\0W\0\0�ControlrWY\0��\0Relationship \'FK_tercero_vs_permiso_permiso\' between \'permiso\' and \'tercero_vs_permiso\'\'\0\0$\0�\0\0\0\0�\0\0m\0\0\0�\0\0Controlr�H\0ϲ\0\0\0�\0�	\0\0\0\0�\0\0b\0\0\0�\0\0W\0\0�ControlrsY\0�\�\0Relationship \'FK_tercero_vs_permiso_tercero\' between \'tercero\' and \'tercero_vs_permiso\'\'\0\0$\0�\0\0\0\0� \0\0m\0\0\0�\0\0ControlrA{\0�!\0\0\0<\0�	\0\0\0\0�!\0\0�\0\0\0�\0\0\0\0�SchGridr֐\0 U\0tercero_vs_telefonon\0\0�\0�	\0\0\0\0�\"\0\0b\0\0\0�\0\0Y\0\0�Controlr�\0MD\0Relationship \'FK_tervero_vs_telefono_tercero\' between \'tercero\' and \'tercero_vs_telefono\'n\'i\0\0$\0�\0\0\0\0�#\0\0o\0\0\0�\0\0Controlr\�x\0dW\0\0\0@\0�	\0\0\0\0�$\0\0�\0\0\0�\0\0\0\0�SchGridrrQ\0\0\�\0\0tipo_comprobante_fiscals\0\0�\0�	\0\0\0\0�%\0\0b\0\0\0�\0\0w\0\0�Controlr�[\0\0��\0\0Relationship \'FK_comprobante_fiscal_tipo_comprobante_fiscal\' between \'tipo_comprobante_fiscal\' and \'comprobante_fiscal\'\0\0\0$\0�\0\0\0\0�&\0\0�\0\0\0�\0\0ControlrB\0\0�\Z\0\0\0�\0�	\0\0\0\0�\'\0\0b\0\0\0�\0\0w\0\0�Controlr�g\0\0\r�\0\0Relationship \'FK_comprobante_ventas_tipo_comprobante_fiscal\' between \'tipo_comprobante_fiscal\' and \'comprobante_ventas\'\0\0\0$\0�\0\0\0\0�(\0\0�\0\0\0�\0\0Controlr2q\0\0E\�\0\0\0\0<\0�	\0\0\0\0�)\0\0�\0\0\0�\0\0\0\0�SchGridr\�\0\0H?\0\0tipo_cuenta_bancaria\0\0�\0�	\0\0\0\0�*\0\0R\0\0\0�\0\0k\0\0�Controlr)�\0\0}I\0\0Relationship \'FK_cuenta_bancaria_tipo_cuenta_bancaria\' between \'tipo_cuenta_bancaria\' and \'cuenta_bancaria\'s\0\0$\0�\0\0\0\0�+\0\0�\0\0\0�\0\0Controlr�\�\0\0EP\0\0\0\0<\0�	\0\0\0\0�,\0\0�\0\0\0�\0\0\0\0�SchGridr��\0~$\0tipo_identificaciona\0\0�\0�	\0\0\0\0�-\0\0R\0\0\0�\0\0g\0\0�Controlr��\0�.\0Relationship \'FK_identificacion_tipo_identificacion\' between \'tipo_identificacion\' and \'identificacion\'\0\0\0$\0�\0\0\0\0�.\0\0}\0\0\0�\0\0Controlr�\0�4\0\0\0D\0�	\0\0\0\0�/\0\0\�\0\0\0�\0\0\Z\0\0�SchGridr\�\�\0\0@\�\0tipo_movimiento_inventariota\0\0@\0�	\0\0\0\0�0\0\0\�\0\0\0�\0\0\0\0�SchGridr\�\0\0J\�\0transferencia_inventario\0\0�\0�	\0\0\0\0�1\0\0b\0\0\0�\0\0m\0\0�Controlr\�6\0\0s\0Relationship \'FK_historial_movimientos_inventario_producto\' between \'producto\' and \'transferencia_inventario\'s\'\0\0\0$\0�\0\0\0\0�2\0\0�\0\0\0�\0\0Controlr\0\0�r\0\0\0�\0�	\0\0\0\0�3\0\0b\0\0\0�\0\0k\0\0�ControlrQ�\0\0��\0Relationship \'FK_historial_movimientos_inventario_almacen\' between \'almacen\' and \'transferencia_inventario\'o\0\0$\0�\0\0\0\0�4\0\0�\0\0\0�\0\0ControlrJ�\0\0\�\0\0\0�\0�	\0\0\0\0�5\0\0b\0\0\0�\0\0l\0\0�ControlrQ�\0\0K�\0Relationship \'FK_historial_movimientos_inventario_almacen1\' between \'almacen\' and \'transferencia_inventario\'\0\0$\0�\0\0\0\0�6\0\0�\0\0\0�\0\0Controlr\�\0\0�\�\0\0\0�\0�	\0\0\0\0�7\0\0b\0\0\0�\0\0e\0\0�Controlr\�\�\0\0\�\0Relationship \'FK_transferencia_inventario_sucursal\' between \'sucursal\' and \'transferencia_inventario\'n\'\0\0\0$\0�\0\0\0\0�8\0\0{\0\0\0�\0\0Controlr�\�\0\0[�\0\0\0�\0�	\0\0\0\0�9\0\0b\0\0\0�\0\0f\0\0�Controlr\�\0\0\�\0Relationship \'FK_transferencia_inventario_sucursal1\' between \'sucursal\' and \'transferencia_inventario\'\'\0\0\0$\0�\0\0\0\0�:\0\0}\0\0\0�\0\0Controlre\�\0\0��\0\0\0�\0�	\0\0\0\0�;\0\0R\0\0\0�\0\0�\0\0�Controlr!\�\0\0\�\0Relationship \'FK_historial_movimientos_inventario_tipo_movimiento_inventario\' between \'tipo_movimiento_inventario\' and \'transferencia_inventario\'\0\0\0\0\0$\0�\0\0\0\0�<\0\0�\0\0\0�\0\0Controlr�\�\0\0�\�\0\0\00\0�	\0\0\0\0�=\0\0�\0\0\0�\0\0\0\0�SchGridr\�x\0@E\0unidaddr\0\0x\0�	\0\0\0\0�>\0\0b\0\0\0�\0\0M\0\0�Controlr5\0\�(\0Relationship \'FK_pedido_detalle_unidad\' between \'unidad\' and \'pedido_detalle\'on\'\0\0$\0�\0\0\0\0�?\0\0c\0\0\0�\0\0Controlr�\'\0�\0\0\0�\0�	\0\0\0\0�@\0\0b\0\0\0�\0\0g\0\0�ControlrE=\0(\0Relationship \'FK_historial_devolucion_ventas_unidad\' between \'unidad\' and \'historial_devolucion_ventas\'\0\0\0$\0�\0\0\0\0�A\0\0}\0\0\0�\0\0Controlr\�(\0q\�\0\0\0�\0�	\0\0\0\0�D\0\0b\0\0\0�\0\0i\0\0�Controlrn\0\�K\0Relationship \'FK_historial_inventario_agotado_unidad\' between \'unidad\' and \'historial_inventario_agotado\'io\'\0\0$\0�\0\0\0\0�E\0\0\0\0\0�\0\0Controlr:[\0R\0\0\0�\0�	\0\0\0\0�F\0\0b\0\0\0�\0\0i\0\0�Controlr\�\0\0�h\0Relationship \'FK_historial_devolucion_compras_unidad\' between \'unidad\' and \'historial_devolucion_compras\'io\'\0\0$\0�\0\0\0\0�G\0\0\0\0\0�\0\0Controlr��\0\0R)\0\0\0�\0�	\0\0\0\0�H\0\0b\0\0\0�\0\0Y\0\0�ControlrM�\0�Q\0Relationship \'FK_producto_codigobarra_unidad\' between \'unidad\' and \'producto_codigobarra\'n\'i\0\0$\0�\0\0\0\0�I\0\0o\0\0\0�\0\0Controlr�p\0�o\0\0\0x\0�	\0\0\0\0�J\0\0b\0\0\0�\0\0O\0\0�Controlr\�N\0]\'\0Relationship \'FK_factura_detalle_unidad\' between \'unidad\' and \'factura_detalle\'\'\0\0$\0�\0\0\0\0�K\0\0e\0\0\0�\0\0ControlrA\0~\0\0\0p\0�	\0\0\0\0�L\0\0b\0\0\0�\0\0E\0\0�ControlrUj\0\0֋\0Relationship \'FK_inventario_unidad\' between \'unidad\' and \'inventario\'n\'\0\0\0$\0�\0\0\0\0�M\0\0[\0\0\0�\0\0Controlr³\0\0*\0\0\0�\0�	\0\0\0\0�N\0\0b\0\0\0�\0\0W\0\0�Controlr\�U\0�&\0Relationship \'FK_cotizacion_detalles_unidad\' between \'unidad\' and \'cotizacion_detalles\'\'\0\0$\0�\0\0\0\0�O\0\0m\0\0\0�\0\0Controlr;F\0�\�\0\0\0x\0�	\0\0\0\0�P\0\0b\0\0\0�\0\0O\0\0�Controlr/b\0�Q\0Relationship \'FK_producto_unidad_unidad\' between \'unidad\' and \'producto_unidad\'\'\0\0$\0�\0\0\0\0�Q\0\0e\0\0\0�\0\0Controlr�o\0p\0\0\0�\0�	\0\0\0\0�R\0\0b\0\0\0�\0\0i\0\0�ControlrI\�\0\0y)\0Relationship \'FK_historial_movimientos_inventario_unidad\' between \'unidad\' and \'transferencia_inventario\'io\'\0\0$\0�\0\0\0\0�S\0\0�\0\0\0�\0\0Controlr_\�\0\0�(\0\0\0�\0�	\0\0\0\0�T\0\0b\0\0\0�\0\0c\0\0�Controlrn\0�;\0Relationship \'FK_entrada_salida_inventario_unidad\' between \'unidad\' and \'entrada_salida_inventario\'t\0\0$\0�\0\0\0\0�U\0\0y\0\0\0�\0\0Controlr�\\\0gG\0\0\00\0�	\0\0\0\0�V\0\0�\0\0\0�\0\0\0\0�SchGridr`a\0\\d\0vendedor\0\0l\0�	\0\0\0\0�W\0\0R\0\0\0�\0\0C\0\0�Controlro\0`J\0Relationship \'FK_vendedor_tercero\' between \'tercero\' and \'vendedor\'o\0\0$\0�\0\0\0\0�X\0\0Y\0\0\0�\0\0Controlrd\0yX\0\0\08\0�	\0\0\0\0�Y\0\0�\0\0\0�\0\0\0\0�SchGridrv\�\0\0R\0venta_vs_pagosil\0\0|\0�	\0\0\0\0�Z\0\0b\0\0\0�\0\0Q\0\0�ControlrW�\0\0b\0Relationship \'FK_venta_vs_pagos_empleado\' between \'empleado\' and \'venta_vs_pagos\'all\0\0$\0�\0\0\0\0�[\0\0g\0\0\0�\0\0ControlrC�\0\0�O\0\0\0�\0�	\0\0\0\0�\\\0\0b\0\0\0�\0\0c\0\0�Controlr\�4\0\0�G\0\0Relationship \'FK_oferta_producto_detalle_producto\' between \'producto\' and \'oferta_producto_detalle\'t\0\0$\0�\0\0\0\0�]\0\0y\0\0\0�\0\0Controlr[�\0\0e\�\0\0\0\00\0�	\0\0\0\0�^\0\0�\0\0\0�\0\0\0\0�SchGridr�\�\0\0�\0\0modelodr\0\0h\0�	\0\0\0\0�_\0\0R\0\0\0�\0\0=\0\0�Controlrs\�\0\0=\0\0Relationship \'FK_modelo_marcas\' between \'marcas\' and \'modelo\'o\'\0\0\0$\0�\0\0\0\0�`\0\0S\0\0\0�\0\0Controlr�\�\0\0\0\0\0\0@\0�	\0\0\0\0�c\0\0�\0\0\0�\0\0\0\0�SchGridrP�\0\0\0\0inventario_reparacionrio\0\0�\0�	\0\0\0\0�e\0\0R\0\0\0�\0\0[\0\0�Controlre�\0\0�	\0\0Relationship \'FK_inventario_reparacion_marcas\' between \'marcas\' and \'inventario_reparacion\'i\0\0$\0�\0\0\0\0�f\0\0q\0\0\0�\0\0Controlrð\0\0	\0\0\0\0�\0�	\0\0\0\0�g\0\0b\0\0\0�\0\0s\0\0�Controlre�\0\0�/\0\0Relationship \'FK_inventario_reparacion_estados_reparacion\' between \'estados_reparacion\' and \'inventario_reparacion\'t\0\0$\0�\0\0\0\0�h\0\0�\0\0\0�\0\0Controlrq�\0\0\�1\0\0\0\0�\0�	\0\0\0\0�i\0\0b\0\0\0�\0\0_\0\0�ControlrQ4\0\0�.\0\0Relationship \'FK_inventario_reparacion_producto\' between \'producto\' and \'inventario_reparacion\'\0\0\0$\0�\0\0\0\0�j\0\0u\0\0\0�\0\0Controlr\�]\0\0\�\0\0\0\0�\0�	\0\0\0\0�k\0\0b\0\0\0�\0\0[\0\0�Controlr�\0\0�.\0\0Relationship \'FK_inventario_reparacion_unidad\' between \'unidad\' and \'inventario_reparacion\'i\0\0$\0�\0\0\0\0�l\0\0q\0\0\0�\0\0ControlrZ\0u9\0\0\0�\0�	\0\0\0\0�m\0\0b\0\0\0�\0\0i\0\0�Controlr}5\0\0?o\0\0Relationship \'FK_producto_unidad_conversion_producto\' between \'producto\' and \'producto_unidad_conversion\'io\'\0\0$\0�\0\0\0\0�n\0\0\0\0\0�\0\0ControlrIt\0\0)\�\0\0\0\0�\0�	\0\0\0\0�o\0\0b\0\0\0�\0\0e\0\0�Controlr\�\0\0?o\0\0Relationship \'FK_producto_unidad_conversion_unidad\' between \'unidad\' and \'producto_unidad_conversion\'s\'\0\0\0$\0�\0\0\0\0�p\0\0{\0\0\0�\0\0Controlr�\"\0�Y\0\0\08\0�	\0\0\0\0�q\0\0�\0\0\0�\0\0\r\0\0�SchGridr\�^\0\0\��\0\0ingresos_cajasil\0\0<\0�	\0\0\0\0�r\0\0�\0\0\0�\0\0\0\0�SchGridr:\0\0f\0ingresos_conceptosio\0\0<\0�	\0\0\0\0�s\0\0�\0\0\0�\0\0\0\0�SchGridr��\0\0�\�\0\0sistema_historialsio\0\0t\0�	\0\0\0\0�t\0\0R\0\0\0�\0\0K\0\0�ControlrAq\0\0��\0\0Relationship \'FK_ingresos_caja_cajero\' between \'cajero\' and \'ingresos_caja\'d\0\0$\0�\0\0\0\0�u\0\0a\0\0\0�\0\0Controlr�d\0\0�\0\0\0\0�\0�	\0\0\0\0�v\0\0b\0\0\0�\0\0c\0\0�Controlr{F\0\0��\0\0Relationship \'FK_ingresos_caja_ingresos_conceptos\' between \'ingresos_conceptos\' and \'ingresos_caja\'n\0\0$\0�\0\0\0\0�w\0\0y\0\0\0�\0\0Controlr�L\0\0��\0\0\0\08\0�	\0\0\0\0�x\0\0�\0\0\0�\0\0\0\0�SchGridr\�B\0\0\n\0catalogo_cuentas\0\0<\0�	\0\0\0\0�y\0\0�\0\0\0�\0\0\0\0�SchGridr��\0\0�!\0correo_electronicoso\0\0H\0�	\0\0\0\0�z\0\0\�\0\0\0�\0\0\0\0�SchGridr\0\0A\0producto_productos_requisitosle\0\0\0@\0�	\0\0\0\0�{\0\0�\0\0\0�\0\0\0\0�SchGridrrQ\0\0J\0sistema_modulo_opcioneso\0\08\0�	\0\0\0\0�|\0\0�\0\0\0�\0\0\0\0�SchGridr\� \0\0dL\0sistema_moduloss\0\08\0�	\0\0\0\0�}\0\0�\0\0\0�\0\0\0\0�SchGridr g\0\0X\0suplidores_dgiis\0\0�\0�	\0\0\0\0�~\0\0R\0\0\0�\0\0q\0\0�ControlrV>\0\0}O\0Relationship \'FK_sistema_modulo_opciones_sistema_modulos\' between \'sistema_modulos\' and \'sistema_modulo_opciones\'n\'t\0\0$\0�\0\0\0\0�\0\0�\0\0\0�\0\0Controlr�;\0\0\�Q\0\0\0�\0�	\0\0\0\0��\0\0R\0\0\0�\0\0o\0\0�Controlr\�\0\0�O\0Relationship \'FK_producto_productos_requisitos_producto\' between \'producto\' and \'producto_productos_requisitos\'\0\0\0$\0�\0\0\0\0��\0\0�\0\0\0�\0\0Controlr\"\0\0&X\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0\�\0\0\0\�\0\0\0\�\0\0\0\�\0\0\0\�\0\0\0\�\0\0\0\�\0\0\0\�\0\0\0\�\0\0\0\�\0\0\0\�\0\0\0\�\0\0\0\�\0\0\0\�\0\0\0\�\0\0\0\�\0\0\0\�\0\0\0\�\0\0\0\�\0\0\0\�\0\0\0\�\0\0\0\�\0\0\0\�\0\0\0\�\0\0\0\�\0\0\0\�\0\0\0\�\0\0\0\�\0\0\0\�\0\0\0\�\0\0\0\�\0\0\0\�\0\0\0\�\0\0\0\�\0\0\0\�\0\0\0\�\0\0\0\�\0\0\0\�\0\0\0\�\0\0\0\�\0\0\0\�\0\0\0\�\0\0\0\�\0\0\0\�\0\0\0\�\0\0\0\�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0����!C4\0\0\0A\0\0g\0\0xV4\0\0\0\0\0a\0l\0m\0a\0c\0e\0n\0\0\0\n\0\0\0/P\0\0\0\0/P\0�R\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\\�Td^�T\\]�THk�Td^�T]�Te\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0I\0\0h\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0I\0\0p\0\0\0\0\0\0\0\0\0\0\0�����\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\09\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0g\0\0�\0\0\�\0\0�\0\0+\0\0�\0\0�\0\0*\0\0\0\0\0\0\0\0\0A\0\0g\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\n\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0X\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0a\0l\0m\0a\0c\0e\0n\0\0\0!C4\0\0\0A\0\0q\n\0\0xV4\0\0\0\0\0b\0a\0n\0c\0o\0\0\0\�P\0\0\0 \�\�\0\0\0\0 \�\�0$;\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0d^�T,��T\�%2Ut`�`�`�`�`�`�`\�`\�`\�`\�`�````(`4`@`L`X`d`p`|`�`�`�`�`�`\�`\�`\�`\�`�`\0```$`0`<`H\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\09\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0Z\0\0\0i\0\0\0K\0\0\0\�\0\0�\0\0\0Z\0\0\0�\0\0\0\�\0\0\0�\0\0\0\0\0\0\0\0\0\0A\0\0q\n\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\04\0\0\0\0\0\0\0\0\0�\0\0N\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0T\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0b\0a\0n\0c\0o\0\0\0!C4\0\0\0A\0\0\�\0\0xV4\0\0\0\0\0c\0a\0j\0a\0\0\0#��7	\0\0\0��P\0\0\0\0��P@�P\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\\�Td^�T\\]�THk�T�\�\�\�\��T(k�THk�Td\�\�\�\��T(k�THk�Td^�T]�T`\0@\0p\0p\00\00\0`\00\0�\0p\0p\0p\0p\0@\0P\0@\0p\0`\0�\0P\0`\0P\0�\0p\0�\0�\0`\0`\0�\0�\00\0@\0p\0`\0�\0�\0�\0p\0�\0p\0`\0p\0�\0p\0�\0p\0p\0p\0������������������\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\09\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0�\0\0�\0\0\�\0\0�\0\0H\0\0�\0\0�\0\0�\0\0\0\0\0\0\0\0\0A\0\0\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\n\0\0\0\0\0\0\0\0\0�\0\0N\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0R\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0c\0a\0j\0a\0\0\0!C4\0\0\0A\0\0g\0\0xV4\0\0\0\0\0c\0a\0j\0e\0r\0o\0\0\0��f\0t\0�#5\n��}S\0|S�\0X��S�^�S\0\0\0�#5\n����e\0n\0�]a<D\0\0��\0\0�\0\0\0�#5\n��}S\0|S�\0\�ݺS\�T�S\0\0\0�#5\n����.\0M\0�#5\n��}S\0|S�\0���S\�T�S\0\0\0�#5\n����\0\0\0\0�#5\n��}S\0|S�\0޺S\�T�S\0\0\0�#5\n����\0\0\0\0�#5\n��}S\0|S�\0F޺S�T�S\0\0\0�#5\n����\0\0\0\0�]\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\09\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0�\0\0�\0\0\�\0\0�\0\0H\0\0�\0\0�\0\0�\0\0\0\0\0\0\0\0\0A\0\0g\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\n\0\0\0\0\0\0\0\0\0�\0\0\�\n\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0V\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0c\0a\0j\0e\0r\0o\0\0\0\0\0�}\0\0�\�\0\0�}\0\0\�\0\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�t\0\0\�\0\0V\0\0X\0\04\0\0\0\0\0\0\0V\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0c\0a\0j\0e\0r\0o\0_\0c\0a\0j\0a\0!C4\0\0\0A\0\0\�\0\0xV4\0\0\0\0\0c\0a\0r\0g\0o\0\0\0\0\0\0�#5\n����\���#5\n\��}S\0|S�\0DߺSU�S\0\0\0�#5\n����$�W?^\\a<\0\0\0�\�\0\0�\0\0\0�#5\n\��}S\0|S�\0�ߺS	U�S\0\0\0�#5\n�����w�=�#5\n\��}S\0|S�\0\�ߺS	U�S\0\0\0�#5\n����\0\0\0\0�#5\n��}S\0|S�\0\0\�SU�S\0\0\0�#5\n����\0\0\0\0�#5\n��}S\0|S�\0;\�S,]�S\0\0\0�#5\n��\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\09\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0�\0\0�\0\0\�\0\0�\0\0H\0\0�\0\0�\0\0�\0\0\0\0\0\0\0\0\0A\0\0\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0N\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0T\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0c\0a\0r\0g\0o\0\0\0!C4\0\0\0A\0\0\�\0\0xV4\0\0\0\0\0c\0a\0t\0e\0g\0o\0r\0i\0a\0_\0p\0r\0o\0d\0u\0c\0t\0o\0\0\0�T�`�T�`�TP\�P\�\�\�\�\�\�\�\�\��\��\��\��\�\0	\�\0	\�	\�	\�	\�	\�	\�	\� 	\� 	\�(	\�(	\�X\�X\�`\�`\�H	\�H	\�P	\�P	\�h\�h\�l	\�l	\�t	\�t	\�p\�p\�x\�x\��	\��	\��	\��	\��	\��	\��	\��	\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\09\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0g\0\0�\0\0\�\0\0�\0\0+\0\0�\0\0�\0\0*\0\0\0\0\0\0\0\0\0A\0\0\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\n\0\0\0\0\0\0\0\0\0�\0\0N\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0n\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0c\0a\0t\0e\0g\0o\0r\0i\0a\0_\0p\0r\0o\0d\0u\0c\0t\0o\0\0\0!C4\0\0\0A\0\0\�\0\0xV4\0\0\0\0\0c\0l\0i\0e\0n\0t\0e\0\0\0\0\0�c�}<��\0�`\0�P\0\0\0\0\0\0\0\0�\n*\n/O/O\0\0\0\0\0\0PA\0\0\0\0\�4P�P�*\n\�\�\n\�\�\n\0\0\0\0\0\0\0\0\�0O\�0O\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\0\�\Z\0\0\0\0\0\0-\0\0	\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0Z\0\0\0i\0\0\0K\0\0\0\�\0\0�\0\0\0Z\0\0\0�\0\0\0\�\0\0\0�\0\0\0\0\0\0\0\0\0\0A\0\0\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0\0\0\0\0\0�\0\0\�\n\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0X\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0c\0l\0i\0e\0n\0t\0e\0\0\0!C4\0\0\0A\0\0\�\0\0xV4\0\0\0\0\0c\0l\0i\0e\0n\0t\0e\0_\0c\0a\0t\0e\0g\0o\0r\0i\0a\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0X\�:\0\0\0\0�0\0\0\02\0\0\0\0\0\0\0\0\0\0\0\0\0\0��}<\0\0\0�\�\0�P\0\0\0\0\0\0\0\0�\n*\nt3O|3O\0\0\0\0\0\08C\0\0\0\0\0>CP�P�*\n\�\�\n\�\�\n\0\0\0\0\0\0\0\045O45O\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\09\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0Z\0\0\0i\0\0\0K\0\0\0\�\0\0�\0\0\0Z\0\0\0�\0\0\0\�\0\0\0�\0\0\0\0\0\0\0\0\0\0A\0\0\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\04\0\0\0\0\0\0\0\0\0�\0\0N\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0l\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0c\0l\0i\0e\0n\0t\0e\0_\0c\0a\0t\0e\0g\0o\0r\0i\0a\0\0\0\0\0.�\0<\�\0.�\0\�\0\�x\0\�\0\�x\00�\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0=j\0\�\�\0o\0\0X\0\01\0\0\0\0\0\0\0o\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0c\0l\0i\0e\0n\0t\0e\0_\0c\0l\0i\0e\0n\0t\0e\0_\0c\0a\0t\0e\0g\0o\0r\0i\0a\0!C4\0\0\0A\0\0g\0\0xV4\0\0\0\0\0c\0l\0i\0e\0n\0t\0e\0_\0s\0u\0b\0c\0a\0t\0e\0g\0o\0r\0i\0a\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0X\�:\0\0\0\0�0\0\0\07\0\0\0\0\0\0\0\0\0\0\0\0\0iC��}<\0\0\0��P\0\0\0\0\0\0\0\0�\n*\n\�4O�4O\0\0\0\0\0\0oC\0\0\0\0\0\0\0P�P�*\n\�\�\n\�\�\n\0\0\0\0\0\0\0\0�6O�6O\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\09\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0Z\0\0\0i\0\0\0K\0\0\0\�\0\0�\0\0\0Z\0\0\0�\0\0\0\�\0\0\0�\0\0\0\0\0\0\0\0\0\0A\0\0g\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0r\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0c\0l\0i\0e\0n\0t\0e\0_\0s\0u\0b\0c\0a\0t\0e\0g\0o\0r\0i\0a\0\0\0\0\0v�\0�\�\0\�\0�\�\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\'�\0�\�\0\0\0X\0\0:\0\0\0\0\0\0\0\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma)\0F\0K\0_\0c\0l\0i\0e\0n\0t\0e\0_\0s\0u\0b\0c\0a\0t\0e\0g\0o\0r\0i\0a\0_\0c\0l\0i\0e\0n\0t\0e\0_\0c\0a\0t\0e\0g\0o\0r\0i\0a\0\0\0^�\0\�\0^�\0\�\�\0\0w\0\�\�\0\0w\00�\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�d\0\�\0Y\0\0X\0\0/\0\0\0\0\0\0\0Y\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0c\0l\0i\0e\0n\0t\0e\0_\0c\0l\0i\0e\0n\0t\0e\0_\0s\0u\0b\0c\0a\0t\0e\0g\0o\0r\0i\0a\0!C4\0\0\0A\0\0g\0\0xV4\0\0\0\0\0c\0o\0m\0b\0o\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0X\�:\0\0\0\0�0\0\0\0<\0\0\0\0\0\0\0�C\0\0@A\0\0PA��}<�W\0�K�P\0\0\0\0\0\0\0\0�\n*\nd6Ol6O\0\0\0\0\0\0\0\0\0\0\0\08OP�P�*\n\�\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\09\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0g\0\0�\0\0\�\0\0�\0\0+\0\0�\0\0�\0\0*\0\0\0\0\0\0\0\0\0A\0\0g\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\n\0\0\0\0\0\0\0\0\0�\0\0N\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0T\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0c\0o\0m\0b\0o\0\0\0!C4\0\0\0A\0\05(\0\0xV4\0\0\0\0\0c\0o\0m\0p\0r\0a\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\0\�#\0\0\0\0\0\0-\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0g\0\0�\0\0\�\0\0�\0\0+\0\0�\0\0�\0\0*\0\0\0\0\0\0\0\0\0A\0\05(\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\�\n\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0V\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0c\0o\0m\0p\0r\0a\0\0\0!C4\0\0\0A\0\0\�\0\0xV4\0\0\0\0\0c\0o\0m\0p\0r\0a\0_\0d\0e\0t\0a\0l\0l\0e\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\0Q\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0g\0\0�\0\0\�\0\0�\0\0+\0\0�\0\0�\0\0*\0\0\0\0\0\0\0\0\0A\0\0\�\0\0\0\0\0\0	\0\0\0	\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0N\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0f\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0c\0o\0m\0p\0r\0a\0_\0d\0e\0t\0a\0l\0l\0e\0\0\0!C4\0\0\0A\0\0]\0\0xV4\0\0\0\0\0c\0o\0m\0p\0r\0a\0_\0p\0a\0g\0o\0_\0a\0n\0u\0l\0a\0d\0o\0s\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\0\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0g\0\0�\0\0\�\0\0�\0\0+\0\0�\0\0�\0\0*\0\0\0\0\0\0\0\0\0A\0\0]\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0r\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0c\0o\0m\0p\0r\0a\0_\0p\0a\0g\0o\0_\0a\0n\0u\0l\0a\0d\0o\0s\0\0\0\0\0\�\0�\�\0\�\0\�\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\Z\0\0\0\0\0\0\0y�\0\�\�\0|\0\0X\0\02\0\0\0\0\0\0\0|\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0c\0o\0m\0p\0r\0a\0_\0p\0a\0g\0o\0_\0a\0n\0u\0l\0a\0d\0o\0s\0_\0c\0o\0m\0p\0r\0a\0!C4\0\0\0A\0\05(\0\0xV4\0\0\0\0\0c\0o\0m\0p\0r\0a\0_\0v\0s\0_\0p\0a\0g\0o\0s\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\0\�#\0\0\0\0\0\0-\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0g\0\0�\0\0\�\0\0�\0\0+\0\0�\0\0�\0\0*\0\0\0\0\0\0\0\0\0A\0\05(\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\n\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0h\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0c\0o\0m\0p\0r\0a\0_\0v\0s\0_\0p\0a\0g\0o\0s\0\0\0\0\0S�\0\�\�\0\�\0\�\�\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0�\�\0r\0\0X\0\01\0\0\0\0\0\0\0r\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0c\0o\0m\0p\0r\0a\0_\0v\0s\0_\0p\0a\0g\0o\0s\0_\0c\0o\0m\0p\0r\0a\0!C4\0\0\0A\0\0\�\0\0xV4\0\0\0\0\0c\0o\0m\0p\0r\0o\0b\0a\0n\0t\0e\0_\0f\0i\0s\0c\0a\0l\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\0Q\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0g\0\0�\0\0\�\0\0�\0\0+\0\0�\0\0�\0\0*\0\0\0\0\0\0\0\0\0A\0\0\�\0\0\0\0\0\0	\0\0\0	\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\�\n\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0n\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0c\0o\0m\0p\0r\0o\0b\0a\0n\0t\0e\0_\0f\0i\0s\0c\0a\0l\0\0\0!C4\0\0\0A\0\0g\0\0xV4\0\0\0\0\0c\0o\0m\0p\0r\0o\0b\0a\0n\0t\0e\0_\0s\0e\0r\0i\0e\0\0\06\0_\0n\0a\0m\0e\0(\0t\0b\0l\0.\0p\0�\nm<n\0\0�:\0p\0a\0l\0_\0i\0d\0)\0 \0a\0s\0 \0�\nm<r\0\0�>\0t\0O\0w\0n\0e\0r\0,\0 \0t\0b\0l\0�\nm<s\0\0�B\0e\0p\0l\0i\0c\0a\0t\0e\0d\0,\0 \0�\nm<l\0\0�F\0o\0c\0k\0_\0e\0s\0c\0a\0l\0a\0t\0�\nm<n\0\0�J\0e\0s\0c\0,\0 \0C\0A\0S\0T\0(\0c\0�\nm<e\0\0�N\0h\0e\0n\0 \0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\09\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0g\0\0�\0\0\�\0\0�\0\0+\0\0�\0\0�\0\0*\0\0\0\0\0\0\0\0\0A\0\0g\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\n\0\0\0\0\0\0\0\0\0�\0\0N\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0l\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0c\0o\0m\0p\0r\0o\0b\0a\0n\0t\0e\0_\0s\0e\0r\0i\0e\0\0\0\0\0KX\0\0<;\0\�a\0\0<;\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0!\0\0\0\0\0\0\0MQ\0\0\�;\0�\0\0X\0\02\0\0\0\0\0\0\0�\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\'\0F\0K\0_\0c\0o\0m\0p\0r\0o\0b\0a\0n\0t\0e\0_\0f\0i\0s\0c\0a\0l\0_\0c\0o\0m\0p\0r\0o\0b\0a\0n\0t\0e\0_\0s\0e\0r\0i\0e\0!C4\0\0\0A\0\0g\0\0xV4\0\0\0\0\0c\0o\0m\0p\0r\0o\0b\0a\0n\0t\0e\0_\0v\0e\0n\0t\0a\0s\0\0\0m<k\0\0�b\0o\0l\0u\0m\0n\0s\0\0\0\0\0\0\0\0a\0k\nm<d\0\0�f\0n\0,\00\0)\0 \0A\0S\0 \0b\0i\0t\0g\nm< \0\0�j\0S\0E\0 \0W\0H\0E\0N\0 \0\'\0F\0D\0c\nm<d\0\0�n\0b\0l\0.\0t\0y\0p\0e\0 \0T\0H\0E\0\nm<d\0\0�r\0b\0l\0.\0n\0a\0m\0e\0 \0E\0L\0S\0{\nm<N\0\0�v\0 \0E\0N\0D\0 \0A\0S\0 \0[\0F\0i\0w\nm<S\0\0�z\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\09\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0�\0\0�\0\0\�\0\0�\0\0H\0\0�\0\0�\0\0�\0\0\0\0\0\0\0\0\0A\0\0g\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\n\0\0\0\0\0\0\0\0\0�\0\0\�\n\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0n\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0c\0o\0m\0p\0r\0o\0b\0a\0n\0t\0e\0_\0v\0e\0n\0t\0a\0s\0\0\0\0\0�}\0\0\�\0\0�}\0\0Q\�\0\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0$\0\0\0\0\0\0\0�~\0\0Q\�\0\0r\0\0X\0\05\0\0\0\0\0\0\0r\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\Z\0F\0K\0_\0c\0o\0m\0p\0r\0o\0b\0a\0n\0t\0e\0_\0v\0e\0n\0t\0a\0s\0_\0c\0a\0j\0a\0!C4\0\0\0A\0\0\�\0\0xV4\0\0\0\0\0c\0o\0t\0i\0z\0a\0c\0i\0o\0n\0\0\0\'\0 \0E\0N\0D\0 \0A\0S\0 \0[\0F\0C\nm<e\0\0��\0r\0e\0a\0m\0P\0a\0r\0t\0i\0t\0i\0_\nm<S\0\0��\0e\0m\0e\0]\0 \0f\0r\0o\0m\0 \0s\0[\nm<.\0\0��\0b\0l\0e\0s\0 \0t\0b\0l\0 \0l\0e\0W\nm< \0\0��\0t\0e\0r\0 \0j\0o\0i\0n\0 \0s\0y\0S\nm<c\0\0��\0n\0g\0e\0_\0t\0r\0a\0c\0k\0i\0n\0/\nm<t\0\0��\0l\0e\0s\0 \0a\0s\0 \0c\0t\0t\0 \0+\n\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\0\�\Z\0\0\0\0\0\0-\0\0	\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0Z\0\0\0i\0\0\0K\0\0\0\�\0\0�\0\0\0Z\0\0\0�\0\0\0\�\0\0\0�\0\0\0\0\0\0\0\0\0\0A\0\0\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0 \r\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0^\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0c\0o\0t\0i\0z\0a\0c\0i\0o\0n\0\0\0\0\0\�k\0��\0\�d\0��\0\�d\0��\0\�b\0��\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\'\0\0\0\0\0\0\0�X\0 �\0}\0\0X\0\04\0\0\0\0\0\0\0}\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0c\0o\0t\0i\0z\0a\0c\0i\0o\0n\0_\0c\0l\0i\0e\0n\0t\0e\0!C4\0\0\0A\0\0\�\0\0xV4\0\0\0\0\0c\0o\0t\0i\0z\0a\0c\0i\0o\0n\0_\0d\0e\0t\0a\0l\0l\0e\0s\0\0\0p\0.\0d\0a\0t\0a\07\nm<p\0\0��\0e\0_\0i\0d\0 \0=\0 \0t\0b\0l\0.\03\nm<b\0\0��\0a\0t\0a\0_\0s\0p\0a\0c\0e\0_\0i\0\nm<l\0\0�\�\0t\0 \0o\0u\0t\0e\0r\0 \0j\0o\0i\0\nm<(\0\0�\�\0s\0.\0f\0u\0l\0l\0t\0e\0x\0t\0_\0\nm<d\0\0�\�\0e\0s\0 \0f\0t\0i\0 \0i\0n\0n\0e\0\nm<j\0\0�\�\0n\0 \0s\0y\0s\0.\0f\0u\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\0\�\Z\0\0\0\0\0\0-\0\0	\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0Z\0\0\0i\0\0\0K\0\0\0\�\0\0�\0\0\0Z\0\0\0�\0\0\0\�\0\0\0�\0\0\0\0\0\0\0\0\0\0A\0\0\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\�\n\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0p\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0c\0o\0t\0i\0z\0a\0c\0i\0o\0n\0_\0d\0e\0t\0a\0l\0l\0e\0s\0\0\0\0\0\\W\0t�\0\\W\0ּ\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0*\0\0\0\0\0\0\0�D\0\0�\0#\0\0X\0\09\0\0\0\0\0\0\0#\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma!\0F\0K\0_\0c\0o\0t\0i\0z\0a\0c\0i\0o\0n\0_\0d\0e\0t\0a\0l\0l\0e\0s\0_\0c\0o\0t\0i\0z\0a\0c\0i\0o\0n\0!C4\0\0\0A\0\0�*\0\0xV4\0\0\0\0\0c\0u\0a\0d\0r\0e\0_\0c\0a\0j\0a\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\0\�#\0\0\0\0\0\0-\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0�\0\0�\0\0\�\0\0�\0\0H\0\0�\0\0�\0\0�\0\0\0\0\0\0\0\0\0A\0\0�*\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\n\0\0\0\0\0\0\0\0\0�\0\0 \r\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0`\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0c\0u\0a\0d\0r\0e\0_\0c\0a\0j\0a\0\0\0!C4\0\0\0A\0\0\�\0\0xV4\0\0\0\0\0c\0u\0e\0n\0t\0a\0_\0b\0a\0n\0c\0a\0r\0i\0a\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\0\�\Z\0\0\0\0\0\0-\0\0	\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0�\0\0�\0\0\�\0\0�\0\0H\0\0�\0\0�\0\0�\0\0\0\0\0\0\0\0\0A\0\0\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0h\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0c\0u\0e\0n\0t\0a\0_\0b\0a\0n\0c\0a\0r\0i\0a\0\0\0!C4\0\0\0A\0\0g\0\0xV4\0\0\0\0\0d\0e\0p\0a\0r\0t\0a\0m\0e\0n\0t\0o\0\0\0\0\0�(2\n\0\0\0�(2\n\0\0\0\0@fO\0\0\0@fO\0\0\0\0�lO\0\0\0�lO\0\0\0\0\�pO\0\0\0\�pO\0\0\0\0\0\�O\0\0\0\0\�O\0\0\0\0P\�O\0\0\0P\�O\0\0\0\0\�\�+\0\0\0\�\�+\0\0\0\0\�\�+\0\0\0\�\�+\0\0\0\0\�\�+\0\0\0\�\�+\0\0\0\0P�,\0\0\0P�,\0\0\0\0�c\0\0\0�c\0\0\0\0�c\0\0\0�c\0\0\0\0Pc\0\0\0Pc\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\09\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0g\0\0�\0\0\�\0\0�\0\0+\0\0�\0\0�\0\0*\0\0\0\0\0\0\0\0\0A\0\0g\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\n\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0b\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\r\0\0\0d\0e\0p\0a\0r\0t\0a\0m\0e\0n\0t\0o\0\0\0!C4\0\0\0\'\0\0g\0\0xV4\0\0\0\0\0d\0i\0r\0e\0c\0c\0i\0o\0n\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\09\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0g\0\0�\0\0\�\0\0�\0\0+\0\0�\0\0�\0\0*\0\0\0\0\0\0\0\0\0\'\0\0g\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\n\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0\\\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\n\0\0\0d\0i\0r\0e\0c\0c\0i\0o\0n\0\0\0!C4\0\0\0A\0\0\�\0\0xV4\0\0\0\0\0e\0g\0r\0e\0s\0o\0s\0_\0c\0a\0j\0a\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\0Q\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0�\0\0�\0\0\�\0\0�\0\0H\0\0�\0\0�\0\0�\0\0\0\0\0\0\0\0\0A\0\0\�\0\0\0\0\0\0	\0\0\0	\0\0\0\0\0\0\0\0\0\0\0\�\n\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0b\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\r\0\0\0e\0g\0r\0e\0s\0o\0s\0_\0c\0a\0j\0a\0\0\0\0\0�}\0\0w�\0\0�}\0\0n	\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\01\0\0\0\0\0\0\0p\0\0^\0J\r\0\0X\0\03\0\0\0\0\0\0\0J\r\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0e\0g\0r\0e\0s\0o\0s\0_\0c\0a\0j\0a\0_\0c\0a\0j\0e\0r\0o\0!C4\0\0\0A\0\0\�\0\0xV4\0\0\0\0\0e\0g\0r\0e\0s\0o\0s\0_\0c\0o\0n\0c\0e\0p\0t\0o\0s\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\09\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0�\0\0�\0\0\�\0\0�\0\0H\0\0�\0\0�\0\0�\0\0\0\0\0\0\0\0\0A\0\0\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0N\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0l\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0e\0g\0r\0e\0s\0o\0s\0_\0c\0o\0n\0c\0e\0p\0t\0o\0s\0\0\0!C4\0\0\0A\0\05(\0\0xV4\0\0\0\0\0e\0m\0p\0l\0e\0a\0d\0o\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\0\�#\0\0\0\0\0\0-\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0�\0\0�\0\0\�\0\0�\0\0H\0\0�\0\0�\0\0�\0\0\0\0\0\0\0\0\0A\0\05(\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\n\0\0\0\0\0\0\0\0\0�\0\0 \r\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0Z\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0	\0\0\0e\0m\0p\0l\0e\0a\0d\0o\0\0\0\0\0\�\0\0:x\0\�\0\0P\0,�\0\0P\0,�\0\0\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\05\0\0\0\0\0\0\0\�\�\0\0|f\0�\0\0X\0\0D\0\0\0\0\0\0\0�\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0e\0m\0p\0l\0e\0a\0d\0o\0_\0d\0e\0p\0a\0r\0t\0a\0m\0e\0n\0t\0o\0\0\0S�\0\0\�\0L�\0\0\�\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\07\0\0\0\0\0\0\0B�\0\0\0�\0\0X\0\0I\0\0\0\0\0\0\0�\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0c\0u\0a\0d\0r\0e\0_\0c\0a\0j\0a\0_\0e\0m\0p\0l\0e\0a\0d\0o\0\0\0�\0\0\�\0B�\0\0\�\0B�\0\0��\0\0��\0\0��\0\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\09\0\0\0\0\0\0\0�\0\0�\0\0D\0\0X\0\03\0\0\0\0\0\0\0D\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0c\0a\0j\0e\0r\0o\0_\0e\0m\0p\0l\0e\0a\0d\0o\0\0\0z�\0\0\0z�\0\0K\0\\W\0K\0\\W\0��\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0;\0\0\0\0\0\0\0I\0\�#\0.\r\0\0X\0\06\0\0\0\0\0\0\0.\r\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0c\0o\0t\0i\0z\0a\0c\0i\0o\0n\0_\0e\0m\0p\0l\0e\0a\0d\0o\0!C4\0\0\0\�\0\0!2\0\0xV4\0\0\0\0\0e\0m\0p\0l\0e\0a\0d\0o\0_\0h\0i\0s\0t\0o\0r\0i\0a\0l\0_\0d\0a\0t\0o\0s\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\0\�#\0\0\0\0\0\0-\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0�\0\0�\0\0\�\0\0�\0\0H\0\0�\0\0�\0\0�\0\0\0\0\0\0\0\0\0\�\0\0!2\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0R\0\0\0\0\0\0\0\0\0�\0\0 \r\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0z\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0e\0m\0p\0l\0e\0a\0d\0o\0_\0h\0i\0s\0t\0o\0r\0i\0a\0l\0_\0d\0a\0t\0o\0s\0\0\0\0\0̍\0\0dv\0\0̍\0\0�\0\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0>\0\0\0\0\0\0\0�y\0\0�z\0\0|\0\0X\0\04\0\0\0\0\0\0\0|\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma!\0F\0K\0_\0e\0m\0p\0l\0e\0a\0d\0o\0_\0h\0i\0s\0t\0o\0r\0i\0a\0l\0_\0d\0a\0t\0o\0s\0_\0c\0a\0r\0g\0o\0\0\04�\0\0\�\�\0\04�\0\0��\0\0b�\0\0��\0\0b�\0\0ݱ\0\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0@\0\0\0\0\0\0\0\�\0\0-\�\0\0N\0\0X\0\02\0\0\0\0\0\0\0N\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma%\0F\0K\0_\0e\0m\0p\0l\0e\0a\0d\0o\0_\0h\0i\0s\0t\0o\0r\0i\0a\0l\0_\0d\0a\0t\0o\0s\0_\0e\0m\0p\0l\0e\0a\0d\0o\01\0\0\0r�\0\0\�\�\0\0r�\0\0��\0\0��\0\0��\0\0��\0\0ݱ\0\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0B\0\0\0\0\0\0\0!�\0\0+\�\0\0�\0\0X\0\02\0\0\0\0\0\0\0�\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma$\0F\0K\0_\0e\0m\0p\0l\0e\0a\0d\0o\0_\0h\0i\0s\0t\0o\0r\0i\0a\0l\0_\0d\0a\0t\0o\0s\0_\0e\0m\0p\0l\0e\0a\0d\0o\0!C4\0\0\0A\0\0q\n\0\0xV4\0\0\0\0\0e\0m\0p\0l\0e\0a\0d\0o\0_\0v\0s\0_\0c\0a\0r\0g\0o\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\09\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0�\0\0�\0\0\�\0\0�\0\0H\0\0�\0\0�\0\0�\0\0\0\0\0\0\0\0\0A\0\0q\n\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0l\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0e\0m\0p\0l\0e\0a\0d\0o\0_\0v\0s\0_\0c\0a\0r\0g\0o\0\0\0\0\0b�\0\0xi\0\0b�\0\0�_\0\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0E\0\0\0\0\0\0\0�\0\0\�c\0\0�\0\0X\0\04\0\0\0\0\0\0\0�\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\Z\0F\0K\0_\0e\0m\0p\0l\0e\0a\0d\0o\0_\0v\0s\0_\0c\0a\0r\0g\0o\0_\0c\0a\0r\0g\0o\0!C4\0\0\0u\0\0\�\0\0xV4\0\0\0\0\0e\0m\0p\0l\0e\0a\0d\0o\0_\0v\0s\0_\0c\0o\0n\0c\0e\0p\0t\0o\0s\0_\0n\0o\0m\0i\0n\0a\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\09\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0g\0\0�\0\0\�\0\0�\0\0+\0\0�\0\0�\0\0*\0\0\0\0\0\0\0\0\0u\0\0\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\�\n\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0e\0m\0p\0l\0e\0a\0d\0o\0_\0v\0s\0_\0c\0o\0n\0c\0e\0p\0t\0o\0s\0_\0n\0o\0m\0i\0n\0a\0\0\0\0\0��\0\0\0��\0\0\�K\0�@\0\�K\0�@\0\�`\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0H\0\0\0\0\0\0\0$&\0Sg\0�\0\0X\0\01\0\0\0\0\0\0\0�\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma(\0F\0K\0_\0e\0m\0p\0l\0e\0a\0d\0o\0_\0v\0s\0_\0c\0o\0n\0c\0e\0p\0t\0o\0s\0_\0n\0o\0m\0i\0n\0a\0_\0e\0m\0p\0l\0e\0a\0d\0o\0!C4\0\0\0A\0\0g\0\0xV4\0\0\0\0\0e\0m\0p\0r\0e\0s\0a\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\09\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0g\0\0�\0\0\�\0\0�\0\0+\0\0�\0\0�\0\0*\0\0\0\0\0\0\0\0\0A\0\0g\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\n\0\0\0\0\0\0\0\0\0�\0\0N\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0X\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0e\0m\0p\0r\0e\0s\0a\0\0\0!C4\0\0\0\�\0\0\�\0\0xV4\0\0\0\0\0e\0n\0t\0r\0a\0d\0a\0_\0s\0a\0l\0i\0d\0a\0_\0i\0n\0v\0e\0n\0t\0a\0r\0i\0o\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\0Q\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0g\0\0�\0\0\�\0\0�\0\0+\0\0�\0\0�\0\0*\0\0\0\0\0\0\0\0\0\�\0\0\�\0\0\0\0\0\0	\0\0\0	\0\0\0\0\0\0\0\0\0\0\0`	\0\0\0\0\0\0\0\0\0�\0\0 \r\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0|\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\Z\0\0\0e\0n\0t\0r\0a\0d\0a\0_\0s\0a\0l\0i\0d\0a\0_\0i\0n\0v\0e\0n\0t\0a\0r\0i\0o\0\0\0\0\0<�\0\0\0<�\0\0aJ\0c\0aJ\0c\0�.\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0L\0\0\0\0\0\0\0�E\0K\0�\0\0X\0\02\0\0\0\0\0\0\0�\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma%\0F\0K\0_\0e\0n\0t\0r\0a\0d\0a\0_\0s\0a\0l\0i\0d\0a\0_\0i\0n\0v\0e\0n\0t\0a\0r\0i\0o\0_\0e\0m\0p\0l\0e\0a\0d\0o\0!C4\0\0\0A\0\0g\0\0xV4\0\0\0\0\0e\0s\0t\0a\0d\0o\0s\0_\0r\0e\0p\0a\0r\0a\0c\0i\0o\0n\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\09\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0�\0\0�\0\0\�\0\0�\0\0H\0\0�\0\0�\0\0�\0\0\0\0\0\0\0\0\0A\0\0g\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0N\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0n\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0e\0s\0t\0a\0d\0o\0s\0_\0r\0e\0p\0a\0r\0a\0c\0i\0o\0n\0\0\0!C4\0\0\0A\0\0\�J\0\0xV4\0\0\0\0\0f\0a\0c\0t\0u\0r\0a\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\0\�#\0\0\0\0\0\0-\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0Z\0\0\0i\0\0\0K\0\0\0\�\0\0�\0\0\0Z\0\0\0�\0\0\0\�\0\0\0�\0\0\0\0\0\0\0\0\0\0A\0\0\�J\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0X\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0f\0a\0c\0t\0u\0r\0a\0\0\0\0\0>u\00�\0>u\0\�\�\0&`\0\�\�\0&`\0\�\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0P\0\0\0\0\0\0\0lj\0�\�\0#\n\0\0X\0\03\0\0\0\0\0\0\0#\n\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0f\0a\0c\0t\0u\0r\0a\0_\0c\0l\0i\0e\0n\0t\0e\0!C4\0\0\0A\0\0I\0\0xV4\0\0\0\0\0f\0a\0c\0t\0u\0r\0a\0_\0d\0e\0t\0a\0l\0l\0e\0\0\0.\0o\0b\0j\0e\0c\0t\0_\0i\0d\0,\0 \0c\0o\0l\0.\0n\0a\0m\0e\0,\0 \0N\0\'\0I\0s\0I\0d\0N\0o\0t\0F\0o\0r\0R\0e\0p\0l\0\'\0)\0)\0 \0a\0s\0 \0I\0s\0I\0d\0N\0o\0t\0F\0o\0r\0R\0e\0p\0l\0,\0 \0c\0o\0l\0.\0i\0s\0_\0r\0e\0p\0l\0i\0c\0a\0t\0e\0d\0,\0 \0c\0o\0l\0.\0i\0s\0_\0n\0o\0n\0_\0s\0q\0l\0_\0s\0u\0b\0s\0c\0r\0i\0b\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\0�!\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0Z\0\0\0i\0\0\0K\0\0\0\�\0\0�\0\0\0Z\0\0\0�\0\0\0\�\0\0\0�\0\0\0\0\0\0\0\0\0\0A\0\0I\0\0\0\0\0\0\n\0\0\0\n\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0\0\0\0\0\0�\0\0\�\n\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0h\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0f\0a\0c\0t\0u\0r\0a\0_\0d\0e\0t\0a\0l\0l\0e\0\0\0\0\0�^\0�\'\0�^\0\Z/\0TP\0\Z/\0TP\0p1\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0S\0\0\0\0\0\0\0|J\0-\0\�\0\0X\0\02\0\0\0\0\0\0\0\�\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\Z\0F\0K\0_\0f\0a\0c\0t\0u\0r\0a\0_\0d\0e\0t\0a\0l\0l\0e\0_\0f\0a\0c\0t\0u\0r\0a\0!C4\0\0\0A\0\0\�\0\0xV4\0\0\0\0\0f\0a\0c\0t\0u\0r\0a\0s\0_\0a\0n\0u\0l\0a\0d\0a\0s\0\0\0c\0o\0l\0u\0m\0n\0_\0i\0d\0)\0 \0F\0T\0_\0t\0y\0p\0e\0_\0c\0o\0l\0u\0m\0n\0,\0 \0f\0t\0c\0.\0l\0a\0n\0g\0u\0a\0g\0e\0_\0i\0d\0 \0a\0s\0 \0F\0T\0_\0l\0a\0n\0g\0u\0a\0g\0e\0_\0i\0d\0,\0 \0c\0a\0s\0e\0 \0w\0h\0e\0n\0(\0c\0m\0c\0.\0c\0o\0l\0u\0m\0n\0_\0i\0d\0 \0i\0s\0 \0n\0u\0l\0l\0)\0 \0t\0h\0e\0n\0 \0n\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\09\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0Z\0\0\0i\0\0\0K\0\0\0\�\0\0�\0\0\0Z\0\0\0�\0\0\0\�\0\0\0�\0\0\0\0\0\0\0\0\0\0A\0\0\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0\0\0\0\0\0�\0\0N\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0l\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0f\0a\0c\0t\0u\0r\0a\0s\0_\0a\0n\0u\0l\0a\0d\0a\0s\0\0\0\0\0�`\0�\'\0�`\0\Z/\0�p\0\Z/\0�p\0p1\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0V\0\0\0\0\0\0\0\�T\0\�/\0�\0\0X\0\02\0\0\0\0\0\0\0�\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0f\0a\0c\0t\0u\0r\0a\0s\0_\0a\0n\0u\0l\0a\0d\0a\0s\0_\0f\0a\0c\0t\0u\0r\0a\0!C4\0\0\0A\0\0\�\0\0xV4\0\0\0\0\0g\0r\0u\0p\0o\0_\0u\0s\0u\0a\0r\0i\0o\0s\0\0\0n\0u\0l\0l\0)\0 \0t\0h\0e\0n\0 \0n\0u\0l\0l\0 \0e\0l\0s\0e\0 \0c\0m\0c\0.\0i\0s\0_\0p\0e\0r\0s\0i\0s\0t\0e\0d\0 \0e\0n\0d\0 \0a\0s\0 \0i\0s\0_\0p\0e\0r\0s\0i\0s\0t\0e\0d\0,\0 \0d\0e\0f\0C\0s\0t\0.\0d\0e\0f\0i\0n\0i\0t\0i\0o\0n\0,\0 \0C\0O\0L\0U\0M\0N\0P\0R\0O\0P\0E\0R\0T\0Y\0(\0c\0o\0l\0.\0o\0b\0j\0e\0c\0t\0_\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\09\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0Z\0\0\0i\0\0\0K\0\0\0\�\0\0�\0\0\0Z\0\0\0�\0\0\0\�\0\0\0�\0\0\0\0\0\0\0\0\0\0A\0\0\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\04\0\0\0\0\0\0\0\0\0�\0\0N\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0f\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0g\0r\0u\0p\0o\0_\0u\0s\0u\0a\0r\0i\0o\0s\0\0\0!C4\0\0\0v\0\0q\n\0\0xV4\0\0\0\0\0g\0r\0u\0p\0o\0_\0u\0s\0u\0a\0r\0i\0o\0s\0_\0p\0e\0r\0m\0i\0s\0o\0s\0\0\0a\0_\0n\0a\0m\0e\0,\0 \0s\0c\0h\0e\0m\0a\0_\0n\0a\0m\0e\0(\0x\0m\0l\0c\0o\0l\0l\0.\0s\0c\0h\0e\0m\0a\0_\0i\0d\0)\0 \0a\0s\0 \0x\0m\0l\0S\0c\0h\0e\0m\0a\0_\0s\0c\0h\0e\0m\0a\0,\0 \0c\0o\0l\0.\0i\0s\0_\0x\0m\0l\0_\0d\0o\0c\0u\0m\0e\0n\0t\0,\0 \0c\0o\0l\0.\0i\0s\0_\0s\0p\0a\0r\0s\0e\0,\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\09\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0Z\0\0\0i\0\0\0K\0\0\0\�\0\0�\0\0\0Z\0\0\0�\0\0\0\�\0\0\0�\0\0\0\0\0\0\0\0\0\0v\0\0q\n\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\04\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0x\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0g\0r\0u\0p\0o\0_\0u\0s\0u\0a\0r\0i\0o\0s\0_\0p\0e\0r\0m\0i\0s\0o\0s\0\0\0\0\0�{\0��\0�{\0A�\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0Z\0\0\0\0\0\0\0m|\0��\0\�\0\0X\0\0:\0\0\0\0\0\0\0\�\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma)\0F\0K\0_\0g\0r\0u\0p\0o\0_\0u\0s\0u\0a\0r\0i\0o\0s\0_\0p\0e\0r\0m\0i\0s\0o\0s\0_\0g\0r\0u\0p\0o\0_\0u\0s\0u\0a\0r\0i\0o\0s\0!C4\0\0\0\0\0S\0\0xV4\0\0\0\0\0h\0i\0s\0t\0o\0r\0i\0a\0l\0_\0d\0e\0v\0o\0l\0u\0c\0i\0o\0n\0_\0c\0o\0m\0p\0r\0a\0s\0\0\0 \00\0)\0 \0t\0h\0e\0n\0 \00\0 \0e\0l\0s\0e\0 \01\0 \0e\0n\0d\0)\0 \0a\0s\0 \0i\0s\0_\0S\0t\0a\0t\0i\0s\0t\0i\0c\0a\0l\0S\0e\0m\0a\0n\0t\0i\0c\0s\0,\0 \0c\0o\0l\0.\0i\0s\0_\0f\0i\0l\0e\0s\0t\0r\0e\0a\0m\0 \0f\0r\0o\0m\0 \0s\0y\0s\0.\0c\0o\0l\0u\0m\0n\0s\0 \0c\0o\0l\0 \0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\0\0\0\0\0\0\0-\0\0\n\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0g\0\0�\0\0\�\0\0�\0\0+\0\0�\0\0�\0\0*\0\0\0\0\0\0\0\0\0\0\0S\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\01\0\0\0\0\0\0\0\0\0�\0\0 \r\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0h\0i\0s\0t\0o\0r\0i\0a\0l\0_\0d\0e\0v\0o\0l\0u\0c\0i\0o\0n\0_\0c\0o\0m\0p\0r\0a\0s\0\0\0\0\0j�\0\0\0j�\0\0P\0b�\0\0P\0b�\0\0R\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0]\0\0\0\0\0\0\0}\0\0n6\0�\0\0X\0\02\0\0\0\0\0\0\0�\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma(\0F\0K\0_\0h\0i\0s\0t\0o\0r\0i\0a\0l\0_\0d\0e\0v\0o\0l\0u\0c\0i\0o\0n\0_\0c\0o\0m\0p\0r\0a\0s\0_\0e\0m\0p\0l\0e\0a\0d\0o\0!C4\0\0\0�\0\0S\0\0xV4\0\0\0\0\0h\0i\0s\0t\0o\0r\0i\0a\0l\0_\0d\0e\0v\0o\0l\0u\0c\0i\0o\0n\0_\0v\0e\0n\0t\0a\0s\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\0\0\0\0\0\0\0-\0\0\n\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0Z\0\0\0i\0\0\0K\0\0\0\�\0\0�\0\0\0Z\0\0\0�\0\0\0\�\0\0\0�\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�	\0\0\0\0\0\0\0\0\0�\0\0 \r\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0h\0i\0s\0t\0o\0r\0i\0a\0l\0_\0d\0e\0v\0o\0l\0u\0c\0i\0o\0n\0_\0v\0e\0n\0t\0a\0s\0\0\0\0\0nT\0�\0cK\0�\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0`\0\0\0\0\0\0\0E\0�\0\0�\0\0X\0\02\0\0\0\0\0\0\0�\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma&\0F\0K\0_\0h\0i\0s\0t\0o\0r\0i\0a\0l\0_\0d\0e\0v\0o\0l\0u\0c\0i\0o\0n\0_\0v\0e\0n\0t\0a\0s\0_\0f\0a\0c\0t\0u\0r\0a\0!C4\0\0\0@\Z\0\0\�\0\0xV4\0\0\0\0\0h\0i\0s\0t\0o\0r\0i\0a\0l\0_\0i\0n\0v\0e\0n\0t\0a\0r\0i\0o\0_\0a\0g\0o\0t\0a\0d\0o\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\0\�\Z\0\0\0\0\0\0-\0\0	\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0g\0\0�\0\0\�\0\0�\0\0+\0\0�\0\0�\0\0*\0\0\0\0\0\0\0\0\0@\Z\0\0\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\n\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0h\0i\0s\0t\0o\0r\0i\0a\0l\0_\0i\0n\0v\0e\0n\0t\0a\0r\0i\0o\0_\0a\0g\0o\0t\0a\0d\0o\0\0\0!C4\0\0\0A\0\0g\0\0xV4\0\0\0\0\0i\0d\0e\0n\0t\0i\0f\0i\0c\0a\0c\0i\0o\0n\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\09\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0Z\0\0\0i\0\0\0K\0\0\0\�\0\0�\0\0\0Z\0\0\0�\0\0\0\�\0\0\0�\0\0\0\0\0\0\0\0\0\0A\0\0g\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\04\0\0\0\0\0\0\0\0\0�\0\0 \r\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0f\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0i\0d\0e\0n\0t\0i\0f\0i\0c\0a\0c\0i\0o\0n\0\0\0!C4\0\0\0A\0\0S\0\0xV4\0\0\0\0\0i\0n\0v\0e\0n\0t\0a\0r\0i\0o\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\0\0\0\0\0\0\0-\0\0\n\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0g\0\0�\0\0\�\0\0�\0\0+\0\0�\0\0�\0\0*\0\0\0\0\0\0\0\0\0A\0\0S\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\�\n\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0^\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0i\0n\0v\0e\0n\0t\0a\0r\0i\0o\0\0\0!C4\0\0\0A\0\0g\0\0xV4\0\0\0\0\0i\0t\0e\0b\0i\0s\0\0\0\0\0\0\0\0\06\0&p`W\0\�\0_\0~&\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\09\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0g\0\0�\0\0\�\0\0�\0\0+\0\0�\0\0�\0\0*\0\0\0\0\0\0\0\0\0A\0\0g\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\n\0\0\0\0\0\0\0\0\0�\0\0N\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0V\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0i\0t\0e\0b\0i\0s\0\0\0!C4\0\0\0A\0\0\�\0\0xV4\0\0\0\0\0l\0o\0t\0e\0r\0i\0a\0_\0r\0e\0a\0l\0_\0q\0u\0i\0n\0i\0e\0l\0a\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\09\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0�\0\0�\0\0\�\0\0�\0\0H\0\0�\0\0�\0\0�\0\0\0\0\0\0\0\0\0A\0\0\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0t\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0l\0o\0t\0e\0r\0i\0a\0_\0r\0e\0a\0l\0_\0q\0u\0i\0n\0i\0e\0l\0a\0\0\0!C4\0\0\0A\0\0\�\0\0xV4\0\0\0\0\0m\0a\0r\0c\0a\0s\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\09\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0�\0\0�\0\0\�\0\0�\0\0H\0\0�\0\0�\0\0�\0\0\0\0\0\0\0\0\0A\0\0\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0N\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0V\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0m\0a\0r\0c\0a\0s\0\0\0!C4\0\0\0A\0\0g\0\0xV4\0\0\0\0\0m\0e\0s\0a\0s\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\09\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0g\0\0�\0\0\�\0\0�\0\0+\0\0�\0\0�\0\0*\0\0\0\0\0\0\0\0\0A\0\0g\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\n\0\0\0\0\0\0\0\0\0�\0\0N\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0T\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0m\0e\0s\0a\0s\0\0\0!C4\0\0\0A\0\0\�\0\0xV4\0\0\0\0\0m\0e\0s\0a\0s\0_\0d\0e\0t\0a\0l\0l\0e\0s\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\09\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0g\0\0�\0\0\�\0\0�\0\0+\0\0�\0\0�\0\0*\0\0\0\0\0\0\0\0\0A\0\0\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\n\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0f\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0m\0e\0s\0a\0s\0_\0d\0e\0t\0a\0l\0l\0e\0s\0\0\0\0\0�\0\0��\0�\0\0h�\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0j\0\0\0\0\0\0\0g\0\0��\0N\0\0X\0\07\0\0\0\0\0\0\0N\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0m\0e\0s\0a\0s\0_\0d\0e\0t\0a\0l\0l\0e\0s\0_\0m\0e\0s\0a\0s\0!C4\0\0\0A\0\0g\0\0xV4\0\0\0\0\0m\0o\0n\0e\0d\0a\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\09\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0�\0\0�\0\0\�\0\0�\0\0H\0\0�\0\0�\0\0�\0\0\0\0\0\0\0\0\0A\0\0g\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0N\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0V\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0m\0o\0n\0e\0d\0a\0\0\0!C4\0\0\0A\0\0\�\0\0xV4\0\0\0\0\0m\0o\0n\0e\0d\0a\0_\0h\0i\0s\0t\0o\0r\0i\0a\0l\0\0\0CXpCXqCXrCXsCXtCXuCXvCXwCXxCXyCXzCX{CX|CX}CX~CXCX�CX�CX�CX�CX�CX�CX�CX�CX�CX�CX�CX�C\�{h\�|h\�}h\�~h\�h\�h\�h\�h\�h\�h\�h\�h\�h\�h\�h\�h\�h\�h\�h\�h\�h\�h\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\09\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0�\0\0�\0\0\�\0\0�\0\0H\0\0�\0\0�\0\0�\0\0\0\0\0\0\0\0\0A\0\0\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0j\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0m\0o\0n\0e\0d\0a\0_\0h\0i\0s\0t\0o\0r\0i\0a\0l\0\0\0\0\0�`\0�U\0\0�`\04L\0\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0n\0\0\0\0\0\0\0ka\0�O\0\0\0\0X\0\08\0\0\0\0\0\0\0\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\Z\0F\0K\0_\0m\0o\0n\0e\0d\0a\0_\0h\0i\0s\0t\0o\0r\0i\0a\0l\0_\0m\0o\0n\0e\0d\0a\0!C4\0\0\0A\0\0\�\0\0xV4\0\0\0\0\0n\0o\0m\0i\0n\0a\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\0Q\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0g\0\0�\0\0\�\0\0�\0\0+\0\0�\0\0�\0\0*\0\0\0\0\0\0\0\0\0A\0\0\�\0\0\0\0\0\0	\0\0\0	\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0 \r\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0V\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0n\0o\0m\0i\0n\0a\0\0\0\0\0�0\0Ή\0\"7\0Ή\0\"7\0�r\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0q\0\0\0\0\0\0\0\�7\0��\0U\0\0X\0\05\0\0\0\0\0\0\0U\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma&\0F\0K\0_\0e\0m\0p\0l\0e\0a\0d\0o\0_\0v\0s\0_\0c\0o\0n\0c\0e\0p\0t\0o\0s\0_\0n\0o\0m\0i\0n\0a\0_\0n\0o\0m\0i\0n\0a\0\0\04�\0\0\04�\0\01M\0�$\01M\0�$\0\�|\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0s\0\0\0\0\0\0\0�\0k�\0�\0\0X\0\02\0\0\0\0\0\0\0�\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0n\0o\0m\0i\0n\0a\0_\0e\0m\0p\0l\0e\0a\0d\0o\0!C4\0\0\0A\0\0g\0\0xV4\0\0\0\0\0n\0o\0m\0i\0n\0a\0_\0c\0o\0n\0c\0e\0p\0t\0o\0s\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\09\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0g\0\0�\0\0\�\0\0�\0\0+\0\0�\0\0�\0\0*\0\0\0\0\0\0\0\0\0A\0\0g\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\n\0\0\0\0\0\0\0\0\0�\0\0N\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0j\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0n\0o\0m\0i\0n\0a\0_\0c\0o\0n\0c\0e\0p\0t\0o\0s\0\0\0\0\0�H\00�\0�H\0�r\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0v\0\0\0\0\0\0\0eI\0-y\0�\0\0X\0\06\0\0\0\0\0\0\0�\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma0\0F\0K\0_\0e\0m\0p\0l\0e\0a\0d\0o\0_\0v\0s\0_\0c\0o\0n\0c\0e\0p\0t\0o\0s\0_\0n\0o\0m\0i\0n\0a\0_\0n\0o\0m\0i\0n\0a\0_\0c\0o\0n\0c\0e\0p\0t\0o\0s\0!C4\0\0\0A\0\0]\0\0xV4\0\0\0\0\0n\0o\0m\0i\0n\0a\0_\0d\0e\0t\0a\0l\0l\0e\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\0\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0g\0\0�\0\0\�\0\0�\0\0+\0\0�\0\0�\0\0*\0\0\0\0\0\0\0\0\0A\0\0]\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0f\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0n\0o\0m\0i\0n\0a\0_\0d\0e\0t\0a\0l\0l\0e\0\0\0\0\0�0\0��\0�7\0��\0�7\0¤\0�<\0¤\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0y\0\0\0\0\0\0\0L8\0D�\0�\0\0X\0\02\0\0\0\0\0\0\0�\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0n\0o\0m\0i\0n\0a\0_\0d\0e\0t\0a\0l\0l\0e\0_\0n\0o\0m\0i\0n\0a\0\0\0�H\0��\0�H\0̚\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0{\0\0\0\0\0\0\003\0�\0\�\0\0X\0\09\0\0\0\0\0\0\0\�\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\"\0F\0K\0_\0n\0o\0m\0i\0n\0a\0_\0d\0e\0t\0a\0l\0l\0e\0_\0n\0o\0m\0i\0n\0a\0_\0c\0o\0n\0c\0e\0p\0t\0o\0s\0!C4\0\0\0A\0\0\�\0\0xV4\0\0\0\0\0n\0o\0m\0i\0n\0a\0_\0t\0i\0p\0o\0s\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\09\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0g\0\0�\0\0\�\0\0�\0\0+\0\0�\0\0�\0\0*\0\0\0\0\0\0\0\0\0A\0\0\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\n\0\0\0\0\0\0\0\0\0�\0\0N\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0b\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\r\0\0\0n\0o\0m\0i\0n\0a\0_\0t\0i\0p\0o\0s\0\0\0\0\0�$\0j�\0�$\0��\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0~\0\0\0\0\0\0\0�%\0��\0�\r\0\0X\0\01\0\0\0\0\0\0\0�\r\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0n\0o\0m\0i\0n\0a\0_\0n\0o\0m\0i\0n\0a\0_\0t\0i\0p\0o\0s\0!C4\0\0\0A\0\0\�\0\0xV4\0\0\0\0\0o\0f\0e\0r\0t\0a\0_\0p\0r\0o\0d\0u\0c\0t\0o\0_\0d\0e\0t\0a\0l\0l\0e\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\09\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0�\0\0�\0\0\�\0\0�\0\0H\0\0�\0\0�\0\0�\0\0\0\0\0\0\0\0\0A\0\0\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0N\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0x\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0o\0f\0e\0r\0t\0a\0_\0p\0r\0o\0d\0u\0c\0t\0o\0_\0d\0e\0t\0a\0l\0l\0e\0\0\0!C4\0\0\0@\0\0g\0\0xV4\0\0\0\0\0o\0f\0e\0r\0t\0a\0_\0p\0r\0o\0d\0u\0c\0t\0o\0_\0s\0u\0b\0c\0a\0t\0e\0_\0d\0e\0t\0a\0l\0l\0e\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\09\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0�\0\0�\0\0\�\0\0�\0\0H\0\0�\0\0�\0\0�\0\0\0\0\0\0\0\0\0@\0\0g\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0m\0\0\0\0\0\0\0\0\0�\0\0N\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0 \0\0\0o\0f\0e\0r\0t\0a\0_\0p\0r\0o\0d\0u\0c\0t\0o\0_\0s\0u\0b\0c\0a\0t\0e\0_\0d\0e\0t\0a\0l\0l\0e\0\0\0!C4\0\0\0A\0\0\�\0\0xV4\0\0\0\0\0p\0a\0i\0s\0\0\0r\0a\0m\0 \0F\0i\0l\0e\0s\0 \0(\0x\08\06\0)\0\\\0M\0i\0c\0r\0o\0s\0o\0f\0t\0 \0S\0Q\0L\0 \0S\0e\0r\0v\0e\0r\0\\\01\01\00\0\\\0T\0o\0o\0l\0s\0\\\0B\0i\0n\0n\0\\\0M\0a\0n\0a\0g\0e\0m\0e\0n\0t\0S\0t\0u\0d\0i\0o\0\\\0T\0o\0o\0l\0s\0\\\0V\0D\0T\0\\\0D\0a\0t\0a\0D\0e\0s\0i\0g\0n\0e\0r\0s\0.\0d\0l\0l\0\0\0i\0s\0i\0o\0�Q5< \0\0�:\0l\0.\0s\0c\0P\0R\0I\0M\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\09\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0g\0\0�\0\0\�\0\0�\0\0+\0\0�\0\0�\0\0*\0\0\0\0\0\0\0\0\0A\0\0\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\n\0\0\0\0\0\0\0\0\0�\0\0N\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0R\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0p\0a\0i\0s\0\0\0!C4\0\0\0A\0\0\�\0\0xV4\0\0\0\0\0p\0e\0d\0i\0d\0o\0_\0d\0e\0t\0a\0l\0l\0e\0\0\0d\0,\0 \0r\0o\0b\0j\0.\0n\0a\0m\0e\0 \0a\0s\0 \0R\0u\0l\0_\0n\0a\0m\0e\0,\0 \0s\0c\0h\0e\0m\0a\0_\0n\0a\0m\0e\0(\0r\0o\0b\0j\0.\0s\0c\0h\0e\0m\0a\0_\0i\0d\0)\0 \0a\0s\0 \0R\0u\0l\0_\0s\0c\0h\0e\0m\0a\0,\0 \0c\0o\0l\0.\0d\0e\0\�V5<u\0\0�\�\0_\0o\0b\0j\0e\0c\0t\0_\0i\0d\0,\0 \0O\0B\0J\0E\0C\0T\0P\0R\0O\0P\0E\0R\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\0\�\Z\0\0\0\0\0\0-\0\0	\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0�\0\0\0\�\0\0\0�\0\0\0\�\0\0;\0\0�\0\0\0;\0\0�\0\0\0\0\0\0\0\0\0\0\0A\0\0\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�	\0\0\0\0\0\0\0\0\0�\0\0\�\n\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0f\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0p\0e\0d\0i\0d\0o\0_\0d\0e\0t\0a\0l\0l\0e\0\0\0!C4\0\0\0A\0\0?#\0\0xV4\0\0\0\0\0p\0e\0d\0i\0d\0o\0s\0\0\0_\0i\0d\0 \0i\0s\0 \0n\0u\0l\0l\0)\0 \0t\0MW5<n\0\0�Ru\0l\0l\0 \0e\0l\0s\0e\0 \0c\0m\0c\0.\0i\0s\0_\0p\0e\0r\0s\0i\0s\0t\0e\0d\0 \0e\0n\0d\0 \0a\0s\0 \0i\0s\0_\0p\0e\0r\0s\0i\0s\0t\0e\0d\0,\0 \0d\0e\0f\0C\0s\0t\0.\0d\0e\0f\0i\0n\0i\0t\0i\0o\0n\0,\0 \0C\0O\0L\0U\0M\0N\0P\0R\0O\0P\0E\0R\0T\0Y\0(\0c\0o\0l\0.\0o\0b\0j\0e\0c\0t\0_\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\0\�#\0\0\0\0\0\0-\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0�\0\0\0\�\0\0\0�\0\0\0\�\0\0;\0\0�\0\0\0;\0\0�\0\0\0\0\0\0\0\0\0\0\0A\0\0?#\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�	\0\0\0\0\0\0\0\0\0�\0\0 \r\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0X\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0p\0e\0d\0i\0d\0o\0s\0\0\0\0\0\�k\0\�\0\�d\0\�\0\�d\0na\0B\0na\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0qe\0i\0]\n\0\0X\0\02\0\0\0\0\0\0\0]\n\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0p\0e\0d\0i\0d\0o\0s\0_\0c\0l\0i\0e\0n\0t\0e\0\0\0�6\0s\0�6\0b|\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0;7\0�v\0�\0\0X\0\01\0\0\0\0\0\0\0�\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0p\0e\0d\0i\0d\0o\0_\0d\0e\0t\0a\0l\0l\0e\0_\0p\0e\0d\0i\0d\0o\0s\0\0\0��\0\0\0��\0\0}L\0�6\0}L\0�6\0\�O\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\�)\0�\�\0\r\0\0X\0\02\0\0\0\0\0\0\0\r\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0p\0e\0d\0i\0d\0o\0s\0_\0e\0m\0p\0l\0e\0a\0d\0o\0!C4\0\0\0A\0\0\�\0\0xV4\0\0\0\0\0p\0e\0r\0m\0i\0s\0o\0\0\0n\0a\0m\0e\0 \0a\0s\0 \0x\0m\0l\0S\0c\0h\0e\0m\0a\0_\0n\0a\0m\0e\0,\0 \0s\0c\0h\0e\0m\0a\0_\0n\0a\0m\0e\0(\0x\0m\0l\0c\0o\0l\0l\0.\0s\0c\0h\0e\0m\0a\0_\0i\0d\0)\0 \0a\0s\0 \0x\0m\0l\0S\0c\0h\0e\0m\0uW5<s\0\0��e\0m\0a\0,\0 \0c\0o\0l\0.\0i\0s\0_\0x\0m\0l\0_\0d\0o\0c\0u\0m\0e\0n\0t\0,\0 \0c\0o\0l\0.\0i\0s\0_\0s\0p\0a\0r\0s\0e\0,\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\09\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0g\0\0�\0\0\�\0\0�\0\0+\0\0�\0\0�\0\0*\0\0\0\0\0\0\0\0\0A\0\0\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\n\0\0\0\0\0\0\0\0\0�\0\0N\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0X\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0p\0e\0r\0m\0i\0s\0o\0\0\0\0\0wf\08�\0Gn\08�\0Gn\0�\0p\0�\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0�n\0\�\0�\0\0X\0\04\0\0\0\0\0\0\0�\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\"\0F\0K\0_\0g\0r\0u\0p\0o\0_\0u\0s\0u\0a\0r\0i\0o\0s\0_\0p\0e\0r\0m\0i\0s\0o\0s\0_\0p\0e\0r\0m\0i\0s\0o\0!C4\0\0\0A\0\0\�\0\0xV4\0\0\0\0\0p\0e\0r\0s\0o\0n\0a\0\0\0p\0e\0_\0i\0d\0 \0l\0e\0f\0t\0 \0o\0u\0t\0e\0r\0 \0j\0o\0i\0n\0 \0s\0y\0s\0.\0t\0y\0p\0e\0s\0 \0b\0t\0 \0o\0n\0 \0b\0t\0.\0u\0s\0e\0r\0_\0t\0y\0p\0e\0_\0i\0d\0 \0=\0 \0c\0o\0�W5<s\0\0�\�t\0e\0m\0_\0t\0y\0p\0e\0_\0i\0d\0 \0l\0e\0f\0t\0 \0o\0u\0t\0e\0r\0 \0j\0o\0i\0n\0 \0s\0y\0s\0.\0o\0b\0j\0e\0c\0t\0s\0 \0r\0o\0b\0j\0 \0o\0n\0 \0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\09\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0�\0\0\0\�\0\0\0�\0\0\0\�\0\0;\0\0�\0\0\0;\0\0�\0\0\0\0\0\0\0\0\0\0\0A\0\0\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�	\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0X\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0p\0e\0r\0s\0o\0n\0a\0\0\0\0\0bo\0\0bo\0�I\0��\0\0�I\0��\0\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0p\0�\0G\0\0X\0\02\0\0\0\0\0\0\0G\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0e\0m\0p\0l\0e\0a\0d\0o\0_\0p\0e\0r\0s\0o\0n\0a\0\0\0�w\0\�/\0�w\0X�\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0Ql\0�Z\0�\n\0\0X\0\02\0\0\0\0\0\0\0�\n\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0c\0l\0i\0e\0n\0t\0e\0_\0p\0e\0r\0s\0o\0n\0a\0!C4\0\0\0A\0\0?#\0\0xV4\0\0\0\0\0p\0r\0o\0d\0u\0c\0t\0o\0\0\0F\0i\0l\0e\0s\0 \0(\0x\08\06\0)\0\\\0M\0i\0c\0r\0o\0s\0o\0f\0t\0 \0S\0Q\0L\0 \0S\0e\0r\0v\0e\0r\0\\\01\01\00\0\\\0T\0o\0o\0l\0s\0\\\0B\0i\0n\0n\0\\\0M\0a\0n\0a\0g\0e\0m\0e\0n\0t\0S\0t\0u\0d\0i\0o\0\\\0T\0o\0o\0l\0s\0\\\0V\0D\0T\0\\\0D\0a\0t\0a\0D\0e\0s\0i\0g\0n\0e\0r\0s\0.\0d\0l\0l\0\0\0\�\0\0Q\0\0�?5<\0\0\0�:\0\0\0Q\0\0�	\0\0\0\0\0\0�	\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\0\�#\0\0\0\0\0\0-\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0g\0\0�\0\0\�\0\0�\0\0+\0\0�\0\0�\0\0*\0\0\0\0\0\0\0\0\0A\0\0?#\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0f\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0Z\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0	\0\0\0p\0r\0o\0d\0u\0c\0t\0o\0\0\0\0\0A\0\0\�|\0�\0\0\�|\0�\0\0$q\0\� \0\0$q\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\�	\0\0�r\0\0\0X\0\03\0\0\0\0\0\0\0\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0p\0r\0o\0d\0u\0c\0t\0o\0_\0t\0i\0p\0o\0_\0p\0r\0o\0d\0u\0c\0t\0o\0\0\0<�\0\0L�\0A:\0\0L�\0A:\0\0$q\08\0\0$q\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0�:\0\0�I\0�\0\0X\0\02\0\0\0\0\0\0\0�\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0p\0r\0o\0d\0u\0c\0t\0o\0_\0a\0l\0m\0a\0c\0e\0n\0\0\0\�L\0\0Z�\0\�L\0\0ʑ\0-\0\0ʑ\0-\0\09�\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\�-\0\0@\0]\n\0\0X\0\03\0\0\0\0\0\0\0]\n\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0p\0r\0o\0d\0u\0c\0t\0o\0_\0i\0t\0e\0b\0i\0s\0\0\08\0\0\�r\0�9\0\0\�r\0�9\0\0x�\0��\0x�\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\�7\0\0\'\�\0\n\0\0X\0\02\0\0\0\0\0\0\0\n\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0c\0o\0m\0b\0o\0_\0p\0r\0o\0d\0u\0c\0t\0o\0\0\08\0\0\�d\0-?\0\0\�d\0-?\0\0\"�\0`\0\0\"�\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\�?\0\0\\~\0�\0\0X\0\02\0\0\0\0\0\0\0�\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0i\0n\0v\0e\0n\0t\0a\0r\0i\0o\0_\0p\0r\0o\0d\0u\0c\0t\0o\0\0\08\0\0\�y\0�6\0\0\�y\0�6\0\0�\�\0�K\0�\�\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0_$\0\03\0�\0\0X\0\03\0\0\0\0\0\0\0�\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0c\0o\0t\0i\0z\0a\0c\0i\0o\0n\0_\0d\0e\0t\0a\0l\0l\0e\0s\0_\0p\0r\0o\0d\0u\0c\0t\0o\0\0\08\0\0c\0-?\0\0c\0-?\0\0�^\0\�\0\0�^\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0�R\0\0�_\0Q\0\0X\0\05\0\0\0\0\0\0\0Q\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma(\0F\0K\0_\0h\0i\0s\0t\0o\0r\0i\0a\0l\0_\0d\0e\0v\0o\0l\0u\0c\0i\0o\0n\0_\0c\0o\0m\0p\0r\0a\0s\0_\0p\0r\0o\0d\0u\0c\0t\0o\0\0\08\0\0Zh\0\�=\0\0Zh\0\�=\0\0_\0U\0_\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0�C\0\0�_\0�\0\0X\0\05\0\0\0\0\0\0\0�\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma(\0F\0K\0_\0h\0i\0s\0t\0o\0r\0i\0a\0l\0_\0i\0n\0v\0e\0n\0t\0a\0r\0i\0o\0_\0a\0g\0o\0t\0a\0d\0o\0_\0p\0r\0o\0d\0u\0c\0t\0o\0\0\08\0\0�{\0	6\0\0�{\0	6\0\0�\0\�1\0�\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\�\0\0\nU\0�\0\0X\0\05\0\0\0\0\0\0\0�\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\'\0F\0K\0_\0h\0i\0s\0t\0o\0r\0i\0a\0l\0_\0d\0e\0v\0o\0l\0u\0c\0i\0o\0n\0_\0v\0e\0n\0t\0a\0s\0_\0p\0r\0o\0d\0u\0c\0t\0o\0\0\08\0\0,x\0q7\0\0,x\0q7\0\0��\0\�*\0��\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0;P\0\03�\0o\0\0X\0\0J\0\0\0\0\0\0\0o\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\Z\0F\0K\0_\0p\0e\0d\0i\0d\0o\0_\0d\0e\0t\0a\0l\0l\0e\0_\0p\0r\0o\0d\0u\0c\0t\0o\0\0\08\0\0r}\0U5\0\0r}\0U5\0\0�@\0�D\0�@\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\�$\0\0*e\0\�\0\0X\0\02\0\0\0\0\0\0\0\�\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0f\0a\0c\0t\0u\0r\0a\0_\0d\0e\0t\0a\0l\0l\0e\0_\0p\0r\0o\0d\0u\0c\0t\0o\0\0\08\0\0\�k\0]<\0\0\�k\0]<\0\0�}\0\nA\0\0�}\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0�(\0\0��\0\�\0\0X\0\02\0\0\0\0\0\0\0\�\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0c\0o\0m\0p\0r\0a\0_\0v\0s\0_\0p\0r\0o\0d\0u\0c\0t\0o\0_\0p\0r\0o\0d\0u\0c\0t\0o\0\0\08\0\0�f\0y>\0\0�f\0y>\0\0=\0\\W\0=\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0>F\0\0�=\0�\0\0X\0\02\0\0\0\0\0\0\0�\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma%\0F\0K\0_\0e\0n\0t\0r\0a\0d\0a\0_\0s\0a\0l\0i\0d\0a\0_\0i\0n\0v\0e\0n\0t\0a\0r\0i\0o\0_\0p\0r\0o\0d\0u\0c\0t\0o\0!C4\0\0\0A\0\0g\0\0xV4\0\0\0\0\0p\0r\0o\0d\0u\0c\0t\0o\0_\0c\0o\0d\0i\0g\0o\0b\0a\0r\0r\0a\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�85<\0\0\0�6\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\09\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0g\0\0�\0\0\�\0\0�\0\0+\0\0�\0\0�\0\0*\0\0\0\0\0\0\0\0\0A\0\0g\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\n\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0r\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0p\0r\0o\0d\0u\0c\0t\0o\0_\0c\0o\0d\0i\0g\0o\0b\0a\0r\0r\0a\0\0\0\0\08\0\0�m\0�;\0\0�m\0�;\0\0��\0\�x\0��\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0J3\0\0Y�\0|\0\0X\0\02\0\0\0\0\0\0\0|\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma \0F\0K\0_\0p\0r\0o\0d\0u\0c\0t\0o\0_\0c\0o\0d\0i\0g\0o\0b\0a\0r\0r\0a\0_\0p\0r\0o\0d\0u\0c\0t\0o\0!C4\0\0\0A\0\0\�\0\0xV4\0\0\0\0\0p\0r\0o\0d\0u\0c\0t\0o\0_\0d\0e\0t\0a\0l\0l\0e\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�85<\0\0\0��\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\09\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0g\0\0�\0\0\�\0\0�\0\0+\0\0�\0\0�\0\0*\0\0\0\0\0\0\0\0\0A\0\0\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\n\0\0\0\0\0\0\0\0\0�\0\0N\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0j\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0p\0r\0o\0d\0u\0c\0t\0o\0_\0d\0e\0t\0a\0l\0l\0e\0\0\0\0\0\� \0\0�\0\0\0�\0\0\0\�\0A\0\0\�\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0�\0\0å\0\r\0\0X\0\05\0\0\0\0\0\0\0\r\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\"\0F\0K\0_\0m\0e\0s\0a\0s\0_\0d\0e\0t\0a\0l\0l\0e\0s\0_\0p\0r\0o\0d\0u\0c\0t\0o\0_\0d\0e\0t\0a\0l\0l\0e\0!C4\0\0\0A\0\0\�\0\0xV4\0\0\0\0\0p\0r\0o\0d\0u\0c\0t\0o\0_\0o\0f\0e\0r\0t\0a\0\0\0\0\0\0��\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\0\�\Z\0\0\0\0\0\0-\0\0	\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0�\0\0�\0\0\�\0\0�\0\0H\0\0�\0\0�\0\0�\0\0\0\0\0\0\0\0\0A\0\0\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0N\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0h\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0p\0r\0o\0d\0u\0c\0t\0o\0_\0o\0f\0e\0r\0t\0a\0\0\0\0\0q\"\0�`\0\0\0,\0�`\0\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\�\0]a\0\0�\0\0X\0\0>\0\0\0\0\0\0\0�\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma2\0F\0K\0_\0o\0f\0e\0r\0t\0a\0_\0p\0r\0o\0d\0u\0c\0t\0o\0_\0s\0u\0b\0c\0a\0t\0e\0_\0d\0e\0t\0a\0l\0l\0e\0_\0p\0r\0o\0d\0u\0c\0t\0o\0_\0o\0f\0e\0r\0t\0a\0\0\0\�\0�U\0\0\�\0rJ\0\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0�\0�N\0\0\�\0\0X\0\0:\0\0\0\0\0\0\0\�\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma*\0F\0K\0_\0o\0f\0e\0r\0t\0a\0_\0p\0r\0o\0d\0u\0c\0t\0o\0_\0d\0e\0t\0a\0l\0l\0e\0_\0p\0r\0o\0d\0u\0c\0t\0o\0_\0o\0f\0e\0r\0t\0a\0!C4\0\0\0v\0\0\�\0\0xV4\0\0\0\0\0p\0r\0o\0d\0u\0c\0t\0o\0_\0o\0f\0e\0r\0t\0a\0_\0h\0i\0s\0t\0o\0r\0i\0a\0l\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0S95<\0\0\0�\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\0Q\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0�\0\0�\0\0\�\0\0�\0\0H\0\0�\0\0�\0\0�\0\0\0\0\0\0\0\0\0v\0\0\�\0\0\0\0\0\0	\0\0\0	\0\0\0\0\0\0\0\0\0\0\04\0\0\0\0\0\0\0\0\0�\0\0N\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0|\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\Z\0\0\0p\0r\0o\0d\0u\0c\0t\0o\0_\0o\0f\0e\0r\0t\0a\0_\0h\0i\0s\0t\0o\0r\0i\0a\0l\0\0\0\0\0\�\0dl\0\0\�\0\�u\0\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\��\0\0\nq\0\0X\0\0X\0\0:\0\0\0\0\0\0\0X\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma,\0F\0K\0_\0p\0r\0o\0d\0u\0c\0t\0o\0_\0o\0f\0e\0r\0t\0a\0_\0h\0i\0s\0t\0o\0r\0i\0a\0l\0_\0p\0r\0o\0d\0u\0c\0t\0o\0_\0o\0f\0e\0r\0t\0a\0!C4\0\0\0A\0\0\�\0\0xV4\0\0\0\0\0p\0r\0o\0d\0u\0c\0t\0o\0_\0p\0e\0r\0m\0i\0s\0o\0s\0\0\0\0\0\0\0�\0\0�\0\0�\0\0\0\0\0\02\0\0�\0\02\0\0\0\0\0\0\�\0\0�\0\0\�\0\0\0\0\0\0^\Z\0\0�\0\0^\Z\0\0\0\0\0\0�\Z\0\0�\0\0�\Z\0\0\0\0\0\0�\0\0�\0\0�\0\0\0\0\0\0 \0\0�\0\0 \0\0\0\0\0\0�\0\0�\0\0�\0\0\0\0\0\0L\0\0�\0\0L\0\0\0\0\0\0\�\0\0�\0\0\�\0\0\0\0\0\0x\0\0�\0\0x\0\0\0\0\�pf\0yN\nt�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\09\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0�\0\0�\0\0\�\0\0�\0\0H\0\0�\0\0�\0\0�\0\0\0\0\0\0\0\0\0A\0\0\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0N\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0l\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0p\0r\0o\0d\0u\0c\0t\0o\0_\0p\0e\0r\0m\0i\0s\0o\0s\0\0\0!C4\0\0\0A\0\0q\n\0\0xV4\0\0\0\0\0p\0r\0o\0d\0u\0c\0t\0o\0_\0u\0n\0i\0d\0a\0d\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0pf\0�\0_\0�\0_\08\08\0\0�\0�\Z\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\09\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0g\0\0�\0\0\�\0\0�\0\0+\0\0�\0\0�\0\0*\0\0\0\0\0\0\0\0\0A\0\0q\n\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\n\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0h\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0p\0r\0o\0d\0u\0c\0t\0o\0_\0u\0n\0i\0d\0a\0d\0\0\0\0\08\0\0j\0=\0\0j\0=\0\0fy\0�W\0fy\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0�.\0\0z\0�\0\0X\0\02\0\0\0\0\0\0\0�\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0p\0r\0o\0d\0u\0c\0t\0o\0_\0u\0n\0i\0d\0a\0d\0_\0p\0r\0o\0d\0u\0c\0t\0o\0!C4\0\0\0u\Z\0\0\�\0\0xV4\0\0\0\0\0p\0r\0o\0d\0u\0c\0t\0o\0_\0u\0n\0i\0d\0a\0d\0_\0c\0o\0n\0v\0e\0r\0s\0i\0o\0n\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\09\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0�\0\0�\0\0\�\0\0�\0\0H\0\0�\0\0�\0\0�\0\0\0\0\0\0\0\0\0u\Z\0\0\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�	\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0~\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0p\0r\0o\0d\0u\0c\0t\0o\0_\0u\0n\0i\0d\0a\0d\0_\0c\0o\0n\0v\0e\0r\0s\0i\0o\0n\0\0\0!C4\0\0\0A\0\0\�\0\0xV4\0\0\0\0\0p\0r\0o\0d\0u\0c\0t\0o\0_\0v\0s\0_\0d\0e\0t\0a\0l\0l\0e\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\09\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0g\0\0�\0\0\�\0\0�\0\0+\0\0�\0\0�\0\0*\0\0\0\0\0\0\0\0\0A\0\0\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\n\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0p\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0p\0r\0o\0d\0u\0c\0t\0o\0_\0v\0s\0_\0d\0e\0t\0a\0l\0l\0e\0\0\0\0\0�,\0\0��\0�,\0\0F�\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0\0\0\07-\0\0\0�\0\�\0\0X\0\0B\0\0\0\0\0\0\0\�\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma+\0F\0K\0_\0p\0r\0o\0d\0u\0c\0t\0o\0_\0d\0e\0t\0a\0l\0l\0e\0_\0p\0r\0o\0d\0u\0c\0t\0o\0_\0e\0s\0p\0e\0c\0i\0f\0i\0c\0a\0c\0i\0o\0n\0\0\0\\+\0\09�\0\\+\0\0~�\0�,\0\0~�\0�,\0\0Z�\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0\0\0\0\Z\0\05\0�\0\0X\0\02\0\0\0\0\0\0\0�\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0p\0r\0o\0d\0u\0c\0t\0o\0_\0d\0e\0t\0a\0l\0l\0e\0_\0p\0r\0o\0d\0u\0c\0t\0o\0!C4\0\0\0A\0\0\�\0\0xV4\0\0\0\0\0p\0r\0o\0d\0u\0c\0t\0o\0_\0v\0s\0_\0p\0e\0r\0m\0i\0s\0o\0s\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\09\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0�\0\0�\0\0\�\0\0�\0\0H\0\0�\0\0�\0\0�\0\0\0\0\0\0\0\0\0A\0\0\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0r\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0p\0r\0o\0d\0u\0c\0t\0o\0_\0v\0s\0_\0p\0e\0r\0m\0i\0s\0o\0s\0\0\0\0\081\0\0�E\0\0�\'\0\0�E\0\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0\0\0\0�\"\0\0�C\0\0\0\0X\0\0C\0\0\0\0\0\0\0\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma)\0F\0K\0_\0p\0r\0o\0d\0u\0c\0t\0o\0_\0v\0s\0_\0p\0e\0r\0m\0i\0s\0o\0s\0_\0p\0r\0o\0d\0u\0c\0t\0o\0_\0p\0e\0r\0m\0i\0s\0o\0s\0\0\0�,\0\0�^\0�,\0\0N\0\0 \0\0N\0\0 \0\04L\0\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0\0\0\07-\0\0�\�\0\0�\0\0X\0\02\0\0\0\0\0\0\0�\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma \0F\0K\0_\0p\0r\0o\0d\0u\0c\0t\0o\0_\0v\0s\0_\0p\0e\0r\0m\0i\0s\0o\0s\0_\0p\0r\0o\0d\0u\0c\0t\0o\0!C4\0\0\0A\0\0g\0\0xV4\0\0\0\0\0p\0r\0o\0v\0i\0n\0c\0i\0a\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\09\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0g\0\0�\0\0\�\0\0�\0\0+\0\0�\0\0�\0\0*\0\0\0\0\0\0\0\0\0A\0\0g\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\n\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0\\\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\n\0\0\0p\0r\0o\0v\0i\0n\0c\0i\0a\0\0\0!C4\0\0\0A\0\0g\0\0xV4\0\0\0\0\0r\0e\0g\0i\0o\0n\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\09\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0g\0\0�\0\0\�\0\0�\0\0+\0\0�\0\0�\0\0*\0\0\0\0\0\0\0\0\0A\0\0g\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\n\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0V\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0r\0e\0g\0i\0o\0n\0\0\0\0\0�[\0B\�\0�[\0\r\�\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0\0\0\0\�O\0\�\0\�\n\0\0X\0\01\0\0\0\0\0\0\0\�\n\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0p\0r\0o\0v\0i\0n\0c\0i\0a\0_\0r\0e\0g\0i\0o\0n\0\0\0�[\0t\0�[\0��\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0\0\0\03\\\0\��\08\0\0X\0\03\0\0\0\0\0\0\08\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0r\0e\0g\0i\0o\0n\0_\0p\0a\0i\0s\0!C4\0\0\0A\0\0g\0\0xV4\0\0\0\0\0s\0e\0c\0t\0o\0r\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\09\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0g\0\0�\0\0\�\0\0�\0\0+\0\0�\0\0�\0\0*\0\0\0\0\0\0\0\0\0A\0\0g\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\n\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0V\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0s\0e\0c\0t\0o\0r\0\0\0\0\0\�O\0D\�\0\rN\0D\�\0\rN\0�\�\0=F\0�\�\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0\0\0\0rB\0	\�\0\�\n\0\0X\0\05\0\0\0\0\0\0\0\�\n\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0s\0e\0c\0t\0o\0r\0_\0p\0r\0o\0v\0i\0n\0c\0i\0a\0\0\0�:\0}�\0�:\0H\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0\0\0\05/\0��\0\�\n\0\0X\0\02\0\0\0\0\0\0\0\�\n\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0d\0i\0r\0e\0c\0c\0i\0o\0n\0_\0s\0e\0c\0t\0o\0r\0!C4\0\0\0A\0\0\�\0\0xV4\0\0\0\0\0s\0e\0x\0o\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\09\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0�\0\0\0;\0\0\�\0\0\0\�\0\0\�\0\0\0\0\�\0\0X\0\0�\0\0\0\0\0\0\0\0\0A\0\0\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0N\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0R\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0s\0e\0x\0o\0\0\0\0\0�Z\0\�&\0�c\0\�&\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0\0\0\0TZ\0�\'\0�	\0\0X\0\03\0\0\0\0\0\0\0�	\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0p\0e\0r\0s\0o\0n\0a\0_\0s\0e\0x\0o\0!C4\0\0\0A\0\0�/\0\0xV4\0\0\0\0\0s\0i\0s\0t\0e\0m\0a\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\0\�#\0\0\0\0\0\0-\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0�\0\0�\0\0\�\0\0�\0\0H\0\0�\0\0�\0\0�\0\0\0\0\0\0\0\0\0A\0\0�/\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0X\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0s\0i\0s\0t\0e\0m\0a\0\0\0!C4\0\0\0A\0\0\�\0\0xV4\0\0\0\0\0s\0i\0t\0u\0a\0c\0i\0o\0n\0_\0e\0m\0p\0l\0e\0a\0d\0o\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\09\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0�\0\0�\0\0\�\0\0�\0\0H\0\0�\0\0�\0\0�\0\0\0\0\0\0\0\0\0A\0\0\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0N\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0n\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0s\0i\0t\0u\0a\0c\0i\0o\0n\0_\0e\0m\0p\0l\0e\0a\0d\0o\0\0\0\0\0z�\0\0\�\0\0ٙ\0\0\�\0\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0\0\0\0$�\0\0\�\0\0	\0\0X\0\02\0\0\0\0\0\0\0	\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma.\0F\0K\0_\0e\0m\0p\0l\0e\0a\0d\0o\0_\0h\0i\0s\0t\0o\0r\0i\0a\0l\0_\0d\0a\0t\0o\0s\0_\0s\0i\0t\0u\0a\0c\0i\0o\0n\0_\0e\0m\0p\0l\0e\0a\0d\0o\0\0\02�\0\0h�\0\02�\0\0��\0\0��\0\0��\0\0��\0\0\�\�\0\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0\0\0\0Ό\0\0!�\0\0y\0\0X\0\02\0\0\0\0\0\0\0y\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0e\0m\0p\0l\0e\0a\0d\0o\0_\0s\0i\0t\0u\0a\0c\0i\0o\0n\0_\0e\0m\0p\0l\0e\0a\0d\0o\0!C4\0\0\0A\0\0g\0\0xV4\0\0\0\0\0s\0u\0b\0c\0a\0t\0e\0g\0o\0r\0i\0a\0_\0p\0r\0o\0d\0u\0c\0t\0o\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\09\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0g\0\0�\0\0\�\0\0�\0\0+\0\0�\0\0�\0\0*\0\0\0\0\0\0\0\0\0A\0\0g\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\n\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0t\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0s\0u\0b\0c\0a\0t\0e\0g\0o\0r\0i\0a\0_\0p\0r\0o\0d\0u\0c\0t\0o\0\0\0\0\0A\0\0\�d\0�\0\0\�d\0�\0\0bo\0\� \0\0bo\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0\0\0\0�\0\0m\0\r\0\0X\0\02\0\0\0\0\0\0\0\r\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma!\0F\0K\0_\0p\0r\0o\0d\0u\0c\0t\0o\0_\0s\0u\0b\0c\0a\0t\0e\0g\0o\0r\0i\0a\0_\0p\0r\0o\0d\0u\0c\0t\0o\0\0\0�\0\0jv\0�\0\0�l\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0\0\0\0g\0\0\�p\0\�\0\0X\0\03\0\0\0\0\0\0\0\�\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma+\0F\0K\0_\0s\0u\0b\0c\0a\0t\0e\0g\0o\0r\0i\0a\0_\0p\0r\0o\0d\0u\0c\0t\0o\0_\0c\0a\0t\0e\0g\0o\0r\0i\0a\0_\0p\0r\0o\0d\0u\0c\0t\0o\0!C4\0\0\0A\0\0g\0\0xV4\0\0\0\0\0s\0u\0c\0u\0r\0s\0a\0l\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\09\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0g\0\0�\0\0\�\0\0�\0\0+\0\0�\0\0�\0\0*\0\0\0\0\0\0\0\0\0A\0\0g\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\n\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0Z\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0	\0\0\0s\0u\0c\0u\0r\0s\0a\0l\0\0\0\0\0\�\�\0\0\\�\0\��\0\0\\�\0\��\0\0��\0�K\0��\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0\0\0\0\�\�\0\0�@\0c\0\0X\0\02\0\0\0\0\0\0\0c\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0c\0o\0t\0i\0z\0a\0c\0i\0o\0n\0_\0s\0u\0c\0u\0r\0s\0a\0l\0\0\0\�\�\0\0\�\0I�\0\0\�\0I�\0\0\�\�\0t\0\�\�\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0\0\0\0\��\0\0�\�\0\n\0\0X\0\02\0\0\0\0\0\0\0\n\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0c\0o\0m\0p\0r\0a\0_\0s\0u\0c\0u\0r\0s\0a\0l\0\0\0\�\�\0\0��\0��\0\0��\0��\0\0na\0\�*\0na\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0\0\0\0�\�\0\0w\n\0D\0\0X\0\02\0\0\0\0\0\0\0D\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0p\0e\0d\0i\0d\0o\0s\0_\0s\0u\0c\0u\0r\0s\0a\0l\0\0\0X\�\0\0:x\0X\�\0\0�N\0��\0\0�N\0��\0\0\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0\0\0\0\�\0\0\0�\0G\0\0X\0\02\0\0\0\0\0\0\0G\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0e\0m\0p\0l\0e\0a\0d\0o\0_\0s\0u\0c\0u\0r\0s\0a\0l\0\0\0\�\�\0\0~\0��\0\0~\0��\0\0��\0@\0��\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0\0\0\0(�\0\0��\0\�\n\0\0X\0\02\0\0\0\0\0\0\0\�\n\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0n\0o\0m\0i\0n\0a\0_\0s\0u\0c\0u\0r\0s\0a\0l\0\0\0�\0��\0�\0b�\0�\�\0\0b�\0�\�\0\0��\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0�\�\0\0[�\0c\0\0X\0\02\0\0\0\0\0\0\0c\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0s\0u\0c\0u\0r\0s\0a\0l\0_\0e\0m\0p\0r\0e\0s\0a\01\0\0\0j\�\0\0��\0j\�\0\0��\0��\0\0��\0��\0\0��\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\�\0\0�\0}\0\0X\0\02\0\0\0\0\0\0\0}\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0a\0l\0m\0a\0c\0e\0n\0_\0s\0u\0c\0u\0r\0s\0a\0l\0\0\0�\�\0\0\�\0�\�\0\0\�\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\�\�\0\0\�}\0�\0\0X\0\03\0\0\0\0\0\0\0�\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0d\0e\0p\0a\0r\0t\0a\0m\0e\0n\0t\0o\0_\0s\0u\0c\0u\0r\0s\0a\0l\0!C4\0\0\0A\0\0\�\0\0xV4\0\0\0\0\0s\0u\0c\0u\0r\0s\0a\0l\0_\0v\0s\0_\0e\0m\0p\0l\0e\0a\0d\0o\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\09\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0g\0\0�\0\0\�\0\0�\0\0+\0\0�\0\0�\0\0*\0\0\0\0\0\0\0\0\0A\0\0\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\n\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0r\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0s\0u\0c\0u\0r\0s\0a\0l\0_\0v\0s\0_\0e\0m\0p\0l\0e\0a\0d\0o\0\0\0\0\0r�\0\0\0r�\0\0\�M\0(\0\�M\0(\0bP\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0l\�\0\0�\0\r\0\0X\0\02\0\0\0\0\0\0\0\r\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma \0F\0K\0_\0s\0u\0c\0u\0r\0s\0a\0l\0_\0v\0s\0_\0e\0m\0p\0l\0e\0a\0d\0o\0_\0e\0m\0p\0l\0e\0a\0d\0o\0\0\0\�\�\0\0T|\0��\0\0T|\0��\0\0\�V\0p�\0\0\�V\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0��\0\0`i\0C\0\0X\0\09\0\0\0\0\0\0\0C\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma \0F\0K\0_\0s\0u\0c\0u\0r\0s\0a\0l\0_\0v\0s\0_\0e\0m\0p\0l\0e\0a\0d\0o\0_\0s\0u\0c\0u\0r\0s\0a\0l\0!C4\0\0\0A\0\0\�\0\0xV4\0\0\0\0\0s\0u\0p\0l\0i\0d\0o\0r\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\09\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0g\0\0�\0\0\�\0\0�\0\0+\0\0�\0\0�\0\0*\0\0\0\0\0\0\0\0\0A\0\0\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\n\0\0\0\0\0\0\0\0\0�\0\0N\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0Z\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0	\0\0\0s\0u\0p\0l\0i\0d\0o\0r\0\0\0\0\0\�z\0�%\0�|\0�%\0�|\0:\0z�\0:\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0Y}\0G\0D\0\0X\0\03\0\0\0\0\0\0\0D\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0s\0u\0p\0l\0i\0d\0o\0r\0_\0p\0e\0r\0s\0o\0n\0a\0\0\02�\0\�\02�\0��\0\�\0��\0\�\0/�\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0��\0��\0\�\n\0\0X\0\02\0\0\0\0\0\0\0\�\n\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0c\0o\0m\0p\0r\0a\0_\0s\0u\0p\0l\0i\0d\0o\0r\0!C4\0\0\0A\0\0\�\0\0xV4\0\0\0\0\0t\0a\0r\0j\0e\0t\0a\0s\0_\0c\0r\0e\0d\0i\0t\0o\0\0\0\0\0v\0\0�\0\0\\\�<\0\0\0�M\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0D\0i\0a\0g\0r\0a\�p#<\0B\0�D\0\0k\0g\0r\0o\0u\0n\0d\0\0\0D\0i\0a\0g\0r\0a\0m\0 \0B\0a\0c\0k\0g\0r\0o\0u\0n\0d\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0D\0i�p#<\0r\0�O\0\0 \0b\0a\0c\0k\0g\0r\0o\0u\0n\0d\0 \0d\0e\0s\0c\0r\0i\0p\0t\0i\0o\0n\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\09\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0�\0\0�\0\0\�\0\0�\0\0H\0\0�\0\0�\0\0�\0\0\0\0\0\0\0\0\0A\0\0\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0N\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0j\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0t\0a\0r\0j\0e\0t\0a\0s\0_\0c\0r\0e\0d\0i\0t\0o\0\0\0!C4\0\0\0A\0\0g\0\0xV4\0\0\0\0\0t\0e\0r\0c\0e\0r\0o\0\0\0\0c��:h�:�:��:`�:�:�\0;X;\0;��dH�d�d��d@�d\�d��d8�d\�\�d\�\�ix\�i \�i\�\�i\�i�\�i\�i�snwn�xn`zn|n�}nXn\0�nh1q`6q�9qX;q�qsHss�ts�vs@xs�4q3q\�ys�{s8}s\�~sxax cxhx�ixhkxmx�n\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\09\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0Z\0\0\0i\0\0\0K\0\0\0\�\0\0�\0\0\0Z\0\0\0�\0\0\0\�\0\0\0�\0\0\0\0\0\0\0\0\0\0A\0\0g\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\04\0\0\0\0\0\0\0\0\0�\0\0N\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0X\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0t\0e\0r\0c\0e\0r\0o\0\0\0\0\0p\0NE\0Rj\0NE\0Rj\0L�\0E!\0L�\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\n\0E�\0D\0\0X\0\02\0\0\0\0\0\0\0D\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0e\0m\0p\0r\0e\0s\0a\0_\0t\0e\0r\0c\0e\0r\0o\0\0\0G�\0\"D\0c�\0\"D\0c�\0�@\0֐\0�@\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\n\0\0\0\0\0\0�\0B\0N\0\0X\0\03\0\0\0\0\0\0\0N\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\Z\0F\0K\0_\0i\0d\0e\0n\0t\0i\0f\0i\0c\0a\0c\0i\0o\0n\0_\0t\0e\0r\0c\0e\0r\0o\01\0\0\0p\0\�H\0\�h\0\�H\0\�h\0l\'\0\�z\0l\'\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0_\0e%\0\n\0\0X\0\03\0\0\0\0\0\0\0\n\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0p\0e\0r\0s\0o\0n\0a\0_\0t\0e\0r\0c\0e\0r\0o\0\0\0p\0G\0�i\0G\0�i\0:\0��\0:\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\"\n\03\0\�\n\0\0X\0\0;\0\0\0\0\0\0\0\�\n\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0s\0u\0p\0l\0i\0d\0o\0r\0_\0t\0e\0r\0c\0e\0r\0o\0\0\0p\0VL\0�R\0VL\0�R\0�N\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�U\0OJ\0\�	\0\0X\0\02\0\0\0\0\0\0\0\�	\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0b\0a\0n\0c\0o\0_\0t\0e\0r\0c\0e\0r\0o\0!C4\0\0\0A\0\0]\0\0xV4\0\0\0\0\0t\0e\0r\0c\0e\0r\0o\0_\0o\0b\0s\0e\0r\0v\0a\0c\0i\0o\0n\0e\0s\0\0\0\�s#<�\0�A\0\0D\0\0�\0\0D\0\0\0\0\0\0\�\0\0�\0\0\�\0\0\0\0\0\0p\0\0�\0\0p\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0�\0\0�\0\0�\0\0\�s#<2\0�L\0\02\0\0\0\0\0\0\�\0\0�\0\0\�\0\0\0\0\0\0^\Z\0\0�\0\0^\Z\0\0y_\�<�\Z\0�`\0\0�\Z\0\0\0\0\0\0�\0\0�\0\0�\0\0\0\0\0\0 \0\0�s#< \0�W\0\0�\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\0\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0g\0\0�\0\0\�\0\0�\0\0+\0\0�\0\0�\0\0*\0\0\0\0\0\0\0\0\0A\0\0]\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0N\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0t\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0t\0e\0r\0c\0e\0r\0o\0_\0o\0b\0s\0e\0r\0v\0a\0c\0i\0o\0n\0e\0s\0\0\0\0\0p\0�C\0k\0�C\0k\0v<\0\rg\0v<\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�k\0\�\0	\0\0X\0\09\0\0\0\0\0\0\0	\0\0X\0\0\0\0\0\0\0���\0\0\0�\0\0\0\0\0\0\0�DB\0Tahoma \0F\0K\0_\0t\0e\0r\0c\0e\0r\0o\0_\0o\0b\0s\0e\0r\0v\0a\0c\0i\0o\0n\0e\0s\0_\0t\0e\0r\0c\0e\0r\0o\0!C4\0\0\0A\0\0g\0\0xV4\0\0\0\0\0t\0e\0r\0c\0e\0r\0o\0_\0v\0s\0_\0d\0i\0r\0e\0c\0c\0i\0o\0n\0\0\0\0�y\0\0r\0\0�s#<\0�m\0\0\0\0\0\0\0\0�\0\0\�\0\0�\0\0\0\0\0\04\0\0\�\0\04\0\0\0\0\0\0\�\0\0\�\0\0\�\0\0\0\0\0\0`	\0\0\�\0\0`	\0\0\0\0\0\0�	\0\0�s#<�	\0�x\0\0�\n\0\0\�\0\0�\n\0\0\0\0\0\0\"\0\0\�\0\0\"\0\0\0\0\0\0�\0\0\�\0\0�\0\0\0\0\0\0N\0\0\�\0\0N\0\0\0\0\0\0\�\0\0\�\0\0\�\0\0�s#<z\r\0�K_\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\09\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0g\0\0�\0\0\�\0\0�\0\0+\0\0�\0\0�\0\0*\0\0\0\0\0\0\0\0\0A\0\0g\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\n\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0r\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0t\0e\0r\0c\0e\0r\0o\0_\0v\0s\0_\0d\0i\0r\0e\0c\0c\0i\0o\0n\0\0\0\0\0�:\0�\0�:\0\�\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0R\'\0�\0�\0\0X\0\03\0\0\0\0\0\0\0�\0\0X\0\0\0\0\0\0\0���\0\0\0�\0\0\0\0\0\0\0�DB\0Tahoma!\0F\0K\0_\0t\0e\0r\0c\0e\0r\0o\0_\0v\0s\0_\0d\0i\0r\0e\0c\0c\0i\0o\0n\0_\0d\0i\0r\0e\0c\0c\0i\0o\0n\0\0\0p\0\�A\0�k\0\�A\0�k\0�!\0=F\0�!\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0il\05�\0\�\0\0X\0\07\0\0\0\0\0\0\0\�\0\0X\0\0\0\0\0\0\0���\0\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0t\0e\0r\0c\0e\0r\0o\0_\0v\0s\0_\0d\0i\0r\0e\0c\0c\0i\0o\0n\0_\0t\0e\0r\0c\0e\0r\0o\0!C4\0\0\0A\0\0\�\0\0xV4\0\0\0\0\0t\0e\0r\0c\0e\0r\0o\0_\0v\0s\0_\0e\0m\0a\0i\0l\0\0\0\0\0\�\0\0�\0\0\0\0\0\0V\0\0\�\0\0V\0\0fs#<�p\0��a��A\0\0f!\0\0\0\0\0\0�!\0\0�_\�<�!\0��\0\0�\"\0\0A\0\0�\"\0\0\0\0\0\0(#\0\0A\0\0(#\0\0\0\0\0\0�#\0\0A\0\0�#\0\0{s#<T$\0��\0\0T$\0\0\0\0\0\0\�$\0\0\0\0\0\0\�$\0\0i\0\0i\�qj\00\�~\�	�\0\0\0\0&\0\0A\0\0&\0\0\0\0\0\0�&\0\0A\0\0�&\0\0\0\0\0\0B\'\0\0Ls\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\09\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0Z\0\0\0i\0\0\0K\0\0\0\�\0\0�\0\0\0Z\0\0\0�\0\0\0\�\0\0\0�\0\0\0\0\0\0\0\0\0\0A\0\0\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\04\0\0\0\0\0\0\0\0\0�\0\0N\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0j\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0t\0e\0r\0c\0e\0r\0o\0_\0v\0s\0_\0e\0m\0a\0i\0l\0\0\0\0\0T|\0�=\0T|\0�\�\0��\0�\�\0��\0N\�\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0}\0\�M\0\�\0\0X\0\0;\0\0\0\0\0\0\0\�\0\0X\0\0\0\0\0\0\0���\0\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0t\0e\0r\0c\0e\0r\0o\0_\0v\0s\0_\0e\0m\0a\0i\0l\0_\0t\0e\0r\0c\0e\0r\0o\0!C4\0\0\0A\0\0g\0\0xV4\0\0\0\0\0t\0e\0r\0c\0e\0r\0o\0_\0v\0s\0_\0p\0e\0r\0m\0i\0s\0o\0\0\0\0\0�\0\0�\0\0�\0\0\0\0\0\0\0\0�\0\0\0\0Zs#<�\0�\�\0\0�\0\0\0\0\0\0D\0\0�\0\0D\0\0\0\0\0\0\�\0\0�\0\0\�\0\0\0\0\0\0p\0\0�\0\0p\0\0\0\0\0\0\0\0�\0\0\0\0�_\�<�\0�\�#<�\0�\�\0\02\0\0�\0\02\0\0\0\0\0\0\�\0\0�\0\0\�\0\0\0\0\0\0^\Z\0\0�\0\0^\Z\0\0\0\0\0\0�\Z\0\0�\0\0�\Z\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\09\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0g\0\0�\0\0\�\0\0�\0\0+\0\0�\0\0�\0\0*\0\0\0\0\0\0\0\0\0A\0\0g\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\n\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0n\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0t\0e\0r\0c\0e\0r\0o\0_\0v\0s\0_\0p\0e\0r\0m\0i\0s\0o\0\0\0\0\0\�Z\0��\0\�Z\0\n�\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�H\0ϲ\0�\0\0X\0\03\0\0\0\0\0\0\0�\0\0X\0\0\0\0\0\0\0���\0\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0t\0e\0r\0c\0e\0r\0o\0_\0v\0s\0_\0p\0e\0r\0m\0i\0s\0o\0_\0p\0e\0r\0m\0i\0s\0o\0\0\0�z\0�=\0�z\0�\�\0\�Z\0�\�\0\�Z\0q\�\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0 \0\0\0\0\0\0A{\0�!\0Y\0\0X\0\0E\0\0\0\0\0\0\0Y\0\0X\0\0\0\0\0\0\0���\0\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0t\0e\0r\0c\0e\0r\0o\0_\0v\0s\0_\0p\0e\0r\0m\0i\0s\0o\0_\0t\0e\0r\0c\0e\0r\0o\0!C4\0\0\0A\0\0g\0\0xV4\0\0\0\0\0t\0e\0r\0c\0e\0r\0o\0_\0v\0s\0_\0t\0e\0l\0e\0f\0o\0n\0o\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\09\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0Z\0\0\0i\0\0\0K\0\0\0\�\0\0�\0\0\0Z\0\0\0�\0\0\0\�\0\0\0�\0\0\0\0\0\0\0\0\0\0A\0\0g\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\04\0\0\0\0\0\0\0\0\0�\0\0N\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0p\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0t\0e\0r\0c\0e\0r\0o\0_\0v\0s\0_\0t\0e\0l\0e\0f\0o\0n\0o\0\0\0\0\0G�\0\�E\0J�\0\�E\0J�\0�\\\0֐\0�\\\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0#\0\0\0\0\0\0\�x\0dW\0\�\0\0X\0\0@\0\0\0\0\0\0\0\�\0\0X\0\0\0\0\0\0\0���\0\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0t\0e\0r\0v\0e\0r\0o\0_\0v\0s\0_\0t\0e\0l\0e\0f\0o\0n\0o\0_\0t\0e\0r\0c\0e\0r\0o\0!C4\0\0\0A\0\0g\0\0xV4\0\0\0\0\0t\0i\0p\0o\0_\0c\0o\0m\0p\0r\0o\0b\0a\0n\0t\0e\0_\0f\0i\0s\0c\0a\0l\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\09\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0�\0\0�\0\0\�\0\0�\0\0H\0\0�\0\0�\0\0�\0\0\0\0\0\0\0\0\0A\0\0g\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\n\0\0\0\0\0\0\0\0\0�\0\0N\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0x\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0t\0i\0p\0o\0_\0c\0o\0m\0p\0r\0o\0b\0a\0n\0t\0e\0_\0f\0i\0s\0c\0a\0l\0\0\0\0\0*]\0\0o�\0\0*]\0\0\�+\0�m\0\0\�+\0�m\0\0,-\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0&\0\0\0\0\0\0B\0\0�\Z\0\\\Z\0\0X\0\02\0\0\0\0\0\0\0\\\Z\0\0X\0\0\0\0\0\0\0���\0\0\0�\0\0\0\0\0\0\0�DB\0Tahoma-\0F\0K\0_\0c\0o\0m\0p\0r\0o\0b\0a\0n\0t\0e\0_\0f\0i\0s\0c\0a\0l\0_\0t\0i\0p\0o\0_\0c\0o\0m\0p\0r\0o\0b\0a\0n\0t\0e\0_\0f\0i\0s\0c\0a\0l\0\0\0�h\0\0�\�\0\0�p\0\0�\�\0\0�p\0\0�\�\0\0Br\0\0�\�\0\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0(\0\0\0\0\0\02q\0\0E\�\0\0_\0\0X\0\03\0\0\0\0\0\0\0_\0\0X\0\0\0\0\0\0\0���\0\0\0�\0\0\0\0\0\0\0�DB\0Tahoma-\0F\0K\0_\0c\0o\0m\0p\0r\0o\0b\0a\0n\0t\0e\0_\0v\0e\0n\0t\0a\0s\0_\0t\0i\0p\0o\0_\0c\0o\0m\0p\0r\0o\0b\0a\0n\0t\0e\0_\0f\0i\0s\0c\0a\0l\0!C4\0\0\0A\0\0\�\0\0xV4\0\0\0\0\0t\0i\0p\0o\0_\0c\0u\0e\0n\0t\0a\0_\0b\0a\0n\0c\0a\0r\0i\0a\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\09\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0�\0\0�\0\0\�\0\0�\0\0H\0\0�\0\0�\0\0�\0\0\0\0\0\0\0\0\0A\0\0\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0N\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0r\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0t\0i\0p\0o\0_\0c\0u\0e\0n\0t\0a\0_\0b\0a\0n\0c\0a\0r\0i\0a\0\0\0\0\0��\0\04L\0\0��\0\0�U\0\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0+\0\0\0\0\0\0�\�\0\0EP\0\0n\0\0X\0\03\0\0\0\0\0\0\0n\0\0X\0\0\0\0\0\0\0���\0\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\'\0F\0K\0_\0c\0u\0e\0n\0t\0a\0_\0b\0a\0n\0c\0a\0r\0i\0a\0_\0t\0i\0p\0o\0_\0c\0u\0e\0n\0t\0a\0_\0b\0a\0n\0c\0a\0r\0i\0a\0!C4\0\0\0A\0\0\�\0\0xV4\0\0\0\0\0t\0i\0p\0o\0_\0i\0d\0e\0n\0t\0i\0f\0i\0c\0a\0c\0i\0o\0n\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\09\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0Z\0\0\0i\0\0\0K\0\0\0\�\0\0�\0\0\0Z\0\0\0�\0\0\0\�\0\0\0�\0\0\0\0\0\0\0\0\0\0A\0\0\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\04\0\0\0\0\0\0\0\0\0�\0\0N\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0p\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0t\0i\0p\0o\0_\0i\0d\0e\0n\0t\0i\0f\0i\0c\0a\0c\0i\0o\0n\0\0\0\0\0��\0j1\0��\0\09\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0.\0\0\0\0\0\0�\0�4\0`\0\0X\0\03\0\0\0\0\0\0\0`\0\0X\0\0\0\0\0\0\0���\0\0\0�\0\0\0\0\0\0\0�DB\0Tahoma%\0F\0K\0_\0i\0d\0e\0n\0t\0i\0f\0i\0c\0a\0c\0i\0o\0n\0_\0t\0i\0p\0o\0_\0i\0d\0e\0n\0t\0i\0f\0i\0c\0a\0c\0i\0o\0n\0!C4\0\0\0\Z\0\0\�\0\0xV4\0\0\0\0\0t\0i\0p\0o\0_\0m\0o\0v\0i\0m\0i\0e\0n\0t\0o\0_\0i\0n\0v\0e\0n\0t\0a\0r\0i\0o\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\09\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0g\0\0�\0\0\�\0\0�\0\0+\0\0�\0\0�\0\0*\0\0\0\0\0\0\0\0\0\Z\0\0\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\00\0\0\0\0\0\0\0\0\0�\0\0N\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0~\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0t\0i\0p\0o\0_\0m\0o\0v\0i\0m\0i\0e\0n\0t\0o\0_\0i\0n\0v\0e\0n\0t\0a\0r\0i\0o\0\0\0!C4\0\0\0A\0\0\� \0\0xV4\0\0\0\0\0t\0r\0a\0n\0s\0f\0e\0r\0e\0n\0c\0i\0a\0_\0i\0n\0v\0e\0n\0t\0a\0r\0i\0o\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\0\�#\0\0\0\0\0\0-\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0g\0\0�\0\0\�\0\0�\0\0+\0\0�\0\0�\0\0*\0\0\0\0\0\0\0\0\0A\0\0\� \0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0z\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0t\0r\0a\0n\0s\0f\0e\0r\0e\0n\0c\0i\0a\0_\0i\0n\0v\0e\0n\0t\0a\0r\0i\0o\0\0\0\0\08\0\0�t\0\�8\0\0�t\0\�8\0\0t\�\0\�\0\0t\�\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\02\0\0\0\0\0\0\0\0�r\0\0\0X\0\02\0\0\0\0\0\0\0\0\0X\0\0\0\0\0\0\0���\0\0\0�\0\0\0\0\0\0\0�DB\0Tahoma,\0F\0K\0_\0h\0i\0s\0t\0o\0r\0i\0a\0l\0_\0m\0o\0v\0i\0m\0i\0e\0n\0t\0o\0s\0_\0i\0n\0v\0e\0n\0t\0a\0r\0i\0o\0_\0p\0r\0o\0d\0u\0c\0t\0o\0\0\0}�\0\0 �\0��\0\0 �\0��\0\0�\�\0\�\0\0�\�\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\04\0\0\0\0\0\0J�\0\0\�\0�\0\0X\0\03\0\0\0\0\0\0\0�\0\0X\0\0\0\0\0\0\0���\0\0\0�\0\0\0\0\0\0\0�DB\0Tahoma+\0F\0K\0_\0h\0i\0s\0t\0o\0r\0i\0a\0l\0_\0m\0o\0v\0i\0m\0i\0e\0n\0t\0o\0s\0_\0i\0n\0v\0e\0n\0t\0a\0r\0i\0o\0_\0a\0l\0m\0a\0c\0e\0n\0\0\0}�\0\0\��\0�\0\0\��\0�\0\0�\�\0\�\0\0�\�\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\06\0\0\0\0\0\0\�\0\0�\�\0X\0\0X\0\03\0\0\0\0\0\0\0X\0\0X\0\0\0\0\0\0\0���\0\0\0�\0\0\0\0\0\0\0�DB\0Tahoma,\0F\0K\0_\0h\0i\0s\0t\0o\0r\0i\0a\0l\0_\0m\0o\0v\0i\0m\0i\0e\0n\0t\0o\0s\0_\0i\0n\0v\0e\0n\0t\0a\0r\0i\0o\0_\0a\0l\0m\0a\0c\0e\0n\01\0\0\0\�\�\0\0��\0\�\�\0\0b�\0Z\�\0\0b�\0Z\�\0\0J\�\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\08\0\0\0\0\0\0�\�\0\0[�\0d\0\0X\0\06\0\0\0\0\0\0\0d\0\0X\0\0\0\0\0\0\0���\0\0\0�\0\0\0\0\0\0\0�DB\0Tahoma$\0F\0K\0_\0t\0r\0a\0n\0s\0f\0e\0r\0e\0n\0c\0i\0a\0_\0i\0n\0v\0e\0n\0t\0a\0r\0i\0o\0_\0s\0u\0c\0u\0r\0s\0a\0l\0\0\0,\�\0\0��\0,\�\0\0��\0�\�\0\0��\0�\�\0\0J\�\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0:\0\0\0\0\0\0e\�\0\0��\0\0\0X\0\06\0\0\0\0\0\0\0\0\0X\0\0\0\0\0\0\0���\0\0\0�\0\0\0\0\0\0\0�DB\0Tahoma%\0F\0K\0_\0t\0r\0a\0n\0s\0f\0e\0r\0e\0n\0c\0i\0a\0_\0i\0n\0v\0e\0n\0t\0a\0r\0i\0o\0_\0s\0u\0c\0u\0r\0s\0a\0l\01\0\0\0\�\�\0\0�\�\0M\�\0\0�\�\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0<\0\0\0\0\0\0�\�\0\0�\�\0%#\0\0X\0\0N\0\0\0\0\0\0\0%#\0\0X\0\0\0\0\0\0\0���\0\0\0�\0\0\0\0\0\0\0�DB\0Tahoma>\0F\0K\0_\0h\0i\0s\0t\0o\0r\0i\0a\0l\0_\0m\0o\0v\0i\0m\0i\0e\0n\0t\0o\0s\0_\0i\0n\0v\0e\0n\0t\0a\0r\0i\0o\0_\0t\0i\0p\0o\0_\0m\0o\0v\0i\0m\0i\0e\0n\0t\0o\0_\0i\0n\0v\0e\0n\0t\0a\0r\0i\0o\0!C4\0\0\0A\0\0g\0\0xV4\0\0\0\0\0u\0n\0i\0d\0a\0d\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\09\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0g\0\0�\0\0\�\0\0�\0\0+\0\0�\0\0�\0\0*\0\0\0\0\0\0\0\0\0A\0\0g\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\n\0\0\0\0\0\0\0\0\0�\0\0N\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0V\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0u\0n\0i\0d\0a\0d\0\0\0\0\0\�\0@E\0\�\0�)\0�6\0�)\0�6\0:�\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0?\0\0\0\0\0\0�\'\0�\02\0\0X\0\03\0\0\0\0\0\0\02\0\0X\0\0\0\0\0\0\0���\0\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0p\0e\0d\0i\0d\0o\0_\0d\0e\0t\0a\0l\0l\0e\0_\0u\0n\0i\0d\0a\0d\0\0\0��\0@E\0��\0=)\0�>\0=)\0�>\0�\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0A\0\0\0\0\0\0\�(\0q\�\0K\0\0X\0\03\0\0\0\0\0\0\0K\0\0X\0\0\0\0\0\0\0���\0\0\0�\0\0\0\0\0\0\0�DB\0Tahoma%\0F\0K\0_\0h\0i\0s\0t\0o\0r\0i\0a\0l\0_\0d\0e\0v\0o\0l\0u\0c\0i\0o\0n\0_\0v\0e\0n\0t\0a\0s\0_\0u\0n\0i\0d\0a\0d\0\0\0\�x\0tM\0�q\0tM\0�q\0_\0Do\0_\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0E\0\0\0\0\0\0:[\0R\0�\0\0X\0\03\0\0\0\0\0\0\0�\0\0X\0\0\0\0\0\0\0���\0\0\0�\0\0\0\0\0\0\0�DB\0Tahoma&\0F\0K\0_\0h\0i\0s\0t\0o\0r\0i\0a\0l\0_\0i\0n\0v\0e\0n\0t\0a\0r\0i\0o\0_\0a\0g\0o\0t\0a\0d\0o\0_\0u\0n\0i\0d\0a\0d\0\0\0`�\0@E\0`�\0Y+\0b�\0\0Y+\0b�\0\0ik\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0G\0\0\0\0\0\0��\0\0R)\0\0\0X\0\03\0\0\0\0\0\0\0\0\0X\0\0\0\0\0\0\0���\0\0\0�\0\0\0\0\0\0\0�DB\0Tahoma&\0F\0K\0_\0h\0i\0s\0t\0o\0r\0i\0a\0l\0_\0d\0e\0v\0o\0l\0u\0c\0i\0o\0n\0_\0c\0o\0m\0p\0r\0a\0s\0_\0u\0n\0i\0d\0a\0d\0\0\0\�\0�T\0\�\0r\0z�\0r\0z�\0�\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0I\0\0\0\0\0\0�p\0�o\0?\0\0X\0\03\0\0\0\0\0\0\0?\0\0X\0\0\0\0\0\0\0���\0\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0p\0r\0o\0d\0u\0c\0t\0o\0_\0c\0o\0d\0i\0g\0o\0b\0a\0r\0r\0a\0_\0u\0n\0i\0d\0a\0d\0\0\0h�\0@E\0h�\0�(\0TP\0�(\0TP\0�O\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0K\0\0\0\0\0\0A\0~\0�\0\0X\0\02\0\0\0\0\0\0\0�\0\0X\0\0\0\0\0\0\0���\0\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0f\0a\0c\0t\0u\0r\0a\0_\0d\0e\0t\0a\0l\0l\0e\0_\0u\0n\0i\0d\0a\0d\0\0\0�~\0@E\0�~\0\r,\0\�k\0\0\r,\0\�k\0\0��\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0M\0\0\0\0\0\0³\0\0*\0�\0\0X\0\02\0\0\0\0\0\0\0�\0\0X\0\0\0\0\0\0\0���\0\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0i\0n\0v\0e\0n\0t\0a\0r\0i\0o\0_\0u\0n\0i\0d\0a\0d\0\0\0*�\0@E\0*�\0\�\'\0\\W\0\�\'\0\\W\0�\�\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0O\0\0\0\0\0\0;F\0�\�\0r\0\0X\0\02\0\0\0\0\0\0\0r\0\0X\0\0\0\0\0\0\0���\0\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0c\0o\0t\0i\0z\0a\0c\0i\0o\0n\0_\0d\0e\0t\0a\0l\0l\0e\0s\0_\0u\0n\0i\0d\0a\0d\0\0\0\"�\0�T\0\"�\0r\0�c\0r\0�c\0 t\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0Q\0\0\0\0\0\0�o\0p\0o\0\0X\0\03\0\0\0\0\0\0\0o\0\0X\0\0\0\0\0\0\0���\0\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0p\0r\0o\0d\0u\0c\0t\0o\0_\0u\0n\0i\0d\0a\0d\0_\0u\0n\0i\0d\0a\0d\0\0\0\"�\0@E\0\"�\0�*\0\�\�\0\0�*\0\�\�\0\0�\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0S\0\0\0\0\0\0_\�\0\0�(\0\�\0\0X\0\0*\0\0\0\0\0\0\0\�\0\0X\0\0\0\0\0\0\0���\0\0\0�\0\0\0\0\0\0\0�DB\0Tahoma*\0F\0K\0_\0h\0i\0s\0t\0o\0r\0i\0a\0l\0_\0m\0o\0v\0i\0m\0i\0e\0n\0t\0o\0s\0_\0i\0n\0v\0e\0n\0t\0a\0r\0i\0o\0_\0u\0n\0i\0d\0a\0d\0\0\0\�x\0�K\0�q\0�K\0�q\0=\0<o\0=\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0U\0\0\0\0\0\0�\\\0gG\0d\0\0X\0\02\0\0\0\0\0\0\0d\0\0X\0\0\0\0\0\0\0���\0\0\0�\0\0\0\0\0\0\0�DB\0Tahoma#\0F\0K\0_\0e\0n\0t\0r\0a\0d\0a\0_\0s\0a\0l\0i\0d\0a\0_\0i\0n\0v\0e\0n\0t\0a\0r\0i\0o\0_\0u\0n\0i\0d\0a\0d\0!C4\0\0\0A\0\0\�\0\0xV4\0\0\0\0\0v\0e\0n\0d\0e\0d\0o\0r\0\0\0����������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\09\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0Z\0\0\0i\0\0\0K\0\0\0\�\0\0�\0\0\0Z\0\0\0�\0\0\0\�\0\0\0�\0\0\0\0\0\0\0\0\0\0A\0\0\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\04\0\0\0\0\0\0\0\0\0�\0\0N\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0Z\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0	\0\0\0v\0e\0n\0d\0e\0d\0o\0r\0\0\0\0\0�p\0M\0�p\0\\d\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0X\0\0\0\0\0\0d\0yX\0\�\0\0X\0\04\0\0\0\0\0\0\0\�\0\0X\0\0\0\0\0\0\0���\0\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0v\0e\0n\0d\0e\0d\0o\0r\0_\0t\0e\0r\0c\0e\0r\0o\0!C4\0\0\0A\0\0+-\0\0xV4\0\0\0\0\0v\0e\0n\0t\0a\0_\0v\0s\0_\0p\0a\0g\0o\0s\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\0\�#\0\0\0\0\0\0-\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0g\0\0�\0\0\�\0\0�\0\0+\0\0�\0\0�\0\0*\0\0\0\0\0\0\0\0\0A\0\0+-\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0f\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0v\0e\0n\0t\0a\0_\0v\0s\0_\0p\0a\0g\0o\0s\0\0\0\0\0\�\0\0\0\�\0\0MO\0.\�\0\0MO\0.\�\0\0R\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0[\0\0\0\0\0\0C�\0\0�O\0\�\0\0X\0\02\0\0\0\0\0\0\0\�\0\0X\0\0\0\0\0\0\0���\0\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\Z\0F\0K\0_\0v\0e\0n\0t\0a\0_\0v\0s\0_\0p\0a\0g\0o\0s\0_\0e\0m\0p\0l\0e\0a\0d\0o\0\0\0~6\0\0�^\0~6\0\0�\�\0\0�\0�\�\0\0�\0rJ\0\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0]\0\0\0\0\0\0[�\0\0e\�\0\0�\0\0X\0\01\0\0\0\0\0\0\0�\0\0X\0\0\0\0\0\0\0���\0\0\0�\0\0\0\0\0\0\0�DB\0Tahoma#\0F\0K\0_\0o\0f\0e\0r\0t\0a\0_\0p\0r\0o\0d\0u\0c\0t\0o\0_\0d\0e\0t\0a\0l\0l\0e\0_\0p\0r\0o\0d\0u\0c\0t\0o\0!C4\0\0\0A\0\0)\0\0xV4\0\0\0\0\0m\0o\0d\0e\0l\0o\0\0\0W\0i\0n\0d\0o\0w\0s\0.\0F\0o\0r\0m\0s\0,\0 \0V\0e\0r\0s\0i\0o\0n\0=\04\0.\00\0.\00\0.\00\0,\0 \0C\0u\0l\0t\0u\0r\0e\0=\0n\0e\0u\0t\0r\0a\0l\0,\0 \0P\0u\0b\0l\0i\0c\0K\0e\0y\0T\0o\0k\0e\0n\0=\0b\07\07\0a\05\0c\05\06\01\09\03\04\0e\00\08\09\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\09\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0�\0\0�\0\0\�\0\0�\0\0H\0\0�\0\0�\0\0�\0\0\0\0\0\0\0\0\0A\0\0)\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0N\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0V\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0m\0o\0d\0e\0l\0o\0\0\0\0\0\n\�\0\0�\0\0\n\�\0\0�\0\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0`\0\0\0\0\0\0�\�\0\0\0\0]\n\0\0X\0\0\'\0\0\0\0\0\0\0]\n\0\0X\0\0\0\0\0\0\0���\0\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0m\0o\0d\0e\0l\0o\0_\0m\0a\0r\0c\0a\0s\0!C4\0\0\0A\0\0�*\0\0xV4\0\0\0\0\0i\0n\0v\0e\0n\0t\0a\0r\0i\0o\0_\0r\0e\0p\0a\0r\0a\0c\0i\0o\0n\0\0\0V\0e\0r\0s\0i\0o\0n\0=\04\0.\00\0.\00\0.\00\0,\0 \0C\0u\0l\0t\0u\0r\0e\0=\0n\0e\0u\0t\0r\0a\0l\0,\0 \0P\0u\0b\0l\0i\0c\0K\0e\0y\0T\0o\0k\0e\0n\0=\0b\07\07\0a\05\0c\05\06\01\09\03\04\0e\00\08\09\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\0\�#\0\0\0\0\0\0-\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0�\0\0�\0\0\�\0\0�\0\0H\0\0�\0\0�\0\0�\0\0\0\0\0\0\0\0\0A\0\0�*\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0N\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0t\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0i\0n\0v\0e\0n\0t\0a\0r\0i\0o\0_\0r\0e\0p\0a\0r\0a\0c\0i\0o\0n\0\0\0\0\0R\�\0\0\"\0\0��\0\0\"\0\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0f\0\0\0\0\0\0ð\0\0	\0\0]\0\0X\0\02\0\0\0\0\0\0\0]\0\0X\0\0\0\0\0\0\0���\0\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0i\0n\0v\0e\0n\0t\0a\0r\0i\0o\0_\0r\0e\0p\0a\0r\0a\0c\0i\0o\0n\0_\0m\0a\0r\0c\0a\0s\0\0\0T�\0\0R5\0\0�\0\0R5\0\0�\0\081\0\0��\0\081\0\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0h\0\0\0\0\0\0q�\0\0\�1\0\0<\0\0X\0\0J\0\0\0\0\0\0\0<\0\0X\0\0\0\0\0\0\0���\0\0\0�\0\0\0\0\0\0\0�DB\0Tahoma+\0F\0K\0_\0i\0n\0v\0e\0n\0t\0a\0r\0i\0o\0_\0r\0e\0p\0a\0r\0a\0c\0i\0o\0n\0_\0e\0s\0t\0a\0d\0o\0s\0_\0r\0e\0p\0a\0r\0a\0c\0i\0o\0n\0\0\0\�5\0\0�^\0\�5\0\0Y\�\0\0\�\0\0Y\�\0\0\�\0\0�1\0\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0j\0\0\0\0\0\0\�]\0\0\�\0\0`\0\0X\0\00\0\0\0\0\0\0\0`\0\0X\0\0\0\0\0\0\0���\0\0\0�\0\0\0\0\0\0\0�DB\0Tahoma!\0F\0K\0_\0i\0n\0v\0e\0n\0t\0a\0r\0i\0o\0_\0r\0e\0p\0a\0r\0a\0c\0i\0o\0n\0_\0p\0r\0o\0d\0u\0c\0t\0o\0\0\0\�y\0@E\0\�y\0|;\0��\0\0|;\0��\0\0�1\0\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0l\0\0\0\0\0\0Z\0u9\0#\0\0X\0\03\0\0\0\0\0\0\0#\0\0X\0\0\0\0\0\0\0���\0\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0i\0n\0v\0e\0n\0t\0a\0r\0i\0o\0_\0r\0e\0p\0a\0r\0a\0c\0i\0o\0n\0_\0u\0n\0i\0d\0a\0d\0\0\07\0\0�^\07\0\0z\�\0\0\\�\0\0z\�\0\0\\�\0\0�q\0\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0n\0\0\0\0\0\0It\0\0)\�\0\04\0\0X\0\00\0\0\0\0\0\0\04\0\0X\0\0\0\0\0\0\0���\0\0\0�\0\0\0\0\0\0\0�DB\0Tahoma&\0F\0K\0_\0p\0r\0o\0d\0u\0c\0t\0o\0_\0u\0n\0i\0d\0a\0d\0_\0c\0o\0n\0v\0e\0r\0s\0i\0o\0n\0_\0p\0r\0o\0d\0u\0c\0t\0o\0\0\0Xy\0@E\0Xy\0�[\0�\�\0\0�[\0�\�\0\0�q\0\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0p\0\0\0\0\0\0�\"\0�Y\0�\0\0X\0\03\0\0\0\0\0\0\0�\0\0X\0\0\0\0\0\0\0���\0\0\0�\0\0\0\0\0\0\0�DB\0Tahoma$\0F\0K\0_\0p\0r\0o\0d\0u\0c\0t\0o\0_\0u\0n\0i\0d\0a\0d\0_\0c\0o\0n\0v\0e\0r\0s\0i\0o\0n\0_\0u\0n\0i\0d\0a\0d\0!C4\0\0\0j\0\0�%\0\0xV4\0\0\0\0\0i\0n\0g\0r\0e\0s\0o\0s\0_\0c\0a\0j\0a\0\0\0\nr\�$�\\\n\0\0\0n\0\0\0\0O^j�\0\0\0��\0�\�Q\0\�\0\0\0~V^j\0\0\0\0�}M��\0���\0这(��\0�P^j�\�Q\0g\�$\�Q\0�q�w��\\�����\�w�\�w\0\0\0\0 \�\0\0\0\0\0��\0H&�h%�t\�Q\0B��k\0\0\0L\��h%�\0\0\0h%�v\���\�Q\0=U�k\0\0\0v\��y\���\�Q\0>�\�k\0\0\0y\��\0\0\0\0\0\0\0\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0\r\0\0b!\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\�\0\0\�\0\0�\0\0�\0\0\�\0\0�\0\0H\0\0�\0\0�\0\0�\0\0\0\0\0\0\0\0\0j\0\0�%\0\0\0\0\0\0	\0\0\0	\0\0\0\0\0\0\0\0\0\0\03	\0\0\0\0\0\0\0\0\0�\n\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\n\0\0=\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0v\0\0>&\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\08\0\0�\0\0xV4\0\0\0d\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0i\0n\0g\0r\0e\0s\0o\0s\0_\0c\0a\0j\0a\0\0\0!C4\0\0\0S\0\0�\0\0xV4\0\0\0\0\0i\0n\0g\0r\0e\0s\0o\0s\0_\0c\0o\0n\0c\0e\0p\0t\0o\0s\0\0\0l\0e\0s\0 \0(\0x\08\06\0)\0\\\0M\0i\0c\0r\0o\0s\0o\0f\0t\0 \0S\0Q\0L\0 \0S\0e\0r\0v\0e\0r\0\\\01\01\00\0\\\0T\0o\0o\0l\0s\0\\\0B\0i\0n\0n\0\\\0M\0a\0n\0a\0g\0e\0m\0e\0n\0t\0S\0t\0u\0d\0i\0o\0\\\0T\0o\0o\0l\0s\0\\\0V\0D\0T\0\\\0D\0a\0t\0a\0D\0e\0s\0i\0g\0n\0e\0r\0s\0.\0d\0l\0l\0\\\04\0\0\0C\0o\0l\0l\0e\0c\0t\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0\r\0\0�\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\�\0\0\�\0\0�\0\0�\0\0\�\0\0�\0\0H\0\0�\0\0�\0\0�\0\0\0\0\0\0\0\0\0S\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\n\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\n\0\0=\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0v\0\0>&\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\08\0\0�\0\0xV4\0\0\0n\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0i\0n\0g\0r\0e\0s\0o\0s\0_\0c\0o\0n\0c\0e\0p\0t\0o\0s\0\0\0!C4\0\0\0�\0\0�K\0\0xV4\0\0\0\0\0s\0i\0s\0t\0e\0m\0a\0_\0h\0i\0s\0t\0o\0r\0i\0a\0l\0\0\0m\0b\0o\0\'\0)\0 \0o\0r\0d\0e\0r\0 \0b\0y\0 \0c\0o\0l\0.\0c\0o\0l\0u\0m\0n\0_\0i\0d\0\0\0��߂`\��\�\\\�h\�h\�$\�\�\�p��|�(\��\��\�0\�|�����\��\�\�\�T\�`\��\�\�\�\�\�\\\��\� ��(\�X��d�����\�\�\0\��\�<\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0\r\0\0>&\0\0\0\0\0\0-\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0\�\0\0\�\0\0�\0\0�\0\0\�\0\0�\0\0H\0\0�\0\0�\0\0�\0\0\0\0\0\0\0\0\0�\0\0�K\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�	\0\0\0\0\0\0\0\0\0�\n\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\n\0\0=\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0v\0\0>&\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\08\0\0�\0\0xV4\0\0\0l\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0s\0i\0s\0t\0e\0m\0a\0_\0h\0i\0s\0t\0o\0r\0i\0a\0l\0\0\0\0\0\�r\0\0w�\0\0\�r\0\0\��\0\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0u\0\0\0\0\0\0�d\0\0�\0\0�\r\0\0X\0\02\0\0\0\0\0\0\0�\r\0\0X\0\0\0\0\0\0\0���\0\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0i\0n\0g\0r\0e\0s\0o\0s\0_\0c\0a\0j\0a\0_\0c\0a\0j\0e\0r\0o\0\0\0H\0\0f\0H\0\0��\0\0fl\0\0��\0\0fl\0\0\��\0\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0w\0\0\0\0\0\0�L\0\0��\0\0\�\0\0X\0\02\0\0\0\0\0\0\0\�\0\0X\0\0\0\0\0\0\0���\0\0\0�\0\0\0\0\0\0\0�DB\0Tahoma#\0F\0K\0_\0i\0n\0g\0r\0e\0s\0o\0s\0_\0c\0a\0j\0a\0_\0i\0n\0g\0r\0e\0s\0o\0s\0_\0c\0o\0n\0c\0e\0p\0t\0o\0s\0!C4\0\0\02\0\0\�\0\0xV4\0\0\0\0\0c\0a\0t\0a\0l\0o\0g\0o\0_\0c\0u\0e\0n\0t\0a\0s\0\0\0\\\n\0\0\r\0�\0�\0\0\0\0O%m�\0\0\0�A\0�\�>\0\�\0\0\0~V%m\0\0\0\0\�N�A\0��A\0PjW(�A\0�P%m�\�>\0�_�\�>\0�q{w�m�����\�vw�\�vw\0\0\0\0��P\0\0\0\0\0T�E\0H&Vh%Vl\�>\0B�2i\0\0\0\\!\�h%V\0\0\0h%V�!\��\�>\0=U1i\0\0\0�!\��!\��\�>\0>�0i\0\0\0�!\�\0\0\0\0\0\0\0\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0-\0\0\n\0\0\0\0\0\0\0\0\0\0\0E\0\0(\0\09\0\0\0\0\�\0\0f\0\0\0\0�\0\0\0\0�\0\0F\0\0\0\0\0\0\0\0\02\0\0\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0L\0\0h\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0E\0\0\0\0\0\0\0\0\0L\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0E\0\0\0\0\0\0\0\0\0\0\�$\0\0|$\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0E\0\0q\0\0�\0\0xV4\0\0\0j\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0c\0a\0t\0a\0l\0o\0g\0o\0_\0c\0u\0e\0n\0t\0a\0s\0\0\0!C4\0\0\02\0\0	\0\0xV4\0\0\0\0\0c\0o\0r\0r\0e\0o\0_\0e\0l\0e\0c\0t\0r\0o\0n\0i\0c\0o\0s\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0d^\�d,�\�d\�%e\�\0\�\0�\0�\0�\0�\0�\0�\0�\0�\0�\0�\0�\0�\0�\0�\0�\0�\0@\0P\0@\0P\0@\00\0P\0P\0 \0 \0@\0 \0p\0P\0P\0P\0P\00\00\00\0P\0@\0`\0@\0@\0@\0P\0P\0P\0`\0@\0@\0P\0`\0 \00\0P\0@\0p\0`\0`\0@\0`\0P\0@\0@\0`\0P\0p\0P\0@\0P\0������������������\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�\0\0\�\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0E\0\0(\0\0�\0\09\0\0:\0\0f\0\0\�\0\0\�\0\0\�\0\06\0\08\0\0\0\0\0\0\0\0\02\0\0	\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0L\0\0h\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0E\0\0\0\0\0\0\0\0\0L\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0E\0\0\0\0\0\0\0\0\0\0\�$\0\0|$\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0E\0\0q\0\0�\0\0xV4\0\0\0p\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0c\0o\0r\0r\0e\0o\0_\0e\0l\0e\0c\0t\0r\0o\0n\0i\0c\0o\0s\0\0\0!C4\0\0\0[\0\0�\0\0xV4\0\0\0\0\0p\0r\0o\0d\0u\0c\0t\0o\0_\0p\0r\0o\0d\0u\0c\0t\0o\0s\0_\0r\0e\0q\0u\0i\0s\0i\0t\0o\0s\0\0\0\0\0\0\0\0\0\0\�\\\�dd^\�d\\]\�dHk\�d\0%\�\�\�\�d(k\�dHk\�d�M\�\�\�\�d(k\�dHk\�dd^\�d]\�d\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0U��Հ+\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0+�\�Հ+\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0E\0\0(\0\0\�\0\0g\0\0�\0\0f\0\0�\0\0+\0\0�\0\0�\0\0*\0\0\0\0\0\0\0\0\0[\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0z\r\0\0\0\0\0\0\0\0\0L\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0E\0\0\0\0\0\0\0\0\0L\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0E\0\0\0\0\0\0\0\0\0\0\�$\0\0|$\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0E\0\0q\0\0�\0\0xV4\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0p\0r\0o\0d\0u\0c\0t\0o\0_\0p\0r\0o\0d\0u\0c\0t\0o\0s\0_\0r\0e\0q\0u\0i\0s\0i\0t\0o\0s\0\0\0!C4\0\0\0�\0\0�\0\0xV4\0\0\0\0\0s\0i\0s\0t\0e\0m\0a\0_\0m\0o\0d\0u\0l\0o\0_\0o\0p\0c\0i\0o\0n\0e\0s\0\0\0<j\�\�j\�\�j\�T��<��H��(l\��l\�m\�tm\�\\n\�hn\�\\p\�hp\�8��D�����ظ���\�r\�Ds\��s\��s\�t\�tt\�`��ȹ�Hv\�`v\�pw\�|w\��w\�x\�(x\��x\�y\�ty\�\\z\�hz\�x{\��{\�\0|\��|\�T}\�(~\�D~\�,\�8\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0E\0\0(\0\09\0\0\0\0\�\0\0f\0\0\0\0�\0\0\0\0�\0\0F\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0L\0\0h\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0E\0\0\0\0\0\0\0\0\0L\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0E\0\0\0\0\0\0\0\0\0\0\�$\0\0|$\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0E\0\0q\0\0�\0\0xV4\0\0\0x\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0s\0i\0s\0t\0e\0m\0a\0_\0m\0o\0d\0u\0l\0o\0_\0o\0p\0c\0i\0o\0n\0e\0s\0\0\0!C4\0\0\0�\0\0B\0\0xV4\0\0\0\0\0s\0i\0s\0t\0e\0m\0a\0_\0m\0o\0d\0u\0l\0o\0s\0\0\0\�\�\�\�\�\�\��\���\��x\���\��\���\�\��\�\�\\\�\��\�\��\�\�$\�\��\���\���\�\�\�\�\�\� \�\��\�\��\�\�\�\�\�<\�\��\�\�\�\�\�\�\��\�\��\�\�\0\�\�|\�\�\�\�\�\�\�@\�\�\\\�\�(\�\�4\�\��\�\�\�\�\�\�\�\�P\�\��\�\�\�\�\0\�\�\�\�\�\�\�\��\�\��\�\�\�\�\�D\�\��\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�\0\0B\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0E\0\0(\0\09\0\0\0\0\�\0\0f\0\0\0\0�\0\0\0\0�\0\0F\0\0\0\0\0\0\0\0\02\0\0\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0L\0\0h\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0E\0\0\0\0\0\0\0\0\0L\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0E\0\0\0\0\0\0\0\0\0\0\�$\0\0|$\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0E\0\0q\0\0�\0\0xV4\0\0\0h\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0s\0i\0s\0t\0e\0m\0a\0_\0m\0o\0d\0u\0l\0o\0s\0\0\0!C4\0\0\0\0\0�\0\0xV4\0\0\0\0\0s\0u\0p\0l\0i\0d\0o\0r\0e\0s\0_\0d\0g\0i\0i\0\0\0��\�<�\��\�t�\�\��\�<�\�$�\�0�\���\���\��\�0�\�\\�\�\��\�\��\��\0\��\0\�$\�<\�h\�\�\��\�L\�\0\�8\�D\��\�@\�L\�\�\�D\��\��\�\r\�\�\r\��\r\�p\��\�\0\�p\�\�\�8\��\��\��\��\��\�\�4\�`\�\�\�8\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0E\0\0(\0\09\0\0\0\0\�\0\0f\0\0\0\0�\0\0\0\0�\0\0F\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0L\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0E\0\0\0\0\0\0\0\0\0L\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0E\0\0\0\0\0\0\0\0\0\0\�$\0\0|$\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0E\0\0q\0\0�\0\0xV4\0\0\0h\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0s\0u\0p\0l\0i\0d\0o\0r\0e\0s\0_\0d\0g\0i\0i\0\0\0\0\0�?\0\0Q\0rQ\0\0Q\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�;\0\0\�Q\0\�\0\0X\0\02\0\0\0\0\0\0\0\�\0\0X\0\0\0\0\0\0\0���\0\0\0�\0\0\0\0\0\0\0�DB\0Tahoma*\0F\0K\0_\0s\0i\0s\0t\0e\0m\0a\0_\0m\0o\0d\0u\0l\0o\0_\0o\0p\0c\0i\0o\0n\0e\0s\0_\0s\0i\0s\0t\0e\0m\0a\0_\0m\0o\0d\0u\0l\0o\0s\0\0\0f!\0\0�^\0f!\0\0�R\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\"\0\0&X\0U\0\0X\0\02\0\0\0\0\0\0\0U\0\0X\0\0\0\0\0\0\0���\0\0\0�\0\0\0\0\0\0\0�DB\0Tahoma)\0F\0K\0_\0p\0r\0o\0d\0u\0c\0t\0o\0_\0p\0r\0o\0d\0u\0c\0t\0o\0s\0_\0r\0e\0q\0u\0i\0s\0i\0t\0o\0s\0_\0p\0r\0o\0d\0u\0c\0t\0o\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0��������������������\0\0\0\0\0\0	\0\0\n\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\Z\0\0\0\0\0\0\0\0\0\0\0\0 \0\0!\0\0\"\0\0#\0\0$\0\0%\0\0&\0\0\'\0\0(\0\0)\0\0*\0\0+\0\0,\0\0-\0\0.\0\0/\0\00\0\01\0\02\0\03\0\04\0\05\0\06\0\07\0\08\0\09\0\0:\0\0;\0\0<\0\0=\0\0>\0\0?\0\0@\0\0A\0\0B\0\0C\0\0D\0\0E\0\0F\0\0G\0\0H\0\0I\0\0J\0\0K\0\0L\0\0M\0\0N\0\0O\0\0P\0\0Q\0\0R\0\0S\0\0T\0\0U\0\0V\0\0W\0\0X\0\0Y\0\0Z\0\0[\0\0\\\0\0]\0\0^\0\0_\0\0`\0\0a\0\0b\0\0c\0\0d\0\0e\0\0f\0\0g\0\0h\0\0i\0\0j\0\0k\0\0l\0\0m\0\0n\0\0o\0\0p\0\0q\0\0r\0\0s\0\0t\0\0u\0\0v\0\0w\0\0x\0\0y\0\0z\0\0{\0\0|\0\0}\0\0~\0\0\0\0�\0\0\0\0\0����������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������\0��\n\0\0����\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0Microsoft DDS Form 2.0\0\0\0\0Embedded Object\0\0\0\0\0�9�q\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0Na�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0D\0d\0s\0S\0t\0r\0e\0a\0m\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0����\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�0\0\0\0\0\0S\0c\0h\0e\0m\0a\0 \0U\0D\0V\0 \0D\0e\0f\0a\0u\0l\0t\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0&\0\0������������\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0D\0S\0R\0E\0F\0-\0S\0C\0H\0E\0M\0A\0-\0C\0O\0N\0T\0E\0N\0T\0S\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0,\0\0\0\0\0\0\0����\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0S\0c\0h\0e\0m\0a\0 \0U\0D\0V\0 \0D\0e\0f\0a\0u\0l\0t\0 \0P\0o\0s\0t\0 \0V\06\0\0\0\0\0\0\0\0\0\0\0\0\06\0\0������������\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0�\0\0�\0\0�\0\0�\0\0�\0\0�\0\0�\0\0�\0\0�\0\0�\0\0�\0\0�\0\0�\0\0�\0\0�\0\0�\0\0�\0\0�\0\0�\0\0�\0\0�\0\0�\0\0�\0\0�\0\0�\0\0�\0\0�\0\0�\0\0�����\0\0�\0\0�\0\0�\0\0�\0\0�\0\0�\0\0�\0\0�\0\0�\0\0�\0\0������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������\0\0\0�\0\0*\0\0&\0\0\0s\0c\0h\0_\0l\0a\0b\0e\0l\0s\0_\0v\0i\0s\0i\0b\0l\0e\0\0\0\0\0\0\0��\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0d\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\07\01\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\01\00\00\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\07\07\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\07\07\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0\0\0\0\0\0\0\0\0\0\0.\0\0\0\0\0\0\0\0\0d\0b\0o\0\0\0F\0K\0_\0c\0a\0j\0e\0r\0o\0_\0c\0a\0j\0a\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0j`j\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\00\05\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\07\01\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0	\0\0\0	\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\05\00\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0\n\0\0\0\n\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\01\00\00\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0\0\0\0\0\0\0\0\0\0\0J\0\0\0�\�]\0\0\0d\0b\0o\0\0\0F\0K\0_\0c\0l\0i\0e\0n\0t\0e\0_\0c\0l\0i\0e\0n\0t\0e\0_\0c\0a\0t\0e\0g\0o\0r\0i\0a\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0j j\0\0\0\0\0\0\0\0�\0\0\0\0\0\r\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\05\00\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0\0\0\0\0\0\0\0\0\0\0d\0\0\0�\'\0\0\0\0d\0b\0o\0\0\0F\0K\0_\0c\0l\0i\0e\0n\0t\0e\0_\0s\0u\0b\0c\0a\0t\0e\0g\0o\0r\0i\0a\0_\0c\0l\0i\0e\0n\0t\0e\0_\0c\0a\0t\0e\0g\0o\0r\0i\0a\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0j\�j\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0P\0\0\0�\�]\0\0\0d\0b\0o\0\0\0F\0K\0_\0c\0l\0i\0e\0n\0t\0e\0_\0c\0l\0i\0e\0n\0t\0e\0_\0s\0u\0b\0c\0a\0t\0e\0g\0o\0r\0i\0a\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0j�j\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\07\01\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0\0\0\0\0\0\0\0\0\0\0N\0\0\0�\�]\0\0\0d\0b\0o\0\0\0F\0K\0_\0c\0o\0m\0p\0r\0a\0_\0p\0a\0g\0o\0_\0a\0n\0u\0l\0a\0d\0o\0s\0_\0c\0o\0m\0p\0r\0a\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0\Z\0\0\0\Z\0\0\0\0\0\0\0\0\0�h�h\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\07\01\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0\0\0\0\0\0\0\0\0\0\0D\0\0\0Gu\0\0\0d\0b\0o\0\0\0F\0K\0_\0c\0o\0m\0p\0r\0a\0_\0v\0s\0_\0p\0a\0g\0o\0s\0_\0c\0o\0m\0p\0r\0a\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�h؞h\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\07\01\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0 \0\0\0 \0\0\0\0\0\0\0`\0\0\0\�]\0\0\0d\0b\0o\0\0\0F\0K\0_\0c\0o\0m\0p\0r\0o\0b\0a\0n\0t\0e\0_\0f\0i\0s\0c\0a\0l\0_\0c\0o\0m\0p\0r\0o\0b\0a\0n\0t\0e\0_\0s\0e\0r\0i\0e\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0!\0\0\0!\0\0\0 \0\0\0\0\0\0�h��h\0\0\0\0\0\0\0\0�\0\0\0\0\0\"\0\0\0\"\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\07\01\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0#\0\0\0#\0\0\0\0\0\0\0F\0\0\0Gu\0\0\0d\0b\0o\0\0\0F\0K\0_\0c\0o\0m\0p\0r\0o\0b\0a\0n\0t\0e\0_\0v\0e\0n\0t\0a\0s\0_\0c\0a\0j\0a\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0$\0\0\0$\0\0\0#\0\0\0\0\0\0�hX�h\0\0\0\0\0\0\0\0�\0\0\0\0\0%\0\0\0%\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\00\05\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0&\0\0\0&\0\0\0\0\0\0\0<\0\0\0�\0\0\0\0\0d\0b\0o\0\0\0F\0K\0_\0c\0o\0t\0i\0z\0a\0c\0i\0o\0n\0_\0c\0l\0i\0e\0n\0t\0e\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0\'\0\0\0\'\0\0\0&\0\0\0\0\0\0�h�h\0\0\0\0\0\0\0\0�\0\0\0\0\0(\0\0\0(\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\00\05\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0)\0\0\0)\0\0\0\0\0\0\0T\0\0\0Zl\0\0\0d\0b\0o\0\0\0F\0K\0_\0c\0o\0t\0i\0z\0a\0c\0i\0o\0n\0_\0d\0e\0t\0a\0l\0l\0e\0s\0_\0c\0o\0t\0i\0z\0a\0c\0i\0o\0n\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0*\0\0\0*\0\0\0)\0\0\0\0\0\0�h؝h\0\0\0\0\0\0\0\0�\0\0\0\0\0+\0\0\0+\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\07\09\00\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0,\0\0\0,\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\00\05\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0-\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\07\01\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0.\0\0\0.\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\07\00\00\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0/\0\0\0/\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\07\09\00\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\00\0\0\00\0\0\0\0\0\0\0>\0\0\0�\0\0\0\0\0d\0b\0o\0\0\0F\0K\0_\0e\0g\0r\0e\0s\0o\0s\0_\0c\0a\0j\0a\0_\0c\0a\0j\0e\0r\0o\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\01\0\0\01\0\0\00\0\0\0\0\0\0�h��h\0\0\0\0\0\0\0\0�\0\0\0\0\02\0\0\02\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\00\05\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\03\0\0\03\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\07\07\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\04\0\0\04\0\0\0\0\0\0\0B\0\0\0Gu\0\0\0d\0b\0o\0\0\0F\0K\0_\0e\0m\0p\0l\0e\0a\0d\0o\0_\0d\0e\0p\0a\0r\0t\0a\0m\0e\0n\0t\0o\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\05\0\0\05\0\0\04\0\0\0\0\0\0�hX�h\0\0\0\0\0\0\0\0�\0\0\0\0\06\0\0\06\0\0\0\0\0\0\0@\0\0\0�\0\0\0\0\0d\0b\0o\0\0\0F\0K\0_\0c\0u\0a\0d\0r\0e\0_\0c\0a\0j\0a\0_\0e\0m\0p\0l\0e\0a\0d\0o\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\07\0\0\07\0\0\06\0\0\0\0\0\0�dx�d\0\0\0\0\0\0\0\0�\0\0\0\0\08\0\0\08\0\0\0\0\0\0\06\0\0\0�j\0\0\0d\0b\0o\0\0\0F\0K\0_\0c\0a\0j\0e\0r\0o\0_\0e\0m\0p\0l\0e\0a\0d\0o\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\09\0\0\09\0\0\08\0\0\0\0\0\0�h�h\0\0\0\0\0\0\0\0�\0\0\0\0\0:\0\0\0:\0\0\0\0\0\0\0>\0\0\0�\0\0\0\0\0d\0b\0o\0\0\0F\0K\0_\0c\0o\0t\0i\0z\0a\0c\0i\0o\0n\0_\0e\0m\0p\0l\0e\0a\0d\0o\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0;\0\0\0;\0\0\0:\0\0\0\0\0\0�h؜h\0\0\0\0\0\0\0\0�\0\0\0\0\0<\0\0\0<\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\01\03\00\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0=\0\0\0=\0\0\0\0\0\0\0T\0\0\0Zl\0\0\0d\0b\0o\0\0\0F\0K\0_\0e\0m\0p\0l\0e\0a\0d\0o\0_\0h\0i\0s\0t\0o\0r\0i\0a\0l\0_\0d\0a\0t\0o\0s\0_\0c\0a\0r\0g\0o\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0>\0\0\0>\0\0\0=\0\0\0\0\0\0�h��h\0\0\0\0\0\0\0\0�\0\0\0\0\0?\0\0\0?\0\0\0\0\0\0\0\\\0\0\0\�]\0\0\0d\0b\0o\0\0\0F\0K\0_\0e\0m\0p\0l\0e\0a\0d\0o\0_\0h\0i\0s\0t\0o\0r\0i\0a\0l\0_\0d\0a\0t\0o\0s\0_\0e\0m\0p\0l\0e\0a\0d\0o\01\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0@\0\0\0@\0\0\0?\0\0\0\0\0\0�hX�h\0\0\0\0\0\0\0\0�\0\0\0\0\0A\0\0\0A\0\0\0\0\0\0\0Z\0\0\0\�]\0\0\0d\0b\0o\0\0\0F\0K\0_\0e\0m\0p\0l\0e\0a\0d\0o\0_\0h\0i\0s\0t\0o\0r\0i\0a\0l\0_\0d\0a\0t\0o\0s\0_\0e\0m\0p\0l\0e\0a\0d\0o\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0B\0\0\0B\0\0\0A\0\0\0\0\0\0�h�h\0\0\0\0\0\0\0\0�\0\0\0\0\0C\0\0\0C\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\00\05\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0D\0\0\0D\0\0\0\0\0\0\0F\0\0\0Gu\0\0\0d\0b\0o\0\0\0F\0K\0_\0e\0m\0p\0l\0e\0a\0d\0o\0_\0v\0s\0_\0c\0a\0r\0g\0o\0_\0c\0a\0r\0g\0o\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0E\0\0\0E\0\0\0D\0\0\0\0\0\0�h؛h\0\0\0\0\0\0\0\0�\0\0\0\0\0F\0\0\0F\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\03\06\01\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0G\0\0\0G\0\0\0\0\0\0\0b\0\0\0�\'\0\0\0\0d\0b\0o\0\0\0F\0K\0_\0e\0m\0p\0l\0e\0a\0d\0o\0_\0v\0s\0_\0c\0o\0n\0c\0e\0p\0t\0o\0s\0_\0n\0o\0m\0i\0n\0a\0_\0e\0m\0p\0l\0e\0a\0d\0o\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0H\0\0\0H\0\0\0G\0\0\0\0\0\0�h��h\0\0\0\0\0\0\0\0�\0\0\0\0\0I\0\0\0I\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\07\01\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0J\0\0\0J\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\04\00\00\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0K\0\0\0K\0\0\0\0\0\0\0\\\0\0\0\�]\0\0\0d\0b\0o\0\0\0F\0K\0_\0e\0n\0t\0r\0a\0d\0a\0_\0s\0a\0l\0i\0d\0a\0_\0i\0n\0v\0e\0n\0t\0a\0r\0i\0o\0_\0e\0m\0p\0l\0e\0a\0d\0o\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0L\0\0\0L\0\0\0K\0\0\0\0\0\0KeKe\0\0\0\0\0\0\0\0�\0\0\0\0\0M\0\0\0M\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\00\05\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0N\0\0\0N\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\05\00\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0O\0\0\0O\0\0\0\0\0\0\06\0\0\0�j\0\0\0d\0b\0o\0\0\0F\0K\0_\0f\0a\0c\0t\0u\0r\0a\0_\0c\0l\0i\0e\0n\0t\0e\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0P\0\0\0P\0\0\0O\0\0\0\0\0\0�hX�h\0\0\0\0\0\0\0\0�\0\0\0\0\0Q\0\0\0Q\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\05\00\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0R\0\0\0R\0\0\0\0\0\0\0F\0\0\0Gu\0\0\0d\0b\0o\0\0\0F\0K\0_\0f\0a\0c\0t\0u\0r\0a\0_\0d\0e\0t\0a\0l\0l\0e\0_\0f\0a\0c\0t\0u\0r\0a\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0S\0\0\0S\0\0\0R\0\0\0\0\0\0�h�h\0\0\0\0\0\0\0\0�\0\0\0\0\0T\0\0\0T\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\05\00\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0U\0\0\0U\0\0\0\0\0\0\0J\0\0\0�\�]\0\0\0d\0b\0o\0\0\0F\0K\0_\0f\0a\0c\0t\0u\0r\0a\0s\0_\0a\0n\0u\0l\0a\0d\0a\0s\0_\0f\0a\0c\0t\0u\0r\0a\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0V\0\0\0V\0\0\0U\0\0\0\0\0\0�hؚh\0\0\0\0\0\0\0\0�\0\0\0\0\0W\0\0\0W\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\01\00\00\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0X\0\0\0X\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\01\00\00\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0Y\0\0\0Y\0\0\0\0\0\0\0d\0\0\0�\'\0\0\0\0d\0b\0o\0\0\0F\0K\0_\0g\0r\0u\0p\0o\0_\0u\0s\0u\0a\0r\0i\0o\0s\0_\0p\0e\0r\0m\0i\0s\0o\0s\0_\0g\0r\0u\0p\0o\0_\0u\0s\0u\0a\0r\0i\0o\0s\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0Z\0\0\0Z\0\0\0Y\0\0\0\0\0\0�h��h\0\0\0\0\0\0\0\0�\0\0\0\0\0[\0\0\0[\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\08\06\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0\\\0\0\0\\\0\0\0\0\0\0\0b\0\0\0�\'\0\0\0\0d\0b\0o\0\0\0F\0K\0_\0h\0i\0s\0t\0o\0r\0i\0a\0l\0_\0d\0e\0v\0o\0l\0u\0c\0i\0o\0n\0_\0c\0o\0m\0p\0r\0a\0s\0_\0e\0m\0p\0l\0e\0a\0d\0o\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0]\0\0\0]\0\0\0\\\0\0\0\0\0\0�hX�h\0\0\0\0\0\0\0\0�\0\0\0\0\0^\0\0\0^\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\05\05\00\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0_\0\0\0_\0\0\0\0\0\0\0^\0\0\0\�]\0\0\0d\0b\0o\0\0\0F\0K\0_\0h\0i\0s\0t\0o\0r\0i\0a\0l\0_\0d\0e\0v\0o\0l\0u\0c\0i\0o\0n\0_\0v\0e\0n\0t\0a\0s\0_\0f\0a\0c\0t\0u\0r\0a\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0`\0\0\0`\0\0\0_\0\0\0\0\0\0�h�h\0\0\0\0\0\0\0\0�\0\0\0\0\0a\0\0\0a\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\07\01\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0b\0\0\0b\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\01\00\00\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0c\0\0\0c\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0d\0\0\0d\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\07\01\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0e\0\0\0e\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\00\05\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0f\0\0\0f\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\00\05\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0g\0\0\0g\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\07\01\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0h\0\0\0h\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\07\01\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0i\0\0\0i\0\0\0\0\0\0\0@\0\0\0�\0\0\0\0\0d\0b\0o\0\0\0F\0K\0_\0m\0e\0s\0a\0s\0_\0d\0e\0t\0a\0l\0l\0e\0s\0_\0m\0e\0s\0a\0s\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0j\0\0\0j\0\0\0i\0\0\0\0\0\0�hؙh\0\0\0\0\0\0\0\0�\0\0\0\0\0k\0\0\0k\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\00\05\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0l\0\0\0l\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\00\05\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0m\0\0\0m\0\0\0\0\0\0\0F\0\0\0Gu\0\0\0d\0b\0o\0\0\0F\0K\0_\0m\0o\0n\0e\0d\0a\0_\0h\0i\0s\0t\0o\0r\0i\0a\0l\0_\0m\0o\0n\0e\0d\0a\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0n\0\0\0n\0\0\0m\0\0\0\0\0\0�h��h\0\0\0\0\0\0\0\0�\0\0\0\0\0o\0\0\0o\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0p\0\0\0p\0\0\0\0\0\0\0^\0\0\0\�]\0\0\0d\0b\0o\0\0\0F\0K\0_\0e\0m\0p\0l\0e\0a\0d\0o\0_\0v\0s\0_\0c\0o\0n\0c\0e\0p\0t\0o\0s\0_\0n\0o\0m\0i\0n\0a\0_\0n\0o\0m\0i\0n\0a\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0q\0\0\0q\0\0\0p\0\0\0\0\0\0\�e�\�e\0\0\0\0\0\0\0\0�\0\0\0\0\0r\0\0\0r\0\0\0\0\0\0\06\0\0\0�j\0\0\0d\0b\0o\0\0\0F\0K\0_\0n\0o\0m\0i\0n\0a\0_\0e\0m\0p\0l\0e\0a\0d\0o\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0s\0\0\0s\0\0\0r\0\0\0\0\0\0�hX�h\0\0\0\0\0\0\0\0�\0\0\0\0\0t\0\0\0t\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\07\01\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0u\0\0\0u\0\0\0\0\0\0\0r\0\0\0\0\0\0\0\0d\0b\0o\0\0\0F\0K\0_\0e\0m\0p\0l\0e\0a\0d\0o\0_\0v\0s\0_\0c\0o\0n\0c\0e\0p\0t\0o\0s\0_\0n\0o\0m\0i\0n\0a\0_\0n\0o\0m\0i\0n\0a\0_\0c\0o\0n\0c\0e\0p\0t\0o\0s\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0v\0\0\0v\0\0\0u\0\0\0\0\0\0�h�h\0\0\0\0\0\0\0\0�\0\0\0\0\0w\0\0\0w\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0x\0\0\0x\0\0\0\0\0\0\0B\0\0\0Gu\0\0\0d\0b\0o\0\0\0F\0K\0_\0n\0o\0m\0i\0n\0a\0_\0d\0e\0t\0a\0l\0l\0e\0_\0n\0o\0m\0i\0n\0a\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0y\0\0\0y\0\0\0x\0\0\0\0\0\0�hؘh\0\0\0\0\0\0\0\0�\0\0\0\0\0z\0\0\0z\0\0\0\0\0\0\0V\0\0\0Zl\0\0\0d\0b\0o\0\0\0F\0K\0_\0n\0o\0m\0i\0n\0a\0_\0d\0e\0t\0a\0l\0l\0e\0_\0n\0o\0m\0i\0n\0a\0_\0c\0o\0n\0c\0e\0p\0t\0o\0s\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0{\0\0\0{\0\0\0z\0\0\0\0\0\0�h��h\0\0\0\0\0\0\0\0�\0\0\0\0\0|\0\0\0|\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\07\01\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0}\0\0\0}\0\0\0\0\0\0\0>\0\0\0�\0\0\0\0\0d\0b\0o\0\0\0F\0K\0_\0n\0o\0m\0i\0n\0a\0_\0n\0o\0m\0i\0n\0a\0_\0t\0i\0p\0o\0s\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0~\0\0\0~\0\0\0}\0\0\0\0\0\0\�e�\�e\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\00\05\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0�\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\09\02\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0�\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\07\01\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0�\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\04\07\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0�\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\04\07\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0�\0\0\0�\0\0\0\0\0\0\06\0\0\0�j\0\0\0d\0b\0o\0\0\0F\0K\0_\0p\0e\0d\0i\0d\0o\0s\0_\0c\0l\0i\0e\0n\0t\0e\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0�\0\0\0�\0\0\0�\0\0\0\0\0\0�hX�h\0\0\0\0\0\0\0\0�\0\0\0\0\0�\0\0\0�\0\0\0\0\0\0\0D\0\0\0Gu\0\0\0d\0b\0o\0\0\0F\0K\0_\0p\0e\0d\0i\0d\0o\0_\0d\0e\0t\0a\0l\0l\0e\0_\0p\0e\0d\0i\0d\0o\0s\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0�\0\0\0�\0\0\0�\0\0\0\0\0\0\�e8\�e\0\0\0\0\0\0\0\0�\0\0\0\0\0�\0\0\0�\0\0\0\0\0\0\08\0\0\0�j\0\0\0d\0b\0o\0\0\0F\0K\0_\0p\0e\0d\0i\0d\0o\0s\0_\0e\0m\0p\0l\0e\0a\0d\0o\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0�\0\0\0�\0\0\0�\0\0\0\0\0\0�h�h\0\0\0\0\0\0\0\0�\0\0\0\0\0�\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\07\01\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0�\0\0\0�\0\0\0\0\0\0\0V\0\0\0\0Zl\0\0\0d\0b\0o\0\0\0F\0K\0_\0g\0r\0u\0p\0o\0_\0u\0s\0u\0a\0r\0i\0o\0s\0_\0p\0e\0r\0m\0i\0s\0o\0s\0_\0p\0e\0r\0m\0i\0s\0o\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0�\0\0\0�\0\0\0�\0\0\0\0\0\0Qf(Qf\0\0\0\0\0\0\0\0�\0\0\0\0\0�\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\04\07\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0�\0\0\0�\0\0\0\0\0\0\08\0\0\0�j\0\0\0d\0b\0o\0\0\0F\0K\0_\0e\0m\0p\0l\0e\0a\0d\0o\0_\0p\0e\0r\0s\0o\0n\0a\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0�\0\0\0�\0\0\0�\0\0\0\0\0\0QfhQf\0\0\0\0\0\0\0\0�\0\0\0\0\0�\0\0\0�\0\0\0\0\0\0\06\0\0\0�j\0\0\0d\0b\0o\0\0\0F\0K\0_\0c\0l\0i\0e\0n\0t\0e\0_\0p\0e\0r\0s\0o\0n\0a\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0�\0\0\0�\0\0\0�\0\0\0\0\0\0�hؗh\0\0\0\0\0\0\0\0�\0\0\0\0\0�\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0�\0\0\0�\0\0\0\0\0\0\0D\0\0\0Gu\0\0\0d\0b\0o\0\0\0F\0K\0_\0p\0r\0o\0d\0u\0c\0t\0o\0_\0t\0i\0p\0o\0_\0p\0r\0o\0d\0u\0c\0t\0o\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0�\0\0\0�\0\0\0�\0\0\0\0\0\0Sf(Sf\0\0\0\0\0\0\0\0�\0\0\0\0\0�\0\0\0�\0\0\0\0\0\0\08\0\0\0�j\0\0\0d\0b\0o\0\0\0F\0K\0_\0p\0r\0o\0d\0u\0c\0t\0o\0_\0a\0l\0m\0a\0c\0e\0n\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0�\0\0\0�\0\0\0�\0\0\0\0\0\0SfhSf\0\0\0\0\0\0\0\0�\0\0\0\0\0�\0\0\0�\0\0\0\0\0\0\06\0\0\0�j\0\0\0d\0b\0o\0\0\0F\0K\0_\0p\0r\0o\0d\0u\0c\0t\0o\0_\0i\0t\0e\0b\0i\0s\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0�\0\0\0�\0\0\0�\0\0\0\0\0\0�h��h\0\0\0\0\0\0\0\0�\0\0\0\0\0�\0\0\0�\0\0\0\0\0\0\04\0\0\0�j\0\0\0d\0b\0o\0\0\0F\0K\0_\0c\0o\0m\0b\0o\0_\0p\0r\0o\0d\0u\0c\0t\0o\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0�\0\0\0�\0\0\0�\0\0\0\0\0\0�hX�h\0\0\0\0\0\0\0\0�\0\0\0\0\0�\0\0\0�\0\0\0\0\0\0\0>\0\0\0�\0\0\0\0\0d\0b\0o\0\0\0F\0K\0_\0i\0n\0v\0e\0n\0t\0a\0r\0i\0o\0_\0p\0r\0o\0d\0u\0c\0t\0o\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0�\0\0\0�\0\0\0�\0\0\0\0\0\0�h�h\0\0\0\0\0\0\0\0�\0\0\0\0\0�\0\0\0�\0\0\0\0\0\0\0P\0\0\0�\�]\0\0\0d\0b\0o\0\0\0F\0K\0_\0c\0o\0t\0i\0z\0a\0c\0i\0o\0n\0_\0d\0e\0t\0a\0l\0l\0e\0s\0_\0p\0r\0o\0d\0u\0c\0t\0o\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0�\0\0\0�\0\0\0�\0\0\0\0\0\0�hؖh\0\0\0\0\0\0\0\0�\0\0\0\0\0�\0\0\0�\0\0\0\0\0\0\0b\0\0\0�\'\0\0\0\0d\0b\0o\0\0\0F\0K\0_\0h\0i\0s\0t\0o\0r\0i\0a\0l\0_\0d\0e\0v\0o\0l\0u\0c\0i\0o\0n\0_\0c\0o\0m\0p\0r\0a\0s\0_\0p\0r\0o\0d\0u\0c\0t\0o\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0�\0\0\0�\0\0\0�\0\0\0\0\0\0�h��h\0\0\0\0\0\0\0\0�\0\0\0\0\0�\0\0\0�\0\0\0\0\0\0\0b\0\0\0�\'\0\0\0\0d\0b\0o\0\0\0F\0K\0_\0h\0i\0s\0t\0o\0r\0i\0a\0l\0_\0i\0n\0v\0e\0n\0t\0a\0r\0i\0o\0_\0a\0g\0o\0t\0a\0d\0o\0_\0p\0r\0o\0d\0u\0c\0t\0o\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0�\0\0\0�\0\0\0�\0\0\0\0\0\0�hX�h\0\0\0\0\0\0\0\0�\0\0\0\0\0�\0\0\0�\0\0\0\0\0\0\0`\0\0\0\�]\0\0\0d\0b\0o\0\0\0F\0K\0_\0h\0i\0s\0t\0o\0r\0i\0a\0l\0_\0d\0e\0v\0o\0l\0u\0c\0i\0o\0n\0_\0v\0e\0n\0t\0a\0s\0_\0p\0r\0o\0d\0u\0c\0t\0o\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0�\0\0\0�\0\0\0�\0\0\0\0\0\0�h�h\0\0\0\0\0\0\0\0�\0\0\0\0\0�\0\0\0�\0\0\0\0\0\0\0F\0\0\0Gu\0\0\0d\0b\0o\0\0\0F\0K\0_\0p\0e\0d\0i\0d\0o\0_\0d\0e\0t\0a\0l\0l\0e\0_\0p\0r\0o\0d\0u\0c\0t\0o\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0�\0\0\0�\0\0\0�\0\0\0\0\0\0�hؕh\0\0\0\0\0\0\0\0�\0\0\0\0\0�\0\0\0�\0\0\0\0\0\0\0H\0\0\0Gu\0\0\0d\0b\0o\0\0\0F\0K\0_\0f\0a\0c\0t\0u\0r\0a\0_\0d\0e\0t\0a\0l\0l\0e\0_\0p\0r\0o\0d\0u\0c\0t\0o\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0�\0\0\0�\0\0\0�\0\0\0\0\0\0�h��h\0\0\0\0\0\0\0\0�\0\0\0\0\0�\0\0\0�\0\0\0\0\0\0\0N\0\0\0�\�]\0\0\0d\0b\0o\0\0\0F\0K\0_\0c\0o\0m\0p\0r\0a\0_\0v\0s\0_\0p\0r\0o\0d\0u\0c\0t\0o\0_\0p\0r\0o\0d\0u\0c\0t\0o\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0�\0\0\0�\0\0\0�\0\0\0\0\0\0�hX�h\0\0\0\0\0\0\0\0�\0\0\0\0\0�\0\0\0�\0\0\0\0\0\0\0\\\0\0\0\�]\0\0\0d\0b\0o\0\0\0F\0K\0_\0e\0n\0t\0r\0a\0d\0a\0_\0s\0a\0l\0i\0d\0a\0_\0i\0n\0v\0e\0n\0t\0a\0r\0i\0o\0_\0p\0r\0o\0d\0u\0c\0t\0o\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0�\0\0\0�\0\0\0�\0\0\0\0\0\0�h�h\0\0\0\0\0\0\0\0�\0\0\0\0\0�\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\07\01\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0�\0\0\0�\0\0\0\0\0\0\0R\0\0\0Zl\0\0\0d\0b\0o\0\0\0F\0K\0_\0p\0r\0o\0d\0u\0c\0t\0o\0_\0c\0o\0d\0i\0g\0o\0b\0a\0r\0r\0a\0_\0p\0r\0o\0d\0u\0c\0t\0o\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0�\0\0\0�\0\0\0�\0\0\0\0\0\0�hؔh\0\0\0\0\0\0\0\0�\0\0\0\0\0�\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\07\01\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0�\0\0\0�\0\0\0\0\0\0\0V\0\0\0\0Zl\0\0\0d\0b\0o\0\0\0F\0K\0_\0m\0e\0s\0a\0s\0_\0d\0e\0t\0a\0l\0l\0e\0s\0_\0p\0r\0o\0d\0u\0c\0t\0o\0_\0d\0e\0t\0a\0l\0l\0e\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0�\0\0\0�\0\0\0�\0\0\0\0\0\0�h��h\0\0\0\0\0\0\0\0�\0\0\0\0\0�\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\00\05\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0�\0\0\0�\0\0\0\0\0\0\0v\0\0\0\0\0\0\0\0d\0b\0o\0\0\0F\0K\0_\0o\0f\0e\0r\0t\0a\0_\0p\0r\0o\0d\0u\0c\0t\0o\0_\0s\0u\0b\0c\0a\0t\0e\0_\0d\0e\0t\0a\0l\0l\0e\0_\0p\0r\0o\0d\0u\0c\0t\0o\0_\0o\0f\0e\0r\0t\0a\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0�\0\0\0�\0\0\0�\0\0\0\0\0\0�hX�h\0\0\0\0\0\0\0\0�\0\0\0\0\0�\0\0\0�\0\0\0\0\0\0\0f\0\0\0�\'\0\0\0\0d\0b\0o\0\0\0F\0K\0_\0o\0f\0e\0r\0t\0a\0_\0p\0r\0o\0d\0u\0c\0t\0o\0_\0d\0e\0t\0a\0l\0l\0e\0_\0p\0r\0o\0d\0u\0c\0t\0o\0_\0o\0f\0e\0r\0t\0a\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0�\0\0\0�\0\0\0�\0\0\0\0\0\0�h�h\0\0\0\0\0\0\0\0�\0\0\0\0\0�\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\01\00\00\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0�\0\0\0�\0\0\0\0\0\0\0j\0\0\0�\�]\0\0\0d\0b\0o\0\0\0F\0K\0_\0p\0r\0o\0d\0u\0c\0t\0o\0_\0o\0f\0e\0r\0t\0a\0_\0h\0i\0s\0t\0o\0r\0i\0a\0l\0_\0p\0r\0o\0d\0u\0c\0t\0o\0_\0o\0f\0e\0r\0t\0a\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0�\0\0\0�\0\0\0�\0\0\0\0\0\0�hؓh\0\0\0\0\0\0\0\0�\0\0\0\0\0�\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\00\05\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0�\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\07\01\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0�\0\0\0�\0\0\0\0\0\0\0H\0\0\0Gu\0\0\0d\0b\0o\0\0\0F\0K\0_\0p\0r\0o\0d\0u\0c\0t\0o\0_\0u\0n\0i\0d\0a\0d\0_\0p\0r\0o\0d\0u\0c\0t\0o\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0�\0\0\0�\0\0\0�\0\0\0\0\0\0�h��h\0\0\0\0\0\0\0\0�\0\0\0\0\0�\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\05\00\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0\�\0\0\0\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\07\01\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0\�\0\0\0\�\0\0\0\0\0\0\0h\0\0\0�\'\0\0\0\0d\0b\0o\0\0\0F\0K\0_\0p\0r\0o\0d\0u\0c\0t\0o\0_\0d\0e\0t\0a\0l\0l\0e\0_\0p\0r\0o\0d\0u\0c\0t\0o\0_\0e\0s\0p\0e\0c\0i\0f\0i\0c\0a\0c\0i\0o\0n\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0\�\0\0\0\�\0\0\0\�\0\0\0\0\0\0�hX�h\0\0\0\0\0\0\0\0�\0\0\0\0\0\�\0\0\0\�\0\0\0\0\0\0\0J\0\0\0�\�]\0\0\0d\0b\0o\0\0\0F\0K\0_\0p\0r\0o\0d\0u\0c\0t\0o\0_\0d\0e\0t\0a\0l\0l\0e\0_\0p\0r\0o\0d\0u\0c\0t\0o\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0\�\0\0\0\�\0\0\0\�\0\0\0\0\0\0�h�h\0\0\0\0\0\0\0\0�\0\0\0\0\0\�\0\0\0\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\00\05\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0\�\0\0\0\�\0\0\0\0\0\0\0d\0\0\0\'\0\0\0\0d\0b\0o\0\0\0F\0K\0_\0p\0r\0o\0d\0u\0c\0t\0o\0_\0v\0s\0_\0p\0e\0r\0m\0i\0s\0o\0s\0_\0p\0r\0o\0d\0u\0c\0t\0o\0_\0p\0e\0r\0m\0i\0s\0o\0s\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0\�\0\0\0\�\0\0\0\�\0\0\0\0\0\0�hؒh\0\0\0\0\0\0\0\0�\0\0\0\0\0\�\0\0\0\�\0\0\0\0\0\0\0R\0\0\0Zl\0\0\0d\0b\0o\0\0\0F\0K\0_\0p\0r\0o\0d\0u\0c\0t\0o\0_\0v\0s\0_\0p\0e\0r\0m\0i\0s\0o\0s\0_\0p\0r\0o\0d\0u\0c\0t\0o\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0\�\0\0\0\�\0\0\0\�\0\0\0\0\0\0dfhdf\0\0\0\0\0\0\0\0�\0\0\0\0\0\�\0\0\0\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\07\01\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0\�\0\0\0\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\07\01\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0\�\0\0\0\�\0\0\0\0\0\0\08\0\0\0�j\0\0\0d\0b\0o\0\0\0F\0K\0_\0p\0r\0o\0v\0i\0n\0c\0i\0a\0_\0r\0e\0g\0i\0o\0n\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0\�\0\0\0\�\0\0\0\�\0\0\0\0\0\0�h��h\0\0\0\0\0\0\0\0�\0\0\0\0\0\�\0\0\0\�\0\0\0\0\0\0\0.\0\0\0\0\0\0\0\0d\0b\0o\0\0\0F\0K\0_\0r\0e\0g\0i\0o\0n\0_\0p\0a\0i\0s\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0\�\0\0\0\�\0\0\0\�\0\0\0\0\0\0ff(ff\0\0\0\0\0\0\0\0�\0\0\0\0\0\�\0\0\0\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\07\01\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0\�\0\0\0\�\0\0\0\0\0\0\08\0\0\0�j\0\0\0d\0b\0o\0\0\0F\0K\0_\0s\0e\0c\0t\0o\0r\0_\0p\0r\0o\0v\0i\0n\0c\0i\0a\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0\�\0\0\0\�\0\0\0\�\0\0\0\0\0\0ffhff\0\0\0\0\0\0\0\0�\0\0\0\0\0\�\0\0\0\�\0\0\0\0\0\0\08\0\0\0�j\0\0\0d\0b\0o\0\0\0F\0K\0_\0d\0i\0r\0e\0c\0c\0i\0o\0n\0_\0s\0e\0c\0t\0o\0r\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0\�\0\0\0\�\0\0\0\�\0\0\0\0\0\0�hX�h\0\0\0\0\0\0\0\0�\0\0\0\0\0\�\0\0\0\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\01\08\00\00\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0\�\0\0\0\�\0\0\0\0\0\0\00\0\0\0\0\0\0\0\0\0d\0b\0o\0\0\0F\0K\0_\0p\0e\0r\0s\0o\0n\0a\0_\0s\0e\0x\0o\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0\�\0\0\0\�\0\0\0\�\0\0\0\0\0\0�h�h\0\0\0\0\0\0\0\0�\0\0\0\0\0\�\0\0\0\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\00\05\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0\�\0\0\0\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\00\05\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0\�\0\0\0\�\0\0\0\0\0\0\0n\0\0\0�\�]\0\0\0d\0b\0o\0\0\0F\0K\0_\0e\0m\0p\0l\0e\0a\0d\0o\0_\0h\0i\0s\0t\0o\0r\0i\0a\0l\0_\0d\0a\0t\0o\0s\0_\0s\0i\0t\0u\0a\0c\0i\0o\0n\0_\0e\0m\0p\0l\0e\0a\0d\0o\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0\�\0\0\0\�\0\0\0\�\0\0\0\0\0\0�hؑh\0\0\0\0\0\0\0\0�\0\0\0\0\0\�\0\0\0\�\0\0\0\0\0\0\0N\0\0\0�\�]\0\0\0d\0b\0o\0\0\0F\0K\0_\0e\0m\0p\0l\0e\0a\0d\0o\0_\0s\0i\0t\0u\0a\0c\0i\0o\0n\0_\0e\0m\0p\0l\0e\0a\0d\0o\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0\�\0\0\0\�\0\0\0\�\0\0\0\0\0\0�h��h\0\0\0\0\0\0\0\0�\0\0\0\0\0\�\0\0\0\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\07\01\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0\�\0\0\0\�\0\0\0\0\0\0\0T\0\0\0Zl\0\0\0d\0b\0o\0\0\0F\0K\0_\0p\0r\0o\0d\0u\0c\0t\0o\0_\0s\0u\0b\0c\0a\0t\0e\0g\0o\0r\0i\0a\0_\0p\0r\0o\0d\0u\0c\0t\0o\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0\�\0\0\0\�\0\0\0\�\0\0\0\0\0\0�hX�h\0\0\0\0\0\0\0\0�\0\0\0\0\0\�\0\0\0\�\0\0\0\0\0\0\0h\0\0\0\0\'\0\0\0\0d\0b\0o\0\0\0F\0K\0_\0s\0u\0b\0c\0a\0t\0e\0g\0o\0r\0i\0a\0_\0p\0r\0o\0d\0u\0c\0t\0o\0_\0c\0a\0t\0e\0g\0o\0r\0i\0a\0_\0p\0r\0o\0d\0u\0c\0t\0o\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0\�\0\0\0\�\0\0\0\�\0\0\0\0\0\0�h�h\0\0\0\0\0\0\0\0�\0\0\0\0\0\�\0\0\0\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\07\01\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0\�\0\0\0\�\0\0\0\0\0\0\0>\0\0\0\0\0\0\0\0\0d\0b\0o\0\0\0F\0K\0_\0c\0o\0t\0i\0z\0a\0c\0i\0o\0n\0_\0s\0u\0c\0u\0r\0s\0a\0l\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0\�\0\0\0\�\0\0\0\�\0\0\0\0\0\0nf(nf\0\0\0\0\0\0\0\0�\0\0\0\0\0\�\0\0\0\�\0\0\0\0\0\0\06\0\0\0�j\0\0\0d\0b\0o\0\0\0F\0K\0_\0c\0o\0m\0p\0r\0a\0_\0s\0u\0c\0u\0r\0s\0a\0l\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0\�\0\0\0\�\0\0\0\�\0\0\0\0\0\0�g �g\0\0\0\0\0\0\0\0�\0\0\0\0\0\�\0\0\0\�\0\0\0\0\0\0\08\0\0\0�j\0\0\0d\0b\0o\0\0\0F\0K\0_\0p\0e\0d\0i\0d\0o\0s\0_\0s\0u\0c\0u\0r\0s\0a\0l\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0\�\0\0\0\�\0\0\0\�\0\0\0\0\0\0�hؐh\0\0\0\0\0\0\0\0�\0\0\0\0\0\�\0\0\0\�\0\0\0\0\0\0\0:\0\0\0\0\0\0\0\0\0d\0b\0o\0\0\0F\0K\0_\0e\0m\0p\0l\0e\0a\0d\0o\0_\0s\0u\0c\0u\0r\0s\0a\0l\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0\�\0\0\0\�\0\0\0\�\0\0\0\0\0\0�g`�g\0\0\0\0\0\0\0\0�\0\0\0\0\0\�\0\0\0\�\0\0\0\0\0\0\06\0\0\0�j\0\0\0d\0b\0o\0\0\0F\0K\0_\0n\0o\0m\0i\0n\0a\0_\0s\0u\0c\0u\0r\0s\0a\0l\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0\�\0\0\0\�\0\0\0\�\0\0\0\0\0\0�h��h\0\0\0\0\0\0\0\0�\0\0\0\0\0�\0\0\0�\0\0\0\0\0\0\0:\0\0\0\0\0\0\0\0\0d\0b\0o\0\0\0F\0K\0_\0s\0u\0c\0u\0r\0s\0a\0l\0_\0e\0m\0p\0r\0e\0s\0a\01\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0�\0\0\0�\0\0\0�\0\0\0\0\0\0�g��g\0\0\0\0\0\0\0\0�\0\0\0\0\0�\0\0\0�\0\0\0\0\0\0\08\0\0\0�j\0\0\0d\0b\0o\0\0\0F\0K\0_\0a\0l\0m\0a\0c\0e\0n\0_\0s\0u\0c\0u\0r\0s\0a\0l\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0�\0\0\0�\0\0\0�\0\0\0\0\0\0�hX�h\0\0\0\0\0\0\0\0�\0\0\0\0\0�\0\0\0�\0\0\0\0\0\0\0B\0\0\0Gu\0\0\0d\0b\0o\0\0\0F\0K\0_\0d\0e\0p\0a\0r\0t\0a\0m\0e\0n\0t\0o\0_\0s\0u\0c\0u\0r\0s\0a\0l\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0�\0\0\0�\0\0\0�\0\0\0\0\0\0�h�h\0\0\0\0\0\0\0\0�\0\0\0\0\0�\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\07\01\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0�\0\0\0�\0\0\0\0\0\0\0R\0\0\0Zl\0\0\0d\0b\0o\0\0\0F\0K\0_\0s\0u\0c\0u\0r\0s\0a\0l\0_\0v\0s\0_\0e\0m\0p\0l\0e\0a\0d\0o\0_\0e\0m\0p\0l\0e\0a\0d\0o\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0�\0\0\0�\0\0\0�\0\0\0\0\0\0�h؏h\0\0\0\0\0\0\0\0�\0\0\0\0\0�\0\0\0�\0\0\0\0\0\0\0R\0\0\0Zl\0\0\0d\0b\0o\0\0\0F\0K\0_\0s\0u\0c\0u\0r\0s\0a\0l\0_\0v\0s\0_\0e\0m\0p\0l\0e\0a\0d\0o\0_\0s\0u\0c\0u\0r\0s\0a\0l\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0�\0\0\0�\0\0\0�\0\0\0\0\0\0�g\��g\0\0\0\0\0\0\0\0�\0\0\0\0\0�\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\07\01\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0�\0\0\0�\0\0\0\0\0\0\08\0\0\0�j\0\0\0d\0b\0o\0\0\0F\0K\0_\0s\0u\0p\0l\0i\0d\0o\0r\0_\0p\0e\0r\0s\0o\0n\0a\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0�\0\0\0�\0\0\0�\0\0\0\0\0\0�g �g\0\0\0\0\0\0\0\0�\0\0\0\0\0�\0\0\0�\0\0\0\0\0\0\06\0\0\0�j\0\0\0d\0b\0o\0\0\0F\0K\0_\0c\0o\0m\0p\0r\0a\0_\0s\0u\0p\0l\0i\0d\0o\0r\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0�\0\0\0�\0\0\0�\0\0\0\0\0\0�h��h\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\00\05\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\01\00\00\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0\0\0\0\0\0\0\0\06\0\0\0�j\0\0\0d\0b\0o\0\0\0F\0K\0_\0e\0m\0p\0r\0e\0s\0a\0_\0t\0e\0r\0c\0e\0r\0o\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0\0\0\0\0\0\0\0\0\0�h�h\0\0\0\0\0\0\0\0�\0\0\0\0\0	\0\0	\0\0\0\0\0\0F\0\0\0Gu\0\0\0d\0b\0o\0\0\0F\0K\0_\0i\0d\0e\0n\0t\0i\0f\0i\0c\0a\0c\0i\0o\0n\0_\0t\0e\0r\0c\0e\0r\0o\01\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0\n\0\0\n\0\0	\0\0\0\0\0�g �g\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\06\0\0\0�j\0\0\0d\0b\0o\0\0\0F\0K\0_\0p\0e\0r\0s\0o\0n\0a\0_\0t\0e\0r\0c\0e\0r\0o\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0\0\0\0\0\0\0\0\0\0�g`�g\0\0\0\0\0\0\0\0�\0\0\0\0\0\r\0\0\r\0\0\0\0\0\08\0\0\0�j\0\0\0d\0b\0o\0\0\0F\0K\0_\0s\0u\0p\0l\0i\0d\0o\0r\0_\0t\0e\0r\0c\0e\0r\0o\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0\0\0\0\0\r\0\0\0\0\0�g��g\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\02\0\0\0j\0\0\0d\0b\0o\0\0\0F\0K\0_\0b\0a\0n\0c\0o\0_\0t\0e\0r\0c\0e\0r\0o\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0\0\0\0\0\0\0\0\0\0�h؎h\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0\0\0\0\0\0\0\0\0R\0\0\0Zl\0\0\0d\0b\0o\0\0\0F\0K\0_\0t\0e\0r\0c\0e\0r\0o\0_\0o\0b\0s\0e\0r\0v\0a\0c\0i\0o\0n\0e\0s\0_\0t\0e\0r\0c\0e\0r\0o\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0\0\0\0\0\0\0\0\0\0�h��h\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\07\01\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0\0\0\0\0\0\0\0\0T\0\0\0Zl\0\0\0d\0b\0o\0\0\0F\0K\0_\0t\0e\0r\0c\0e\0r\0o\0_\0v\0s\0_\0d\0i\0r\0e\0c\0c\0i\0o\0n\0_\0d\0i\0r\0e\0c\0c\0i\0o\0n\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0\0\0\0\0\0\0\0\0\0�hX�h\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0P\0\0\0�\�]\0\0\0d\0b\0o\0\0\0F\0K\0_\0t\0e\0r\0c\0e\0r\0o\0_\0v\0s\0_\0d\0i\0r\0e\0c\0c\0i\0o\0n\0_\0t\0e\0r\0c\0e\0r\0o\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0\0\0\0\0\0\0\0\0\0�h�h\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\01\00\00\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0\Z\0\0\Z\0\0\0\0\0\0H\0\0\0Gu\0\0\0d\0b\0o\0\0\0F\0K\0_\0t\0e\0r\0c\0e\0r\0o\0_\0v\0s\0_\0e\0m\0a\0i\0l\0_\0t\0e\0r\0c\0e\0r\0o\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0\0\0\0\0\Z\0\0\0\0\0�h؍h\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\07\01\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0\0\0\0\0\0\0\0\0L\0\0\0�\�]\0\0\0d\0b\0o\0\0\0F\0K\0_\0t\0e\0r\0c\0e\0r\0o\0_\0v\0s\0_\0p\0e\0r\0m\0i\0s\0o\0_\0p\0e\0r\0m\0i\0s\0o\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0\0\0\0\0\0\0\0\0\0�h��h\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0L\0\0\0�\�]\0\0\0d\0b\0o\0\0\0F\0K\0_\0t\0e\0r\0c\0e\0r\0o\0_\0v\0s\0_\0p\0e\0r\0m\0i\0s\0o\0_\0t\0e\0r\0c\0e\0r\0o\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0 \0\0 \0\0\0\0\0\0\0�hX�h\0\0\0\0\0\0\0\0�\0\0\0\0\0!\0\0!\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\01\00\00\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0\"\0\0\"\0\0\0\0\0\0N\0\0\0\�]\0\0\0d\0b\0o\0\0\0F\0K\0_\0t\0e\0r\0v\0e\0r\0o\0_\0v\0s\0_\0t\0e\0l\0e\0f\0o\0n\0o\0_\0t\0e\0r\0c\0e\0r\0o\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0#\0\0#\0\0\"\0\0\0\0\0�h�h\0\0\0\0\0\0\0\0�\0\0\0\0\0$\0\0$\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\07\09\00\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0%\0\0%\0\0\0\0\0\0l\0\0\0�\�]\0\0\0d\0b\0o\0\0\0F\0K\0_\0c\0o\0m\0p\0r\0o\0b\0a\0n\0t\0e\0_\0f\0i\0s\0c\0a\0l\0_\0t\0i\0p\0o\0_\0c\0o\0m\0p\0r\0o\0b\0a\0n\0t\0e\0_\0f\0i\0s\0c\0a\0l\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0&\0\0&\0\0%\0\0\0\0\0�h،h\0\0\0\0\0\0\0\0�\0\0\0\0\0\'\0\0\'\0\0\0\0\0\0l\0\0\0�\�]\0\0\0d\0b\0o\0\0\0F\0K\0_\0c\0o\0m\0p\0r\0o\0b\0a\0n\0t\0e\0_\0v\0e\0n\0t\0a\0s\0_\0t\0i\0p\0o\0_\0c\0o\0m\0p\0r\0o\0b\0a\0n\0t\0e\0_\0f\0i\0s\0c\0a\0l\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0(\0\0(\0\0\'\0\0\0\0\0�h��h\0\0\0\0\0\0\0\0�\0\0\0\0\0)\0\0)\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\00\05\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0*\0\0*\0\0\0\0\0\0`\0\0\0\�]\0\0\0d\0b\0o\0\0\0F\0K\0_\0c\0u\0e\0n\0t\0a\0_\0b\0a\0n\0c\0a\0r\0i\0a\0_\0t\0i\0p\0o\0_\0c\0u\0e\0n\0t\0a\0_\0b\0a\0n\0c\0a\0r\0i\0a\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0+\0\0+\0\0*\0\0\0\0\0�hX�h\0\0\0\0\0\0\0\0�\0\0\0\0\0,\0\0,\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\01\00\00\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0-\0\0-\0\0\0\0\0\0\\\0\0\0\�]\0\0\0d\0b\0o\0\0\0F\0K\0_\0i\0d\0e\0n\0t\0i\0f\0i\0c\0a\0c\0i\0o\0n\0_\0t\0i\0p\0o\0_\0i\0d\0e\0n\0t\0i\0f\0i\0c\0a\0c\0i\0o\0n\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0.\0\0.\0\0-\0\0\0\0\0�h�h\0\0\0\0\0\0\0\0�\0\0\0\0\0/\0\0/\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\03\01\02\00\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\00\0\00\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\01\0\01\0\0\0\0\0\0j\0\0\0�\�]\0\0\0d\0b\0o\0\0\0F\0K\0_\0h\0i\0s\0t\0o\0r\0i\0a\0l\0_\0m\0o\0v\0i\0m\0i\0e\0n\0t\0o\0s\0_\0i\0n\0v\0e\0n\0t\0a\0r\0i\0o\0_\0p\0r\0o\0d\0u\0c\0t\0o\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\02\0\02\0\01\0\0\0\0\0�h؋h\0\0\0\0\0\0\0\0�\0\0\0\0\03\0\03\0\0\0\0\0\0h\0\0\0\'\0\0\0\0d\0b\0o\0\0\0F\0K\0_\0h\0i\0s\0t\0o\0r\0i\0a\0l\0_\0m\0o\0v\0i\0m\0i\0e\0n\0t\0o\0s\0_\0i\0n\0v\0e\0n\0t\0a\0r\0i\0o\0_\0a\0l\0m\0a\0c\0e\0n\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\04\0\04\0\03\0\0\0\0\0�h��h\0\0\0\0\0\0\0\0�\0\0\0\0\05\0\05\0\0\0\0\0\0j\0\0\0�\�]\0\0\0d\0b\0o\0\0\0F\0K\0_\0h\0i\0s\0t\0o\0r\0i\0a\0l\0_\0m\0o\0v\0i\0m\0i\0e\0n\0t\0o\0s\0_\0i\0n\0v\0e\0n\0t\0a\0r\0i\0o\0_\0a\0l\0m\0a\0c\0e\0n\01\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\06\0\06\0\05\0\0\0\0\0�hX�h\0\0\0\0\0\0\0\0�\0\0\0\0\07\0\07\0\0\0\0\0\0Z\0\0\0\�]\0\0\0d\0b\0o\0\0\0F\0K\0_\0t\0r\0a\0n\0s\0f\0e\0r\0e\0n\0c\0i\0a\0_\0i\0n\0v\0e\0n\0t\0a\0r\0i\0o\0_\0s\0u\0c\0u\0r\0s\0a\0l\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\08\0\08\0\07\0\0\0\0\0�h�h\0\0\0\0\0\0\0\0�\0\0\0\0\09\0\09\0\0\0\0\0\0\\\0\0\0\�]\0\0\0d\0b\0o\0\0\0F\0K\0_\0t\0r\0a\0n\0s\0f\0e\0r\0e\0n\0c\0i\0a\0_\0i\0n\0v\0e\0n\0t\0a\0r\0i\0o\0_\0s\0u\0c\0u\0r\0s\0a\0l\01\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0:\0\0:\0\09\0\0\0\0\0�h؊h\0\0\0\0\0\0\0\0�\0\0\0\0\0;\0\0;\0\0\0\0\0\0�\0\0\0\0\�]\0\0\0d\0b\0o\0\0\0F\0K\0_\0h\0i\0s\0t\0o\0r\0i\0a\0l\0_\0m\0o\0v\0i\0m\0i\0e\0n\0t\0o\0s\0_\0i\0n\0v\0e\0n\0t\0a\0r\0i\0o\0_\0t\0i\0p\0o\0_\0m\0o\0v\0i\0m\0i\0e\0n\0t\0o\0_\0i\0n\0v\0e\0n\0t\0a\0r\0i\0o\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0<\0\0<\0\0;\0\0\0\0\0�h��h\0\0\0\0\0\0\0\0�\0\0\0\0\0=\0\0=\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\07\01\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0>\0\0>\0\0\0\0\0\0B\0\0\0Gu\0\0\0d\0b\0o\0\0\0F\0K\0_\0p\0e\0d\0i\0d\0o\0_\0d\0e\0t\0a\0l\0l\0e\0_\0u\0n\0i\0d\0a\0d\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0?\0\0?\0\0>\0\0\0\0\0�hX�h\0\0\0\0\0\0\0\0�\0\0\0\0\0@\0\0@\0\0\0\0\0\0\\\0\0\0\�]\0\0\0d\0b\0o\0\0\0F\0K\0_\0h\0i\0s\0t\0o\0r\0i\0a\0l\0_\0d\0e\0v\0o\0l\0u\0c\0i\0o\0n\0_\0v\0e\0n\0t\0a\0s\0_\0u\0n\0i\0d\0a\0d\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0A\0\0A\0\0@\0\0\0\0\0�h�h\0\0\0\0\0\0\0\0�\0\0\0\0\0D\0\0D\0\0\0\0\0\0^\0\0\0\�]\0\0\0d\0b\0o\0\0\0F\0K\0_\0h\0i\0s\0t\0o\0r\0i\0a\0l\0_\0i\0n\0v\0e\0n\0t\0a\0r\0i\0o\0_\0a\0g\0o\0t\0a\0d\0o\0_\0u\0n\0i\0d\0a\0d\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0E\0\0E\0\0D\0\0\0\0\0�h��h\0\0\0\0\0\0\0\0�\0\0\0\0\0F\0\0F\0\0\0\0\0\0^\0\0\0\�]\0\0\0d\0b\0o\0\0\0F\0K\0_\0h\0i\0s\0t\0o\0r\0i\0a\0l\0_\0d\0e\0v\0o\0l\0u\0c\0i\0o\0n\0_\0c\0o\0m\0p\0r\0a\0s\0_\0u\0n\0i\0d\0a\0d\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0G\0\0G\0\0F\0\0\0\0\0�hX�h\0\0\0\0\0\0\0\0�\0\0\0\0\0H\0\0H\0\0\0\0\0\0N\0\0\0\0\�]\0\0\0d\0b\0o\0\0\0F\0K\0_\0p\0r\0o\0d\0u\0c\0t\0o\0_\0c\0o\0d\0i\0g\0o\0b\0a\0r\0r\0a\0_\0u\0n\0i\0d\0a\0d\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0I\0\0I\0\0H\0\0\0\0\0�h�h\0\0\0\0\0\0\0\0�\0\0\0\0\0J\0\0J\0\0\0\0\0\0D\0\0\0Gu\0\0\0d\0b\0o\0\0\0F\0K\0_\0f\0a\0c\0t\0u\0r\0a\0_\0d\0e\0t\0a\0l\0l\0e\0_\0u\0n\0i\0d\0a\0d\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0K\0\0K\0\0J\0\0\0\0\0�h؈h\0\0\0\0\0\0\0\0�\0\0\0\0\0L\0\0L\0\0\0\0\0\0:\0\0\0\0\0\0\0\0\0d\0b\0o\0\0\0F\0K\0_\0i\0n\0v\0e\0n\0t\0a\0r\0i\0o\0_\0u\0n\0i\0d\0a\0d\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0M\0\0M\0\0L\0\0\0\0\0�h��h\0\0\0\0\0\0\0\0�\0\0\0\0\0N\0\0N\0\0\0\0\0\0L\0\0\0\�]\0\0\0d\0b\0o\0\0\0F\0K\0_\0c\0o\0t\0i\0z\0a\0c\0i\0o\0n\0_\0d\0e\0t\0a\0l\0l\0e\0s\0_\0u\0n\0i\0d\0a\0d\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0O\0\0O\0\0N\0\0\0\0\0�hX�h\0\0\0\0\0\0\0\0�\0\0\0\0\0P\0\0P\0\0\0\0\0\0D\0\0\0Gu\0\0\0d\0b\0o\0\0\0F\0K\0_\0p\0r\0o\0d\0u\0c\0t\0o\0_\0u\0n\0i\0d\0a\0d\0_\0u\0n\0i\0d\0a\0d\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0Q\0\0Q\0\0P\0\0\0\0\0�h�h\0\0\0\0\0\0\0\0�\0\0\0\0\0R\0\0R\0\0\0\0\0\0f\0\0\0\0\'\0\0\0\0d\0b\0o\0\0\0F\0K\0_\0h\0i\0s\0t\0o\0r\0i\0a\0l\0_\0m\0o\0v\0i\0m\0i\0e\0n\0t\0o\0s\0_\0i\0n\0v\0e\0n\0t\0a\0r\0i\0o\0_\0u\0n\0i\0d\0a\0d\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0S\0\0S\0\0R\0\0\0\0\0�h؇h\0\0\0\0\0\0\0\0�\0\0\0\0\0T\0\0T\0\0\0\0\0\0X\0\0\0Zl\0\0\0d\0b\0o\0\0\0F\0K\0_\0e\0n\0t\0r\0a\0d\0a\0_\0s\0a\0l\0i\0d\0a\0_\0i\0n\0v\0e\0n\0t\0a\0r\0i\0o\0_\0u\0n\0i\0d\0a\0d\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0U\0\0U\0\0T\0\0\0\0\0�g\�g\0\0\0\0\0\0\0\0�\0\0\0\0\0V\0\0V\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\01\00\00\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0W\0\0W\0\0\0\0\0\08\0\0\0j\0\0\0d\0b\0o\0\0\0F\0K\0_\0v\0e\0n\0d\0e\0d\0o\0r\0_\0t\0e\0r\0c\0e\0r\0o\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0X\0\0X\0\0W\0\0\0\0\0�h��h\0\0\0\0\0\0\0\0�\0\0\0\0\0Y\0\0Y\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0Z\0\0Z\0\0\0\0\0\0F\0\0\0Gu\0\0\0d\0b\0o\0\0\0F\0K\0_\0v\0e\0n\0t\0a\0_\0v\0s\0_\0p\0a\0g\0o\0s\0_\0e\0m\0p\0l\0e\0a\0d\0o\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0[\0\0[\0\0Z\0\0\0\0\0�hX�h\0\0\0\0\0\0\0\0�\0\0\0\0\0\\\0\0\\\0\0\0\0\0\0X\0\0\0Zl\0\0\0d\0b\0o\0\0\0F\0K\0_\0o\0f\0e\0r\0t\0a\0_\0p\0r\0o\0d\0u\0c\0t\0o\0_\0d\0e\0t\0a\0l\0l\0e\0_\0p\0r\0o\0d\0u\0c\0t\0o\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0]\0\0]\0\0\\\0\0\0\0\0�g �g\0\0\0\0\0\0\0\0�\0\0\0\0\0^\0\0^\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\00\05\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0_\0\0_\0\0\0\0\0\02\0\0\0j\0\0\0d\0b\0o\0\0\0F\0K\0_\0m\0o\0d\0e\0l\0o\0_\0m\0a\0r\0c\0a\0s\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0`\0\0`\0\0_\0\0\0\0\0�h�h\0\0\0\0\0\0\0\0�\0\0\0\0\0c\0\0c\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\00\05\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0e\0\0e\0\0\0\0\0\0P\0\0\0\�]\0\0\0d\0b\0o\0\0\0F\0K\0_\0i\0n\0v\0e\0n\0t\0a\0r\0i\0o\0_\0r\0e\0p\0a\0r\0a\0c\0i\0o\0n\0_\0m\0a\0r\0c\0a\0s\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0f\0\0f\0\0e\0\0\0\0\0�h؆h\0\0\0\0\0\0\0\0�\0\0\0\0\0g\0\0g\0\0\0\0\0\0h\0\0\0\0\'\0\0\0\0d\0b\0o\0\0\0F\0K\0_\0i\0n\0v\0e\0n\0t\0a\0r\0i\0o\0_\0r\0e\0p\0a\0r\0a\0c\0i\0o\0n\0_\0e\0s\0t\0a\0d\0o\0s\0_\0r\0e\0p\0a\0r\0a\0c\0i\0o\0n\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0h\0\0h\0\0g\0\0\0\0\0�h��h\0\0\0\0\0\0\0\0�\0\0\0\0\0i\0\0i\0\0\0\0\0\0T\0\0\0Zl\0\0\0d\0b\0o\0\0\0F\0K\0_\0i\0n\0v\0e\0n\0t\0a\0r\0i\0o\0_\0r\0e\0p\0a\0r\0a\0c\0i\0o\0n\0_\0p\0r\0o\0d\0u\0c\0t\0o\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0j\0\0j\0\0i\0\0\0\0\0�hX�h\0\0\0\0\0\0\0\0�\0\0\0\0\0k\0\0k\0\0\0\0\0\0P\0\0\0\�]\0\0\0d\0b\0o\0\0\0F\0K\0_\0i\0n\0v\0e\0n\0t\0a\0r\0i\0o\0_\0r\0e\0p\0a\0r\0a\0c\0i\0o\0n\0_\0u\0n\0i\0d\0a\0d\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0l\0\0l\0\0k\0\0\0\0\0�h�h\0\0\0\0\0\0\0\0�\0\0\0\0\0m\0\0m\0\0\0\0\0\0^\0\0\0\�]\0\0\0d\0b\0o\0\0\0F\0K\0_\0p\0r\0o\0d\0u\0c\0t\0o\0_\0u\0n\0i\0d\0a\0d\0_\0c\0o\0n\0v\0e\0r\0s\0i\0o\0n\0_\0p\0r\0o\0d\0u\0c\0t\0o\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0n\0\0n\0\0m\0\0\0\0\0�h؅h\0\0\0\0\0\0\0\0�\0\0\0\0\0o\0\0o\0\0\0\0\0\0Z\0\0\0\�]\0\0\0d\0b\0o\0\0\0F\0K\0_\0p\0r\0o\0d\0u\0c\0t\0o\0_\0u\0n\0i\0d\0a\0d\0_\0c\0o\0n\0v\0e\0r\0s\0i\0o\0n\0_\0u\0n\0i\0d\0a\0d\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0p\0\0p\0\0o\0\0\0\0\0�h��h\0\0\0\0\0\0\0\0�\0\0\0\0\0q\0\0q\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\04\0\0\04\0,\00\0,\02\08\04\0,\00\0,\09\01\05\0,\01\0,\07\05\00\0,\05\0,\04\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\03\05\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\09\01\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\09\01\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\09\01\05\0,\01\02\0,\01\00\08\00\0,\01\01\0,\06\06\00\0\0\0r\0\0r\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\04\0\0\04\0,\00\0,\02\08\04\0,\00\0,\09\01\05\0,\01\0,\07\05\00\0,\05\0,\04\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\03\00\09\00\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\09\01\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\09\01\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\09\01\05\0,\01\02\0,\01\00\08\00\0,\01\01\0,\06\06\00\0\0\0s\0\0s\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\04\0\0\04\0,\00\0,\02\08\04\0,\00\0,\09\01\05\0,\01\0,\07\05\00\0,\05\0,\04\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\05\05\00\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\09\01\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\09\01\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\09\01\05\0,\01\02\0,\01\00\08\00\0,\01\01\0,\06\06\00\0\0\0t\0\0t\0\0\0\0\0\0@\0\0\0\0\0\0\0\0\0d\0b\0o\0\0\0F\0K\0_\0i\0n\0g\0r\0e\0s\0o\0s\0_\0c\0a\0j\0a\0_\0c\0a\0j\0e\0r\0o\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0u\0\0u\0\0t\0\0\0\0\0�hX�h\0\0\0\0\0\0\0\0�\0\0\0\0\0v\0\0v\0\0\0\0\0\0X\0\0\0Zl\0\0\0d\0b\0o\0\0\0F\0K\0_\0i\0n\0g\0r\0e\0s\0o\0s\0_\0c\0a\0j\0a\0_\0i\0n\0g\0r\0e\0s\0o\0s\0_\0c\0o\0n\0c\0e\0p\0t\0o\0s\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0w\0\0w\0\0v\0\0\0\0\0�h�h\0\0\0\0\0\0\0\0�\0\0\0\0\0x\0\0x\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\08\0\0\04\0,\00\0,\02\08\04\0,\00\0,\01\06\00\05\0,\01\0,\01\03\02\00\0,\05\0,\08\07\00\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\00\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\01\06\00\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\01\06\00\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\01\06\00\05\0,\01\02\0,\01\09\00\05\0,\01\01\0,\01\01\07\00\0\0\0y\0\0y\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\08\0\0\04\0,\00\0,\02\08\04\0,\00\0,\01\06\00\05\0,\01\0,\01\03\02\00\0,\05\0,\08\07\00\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\01\09\00\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\01\06\00\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\01\06\00\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\01\06\00\05\0,\01\02\0,\01\09\00\05\0,\01\01\0,\01\01\07\00\0\0\0z\0\0z\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\08\0\0\04\0,\00\0,\02\08\04\0,\00\0,\01\06\00\05\0,\01\0,\01\03\02\00\0,\05\0,\08\07\00\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\03\04\05\00\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\01\06\00\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\01\06\00\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\01\06\00\05\0,\01\02\0,\01\09\00\05\0,\01\01\0,\01\01\07\00\0\0\0{\0\0{\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\00\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\08\0\0\04\0,\00\0,\02\08\04\0,\00\0,\01\06\00\05\0,\01\0,\01\03\02\00\0,\05\0,\08\07\00\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\09\08\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\01\06\00\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\01\06\00\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\01\06\00\05\0,\01\02\0,\01\09\00\05\0,\01\01\0,\01\01\07\00\0\0\0|\0\0|\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\00\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\08\0\0\04\0,\00\0,\02\08\04\0,\00\0,\01\06\00\05\0,\01\0,\01\03\02\00\0,\05\0,\08\07\00\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\00\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\01\06\00\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\01\06\00\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\01\06\00\05\0,\01\02\0,\01\09\00\05\0,\01\01\0,\01\01\07\00\0\0\0}\0\0}\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\08\0\0\04\0,\00\0,\02\08\04\0,\00\0,\01\06\00\05\0,\01\0,\01\03\02\00\0,\05\0,\08\07\00\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\01\09\00\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\01\06\00\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\01\06\00\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\01\06\00\05\0,\01\02\0,\01\09\00\05\0,\01\01\0,\01\01\07\00\0\0\0~\0\0~\0\0\0\0\0\0f\0\0\0�\'\0\0\0\0d\0b\0o\0\0\0F\0K\0_\0s\0i\0s\0t\0e\0m\0a\0_\0m\0o\0d\0u\0l\0o\0_\0o\0p\0c\0i\0o\0n\0e\0s\0_\0s\0i\0s\0t\0e\0m\0a\0_\0m\0o\0d\0u\0l\0o\0s\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0\0\0\0\0~\0\0\0\0\0-j\�-j\0\0\0\0\0\0\0\0�\0\0\0\0�\0\0�\0\0\0\0\0\0d\0\0\0�\'\0\0\0\0d\0b\0o\0\0\0F\0K\0_\0p\0r\0o\0d\0u\0c\0t\0o\0_\0p\0r\0o\0d\0u\0c\0t\0o\0s\0_\0r\0e\0q\0u\0i\0s\0i\0t\0o\0s\0_\0p\0r\0o\0d\0u\0c\0t\0o\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0�\0\0�\0\0�\0\0\0\0\0.j�.j\0\0\0\0\0\0\0\0�\0\0\0\0�\0\05\0\0\0\0\00\0\0g\0\0\0�\0\0\03\0\0\0\0\00\0\0a\0\0\0|\0\0\0�\0\0\0\0\0\0�\0\0\0d\0\0\0�\0\0\0#\0\0\0\0\0\0\"\0\0\0&\0\0\0\'\0\0\0\0\0\0\0\0\0\0\0\0\'\0\0\0&\0\0\00\0\0\0\0\0\0/\0\0\0\'\0\0\0\0\0\0t\0\0\0\0\0q\0\0\0\0\0B\0\0\0D\0\0\0\0\0\0C\0\0\0&\0\0\0\'\0\0\0=\0\0\0\0\0\0<\0\0\0%\0\0\0&\0\0\0\�\0\0\0\0\0\0\�\0\0\0&\0\0\0\'\0\0\0�\0\0\0\0\0\0�\0\0\0a\0\0\0�\0\0\0�\0\0\0	\0\0\0�\0\0\0n\0\0\0�\0\0\0O\0\0\0	\0\0\0N\0\0\0\0\0\0&\0\0\0&\0\0\0	\0\0\0%\0\0\0t\0\0\0q\0\0\0\0\0\0\n\0\0\0\r\0\0\0`\0\0\0e\0\0\0\0\0\0\n\0\0\0	\0\0\0&\0\0\0+\0\0\0\0\0\0\r\0\0\0	\0\0\0&\0\0\0%\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0&\0\0\0\'\0\0\0 \0\0\0\0\0\0\0\0\0e\0\0\0z\0\0\0)\0\0\0%\0\0\0(\0\0\0\'\0\0\0&\0\0\04\0\0\0-\0\0\03\0\0\0&\0\0\0\r\0\0\0\0\0.\0\0\0\0\0\'\0\0\0&\0\0\0Z\0\03\0\0\0Y\0\0\0\0\0&\0\0\0�\0\0\03\0\0\0�\0\0\0\0\0\0&\0\0\0�\0\0\03\0\0\0�\0\0\0+\0\0\0&\0\0\0r\0\0\03\0\0\0o\0\0\0%\0\0\0&\0\0\0\\\0\0\03\0\0\0[\0\0\0\0\0\0,\0\0\0K\0\0\03\0\0\0J\0\0\0=\0\0\0&\0\0\0G\0\0\03\0\0\0F\0\0\01\0\0\02\0\0\0A\0\0\03\0\0\0<\0\0\0\0\0\0#\0\0\0?\0\0\03\0\0\0<\0\0\0$\0\0\0)\0\0\0:\0\0\03\0\0\0%\0\0\07\0\0\0&\0\0\08\0\0\03\0\0\0\0\0\0�\0\0\0e\0\0\06\0\0\03\0\0\0+\0\0\0�\0\0\0�\0\0\0�\0\0\0I\0\0\0\�\0\0\0&\0\0\0/\0\0\0g\0\0M\0\0\0c\0\0L\0\0\0\�\0\0\0_\0\0\0N\0\0\0^\0\0\0\�\0\0\0\0\0\0U\0\0\0N\0\0\0T\0\0\0)\0\0\0&\0\0\0R\0\0\0N\0\0\0Q\0\0\0#\0\0\0&\0\0\0Y\0\0\0W\0\0\0X\0\0\0&\0\0\0\'\0\0\0�\0\0\0d\0\0\0�\0\0\0&\0\0\0)\0\0\0e\0\0f\0\0\0c\0\0X\0\0\0Y\0\0\0_\0\0f\0\0\0^\0\0\'\0\0\0\0\0\0i\0\0\0g\0\0\0h\0\0\0&\0\0\0\'\0\0\0m\0\0\0k\0\0\0l\0\0\0&\0\0\0\'\0\0\0x\0\0\0o\0\0\0w\0\0\0}\0\0\0l\0\0\0p\0\0\0o\0\0\0F\0\0\0w\0\0\0\0\0\0z\0\0\0t\0\0\0w\0\0\0\'\0\0\0&\0\0\0u\0\0\0t\0\0\0F\0\0\0&\0\0\0O\0\0\0}\0\0\0|\0\0\0o\0\0\0&\0\0\0\'\0\0\0\�\0\0\0�\0\0\0\�\0\0\0&\0\0\0\'\0\0\0�\0\0\0�\0\0\0�\0\0\0\'\0\0\0&\0\0\0\0\0�\0\0\0\0\0\'\0\0\0&\0\0\0�\0\0\0�\0\0\0X\0\0\0a\0\0\0^\0\0\0�\0\0\0�\0\0\0�\0\0\0e\0\0\0`\0\0\0�\0\0\0�\0\0\0	\0\0\0C\0\0\0&\0\0\0�\0\0\0�\0\0\03\0\0\0&\0\0\0C\0\0\0�\0\0�\0\0\0z\0\0\0\0\0\0Y\0\0\0m\0\0�\0\0\0�\0\0\0J\0\0\0\0\0\0i\0\0�\0\0\0c\0\0F\0\0\0\0\0\0\\\0\0�\0\0\0\0\0\0H\0\0\0\0\0\01\0\0�\0\0\00\0\0�\0\0\0�\0\0\0\�\0\0\0�\0\0\0\�\0\0\0&\0\0\0\'\0\0\0\�\0\0\0�\0\0\0\�\0\0\0#\0\0\0&\0\0\0�\0\0\0�\0\0\0�\0\0\0q\0\0\0\\\0\0\0�\0\0\0�\0\0\0�\0\0\0}\0\0\0d\0\0\0�\0\0\0�\0\0\0J\0\0\0e\0\0\0~\0\0\0�\0\0\0�\0\0\0\0\0\0w\0\0\0z\0\0\0�\0\0\0�\0\0\0Q\0\0\0�\0\0\0~\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0p\0\0\0�\0\0\0�\0\0\0^\0\0\0�\0\0\0~\0\0\0�\0\0\0�\0\0\0a\0\0\0k\0\0\0|\0\0\0�\0\0\0�\0\0\0[\0\0\0Y\0\0\0�\0\0\0�\0\0\0�\0\0\0(\0\0\0�\0\0\0p\0\0\0�\0\0\0�\0\0\0c\0\0\0_\0\0\0v\0\0\0�\0\0\0�\0\0\0\0\0\0�\0\0\0d\0\0\0\�\0\0\0�\0\0\0\�\0\0\0&\0\0\0\'\0\0\0�\0\0\0�\0\0\0h\0\0\0`\0\0\0a\0\0\0�\0\0\0�\0\0\0�\0\0\0\'\0\0\0&\0\0\0�\0\0\0�\0\0\0\0\0\0&\0\0\0\0\0\0�\0\0\0�\0\0\0�\0\0\0q\0\0\0z\0\0\0\�\0\0\0�\0\0\0\�\0\0\0`\0\0\0a\0\0\0\�\0\0\0\�\0\0\0\�\0\0\0d\0\0\0e\0\0\0\�\0\0\0\�\0\0\0\�\0\0\0&\0\0\0\'\0\0\0\�\0\0\0\�\0\0\0.\0\0\0\'\0\0\0&\0\0\0\�\0\0\0\�\0\0\0�\0\0\0a\0\0\0h\0\0\0\�\0\0\0\�\0\0\03\0\0\0\'\0\0\0*\0\0\0\�\0\0\0\�\0\0\0<\0\0\0`\0\0\0�\0\0\0\�\0\0\0\�\0\0\0�\0\0\0e\0\0\0�\0\0\09\0\0\�\0\0\00\0\0#\0\0\0\"\0\0\07\0\0\�\0\0\00\0\0)\0\0\0(\0\0\0�\0\0\0\�\0\0\0�\0\0\0Y\0\0\0`\0\0\0�\0\0\0\�\0\0\0-\0\0\0d\0\0\0e\0\0\0�\0\0\0\�\0\0\0\0\0\0\0\0\0&\0\0\0\�\0\0\0\�\0\0\0o\0\0\0_\0\0\0z\0\0\0\�\0\0\0\�\0\0\03\0\0\0&\0\0\0\0\0\0\�\0\0\0\�\0\0\0�\0\0\0k\0\0\0�\0\0\0\�\0\0\0\�\0\0\0\0\0\0e\0\0\0�\0\0\0\�\0\0\0\�\0\0\0%\0\0\0q\0\0\0p\0\0\0�\0\0\0�\0\0\0\0\0\0&\0\0\0\'\0\0\0W\0\0\0\0V\0\0\0\0\02\0\0\0\"\0\0\0\0!\0\0g\0\0\0d\0\0\0\0\0\0\0\0\0\"\0\0\0\'\0\0\0\Z\0\0\0\0\0\0(\0\0\0\'\0\0\0\0\0\0\0\0\0X\0\0\0e\0\0\0\0\0\0\0\0\0^\0\0\0m\0\0\0\0\0\0\0\0\0\0|\0\0\06\0\0\0\r\0\0\0\0�\0\0\0j\0\0\0a\0\0\0\0\0\0\0�\0\0\0p\0\0\0k\0\0\0	\0\0\0\0b\0\0\0a\0\0\0d\0\0\0\0\0\0\0I\0\0\0d\0\0\0e\0\0\0\'\0\0$\0\0\"\0\0\0e\0\0\0d\0\0\0%\0\0$\0\0\0\0\0\'\0\0\0&\0\0\0*\0\0)\0\0,\0\0\0\'\0\0\0&\0\0\0-\0\0,\0\0b\0\0\05\0\0\0&\0\0\0;\0\0/\0\00\0\0j\0\0\0�\0\0\0o\0\0=\0\0�\0\0\0\0\0\0\0W\0\0\0k\0\0=\0\0c\0\0\0\0\0K\0\0\0T\0\0=\0\0J\0\0\0`\0\0\0\0\0\0R\0\0=\0\00\0\0\0\0\0\'\0\0\0P\0\0=\0\0�\0\0\0\0\0\0&\0\0\0N\0\0=\0\0(\0\0\06\0\0\0\'\0\0\0L\0\0=\0\0c\0\0\0\0\0\0\'\0\0\0J\0\0=\0\0Q\0\0\00\0\0\0\'\0\0\0H\0\0=\0\0�\0\0\0%\0\0\0&\0\0\0F\0\0=\0\0[\0\0\0\0\0\0-\0\0\0D\0\0=\0\0a\0\0\0f\0\0\0}\0\0\0@\0\0=\0\0^\0\0\0*\0\0\0+\0\0\0>\0\0=\0\0�\0\0\0$\0\0\0\'\0\0\0v\0\0r\0\0q\0\0.\0\0\0,\0\0\0~\0\0|\0\0{\0\0u\0\0\0|\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\�\��\��Q\0�\�W9\0\0\0�\�&\�\0\0HE\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0D\0a\0t\0a\0 \0S\0o\0u\0r\0c\0e\0=\0.\0;\0I\0n\0i\0t\0i\0a\0l\0 \0C\0a\0t\0a\0l\0o\0g\0=\0p\0u\0n\0t\0o\0_\0v\0e\0n\0t\0a\0;\0P\0e\0r\0s\0i\0s\0t\0 \0S\0e\0c\0u\0r\0i\0t\0y\0 \0I\0n\0f\0o\0=\0T\0r\0u\0e\0;\0U\0s\0e\0r\0 \0I\0D\0=\0d\0e\0x\0t\0r\0o\0y\0e\0x\0;\0M\0u\0l\0t\0i\0p\0l\0e\0A\0c\0t\0i\0v\0e\0R\0e\0s\0u\0l\0t\0S\0e\0t\0s\0=\0F\0a\0l\0s\0e\0;\0P\0a\0c\0k\0e\0t\0 \0S\0i\0z\0e\0=\04\00\09\06\0;\0A\0p\0p\0l\0i\0c\0a\0t\0i\0o\0n\0 \0N\0a\0m\0e\0=\0\"\0M\0i\0c\0r\0o\0s\0o\0f\0t\0 \0S\0Q\0L\0 \0S\0e\0r\0v\0e\0r\0 \0M\0a\0n\0a\0g\0e\0m\0e\0n\0t\0 \0S\0t\0u\0d\0i\0o\0\"\0\0\0\0�\0\0\0\0D\0i\0a\0g\0r\0a\0m\0_\00\0\0\0\0&\0$\0\0\0s\0i\0s\0t\0e\0m\0a\0_\0h\0i\0s\0t\0o\0r\0i\0a\0l\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0&\0\0\0i\0n\0g\0r\0e\0s\0o\0s\0_\0c\0o\0n\0c\0e\0p\0t\0o\0s\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0\0\0\0i\0n\0g\0r\0e\0s\0o\0s\0_\0c\0a\0j\0a\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0,\0\0\0i\0n\0v\0e\0n\0t\0a\0r\0i\0o\0_\0r\0e\0p\0a\0r\0a\0c\0i\0o\0n\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0\0\0\0m\0o\0d\0e\0l\0o\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0\0\0\0v\0e\0n\0t\0a\0_\0v\0s\0_\0p\0a\0g\0o\0s\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0\0\0\0v\0e\0n\0d\0e\0d\0o\0r\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0\0\0\0u\0n\0i\0d\0a\0d\0\0\0\0\0\0d\0b\0o\0\0\0\0&\02\0\0\0t\0r\0a\0n\0s\0f\0e\0r\0e\0n\0c\0i\0a\0_\0i\0n\0v\0e\0n\0t\0a\0r\0i\0o\0\0\0\0\0\0d\0b\0o\0\0\0\0&\06\0\0\0t\0i\0p\0o\0_\0m\0o\0v\0i\0m\0i\0e\0n\0t\0o\0_\0i\0n\0v\0e\0n\0t\0a\0r\0i\0o\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0(\0\0\0t\0i\0p\0o\0_\0i\0d\0e\0n\0t\0i\0f\0i\0c\0a\0c\0i\0o\0n\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0*\0\0\0t\0i\0p\0o\0_\0c\0u\0e\0n\0t\0a\0_\0b\0a\0n\0c\0a\0r\0i\0a\0\0\0\0\0\0d\0b\0o\0\0\0\0&\00\0\0\0t\0i\0p\0o\0_\0c\0o\0m\0p\0r\0o\0b\0a\0n\0t\0e\0_\0f\0i\0s\0c\0a\0l\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0(\0\0\0t\0e\0r\0c\0e\0r\0o\0_\0v\0s\0_\0t\0e\0l\0e\0f\0o\0n\0o\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0&\0\0\0t\0e\0r\0c\0e\0r\0o\0_\0v\0s\0_\0p\0e\0r\0m\0i\0s\0o\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0\"\0\0\0t\0e\0r\0c\0e\0r\0o\0_\0v\0s\0_\0e\0m\0a\0i\0l\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0*\0\0\0t\0e\0r\0c\0e\0r\0o\0_\0v\0s\0_\0d\0i\0r\0e\0c\0c\0i\0o\0n\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0,\0\0\0t\0e\0r\0c\0e\0r\0o\0_\0o\0b\0s\0e\0r\0v\0a\0c\0i\0o\0n\0e\0s\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0\0\0\0t\0e\0r\0c\0e\0r\0o\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0\"\0\0\0t\0a\0r\0j\0e\0t\0a\0s\0_\0c\0r\0e\0d\0i\0t\0o\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0\0\0\0s\0u\0p\0l\0i\0d\0o\0r\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0*\0\0\0s\0u\0c\0u\0r\0s\0a\0l\0_\0v\0s\0_\0e\0m\0p\0l\0e\0a\0d\0o\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0\0\0\0s\0u\0c\0u\0r\0s\0a\0l\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0,\0\0\0s\0u\0b\0c\0a\0t\0e\0g\0o\0r\0i\0a\0_\0p\0r\0o\0d\0u\0c\0t\0o\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0&\0\0\0s\0i\0t\0u\0a\0c\0i\0o\0n\0_\0e\0m\0p\0l\0e\0a\0d\0o\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0\0\0\0s\0i\0s\0t\0e\0m\0a\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0\n\0\0\0s\0e\0x\0o\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0\0\0\0s\0e\0c\0t\0o\0r\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0\0\0\0r\0e\0g\0i\0o\0n\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0\0\0\0p\0r\0o\0v\0i\0n\0c\0i\0a\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0*\0\0\0p\0r\0o\0d\0u\0c\0t\0o\0_\0v\0s\0_\0p\0e\0r\0m\0i\0s\0o\0s\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0(\0\0\0p\0r\0o\0d\0u\0c\0t\0o\0_\0v\0s\0_\0d\0e\0t\0a\0l\0l\0e\0\0\0\0\0\0d\0b\0o\0\0\0\0&\06\0\0\0p\0r\0o\0d\0u\0c\0t\0o\0_\0u\0n\0i\0d\0a\0d\0_\0c\0o\0n\0v\0e\0r\0s\0i\0o\0n\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0 \0\0\0p\0r\0o\0d\0u\0c\0t\0o\0_\0u\0n\0i\0d\0a\0d\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0$\0\0\0p\0r\0o\0d\0u\0c\0t\0o\0_\0p\0e\0r\0m\0i\0s\0o\0s\0\0\0\0\0\0d\0b\0o\0\0\0\0&\04\0\0\0p\0r\0o\0d\0u\0c\0t\0o\0_\0o\0f\0e\0r\0t\0a\0_\0h\0i\0s\0t\0o\0r\0i\0a\0l\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0 \0\0\0p\0r\0o\0d\0u\0c\0t\0o\0_\0o\0f\0e\0r\0t\0a\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0\"\0\0\0p\0r\0o\0d\0u\0c\0t\0o\0_\0d\0e\0t\0a\0l\0l\0e\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0*\0\0\0p\0r\0o\0d\0u\0c\0t\0o\0_\0c\0o\0d\0i\0g\0o\0b\0a\0r\0r\0a\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0\0\0\0p\0r\0o\0d\0u\0c\0t\0o\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0\0\0\0p\0e\0r\0s\0o\0n\0a\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0\0\0\0p\0e\0r\0m\0i\0s\0o\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0\0\0\0p\0e\0d\0i\0d\0o\0s\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0\0\0\0p\0e\0d\0i\0d\0o\0_\0d\0e\0t\0a\0l\0l\0e\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0\n\0\0\0p\0a\0i\0s\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0@\0\0\0o\0f\0e\0r\0t\0a\0_\0p\0r\0o\0d\0u\0c\0t\0o\0_\0s\0u\0b\0c\0a\0t\0e\0_\0d\0e\0t\0a\0l\0l\0e\0\0\0\0\0\0d\0b\0o\0\0\0\0&\00\0\0\0o\0f\0e\0r\0t\0a\0_\0p\0r\0o\0d\0u\0c\0t\0o\0_\0d\0e\0t\0a\0l\0l\0e\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0\Z\0\0\0n\0o\0m\0i\0n\0a\0_\0t\0i\0p\0o\0s\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0\0\0\0n\0o\0m\0i\0n\0a\0_\0d\0e\0t\0a\0l\0l\0e\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0\"\0\0\0n\0o\0m\0i\0n\0a\0_\0c\0o\0n\0c\0e\0p\0t\0o\0s\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0\0\0\0n\0o\0m\0i\0n\0a\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0\"\0\0\0m\0o\0n\0e\0d\0a\0_\0h\0i\0s\0t\0o\0r\0i\0a\0l\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0\0\0\0m\0o\0n\0e\0d\0a\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0\0\0\0m\0e\0s\0a\0s\0_\0d\0e\0t\0a\0l\0l\0e\0s\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0\0\0\0m\0e\0s\0a\0s\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0\0\0\0m\0a\0r\0c\0a\0s\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0,\0\0\0l\0o\0t\0e\0r\0i\0a\0_\0r\0e\0a\0l\0_\0q\0u\0i\0n\0i\0e\0l\0a\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0\0\0\0i\0t\0e\0b\0i\0s\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0\0\0\0i\0n\0v\0e\0n\0t\0a\0r\0i\0o\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0\0\0\0i\0d\0e\0n\0t\0i\0f\0i\0c\0a\0c\0i\0o\0n\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0:\0\0\0h\0i\0s\0t\0o\0r\0i\0a\0l\0_\0i\0n\0v\0e\0n\0t\0a\0r\0i\0o\0_\0a\0g\0o\0t\0a\0d\0o\0\0\0\0\0\0d\0b\0o\0\0\0\0&\08\0\0\0h\0i\0s\0t\0o\0r\0i\0a\0l\0_\0d\0e\0v\0o\0l\0u\0c\0i\0o\0n\0_\0v\0e\0n\0t\0a\0s\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0:\0\0\0h\0i\0s\0t\0o\0r\0i\0a\0l\0_\0d\0e\0v\0o\0l\0u\0c\0i\0o\0n\0_\0c\0o\0m\0p\0r\0a\0s\0\0\0\0\0\0d\0b\0o\0\0\0\0&\00\0\0\0g\0r\0u\0p\0o\0_\0u\0s\0u\0a\0r\0i\0o\0s\0_\0p\0e\0r\0m\0i\0s\0o\0s\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0\0\0\0g\0r\0u\0p\0o\0_\0u\0s\0u\0a\0r\0i\0o\0s\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0$\0\0\0f\0a\0c\0t\0u\0r\0a\0s\0_\0a\0n\0u\0l\0a\0d\0a\0s\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0 \0\0\0f\0a\0c\0t\0u\0r\0a\0_\0d\0e\0t\0a\0l\0l\0e\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0\0\0\0f\0a\0c\0t\0u\0r\0a\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0&\0\0\0e\0s\0t\0a\0d\0o\0s\0_\0r\0e\0p\0a\0r\0a\0c\0i\0o\0n\0\0\0\0\0\0d\0b\0o\0\0\0\0&\04\0\0\0e\0n\0t\0r\0a\0d\0a\0_\0s\0a\0l\0i\0d\0a\0_\0i\0n\0v\0e\0n\0t\0a\0r\0i\0o\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0\0\0\0e\0m\0p\0r\0e\0s\0a\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0:\0\0\0e\0m\0p\0l\0e\0a\0d\0o\0_\0v\0s\0_\0c\0o\0n\0c\0e\0p\0t\0o\0s\0_\0n\0o\0m\0i\0n\0a\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0$\0\0\0e\0m\0p\0l\0e\0a\0d\0o\0_\0v\0s\0_\0c\0a\0r\0g\0o\0\0\0\0\0\0d\0b\0o\0\0\0\0&\02\0\0\0e\0m\0p\0l\0e\0a\0d\0o\0_\0h\0i\0s\0t\0o\0r\0i\0a\0l\0_\0d\0a\0t\0o\0s\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0\0\0\0e\0m\0p\0l\0e\0a\0d\0o\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0$\0\0\0e\0g\0r\0e\0s\0o\0s\0_\0c\0o\0n\0c\0e\0p\0t\0o\0s\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0\Z\0\0\0e\0g\0r\0e\0s\0o\0s\0_\0c\0a\0j\0a\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0\0\0\0d\0i\0r\0e\0c\0c\0i\0o\0n\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0\Z\0\0\0d\0e\0p\0a\0r\0t\0a\0m\0e\0n\0t\0o\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0 \0\0\0c\0u\0e\0n\0t\0a\0_\0b\0a\0n\0c\0a\0r\0i\0a\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0\0\0\0c\0u\0a\0d\0r\0e\0_\0c\0a\0j\0a\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0(\0\0\0c\0o\0t\0i\0z\0a\0c\0i\0o\0n\0_\0d\0e\0t\0a\0l\0l\0e\0s\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0\0\0\0c\0o\0t\0i\0z\0a\0c\0i\0o\0n\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0&\0\0\0c\0o\0m\0p\0r\0o\0b\0a\0n\0t\0e\0_\0v\0e\0n\0t\0a\0s\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0$\0\0\0c\0o\0m\0p\0r\0o\0b\0a\0n\0t\0e\0_\0s\0e\0r\0i\0e\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0&\0\0\0c\0o\0m\0p\0r\0o\0b\0a\0n\0t\0e\0_\0f\0i\0s\0c\0a\0l\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0 \0\0\0c\0o\0m\0p\0r\0a\0_\0v\0s\0_\0p\0a\0g\0o\0s\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0*\0\0\0c\0o\0m\0p\0r\0a\0_\0p\0a\0g\0o\0_\0a\0n\0u\0l\0a\0d\0o\0s\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0\0\0\0c\0o\0m\0p\0r\0a\0_\0d\0e\0t\0a\0l\0l\0e\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0\0\0\0c\0o\0m\0p\0r\0a\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0\0\0\0c\0o\0m\0b\0o\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0*\0\0\0c\0l\0i\0e\0n\0t\0e\0_\0s\0u\0b\0c\0a\0t\0e\0g\0o\0r\0i\0a\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0$\0\0\0c\0l\0i\0e\0n\0t\0e\0_\0c\0a\0t\0e\0g\0o\0r\0i\0a\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0\0\0\0c\0l\0i\0e\0n\0t\0e\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0&\0\0\0c\0a\0t\0e\0g\0o\0r\0i\0a\0_\0p\0r\0o\0d\0u\0c\0t\0o\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0\0\0\0c\0a\0r\0g\0o\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0\0\0\0c\0a\0j\0e\0r\0o\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0\n\0\0\0c\0a\0j\0a\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0\0\0\0b\0a\0n\0c\0o\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0\0\0\0a\0l\0m\0a\0c\0e\0n\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0\"\0\0\0c\0a\0t\0a\0l\0o\0g\0o\0_\0c\0u\0e\0n\0t\0a\0s\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0(\0\0\0c\0o\0r\0r\0e\0o\0_\0e\0l\0e\0c\0t\0r\0o\0n\0i\0c\0o\0s\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0<\0\0\0p\0r\0o\0d\0u\0c\0t\0o\0_\0p\0r\0o\0d\0u\0c\0t\0o\0s\0_\0r\0e\0q\0u\0i\0s\0i\0t\0o\0s\0\0\0\0\0\0d\0b\0o\0\0\0\0&\00\0\0\0s\0i\0s\0t\0e\0m\0a\0_\0m\0o\0d\0u\0l\0o\0_\0o\0p\0c\0i\0o\0n\0e\0s\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0 \0\0\0s\0i\0s\0t\0e\0m\0a\0_\0m\0o\0d\0u\0l\0o\0s\0\0\0\0\0\0d\0b\0o\0\0\0\0$\0 \0\0\0s\0u\0p\0l\0i\0d\0o\0r\0e\0s\0_\0d\0g\0i\0i\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0օ	��k�E��7d�2p\0N\0\0\0{\01\06\03\04\0C\0D\0D\07\0-\00\08\08\08\0-\04\02\0E\03\0-\09\0F\0A\02\0-\0B\06\0D\03\02\05\06\03\0B\09\01\0D\0}\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0b�R'),(2,'Diagram_1',1,1,'\�\�ࡱ\Z\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0>\0\0��	\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0����\0\0\0\0\0\0\0\0����������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0��������\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0��������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������R\0o\0o\0t\0 \0E\0n\0t\0r\0y\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0��������\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�3�0\�\0\0\0@&\0\0\0\0\0\0f\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0������������\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0o\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0����\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0\0\0\0C\0o\0m\0p\0O\0b\0j\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0������������\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0S\0\0\0_\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0����\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\Z\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0 \0\0\0!\0\0\0\"\0\0\0#\0\0\0$\0\0\0%\0\0\0&\0\0\0\'\0\0\0(\0\0\0)\0\0\0*\0\0\0+\0\0\0,\0\0\0-\0\0\0.\0\0\0/\0\0\00\0\0\01\0\0\02\0\0\03\0\0\04\0\0\05\0\0\06\0\0\07\0\0\08\0\0\09\0\0\0:\0\0\0;\0\0\0<\0\0\0=\0\0\0>\0\0\0?\0\0\0@\0\0\0A\0\0\0B\0\0\0C\0\0\0D\0\0\0E\0\0\0F\0\0\0G\0\0\0H\0\0\0I\0\0\0J\0\0\0K\0\0\0L\0\0\0M\0\0\0N\0\0\0O\0\0\0P\0\0\0Q\0\0\0R\0\0\0����T\0\0\0����V\0\0\0W\0\0\0X\0\0\0Y\0\0\0Z\0\0\0[\0\0\0\\\0\0\0]\0\0\0^\0\0\0_\0\0\0`\0\0\0a\0\0\0b\0\0\0c\0\0\0d\0\0\0e\0\0\0f\0\0\0g\0\0\0h\0\0\0i\0\0\0j\0\0\0k\0\0\0l\0\0\0m\0\0\0n\0\0\0o\0\0\0p\0\0\0q\0\0\0r\0\0\0s\0\0\0t\0\0\0u\0\0\0v\0\0\0w\0\0\0x\0\0\0y\0\0\0z\0\0\0{\0\0\0|\0\0\0}\0\0\0~\0\0\0\0\0\0�\0\0\0\04\0\nP\0\0�\0\0\0\0��Z\0\0\0\0\0\0\0}\0\0�\0\0�H\0\03�\0\0q_\0\0\����|\���ހ[�\���\0�\0�\�\\\0\0\00\0\0\0\0\0\0\0\0\0<\0k\0\0\0	\0\0\0\0\0\0\0\�\�\��\��Q\0�\�W9�;�a\�C�5)�\�\�R��2}�\�b�B��\'<%�\�-\0\0(\0C\0\0\0\0\0\0\0SDM\�\��c\0`�\�\�H4\�\�wyw\��p\0[�\r�\0\0(\0C\0\0\0\0\0\0\0QDM\�\��c\0`�\�\�H4\�\�wyw\��p\0[�\r�\r\0\0\0�\0\0\0�\0\0\00\0�	\0\0\0\0�\0\0\0�\0\0\0�\0\0\0\0�SchGrid\0\�h\0\0\0\0\0\0pagosid\0\0\08\0�	\0\0\0\0�\0\0\0�\0\0\0�\0\0\0\0�SchGrid\0�H\0\0\0\0pagos_detalles\0\0\0\00\0�	\0\0\0\0�\0\0\0�\0\0\0�\0\0\0\0�SchGrid\0\�\0\0Z���cobrosd\0\0\08\0�	\0\0\0\0�\0\0\0�\0\0\0�\0\0\0\0�SchGrid\0\0\0\0\0\�\0\0cobros_detalles\0\0\0x\0�	\0\0\0\0�\n\0\0\0R\0\0\0�\0\0O\0\0�Control\0\0\0\�\0\0Relationship \'FK_cobros_detalles_cobros\' between \'cobros\' and \'cobros_detalles\'\0\0\0(\0�\0\0\0\0�\0\0\01\0\0\0e\0\0\0�\0\0Control\0!\0\0a\0\0\0\0t\0�	\0\0\0\0�\0\0\0R\0\0\0�\0\0K\0\0�Control\0�^\0\0\r\0\0Relationship \'FK_pagos_detalles_pagos\' between \'pagos\' and \'pagos_detalles\'l\0\0(\0�\0\0\0\0�\r\0\0\01\0\0\0a\0\0\0�\0\0Control\0[]\0\0�\0\0\0\00\0�	\0\0\0\0�\0\0\0�\0\0\0�\0\0\0\0�SchGrid\0\�\'\0\0�\0\0cajerod\0\0\0d\0�	\0\0\0\0�\0\0\0R\0\0\0�\0\0;\0\0�Control\0�:\0\0�\0\0Relationship \'FK_pagos_cajero\' between \'cajero\' and \'pagos\'\0\0\0(\0�\0\0\0\0�\0\0\01\0\0\0Q\0\0\0�\0\0Control\0�M\0\0\�\0\0\0\0h\0�	\0\0\0\0�\0\0\0R\0\0\0�\0\0=\0\0�Control\0\�&\0\0c\0\0Relationship \'FK_cobros_cajero\' between \'cajero\' and \'cobros\'\0\0\0\0\0(\0�\0\0\0\0�\0\0\01\0\0\0S\0\0\0�\0\0Control\0)\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0!C4\0\0\0A\0\0\� \0\0xV4\0\0\0\0\0p\0a\0g\0o\0s\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0̓@\0\0\0\0\0\0@\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0̓@\0\0\0\0\0\0\0\0\0\0\0\0\0̓@\0\0\0\0\0\0\0@\0\0\0 \0\0\00\0\0\0\0\0\0\0\0\0\0\0\0ē@\0\0\0\0\0\0@\0\0\0\0\0\0\0@\0\0\0\0\0\0\0@\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0@\0\0\0\0\0\0\0\0\0\0\0\0\0@\0\0\0\0\0\0@\0\0\0 \0\0\0 \0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\0\�#\0\0\0\0\0\0-\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0�\0\0�\0\0\�\0\0�\0\0H\0\0�\0\0�\0\0�\0\0\0\0\0\0\0\0\0A\0\0\� \0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\n\0\0\0\0\0\0\0\0\0�\0\0N\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0T\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0p\0a\0g\0o\0s\0\0\0!C4\0\0\0A\0\0]\0\0xV4\0\0\0\0\0p\0a\0g\0o\0s\0_\0d\0e\0t\0a\0l\0l\0e\0s\0\0\0@H\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0d^ n,�(n\�%]nd^ n,�(n\�%]n,\0 \0x\0p\0.\0m\0a\0j\0o\0r\0_\0i\0d\0,\0 \0k\0c\0.\0n\0a\0m\0e\0 \0a\0s\0 \0K\0e\0y\0_\0n\0a\0m\0e\0 \0 \0f\0r\0o\0m\0 \0s\0y\0s\0.\0e\0x\0t\0e\0n\0d\0e\0d\0_\0p\0r\0o\0p\0e\0r\0t\0i\0e\0s\0 \0x\0p\0 \0i\0n\0n\0e\0r\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\0\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0�\0\0�\0\0\�\0\0�\0\0H\0\0�\0\0�\0\0�\0\0\0\0\0\0\0\0\0A\0\0]\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\n\0\0\0\0\0\0\0\0\0�\0\0N\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0f\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0p\0a\0g\0o\0s\0_\0d\0e\0t\0a\0l\0l\0e\0s\0\0\0!C4\0\0\0A\0\0\� \0\0xV4\0\0\0\0\0c\0o\0b\0r\0o\0s\0\0\0��\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\0\�#\0\0\0\0\0\0-\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0�\0\0�\0\0\�\0\0�\0\0H\0\0�\0\0�\0\0�\0\0\0\0\0\0\0\0\0A\0\0\� \0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\n\0\0\0\0\0\0\0\0\0�\0\0N\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0V\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0c\0o\0b\0r\0o\0s\0\0\0!C4\0\0\0A\0\0]\0\0xV4\0\0\0\0\0c\0o\0b\0r\0o\0s\0_\0d\0e\0t\0a\0l\0l\0e\0s\0\0\0\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0���\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0�)\0\0\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0S\0\0\�\0\0�\0\0�\0\0\�\0\0�\0\0H\0\0�\0\0�\0\0�\0\0\0\0\0\0\0\0\0A\0\0]\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\n\0\0\0\0\0\0\0\0\0�\0\0N\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0U2\0\0\�#\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0�\0\0�\n\0\0�\0\0xV4\0\0\0h\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0c\0o\0b\0r\0o\0s\0_\0d\0e\0t\0a\0l\0l\0e\0s\0\0\0\0\0\�\0\0h\0\0A\0\0h\0\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0!\0\0a\0\0�\0\0X\0\02\0\0\0\0\0\0\0�\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0c\0o\0b\0r\0o\0s\0_\0d\0e\0t\0a\0l\0l\0e\0s\0_\0c\0o\0b\0r\0o\0s\0\0\0\�h\0\0�\0\0\�_\0\0�\0\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0[]\0\0�\0\0\0\0X\0\02\0\0\0\0\0\0\0\0\0X\0\0\0\0\0\0\0\0\0�\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0p\0a\0g\0o\0s\0_\0d\0e\0t\0a\0l\0l\0e\0s\0_\0p\0a\0g\0o\0s\0!C4\0\0\0\�\0\0F\0\0xV4\0\0\0\0\0c\0a\0j\0e\0r\0o\0\0\0 \Z\0\0\0\0�� \Z\0\0\0�� \Z\0\0\0\0�� \Z\0\0\0�� \Z\0\0\0\0�� \Z\0\0\0�� \Z\0\0\0\0�� \Z\0\0\0�� \Z\0\0\0\0�� \Z\0\0\0�� \Z\0\0\0\0�� \Z\0\0\0�� \Z\0\0\0\0�� \Z\0\0\0�� \Z\0\0\0\0�� \Z\0\0\0�� \Z\0\0\0\0�� \Z\0\0\0�� \Z\0\0\0\0�� \Z\0\0\0�� \Z\0\0\0\0�� \Z\0\0\0�� \Z\0\0\0\0�� \Z\0\0\0�� \Z\0\0\0\0�� \Z\0\0\0�� \Z\0\0\0\0�� \Z\0\0\0��\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0T\0\0\0,\0\0\0,\0\0\0,\0\0\04\0\0\0\0\0\0\0\0\0\0\0#&\0\0S\0\0\0\0\0\0-\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\�\0\0�\0\0�\0\0e\0\0�\0\0H\0\0�\0\0�\0\0�\0\0\0\0\0\0\0\0\0\�\0\0F\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0f\0\0\�\n\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0f\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�-\0\0$\0\0\0\0\0\0\0\0\0\0\r\0\0\0\0\0\0\0\0\0\0\0\0\0�	\0\0\�\0\0xV4\0\0\0V\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0	\0\0\0\n\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0c\0a\0j\0e\0r\0o\0\0\0\0\0�;\0\02\0\0\�h\0\02\0\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�M\0\0\�\0\0Y	\0\0X\0\02\0\0\0\0\0\0\0Y	\0\0X\0\0\0\0\0\0\0���\0\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0p\0a\0g\0o\0s\0_\0c\0a\0j\0e\0r\0o\0\0\0n(\0\0�\0\0n(\0\0\0\0\0\0\0\0\0\0\0���\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0)\0\0�\0\0�	\0\0X\0\02\0\0\0\0\0\0\0�	\0\0X\0\0\0\0\0\0\0���\0\0\0�\0\0\0\0\0\0\0�DB\0Tahoma\0F\0K\0_\0c\0o\0b\0r\0o\0s\0_\0c\0a\0j\0e\0r\0o\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0��\n\0\0����\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0Microsoft DDS Form 2.0\0\0\0\0Embedded Object\0\0\0\0\0�9�q\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\����|\���\0&\0\0\0s\0c\0h\0_\0l\0a\0b\0e\0l\0s\0_\0v\0i\0s\0i\0b\0l\0e\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0d\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0D\0d\0s\0S\0t\0r\0e\0a\0m\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0����\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0U\0\0\0\r\0\0\0\0\0\0S\0c\0h\0e\0m\0a\0 \0U\0D\0V\0 \0D\0e\0f\0a\0u\0l\0t\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0&\0\0������������\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0D\0S\0R\0E\0F\0-\0S\0C\0H\0E\0M\0A\0-\0C\0O\0N\0T\0E\0N\0T\0S\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0,\0\0\0\0\0\0\0����\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0S\0c\0h\0e\0m\0a\0 \0U\0D\0V\0 \0D\0e\0f\0a\0u\0l\0t\0 \0P\0o\0s\0t\0 \0V\06\0\0\0\0\0\0\0\0\0\0\0\0\06\0\0������������\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0���������\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0�\0\0\0������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\07\09\00\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\07\07\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\07\07\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\0,\01\08\07\05\0,\05\0,\01\02\04\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\07\07\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0,\01\02\0,\02\07\01\05\0,\01\01\0,\01\06\06\05\0\0\0\n\0\0\0\n\0\0\0\0\0\0\0D\0\0\0Lv\0\0\0d\0b\0o\0\0\0F\0K\0_\0c\0o\0b\0r\0o\0s\0_\0d\0e\0t\0a\0l\0l\0e\0s\0_\0c\0o\0b\0r\0o\0s\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0\0\0\0\0\0\0\n\0\0\0\0\0\0\rJ\Z\�\rJ\Z\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0@\0\0\0��\0\0\0d\0b\0o\0\0\0F\0K\0_\0p\0a\0g\0o\0s\0_\0d\0e\0t\0a\0l\0l\0e\0s\0_\0p\0a\0g\0o\0s\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0\r\0\0\0\r\0\0\0\0\0\0\0\0\0\rJ\Z�\rJ\Z\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0(\0\0\0A\0c\0t\0i\0v\0e\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0\0\0\0\0\0\0\0\0\01\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\00\0\0\0\0\0\0\0:\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\00\07\00\0,\01\0,\01\06\09\05\0,\05\0,\01\01\02\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\01\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\02\09\05\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\02\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\00\07\00\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\03\0\0\0\0\0\0\0\0\0\02\0,\00\0,\02\08\04\0,\00\0,\02\00\07\00\0\0\0 \0\0\0T\0a\0b\0l\0e\0V\0i\0e\0w\0M\0o\0d\0e\0:\04\0\0\0\0\0\0\0>\0\0\04\0,\00\0,\02\08\04\0,\00\0,\02\00\07\00\0,\01\02\0,\02\04\04\05\0,\01\01\0,\01\05\00\00\0\0\0\0\0\0\0\0\0\0\0\0\00\0\0\0�\0\0\0d\0b\0o\0\0\0F\0K\0_\0p\0a\0g\0o\0s\0_\0c\0a\0j\0e\0r\0o\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�o\Z\�o\Z\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\02\0\0\0�\�\0\0\0d\0b\0o\0\0\0F\0K\0_\0c\0o\0b\0r\0o\0s\0_\0c\0a\0j\0e\0r\0o\0\0\0\0\0\0\0\0\0\0\0\�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0J.\ZPJ.\Z\0\0\0\0\0\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0|\0\0\0M\0\0\0\n\0\0\0\0\0\0\0\0\0�\0\0\0M\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\01\0\0\0\0\0\0\0\0\0\0\0\0C\0\0\0�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0Na�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\�\�\��\��Q\0�\�W9\0\0\0��\Z�0\�\0\0HE\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�\0\0D\0a\0t\0a\0 \0S\0o\0u\0r\0c\0e\0=\0.\0;\0I\0n\0i\0t\0i\0a\0l\0 \0C\0a\0t\0a\0l\0o\0g\0=\0p\0u\0n\0t\0o\0_\0v\0e\0n\0t\0a\0;\0P\0e\0r\0s\0i\0s\0t\0 \0S\0e\0c\0u\0r\0i\0t\0y\0 \0I\0n\0f\0o\0=\0T\0r\0u\0e\0;\0U\0s\0e\0r\0 \0I\0D\0=\0d\0e\0x\0t\0r\0o\0y\0e\0x\0;\0M\0u\0l\0t\0i\0p\0l\0e\0A\0c\0t\0i\0v\0e\0R\0e\0s\0u\0l\0t\0S\0e\0t\0s\0=\0F\0a\0l\0s\0e\0;\0P\0a\0c\0k\0e\0t\0 \0S\0i\0z\0e\0=\04\00\09\06\0;\0A\0p\0p\0l\0i\0c\0a\0t\0i\0o\0n\0 \0N\0a\0m\0e\0=\0\"\0M\0i\0c\0r\0o\0s\0o\0f\0t\0 \0S\0Q\0L\0 \0S\0e\0r\0v\0e\0r\0 \0M\0a\0n\0a\0g\0e\0m\0e\0n\0t\0 \0S\0t\0u\0d\0i\0o\0\"\0\0\0\0�\0\0\0\0D\0i\0a\0g\0r\0a\0m\0_\01\0\0\0\0&\0 \0\0\0c\0o\0b\0r\0o\0s\0_\0d\0e\0t\0a\0l\0l\0e\0s\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0\0\0\0c\0o\0b\0r\0o\0s\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0\0\0\0p\0a\0g\0o\0s\0_\0d\0e\0t\0a\0l\0l\0e\0s\0\0\0\0\0\0d\0b\0o\0\0\0\0&\0\0\0\0p\0a\0g\0o\0s\0\0\0\0\0\0d\0b\0o\0\0\0\0$\0\0\0\0c\0a\0j\0e\0r\0o\0\0\0\0\0\0d\0b\0o\0\0\0\0\0\0օ	��k�E��7d�2p\0N\0\0\0{\01\06\03\04\0C\0D\0D\07\0-\00\08\08\08\0-\04\02\0E\03\0-\09\0F\0A\02\0-\0B\06\0D\03\02\05\06\03\0B\09\01\0D\0}\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0b�R');
/*!40000 ALTER TABLE `sysdiagrams` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tarjetas_credito`
--

DROP TABLE IF EXISTS `tarjetas_credito`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tarjetas_credito` (
  `codigo` int(11) NOT NULL,
  `nombre` longtext CHARACTER SET utf8 NOT NULL,
  `activo` tinyint(4) NOT NULL DEFAULT '1',
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tarjetas_credito`
--

LOCK TABLES `tarjetas_credito` WRITE;
/*!40000 ALTER TABLE `tarjetas_credito` DISABLE KEYS */;
INSERT INTO `tarjetas_credito` VALUES (1,'VISA',1),(2,'MASTERCARD',1);
/*!40000 ALTER TABLE `tarjetas_credito` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipo_comprobante_fiscal`
--

DROP TABLE IF EXISTS `tipo_comprobante_fiscal`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tipo_comprobante_fiscal` (
  `codigo` int(11) NOT NULL,
  `secuencia` varchar(2) CHARACTER SET utf8 NOT NULL,
  `nombre` varchar(100) COLLATE utf8_bin NOT NULL,
  `activo` tinyint(4) NOT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipo_comprobante_fiscal`
--

LOCK TABLES `tipo_comprobante_fiscal` WRITE;
/*!40000 ALTER TABLE `tipo_comprobante_fiscal` DISABLE KEYS */;
INSERT INTO `tipo_comprobante_fiscal` VALUES (1,'01','CREDITO FISCAL',1),(2,'02','CONSUMIDOR FINAL',1);
/*!40000 ALTER TABLE `tipo_comprobante_fiscal` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipo_cuenta_bancaria`
--

DROP TABLE IF EXISTS `tipo_cuenta_bancaria`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tipo_cuenta_bancaria` (
  `codigo` int(11) NOT NULL,
  `descripcion` varchar(50) COLLATE utf8_bin NOT NULL,
  `estado` tinyint(3) unsigned NOT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipo_cuenta_bancaria`
--

LOCK TABLES `tipo_cuenta_bancaria` WRITE;
/*!40000 ALTER TABLE `tipo_cuenta_bancaria` DISABLE KEYS */;
/*!40000 ALTER TABLE `tipo_cuenta_bancaria` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipo_identificacion`
--

DROP TABLE IF EXISTS `tipo_identificacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tipo_identificacion` (
  `codigo` int(11) NOT NULL,
  `nombre` varchar(50) COLLATE utf8_bin DEFAULT NULL,
  `estado` tinyint(3) unsigned DEFAULT '1',
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipo_identificacion`
--

LOCK TABLES `tipo_identificacion` WRITE;
/*!40000 ALTER TABLE `tipo_identificacion` DISABLE KEYS */;
/*!40000 ALTER TABLE `tipo_identificacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipo_movimiento_inventario`
--

DROP TABLE IF EXISTS `tipo_movimiento_inventario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tipo_movimiento_inventario` (
  `codigo` varchar(5) COLLATE utf8_bin NOT NULL,
  `nombre` varchar(100) COLLATE utf8_bin NOT NULL,
  `estado` tinyint(3) unsigned NOT NULL DEFAULT '1',
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipo_movimiento_inventario`
--

LOCK TABLES `tipo_movimiento_inventario` WRITE;
/*!40000 ALTER TABLE `tipo_movimiento_inventario` DISABLE KEYS */;
/*!40000 ALTER TABLE `tipo_movimiento_inventario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `transferencia_inventario`
--

DROP TABLE IF EXISTS `transferencia_inventario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `transferencia_inventario` (
  `codigo` int(11) NOT NULL,
  `tipo_movimiento` varchar(5) COLLATE utf8_bin DEFAULT '3',
  `cod_producto` int(11) NOT NULL,
  `cod_unidad` int(11) NOT NULL,
  `cantidad` decimal(20,2) NOT NULL,
  `fecha` date NOT NULL,
  `codigo_sucursal_origen` int(11) DEFAULT NULL,
  `codigo_almacen_origen` int(11) DEFAULT NULL,
  `codigo_sucursal_destino` int(11) DEFAULT NULL,
  `codigo_almacen_destino` int(11) DEFAULT NULL,
  `codigo_empleado` int(11) DEFAULT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transferencia_inventario`
--

LOCK TABLES `transferencia_inventario` WRITE;
/*!40000 ALTER TABLE `transferencia_inventario` DISABLE KEYS */;
/*!40000 ALTER TABLE `transferencia_inventario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `unidad`
--

DROP TABLE IF EXISTS `unidad`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `unidad` (
  `codigo` int(11) NOT NULL,
  `nombre` varchar(150) CHARACTER SET utf8 NOT NULL,
  `activo` tinyint(4) NOT NULL DEFAULT '1',
  `unidad_abreviada` varchar(10) CHARACTER SET utf8 DEFAULT '',
  PRIMARY KEY (`codigo`),
  UNIQUE KEY `nombre_UNIQUE` (`nombre`),
  UNIQUE KEY `unidad_abreviada_UNIQUE` (`unidad_abreviada`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `unidad`
--

LOCK TABLES `unidad` WRITE;
/*!40000 ALTER TABLE `unidad` DISABLE KEYS */;
/*!40000 ALTER TABLE `unidad` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `vendedor`
--

DROP TABLE IF EXISTS `vendedor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `vendedor` (
  `codigo` int(11) NOT NULL,
  `porciento` decimal(2,2) DEFAULT NULL,
  `activo` tinyint(4) DEFAULT '1',
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vendedor`
--

LOCK TABLES `vendedor` WRITE;
/*!40000 ALTER TABLE `vendedor` DISABLE KEYS */;
INSERT INTO `vendedor` VALUES (5,0.10,1);
/*!40000 ALTER TABLE `vendedor` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-11-19 13:36:09
