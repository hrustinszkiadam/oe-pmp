namespace L07;

public static class GroundControl
{
  private static readonly List<Flight> flights = new();

  public static void AddFlight(Flight flight)
  {
    flights.Add(flight);
  }

  public static void AverageDelay()
  {
    if (flights.Count == 0)
    {
      Console.WriteLine("No flights available.");
      return;
    }

    int totalDelay = 0, delayedFlightsCount = 0;
    foreach (Flight flight in flights)
    {
      if (flight.Status == FlightStatus.Delayed)
      {
        totalDelay += flight.Delay;
        delayedFlightsCount++;
      }
    }

    double averageDelay = delayedFlightsCount > 0 ? (double)totalDelay / delayedFlightsCount : 0;
    Console.WriteLine($"Average delay is {averageDelay:F0} minutes.");
  }

  public static void DisplayFlightData()
  {
    if (flights.Count == 0)
    {
      Console.WriteLine("No flights available.");
      return;
    }

    foreach (Flight flight in flights)
    {
      Console.WriteLine(flight.AllData);
    }
  }
}
