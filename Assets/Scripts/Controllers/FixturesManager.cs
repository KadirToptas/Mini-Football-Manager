using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixturesManager : MonoBehaviour
{
    public List<MatchWeek> MatchWeeks = new List<MatchWeek>();
    
    void Start()
    {
        MatchWeeks = FixtureGenerator.GenerateFixtures(TeamManager.Instance.GetAllTeams());
    }
}
