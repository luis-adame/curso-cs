// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Search: ");
//var input = Console.ReadLine();

Console.WriteLine("Anio: ");
var input = Console.ReadLine();
Console.WriteLine("Mes");
input += "-" + Console.ReadLine();
Console.WriteLine("Dia");
input += "-" + Console.ReadLine();

Searcher(input);


static void Searcher(string input)
{
    User.Input = input;

    Predicate<Person> predicateByName = new Predicate<Person>(Person.exist);
    Predicate<Person> predicateByAge = new Predicate<Person>(Person.GetByAge);
    Predicate<Person> predicateByBirthday = new Predicate<Person>(Person.GetByBirthday);

    List<Person> people = new List<Person>()
    {
        new Person() { name = "Luis", age = 29, Birthday = new DateTime(1992, 05, 17)},
        new Person() { name = "Felipe", age = 29, Birthday = new DateTime(1993, 06, 18)},
        new Person() { name = "Adame", age = 29, Birthday = new DateTime(1994, 07, 19)}
    };

    if (people.Exists(predicateByBirthday))
    {
        Console.WriteLine("The user exists");
    }
    else
    {
        Console.WriteLine("The user exists");
    }

    //if (people.Exists(predicateByName))
    //    Console.WriteLine("The user exists");
    //else
    //{
    //    var result = people.FindAll(predicateByAge);

    //    if (result.Any())
    //    {
    //        Console.WriteLine("We found these names:");

    //        foreach (var item in result)
    //        {
    //            Console.WriteLine(item.name);
    //        }
    //    }
    //    else
    //        Console.WriteLine("We did not find any names.");
    //}
}

class Person
{
    public String name { get; set; }
    public int age { get; set; }
    public DateTime Birthday { get; set; }

    public static bool exist(Person persona)
    {
        return persona.name.Equals(User.Input);
    }

    public static bool GetByAge(Person person)
    {
        var isNumber = Int32.TryParse(User.Input, out int age);

        if (isNumber)
            return person.age.Equals(age);
        else
            return false;
    }

    public static bool GetByBirthday(Person person)
    {
        DateTime fecha = DateTime.Parse(User.Input);

        if (person.Birthday.Equals(fecha))
            return true;
        else
            return false;
    }
}

class User
{
    public static string Input { get; set; }
}
