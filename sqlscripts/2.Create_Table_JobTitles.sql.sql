create table JobTitles(
idJobTitle int generated always as identity primary key,
sJobTitleName varchar(40) not null,
mSalary money not null)