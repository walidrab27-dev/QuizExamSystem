USE QuizExamSystemDB;
GO

-- 1. Insert Admins (20 Records)
INSERT INTO Admin (Name, Email, Password, PhoneNumber) VALUES
('Admin 1', 'admin1@gmail.com', 'Passw@rd123', '01000000001'),
('Admin 2', 'admin2@gmail.com', 'Passw@rd123', '01000000002'),
('Admin 3', 'admin3@gmail.com', 'Passw@rd123', '01000000003'),
('Admin 4', 'admin4@gmail.com', 'Passw@rd123', '01000000004'),
('Admin 5', 'admin5@gmail.com', 'Passw@rd123', '01000000005'),
('Admin 6', 'admin6@gmail.com', 'Passw@rd123', '01000000006'),
('Admin 7', 'admin7@gmail.com', 'Passw@rd123', '01000000007'),
('Admin 8', 'admin8@gmail.com', 'Passw@rd123', '01000000008'),
('Admin 9', 'admin9@gmail.com', 'Passw@rd123', '01000000009'),
('Admin 10', 'admin10@gmail.com', 'Passw@rd123', '01000000010'),
('Admin 11', 'admin11@gmail.com', 'Passw@rd123', '01000000011'),
('Admin 12', 'admin12@gmail.com', 'Passw@rd123', '01000000012'),
('Admin 13', 'admin13@gmail.com', 'Passw@rd123', '01000000013'),
('Admin 14', 'admin14@gmail.com', 'Passw@rd123', '01000000014'),
('Admin 15', 'admin15@gmail.com', 'Passw@rd123', '01000000015'),
('Admin 16', 'admin16@gmail.com', 'Passw@rd123', '01000000016'),
('Admin 17', 'admin17@gmail.com', 'Passw@rd123', '01000000017'),
('Admin 18', 'admin18@gmail.com', 'Passw@rd123', '01000000018'),
('Admin 19', 'admin19@gmail.com', 'Passw@rd123', '01000000019'),
('Admin 20', 'admin20@gmail.com', 'Passw@rd123', '01000000020');

-- 2. Insert Teachers (20 Records)
INSERT INTO Teacher (Name, Email, Password, PhoneNumber, TeacherTitle) VALUES
('Teacher 1', 'teacher1@gmail.com', 'Passw@rd123', '01100000001', 'Eng.'),
('Teacher 2', 'teacher2@gmail.com', 'Passw@rd123', '01100000002', 'Dr.'),
('Teacher 3', 'teacher3@gmail.com', 'Passw@rd123', '01100000003', 'Eng.'),
('Teacher 4', 'teacher4@gmail.com', 'Passw@rd123', '01100000004', 'Prof.'),
('Teacher 5', 'teacher5@gmail.com', 'Passw@rd123', '01100000005', 'Eng.'),
('Teacher 6', 'teacher6@gmail.com', 'Passw@rd123', '01100000006', 'Dr.'),
('Teacher 7', 'teacher7@gmail.com', 'Passw@rd123', '01100000007', 'Eng.'),
('Teacher 8', 'teacher8@gmail.com', 'Passw@rd123', '01100000008', 'Prof.'),
('Teacher 9', 'teacher9@gmail.com', 'Passw@rd123', '01100000009', 'Eng.'),
('Teacher 10', 'teacher10@gmail.com', 'Passw@rd123', '01100000010', 'Dr.'),
('Teacher 11', 'teacher11@gmail.com', 'Passw@rd123', '01100000011', 'Eng.'),
('Teacher 12', 'teacher12@gmail.com', 'Passw@rd123', '01100000012', 'Dr.'),
('Teacher 13', 'teacher13@gmail.com', 'Passw@rd123', '01100000013', 'Eng.'),
('Teacher 14', 'teacher14@gmail.com', 'Passw@rd123', '01100000014', 'Prof.'),
('Teacher 15', 'teacher15@gmail.com', 'Passw@rd123', '01100000015', 'Eng.'),
('Teacher 16', 'teacher16@gmail.com', 'Passw@rd123', '01100000016', 'Dr.'),
('Teacher 17', 'teacher17@gmail.com', 'Passw@rd123', '01100000017', 'Eng.'),
('Teacher 18', 'teacher18@gmail.com', 'Passw@rd123', '01100000018', 'Prof.'),
('Teacher 19', 'teacher19@gmail.com', 'Passw@rd123', '01100000019', 'Eng.'),
('Teacher 20', 'teacher20@gmail.com', 'Passw@rd123', '01100000020', 'Dr.');

-- 3. Insert Students (20 Records)
INSERT INTO Student (Name, Email, Password, PhoneNumber) VALUES
('Student 1', 'student1@gmail.com', 'Passw@rd123', '01200000001'),
('Student 2', 'student2@gmail.com', 'Passw@rd123', '01200000002'),
('Student 3', 'student3@gmail.com', 'Passw@rd123', '01200000003'),
('Student 4', 'student4@gmail.com', 'Passw@rd123', '01200000004'),
('Student 5', 'student5@gmail.com', 'Passw@rd123', '01200000005'),
('Student 6', 'student6@gmail.com', 'Passw@rd123', '01200000006'),
('Student 7', 'student7@gmail.com', 'Passw@rd123', '01200000007'),
('Student 8', 'student8@gmail.com', 'Passw@rd123', '01200000008'),
('Student 9', 'student9@gmail.com', 'Passw@rd123', '01200000009'),
('Student 10', 'student10@gmail.com', 'Passw@rd123', '01200000010'),
('Student 11', 'student11@gmail.com', 'Passw@rd123', '01200000011'),
('Student 12', 'student12@gmail.com', 'Passw@rd123', '01200000012'),
('Student 13', 'student13@gmail.com', 'Passw@rd123', '01200000013'),
('Student 14', 'student14@gmail.com', 'Passw@rd123', '01200000014'),
('Student 15', 'student15@gmail.com', 'Passw@rd123', '01200000015'),
('Student 16', 'student16@gmail.com', 'Passw@rd123', '01200000016'),
('Student 17', 'student17@gmail.com', 'Passw@rd123', '01200000017'),
('Student 18', 'student18@gmail.com', 'Passw@rd123', '01200000018'),
('Student 19', 'student19@gmail.com', 'Passw@rd123', '01200000019'),
('Student 20', 'student20@gmail.com', 'Passw@rd123', '01200000020');

-- 4. Insert Courses (20 Records)
INSERT INTO Course (Name, Category, Duration, NumberLessons, AdminId, TeacherId) VALUES
('C# OOP', 'Programming', 120, 10, 1, 1),
('C++ Basics', 'Programming', 90, 8, 2, 2),
('SQL Server', 'Database', 150, 12, 3, 3),
('Figma Design', 'UI/UX', 60, 5, 4, 4),
('ASP.NET Core', 'Web', 200, 15, 5, 5),
('Data Structures', 'CS', 180, 14, 6, 6),
('Algorithms', 'CS', 180, 14, 7, 7),
('HTML & CSS', 'Web', 80, 6, 8, 8),
('JavaScript', 'Web', 110, 9, 9, 9),
('React JS', 'Web', 130, 10, 10, 10),
('Angular', 'Web', 140, 11, 11, 11),
('Design Patterns', 'Architecture', 160, 12, 12, 12),
('Clean Code', 'Architecture', 100, 8, 13, 13),
('Git & GitHub', 'Tools', 45, 4, 14, 14),
('Docker', 'DevOps', 90, 7, 15, 15),
('Azure Basics', 'Cloud', 120, 10, 16, 16),
('Python', 'Programming', 110, 9, 17, 17),
('Machine Learning', 'AI', 240, 20, 18, 18),
('System Design', 'Architecture', 200, 15, 19, 19),
('Entity Framework', 'Database', 100, 8, 20, 20);

-- 5. Insert Quizzes (20 Records)
INSERT INTO Quiz (Name, Duration, CourseId) VALUES
('Quiz 1 - C# OOP', 30, 1),
('Quiz 2 - C++ Basics', 25, 2),
('Quiz 3 - SQL Server', 45, 3),
('Quiz 4 - Figma Design', 20, 4),
('Quiz 5 - ASP.NET Core', 50, 5),
('Quiz 6 - Data Structures', 40, 6),
('Quiz 7 - Algorithms', 45, 7),
('Quiz 8 - HTML & CSS', 20, 8),
('Quiz 9 - JavaScript', 30, 9),
('Quiz 10 - React JS', 35, 10),
('Quiz 11 - Angular', 35, 11),
('Quiz 12 - Design Patterns', 40, 12),
('Quiz 13 - Clean Code', 25, 13),
('Quiz 14 - Git & GitHub', 15, 14),
('Quiz 15 - Docker', 30, 15),
('Quiz 16 - Azure Basics', 30, 16),
('Quiz 17 - Python', 35, 17),
('Quiz 18 - Machine Learning', 60, 18),
('Quiz 19 - System Design', 60, 19),
('Quiz 20 - Entity Framework', 30, 20);

-- 6. Insert Enrollments (20 Records - Unique Student and Course)
INSERT INTO Enrollment (StudentId, CourseId) VALUES
(1, 1), (2, 2), (3, 3), (4, 4), (5, 5),
(6, 6), (7, 7), (8, 8), (9, 9), (10, 10),
(11, 11), (12, 12), (13, 13), (14, 14), (15, 15),
(16, 16), (17, 17), (18, 18), (19, 19), (20, 20);

-- 7. Insert StudentQuiz (20 Records - Unique Student and Quiz)
INSERT INTO StudentQuiz (StudentId, QuizId, FinalScore) VALUES
(1, 1, 95.50), (2, 2, 88.00), (3, 3, 75.25), (4, 4, 100.00), (5, 5, 60.50),
(6, 6, 85.00), (7, 7, 92.75), (8, 8, 78.00), (9, 9, 89.50), (10, 10, 94.00),
(11, 11, 81.25), (12, 12, 77.50), (13, 13, 99.00), (14, 14, 65.00), (15, 15, 82.50),
(16, 16, 91.00), (17, 17, 88.50), (18, 18, 73.00), (19, 19, 86.25), (20, 20, 97.00);

-- 8. Insert Questions (20 Records - Mixing the 3 Types)
INSERT INTO Question (text, QuestionType, Score, QuizId) VALUES
('Is C# an OOP language?', 'TrueFalse', 5.00, 1),
('What is the capital of Egypt?', 'ShortAnswer', 5.00, 2),
('Which of the following is an access modifier?', 'MultipleChoice', 10.00, 3),
('Figma is used for Backend development.', 'TrueFalse', 5.00, 4),
('MVC stands for Model View Controller.', 'TrueFalse', 5.00, 5),
('What data structure uses LIFO?', 'ShortAnswer', 10.00, 6),
('Binary Search is faster than Linear Search.', 'TrueFalse', 5.00, 7),
('What does HTML stand for?', 'ShortAnswer', 5.00, 8),
('Which keyword declares a variable in JS?', 'MultipleChoice', 5.00, 9),
('React uses a Virtual DOM.', 'TrueFalse', 5.00, 10),
('Angular is a framework.', 'TrueFalse', 5.00, 11),
('Singleton ensures only one instance is created.', 'TrueFalse', 10.00, 12),
('Clean code should be self-explanatory.', 'TrueFalse', 5.00, 13),
('Which git command uploads code?', 'ShortAnswer', 5.00, 14),
('Docker uses Containers.', 'TrueFalse', 5.00, 15),
('Azure is owned by Amazon.', 'TrueFalse', 5.00, 16),
('Python is compiled, not interpreted.', 'TrueFalse', 5.00, 17),
('What does ML stand for?', 'ShortAnswer', 10.00, 18),
('Load balancers distribute traffic.', 'TrueFalse', 10.00, 19),
('EF Core supports Code-First approach.', 'TrueFalse', 5.00, 20);

-- 9. Insert Answers (20 Records - Correct Answers for the Questions)
INSERT INTO Answer (text, IsCorrect, QuestionId) VALUES
('True', 1, 1),
('Cairo', 1, 2),
('Private', 1, 3),
('False', 1, 4),
('True', 1, 5),
('Stack', 1, 6),
('True', 1, 7),
('Hyper Text Markup Language', 1, 8),
('let', 1, 9),
('True', 1, 10),
('True', 1, 11),
('True', 1, 12),
('True', 1, 13),
('git push', 1, 14),
('True', 1, 15),
('False', 1, 16),
('False', 1, 17),
('Machine Learning', 1, 18),
('True', 1, 19),
('True', 1, 20);

-- 10. Insert StudentAnswers (20 Records - Ensuring constraints are met)
INSERT INTO StudentAnswer (Answer, StudentQuizId, QuestionId) VALUES
('True', 1, 1),
('Cairo', 2, 2),
('Private', 3, 3),
('True', 4, 4), -- Student answered wrong here
('True', 5, 5),
('Stack', 6, 6),
('True', 7, 7),
('HTML', 8, 8), -- Student answered wrong here
('let', 9, 9),
('True', 10, 10),
('True', 11, 11),
('True', 12, 12),
('True', 13, 13),
('git push', 14, 14),
('True', 15, 15),
('False', 16, 16),
('True', 17, 17), -- Student answered wrong here
('Machine Learning', 18, 18),
('True', 19, 19),
('True', 20, 20);