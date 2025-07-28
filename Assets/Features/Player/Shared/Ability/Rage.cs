using UnityEngine;
[CreateAssetMenu(menuName = "Data/Ability/Rage")]
public class Rage : AbilityData
{
    public int[] valueLV = new int[7]{ 1, 2, 4, 5, 6, 8, 10 };
    public bool isAssigned = false;
    public override void OnTurnStart(CombatManager combatManager)
    {
        combatManager.player.stats.attack += valueLV[level-1];
        if(!isAssigned)
        {
            combatManager.Log($"분노로 플레이어의 공격력이 {valueLV[level - 1]} 증가되었다!");
            isAssigned = true;
        }
    }
}
