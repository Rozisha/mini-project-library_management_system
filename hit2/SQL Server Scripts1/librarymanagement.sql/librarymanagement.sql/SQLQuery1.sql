create database library 

create table NewBook (
bid int not null identity(1,1) primary key,
bName varchar(250) not null,
bAuthor varchar(150) not null,
bPubl varchar(250) not null,
bPrice bigint not null,
bQuan bigint not null
)

bName, bAuthor, bPubl, bPrice,bQuan

select * from NewBook

drop table NewBook





create table NewStudent(
sid int not null identity(1,1) primary key,
sName varchar(250) not null,
sRollNo bigint not null,
sEnrollYr bigint not null,
sProgram varchar(250) not null,
sPhoneNo bigint not null
)

 sName , sRollNo, sEnrollYr, sProgram, sPhoneNo

select * from NewStudent

drop table NewStudent





create table IRBook(
id int not null identity(1,1) primary key,

std_name varchar(250) not null,
std_rollno bigint not null,
std_enrollyr bigint not null,
std_program varchar(250) not null,
std_contact bigint not null,
book_name varchar(250) not null,
book_issue_date varchar(250) not null,
book_return_date varchar(250) 
);
select * from IRBook

select * from IRBook where std_rollno='1' and book_return_date is null