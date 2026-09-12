select 
	Course.Name as [Course Name] ,
	Teacher.Name as [Teacher Name] ,
	Course.Category as [Course Category]
from Course
	inner join Teacher
	on Course.TeacherId = Teacher.Id;


select
	Name as [Quiz Name] ,
	(select count(*) from Question where Question.QuizId = Quiz.Id) as [Number of Questions]
from Quiz;

select * from Question where Question.QuizId = 4;

select	
	Student.Name as [Student Name] ,
	Course.Name as [Course Name]
from Student
	inner join Enrollment on Student.Id = Enrollment.StudentId
	inner join Course on Enrollment.CourseId = Course.Id
where Course.Id = 1;

select count(*)as [Number of Quizzes] from Quiz where CourseId = 5;

select 
	Course.Name as [Course Name] ,
	Teacher.Name as [Teacher Name] 
from Course
	left join Teacher
	on Course.TeacherId = Teacher.Id;

update course set Duration = 120 where Id = 2;

select Avg(Duration) as [Average of Quiz Duration] from Quiz;