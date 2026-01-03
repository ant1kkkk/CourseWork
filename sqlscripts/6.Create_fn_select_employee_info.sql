create function fn_select_employee_info(idEmployee int) returns setof vdremployee as $$
	select *
	from vdremployee
	where id = idEmployee;
$$ language sql;