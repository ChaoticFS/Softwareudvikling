//opg1
/*Person[] people = new Person[]
{
    new Person { Name = "Jens Hansen", Age = 45, Phone = "+4512345678" },
    new Person { Name = "Jane Olsen", Age = 22, Phone = "+4543215687" },
    new Person { Name = "Tor Iversen", Age = 35, Phone = "+4587654322" },
    new Person { Name = "Sigurd Nielsen", Age = 31, Phone = "+4512345673" },
    new Person { Name = "Viggo Nielsen", Age = 28, Phone = "+4543217846" },
    new Person { Name = "Rosa Jensen", Age = 23, Phone = "+4543217846" },
};

// Udregner den samlede alder for alle mennesker.
/*int totalAge = 0;
for (int i = 0; i < people.Length; i++)
{
    totalAge += people[i].Age;
}
Console.WriteLine(people.Sum(person => person.Age));*/

// Tæller hvor mange der hedder "Nielsen"
/*int countNielsen = 0;
for (int i = 0; i < people.Length; i++)
{
    if (people[i].Name.Contains("Nielsen"))
    {
        countNielsen++;
    }
}
Console.WriteLine(people.Where(person => person.Name.Contains("Nielsen")).Count());*/

// Find den ældste person
/*Person oldestPerson = null;
for (int i = 0; i < people.Length; i++)
{
    if (oldestPerson == null || people[i].Age > oldestPerson.Age)
    {
        oldestPerson = people[i];
    }
}
Console.WriteLine(people.MaxBy(person => person.Age).Name);

class Person
{
    public string? Name { get; set; }
    public int Age { get; set; }
    public string? Phone { get; set; }
}
*/

//opg2
/*Person[] people = new Person[]
{
    new Person ( Name: "Jens Hansen", Age: 45, Phone: "+4512345678" ),
    new Person ( Name: "Jane Olsen", Age: 22, Phone: "+4543215687" ),
    new Person ( Name: "Tor Iversen", Age: 35, Phone: "+4587654322" ),
    new Person ( Name: "Sigurd Nielsen", Age: 31, Phone: "+4512345673" ),
    new Person ( Name: "Viggo Nielsen", Age: 28, Phone: "+4543217846" ),
    new Person ( Name: "Rosa Jensen", Age: 23, Phone: "+4543217846" ),
};

//Find og udskriv personen med mobilnummer “+4543215687”.
Console.WriteLine(people.First(person => person.Phone == "+4543215687").Name);

//Vælg alle som er over 30 og udskriv dem.
Console.WriteLine(string.Join(", ", people.Where(person => person.Age >= 30).ToList().Select(person => person.Name)));

//Lav et nyt array med de samme personer, men hvor “+45” er fjernet fra alle telefonnumre.
//Console.WriteLine(string.Join(" ,", people.Select(person => new Person (person.Name, person.Age, person.Phone.Substring(3))).ToList().Select(person => person.Name + ": " + person.Phone)));
Console.WriteLine(string.Join(" ,", people.Select(person => new Person { Name = person.Name, Age = person.Age, Phone = person.Phone.Substring(3) }).ToList().Select(person => person.Name + ": " + person.Phone)));

//Generér en string med navn og telefonnummer på de personer, der er yngre end 30, adskilt med komma
Console.WriteLine(string.Join(", ", people.Where(person => person.Age < 30).ToList().Select(person => $"{person.Name}: {person.Phone}")));

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Phone { get; set; }

    public Person(string Name = "", int Age = 0, string Phone = "")
    {
        this.Name = Name;
        this.Age = Age;
        this.Phone = Phone;
    }
} */

//opg3 
/*var CreateWordFilterFn = (string[] words) => {
    return (string text) => {
        return string.Join(" ", text.Split(" ").Where(w => !words.Contains(w)));
    };
};

var CreateWordReplacerFn = (string[] words, string replacementWord) => {
    return (string text) => {
        return string.Join(" ", text.Split(" ").Select(w => !words.Contains(w) ? w : replacementWord));
    };
};

var badWords = new string[] { "shit", "fuck", "idiot", "lort" };
//var FilterBadWords = CreateWordFilterFn(badWords);
var FilterBadWords = CreateWordReplacerFn(badWords, "kage");
Console.WriteLine(FilterBadWords("Sikke en gang lort"));
// Udskriver: "Sikke en gang kage" */

//Opg4 
Person[] people = new Person[]
{
    new Person { Name = "Jens Hansen", Age = 45, Phone = "+4512345678" },
    new Person { Name = "Jane Olsen", Age = 22, Phone = "+4543215687" },
    new Person { Name = "Tor Iversen", Age = 35, Phone = "+4587654322" },
    new Person { Name = "Sigurd Nielsen", Age = 31, Phone = "+4512345673" },
    new Person { Name = "Viggo Nielsen", Age = 28, Phone = "+4543217846" },
    new Person { Name = "Rosa Jensen", Age = 23, Phone = "+4543217846" },
};

Console.WriteLine("Før sortering:");
PrintPeople(people);

BubbleSort.Sort(people, (p1, p2) => p1.Age.CompareTo(p2.Age));

Console.WriteLine("\nEfter sortering:");
PrintPeople(people);
    

    static void PrintPeople(Person[] people)
{
    foreach (Person person in people)
    {
        Console.WriteLine($"Name: {person.Name}, Age: {person.Age}, Phone: {person.Phone}");
    }
}

public class BubbleSort
{
    // Bytter om på to elementer i et array
    private static void Swap(Person[] array, int i, int j)
    {
        Person temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }

    Func<Person, Person, int> compareFn = (Person p1, Person p2) => {
        if (p1.Age > p2.Age)
        {
            return -1;
        }
        else if (p1.Age < p2.Age)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    };

    // Laver sortering på array med Bubble Sort. 
    // compareFn bruges til at sammeligne to personer med.
    public static void Sort(Person[] array, Func<Person, Person, int> compareFn)
    {
        for (int i = array.Length - 1; i >= 0; i--)
        {
            for (int j = 0; j <= i - 1; j++)
            {
                // Laver en ombytning, hvis to personer står forkert sorteret
                if (compareFn(array[j], array[j + 1]) > 0)
                {
                    Swap(array, j, j + 1);
                }
            }
        }
    }


}

public class Person
{
    public string? Name { get; set; }
    public int Age { get; set; }
    public string? Phone { get; set; }
}
