create table Departments (
idDepartment int generated always as identity primary key,
sDepartmentName varchar(120) not null,
dDepartmentCreationDate date not null,
dHeadAppointmentDate date null);

insert into departments (sDepartmentName, dDepartmentCreationDate, dHeadAppointmentDate)
values ('Автоматизации и развития', '2025-12-21', '2025-12-12');