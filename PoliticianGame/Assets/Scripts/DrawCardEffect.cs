﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCardEffect : BaseEffect
{
    public override string GetEffectName()
    {
        base.GetEffectName();
        return "Draw Card";
    }

    public override void Apply()
    {
        base.Apply();
        GameObject.Find("GameManager").GetComponent<DeckManager>().DrawCard();
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
