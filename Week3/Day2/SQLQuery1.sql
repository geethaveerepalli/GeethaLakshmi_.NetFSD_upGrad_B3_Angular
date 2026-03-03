-- Create Database
CREATE DATABASE EventDb;

-- Use the Database
USE EventDb;

-----------------------------------------------------
-- 1. UserInfo Table
-----------------------------------------------------
CREATE TABLE UserInfo (
    EmailId VARCHAR(100) PRIMARY KEY,
    UserName VARCHAR(50) NOT NULL CHECK (LEN(UserName) BETWEEN 1 AND 50),
    Role VARCHAR(20) NOT NULL CHECK (Role IN ('Admin','Participant')),
    Password VARCHAR(20) NOT NULL CHECK (LEN(Password) BETWEEN 6 AND 20)
);

-----------------------------------------------------
-- 2. EventDetails Table
-----------------------------------------------------
CREATE TABLE EventDetails (
    EventId INT PRIMARY KEY,
    EventName VARCHAR(50) NOT NULL,
    EventCategory VARCHAR(50) NOT NULL,
    EventDate DATETIME NOT NULL,
    Description VARCHAR(200),
    Status VARCHAR(20) CHECK (Status IN ('Active','In-Active'))
);

-----------------------------------------------------
-- 3. SpeakersDetails Table
-----------------------------------------------------
CREATE TABLE SpeakersDetails (
    SpeakerId INT PRIMARY KEY,
    SpeakerName VARCHAR(50) NOT NULL
);

-----------------------------------------------------
-- 4. SessionInfo Table
-----------------------------------------------------
CREATE TABLE SessionInfo (
    SessionId INT PRIMARY KEY,
    EventId INT NOT NULL,
    SessionTitle VARCHAR(50) NOT NULL,
    SpeakerId INT NOT NULL,
    Description VARCHAR(200),
    SessionStart DATETIME NOT NULL,
    SessionEnd DATETIME NOT NULL,
    SessionUrl VARCHAR(200),
    FOREIGN KEY (EventId) REFERENCES EventDetails(EventId),
    FOREIGN KEY (SpeakerId) REFERENCES SpeakersDetails(SpeakerId)
);

-----------------------------------------------------
-- 5. ParticipantEventDetails Table
-----------------------------------------------------
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

-----------------------------------------------------
-- Insert Sample Data
-----------------------------------------------------
INSERT INTO UserInfo VALUES
('geetha@gmail.com','Geetha','Participant','pass123');

INSERT INTO EventDetails VALUES
(1,'AI Workshop','Technology','2026-04-10','AI Learning Session','Active');

INSERT INTO SpeakersDetails VALUES
(1,'Dr. Ramesh');

INSERT INTO SessionInfo VALUES
(1,1,'Introduction to AI',1,'Basics of AI',
'2026-04-10 10:00:00',
'2026-04-10 12:00:00',
'www.ai-session.com');

INSERT INTO ParticipantEventDetails VALUES
(1,'geetha@gmail.com',1,1,1);

-----------------------------------------------------
-- View Data
-----------------------------------------------------
SELECT * FROM UserInfo;
SELECT * FROM EventDetails;
SELECT * FROM SpeakersDetails;
SELECT * FROM SessionInfo;
SELECT * FROM ParticipantEventDetails;