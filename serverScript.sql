CREATE DATABASE admprodutos;

USE admprodutos;

CREATE TABLE produto (
  id int(11) NOT NULL AUTO_INCREMENT,
  nome varchar(255),
  fabricante varchar(255),
  preco DECIMAL(11,2),
  disponivel bool,
  dataCadastro DATETIME,
  PRIMARY KEY (id)
);