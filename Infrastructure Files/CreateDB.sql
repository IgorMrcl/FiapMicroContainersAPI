CREATE TABLE notas (
    RM character varying(10) NOT NULL,
    NOME character varying(255),
    MATERIA character varying(255),
    NOTA smallint
);

insert into notas (RM, NOME, MATERIA, NOTA) values('340629', 'Igor Martelo', 'Microcontainers', 9);
insert into notas (RM, NOME, MATERIA, NOTA) values('340434', 'Raphael Casado', 'Microserviços', 8);
insert into notas (RM, NOME, MATERIA, NOTA) values('341989', 'Thaigo Cortano', 'Gestão de Projetos', 10);
insert into notas (RM, NOME, MATERIA, NOTA) values('340982', 'Julia Cadarço', 'Data Analytics', 7);