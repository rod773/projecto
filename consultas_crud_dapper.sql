select * from cliente where clave = md5('123');

insert into cliente 
(Nombres,Apellidos,Email,Clave)
values ("rod","tro","rod@gmail.com",md5('rod'));

SELECT LAST_INSERT_ID();

delete from cliente where idcliente = last_insert_id();


update cliente 
set Nombres="rod", 
Apellidos="tro", 
Email = "rod@gmail.com",
Clave = md5('rod')
where idcliente = 27;

select email,clave from cliente;

select * from cliente;



select last_insert_id();

select IF(ROW_COUNT() > 0, LAST_INSERT_ID(), 0);




select * from cliente where IdCliente=(SELECT LAST_INSERT_ID());

drop cliente;


delete  from cliente where idcliente>0;


ALTER TABLE `rifa_bd`.`cliente` 
CHANGE COLUMN `IdCliente` `IdCliente` INT NOT NULL ;


ALTER TABLE `rifa_bd`.`cliente` 
CHANGE COLUMN `IdCliente` `IdCliente` INT NOT NULL AUTO_INCREMENT ;


delete from cliente where clave = md5('123456');

select * from cliente;

select * from boleto;

select * from premio;

insert into boleto (idboleto,idcliente) values (2,5) ;

select * from boleto where boleto.idCliente=4;


select premio.idpremio,premio.nombre,premio.idboleto from premio,boleto,cliente
where  boleto.idcliente= 4
and boleto.idboleto = premio.idboleto;





