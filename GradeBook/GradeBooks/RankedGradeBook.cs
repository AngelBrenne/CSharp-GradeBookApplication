using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook: BaseGradeBook 
    {
        public RankedGradeBook(string name) : base (name)
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
            int placement =-1;
            List<double> gradesList = new List<double>();

            foreach (Student student in Students){
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
                return 'A';
            }
            else if (placement < downOneGrade*2)
            {
                return 'B';
            }
            else if (placement < downOneGrade * 3)
            {
                return 'C';
            }
            else if (placement < downOneGrade * 4)
            {
                return 'D';
            }
            else
            {
                return 'F';
            }
        }
    }
}