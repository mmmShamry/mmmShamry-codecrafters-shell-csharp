using System.Net;
using System.Net.Sockets;


// Wait for user input

while (true)
{
    List<string> builtins = new List<string> { "echo", "exit" };
    
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