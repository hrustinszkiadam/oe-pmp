using System;

namespace ZH02M;

internal class FleetHandler
{
  private List<Spaceship> fleet;
  private DateTime currentDate;

  public FleetHandler(string fileName)
  {
    string[] shipStrings = File.ReadAllLines(fileName);

    this.fleet = new List<Spaceship>();
    this.currentDate = DateTime.Parse(shipStrings[0]);
    
    for (int i = 1; i < shipStrings.Length; i++)
    {
      this.fleet.Add(new Spaceship(shipStrings[i]));
    }
  }

  public int TotalShipCount { get => fleet.Count; }
  public bool HasAnyDeceasedCrew
  {
    get
    {
      foreach (Spaceship ship in fleet)
      {
        if (ship.CrewStatus == CrewStatusType.Deceased)
        {
          return true;
        }
      }
      return false;
    }
  }

  public double AverageCargo(ShipClassType shipClass)
  {
    int totalCargo = 0;
    int shipCount = 0;

    foreach (Spaceship ship in fleet)
    {
      if (ship.ShipClass == shipClass)
      {
        totalCargo += ship.WeightInTons;
        shipCount++;
      }
    }

    return shipCount > 0 ? (double)totalCargo / shipCount : 0;
  }

  public Spaceship[] GetShipsGroupByRisk()
  {
    Spaceship[] result = new Spaceship[fleet.Count];
    int front = 0;
    int back = fleet.Count - 1;

    foreach (Spaceship ship in fleet)
    {
      if (
        (ship.ShipClass == ShipClassType.Cargo || 
        ship.ShipClass == ShipClassType.Research)
        && ship.NeedsRescue(currentDate)
      )
      {
        result[front++] = ship;
      }
      else
      {
        result[back--] = ship;
      }
    }

    return result;
  }

  public string GetLargestCrewData(CrewStatusType status)
  {
    Spaceship? largestShip = null;
    int largestCrew = 0;

    foreach (Spaceship ship in fleet)
    {
      if (ship.CrewStatus == status && ship.CrewCount > largestCrew)
      {
        largestCrew = ship.CrewCount;
        largestShip = ship;
      }
    }

    return largestShip != null ? $"{largestShip.GetStatusReport(this.currentDate)}" : "";
  }

  public void GenerateReport(string fileName)
  {
    using (StreamWriter writer = new StreamWriter(fileName))
    {
      writer.WriteLine($"Current Date is {this.currentDate:yyyy.\tMM.\tdd.\tHH:mm:ss.}");

      writer.WriteLine($"Total ship count is {this.TotalShipCount}.");

      writer.WriteLine("Average cargo by ship types:");
      foreach (ShipClassType shipClass in Enum.GetValues(typeof(ShipClassType)))
      {
        double averageCargo = this.AverageCargo(shipClass);
        writer.WriteLine($"\t{shipClass}:\t{averageCargo}");
      }

      writer.WriteLine("Detailed info sorted by risk:");
      Spaceship[] shipsByRisk = this.GetShipsGroupByRisk();
      foreach (Spaceship ship in shipsByRisk)
      {
        writer.WriteLine(ship.GetStatusReport(this.currentDate));
      }
    }
  }
}
