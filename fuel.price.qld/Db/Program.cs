using DbUp.Engine;
using DbUp;
using System.Reflection;

int result;

string connectionString =
    args.FirstOrDefault()
    ?? "Server=APSTTWX180\\LOCALHOST;Database=qld_fuel_price_v1;User ID=dbup;Password=dbup";

UpgradeEngine upgrader = DeployChanges.To
    .SqlDatabase(connectionString)
    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
    .LogToConsole()
    .Build();

DatabaseUpgradeResult dbUpgradeResult = upgrader.PerformUpgrade();

if (!dbUpgradeResult.Successful)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(dbUpgradeResult.Error);
    Console.ResetColor();
#if DEBUG
    Console.ReadLine();
#endif
    result = -1;
}
else
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Success!");
    Console.ResetColor();

    result = 0;
}

return result;
