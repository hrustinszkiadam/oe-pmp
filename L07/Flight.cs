namespace L07;

public enum FlightStatus
{
  Scheduled,
  Delayed,
  Cancelled
}

public class Flight(string flightNumber, string destination, DateTime departureTime, int delay = 0)
{
  private string flightNumber = flightNumber;
  private string destination = destination;
  private DateTime departureTime = departureTime;
  private int delay = delay;
  private FlightStatus status = delay > 0 ? FlightStatus.Delayed : FlightStatus.Scheduled;

  public string FlightNumber { get => flightNumber; }
  public string Destination { get => destination; }
  public DateTime DepartureTime { get => departureTime; }
  public int Delay { get => delay; }
  public FlightStatus Status { get => status; }
  public string AllData
  {
    get
    {
      switch (status)
      {
        case FlightStatus.Scheduled:
          return $"Flight {flightNumber} is on time. (STD {departureTime:yyyy. MM.dd. HH:mm:ss})";
        case FlightStatus.Delayed:
          return $"Flight {flightNumber} is delayed by {delay} minutes. (ETD {departureTime:yyyy. MM.dd. HH:mm:ss})";
        case FlightStatus.Cancelled:
          return $"Flight {flightNumber} is cancelled.";
        default:
          throw new InvalidDataException("Invalid flight status.");
      }
    }
  }

  public DateTime EstimatedDeparture
  {
    get
    {
      if (status == FlightStatus.Cancelled)
      {
        throw new InvalidOperationException("Cannot get estimated departure time for a cancelled flight.");
      }
      return departureTime.AddMinutes(delay);
    }
  }

  public void DelayByMinutes(int minutes)
  {
    delay += minutes;
    UpdateStatus();
  }

  public void Cancel()
  {
    status = FlightStatus.Cancelled;
    UpdateStatus(FlightStatus.Cancelled);
  }

  private void UpdateStatus()
  {
    if(status == FlightStatus.Cancelled) return;
    if(delay > 0) {
      status = FlightStatus.Delayed;
    } else {
      status = FlightStatus.Scheduled;
    }
  }

  private void UpdateStatus(FlightStatus newStatus)
  {
    if(status == FlightStatus.Cancelled) return;
    status = newStatus;
  }
}
