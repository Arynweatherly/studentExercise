using System;
using System.Collections.Generic;

namespace studentExercise1
{
    public class Student
    {
        public Student(string first, string last, string slack, Cohort cohort)
        {
            FirstName = first;
            LastName = last;
            Slack = slack;
            CurrentCohort = cohort;
        }

        public string FirstName { get; }
        public string LastName { get; }
        public string Slack { get; }
        public Cohort CurrentCohort { get; set; }
        public List<Exercise> Exercises = new List<Exercise>();
    }
}