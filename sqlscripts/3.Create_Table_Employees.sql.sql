create table Employees (
id int generated always as identity primary key,
sFirstName varchar(25) not null,
sLastName varchar(25) not null,
iAge int not null,
idJobTitle int not null references JobTitles (idJobTitle) on delete restrict,
idDepartment int NOT NULL REFERENCES Departments (idDepartment) on delete restrict,
dEmploymentDate date not null);

alter table departments add column idHead int null references employees (id) on delete set null;