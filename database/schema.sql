-- *************************************************************************************************
-- This script creates all of the database objects (tables, constraints, etc) for the database
-- *************************************************************************************************
use master
    drop database techdin;
    create database techdin;
	
    use techdin;
    -- CREATE statements go here

    create table Invitations
    (
        InvID int identity(1,1) not null,
        Email varchar(255) not null,
        InvKey varchar(32) unique not null,
        constraint pk_invitations primary key (InvID)
    )

    create table Users
    (
        UserID int IDENTITY(1,1) not null,
        Username varchar(32) not null,
		Password varchar(144) not null,
		Salt varchar(8) not null,
		AcctType int,
        --students, staff, employers, companies, institutions, skill
		PrimaryLanguage varchar(20),
        Email varchar(255),
		Header varchar(100),
		FirstName varchar(32),
		LastName varchar(32),
		Description varchar(500),
		LinkedIn varchar(64),
		Repository varchar(64),
		ImagePath varchar(100),
		ResumePath varchar(100),
        HomePhone varchar(25),
        CellPhone varchar(25),
		AuthToken varchar(48),
        Views int,
        CohortID int,
        constraint pk_users PRIMARY KEY (UserID)
    )

	create table Skills 
	(
		SkillID int IDENTITY(1,1) not null,
		SkillName varchar(64)
		constraint pk_skills PRIMARY KEY (SkillID)
	)

	create table UserSkills
	(
		UserID int,
		SkillID int,
		CONSTRAINT pk_user_skills PRIMARY KEY(UserID, SkillID)
	)

    create table InterestsUsers
    (
        UserID int,
        InterestID int,
        constraint pk_InterestsUsers PRIMARY KEY(UserID, InterestID)
    )

    create table Cohorts
    (
        CohortID int IDENTITY(1,1) not null,
		Language varchar(8) not null,
        Location varchar(20) not null,
		Season varchar(12) not null,
        StartDate DATETIME not null,
        EndDate DATETIME not null,
		IsActive bit not null,
        constraint pk_Cohort PRIMARY KEY(CohortID)
    )
    create table WorkExperience
    (
        WorkID int IDENTITY(1,1) not null,
        UserID int,
        -- fk to users.userid
        OrganizationID int,
        --fk to Organizations.OrganizationID
        Position varchar(100) not null,
        Description varchar(500),
        StartDate DATETIME,
        EndDate DATETIME
            CONSTRAINT pk_WorkExperience PRIMARY KEY(WorkID)
    )


    create table Organizations
    (
        OrganizationID int IDENTITY(1,1) not null,
        OrganizationName varchar(100),
        UserID int, -- fk to users.userid #hashtag account
        CONSTRAINT pk_OrganizationID PRIMARY KEY(OrganizationID)
    )

    create table OrganizationUser
    (
        OrganizationID int,
        --fk to Organizations.OrganizationID
        UserID int,
        --fk to users.userid
        CONSTRAINT pk_ID PRIMARY KEY(OrganizationID, UserID)
    )

    create table Education
    (
        EduID int IDENTITY(1,1) not null,
        UserID int,
        --fk to users.userid
        OrganizationID int,
        --fk to Organizations.OrganizationID
        StartDate DATETIME,
        EndDate DATETIME,
        Degree varchar(100),
        FieldOfStudy varchar(100),
        Grade varchar(100),
        Description varchar(500),
        ActivitiesSocieties varchar(500),
        CONSTRAINT pk_EduID PRIMARY KEY(EduID)
    )

    create table Projects
    (
        ProjectID int IDENTITY(1,1) not null,
        Name varchar(100),
        Description varchar(500),
        CONSTRAINT pk_ProjectID PRIMARY KEY(ProjectID)
    )

    create table ProjectUser
    (
        ProjectID int,
        UserID int,
        CONSTRAINT pk_ProjectUserID PRIMARY key(ProjectID, UserID)
    )

    create table ProjectAttachments
    (
        ProjAttID int IDENTITY(1,1) not null,
        ProjectID int,
        FileName varchar(100),
        constraint pk_ProjAttID PRIMARY KEY(ProjAttID)
    )

    create table ProfileAttachments
    (
        ProfAttID int IDENTITY(1,1) not null,
        UserID int,
        FileName varchar(100),
        CONSTRAINT pk_ProfAttID PRIMARY KEY(ProfAttID)
    )

    create table BlogPosts
    (
        PostID int IDENTITY(1,1) not null,
        UserID int,
        Subject varchar(100),
        Content varchar(500),
        CONSTRAINT pk_PostID PRIMARY KEY(PostID)
    )

    create table NewsFeed
    (
        ChangeID int IDENTITY(1,1) not null,
        UserID int,
        ChangeDate DATETIME,
        ChangeType varchar(50),
        -- reference to the table that was updated
        CONSTRAINT pk_ChangeID PRIMARY KEY (ChangeID)
    )

    alter table NewsFeed add FOREIGN KEY (UserID) REFERENCES Users(UserID)
    alter table BlogPosts add FOREIGN KEY (UserID) REFERENCES Users(UserID)
    alter table ProfileAttachments add FOREIGN KEY (UserID) REFERENCES Users(UserID)
    alter table ProjectAttachments add FOREIGN KEY (ProjectID) REFERENCES Projects(ProjectID)
    alter table ProjectUser add FOREIGN KEY (UserID) REFERENCES Users(UserID)
    alter table ProjectUser add FOREIGN KEY (ProjectID) REFERENCES Projects(ProjectID)
    alter table Education add FOREIGN KEY (UserID) REFERENCES Users(UserID)
    alter table Education add FOREIGN KEY (OrganizationID) REFERENCES Organizations(OrganizationID)
    alter table OrganizationUser add FOREIGN KEY (UserID) REFERENCES Users(UserID)
    alter table OrganizationUser add FOREIGN KEY (OrganizationID) REFERENCES Organizations(OrganizationID)
    alter table Organizations add FOREIGN KEY (UserID) REFERENCES Users(UserID)
    alter table WorkExperience add FOREIGN KEY (UserID) REFERENCES Users(UserID)
    alter table WorkExperience add FOREIGN KEY (OrganizationID) REFERENCES Organizations(OrganizationID)
    alter table InterestsUsers add FOREIGN KEY (UserID) REFERENCES Users(UserID)
    alter table InterestsUsers add FOREIGN KEY (InterestID) REFERENCES Users(UserID)
    alter table Users add FOREIGN KEY (CohortID) REFERENCES Cohorts(CohortID)

	--Create an account with these to test Invitation Codes
	INSERT INTO Invitations VALUES('demo@techelevator.com', '1234')

	--Spring 2019 / Active Cohorts
	INSERT INTO Cohorts (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('C#', 'Pittsburgh', 'Spring', '01/14/2019', '04/19/2019', 1);
	INSERT INTO Cohorts (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('C#', 'Cleveland', 'Spring', '01/14/2019', '04/19/2019', 1);
	INSERT INTO Cohorts (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('C#', 'Columbus', 'Spring', '01/14/2019', '04/19/2019', 1);
	INSERT INTO Cohorts (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('C#', 'Cincinnati', 'Spring', '01/14/2019', '04/19/2019', 1);

	INSERT INTO Cohorts (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('Java', 'Cleveland', 'Spring', '01/14/2019', '04/19/2019', 1);
	INSERT INTO Cohorts (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('Java', 'Pittsburgh', 'Spring', '01/14/2019', '04/19/2019', 1);
	INSERT INTO Cohorts (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('Java', 'Columbus', 'Spring', '01/14/2019', '04/19/2019', 1);
	INSERT INTO Cohorts (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('Java', 'Cincinnati', 'Spring', '01/14/2019', '04/19/2019', 1);

--Summer 2019 / Next Cohort
	INSERT INTO Cohorts (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('C#', 'Pittsburgh', 'Summer', '05/13/2019', '08/16/2019', 0);
	INSERT INTO Cohorts (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('C#', 'Cleveland', 'Summer', '05/13/2019', '08/16/2019', 0);
	INSERT INTO Cohorts (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('C#', 'Columbus', 'Summer', '05/13/2019', '08/16/2019', 0);
	INSERT INTO Cohorts (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('C#', 'Cincinnati', 'Summer', '05/13/2019', '08/16/2019', 0);
	INSERT INTO Cohorts (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('C#', 'Detroit', 'Summer', '05/13/2019', '08/16/2019', 0);

	INSERT INTO Cohorts (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('Java', 'Pittsburgh', 'Summer', '05/13/2019', '08/16/2019', 0);
	INSERT INTO Cohorts (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('Java', 'Cleveland', 'Summer', '05/13/2019', '08/16/2019', 0);
	INSERT INTO Cohorts (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('Java', 'Columbus', 'Summer', '05/13/2019', '08/16/2019', 0);
	INSERT INTO Cohorts (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('Java', 'Cincinnati', 'Summer', '05/13/2019', '08/16/2019', 0);
	INSERT INTO Cohorts (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('Java', 'Detroit', 'Summer', '05/13/2019', '08/16/2019', 0);

--Fall 2018 / Previous Cohort
	INSERT INTO Cohorts (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('C#', 'Pittsburgh', 'Fall', '09/17/2018', '12/21/2018', 0);
	INSERT INTO Cohorts (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('C#', 'Cleveland', 'Fall', '09/17/2018', '12/21/2018', 0);
	INSERT INTO Cohorts (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('C#', 'Columbus', 'Fall', '09/17/2018', '12/21/2018', 0);
	INSERT INTO Cohorts (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('C#', 'Cincinnati', 'Fall', '09/17/2018', '12/21/2018', 0);

	INSERT INTO Cohorts (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('Java', 'Pittsburgh', 'Fall', '09/17/2018', '12/21/2018', 0);
	INSERT INTO Cohorts (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('Java', 'Cleveland', 'Fall', '09/17/2018', '12/21/2018', 0);
	INSERT INTO Cohorts (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('Java', 'Columbus', 'Fall', '09/17/2018', '12/21/2018', 0);
	INSERT INTO Cohorts (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('Java', 'Cincinnati', 'Fall', '09/17/2018', '12/21/2018', 0);

--Summer 2018 / Previous Cohort
	INSERT INTO Cohorts (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('C#', 'Pittsburgh', 'Summer', '05/29/2018', '08/31/2018', 0);
	INSERT INTO Cohorts (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('C#', 'Cleveland', 'Summer', '05/15/2018', '08/17/2018', 0);
	INSERT INTO Cohorts (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('C#', 'Columbus', 'Summer', '05/15/2018', '08/17/2018', 0);
	INSERT INTO Cohorts (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('C#', 'Cincinnati', 'Summer', '05/15/2018', '08/17/2018', 0);

	INSERT INTO Cohorts (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('Java', 'Pittsburgh', 'Summer', '05/29/2018', '08/31/2018', 0);
	INSERT INTO Cohorts (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('Java', 'Cleveland', 'Summer', '05/15/2018', '08/17/2018', 0);
	INSERT INTO Cohorts (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('Java', 'Columbus', 'Summer', '05/15/2018', '08/17/2018', 0);
	INSERT INTO Cohorts (Language, Location, Season, StartDate, EndDate, IsActive) VALUES('Java', 'Cincinnati', 'Summer', '05/15/2018', '08/17/2018', 0);

	--Password is password
	INSERT INTO users (Username, FirstName, LastName, AcctType, Password, Salt, Email, Views, LinkedIn, ImagePath, ResumePath, CohortID) VALUES('Default', 'Default', 'Jones', 3, '0IWBlZ5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8', '0IWBlZ', 'defaultuser@techelevator.com', 0, 'https://www.fakeLinkedIn.com/in/username/', '../users/Default/Default_profileimg.jpg', '../users/Default/Default_resume.pdf', 2);
	INSERT INTO users (Username, FirstName, LastName, AcctType, Password, Salt, Email, Views, LinkedIn, ImagePath, ResumePath, CohortID) VALUES('TestUser', 'Test', 'User', 3, 'JOJOJO5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8', 'JOJOJO', 'testuser@techelevator.com', 0, 'https://www.fakeLinkedIn.com/in/username/', '../users/TestUser/TestUser_profileimg.png', '../users/TestUser/TestUser_resume.pdf', 2);
	INSERT INTO users (Username, FirstName, LastName, AcctType, Password, Salt, Email, Views, LinkedIn, ImagePath, ResumePath, CohortID) VALUES('DetLove', 'Det', 'Roit', 3, '0IWBlZ5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8', '0IWBlZ', 'defaultuser@techelevator.com', 0, 'https://www.fakeLinkedIn.com/in/username/', '../users/DetLove/DetLove_profileimg.png', '../users/DetLove/DetLove_resume.pdf', 9);
	INSERT INTO users (Username, FirstName, LastName, AcctType, Password, Salt, Email, Views, LinkedIn, ImagePath, ResumePath, CohortID) VALUES('Pittlove', 'Pitts', 'Burgh', 3, 'JOJOJO5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8', 'JOJOJO', 'testuser@techelevator.com', 0, 'https://www.fakeLinkedIn.com/in/username/', '../users/PittLove/PittLove_profileimg.jpg', '../users/PittLove/PittLove_resume.pdf', 9);
	INSERT INTO users (Username, FirstName, LastName, AcctType, Password, Salt, Email, Views, LinkedIn, ImagePath, ResumePath, CohortID) VALUES('ColLove', 'Colum', 'Bus', 3, '0IWBlZ5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8', '0IWBlZ', 'defaultuser@techelevator.com', 0, 'https://www.fakeLinkedIn.com/in/username/', '../users/ColLove/ColLove_profileimg.jpg', '../users/ColLove/PittLove_resume.pdf', 5);
	INSERT INTO users (Username, FirstName, LastName, AcctType, Password, Salt, Email, Views, LinkedIn, ImagePath, ResumePath, CohortID) VALUES('CleLove', 'Cleve', 'Land', 3, 'JOJOJO5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8', 'JOJOJO', 'testuser@techelevator.com', 0, 'https://www.fakeLinkedIn.com/in/username/', '../users/CleLove/CleLove_profileimg.png', '../users/CleLove/CleLove_resume.pdf', 5);

	INSERT INTO users (Username, FirstName, LastName, AcctType, Password, Salt, Email, Views, LinkedIn, ImagePath, ResumePath, CohortID) VALUES('Johnisamoose', 'John', 'Hale', 3, '0IWBlZ5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8', '0IWBlZ', 'defaultuser@techelevator.com', 0, 'https://www.fakeLinkedIn.com/in/username/', '../users/Johnisamoose/Johnisamoose_profileimg.png', '../users/Johnisamoose/Johnisamoose_resume.pdf', 1);
	INSERT INTO users (Username, FirstName, LastName, AcctType, Password, Salt, Email, Views, LinkedIn, ImagePath, ResumePath, CohortID) VALUES('TzviS', 'Tzvi', 'Seliger', 3, 'JOJOJO5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8', 'JOJOJO', 'testuser@techelevator.com', 0, 'https://www.fakeLinkedIn.com/in/username/', '../users/TzviS/TzviS_profileimg.png', '../users/TzviS/TzviS_resume.pdf', 1);
	INSERT INTO users (Username, FirstName, LastName, AcctType, Password, Salt, Email, Views, LinkedIn, ImagePath, ResumePath, CohortID) VALUES('JeffR', 'Jeffrey', 'Ruby', 3, '0IWBlZ5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8', '0IWBlZ', 'defaultuser@techelevator.com', 0, 'https://www.fakeLinkedIn.com/in/username/', '../users/JeffR/JeffR_profileimg.png', '../users/JeffR/JeffR_resume.pdf', 1);
	INSERT INTO users (Username, FirstName, LastName, AcctType, Password, Salt, Email, Views, LinkedIn, ImagePath, ResumePath, CohortID) VALUES('MarcusK', 'Marcus', 'Krueger', 3, 'JOJOJO5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8', 'JOJOJO', 'testuser@techelevator.com', 0, 'https://www.fakeLinkedIn.com/in/username/', '../users/MarcusK/MarcusK_profileimg.png', '../users/MarcusK/MarcusK_resume.pdf', 1);
	INSERT INTO users (Username, FirstName, LastName, AcctType, Password, Salt, Email, Views, LinkedIn, ImagePath, ResumePath, CohortID) VALUES('Yaboi', 'Beeg', 'Yoshi', 3, '0IWBlZ5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8', '0IWBlZ', 'defaultuser@techelevator.com', 0, 'https://www.fakeLinkedIn.com/in/username/', '../users/Yaboi/Yaboi_profileimg.png', '../users/Yaboi/Yaboi_resume.pdf', 5);
	INSERT INTO users (Username, FirstName, LastName, AcctType, Password, Salt, Email, Views, LinkedIn, ImagePath, ResumePath, CohortID) VALUES('TheMM', 'Mail', 'Man', 3, 'JOJOJO5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8', 'JOJOJO', 'testuser@techelevator.com', 0, 'https://www.fakeLinkedIn.com/in/username/', '../users/TheMM/TheMM_profileimg.png', '../users/TheMM/TheMM_resume.pdf', 5);

	INSERT INTO users (Username, FirstName, LastName, AcctType, Password, Salt, Email, Views, CohortID) VALUES('Admin', 'Justin', 'Driscoll', 1, '0IWBlZ5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8', '0IWBlZ', 'admin@techelevator.com', 0, 1);

	SELECT * from users
	SELECT * FROM invitations
	SELECT * FROM Cohorts


