using System;
using System.Collections.Generic;
using System.Text;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            this.Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (this.Students.Count < 5)
            {
                throw new InvalidOperationException();
            }
            else
            {
                int betterStudentsCount = 0;

                foreach (var student in Students)
                {
                    if (student.AverageGrade > averageGrade)
                    {
                        betterStudentsCount++;
                    }
                }

                var studentPlace = (double)(betterStudentsCount + 1) / Students.Count;

                if (studentPlace <= 0.2)
                {
                    return 'A';
                } else if (studentPlace <= 0.4)
                {
                    return 'B';
                } else if (studentPlace <= 0.6)
                {
                    return 'C';
                } else if (studentPlace <= 0.8)
                {
                    return 'D';
                }
            }

            return 'F';
        }

        public override void CalculateStatistics()
        {
            if (this.Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            else
            {
                base.CalculateStatistics();
            }
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (this.Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
        }
    }
}
