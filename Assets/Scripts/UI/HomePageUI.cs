    using System;
    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomePageUI : UIPage
{
    public static HomePageUI Instance { get; private set; }

    [SerializeField] private Transform fixtureContainer;
    [SerializeField] private GameObject resultPrefab;

    
    [SerializeField] private Transform leagueStandingContainer;
    [SerializeField] private GameObject leagueStandingPrefab;
    public void Awake()
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

    protected override void OnShow()
    {
        ClearFixtures();

        foreach (Fixture f in FixturesManager.Instance.MatchWeeks[0].fixtures)
        {
            var obj = Instantiate(resultPrefab, fixtureContainer);
            obj.GetComponent<FixtureUI>().SetFixtureText(f);
        }

        int leagueStandingIndex = 1;

        var standings = LeagueManager.Instance.GetStandings();
        foreach (LeagueTableEntry l in standings)
        {
            var obj = Instantiate(leagueStandingPrefab, leagueStandingContainer);
            obj.GetComponent<LeagueStandingUI>().SetLeagueStandingText(l , leagueStandingIndex);
            leagueStandingIndex++;
        }
    }

    private void ClearFixtures()
    {
        foreach (Transform t in fixtureContainer)
        {
            Destroy(t.gameObject);
        }
    }

}