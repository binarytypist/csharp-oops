using System;
using System.Collections.Generic;
using System.Linq;

class CompanyRoster
{
    public static void Main(string[] args)
    {
        /*
         * PURPOSE OF THIS PROGRAM:
         * ------------------------
         * We are building a company roster system.
         *
         * We:
         * 1. Create employees
         * 2. Group them by department
         * 3. Find department with highest average salary
         * 4. Print employees in that department
         */

        // ----------------------------------------------------
        // STEP 1: DUMMY INPUT DATA (instead of Console.ReadLine)
        // ----------------------------------------------------
        var inputData = new List<string>
        {
            "John 1200 Developer IT 28",
            "Anna 1500 Manager HR",
            "Peter 1800 Developer IT peter@mail.com",
            "George 2000 Manager HR 35",
            "Michael 2500 Developer IT 30",
            "Sara 3000 CEO Management 40"
        };

        // Store all employees
        List<Employee> employees = new List<Employee>();

        // ----------------------------------------------------
        // STEP 2: PROCESS EMPLOYEE CREATION
        // ----------------------------------------------------
        foreach (var line in inputData)
        {
            var tokens = line.Split(' ');

            // Basic required fields
            var name = tokens[0];                     // employee name
            decimal salary = decimal.Parse(tokens[1]); // employee salary
            string position = tokens[2];              // job title
            string department = tokens[3];            // department

            // Create employee object
            Employee emp = new Employee(name, salary, position, department);

            /*
             * OPTIONAL FIELDS LOGIC:
             * tokens[4] can be:
             * - age (number)
             * - email (string)
             */
            if (tokens.Length > 4)
            {
                int age;

                // If it is a number → it's age
                if (int.TryParse(tokens[4], out age))
                {
                    emp.Age = age;
                }
                else
                {
                    // Otherwise → it's email
                    emp.Email = tokens[4];
                }

                // If 6th value exists → always age (overwrite or confirm)
                if (tokens.Length > 5)
                {
                    emp.Age = int.Parse(tokens[5]);
                }
            }

            // Add employee to list
            employees.Add(emp);
        }

        // ----------------------------------------------------
        // STEP 3: GROUP EMPLOYEES BY DEPARTMENT
        // ----------------------------------------------------
        var bestDep = employees
            .GroupBy(
                x => x.Department, // group key (department)

                x => new
                {
                    // projection (what we keep inside group)
                    Name = x.Name,
                    Salary = x.Salary,
                    Email = string.IsNullOrEmpty(x.Email) ? "n/a" : x.Email,
                    Age = x.Age != null ? x.Age.Value : -1
                },

                (department, emplos) =>
                new
                {
                    Department = department,

                    // sort employees inside department by salary descending
                    Emps = emplos.OrderByDescending(e => e.Salary).ToList()
                })
            // find department with highest average salary
            .OrderByDescending(x => x.Emps.Average(e => e.Salary))
            .First();

        // ----------------------------------------------------
        // STEP 4: OUTPUT RESULT
        // ----------------------------------------------------

        // print best department
        Console.WriteLine($"Highest Average Salary: {bestDep.Department}");

        // print employees in that department
        foreach (var e in bestDep.Emps)
        {
            Console.WriteLine($"{e.Name} {e.Salary:F2} {e.Email} {e.Age}");
        }
    }
}