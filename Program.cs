using System;
using System.Collections.Generic;
using System.Linq;

namespace studentExercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Exercise exercise1 = new Exercise("Learn about arrays", "JS");
            Exercise exercise2 = new Exercise("Style things with CSS", "CSS");
            Exercise exercise3 = new Exercise("Develop an app.", "React");
            Exercise exercise4 = new Exercise("Build a personal website.", "HTML");
            Exercise exercise5 = new Exercise("Study inheritance", "C#");

            Cohort cohort1 = new Cohort("Cohort 35");
            Cohort cohort2 = new Cohort("Cohort 36");
            Cohort cohort3 = new Cohort("Cohort 37");

            Student ArynWeatherly = new Student("Aryn", "Weatherly", "aryn-weatherly", cohort1);
            Student CorriGolden = new Student("Corri", "Golden", "corri-golden", cohort2);
            Student PhilGriswold = new Student("Phil", "Griswold", "phil-griswold", cohort1);
            Student KeatonWilliamson = new Student("Keaton", "Williamson", "keaton-williamson", cohort2);
            Student NateVogel = new Student("Nate", "Vogel", "nate-vogel", cohort3);
            Student HeidiSmith = new Student("Heidi", "Smith", "heidi-smith", cohort3);


            Instructor BrendaLong = new Instructor("Brenda", "Long", "brenda-long", "front-end", cohort1);
            Instructor MoSilvera = new Instructor("Mo", "Silvera", "mo-silvera", "front-end", cohort3);
            Instructor MadiPiper = new Instructor("Madi", "Piper", "madi-piper", "back-end", cohort2);
            Instructor AdamSheaffer = new Instructor("Adam", "Sheaffer", "adam-sheaffer", "back-end", cohort1);

            cohort1.StudentList.Add(ArynWeatherly);
            cohort2.StudentList.Add(CorriGolden);
            cohort1.StudentList.Add(PhilGriswold);
            cohort2.StudentList.Add(KeatonWilliamson);
            cohort3.StudentList.Add(HeidiSmith);
            cohort3.StudentList.Add(NateVogel);


            cohort1.InstructorList.Add(AdamSheaffer);
            cohort1.InstructorList.Add(BrendaLong);
            cohort3.InstructorList.Add(MoSilvera);
            cohort2.InstructorList.Add(MadiPiper);

            AdamSheaffer.AssignExercise(ArynWeatherly, exercise1);
            BrendaLong.AssignExercise(KeatonWilliamson, exercise2);
            MoSilvera.AssignExercise(HeidiSmith, exercise3);
            AdamSheaffer.AssignExercise(PhilGriswold, exercise4);
            AdamSheaffer.AssignExercise(NateVogel, exercise5);

            List<Student> students = new List<Student>();
            students.Add(ArynWeatherly);
            students.Add(PhilGriswold);
            students.Add(HeidiSmith);
            students.Add(NateVogel);
            students.Add(KeatonWilliamson);
            students.Add(CorriGolden);

            List<Exercise> exercises = new List<Exercise>();
            exercises.Add(exercise1);
            exercises.Add(exercise2);
            exercises.Add(exercise3);
            exercises.Add(exercise4);
            exercises.Add(exercise5);

            foreach (Student student in students)
            {
                Console.WriteLine($"Student: {student.FirstName} {student.LastName}");
                Console.WriteLine("Exercises:");
                foreach (Exercise exercise in student.Exercises)
                {
                    Console.WriteLine($"Program: {exercise.Name} Language: {exercise.Language}");
                }
            }

            List<Cohort> cohorts = new List<Cohort>()
            {
                cohort1,
                cohort2,
                cohort3,

            };

            List<Instructor> instructor = new List<Instructor>()
            {
                AdamSheaffer,
                MoSilvera,
                BrendaLong,
                MadiPiper
            };

            List<Exercise> javascriptExercise = exercises.Where(ex => ex.Language == "JS").ToList();

            foreach (var item in javascriptExercise)
            {
                Console.WriteLine(item.Name);
            }

            var listOfStudentsInCohort = cohorts.Where(cohort => cohort.Name == "Cohort 35")
                .SelectMany(c => c.StudentList).Distinct().ToList();

            foreach (var item in listOfStudentsInCohort)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName} is in Cohort 35");
            }

            var listOfInstructors = cohorts.Where(c => c.Name == "Cohort 35").SelectMany(c => c.InstructorList).Distinct().ToList();
            foreach (var item2 in listOfInstructors)
            {
                Console.WriteLine($"{item2.FirstName} {item2.LastName}: Instructors assigned for cohort-35");
            }

            var studentsByLastName = students.OrderBy(x => x.LastName).ToList();

            foreach (var item3 in studentsByLastName)
            {
                Console.WriteLine(item3.LastName);
            }

            var studentWithoutExercises = students.Where(student => student.Exercises.Count == 0).ToList();

            foreach (var item4 in studentWithoutExercises)
            {
                Console.WriteLine($"These student does't have any exercise assigned: {item4.FirstName} {item4.LastName}");
            }

            var studentWithMostExercises = students.Select(student => new
            {
                firstName = student.FirstName,
                lastName = student.LastName,
                numberOfExercises = student.Exercises.Count()
            }).OrderByDescending(x => x.numberOfExercises).FirstOrDefault();

            Console.WriteLine($"The student with the most exercises: {studentWithMostExercises.firstName} {studentWithMostExercises.lastName} with {studentWithMostExercises.numberOfExercises} exercises");

            var numOfStudents = cohorts.Select(x => new
            {
                name = x.Name,
                numOfStudentsInCohort = x.StudentList.Count()
            }).ToList();

            foreach (var item5 in numOfStudents)
            {
                Console.WriteLine($"In {item5.name} there are {item5.numOfStudentsInCohort} students.");
            }

        }
    }
}