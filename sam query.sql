use hpcommon_test

create table employee (

empid int primary key not null IDENTITY(1,1),
Firstname varchar(50)not null,
Lastname varchar (50),
Contact varchar (15),
Gender varchar (15),
Birthday date 
Age varchar(10)
Address_ varchar(50)
Citizenship varchar(10)
ZIP_Code varchar(10)
Email_Address varchar(100)
Photos Image 

)

 

SELECT * FROM employee

DELETE FROM employee where empid=14


alter table employee
add Photos Image


alter table employee
drop column Photos




