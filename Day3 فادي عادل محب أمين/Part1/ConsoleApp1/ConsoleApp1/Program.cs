//Question 1 Start:
using System;
using System.Text;

class Program
{
    static void Main()
    {
        // Accept input from the user
        Console.Write("Enter a number: ");
        string input = Console.ReadLine();

        // Try to parse the input using both int.Parse and Convert.ToInt32
        try
        {
            // Using int.Parse
            int parsedValue = int.Parse(input);
            Console.WriteLine($"Parsed value using int.Parse: {parsedValue}");
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Error with int.Parse: {ex.Message}");
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine($"Error with int.Parse: {ex.Message}");
        }

        try
        {
            // Using Convert.ToInt32
            int convertedValue = Convert.ToInt32(input);
            Console.WriteLine($"Converted value using Convert.ToInt32: {convertedValue}");
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Error with Convert.ToInt32: {ex.Message}");
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine($"Error with Convert.ToInt32: {ex.Message}");
        }
    }
}

/*Difference Between int.Parse and Convert.ToInt32 for null Inputs:
int.Parse:

Throws an ArgumentNullException if the input is null.
If the input is an empty string or a non-numeric string, it throws a FormatException.
Convert.ToInt32:

If the input is null, it returns 0 (does not throw an exception).
If the input is a non-numeric string, it throws a FormatException (like int.Parse).*/

//Question 1 End:



//Question 2 Start:
using System;

class Program
{
    static void Main()
    {
        // Prompt the user to enter a number
        Console.Write("Please enter a number: ");
        string input = Console.ReadLine();

        // Use int.TryParse to check if the input can be converted to an integer
        if (int.TryParse(input, out int result))
        {
            // If valid, print the parsed number
            Console.WriteLine($"You entered a valid number: {result}");
        }
        else
        {
            // If invalid, print an error message
            Console.WriteLine("Invalid input! Please enter a valid integer.");
        }
    }
}


/*Why is TryParse Recommended Over Parse in User-Facing Applications?
No Exceptions:

TryParse is safer in user-facing applications because it does not throw exceptions.
When you use int.Parse, an invalid input (such as a non-numeric string) results in a FormatException being thrown,
which you need to handle with a try-catch block.
This adds complexity and can make the application less responsive if errors are frequent.
TryParse, on the other hand,
simply returns false if the input is invalid,
allowing you to handle the error without the overhead of exception handling.*/

//Question 2 End:





//Question 3 Start:
using System;

class Program
{
    static void Main()
    {
        // Declare an object variable
        object obj;

        // Assign an integer to the object and print the GetHashCode()
        obj = 42;
        Console.WriteLine($"HashCode of int (42): {obj.GetHashCode()}");

        // Assign a string to the object and print the GetHashCode()
        obj = "Hello, world!";
        Console.WriteLine($"HashCode of string ('Hello, world!'): {obj.GetHashCode()}");

        // Assign a double to the object and print the GetHashCode()
        obj = 3.14159;
        Console.WriteLine($"HashCode of double (3.14159): {obj.GetHashCode()}");
    }
}


/*What is the Purpose of the GetHashCode() Method?
The GetHashCode() method is a part of the base System.
Object class, and it provides a hash value (an int) that is used for hashing-based operations.
The primary purpose of GetHashCode() is as follows:
Efficient Lookups in Hash-Based Collections,
Object Comparison,
Consistency and Uniqueness
*/

//Question 3 End:






//Question 4 Start:


using System;

class Program
{
    static void Main()
    {
        // Create an object and assign it a value
        Person person1 = new Person();
        person1.Name = "Fady";
        person1.Age = 21;

        // Create a second reference to the same object
        Person person2 = person1;

        // Modify the object using the first reference
        person1.Name = "Adel";
        person1.Age = 23;

        // Print the values using the second reference
        Console.WriteLine($"Person2's Name: {person2.Name}, Age: {person2.Age}");

        // Output the value using the first reference to show that both point to the same object
        Console.WriteLine($"Person1's Name: {person1.Name}, Age: {person1.Age}");
    }
}

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}



/*ignificance of Reference Equality in .NET:
In .NET, reference equality refers to the situation where two variables (references) point to the same memory location,
they refer to the same object instance.
The significance of reference equality includes the following:

Shared Mutability,
Memory Efficiency,
Performance Considerations,
Equality Comparison
*/


//Question 4 End:



//Question 5 Start:

using System;

class Program
{
    static void Main()
    {
        // Declare a string
        string message = "Hello";

        // Print the GetHashCode before modification
        Console.WriteLine($"Original message: {message}");
        Console.WriteLine($"GetHashCode before modification: {message.GetHashCode()}");

        // Modify the string by concatenating additional text
        message = message + " Fady";  // Concatenation creates a new string

        // Print the GetHashCode after modification
        Console.WriteLine($"Modified message: {message}");
        Console.WriteLine($"GetHashCode after modification: {message.GetHashCode()}");
    }
}


/*Why Is String Immutable in C#?
Performance Benefits: Immutable strings help to conserve memory.
Since strings are immutable, multiple references can point to the same string object 
without risk of unintended modifications.
This reduces the need to create multiple copies of the same string.
Interning: C# uses string interning,
which means that identical string literals are stored only once in memory. 
*/

//Question 5 End:




//Question 6 Start:
using System;
using System.Text;

class Program
{
    static void Main()
    {
        // Create a StringBuilder instance with initial text "Hi Fady"
        StringBuilder sb = new StringBuilder("Hi Fady");

        // Print the GetHashCode before modification
        Console.WriteLine($"Original StringBuilder: {sb.ToString()}");
        Console.WriteLine($"GetHashCode before modification: {sb.GetHashCode()}");

        // Append text to the StringBuilder
        sb.Append(" - Welcome to the C# World Fady Adel!");

        // Print the GetHashCode after modification
        Console.WriteLine($"Modified StringBuilder: {sb.ToString()}");
        Console.WriteLine($"GetHashCode after modification: {sb.GetHashCode()}");
    }
}


/*How StringBuilder Addresses Inefficiencies of String Concatenation:
In C#, strings are immutable.
This means that each time you modify a string,
a new string is created, and the old string is discarded.
This process can lead to significant inefficiencies when performing multiple concatenations,
especially in loops or when dealing with large strings.
Each concatenation involves allocating new memory, copying data from the old string,
and then adding the new content. This can cause performance problems,
particularly with large or numerous string modifications.*/

//Question 6 End:




//Question 7 Start:

/*StringBuilder is significantly faster for large-scale string modifications compared to using regular strings in C#.
This performance advantage arises from the way StringBuilder is designed to handle memory and string modifications.

In C#, strings are immutable, 
which means that once a string is created, it cannot be changed.
Any modification to a string (such as concatenation or replacement) results in a new string object being created.
This involves:

Allocating new memory for the modified string.
Copying the content of the original string to the new memory location.
Appending the new content to this copied string.*/

//Question 7 End:





//Question 8 Start:

using System;

class Program
{
    static void Main()
    {
        // Accept two integer inputs from the user
        Console.Write("Enter the first number: ");
        int input1 = int.Parse(Console.ReadLine());

        Console.Write("Enter the second number: ");
        int input2 = int.Parse(Console.ReadLine());

        // Calculate the sum
        int sum = input1 + input2;

        // Method 1: Concatenation
        Console.WriteLine("Concatenation: Sum is " + input1 + " + " + input2 + " = " + sum);

        // Method 2: Composite formatting (string.Format)
        Console.WriteLine("Composite formatting: Sum is {0} + {1} = {2}", input1, input2, sum);

        // Method 3: String interpolation ($)
        Console.WriteLine($"String interpolation: Sum is {input1} + {input2} = {sum}");
    }
}


/*Which String Formatting Method is Most Used and Why?
In modern C#,
string interpolation ($) is generally considered the most preferred
and commonly used string formatting method. Here's why:

Clarity and Readability:

String Interpolation is the most readable and straightforward method.
It directly integrates expressions inside the string,
making the code more intuitive to read and maintain.
For example:
Console.WriteLine($"Sum is {input1} + {input2} = {sum}");
This is clear because you can directly see the expression inside the {} within the string.*/

//Question 8 End:





//Question 9 Start:

using System;
using System.Text;

class Program
{
    static void Main()
    {
        // Initialize a StringBuilder with initial text
        StringBuilder sb = new StringBuilder("Hello World");

        // Append text
        sb.Append(" - Welcome to C# programming!");
        Console.WriteLine($"After Append: {sb}");

        // Replace a substring
        sb.Replace("World", "Universe");
        Console.WriteLine($"After Replace: {sb}");

        // Insert a string at a specific position
        sb.Insert(6, "Amazing ");
        Console.WriteLine($"After Insert: {sb}");

        // Remove a portion of text
        sb.Remove(6, 8);  // Remove "Amazing "
        Console.WriteLine($"After Remove: {sb}");
    }
}

/*How StringBuilder Handles Frequent Modifications:
Internal Buffer:

StringBuilder uses an internal buffer
(a dynamically resizable array) to hold the string data.
Instead of creating new string objects each time it is modified
(like in the case of immutable strings),
StringBuilder modifies the contents of its buffer.
This reduces memory usage and eliminates the overhead of
allocating and copying data each time a modification is made.*/

//Question 9 End:
