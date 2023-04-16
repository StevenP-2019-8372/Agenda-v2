create database dbage
go
use dbage
go
create table clientes
(
id varchar(5),
Nombre varchar(50),
Apellido varchar(50),
Direccion varchar(200),
FechaDN varchar(50),
Movil int,
Telefono int,
Correo varchar(100),
Genero varchar(15),
Estado varchar(15)
);
go
create proc sp_listar_clientes
as
select * from clientes order by id
go

create proc sp_buscar_clientes
@Nombre varchar(50)
as
select id,Nombre,Apellido,Direccion,FechaDN,Movil,Telefono,Correo,Genero,Estado from clientes where Nombre like @Nombre + '%'
go

create proc sp_mantenimiento_clientes
@id varchar(5),
@Nombre varchar(50),
@Apellido varchar(50),
@Direccion varchar(200),
@FechaDN varchar(50),
@Movil int,
@Telefono int,
@Correo varchar(100),
@Genero varchar(15),
@Estado varchar(15),
@accion varchar(50) output
as
if(@accion='1')
begin
	declare @idnuevo varchar(5), @idmax varchar(5)
	set @idmax=(select max (id) from clientes)
	set @idmax= isnull(@idmax,'A0000')
	set @idnuevo='A'+RIGHT(RIGHT(@idmax,4)+10001,4)
	insert into clientes(id,Nombre,Apellido,Direccion,FechaDN,Movil,Telefono,Correo,Genero,Estado)
	values(@idnuevo,@Nombre,@Apellido,@Direccion,@FechaDN,@Movil,@Telefono,@Correo,@Genero,@Estado)
	set @accion='Se genero el id: '+@idnuevo
end
else if(@accion='2')
begin
	update clientes set Nombre=@Nombre,Apellido=@Apellido,Direccion=@Direccion,FechaDN=@FechaDN,Movil=@Movil,Telefono=@Telefono,Correo=@Correo,Genero=@Genero,Estado=@Estado where id=@id
	set @accion='Se modifico el id'+@id
end
else if(@accion='3')
begin
	delete from clientes where id=@id
	set @accion='Se borro el id'+@id
end
go
