create database QuizExamSystemDB;
create table Admin
(
	Id int primary key identity (1,1),
	Name varchar(250) not null,
	Email varchar(250) not null unique check (len(trim(Email))>0 and (Email like '%@gmail.com')),
	Password varchar(250) not null check (len(trim(Password)) >= 8),
	PhoneNumber varchar(11) not null unique check (len(trim(PhoneNumber))=11 and PhoneNumber like '01[0125]%'),
	CreatedAt datetime not null default getdate(),
	UpdatedAt datetime not null default getdate()
);
create table Teacher
(
	Id int primary key identity (1,1),
	Name varchar(250) not null,
	Email varchar(250) not null unique check (len(trim(Email))>0 and (Email like '%@gmail.com')),
	Password varchar(250) not null check (len(trim(Password)) >= 8),
	PhoneNumber varchar(11) not null unique check (len(trim(PhoneNumber))=11 and PhoneNumber like '01[0125]%'),
	TeacherTitle varchar(250) not null,
	CreatedAt datetime not null default getdate(),
	UpdatedAt datetime not null default getdate()
);
create table Student
(
	Id int primary key identity (1,1),
	Name varchar(250) not null,
	Email varchar(250) not null unique check (len(trim(Email))>0 and (Email like '%@gmail.com')),
	Password varchar(250) not null check (len(trim(Password)) >= 8),
	PhoneNumber varchar(11) not null unique check (len(trim(PhoneNumber))=11 and PhoneNumber like '01[0125]%'),
	Grade int check (Grade >= 0),
	CreatedAt datetime not null default getdate(),
	UpdatedAt datetime not null default getdate()
);
create table Course
(
	Id int primary key identity (1,1),
	Name varchar(250) not null,
	Category varchar(250) not null,
	Duration int not null,
	NumberLessons int not null,
	AdminId int not null,
	TeacherId int not null,
	foreign key (AdminId) references Admin(Id),
	foreign key (TeacherId) references Teacher(Id),
	CreatedAt datetime not null default getdate(),
	UpdatedAt datetime not null default getdate()
);
create table Quiz
(
	Id int primary key identity (1,1),
	Name varchar(250) not null,
	Duration int not null,
	CourseId int not null,
	foreign key (CourseId) references Course(Id) on delete cascade,
	CreatedAt datetime not null default getdate(),
	UpdatedAt datetime not null default getdate()
);
create table Enrollment
(
	Id int primary key identity (1,1),
	StudentId int not null,
	CourseId int not null,
	foreign key (StudentId) references Student(Id) on delete cascade,
	foreign key (CourseId) references Course(Id) on delete cascade,
	Unique(StudentId,CourseId),
	CreatedAt datetime not null default getdate(),
	UpdatedAt datetime not null default getdate()
);
create table StudentQuiz
(
	Id int primary key identity (1,1),
	StudentId int not null,
	QuizId int not null,
	foreign key (StudentId) references Student(Id) on delete cascade,
	foreign key (QuizId) references Quiz(Id) on delete cascade,
	FinalScore decimal(5,2) not null,
	Unique(StudentId,QuizId),
	CreatedAt datetime not null default getdate(),
	UpdatedAt datetime not null default getdate()
);
create table Question
(
	Id int primary key identity (1,1),
	text varchar(max) not null,
	QuestionType varchar(250) check (QuestionType in ('ShortAnswer','MultipleChoice','TrueFalse')) not null,
	Score decimal(5,2) not null,
	QuizId int not null,
	foreign key (QuizId) references Quiz(Id) on delete cascade,
	CreatedAt datetime not null default getdate(),
	UpdatedAt datetime not null default getdate()
);
create table Answer
(
	Id int primary key identity (1,1),
	text varchar(250) not null,
	IsCorrect bit not null, 
	QuestionId int not null,
	foreign key (QuestionId) references Question(Id) on delete cascade,
	CreatedAt datetime not null default getdate(),
	UpdatedAt datetime not null default getdate()
);
create table StudentAnswer
(
	Id int primary key identity (1,1),
	Answer varchar(max) not null,
	StudentQuizId int not null,
	QuestionId int not null,
	foreign key (StudentQuizId) references StudentQuiz(Id) on delete cascade,
	foreign key (QuestionId) references Question(Id),
	unique(StudentQuizId,QuestionId),
	CreatedAt datetime not null default getdate(),
	UpdatedAt datetime not null default getdate()
);
