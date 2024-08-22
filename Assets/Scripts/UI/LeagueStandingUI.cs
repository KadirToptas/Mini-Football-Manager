using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeagueStandingUI : MonoBehaviour
{
    public TextMeshProUGUI Standing, TeamName, Points;

    public void SetLeagueStandingText(LeagueTableEntry entry, int standing )
    {
        Standing.text = standing.ToString();
        TeamName.text = entry.Team.teamName;
        Points.text = entry.Points.ToString();

    }

}
