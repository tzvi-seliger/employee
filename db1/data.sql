-- *****************************************************************************
-- This script contains INSERT statements for populating tables with seed data
-- *****************************************************************************

BEGIN TRANSACTION;
	--Cohorts
	INSERT INTO cohort VALUES('C#', 'Pittsburgh', '01/14/2019', '04/19/2019');
	
	--Projects
	INSERT INTO Projects VALUES('Title 1', 'Description 1');
	INSERT INTO Projects VALUES('Title 2', 'Description 2');
	INSERT INTO Projects VALUES('Title 3', 'Description 3');

	--Users; Password is "password"
	INSERT INTO users (Username, Password, Salt, AcctType, Email, Views, CohortID) VALUES('Default', '0IWBlZ5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8', '0IWBlZ', 2, 'defaultuser@techelevator.com', 0, 1);
	INSERT INTO users (Username, Password, Salt, AcctType, Email, Views, CohortID) VALUES('TestUser', 'JOJOJO5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8', 'JOJOJO', 2, 'testuser@techelevator.com', 0, 1);

	--Project-Users
	INSERT INTO ProjectUser VALUES(1, 1);
	INSERT INTO ProjectUser VALUES(2, 1);
	INSERT INTO ProjectUser VALUES(3, 2);

	--Companies
	INSERT INTO Organizations VALUES('Google');
	INSERT INTO Organizations VALUES('Apple');

	--Companies-Users
	INSERT INTO OrganizationUser VALUES(1, 1); 
	INSERT INTO OrganizationUser VALUES(2, 1); 
	INSERT INTO OrganizationUser VALUES(2, 2); 

COMMIT;