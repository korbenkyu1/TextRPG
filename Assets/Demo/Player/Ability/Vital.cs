using UnityEngine;
public class Vital : AbilityData
{
    public int[] valueLV = new int[7]{ 5, 10, 20, 25, 30, 45, 50 };
    public override void OnTurnStart(CombatManager combatManager)
    {
        combatManager.player.stats.maxHealth += valueLV[level-1];
        Debug.Log($"활력 특성으로 인해 최대체력 {valueLV[level - 1]} 증가");
    }
}
