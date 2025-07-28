using UnityEngine;
[CreateAssetMenu(menuName = "Data/Ability/Vital")]
public class Vital : AbilityData
{
    public int[] valueLV = new int[7]{ 5, 10, 20, 25, 30, 45, 50 };
    public bool isAssigned = false;
    public override void OnTurnStart(CombatManager combatManager)
    {
        combatManager.player.stats.maxHealth += valueLV[level-1];
        if(!isAssigned)
        {
            combatManager.Log($"활력으로 최대체력이 {valueLV[level - 1]} 증가되었다!");
            isAssigned = true;
        }
    }
}
