create table Departments (
idDepartment int generated always as identity primary key,
sDepartmentName varchar(120) not null,
dDepartmentCreationDate date not null,
dHeadAppointmentDate date null)