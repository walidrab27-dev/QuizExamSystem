using QuizExamSystem.Data.Data;
using QuizExamSystem.Data.Enums;
using QuizExamSystem.Data.Models;
using QuizExamSystem.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizExamSystem.ConsoleUI.UI
{
    public class AdminDashboard : Menu
    {
        private Admin _admin;
        private AdminService _adminService = new AdminService();
        public AdminDashboard(Admin admin)
        {
            this._admin = admin;
        }
        public override void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\tAdmin Dashboard\t\t");
                Console.ResetColor();

                Console.WriteLine();
                Console.WriteLine("1.\tAdd New Course\n");
                Console.WriteLine("2.\tView All Courses\n");
                Console.WriteLine("3.\tView All Teachers\n");
                Console.WriteLine("4.\tView All Students\n");
                Console.WriteLine("5.\tLogout");
                Console.WriteLine();

                Console.Write("Enter a number between 1 And 5: ");
                if (!TryGetChoice(out int choice))
                    continue;

                switch (choice)
                {
                    case 1:
                        CreateCourse();
                        break;
                    case 2:
                        ViewAllCourses();
                        break;
                    case 3:
                        ViewAllTeachers();
                        break;
                    case 4:
                        ViewAllStudents();
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Logged out");
                        Console.ResetColor();
                        WaitForKeyPress();
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter a valid option between 1 and 5.");
                        Console.ResetColor();
                        WaitForKeyPress();
                        break;
                }
              
            }
        }
        private Teacher GetTeachreById(int teacherId)
        {
            foreach (var teacher in DatabaseMock.Teachers)
            {
                if (teacher.Id == teacherId)
                {
                    return teacher;
                }
            }
            throw new ArgumentException("there isn't any teacher in system with this ID.");
        }
        private void CreateCourse()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t\tAdd New Course\t\t\n");
            Console.ResetColor();

            Console.Write("Enter name of the course: ");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input! Course name cannot be empty.");
                Console.ResetColor();
                WaitForKeyPress();
                return; 
            }
            Console.WriteLine();

            Console.Write("Enter Category (e.g., Programming, Language, Science): ");
            if (!Enum.TryParse<CourseCategories>(Console.ReadLine(), true, out CourseCategories category))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Category! Please enter a valid category name.");
                Console.ResetColor();
                WaitForKeyPress();
                return;
            }
            Console.WriteLine();

            Console.Write("Enter duration (HH:mm:ss): ");
            if (!TimeSpan.TryParse(Console.ReadLine(), out TimeSpan duration))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid time format! Please use HH:mm:ss (e.g., 02:30:00).");
                Console.ResetColor();
                WaitForKeyPress();
                return;
            }
            Console.WriteLine();

            Console.Write("Enter number of lessons: ");
            if (!int.TryParse(Console.ReadLine(), out int numberLessons) || numberLessons <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input! Please enter a valid positive number.");
                Console.ResetColor();
                WaitForKeyPress();
                return;
            }
            Console.WriteLine();

            Teacher selectedTeacher = null;
            if (DatabaseMock.Teachers.Count>0)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\t\tAssign a Teacher (Optional)\t\t");
                Console.ResetColor();
                Console.WriteLine();

                for (var i =0;i<DatabaseMock.Teachers.Count;i++)
                {
                    Console.WriteLine($"[{DatabaseMock.Teachers[i].Id}]. {DatabaseMock.Teachers[i].Name} - {DatabaseMock.Teachers[i].Email} | {DatabaseMock.Teachers[i].Title}");
                    Console.WriteLine();
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Enter the Id of the teacher (or 0 to skip): ");
                Console.ResetColor();

                try
                {
                    if (int.TryParse(Console.ReadLine(), out int teacherId))
                    {
                        if (teacherId == 0)
                            Console.WriteLine("\nProceeding without assigning a teacher.");
                        selectedTeacher = GetTeachreById(teacherId);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\nSelected Teacher: {selectedTeacher.Title}. {selectedTeacher.Name}");
                        Console.ResetColor();
                    }
                    else
                        Console.WriteLine("\nProceeding without assigning a teacher.");
                }
                catch(ArgumentException ex)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Proceeding without assigning a teacher.");
                    Console.ResetColor();
                    WaitForKeyPress();
                }
            }

            try
            {
                Console.Clear();
                _adminService.CreateCourse(name, category, duration, numberLessons, this._admin, selectedTeacher);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Course Created Successfully!");
                Console.ResetColor();
                WaitForKeyPress();
            }
            catch (ArgumentException ex)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
                WaitForKeyPress();
            }
        }
        private void ViewAllCourses()
        {
            Console.Clear();

            if (_adminService.GetAllCourses().Count == 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t[!] No courses available in the system yet.\n");
                Console.ResetColor();
                WaitForKeyPress();
                return;
            }

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t\tAVAILABLE COURSES\t\t");
            Console.ResetColor();
            Console.WriteLine();

            foreach (var course in _adminService.GetAllCourses())
            {
                string teacherName = course.Teacher != null ? course.Teacher.Name : "Not Assigned Yet";
                Console.WriteLine($"\t\t[{course.Id}]. {course.Name} Course\t\t");
                Console.WriteLine($"Teacher Name      : {teacherName}");
                Console.WriteLine($"Duration          : {course.Duration}");
                Console.WriteLine($"Number of Lessons : {course.NumberLessons}");
                Console.WriteLine($"Category          : {course.Category}");
                Console.WriteLine($"Number of Students: {course.Enrollments.Count}");
                Console.WriteLine($"Number of Quizzes : {course.Quizzes.Count}");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Quiz Names        :");
                Console.ResetColor();

                if (course.Quizzes.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"\t[!] this course doesn't have any quizzes yet.");
                    Console.ResetColor();
                }
                for (var i = 0; i < course.Quizzes.Count; i++)
                {
                    Console.WriteLine($"\t[{i + 1}]. {course.Quizzes[i].Name}");
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Student Names     :");
                Console.ResetColor();

                if (course.Enrollments.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"\t[!] this course doesn't have any student yet.");
                    Console.ResetColor();
                }
                for (var i = 0; i < course.Enrollments.Count; i++)
                {
                    Console.WriteLine($"\t[{i + 1}]. {course.Enrollments[i].Student.Name}");
                }

                Console.WriteLine();
            }
            WaitForKeyPress();

        }
        private void ViewAllTeachers()
        {
            Console.Clear();

            if (_adminService.GetAllTeachers().Count == 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t[!] No Teachers available in the system yet.\n");
                Console.ResetColor();
                WaitForKeyPress();
                return;
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t\tTeachers\t\t\n");
            Console.ResetColor();

            foreach (var teacher in _adminService.GetAllTeachers())
            {
                Console.WriteLine($"\t\t[{teacher.Id}]. {teacher.Name}\t\t");
                Console.WriteLine($"Email             : {teacher.Email}");
                Console.WriteLine($"Title             : {teacher.Title}");
                Console.WriteLine($"Number of Courses : {teacher.Courses.Count}");
                Console.WriteLine($"Number of Quizzes :{teacher.Quizzes.Count}");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Course Names      :");
                Console.ResetColor();

                if (teacher.Courses.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"\t[!] {teacher.Title}. {teacher.Name} didnt assign any course yet.");
                    Console.ResetColor();
                }
                for (var i = 0; i < teacher.Courses.Count; i++)
                {
                    Console.WriteLine($"\t[{i + 1}]. {teacher.Courses[i].Name}");
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Quiz Names:");
                Console.ResetColor();

                if (teacher.Quizzes.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"\t[!] {teacher.Title}. {teacher.Name} didnt make any quiz yet.");
                    Console.ResetColor();
                }
                for (var i = 0; i < teacher.Courses.Count; i++)
                {
                    Console.WriteLine($"\t[{i + 1}]. {teacher.Courses[i].Name}");
                }

                Console.WriteLine();
            }
            WaitForKeyPress();

        }
        private void ViewAllStudents()
        {
            Console.Clear();

            if (_adminService.GetAllStudents().Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t[!] No Students available in the system yet.\n");
                Console.ResetColor();
                WaitForKeyPress();
                return;
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t\tStudents\t\t\n");
            Console.ResetColor();

            foreach (var student in _adminService.GetAllStudents())
            {
                Console.WriteLine($"\t\t[{student.Id}]. {student.Name}\t\t");
                Console.WriteLine($"Email             : {student.Email}");
                Console.WriteLine($"Grade             : {student.Grade}");
                Console.WriteLine($"Number of Courses : {student.Enrollments.Count}");
                Console.WriteLine($"Number of Quizzes :{student.StudentQuizzes.Count}");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Course Names      :");
                Console.ResetColor();
                
                if (student.Enrollments.Count==0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"\t[!] {student.Name} didnt enroll any course yet.");
                    Console.ResetColor();
                }
                for (var i = 0; i < student.Enrollments.Count;i++)
                {
                    Console.WriteLine($"\t[{i+1}]. {student.Enrollments[i].Course.Name}");
                }


                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("quiz Names        :");
                Console.ResetColor();

                if (student.StudentQuizzes.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"\t[!] {student.Name} didnt take any quiz yet.");
                    Console.ResetColor();
                }
                for (var i = 0;i<student.StudentQuizzes.Count;i++)
                {
                    Console.WriteLine($"\t[{i+1}]. {student.StudentQuizzes[i].Quiz.Name}");
                }
                Console.WriteLine();
            }
            WaitForKeyPress();
        }
        
    }
}
