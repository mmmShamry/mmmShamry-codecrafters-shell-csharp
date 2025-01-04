using System.Net;
using System.Net.Sockets;


// Wait for user input

while (true)
{
    Console.Write("$ ");
    var command = Console.ReadLine();
    if (command == "exit 0")
    {
        break;
    }
    else
    {
        Console.WriteLine($"{command}: command not found");
        continue;
    }
}