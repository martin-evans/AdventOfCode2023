namespace MJE.Advent.CubeConundrum;

public class GameTests
{
    [Test]
    public void ModelGame()
    {
        var game = new Game() { Id = 1, Sets = new List<Subset>() { new Subset { Blue = 3, Red = 1, Green = 4 } } };
        Assert.NotNull(game);
    }
    
    public const string puzzleInput =
        "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green\nGame 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue\nGame 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red\nGame 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red\nGame 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green";
    
    [Test]
    public void InputParserTests()
    {
        var games = InputParser.Generate(puzzleInput);

        Assert.That(games.Length, Is.EqualTo(5));

        var g = games.Single(x => x.Id == 5);

        Assert.That(g.Sets[0].Blue, Is.EqualTo(1));
    }

    [Test]
    public void GameQueryTests()
    {
        var games = InputParser.Generate(puzzleInput);
        Console.WriteLine(GameFilter.AllowedGames(games));
    }
}