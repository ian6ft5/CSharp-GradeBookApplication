using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }
        public override void CalculateStatistics()
        {
            if (Students.Count < 6)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStatistics();
        }
        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 6)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }
        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");

            }
            double highestGrade = Students.Max(x => x.AverageGrade);
            double lowestGrade = Students.Min(x => x.AverageGrade);
            double incrementAmount = (highestGrade - lowestGrade) / 5;
            double nextThreshold = highestGrade - incrementAmount;
            if (averageGrade > nextThreshold)
            {
                return 'A';
            }
            else
            {
                nextThreshold -= incrementAmount;
            }
            if (averageGrade > nextThreshold)
            {
                return 'B';
            }
            else
            {
                nextThreshold -= incrementAmount;
            }
            if (averageGrade > nextThreshold)
            {
                return 'C';
            }
            else
            {
                nextThreshold -= incrementAmount;
            }
            if (averageGrade > nextThreshold)
            {
                return 'D';
            }
            return 'F';
        }
    }
}
