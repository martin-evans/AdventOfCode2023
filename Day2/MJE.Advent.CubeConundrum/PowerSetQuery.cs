namespace MJE.Advent.CubeConundrum;

public class PowerSetQuery
{
    public static int Calculate(Game[] games)
    {
        Func<List<Subset>,int> cubesPowerGame = subSets =>
        {
            var blue = subSets.Max(x => x.Blue);
            var red = subSets.Max(x => x.Red);
            var green = subSets.Max(x => x.Green);

            return blue * red * green;
        };

        return games.Sum(x => cubesPowerGame(x.Sets));
    }
}