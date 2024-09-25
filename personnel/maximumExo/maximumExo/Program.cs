// 4 players
List<Player> players = new List<Player>()
{
    new Player("Joe", 32),
    new Player("Jack", 33),
    new Player("William", 37),
    new Player("Averell", 25)
};

// Initialize search
Player elder = players.First();
int biggestAge = elder.Age;

Dictionary<Player, int> keyValuePairs = new Dictionary<Player, int>();

// search
foreach (Player p in players)
{
    if (p.Age > biggestAge) // memorize new elder
    {
        keyValuePairs.Add(p, p.Age);
        //Player oldest = p;
        //int oldestAge = p.Age; // for future loops
    }
}


Console.WriteLine($"Le plus agé est {keyValuePairs.Last().Key.Name} qui a {keyValuePairs.Last().Value} ans");

Console.ReadKey();

public class Player
{
    private readonly string _name;
    private readonly int _age;

    public Player(string name, int age)
    {
        _name = name;
        _age = age;
    }

    public string Name => _name;

    public int Age => _age;
}