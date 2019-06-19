DROP TABLE colaboradores;
CREATE TABLE colaboradores(
id INT PRIMARY KEY IDENTITY (1,1),
nome VARCHAR(50),
cpf VARCHAR(20),
salario DECIMAL(6,2),
sexo VARCHAR(50),
cargo VARCHAR (50),
programador VARCHAR(10)
);

SELECT*FROM colaboradores;