using System.IO;

namespace BashSoft
{
    public static class SessionsData
    {
        // This variable stores the CURRENT WORKING DIRECTORY of the application.
        // It behaves like a "shell path" (similar to cmd or terminal in real OS).
        //
        // Example:
        // C:\Users\...\BashSoft\bin\Debug
        //
        // All file operations (ls, mkdir, cd, readDb, etc.) depend on this path.
        //
        // It is STATIC because:
        // - There is only ONE active session in the program
        // - All commands share the same working directory state

        public static string currentPath = Directory.GetCurrentDirectory();

        // Directory.GetCurrentDirectory():
        // - Returns the folder where the .exe is running
        // - This becomes the starting point of the "virtual file system" in BashSoft
        //
        // In BashSoft, this acts like:
        // > pwd (print working directory in Linux)
    }
}