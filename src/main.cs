using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Sockets;


// Wait for user input

while (true)
{
    List<string> builtins = new List<string> { "echo", "exit" ,"type"};
    
    Console.Write("$ ");
    var command = Console.ReadLine().ToLower();
    
    if (command == "exit 0")
    {
        break;
    }
    else if (command.StartsWith("echo"))
    {
        Console.WriteLine($"{command.Substring(5)}");
        continue;
    }
    else if (command.StartsWith("type"))
    {
        if (builtins.Contains(command.Substring(5)))
        {
            Console.WriteLine($"{command.Substring(5)} is a shell builtin");
            continue;
        }
        else if(pathLookup(command.Substring(5), out string foundAt))
        {
            Console.WriteLine($"{command.Substring(5)} is {Path.Combine(foundAt, command.Substring(5))}");
            continue;
        }
        else
        {
            Console.WriteLine($"{command.Substring(5)}: not found");
            continue;
        }
    }
    else
    {
        Console.WriteLine($"{command}: command not found");
        continue;
    }
}


bool pathLookup (string cmd, [NotNullWhen(true)] out string foundAt)
{
    string? pathEnvVar = Environment.GetEnvironmentVariable("PATH");
    if (pathEnvVar != null)
    {
        string[] parts = pathEnvVar.Split(Path.PathSeparator);
        foreach (string part in parts)
        {
            if (File.Exists(Path.Combine(part, cmd)))
            {
                foundAt = part;
                return true;
            }
        }
    }

    foundAt = null;
    return false;
}