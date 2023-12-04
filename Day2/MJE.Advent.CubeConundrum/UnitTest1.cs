namespace MJE.Advent.CubeConundrum;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ModelGame()
    {
        var game = new Game(){ Id=1, Sets = new List<Subset>(){ new Subset {Blue = 3, Red = 1, Green = 4}}};
        Assert.NotNull(game);
    }

    [Test]
    public void InputParserTests()
    {
        var puzzleInput =
            "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green\nGame 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue\nGame 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red\nGame 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red\nGame 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green";

        Game[] games = InputParser.Generate(puzzleInput);
        
        Assert.That(games.Length, Is.EqualTo(5));

        var g = games.Single(x => x.Id == 5);
        
        Assert.That(g.Sets[0].Blue, Is.EqualTo(1));


    }
}

public static class InputParser
{
    public static Game[] Generate(string puzzleInput)
    {

        var ret = new List<Game>();
        
        var gameLines = puzzleInput.Split("\n", StringSplitOptions.RemoveEmptyEntries);

        foreach (var gameLine in gameLines)
        {
            var game = new Game();

            var id = gameLine.Split(new[] { " ",":" }, StringSplitOptions.RemoveEmptyEntries)[1];
            game.Id = int.Parse(id);
            
            var subsetLines = gameLine.Split(new[] { ":", ";" }, StringSplitOptions.RemoveEmptyEntries).Skip(1);

            foreach (var subsetLine in subsetLines)
            {
                var subset = new Subset();
                
                var colourVals = subsetLine.Split(",", StringSplitOptions.RemoveEmptyEntries);

                foreach (var colourVal in colourVals)
                {
                    subset.Blue = ProcessColourValues(colourVal, "blue") ?? subset.Blue;
                    subset.Red = ProcessColourValues(colourVal, "red") ?? subset.Red;
                    subset.Green = ProcessColourValues(colourVal, "green") ?? subset.Green;
                }
                
                game.Sets.Add(subset);
            }
            
            ret.Add(game);
            continue;

            int? ProcessColourValues(string colourAndValue, string colourName) => colourAndValue.Contains(colourName) ? int.Parse(colourAndValue.Replace(colourName, string.Empty).Trim()) : null;
        }

        return ret.ToArray();
    }
    
}

public class Subset
{
    public int Blue { get; set; }
    public int Red { get; set; }
    public int Green { get; set; }
}

public class Game
{
    public int Id { get; set; }
    public List<Subset> Sets { get; set; } = new();
}