using System;
using System.Collections.Generic;
using System.Linq;

public class Family
{
    /*
     * PURPOSE OF THIS CLASS:
     * ----------------------
     * This class represents a FAMILY group.
     *
     * It stores multiple Person objects and provides
     * operations to manage them.
     *
     * This demonstrates:
     * - Encapsulation (data + behavior together)
     * - Aggregation (Family HAS MANY Persons)
     * - Collection management in OOP
     */

    /*
     * CONSTRUCTOR:
     * ------------
     * Initializes the FamilyMembers list to avoid null errors.
     */
    public Family()
    {
        this.FamilyMembers = new List<Person>();
    }

    /*
     * PROPERTY:
     * ---------
     * Stores all Person objects in the family.
     *
     * This is a HAS-MANY relationship.
     */
    public ICollection<Person> FamilyMembers { get; set; }

    /*
     * METHOD: AddMember
     * -----------------
     * Adds a Person object into the family collection.
     *
     * This demonstrates behavior (not just data storage).
     */
    public void AddMember(Person member)
    {
        this.FamilyMembers.Add(member);
    }

    /*
     * METHOD: GetOldestMember
     * -----------------------
     * Finds the oldest person in the family.
     *
     * Logic:
     * - Orders members by Age descending
     * - Returns the first (oldest)
     */
    public Person GetOldestMember()
    {
        return FamilyMembers
            .OrderByDescending(f => f.Age)
            .First();
    }
}