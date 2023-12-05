namespace MJE.Advent.CubeConundrum;

public class Answers
{
    [Test]
    public void AnswerOne()
    {
        var games = InputParser.Generate(PuzzleInput.Input);
        Console.WriteLine(AllowedGamesQuery.Calculate(games));
    }
    
    
    [Test]
    public void AnswerTwo()
    {
        var games = InputParser.Generate(PuzzleInput.Input);
        Console.WriteLine(PowerSetQuery.Calculate(games));
    }
    
}