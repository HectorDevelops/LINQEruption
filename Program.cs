List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46, "Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};

// Helper method to print each item in a List or IEnumerable. This should remain at the bottom of your class!
static void PrintEach(IEnumerable<Eruption> items, string msg = "")
{
    Console.WriteLine("\n" + msg);
    foreach (Eruption item in items)
    {
        Console.WriteLine(item.ToString());
    }
}

Console.WriteLine("Display first eruption in Chile:");
Eruption? selectFirstChile = eruptions.FirstOrDefault(info => info.Location == "Chile");
Console.WriteLine(selectFirstChile);


Console.WriteLine("Display first eruption in Hawaiian Is:");
Eruption? firstHawaii = eruptions.FirstOrDefault(eLocation => eLocation.Location == "Hawaiian Is");
if (firstHawaii != null)
{
    Console.WriteLine(firstHawaii);
}
else
{
    Console.WriteLine("No Hawaiian Is Eruption found.");
}

Eruption? firstGreenland = eruptions.FirstOrDefault(eLocation => eLocation.Location == "Greenland");
Console.WriteLine("Display first eruption in Greenland:");
if (firstGreenland != null)
{
    Console.WriteLine(firstGreenland);
}
else
{
    Console.WriteLine("No Greenland Eruption found.");
}


Eruption? filteredEruption = eruptions.FirstOrDefault(info => info.Year > 1900 && info.Location == "New Zealand");
Console.WriteLine("Display first eruption after 1900 that also happened in New Zealand:");
if (filteredEruption != null)
{
    Console.WriteLine(filteredEruption);
}


Console.WriteLine("Locations with volcano's elevation over 2000m: ");
List<Eruption> twoKMeters = eruptions.Where(elevationInMeter => elevationInMeter.ElevationInMeters > 2000).ToList();
PrintEach(twoKMeters);


List<Eruption> filteredVolcanoss = eruptions.Where(letter => letter.Volcano.StartsWith("L")).ToList();
Console.WriteLine("Locations with volcanos that start with the letter L: ");
Console.WriteLine(String.Join(", ", filteredVolcanoss));
Console.WriteLine($"Total numbers of eruptions: {filteredVolcanoss.Count()}");


Console.WriteLine(" Find highest elevation amongst the volcanos: ");
int highestElevation = eruptions.Max(highest => highest.ElevationInMeters);
Console.WriteLine(highestElevation);

Console.WriteLine(" Name of highest volcano: ");
Eruption? highestVolcano = eruptions.FirstOrDefault(elevation => elevation.ElevationInMeters == highestElevation);
Console.WriteLine(highestVolcano?.Volcano);


Console.WriteLine("Print all Volcano names alphabetically:");
List<Eruption> orderAlphabetically = eruptions.OrderBy(name => name.Volcano).ToList();
foreach (Eruption eruption in orderAlphabetically)
{
    Console.WriteLine(eruption.Volcano);
}

Console.WriteLine("Print the sum of all elevations of the volcano combined:");
List<Eruption> elevationTotals = eruptions.OrderBy(elevation => elevation.ElevationInMeters).ToList();

int elevation = eruptions.Sum(eruption => eruption.ElevationInMeters);
Console.WriteLine(elevation);

Console.WriteLine("Print whether any volcanos erupted in the year 2000:");
bool isEruptionAfterTwoK = eruptions.Any(volcano => volcano.Year > 2000);
Console.WriteLine(isEruptionAfterTwoK);


Console.WriteLine("Find all stratovolcanoes and print just the first three: ");
List<Eruption> stratovolcanoes = eruptions.Where(type => type.Type == "Stratovolcano").Take(3).ToList();

foreach (Eruption volcano in stratovolcanoes)
{
    Console.WriteLine(volcano.Volcano);
}

Console.WriteLine("Print all the eruptions that happened before the year 1000 CE alphabetically according to Volcano name.");
List<Eruption> listOfEruptions = eruptions.Where(year => year.Year < 1000).ToList();

foreach (Eruption item in listOfEruptions)
{
    Console.WriteLine(item);
}

Console.WriteLine("Redo the last query, but this time use LINQ to only select the volcano's name so that only the names are printed.");
List<Eruption> listOfEruptionsNames = eruptions.Where(year => year.Year < 1000).OrderBy(name => name.Volcano).ToList();

foreach (Eruption item in listOfEruptionsNames)
{
    Console.WriteLine(item.Volcano);
}