using System;
using System.Collections.Generic;

namespace CourseManagement
{
    class Program
    {
        class Course
        {
            public string Name { get; set; }
            public int Credit { get; set; }
            public string Description { get; set; }
            public string Semester { get; set; }

            public override string ToString()
            {
                return $"Name: {Name}, Credit: {Credit}, Semester: {Semester}, Description: {Description}";
            }
        }

        static void Main(string[] args)
        {
            List<Course> courses = new List<Course>();

            while (true)
            {
                Console.WriteLine("\nCourse Management Software");
                Console.WriteLine("1. Create a new course");
                Console.WriteLine("2. Display all courses");
                Console.WriteLine("3. Remove a course");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateCourse(courses);
                        break;
                    case "2":
                        DisplayCourses(courses);
                        break;
                    case "3":
                        RemoveCourse(courses);
                        break;
                    case "4":
                        Console.WriteLine("Exiting the program...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void CreateCourse(List<Course> courses)
        {
            Console.Write("Enter course name: ");
            string name = Console.ReadLine();

            Console.Write("Enter course credit: ");
            if (!int.TryParse(Console.ReadLine(), out int credit) || credit <= 0)
            {
                Console.WriteLine("Invalid credit. Course not created.");
                return;
            }

            Console.Write("Enter course description: ");
            string description = Console.ReadLine();

            Console.Write("Enter course semester: ");
            string semester = Console.ReadLine();

            courses.Add(new Course
            {
                Name = name,
                Credit = credit,
                Description = description,
                Semester = semester
            });

            Console.WriteLine("Course added successfully!");
        }

        static void DisplayCourses(List<Course> courses)
        {
            if (courses.Count == 0)
            {
                Console.WriteLine("No courses to display.");
                return;
            }

            Console.WriteLine("\nList of Courses:");
            for (int i = 0; i < courses.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {courses[i]}");
            }
        }

        static void RemoveCourse(List<Course> courses)
        {
            if (courses.Count == 0)
            {
                Console.WriteLine("No courses to remove.");
                return;
            }

            Console.WriteLine("\nSelect a course to remove:");
            for (int i = 0; i < courses.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {courses[i].Name}");
            }

            Console.Write("Enter the number of the course to remove: ");
            if (!int.TryParse(Console.ReadLine(), out int index) || index <= 0 || index > courses.Count)
            {
                Console.WriteLine("Invalid selection. No course removed.");
                return;
            }

            courses.RemoveAt(index - 1);
            Console.WriteLine("Course removed successfully!");
        }
    }
}