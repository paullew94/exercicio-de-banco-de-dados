CREATE TABLE clientes(
id INT PRIMARY KEY IDENTITY(1,1),
nome VARCHAR(50),
saldo DECIMAL(6,2),
telefone VARCHAR(15),
estado VARCHAR(2),
cidade VARCHAR(50),
bairro VARCHAR(50),
cep VARCHAR(50),
logradouro VARCHAR(50),
numero INT,
complemento VARCHAR(50),
nome_sujo VARCHAR(5),
altura DECIMAL(3,2),
peso DECIMAL(5,2)
);