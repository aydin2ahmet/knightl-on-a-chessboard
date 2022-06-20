int n = 30;

var startTime = DateTime.Now;
var result = knightlOnAChessboard(n);
Console.WriteLine($"İşlem Süresi = {(DateTime.Now - startTime).TotalMilliseconds}ms");

for(int i = 0; i < n-1; i++)
{
    for(int j = 0; j < n - 1; j++)
        Console.Write($"{result[i][j]}\t");

    Console.WriteLine();
}

List<List<int>> knightlOnAChessboard(int n)
{
    var resultList = new List<List<int>>();

    for (int i = 1; i < n; i++)
    {
        var rowList = new List<int>();

        for (int j = 1; j < n; j++)
        {
            if (i > j)
                rowList.Add(resultList[j - 1][i - 1]);
            else
                rowList.Add(bfs((i, j), n - 1));
        }

        resultList.Add(rowList);
    }

    return resultList;
}

int bfs((int, int) knightL, int reachPoint)
{
    Dictionary<(int, int), bool> traveledPointsDict = new Dictionary<(int, int), bool>();

    Queue<List<(int, int)>> queue = new Queue<List<(int, int)>>();

    if ((knightL.Item1 == reachPoint) && (knightL.Item2 == reachPoint))
        return 1;

    queue.Enqueue(new List<(int, int)>{ (0, 0) } );

    while (queue.Count() > 0)
    {
        var pathList = queue.Dequeue();

        var allSteps = getAllSteps(pathList.Last(), knightL, reachPoint);

        foreach (var i in allSteps)
        {
            if ((i.Item1 == reachPoint) && (i.Item2 == reachPoint))
                return pathList.Count();

            if(traveledPointsDict.ContainsKey((i.Item1,i.Item2)))
                continue;

            traveledPointsDict[(i.Item1, i.Item2)] = true;

            List<(int, int)> addQueue = new List<(int, int)>(pathList);

            addQueue.Add((i.Item1, i.Item2));
            queue.Enqueue(addQueue);
        }
    }

    return -1;
}

List<(int, int)> getAllSteps((int, int) currentPosition, (int, int) knightL, int reachPoint)
{
    var allSteps = new List<(int, int)>();

    if (currentPosition.Item1 + knightL.Item1 <= reachPoint && currentPosition.Item2 + knightL.Item2 <= reachPoint)
        allSteps.Add((knightL.Item1 + currentPosition.Item1, currentPosition.Item2 + knightL.Item2));

    if (knightL.Item1 + currentPosition.Item1 <= reachPoint && currentPosition.Item2 - knightL.Item2 >= 0)
        allSteps.Add((knightL.Item1 + currentPosition.Item1, currentPosition.Item2 - knightL.Item2));

    if (currentPosition.Item1 - knightL.Item1 >= 0 && currentPosition.Item2 + knightL.Item2 <= reachPoint)
        allSteps.Add((currentPosition.Item1 - knightL.Item1, currentPosition.Item2 + knightL.Item2));

    if (currentPosition.Item1 - knightL.Item1 >= 0 && currentPosition.Item2 - knightL.Item2 >= 0)
        allSteps.Add((currentPosition.Item1 - knightL.Item1, currentPosition.Item2 - knightL.Item2));

    if (knightL.Item1 == knightL.Item2)
        return allSteps;

    if (currentPosition.Item2 + knightL.Item2 <= reachPoint && knightL.Item1 + currentPosition.Item1 <= reachPoint)
        allSteps.Add((currentPosition.Item2 + knightL.Item2, knightL.Item1 + currentPosition.Item1));

    if (currentPosition.Item2 + knightL.Item2 <= reachPoint && currentPosition.Item1 - knightL.Item1 >= 0)
        allSteps.Add((currentPosition.Item2 + knightL.Item2, currentPosition.Item1 - knightL.Item1));

    if (currentPosition.Item2 - knightL.Item2 >= 0 && knightL.Item1 + currentPosition.Item1 <= reachPoint)
        allSteps.Add((currentPosition.Item2 - knightL.Item2, knightL.Item1 + currentPosition.Item1));

    if (currentPosition.Item2 - knightL.Item2 >= 0 && currentPosition.Item1 - knightL.Item1 >= 0)
        allSteps.Add((currentPosition.Item2 - knightL.Item2, currentPosition.Item1 - knightL.Item1));

    return allSteps;
}
