using System;
using UnityEngine;

public class FixtureListUI : UIPage
{
    public static FixtureListUI Instance { get; private set; }

    private int weekFocus = 0;

    [SerializeField] private Transform fixtureContainer;
    [SerializeField] private GameObject resultPrefab;
    
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

    public void ChangeWeekFocus(int amount)
    {
        weekFocus = weekFocus + amount < 0 ? 0 :
            weekFocus + amount > FixturesManager.Instance.MatchWeeks.Count - 1 ? weekFocus : weekFocus + amount;

        SetupFixturesPanel();
    }

    protected override void OnShow()
    {
        SetupFixturesPanel();
    }

    private void SetupFixturesPanel()
    {
        ClearFixtures();

        foreach (Fixture f in FixturesManager.Instance.MatchWeeks[weekFocus].fixtures)
        {
            var obj = Instantiate(resultPrefab, fixtureContainer);
            obj.GetComponent<FixtureUI>().SetFixtureText(f);
        }
    }
}