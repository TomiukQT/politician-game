using UnityEngine;
using UnityEditor;

public class CardAsset
{
    [MenuItem("Assets/Create/Card")]
    public static void CreateAsset()
    {
        ScriptableObjectUtility.CreateAsset<Card>();
    }
}