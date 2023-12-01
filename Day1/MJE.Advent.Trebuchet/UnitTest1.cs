namespace MJE.Advent.Trebuchet;

public class CalibratorTests
{
    [Test]
    public void Test1()
    {
        const string calibrationDocument = "1abc2\npqr3stu8vwx\na1b2c3d4e5f\ntreb7uchet";

        Assert.That(Calibrator.CalculateSum(calibrationDocument), Is.EqualTo(142));
    }
    
    
    [Test]
    public void PuzzleQuestion()
    {
        Console.WriteLine(Calibrator.CalculateSum(PuzzleInput.CalibarationDocument));
    }
    
    
}

public static class Calibrator
{
    public static int CalculateSum(string calibrationDocument)
    {
  
        var ret = calibrationDocument.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries)
            .Select(x =>
            {
                var res = x.Where(c => int.TryParse(c.ToString(), out _)).ToArray();
                var op = string.Concat(new[] { res[0], res[^1] }); ;
                return int.Parse(op);
            });

        return ret.Sum();
    }
}