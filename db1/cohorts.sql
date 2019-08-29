USE techdin
DELETE Cohort;

--Spring 2019 / Active Cohorts
	INSERT INTO Cohort (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('C#', 'Pittsburgh', 'Spring', '01/14/2019', '04/19/2019', 1);
	INSERT INTO Cohort (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('C#', 'Cleveland', 'Spring', '01/14/2019', '04/19/2019', 1);
	INSERT INTO Cohort (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('C#', 'Columbus', 'Spring', '01/14/2019', '04/19/2019', 1);
	INSERT INTO Cohort (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('C#', 'Cincinnati', 'Spring', '01/14/2019', '04/19/2019', 1);

	INSERT INTO Cohort (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('Java', 'Pittsburgh', 'Spring', '01/14/2019', '04/19/2019', 1);
	INSERT INTO Cohort (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('Java', 'Cleveland', 'Spring', '01/14/2019', '04/19/2019', 1);
	INSERT INTO Cohort (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('Java', 'Columbus', 'Spring', '01/14/2019', '04/19/2019', 1);
	INSERT INTO Cohort (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('Java', 'Cincinnati', 'Spring', '01/14/2019', '04/19/2019', 1);

--Summer 2019 / Next Cohort
	INSERT INTO Cohort (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('C#', 'Pittsburgh', 'Summer', '05/13/2019', '08/16/2019', 0);
	INSERT INTO Cohort (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('C#', 'Cleveland', 'Summer', '05/13/2019', '08/16/2019', 0);
	INSERT INTO Cohort (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('C#', 'Columbus', 'Summer', '05/13/2019', '08/16/2019', 0);
	INSERT INTO Cohort (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('C#', 'Cincinnati', 'Summer', '05/13/2019', '08/16/2019', 0);
	INSERT INTO Cohort (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('C#', 'Detroit', 'Summer', '05/13/2019', '08/16/2019', 0);

	INSERT INTO Cohort (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('Java', 'Pittsburgh', 'Summer', '05/13/2019', '08/16/2019', 0);
	INSERT INTO Cohort (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('Java', 'Cleveland', 'Summer', '05/13/2019', '08/16/2019', 0);
	INSERT INTO Cohort (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('Java', 'Columbus', 'Summer', '05/13/2019', '08/16/2019', 0);
	INSERT INTO Cohort (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('Java', 'Cincinnati', 'Summer', '05/13/2019', '08/16/2019', 0);
	INSERT INTO Cohort (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('Java', 'Detroit', 'Summer', '05/13/2019', '08/16/2019', 0);

--Fall 2018 / Previous Cohort
	INSERT INTO Cohort (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('C#', 'Pittsburgh', 'Fall', '09/17/2018', '12/21/2018', 0);
	INSERT INTO Cohort (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('C#', 'Cleveland', 'Fall', '09/17/2018', '12/21/2018', 0);
	INSERT INTO Cohort (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('C#', 'Columbus', 'Fall', '09/17/2018', '12/21/2018', 0);
	INSERT INTO Cohort (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('C#', 'Cincinnati', 'Fall', '09/17/2018', '12/21/2018', 0);

	INSERT INTO Cohort (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('Java', 'Pittsburgh', 'Fall', '09/17/2018', '12/21/2018', 0);
	INSERT INTO Cohort (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('Java', 'Cleveland', 'Fall', '09/17/2018', '12/21/2018', 0);
	INSERT INTO Cohort (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('Java', 'Columbus', 'Fall', '09/17/2018', '12/21/2018', 0);
	INSERT INTO Cohort (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('Java', 'Cincinnati', 'Fall', '09/17/2018', '12/21/2018', 0);

--Summer 2018 / Previous Cohort
	INSERT INTO Cohort (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('C#', 'Pittsburgh', 'Summer', '05/29/2018', '08/31/2018', 0);
	INSERT INTO Cohort (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('C#', 'Cleveland', 'Summer', '05/15/2018', '08/17/2018', 0);
	INSERT INTO Cohort (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('C#', 'Columbus', 'Summer', '05/15/2018', '08/17/2018', 0);
	INSERT INTO Cohort (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('C#', 'Cincinnati', 'Summer', '05/15/2018', '08/17/2018', 0);

	INSERT INTO Cohort (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('Java', 'Pittsburgh', 'Summer', '05/29/2018', '08/31/2018', 0);
	INSERT INTO Cohort (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('Java', 'Cleveland', 'Summer', '05/15/2018', '08/17/2018', 0);
	INSERT INTO Cohort (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('Java', 'Columbus', 'Summer', '05/15/2018', '08/17/2018', 0);
	INSERT INTO Cohort (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('Java', 'Cincinnati', 'Summer', '05/15/2018', '08/17/2018', 0);

--All Cohorts
SELECT * FROM Cohort;

--All C#
SELECT * FROM Cohort WHERE Language = 'C#';

--All Java
SELECT * FROM Cohort WHERE Language = 'Java';

--All Active Cohorts
SELECT * FROM Cohort WHERE IsActive = 1;