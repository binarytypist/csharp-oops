

// <summary>
// Base class for all machines in the system, providing common properties and functionality.    
// The Machine class is an abstract class that serves as a base for all types of machines in the Minedraft system,
// including harvesters and providers. It contains a single property, Id, which is a string that uniquely identifies each machine.
// The constructor of the Machine class takes an id parameter and sets the Id property. The Id property has a getter and a setter, allowing derived classes to access and modify the machine's identifier as needed. The Machine class provides a common foundation for all machines in the system, 
// ensuring that they all have a unique identifier and can be managed consistently within the DraftManager.  
// </ summary >

public abstract class Machine
{
    private string id;

    protected Machine(string id)
    {
        this.Id = id;
    }

    public string Id
    {
        get { return this.id; }
        set { this.id = value; }
    }
}