CREATE TABLE myfinance.dbo.planoconta (
	id int IDENTITY(0,1) NOT NULL,
	descricao varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	tipo char(1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	CONSTRAINT pk PRIMARY KEY (id)
);

CREATE TABLE myfinance.dbo.transacao (
	id int IDENTITY(1,1) NOT NULL,
	[data] datetime2 NOT NULL,
	valor decimal(9,2) NOT NULL,
	historico varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS DEFAULT NULL NULL,
	planoconta_id int NOT NULL,
	CONSTRAINT PK__transaca__3213E83F2D6C707B PRIMARY KEY (id)
);


ALTER TABLE myfinance.dbo.transacao ADD CONSTRAINT transacao_ibfk_1 FOREIGN KEY (planoconta_id) REFERENCES myfinance.dbo.planoconta(id);


INSERT INTO myfinance.dbo.planoconta
(id, descricao, tipo)
VALUES(1, N'Salário', N'R');
INSERT INTO myfinance.dbo.planoconta
(id, descricao, tipo)
VALUES(2, N'Alimentação', N'R');
INSERT INTO myfinance.dbo.planoconta
(id, descricao, tipo)
VALUES(3, N'Casa', N'D');
INSERT INTO myfinance.dbo.planoconta
(id, descricao, tipo)
VALUES(4, N'Infra', N'D');

