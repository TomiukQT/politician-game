using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscardCardEffect : BaseEffect
{
    public override string GetEffectName()
    {
        return "Discard Random Card";
    }

    public override void Apply()
    {
        Transform hand = GameObject.Find("Hand").transform;
        int random = Random.Range(0, hand.childCount);
        Destroy(hand.GetChild(random));
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
