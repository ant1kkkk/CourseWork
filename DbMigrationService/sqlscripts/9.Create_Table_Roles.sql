CREATE TABLE Roles (
    idRole INT generated always as identity primary key,
    sRoleName VARCHAR(20) NOT NULL
);

INSERT INTO Roles (sRoleName)
SELECT 'Admin' UNION ALL
SELECT 'User';

CREATE TABLE Users (
                       idUser INT generated always as identity primary key,
                       sUserName varchar(50) NOT NULL,
                       sFirstName varchar(20) NOT NULL,
                       idRole INT NOT NULL REFERENCES roles (idRole) on delete cascade,
                       sPassword varchar(300) NOT NULL
);

create view vdruser as
select  usr.idUser
     ,usr.sUserName
     ,usr.sFirstName
     ,usr.sPassword
     ,rls.sRoleName
from users as usr 	inner join roles 	as rls 		on usr.idRole 	= rls.idRole;



INSERT INTO Users (sUserName, sFirstName, idRole, sPassword)
VALUES ('Admin', 'Admin', (SELECT idRole FROM Roles WHERE sRoleName = 'Admin'), 'AQAAAAIAAYagAAAAEH4+jMeYKnZtZYj8C96pqSOUt5/KyT0biQOP9D5CVYqgYOR/bE4rTzmneC/sxW2tYA==');

