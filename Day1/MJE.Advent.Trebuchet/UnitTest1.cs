namespace MJE.Advent.Trebuchet;

public class CalibratorTests
{
    [Test]
    public void InitialTestSpec()
    {
        const string calibrationDocument = "1abc2\npqr3stu8vwx\na1b2c3d4e5f\ntreb7uchet";

        Assert.That(Calibrator.CalculateSum(calibrationDocument), Is.EqualTo(142));
    }

    [Test]
    public void PuzzleQuestion()
    {
        Assert.That(Calibrator.CalculateSum(PuzzleInput.CalibarationDocument), Is.EqualTo(54605));
    }
    
    [Test]
    public void Puzzle2Question()
    {
        var ret = Calibrator.CalculateSecondarySum(PuzzleInput.CalibarationDocument);

        Console.WriteLine(ret);
        
    }


    [Test]
    public void SecondaryTestSpec()
    {
        const string calibrationDocument =
            "two1nine\neightwothree\nabcone2threexyz\nxtwone3four\n4nineeightseven2\nzoneight234\n7pqrstsixteen";
        
        var r = Calibrator.CalculateSecondarySum(calibrationDocument);
        
        Assert.That(r, Is.EqualTo(281));
    }
    
}