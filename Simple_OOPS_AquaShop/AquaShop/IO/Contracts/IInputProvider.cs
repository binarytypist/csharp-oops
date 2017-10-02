namespace AquaShop.IO.Contracts
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines a contract for providing input data to the Engine.
    /// 
    /// This abstraction allows different input sources:
    /// - Console input
    /// - File input
    /// - Dummy/test input
    /// </summary>
    public interface IInputProvider
    {
        IEnumerable<string> GetInput();
    }
}