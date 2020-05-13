using System;
using System.Collections.Generic;

public class GradeSchool
{
    private List<Student> StudentList = new List<Student>();

    public void Add(string student, int grade)
    {
        var entry = new Student(student, grade);

        StudentList.Add(entry);
    }

    public IEnumerable<string> Roster()
    {
        var roster = new List<string>();

        SortStudentsByGradeThenName(StudentList);

        foreach (var student in StudentList)
        {
            roster.Add(student.Name);
        }

        return roster;
    }

    public IEnumerable<string> Grade(int grade)
    {
        var gradeList = new List<string>();

        foreach (var student in StudentList)
        {
            if (student.Grade == grade)
            {
                gradeList.Add(student.Name);
            }
        }

        gradeList.Sort();

        return gradeList;
    }

    private static void SortStudentsByGradeThenName(List<Student> students)
    {
        Student tmp = null;
        for (int i = 0; i < students.Count; i++)
        {
            for (int j = 1; j < students.Count; j++)
            {
                // higher grade or (equal grade and higher name), switch
                if (students[j - 1].Grade > students[j].Grade ||
                    (students[j - 1].Grade == students[j].Grade &&
                    students[j - 1].Name.CompareTo(students[j].Name) > 0))
                {
                    tmp = students[j - 1];
                    students[j - 1] = students[j];
                    students[j] = tmp;
                }
            }
        }
    }

    public class Student
    {
        public string Name;
        public int Grade;

        public Student(string name, int grade)
        {
            this.Name = name;
            this.Grade = grade;
        }
    }
}