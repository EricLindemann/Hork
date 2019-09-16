DROP TABLE Exercise;
DROP TABLE WorkoutDetail;
DROP TABLE ExerciseDetail;

CREATE TABLE Exercise 
	(ExerciseId Int(11) NOT NULL AUTO_INCREMENT,
	Name VARCHAR(500) NOT NULL ,
	Notes VARCHAR(500) NULL,
    IsSearchable bit NOT NULL,
    CreatedById Int(11) NULL,
    CreatedOn DateTime NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UpdatedOn DateTime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    primary key (ExerciseId));
    
CREATE TABLE WorkoutDetail
	(WorkoutDetailId Int(11) NOT NULL AUTO_INCREMENT,
    Name VARCHAR(500) NOT NULL,
    CompletedOn DateTime NULL,
	CreatedOn DateTime NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UpdatedOn DateTime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    primary key (WorkoutDetailId));

CREATE TABLE ExerciseDetail
	(ExerciseDetailId Int(11) NOT NULL AUTO_INCREMENT,
	WorkoutDetailId Int(11) NOT NULL,
    ExerciseId Int(11) NOT NULL,
    Sets Int(11) NULL,
    Reps Int(11) NULL,
    Weight Int(11) NULL,
    OrderId Int(11) NOT NULL,
	CreatedOn DateTime NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UpdatedOn DateTime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
	primary key (ExerciseDetailId),
    foreign key (WorkoutDetailId) REFERENCES WorkoutDetail(WorkoutDetailId),
	foreign key (ExerciseId) REFERENCES Exercise(ExerciseId));

