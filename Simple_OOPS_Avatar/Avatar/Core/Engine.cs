using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

// Controller class that manages the whole simulation
public class Engine
{
    private NationsBuilder builder;

    // Dummy input instead of Console.ReadLine
    private Queue<string> input;

    public Engine()
    {
        this.builder = new NationsBuilder();

        // Dummy dataset (replace Console input)
        this.input = new Queue<string>(new[]
        {
            "Bender Air Aang 100 1.5",
            "Monument Air SkyTemple 30",
            "Status Air",
            "War Fire",
            "Quit"
        });
    }

    public void Run()
    {
        var tokens = ParseInput(ReadLine());

        string command;

        while ((command = tokens[0]) != "Quit")
        {
            ProcessCommand(command, tokens.Skip(1).ToList());

            tokens = ParseInput(ReadLine());
        }

        Console.WriteLine(builder.GetWarsRecord());
    }

    // Replace Console.ReadLine
    private string ReadLine()
    {
        return input.Count > 0 ? input.Dequeue() : "Quit";
    }

    private void ProcessCommand(string command, List<string> commandArgs)
    {
        switch (command)
        {
            case "Bender":
                builder.AssignBender(commandArgs);
                break;

            case "Monument":
                builder.AssignMonument(commandArgs);
                break;

            case "Status":
                Console.Write(builder.GetStatus(commandArgs.First()));
                break;

            case "War":
                builder.IssueWar(commandArgs.First());
                break;
        }
    }
    

    private List<string> ParseInput(string input)
    {
        return input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
    }
}