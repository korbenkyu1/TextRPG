using UnityEngine;
[CreateAssetMenu(menuName = "Data/Ability/Rage")]
public class Rage : AbilityData
{
    public int[] valueLV = new int[7]{ 1, 2, 4, 5, 6, 8, 10 };
    public override void OnTurnStart(CombatManager combatManager)
    {
        combatManager.player.stats.attack += valueLV[level-1];
        Debug.Log($"�г� Ư������ ���� �÷��̾��� ���ݷ� {valueLV[level - 1]} ���");
    }
}
