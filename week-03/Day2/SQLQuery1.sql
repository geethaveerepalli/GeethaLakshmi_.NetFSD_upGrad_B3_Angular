USE EventDb;

CREATE TABLE UserInfo (
    EmailId VARCHAR(100) PRIMARY KEY,
    UserName VARCHAR(50) NOT NULL CHECK (LEN(UserName) BETWEEN 1 AND 50),
    Role VARCHAR(20) NOT NULL CHECK (Role IN ('Admin','Participant')),
    Password VARCHAR(20) NOT NULL CHECK (LEN(Password) BETWEEN 6 AND 20)
);

INSERT INTO UserInfo VALUES('geetha@gmail.com','Geetha','Participant','pass123');


INSERT INTO SpeakersDetails VALUES(1,'Dr. Ramesh');

CREATE TABLE EventDetails (
    EventId INT PRIMARY KEY,
    EventName VARCHAR(50) NOT NULL CHECK (LEN(EventName) BETWEEN 1 AND 50),
    EventCategory VARCHAR(50) NOT NULL CHECK (LEN(EventCategory) BETWEEN 1 AND 50),
    EventDate DATETIME NOT NULL,
    Description VARCHAR(200) NULL,
    Status VARCHAR(20) CHECK (Status IN ('Active','In-Active'))
);

INSERT INTO EventDetails VALUES(3,'AI Workshop','Technology','2026-04-10','AI Learning Session','Active');

CREATE TABLE SpeakersDetails (
    SpeakerId INT PRIMARY KEY,
    SpeakerName VARCHAR(50) NOT NULL CHECK (LEN(SpeakerName) BETWEEN 1 AND 50)
);

INSERT INTO SpeakersDetails VALUES(4,'Dr. Ramesh');


CREATE TABLE SessionInfo (
    SessionId INT PRIMARY KEY,
    EventId INT NOT NULL,
    SessionTitle VARCHAR(50) NOT NULL CHECK (LEN(SessionTitle) BETWEEN 1 AND 50),
    SpeakerId INT NOT NULL,
    Description VARCHAR(200) NULL,
    SessionStart DATETIME NOT NULL,
    SessionEnd DATETIME NOT NULL,
    SessionUrl VARCHAR(200) NULL,
    FOREIGN KEY (EventId) REFERENCES EventDetails(EventId),
    FOREIGN KEY (SpeakerId) REFERENCES SpeakersDetails(SpeakerId)
);

INSERT INTO SessionInfo VALUES
(1,1,'Introduction to AI',1,'Basics of AI',
'2026-04-10 10:00:00',
'2026-04-10 12:00:00',
'www.ai-session.com');

CREATE TABLE ParticipantEventDetails (
    Id INT PRIMARY KEY,
    ParticipantEmailId VARCHAR(100) NOT NULL,
    EventId INT NOT NULL,
    SessionId INT NOT NULL,
    IsAttended BIT CHECK (IsAttended IN (0,1)),
    FOREIGN KEY (ParticipantEmailId) REFERENCES UserInfo(EmailId),
    FOREIGN KEY (EventId) REFERENCES EventDetails(EventId),
    FOREIGN KEY (SessionId) REFERENCES SessionInfo(SessionId)
);

INSERT INTO ParticipantEventDetails VALUES(1,'geetha@gmail.com',1,1,1);

SELECT * FROM UserInfo;
SELECT * FROM EventDetails;
SELECT * FROM SpeakersDetails;
SELECT * FROM SessionInfo;
SELECT * FROM ParticipantEventDetails;
SELECT EmailId,UserName FROM UserInfo;