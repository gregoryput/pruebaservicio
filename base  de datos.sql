create database DataServicio
use DataServicio


create table CategoriaServicio(
CategoriaID int identity primary key(CategoriaID),
NombreCategoria varchar(50)
)

insert into CategoriaServicio (NombreCategoria) values ('PLAN PRIMIUM'),('PLAN RECOMENDADO'),('PLAN BASICO')
select * from CategoriaServicio

create table Servicios(
ServicioID int identity primary key(ServicioID),
NombreServicio varchar(50),
CategoriaID  int CONSTRAINT Fk_Categoria FOREIGN KEY  REFERENCES CategoriaServicio(CategoriaID)
)
insert into Servicios (NombreServicio,CategoriaID) values ('SERVICIO TV',2),('SERVICIO TV',3),('SERVICIO TV',1)
select * from Servicios

create table Usuario(
UsuarioID int identity primary key(UsuarioID),
NombreUsuario varchar(20),
Correo varchar(30),
Password varchar(30)
)

create table Clientes(
ClienteID int identity primary key(ClienteID),
NombreCompleto varchar(100),
RNC Varchar(50) UNIQUE,
Direccion varchar(100),
Sector varchar(100),
Ciudad varchar(100),
Provincia varchar(100),
Telefono varchar(50) UNIQUE,
Correo varchar(100)
)

insert into Clientes(NombreCompleto,RNC,Direccion,Sector,Ciudad,Provincia,Telefono,Correo) values ('Gregory Sanchez','402-1326189-1','calle teniente casa #23','villa progreso','villa hermosa','La Romana','809-698-5266','sanchez7878@hotmail.com'),
					(' Sanchez','402-1173189-1','calle teniente casa #23','villa progreso','villa hermosa','La Romana','829-638-5266','saez7878@hotmail.com'),
					('albert Sanchez','402-1276189-1','calle teniente casa #23','villa progreso','villa hermosa','La Romana','829-691-5266','sanchez8@hotmail.com')
select * from Clientes

create table Factura(
FacturaID int identity primary key (FacturaID),
Fecha datetime,
ClienteID int CONSTRAINT Fk_IDCLIENTE Foreign key References Clientes(ClienteID)
)
insert into Factura (Fecha,ClienteID) values (GETDATE(),1)
select * from Factura

create table FacturaDetalle(
DetalleID int identity primary key (DetalleID),
FacturaID int CONSTRAINT Fk_FAC_ID  FOREIGN KEY References Factura(FacturaID),
Servicio int CONSTRAINT Fk_Serv_ID  FOREIGN KEY References Servicios(ServicioID),
Precio money,
Cantidad int
)

insert into FacturaDetalle (FacturaID,Servicio,precio,cantidad) values (1,2,1000,2)
select * from FacturaDetalle


select * from Factura a
inner join FacturaDetalle b on b.facturaID = a.facturaID