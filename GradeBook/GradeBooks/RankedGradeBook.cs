﻿using System;
using System.Linq;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked Grading requires at least 5 students.");
            }

            var threshold = (int)Math.Ceiling(Students.Count * (.2));

            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            if (grades[threshold - 1] <= averageGrade)
                return 'A';
            else if (grades[(threshold * 2) - 1] <= averageGrade)
                return 'B';
            else if (grades[(threshold * 4) - 1] <= averageGrade)
                return 'C';
            else if (grades[(threshold * 5) - 1] <= averageGrade)
                return 'D';
            else
            {
                return 'F';
            }

                return base.GetLetterGrade(averageGrade);
        }
    }
}
