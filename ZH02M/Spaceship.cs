using System;

namespace ZH02M;

internal class Spaceship
{
  private string name;
  private ShipClassType shipClass;
  private int crewCount;
  private CrewStatusType crewStatus;
  private int weightInTons;
  private DateTime lastMessageFromShip;

  public Spaceship(string shipString)
  {
    string[] shipData = shipString.Split(';');
    this.name = shipData[0];
    this.shipClass = (ShipClassType)Enum.Parse(typeof(ShipClassType), shipData[1]);
    this.crewCount = int.Parse(shipData[2]);
    this.crewStatus = (CrewStatusType)Enum.Parse(typeof(CrewStatusType), shipData[3]);
    this.weightInTons = int.Parse(shipData[4]);
    this.lastMessageFromShip = DateTime.Parse(shipData[5]);
  }

  public string Name { get => name; }
  public int CrewCount { get => crewCount; }
  public int WeightInTons { get => weightInTons; }
  internal ShipClassType ShipClass { get => shipClass; }
  internal CrewStatusType CrewStatus { get => crewStatus; }
  public DateTime LastMessageFromShip { get => lastMessageFromShip; }

  private int DaysSinceLastMessage(DateTime date)
  {
    return (int)date.Subtract(lastMessageFromShip).TotalDays;
  }

  public bool NeedsRescue(DateTime date)
  {
    switch (crewStatus)
    {
      case CrewStatusType.Active:
        return DaysSinceLastMessage(date) > 30;
      case CrewStatusType.InCryosleep:
        return DaysSinceLastMessage(date) > 3650;
      case CrewStatusType.MissingInAction:
      case CrewStatusType.Deceased:
        return true;
      default:
        throw new ArgumentOutOfRangeException();
    }
  }

  public override string ToString()
  {
    return $"{name} ({shipClass})";
  }

  public string GetStatusReport(DateTime date)
  {
    string statusReport = $"=== {this} ===\n";
    statusReport += $"\tCrew:\t{crewCount} ({crewStatus})\n";
    statusReport += $"\tLast message:\t{DaysSinceLastMessage(date)} days\n";
    statusReport += $"\tRescue needed:\t{(NeedsRescue(date) ? "Yes" : "No")}";
    return statusReport;
  }
}
