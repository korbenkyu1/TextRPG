using UnityEngine;

[System.Serializable]
public class RandomStage
{
    public float weight;
    public StageData stage;
}

[CreateAssetMenu(menuName = "Data/Act")]
public class ActData : ScriptableObject
{
    public Sprite backgound;
    public StageData[] fixedStages = new StageData[12];
    public RandomStage[] randomStages;
    [Header("Item Weights [common, uncommon, rare, epic, legandary, mythical]")]
    public float[] itemWeights = new float[6];
    [Header("Food Weights [common, uncommon, rare, epic, legandary, mythical]")] 
    public float[] foodWeights = new float[6];
}
