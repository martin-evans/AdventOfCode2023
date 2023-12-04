namespace MJE.Advent.CubeConundrum;

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