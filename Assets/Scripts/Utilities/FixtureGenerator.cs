using System;
using System.Collections;
using System.Collections.Generic;

public static class FixtureGenerator
{
  public static List<MatchWeek> GenerateFixtures(List<Team> teams)
  {
    if (teams==null || teams.Count <2)
    {
      throw new ArgumentException("Insufficient number of teams");
    }

    List<MatchWeek> matchWeeks = new List<MatchWeek>();
    int totalTeams = teams.Count;

    if (totalTeams % 2 != 0)
    {
      throw new InvalidOperationException("Number of teams must be even");
    }

    int totalWeeks = totalTeams - 1;
    int matchWeeksCount = totalTeams * 2;

    for (int week = 0; week < matchWeeksCount; week++)
    {
      MatchWeek matchWeek = new MatchWeek(week + 1);
      for (int i = 0; i < totalTeams / 2; i++)
      {
        int homeIndex = (i + week) % totalTeams;
        int awayIndex = (totalTeams - i - 1 + week) % totalTeams;

        if (homeIndex != awayIndex)
        {
          matchWeek.AddFixture(new Fixture(teams[homeIndex], teams[awayIndex], matchWeek));
        }
      }
      matchWeeks.Add(matchWeek);
    }

    return matchWeeks;
  }
}
