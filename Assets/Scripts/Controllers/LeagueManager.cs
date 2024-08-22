    using System.Collections;
using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;

public class LeagueManager : MonoBehaviour
{
    private List<LeagueTableEntry> standings;
    
    public static LeagueManager Instance { get; private set; }

    public LeagueManager()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            throw new System.Exception("Only one instance of LeagueTableManager is available");
        }

        standings = new List<LeagueTableEntry>();
    }

    public void InitializeStandings()
    {
        standings.Clear();
        foreach (var team in TeamManager.Instance.GetAllTeams())
        {
            standings.Add(new LeagueTableEntry(team));
        }
    }

    public void UpdateStandings(Fixture fixture)
    {
        var homeTeamEntry = standings.FirstOrDefault(entry => entry.Team == fixture.homeTeam);
        var awayTeamEntry = standings.FirstOrDefault(entry => entry.Team == fixture.awayTeam);

        if (homeTeamEntry == null || awayTeamEntry == null)
        {
            Debug.LogError("Team not found in league standings");
            return;
        }

        int homeGoals = fixture.homeScore;
        int awayGoals = fixture.awayScore;

        homeTeamEntry.GoalsFor += homeGoals;
        homeTeamEntry.GoalsAgainst += awayGoals;
        
        awayTeamEntry.GoalsFor += awayGoals;
        awayTeamEntry.GoalsAgainst += homeGoals;

        if (homeGoals > awayGoals)
        {
            homeTeamEntry.Points += 3;
        }
        else if (homeGoals < awayGoals)
        {
            awayTeamEntry.Points += 3;
        }
        else
        {
            homeTeamEntry.Points += 1;
            awayTeamEntry.Points += 1;
        }

        SortStandings();
    }

    private void SortStandings()
    {
        standings = standings.OrderByDescending(entry => entry.Points)
            .ThenByDescending(entry => entry.GoalDifference)
            .ThenByDescending(entry => entry.GoalsFor)
            .ToList();
    }
    
    public List<LeagueTableEntry>GetStandings()
    {
        if (standings.Count < 1)
        {
            InitializeStandings();
        }

        return standings;
    }
    
}
