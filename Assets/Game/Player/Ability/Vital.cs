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
            combatManager.Log($"Ȱ������ �ִ�ü���� {valueLV[level - 1]} �����Ǿ���!");
            isAssigned = true;
        }
    }
}
