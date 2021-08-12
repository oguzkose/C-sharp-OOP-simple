﻿using System;

namespace C_sharp_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Constructor
            // Employee employee = new Employee(1, "Oğuz", "Köse");
            // Console.WriteLine(employee.Number + " " + employee.Name + " " + employee.Surname);//Output: 1 Oğuz Köse 
            // Employee employee2 = new Employee("James", "Hetfield");
            // Console.WriteLine(employee2.Name + " " + employee2.Surname);//Output: James Hetfield
            #endregion
            #region Encapsulation
            Student student = new Student("Oğuz", "Köse", 21);
            student.PrintStudentInfo();//Output: Not:21

            student.DownGrade();
            student.PrintStudentInfo();//Output: Not:1

            student.DownGrade();
            student.PrintStudentInfo();//Output: Not sıfırdan küçük olamaz Not:1             
            #endregion
            #region StaticClass
            //Product class'i static olarak işaretlenmediği için instance'i alınabilir.Aksi durumda Product class'ina instance ile değil class ismi ile erişilebilirdi.
            Product product = new Product();

            //Id property'si static olmadığı için instance ile erişilebilir
            product.Id = 1;

            //Name field'i ve Surname property'si static olarak işaretlendiği için direct olarak ait oldukları class'ın ismi ile erişilebilirç
            Product.Name = "Oğuz";
            Product.Surname = "Köse";
            #endregion



        }
    }
}