CREATE DATABASE FUENTE_SODA

USE FUENTE_SODA
GO




CREATE TABLE CATEGORIA 
(
ID_CAT INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
DES_CAT VARCHAR(35)
)
GO

SET IDENTITY_INSERT CATEGORIA ON

INSERT INTO CATEGORIA (ID_CAT, DES_CAT) VALUES (1, 'BEBIDA');
INSERT INTO CATEGORIA (ID_CAT, DES_CAT) VALUES (2, 'POSTRES');
INSERT INTO CATEGORIA (ID_CAT, DES_CAT) VALUES (3, 'ENTRADA');
INSERT INTO CATEGORIA (ID_CAT, DES_CAT) VALUES (4, 'SEGUNDO');
INSERT INTO CATEGORIA (ID_CAT, DES_CAT) VALUES (5, 'MERIENDA');
SET IDENTITY_INSERT CATEGORIA Off

create TABLE PRODUCTO
(
IDE_PRO INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
DES_PRO VARCHAR(40),
IDE_CAT INT  ,
PRE_PRO decimal,
STO_PRO INT,
IMG_PRO VARCHAR(100),
FOREIGN KEY (IDE_CAT) REFERENCES CATEGORIA(ID_CAT)
)
GO
Alter TABLE PRODUCTO
ALTER COLUMN PRE_PRO decimal


SELECT * FROM PRODUCTO
SET IDENTITY_INSERT PRODUCTO ON
INSERT INTO PRODUCTO (IDE_PRO, DES_PRO, IDE_CAT, PRE_PRO , STO_PRO , IMG_PRO ) VALUES (1, 'TORTA FRIA', 2 , 35, 2000, null );
INSERT INTO PRODUCTO (IDE_PRO, DES_PRO, IDE_CAT, PRE_PRO , STO_PRO , IMG_PRO ) VALUES (2, 'EMPANADA', 2 , 3, 2000, null );
INSERT INTO PRODUCTO (IDE_PRO, DES_PRO, IDE_CAT, PRE_PRO , STO_PRO , IMG_PRO ) VALUES (3, 'SOPA', 3 , 5, 2000, null );
INSERT INTO PRODUCTO (IDE_PRO, DES_PRO, IDE_CAT, PRE_PRO , STO_PRO , IMG_PRO ) VALUES (4, 'POLLO A LA BRASA', 4 , 28, 2000, null );
INSERT INTO PRODUCTO (IDE_PRO, DES_PRO, IDE_CAT, PRE_PRO , STO_PRO , IMG_PRO ) VALUES (5, 'PASTICHO', 4 , 15, 2000, null );
INSERT INTO PRODUCTO (IDE_PRO, DES_PRO, IDE_CAT, PRE_PRO , STO_PRO , IMG_PRO ) VALUES (6, 'PABELLON', 4 , 16, 2000, null );
INSERT INTO PRODUCTO (IDE_PRO, DES_PRO, IDE_CAT, PRE_PRO , STO_PRO , IMG_PRO ) VALUES (7, 'QUESILLO', 5 , 7, 2000, null );
INSERT INTO PRODUCTO (IDE_PRO, DES_PRO, IDE_CAT, PRE_PRO , STO_PRO , IMG_PRO ) VALUES (8, 'CERVEZA', 1 , 6, 2000, null );
SET IDENTITY_INSERT PRODUCTO Off


CREATE TABLE DISTRITO
(
IDE_DIS INT PRIMARY KEY IDENTITY(1,1),
DES_DIS VARCHAR(50)
)

select * from DISTRITO
SET IDENTITY_INSERT DISTRITO ON
INSERT INTO DISTRITO (IDE_DIS, DES_DIS ) VALUES (1, 'INDEPENDENCIA' );
INSERT INTO DISTRITO (IDE_DIS, DES_DIS ) VALUES (2, 'LA MOLINA' );
INSERT INTO DISTRITO (IDE_DIS, DES_DIS ) VALUES (3, 'SURCO' );
INSERT INTO DISTRITO (IDE_DIS, DES_DIS ) VALUES (4, 'SAN MARTIN DE PORRES' );
INSERT INTO DISTRITO (IDE_DIS, DES_DIS ) VALUES (5, 'MIRAFLORES' );
INSERT INTO DISTRITO (IDE_DIS, DES_DIS ) VALUES (6, 'LOS OLIVOS' );
INSERT INTO DISTRITO (IDE_DIS, DES_DIS ) VALUES (7, 'SAN MIGUEL' );
INSERT INTO DISTRITO (IDE_DIS, DES_DIS ) VALUES (8, 'LA VICTORIA' );
SET IDENTITY_INSERT DISTRITO Off



CREATE TABLE CLIENTE
(
IDE_CLI INT IDENTITY(1,1) PRIMARY KEY,
NOM_CLI VARCHAR(50),
MOV_CLI VARCHAR(15),
IDE_DIS INT,
COR_CLI VARCHAR(50),
FOREIGN KEY (IDE_DIS) REFERENCES DISTRITO(IDE_DIS)
)


SET IDENTITY_INSERT CLIENTE ON
INSERT INTO CLIENTE (IDE_CLI, NOM_CLI , MOV_CLI , IDE_DIS , COR_CLI  ) VALUES (1, 'LUIS TORRES', 926901319, 1 , 'luiseduardotorres@gmail.com' );
SET IDENTITY_INSERT CLIENTE Off

CREATE TABLE VENDEDOR 
(
IDE_VEN INT PRIMARY KEY IDENTITY(1,1),
NOM_VEN VARCHAR(30),
APE_VEN VARCHAR(30),
DIR_VEN VARCHAR(30),
TEL_VEN VARCHAR(15),
IDE_DIS INT,
COR_VEN VARCHAR(50),
SUE_VEN MONEY,
FOTO image
FOREIGN KEY (IDE_DIS) REFERENCES DISTRITO(IDE_DIS)
)
GO



CREATE TABLE BOLETA
(
NUM_BOL INT PRIMARY KEY IDENTITY(1,1),
FEC_BOL DATE,
IDE_CLI INT,
IDE_VEN INT,
FOREIGN KEY (IDE_VEN) REFERENCES VENDEDOR(IDE_VEN),
FOREIGN KEY (IDE_CLI) REFERENCES CLIENTE(IDE_CLI)
)
GO

CREATE TABLE DETALLEBOLETA
(
NUM_BOL INT primary key,
IDE_PRO INT,
CAN_ART INT,
FOREIGN KEY (IDE_PRO) REFERENCES PRODUCTO(IDE_PRO),
FOREIGN KEY (NUM_BOL) REFERENCES BOLETA(NUM_BOL)
)
GO

CREATE TABLE VENTA
(
ID_VEN INT PRIMARY KEY IDENTITY,
DIA_VEN DATETIME,
SUB_TOT decimal,
IVA decimal,
TOTAL decimal
)



CREATE TABLE LISTAVENTA 
(
ID_LIS_VEN INT PRIMARY KEY IDENTITY ,
ID_VEN INT ,
ID_PRO INT,
CAN_LIS_VEN INT,
TOTAL decimal
FOREIGN KEY (ID_VEN) REFERENCES VENTA,
FOREIGN KEY (ID_PRO) REFERENCES PRODUCTO,

)

