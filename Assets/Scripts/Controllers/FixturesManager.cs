using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixturesManager : MonoBehaviour
{
    public static FixturesManager Instance;
    
    public List<MatchWeek> MatchWeeks = new List<MatchWeek>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        MatchWeeks = FixtureGenerator.GenerateFixtures(TeamManager.Instance.GetAllTeams());
    }
}
