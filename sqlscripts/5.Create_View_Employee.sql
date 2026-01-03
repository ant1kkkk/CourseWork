create view vdremployee as
select 	empl.id
		,empl.sfirstname
		,empl.slastname
		,empl.iage
		,empl.demploymentdate
		,jls.idjobtitle
		,jls.sjobtitlename
		,jls.msalary
		,dep.iddepartment
		,dep.sdepartmentname
		,empl_2.slastname as sHeadLastName
from employees as empl 	inner join jobtitles 	as jls 		on empl.idjobtitle 	= jls.idjobtitle
						inner join departments 	as dep 		on empl.idDepartment = dep.idDepartment
						inner join employees 	as empl_2 	on dep.idHead = empl_2.id