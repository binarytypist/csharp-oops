using BashSoft.Exceptions;
using System;

namespace BashSoft.IO.Commands
{

    /// <summary>
    ///  The Command class is an abstract base class that defines the structure and behavior of commands in the BashSoft application.
    /// </summary>  
    
    public abstract class Command
    {
        //  Fields
        /// <summary>
        //  The Command class has three private fields: judge, repository, and inputOutputManager. These fields are used to store references
        //  to the Tester, StudentsRepository, and IOManager instances that are passed to the constructor of the Command class. The judge field is used for testing purposes, while the repository and inputOutputManager fields are used 
        //  for managing student data and handling input/output operations, respectively.
        //  The Command class also has two private fields, input and data, which are used to store the raw command input and the
        //  command data (an array of strings containing the command name and its arguments).
        //  These fields are initialized in the constructor and can be accessed through public properties.
        //  The Command class provides a constructor that initializes these fields and properties to ensure that the command has access
        //  to the necessary components for execution.
        private Tester judge;
        private StudentsRepository repository;
        private IOManager inputOutputManager;

        private string input;
        private string[] data;


        //  Constructor for the Command class. It initializes the command with the given input, data, tester, repository, and IO manager.
        //  Parameters:
        //  - input: The raw command input from the user.
        //  - data: An array of strings containing the command name and its arguments.
        //  - judge: An instance of the Tester class, used for testing purposes.
        //  - repository: An instance of the StudentsRepository class, used for managing student data
        //  - inputOutputManager: An instance of the IOManager class, used for managing input and output operations.
        //  The constructor initializes the private fields with the provided parameters and sets the Input and Data properties using
        //  the provided input and data parameters.

        public Command(string input, string[] data, Tester judge, StudentsRepository repository, IOManager inputOutputManager)
        {

            // The constructor initializes the private fields with the provided parameters and sets the Input and Data properties using
            // the provided input and data parameters. The Input and Data properties have validation logic in
            // their setters to ensure that the command is initialized with valid input and data. If the input is null or empty, an InvalidStringException is thrown.
            // If the data is null or empty, a NullReferenceException is thrown.
            // The constructor also assigns the judge, repository, and inputOutputManager parameters to the
            // corresponding private fields, allowing the command to access these components during execution.    
            this.Input = input;
            this.Data = data;
            this.judge = judge;
            this.repository = repository;
            this.inputOutputManager = inputOutputManager;
        }


        // Properties for accessing the private fields and properties of the Command class. These properties provide access to the judge,
        // repository, inputOutputManager, Input, and Data fields. The Judge, Repository, and InputOutputManager properties are protected, allowing derived classes to access these components during execution.
        // The Input and Data properties have validation logic in
        // their setters to ensure that they are set with valid values.
        // The Input property checks if the value is null or empty and throws an InvalidStringException if it is. The Data property
        // checks if the value is null or has a length of zero and throws a NullReferenceException if it does. These properties ensure that the
        // command is initialized with valid input and data, which is essential for the correct execution of the command.
        protected Tester Judge
        {
            get { return this.judge; }
        }


        // The Repository property provides access to the StudentsRepository instance, allowing derived classes to manage student data
        // during command execution. The InputOutputManager property provides access to the IOManager instance, allowing derived classes to handle
        // input and output operations during command execution. These properties are essential for the functionality of the commands in the BashSoft
        // application, as they allow the commands to interact with the underlying data and perform necessary input/output operations.
        // The Command class is designed to be extended by specific command implementations, which will override the Execute method to define the
        // behavior of the command when it is executed. The Execute method is abstract, meaning that it must be implemented by any non-abstract class that inherits from Command.
        // This design allows for a flexible and extensible command structure in the BashSoft application,
        // where new commands can be added by simply creating new classes that inherit from Command and implement the Execute method.
        protected StudentsRepository Repository
        {
            get { return this.repository; }
        }


        // The InputOutputManager property provides access to the IOManager instance, allowing derived classes to handle input and output
        // operations during command execution. This property is essential for the functionality of the commands in the BashSoft application, as it allows the
        // commands to interact with the underlying data and perform necessary input/output operations.
        protected IOManager InputOutputManager
        {
            get { return this.inputOutputManager; }
        }


        // The Input property provides access to the raw command input from the user. It has a protected setter that validates the input value.
        // If the input value is null or empty, an InvalidStringException is thrown. This validation ensures that the command is initialized with valid
        // input,which is essential for the correct execution of the command. 
        // The Data property provides access to the command data, which is an array of strings containing the command name and its arguments. 
        // It has a protected setter that validates the data value. If the data value is null or has a length of zero, a NullReferenceException is thrown.
        // This validation ensures that the command is initialized with valid data, which is essential for the correct execution of the command.
        public string[] Data
        {
            get { return this.data; }
            protected set
            {
                if (value == null || value.Length == 0)
                {
                    throw new NullReferenceException();
                }

                this.data = value;
            }
        }

        public string Input
        {
            get { return this.input; }
            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }

                this.input = value;
            }
        }

        public abstract void Execute();
    }
}