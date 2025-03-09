// Benjamin Johnson, 3/08, Lab 5 - Piglatin /Encoder
Console.Clear();

// Greeting
Console.WriteLine(@"
                        Welcome to the Piglatin encoder!
Input any message you'd like and I will convert it to piglatin and then encrypt it.");

Console.Write("Please provide a message to encode: ");
string response = Console.ReadLine();
string[] words = response.Split();