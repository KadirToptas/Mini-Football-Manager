using System.Collections.Generic;


public class MatchWeek
{
    public List<Fixture> fixtures;
    public int weekNumber;


    public MatchWeek(int number)
    {
        weekNumber = number;
        fixtures = new List<Fixture>(); 
    }

    public void AddFixture(Fixture fixture)
    {
        fixtures.Add(fixture);
    }

}
