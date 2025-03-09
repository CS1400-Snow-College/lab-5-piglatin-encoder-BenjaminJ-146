// Benjamin Johnson, 3/08, Lab 5 - Piglatin /Encoder
Console.Clear();

// Greeting
Console.WriteLine(@"
                        Welcome to the Piglatin encoder!
Input any message you'd like and I will convert it to piglatin and then encrypt it.");

// Input from user
Console.Write("Please provide a message to encode: ");
string? response = Console.ReadLine();
string[] words = response.Split(" ");
string pigLatin = "";

// Piglatin conversion
for (int i = 0; i < words.Length; i++)
{   
    // Word doesn't ends with punctuation
    if (!punctuationCheck(words[i]))
    {
        words[i] = words[i].ToLower();
        // Word starts with a vowel
        if (startsWithVowel(words[i])) 
        {
            words[i] += "way ";
            pigLatin += words[i];
        }
        // Word doesn't start with a vowel
        else
        {
            int index = firstVowel(words[i]); // Finds which position the first vowel is in      
            words[i] = words[i][index..words[i].Length] + words[i][0..index] + "ay ";
            pigLatin += words[i];
        }
    }
    // Word Ends with Punctuation
    else
    {
        // Removes the punctuation and stores it in another variable for later use
        char punctuation = words[i][words[i].Length - 1];
        words[i] = words[i][0..(words[i].Length - 1)].ToLower();
        // Word starts with a vowel
        if (startsWithVowel(words[i])) 
        {

            words[i] += "way" + punctuation + " "; // Adds punctuation back on
            pigLatin += words[i];
        }
        // Word doesn't start with a vowel
        else
        {
            int index = firstVowel(words[i]); // Finds which position the first vowel is in      
            words[i] = words[i][index..words[i].Length] + words[i][0..index] + "ay" + punctuation + " ";
            pigLatin += words[i];
        }
    }
}

Console.WriteLine($"This is your message in Piglatin: {pigLatin}");

// Method for checking if a word starts with a vowel
bool startsWithVowel(string word)
{
    if (word.StartsWith('a') || word.StartsWith('e') || word.StartsWith('i') || word.StartsWith('o') || word.StartsWith('u'))
    {
        if (word.StartsWith('i') && word.Length == 0)
            return false;
        else if (word.StartsWith('I') && word.Length == 0)
            return false;
        else
            return true;
    }
    else
    {
        return false;
    }
}

// Method for checking if a word ends with punctuation
bool punctuationCheck(string word)
{
    int asciiValue = (int) word[word.Length - 1];
    if (asciiValue < 65 || 90 < asciiValue && asciiValue < 97 || 122 < asciiValue)
    {
        return true;
    }
    else
    {
        return false;
    }
}

// Method for checking the postiion of the first vowel
int firstVowel (string word)
{
    int index = 0;
    for (int i = 1; i < word.Length; i++)
    {   
        if (word[i] == 'a')
        {
            index = word.IndexOf('a');
            break;
        }
        else if (word[i] == 'e')
        {
            index = word.IndexOf('e');
            break;
        }
        else if (word[i] == 'i')
        {
            index = word.IndexOf('i');
            break;
        }
        else if (word[i] == 'o')
        {
            index = word.IndexOf('o');
            break;
        }
        else if (word[i] == 'u')
        {
            index = word.IndexOf('u');
            break;
        }
        else if (word[i] == 'y')
        {
            index = word.IndexOf('y');
            break;
        }
        else
        {
            continue;
        }
    }
    return index;
}
