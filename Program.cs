// See https://aka.ms/new-console-template for more information
using System;
using System.IO;
using System.Text;


ReadInput1:
Console.WriteLine("Enter Input string file name:");

string inputfileName = Console.ReadLine();

//Get input File from user computer MyDocuments special Folder
string pathToFiles = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
if (string.IsNullOrEmpty(inputfileName))
{
    goto ReadInput1;
}

if (!File.Exists(Path.Combine(pathToFiles, inputfileName)))
{
    Console.WriteLine("Enter a file name that exists with the file extension:");
    goto ReadInput1;
}

Console.WriteLine("Enter MaximumCharacter per line:");

// Create a string variable and get user input from the keyboard and store it in the variable
ReadInput2:
string maxStringLength = Console.ReadLine();
int maxLineLength=0;

if (!string.IsNullOrEmpty(maxStringLength))
{
    if (int.TryParse(maxStringLength, out maxLineLength))
    {

    }
    else
    {
        Console.WriteLine("Enter valid MaximumCharacter per line:");
        //Console.ReadLine();
        goto ReadInput2;
    }
   // int maxLineLength = Convert.ToInt32(maxStringLength);
}
else
{
    Console.WriteLine("Enter valid  MaximumCharacter per line:");
    goto ReadInput2;
}


string[] lines = File.ReadAllLines(Path.Combine(pathToFiles, inputfileName));


//Exceute function to format input string from a text file
formatSampleInput(lines, maxLineLength);
//formatSampleInput(lines, maxLineLength);

static void formatSampleInput(string[] inp, int len)
{
    int pos = 0;
    StringBuilder outputString = new StringBuilder();
    if (inp.Length < 1)
    {
        Console.WriteLine("Input string is Empty");
    }
    else
    {
        foreach (string line in inp)
        {
            if (line.Length > len)
            {
               
                while(pos < (line.Length) - pos)
                {
                    outputString.AppendLine(line.Substring(pos,len));
                    pos+=len;
                    
                }

                if (pos+1 > len)
                {
                    outputString.AppendLine(line.Substring(pos));
                }
            }
            else
            {
                outputString.AppendLine(line);
            }
            pos = 0;
        }       
    }
    
    Console.WriteLine(outputString.ToString());
    string pathToFiles = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    using (StreamWriter outputFile = new StreamWriter(Path.Combine(pathToFiles, "SampleStringLineBreakerOutput.txt")))
    {
        outputFile.WriteLine(outputString.ToString());
    }
     //return outputString.ToString();

  
}



