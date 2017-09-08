
public class Person
{
    /*
     * PURPOSE OF THIS CLASS:
     * ----------------------
     * This class represents a PERSON entity.
     *
     * It demonstrates:
     * - Encapsulation (private fields + public properties)
     * - Constructor overloading
     * - Constructor chaining (this() calls)
     * - Default object initialization
     */

    // PRIVATE FIELDS (data hiding → ENCAPSULATION)
    private string name;
    private int age;

    /*
     * DEFAULT CONSTRUCTOR:
     * --------------------
     * Sets default values when no data is provided.
     *
     * This ensures object is always in valid state.
     */
    public Person()
    {
        this.Name = "No name";
        this.Age = 1;
    }

    /*
     * CONSTRUCTOR OVERLOADING:
     * ------------------------
     * Allows creating object with only age.
     *
     * Constructor chaining is used → calls default constructor first.
     */
    public Person(int age) : this()
    {
        this.Age = age;
    }

    /*
     * CONSTRUCTOR OVERLOADING + CHAINING:
     * -----------------------------------
     * Allows creating object with name + age.
     *
     * It first calls Person(int age),
     * which then calls Person() (chain execution).
     */
    public Person(string name, int age) : this(age)
    {
        this.Name = name;
    }

    /*
     * PROPERTY: Name
     * --------------
     * Encapsulation of private field "name".
     *
     * Controls access to internal data.
     */
    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            this.name = value;
        }
    }

    /*
     * PROPERTY: Age
     * -------------
     * Encapsulation of private field "age".
     *
     * Ensures controlled access to data.
     */
    public int Age
    {
        get
        {
            return this.age;
        }
        set
        {
            this.age = value;
        }
    }
}