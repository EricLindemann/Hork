

DROP TABLE EerciseSet;
DROP TABLE Exercise;
DROP TABLE ExerciseDetail;
DROP TABLE Workout;

CREATE TABLE ExerciseDetail
	(ExerciseDetailId Int(11) NOT NULL AUTO_INCREMENT,
	Name VARCHAR(500) NOT NULL ,
	Notes VARCHAR(500) NULL,
    IsSearchable bit NOT NULL,
    CreatedById Int(11) NULL,
    CreatedOn DateTime NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UpdatedOn DateTime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    primary key (ExerciseDetailId));
    
CREATE TABLE Workout
	(WorkoutId Int(11) NOT NULL AUTO_INCREMENT,
    Name VARCHAR(500) NOT NULL,
    CompletedOn DateTime NULL,
	CreatedOn DateTime NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UpdatedOn DateTime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    primary key (WorkoutId));

CREATE TABLE Exercise
	(ExerciseId Int(11) NOT NULL AUTO_INCREMENT,
	WorkoutId Int(11) NOT NULL,
    ExerciseDetailId Int(11) NOT NULL,
    OrderId Int(11) NOT NULL,
	CreatedOn DateTime NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UpdatedOn DateTime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
	primary key (ExerciseId),
    foreign key (WorkoutId) REFERENCES Workout(WorkoutId),
	foreign key (ExerciseDetailId) REFERENCES ExerciseDetail(ExerciseDetailId));
    
    
CREATE TABLE ExerciseSet
	(ExerciseSetId Int(11) NOT NULL AUTO_INCREMENT,
    ExerciseId Int(11) NOT NULL,
    Reps int(11) NOT NULL,
    Weight int(11) NOT NULL,
    OrderId int(11) NOT NULL,
	CreatedOn DateTime NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UpdatedOn DateTime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    primary key (ExerciseSetId),
    foreign key (ExerciseId) REFERENCES Exercise(ExerciseId) );

INSERT INTO ExerciseDetail values (1, 'Squat', null, 1, 1, CURDATE(), CURDATE());
INSERT INTO Workout values (1, 'Legs?', CURDATE(), CURDATE(), CURDATE());
INSERT INTO Exercise values (1, 1, 1, 1, CURDATE(), CURDATE());
INSERT INTO ExerciseSet values (1, 1, 5, 225, 1, CURDATE(), CURDATE());
INSERT INTO ExerciseSet values (2, 1, 5, 225, 2, CURDATE(), CURDATE());
INSERT INTO ExerciseSet values (3, 1, 4, 225, 3, CURDATE(), CURDATE());

SELECT * FROM ExerciseDetail;
SELECT * FROM Workout;
SELECT * FROM Exercise;
SELECT * FROM ExerciseSet;

