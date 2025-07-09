using UnityEngine;

[System.Serializable]
public class RandomAct
{
    public float weight;
    public ActData act;
}

[CreateAssetMenu(menuName = "Data/Stage")]
public class StageData : ScriptableObject
{
    public ActData[] fixedActs = new ActData[12];
    public RandomAct[] randomActs;
    public int commonFoodWeight, uncommonFoodWeight, rareFoodWeight, epicFoodWeight, legendaryFoodWeight, mythicalFoodWeight;
}
