using static Lab_01.zad3;
using System.Text.Json;
using Lab_01;

//FizzBuzz(100);

string name;
int trials = (new zad4(100)).run();
Console.WriteLine("Podaj imie: ");
name = Console.ReadLine();
var hs = new HighScore { Name = name, Trials = trials };


List<HighScore> highScores;

const string FileName = "highscores.json";
if (File.Exists(FileName))
    highScores = JsonSerializer.Deserialize<List<HighScore>>(File.ReadAllText(FileName));
else
    highScores = new List<HighScore>();

highScores.Add(hs);

List<HighScore> sorted = highScores.OrderBy(h => h.Trials).ToList();
File.WriteAllText(FileName, JsonSerializer.Serialize(sorted));


foreach (var item in sorted)
{
    Console.WriteLine($"{item.Name} -- {item.Trials} prób");
}
