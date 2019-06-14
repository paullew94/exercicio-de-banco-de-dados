CREATE TABLE colaboradores(
id INT PRIMARY KEY IDENTITY (1,1),
nome VARCHAR(50),
Cpf VARCHAR(14),
salario DECIMAL(6,2),
sexo VARCHAR(50),
cargo VARCHAR (50),
programador BIT
);