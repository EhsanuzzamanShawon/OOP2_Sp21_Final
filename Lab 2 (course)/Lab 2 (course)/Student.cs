﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2__course_
{
    class Student
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public float Cgpa { get; set; }
        public int CourseCount { get; set; }

        public static int CourseLimit = 4;
        private Course[] courses;

        public Student()
        {
            Console.WriteLine("Default Student.");
            this.courses = new Course[Student.CourseLimit];
        }

        public Student(string name, string id, float cgpa)
        {
            this.Name = name;
            this.Id = id;
            this.Cgpa = cgpa;
            this.courses = new Course[Student.CourseLimit];
        }

        public void AddCourse(params Course[] cou)
        {
            foreach (Course c in cou)
            {
                this.courses[this.CourseCount++] = c;
                if (c.GetStudent(this.Id) == null)
                    c.AddStudent(this);
            }
        }

        public void RemoveCourse(Course c)
        {
            if (c == this.courses[this.CourseCount - 1])
            {
                this.courses[this.CourseCount--] = null;
                c.RemoveStudent(this);
                return;
            }

            bool notFound = true;
            for (int i = 0; i < this.CourseCount - 1; ++i)
            {
                if (c == this.courses[i] && notFound)
                {
                    this.courses[i] = null;
                    this.CourseCount--;
                    c.RemoveStudent(this);
                    notFound = false;
                }
                if (!notFound)
                {
                    this.courses[i] = this.courses[i + 1];
                }
            }
        }


        public Course GetCourse(string id)
        {
            for (int i = 0; i < this.CourseCount; ++i)
                if (id == this.courses[i].Id)
                    return this.courses[i];

            return null;
        }

        public void PrintCourse()
        {
            for (int i = 0; i < this.CourseCount; ++i)
            {
                this.courses[i].ShowCourseInfo();
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine("Student Name: " + Name);
            Console.WriteLine("Student ID: " + Id);
            Console.WriteLine("CGPA: " + Cgpa);
        }
    }
}