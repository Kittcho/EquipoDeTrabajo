--Tabla para identificar el rol de los usuarios
create table cat_tipospersonas
(
id_tipo int not null primary key,
DescripcionTipo varchar(100) not null
);


create table reg_fotos
(
id_foto int not null primary key,
imagen bytea not null
);


create table reg_personas
(
id_persona int not null primary key,
id_tipoPersona int not null references cat_tipospersonas(id_tipo) on update cascade on delete cascade,
cnombres varchar (100) not null,
capellidopat varchar (50) not null,
capellidomat varchar (50),
id_foto int not null references reg_fotos(id_foto) on update cascade on delete cascade,
ctel_cel varchar (15) not null,
ccalle varchar (30) not null,
cnum_casa varchar (10) not null,
ccolonia varchar (30) not null,
ncodigopostal int,
cciudad varchar (30) not null,
huella bytea not null,
bactivo bit not null,
dfechaultimaactualizacion timestamp not null
);

create table reg_ninios
(
id_ninio int not null primary key,
cnombres varchar(100)  not null,
capellidopat varchar(50)  not null,
capellidomat varchar(50)  not null,
huella bytea  not null,
cobservaciones varchar(5000)  not null,
bactivo	bit  not null,
dfechaultimaactualizacion timestamp  not null,
id_persona int not null references reg_personas (id_persona) on update cascade on delete cascade
);


create table reg_checador
(
id_registro int not null primary key,
id_ninio int not null references reg_ninios (id_ninio) on update cascade on delete cascade,
dfecha date not null,
dhoraentrada timestamp not null,
dhorasalida timestamp not null,
id_personaentrega int not null references reg_personas (id_persona) on update cascade on delete cascade,
id_personarecibe int not null references reg_personas (id_persona) on update cascade on delete cascade
);

create table reg_checadorEmpleados
(
id_registro int not null primary key,
id_persona int not null references reg_personas (id_persona) on update cascade on delete cascade,
dfecha date not null,
dhoraentrada timestamp not null,
dhorasalida timestamp not null
);

create table reg_Autorizado
(
id_autorizado int not null primary key,
cnombres varchar(100) not null,
capellidopat varchar(50) not null,
capellidomat varchar(50),
id_foto	int not null references reg_fotos(id_foto) on update cascade on delete cascade,
bactivo	bit not null,
dfechaultimaactualizacion timestamp not null,
id_ninio int not null references reg_ninios (id_ninio) on update cascade on delete cascade,
huella bytea not null
);