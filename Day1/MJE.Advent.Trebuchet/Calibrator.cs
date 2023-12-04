namespace MJE.Advent.Trebuchet;

public static class Calibrator
{
    private static int ParseResultFromNumericFigures(string s)
    {
        var res = s.Where(c => int.TryParse(c.ToString(), out _)).ToArray();
        var op = string.Concat(new[] { res[0], res[^1] });
        return int.Parse(op);
    }

    public static int CalculateSum(string calibrationDocument, Func<string, int>? numberParser = null)
    {
        numberParser ??= ParseResultFromNumericFigures;

        var ret = calibrationDocument.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            
        var s = ret.Select(numericVal => numberParser(numericVal)).ToList();

        return s.Sum();

    }

    public static int CalculateSecondarySum(string calibrationDocument)
    {
        return CalculateSum(calibrationDocument, ParseResultFromNumericFiguresAndText);
    }

    private static int ParseResultFromNumericFiguresAndText(string s)
    {
        var replacedValues = ReplaceNumericTextWithNumbers(s);

        var res = replacedValues.Where(c => int.TryParse(c.ToString(), out _)).ToArray();
        var op = string.Concat(new[] { res[0], res[^1] });
        
        return int.Parse(op);
    }


    private static Dictionary<string, string> crit = new()
    {
        ["one"] = "1",
        ["two"] = "2",
        ["three"] = "3",
        ["four"] = "4",
        ["five"] = "5",
        ["six"] = "6",
        ["seven"] = "7",
        ["eight"] = "8",
        ["nine"] = "9",
        ["1"] = "1",
        ["2"] = "2",
        ["3"] = "3",
        ["4"] = "4",
        ["5"] = "5",
        ["6"] = "6",
        ["7"] = "7",
        ["8"] = "8",
        ["9"] = "9"
    };
    
    
    private static string ReplaceNumericTextWithNumbers(string s)
    {
        // start from the beginning, looking for the 1st match

        var leftString = LeftString(s);
        var rightString = RightString(s);

        return $"{leftString}{rightString}";
    }

    private static string LeftString(string s)
    {
        for (var i = 0; i <= s.Length; i++)
        {
            var val = s[..(i + 1)];

            var matchedKey = crit.Keys.FirstOrDefault(val.Contains);
            if (matchedKey != null)
            {
                return crit[matchedKey];
            }
        }

        return string.Empty;
    }

    private static string RightString(string s)
    {
        for (var i = s.Length - 1; i >= 0; i--)
        {
            var val = s[i..];

            var matchedKey = crit.Keys.FirstOrDefault(val.Contains);
            if (matchedKey != null)
            {
                return crit[matchedKey];
            }
        }

        return string.Empty;
    }
}