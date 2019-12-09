create database Pelaajadb;

use Pelaajadb;

create table tilasto (
id int primary key identity(1,1),
nimi nvarchar(255) not null,
taso int not null,
aika datetime not null
);
