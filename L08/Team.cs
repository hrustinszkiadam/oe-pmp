using System;

namespace L08;

public class Team
{
  Player[] players = new Player[5];

  public int NumberOfPlayers
  {
    get;
    private set;
  }

  public bool IsFull
  {
    get => NumberOfPlayers == 5;
  }

  public bool IsIncluded(Player player)
  {
    for (int i = 0; i < NumberOfPlayers; i++)
    {
      if (players[i] == player)
      {
        return true;
      }
    }
    return false;
  }

  public bool IsAvailable(Player player)
  {
    int limit = player.Position == Position.Winger ? 2 : 1;
    int samePosition = 0;
    for (int i = 0; i < NumberOfPlayers; i++)
    {
      if (players[i].Position == player.Position)
      {
        samePosition++;
      }
    }
    return samePosition < limit;
  }

  public void Include(Player player)
  {
    if (IsFull)
    {
      throw new Exception("Team is full");
    }
    if (IsIncluded(player))
    {
      throw new Exception("Player is already included");
    }
    if (!IsAvailable(player))
    {
      throw new Exception("Player is not available");
    }

    players[NumberOfPlayers] = player;
    NumberOfPlayers++;
  }

  public override string ToString()
  {
    string result = "";
    for (int i = 0; i < NumberOfPlayers; i++)
    {
      result += players[i] + Environment.NewLine;
    }
    return result;
  }
}
