#pragma warning disable CA1416
Console.Title = "Defense of Consolas";
string none = "none";
int targetRow;
int targetCol;
bool keepDeploying;

do
{
    keepDeploying = false;
    Console.WriteLine("Target row?");
    targetRow = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Target column?");
    targetCol = Convert.ToInt32(Console.ReadLine());

    Tuple<int, int> topCoordinate = CalculateCoordinate(targetRow, targetCol, 1);
    Tuple<int, int> rightCoordinate = CalculateCoordinate(targetRow, targetCol, 2);
    Tuple<int, int> bottomCoordinate = CalculateCoordinate(targetRow, targetCol, 3);
    Tuple<int, int> leftCoordinate = CalculateCoordinate(targetRow, targetCol, 4);

    Console.WriteLine("Deploy to: ");
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine($"{(topCoordinate.Item1 != 0 ? topCoordinate : none)}");
    Console.WriteLine($"{(rightCoordinate.Item1 != 0 ? rightCoordinate : none)}");
    Console.WriteLine($"{(bottomCoordinate.Item1 != 0 ? bottomCoordinate : none)}");
    Console.WriteLine($"{(leftCoordinate.Item1 != 0 ? leftCoordinate : none)}");
    Console.Beep();
    Console.ForegroundColor = ConsoleColor.White;

    Console.WriteLine("Do you want to deploy a new turret?");
    Console.WriteLine("1.- Yes");
    Console.WriteLine("2.- No");
    var answer = Convert.ToInt32(Console.ReadLine());
    if (answer == 1)
        keepDeploying = true;

} while (keepDeploying);
Console.WriteLine($"Shutting down {Console.Title} defense system. Keep safe.");

static Tuple<int, int> CalculateCoordinate(int targetRow, int targetCol, int position)
{
    int deployRow = 0, deployCol = 0;
    switch (position) {
        case 1:
            deployRow = targetRow + 1;
            deployCol = targetCol;
            break;
        case 2:
            deployRow = targetRow;
            deployCol = targetCol + 1;
            break;
        case 3:
            deployRow = targetRow - 1;
            deployCol = targetCol;
            break;
        case 4:
            deployRow = targetRow;
            deployCol = targetCol - 1;
            break;
    }

    if (deployRow > 8 || deployCol > 8 || deployRow == 0 || deployCol == 0)
    {
        deployRow = 0;
        deployCol = 0;
    }

    return Tuple.Create(deployRow, deployCol);
}
#pragma warning restore CA1416
