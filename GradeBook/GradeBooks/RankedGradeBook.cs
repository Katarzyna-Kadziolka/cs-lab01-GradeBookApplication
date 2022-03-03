using System;
using System.Linq;
using GradeBook.Enums;

namespace GradeBook.GradeBooks {
	public class RankedGradeBook : BaseGradeBook {
		public RankedGradeBook(string name) : base(name) {
			Type = GradeBookType.Ranked;
		}

		public override char GetLetterGrade(double averageGrade) {
			var studentsNumber = Students.Count;
			if (studentsNumber < 5) {
				throw new InvalidOperationException();
			}
			var sortStudents = Students.OrderByDescending(a => a.AverageGrade).ToList();
			var averageGradePosition = sortStudents.FindIndex(a => a.AverageGrade < averageGrade);
			double percentGradePosition = ((averageGradePosition + 1) * 100) / studentsNumber;
			if (percentGradePosition <= 20) return'A';
			if (percentGradePosition <= 40) return'B';
			if (percentGradePosition <= 60) return'C';
			if (percentGradePosition <= 80) return'D';
			return'F';
		}
	}
}