namespace MJE.Advent.CubeConundrum;

public class AllowedGamesQuery
{
    private const int redMax = 12;
    private const int greenMax = 13;
    private const int blueMax = 14;

    public static int Calculate(Game[] games)
    {
        Func<List<Subset>, bool> exceedCriteria = list =>
        {
            return list.Any(x => x.Blue > blueMax || x.Green > greenMax | x.Red > redMax);
        };

        var filteredGames = games.ToList();

        filteredGames.RemoveAll(x => exceedCriteria(x.Sets));

        return filteredGames.Sum(x => x.Id);
    }
}