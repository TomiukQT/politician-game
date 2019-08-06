using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Card : ScriptableObject
{
    private const int minRep = -3;
    private const int maxRep = 3;

    public string cardName;
    public string description;

    public Sprite image;

    public float cost = 0;


    //Stats
    [Space]
    [Range(minRep, maxRep)]
    public int youngs;
    [Range(minRep, maxRep)]
    public int adults;
    [Range(minRep, maxRep)]
    public int pensioners;


    [Space]
    [Range(minRep, maxRep)]
    public int elementary;
    [Range(minRep, maxRep)]
    public int highSchool;
    [Range(minRep, maxRep)]
    public int university;

    [Space]
    [Range(minRep, maxRep)]
    public int christians;
    [Range(minRep, maxRep)]
    public int jews;
    [Range(minRep, maxRep)]
    public int muslims;
    [Range(minRep, maxRep)]
    public int other;
    [Range(minRep, maxRep)]
    public int atheists;

    [Space]
    [Range(minRep, maxRep)]
    public int city;
    [Range(minRep, maxRep)]
    public int village;

    [Space]
    [Range(minRep, maxRep)]
    public int locals;
    [Range(minRep, maxRep)]
    public int foreigners;


    public Dictionary<string, int> GetBonuses()
    {
        Dictionary<string, int> bonuses = new Dictionary<string, int>();

        if (youngs != 0)
            bonuses.Add("Youngs", youngs);
        if (adults != 0)
            bonuses.Add("Adults", adults);
        if (pensioners != 0)
            bonuses.Add("Pensioners", pensioners);

        if (elementary != 0)
            bonuses.Add("Elementary", elementary);
        if (highSchool != 0)
            bonuses.Add("HighSchool", highSchool);
        if (university != 0)
            bonuses.Add("University", university);

        if (christians != 0)
            bonuses.Add("Christians", christians);
        if (jews != 0)
            bonuses.Add("Jews", jews);
        if (muslims != 0)
            bonuses.Add("Muslims", muslims);
        if (other != 0)
            bonuses.Add("Other", other);
        if (atheists != 0)
            bonuses.Add("Atheists", atheists);

        if (city != 0)
            bonuses.Add("City", city);
        if (village != 0)
            bonuses.Add("Village", village);

        if (locals != 0)
            bonuses.Add("Locals", locals);
        if (foreigners != 0)
            bonuses.Add("Foreigners", foreigners);

        return bonuses;
    }

}
