using FamilyTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Problem13_FamilyTree
{
    class FamilyTree
    {
        private static void Main(string[] args)
        {
            /*
             * PURPOSE:
             * Build a family tree using Person objects
             * and link them via parent-child relationships.
             */

            // Regex to detect date format (dd/mm/yyyy)
            string pattern = @"\b\d+\/\d+\/\d+";
            Regex rgx = new Regex(pattern);

            // All persons stored here
            List<Person> people = new List<Person>();

            // TARGET PERSON (no input)
            var key = "John Doe";

            /*
             * DUMMY INPUT DATA
             */
            List<string> inputData = new List<string>
            {
                "John Doe 01/01/2000",
                "Jane Smith 02/02/2005",
                "Alice Brown 03/03/1980",
                "John Doe - Jane Smith",
                "Alice Brown - John Doe",
                "End"
            };

            // Separate data containers
            List<string> linkedInformation = new List<string>();
            List<string> unlinkedInformation = new List<string>();

            /*
             * STEP 1: SPLIT INPUT
             */
            foreach (var input in inputData)
            {
                if (input == "End")
                    break;

                if (input.Contains(" - "))
                {
                    unlinkedInformation.Add(input);
                }
                else
                {
                    linkedInformation.Add(input);
                }
            }

            /*
             * STEP 2: CREATE PERSON OBJECTS
             */
            foreach (var line in linkedInformation)
            {
                var tokens = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string firstName = tokens[0];
                string lastName = tokens[1];
                string date = tokens[2];

                people.Add(new Person(firstName, lastName, date));
            }

            /*
             * STEP 3: BUILD RELATIONSHIPS (GRAPH)
             */
            foreach (var relation in unlinkedInformation)
            {
                Person parent = null;
                Person child = null;

                var tokens = relation
                    .Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .ToArray();

                // FIND PARENT
                if (rgx.IsMatch(tokens[0]))
                {
                    parent = people.First(p => p.Date == tokens[0]);
                }
                else
                {
                    var name = tokens[0]
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    parent = people.First(p =>
                        p.FirstName == name[0] &&
                        p.LastName == name[1]);
                }

                // FIND CHILD
                if (rgx.IsMatch(tokens[1]))
                {
                    child = people.First(p => p.Date == tokens[1]);
                }
                else
                {
                    var name = tokens[1]
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    child = people.First(p =>
                        p.FirstName == name[0] &&
                        p.LastName == name[1]);
                }

                // LINK OBJECTS (COMPOSITION)
                parent.Children.Add(child);
                child.Parents.Add(parent);
            }

            /*
             * STEP 4: FIND TARGET PERSON
             */
            Person target = people.First(p =>
                p.FirstName == "John" &&
                p.LastName == "Doe");

            /*
             * STEP 5: OUTPUT
             */
            Console.WriteLine(target.ToString());

            Console.WriteLine("Parents:");
            foreach (var p in target.Parents)
            {
                Console.WriteLine(p.ToString());
            }

            Console.WriteLine("Children:");
            foreach (var c in target.Children)
            {
                Console.WriteLine(c.ToString());
            }
        }
    }
}