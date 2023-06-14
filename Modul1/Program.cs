// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Console.WriteLine("Skriv dit navn:");
var input = Console.ReadLine();
Console.WriteLine($"Hej {input}");


// fakultet
/*Console.WriteLine(Opgave3.Faculty(5)); // Output skal være '120'.
Console.WriteLine("done");

class Opgave3
{
    public static int Faculty(int n)
    {
        if (n == 0)
        {
            return 1;
        }
        else
        {
            return n * Faculty(n - 1);
        }
    }
} */
//Euclids 
/*Console.WriteLine(Opgave4.Euclids(308788500, 59928));

class Opgave4
{
    public static int Euclids(int a, int b)
    {
        if (b <= a && a % b == 0)
        {
            return b;
        }
        else if (a < b)
        {
            return Euclids(b, a);
        }
        else
        {
            return Euclids(b, a % b);
        }
    }
}*/

//Potens
/*Console.WriteLine(Opgave4.Potens(10, 3));

class Opgave4
{
    public static int Potens(int n, int p)
    {
        if (p == 1)
        {
            return n;
        }
        else if (p == 0)
        {
            return 1;
        }
        else
        {
            return n * Potens(n, p - 1);
        }
    }
}*/

//Gange
/*Console.WriteLine(Opgave4.Multiply(50, 6));

class Opgave4
{
    public static int Multiply(int a, int b)
    {
        if (b == 1)
        {
            return a;
        }
        else
        {
            return a + Multiply(a, b - 1);
        }
    }
}*/

//Reverse
/*Console.WriteLine(Opgave4.Reverse("jeh dem gid sungam"));

class Opgave4
{
    public static string Reverse(string s)
    {
        if (s.Length == 1)
        {
            return s;
        }
        else
        {
            return Reverse(s.Substring(1)) + s[0];
        }
    }
}*/

//Readfolder
Opgave5.ScanDir("C:\\Users\\Kristian");

class Opgave5
{
    public static void ScanDir(string path)
    {
        DirectoryInfo dir = new DirectoryInfo(path);
        FileInfo[] files = dir.GetFiles();

        // Udskriver alle filerne
        foreach (FileInfo file in files)
        {
            Console.WriteLine(file.Name);
        }
        DirectoryInfo[] dirs = dir.GetDirectories();

        // Kalder rekursivt på alle undermapper
        foreach (DirectoryInfo subdir in dirs)
        {
            ScanDir(subdir.FullName);
        }
    }
}