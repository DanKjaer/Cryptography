// See https://aka.ms/new-console-template for more information
Console.WriteLine("Safely store message");
Console.WriteLine("Read message");
Console.WriteLine("Exit");

string? enteredText = Console.ReadLine();

ConsoleKeyInfo key = Console.ReadKey(intercept: true);
//Check if a specific key is pressed
bool isEnter = key.key == ConsoleKey.Enter;
//Get the character that was pressed
bool character = key.keyChar;

