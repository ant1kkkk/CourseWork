insert into jobtitles (sJobTitleName, msalary) 
values ('Рабочий', 500);

insert into departments (sDepartmentName, dDepartmentCreationDate, dHeadAppointmentDate)
values ('Автоматизации и развития', '2025-12-21', '2025-12-12');

insert into employees (sFirstName, sLastName, iAge, idJobTitle, idDepartment, dEmploymentDate) 
values ('John', 'Johnson', 25, 1, 1, '2025-10-10');

update departments
set idHead = 1
where iddepartment = 1