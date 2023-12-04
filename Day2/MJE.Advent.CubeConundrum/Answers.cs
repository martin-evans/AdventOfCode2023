namespace MJE.Advent.CubeConundrum;

public class Answers
{
    [Test]
    public void AnswerOne()
    {
        var games = InputParser.Generate(PuzzleInput.Input);
        Console.WriteLine(GameFilter.AllowedGames(games));
    }
    
}