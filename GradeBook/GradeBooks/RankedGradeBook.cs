﻿using GradeBook.Enums;
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
