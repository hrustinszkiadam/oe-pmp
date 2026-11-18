namespace ZH02M;

enum ShipClassType 
{
    Cargo,
    Military,
    Research,
    Mining,
    Colonial,
    Rescue
}

enum CrewStatusType 
{
    Active = 1,
    InCryosleep = 2,
    MissingInAction = 3,
    Deceased = 4
}

class Program
{
    static void Main(string[] args)
    {
        FleetHandler fleet = new FleetHandler("../../../assets/weyland-yutani.csv");
        fleet.GenerateReport("../../../fleet_report.txt");
    }
}
