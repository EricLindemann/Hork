DROP TABLE Exercise;

CREATE TABLE Exercise 
	(ExerciseId Int(11) NOT NULL AUTO_INCREMENT,
	Name VARCHAR(500) NOT NULL ,
	Notes VARCHAR(500) NULL,
    IsSearchable bit NOT NULL,
    CreatedById Int(11) NULL,
    CreatedOn DateTime NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UpdatedOn DateTime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    primary key (ExerciseId));

INSERT INTO Exercise VALUES (1, 'squat', 'asdfsadf', 1, 123, UTC_TIMESTAMP, UTC_TIMESTAMP );
