﻿using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }

            var top20Division = (int)(Students.Count * 0.2) - 1;
            var second20Division = (int)(Students.Count * 0.4) - 1;
            var third20Division = (int)(Students.Count * 0.6) - 1;
            var fourth20Division = (int)(Students.Count * 0.8) - 1;
            var sortedStudentsByGrade = Students.OrderByDescending(s => s.AverageGrade).ToList();
            
            if (averageGrade >= sortedStudentsByGrade[top20Division].AverageGrade)
            {
                return 'A';
            } 
            else if (averageGrade >= sortedStudentsByGrade[second20Division].AverageGrade)
            {
                return 'B';
            } 
            else if (averageGrade >= sortedStudentsByGrade[third20Division].AverageGrade)
            {
                return 'C';
            }
            else if (averageGrade >= sortedStudentsByGrade[fourth20Division].AverageGrade)
            {
                return 'D';
            }
            else if (averageGrade < sortedStudentsByGrade[fourth20Division].AverageGrade)
            {
                return 'F';
            }

            return 'F';
        }

        public override void CalculateStatistics()
        {
            if(Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");

            }
            else
            {
                base.CalculateStatistics();
            }
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");

            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
        }
    }
}
