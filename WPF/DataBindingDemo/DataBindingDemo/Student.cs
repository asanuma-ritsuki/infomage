using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBindingDemo
{
	public class Student
	{
		public Student()
		{
		}

		public string StudentName { get; set; }

		public bool IsEnrolled { get; set; }
	}

	public class StudentList : ObservableCollection<Student>
	{

	}
}
