create procedure sp_move_employee_into_archive(idEmployee int)
language sql
as $$
insert into employees_archive (	id
								,sFirstName
								,sLastName
								,iAge
								,dEmploymentDate
								,idJobTitle
								,sJobTitleName
								,mSalary
								,idDepartment
								,sDepartmentName
								,sHeadLastName)
select 	id
		,sFirstName
		,sLastName
		,iAge
		,dEmploymentDate
		,idJobTitle
		,sJobTitleName
		,mSalary
		,idDepartment
		,sDepartmentName
		,sHeadLastName
from vdremployee
where id = idEmployee
$$;