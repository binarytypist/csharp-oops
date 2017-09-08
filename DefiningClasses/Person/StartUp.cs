using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

class StartUp
{
    private static void Main(string[] args)
    {
        // =========================================================
        // PROBLEM 1 - COUNT PRIVATE FIELDS (REFLECTION)
        // =========================================================
        Type personType1 = typeof(Person);

        FieldInfo[] fields = personType1
            .GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

        Console.WriteLine("Private fields count: " + fields.Length);


        // =========================================================
        // PROBLEM 2 - CONSTRUCTOR TESTING (REFLECTION)
        // =========================================================
        Type personType2 = typeof(Person);

        ConstructorInfo emptyCtor = personType2.GetConstructor(Type.EmptyTypes);
        ConstructorInfo ageCtor = personType2.GetConstructor(new[] { typeof(int) });
        ConstructorInfo nameAgeCtor = personType2.GetConstructor(new[] { typeof(string), typeof(int) });

        bool swapped = false;

        if (nameAgeCtor == null)
        {
            nameAgeCtor = personType2.GetConstructor(new[] { typeof(int), typeof(string) });
            swapped = true;
        }

        // DUMMY INPUT
        string name = "John";
        int age = 25;

        Person basePerson = (Person)emptyCtor.Invoke(new object[] { });
        Person personWithAge = (Person)ageCtor.Invoke(new object[] { age });

        Person personWithAgeAndName = swapped
            ? (Person)nameAgeCtor.Invoke(new object[] { age, name })
            : (Person)nameAgeCtor.Invoke(new object[] { name, age });

        Console.WriteLine($"{basePerson.Name} {basePerson.Age}");
        Console.WriteLine($"{personWithAge.Name} {personWithAge.Age}");
        Console.WriteLine($"{personWithAgeAndName.Name} {personWithAgeAndName.Age}");


        // =========================================================
        // PROBLEM 3 - FAMILY OLDSET MEMBER (REFLECTION + OOP)
        // =========================================================
        MethodInfo oldestMemberMethod = typeof(Family).GetMethod("GetOldestMember");
        MethodInfo addMemberMethod = typeof(Family).GetMethod("AddMember");

        if (oldestMemberMethod == null || addMemberMethod == null)
        {
            throw new Exception("Methods missing in Family class");
        }

        Family family = new Family();

        // DUMMY DATA
        List<(string Name, int Age)> members = new List<(string, int)>
        {
            ("John", 20),
            ("Alice", 35),
            ("Bob", 40)
        };

        foreach (var m in members)
        {
            family.AddMember(new Person(m.Name, m.Age));
        }

        var oldest = family.GetOldestMember();
        Console.WriteLine($"{oldest.Name} {oldest.Age}");


        // =========================================================
        // PROBLEM 4 - FILTER PEOPLE > 30
        // =========================================================
        List<Person> people = new List<Person>();

        List<(string Name, int Age)> peopleData = new List<(string, int)>
        {
            ("John", 25),
            ("Alice", 35),
            ("Bob", 40),
            ("Mike", 28)
        };

        foreach (var p in peopleData)
        {
            people.Add(new Person(p.Name, p.Age));
        }

        foreach (var person in people
            .Where(x => x.Age > 30)
            .OrderBy(p => p.Name))
        {
            Console.WriteLine($"{person.Name} - {person.Age}");
        }


        // =========================================================
        // PROBLEM 5 - DATE DIFFERENCE
        // =========================================================
        DateModifier dm = new DateModifier();

        // DUMMY DATES
        string date1 = "2000-01-01";
        string date2 = "2005-01-01";

        dm.FindDifference(date1, date2);

        Console.WriteLine("Days difference: " + dm.DateDifferenceDays);
    }
}