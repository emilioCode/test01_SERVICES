CREATE DATABASE test01;
USE test01;
CREATE TABLE CONTACTS(
	id int NOT NULL AUTO_INCREMENT,
    firstName varchar(100) NOT NULL,
    lastName varchar(100) NOT NULL,
    telephoneNumber varchar(13) NULL,
    birthDate date NOT NULL,
    email varchar(100) NULL,
    civilStatus varchar(10) NULL,
    disabled boolean NOT NULL DEFAULT 0,
    PRIMARY KEY (id)
);

/*
Win-OS
Scaffold-DbContext "server=127.0.0.1;uid=root;pwd=12345678;database=test01" MySql.EntityFrameworkCore -OutputDir Models
MacOS
dotnet ef dbcontext scaffold "server=127.0.0.1;uid=root;pwd=12345678;database=test01" MySql.EntityFrameworkCore -o Models --project test01_SERVICES
*/

