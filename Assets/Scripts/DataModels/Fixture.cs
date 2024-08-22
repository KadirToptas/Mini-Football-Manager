[System.Serializable]

public class Fixture
{
    public Team homeTeam;
    public Team awayTeam;
    public int homeScore;
    public int awayScore;

    public Fixture(Team home, Team away)
    {
        homeTeam = home;
        awayTeam = away;
        homeScore = 0;
        awayScore = 0; 
    }
}