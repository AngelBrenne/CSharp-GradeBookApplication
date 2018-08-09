using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool weighted) : base(name, weighted)
        {
            Type = GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            }

            int downOneGrade = Students.Count / 5;
            int placement = -1;
            List<double> gradesList = new List<double>();

            foreach (Student student in Students)
            {
                gradesList.Add(student.AverageGrade);
            }
            gradesList.Sort();
            for (int i = 0; i < gradesList.Count; i++)
            {
                if (averageGrade == gradesList[i])
                {
                    placement = i;
                }
            }

            if (placement == -1)
            {
                Console.WriteLine("Something went wrong, ops");
                return 'Q';
            }
            else if (placement < downOneGrade)
            {
                return 'F';
            }
            else if (placement < downOneGrade * 2)
            {
                return 'D';
            }
            else if (placement < downOneGrade * 3)
            {
                return 'C';
            }
            else if (placement < downOneGrade * 4)
            {
                return 'B';
            }
            else
            {
                return 'A';
            }
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }
    }
}