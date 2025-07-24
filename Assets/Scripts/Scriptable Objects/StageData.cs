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
    [Header("Item Weights [common, uncommon, rare, epic, legandary, mythical]")]
    public float[] itemWeights = new float[6];
    [Header("Food Weights [common, uncommon, rare, epic, legandary, mythical]")] 
    public float[] foodWeights = new float[6];
    public Sprite backgound;
}
