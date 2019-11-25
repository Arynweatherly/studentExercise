using System;
using System.Collections.Generic;

namespace studentExercise1
{
    public class Instructor
    {
        public Instructor(string first, string last, string slack, string specialty, Cohort cohort)
        {
            FirstName = first;
            LastName = last;
            Slack = slack;
            Specialty = specialty;
            CurrentCohort = cohort;
        }

        public string FirstName { get; set; }
        public Cohort CurrentCohort { get; set; }
        public void AssignExercise(Student student, Exercise exercise)
        {
            student.Exercises.Add(exercise);
        }
        public string LastName { get; set; }
        private string Slack { get; }
        private string Specialty { get; }
    }
}