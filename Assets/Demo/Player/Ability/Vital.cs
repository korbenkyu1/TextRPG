using UnityEngine;
public class Vital : AbilityData
{
    public int[] valueLV = new int[7]{ 5, 10, 20, 25, 30, 45, 50 };
    public override void OnTurnStart(CombatManager combatManager)
    {
        combatManager.player.stats.maxHealth += valueLV[level-1];
        Debug.Log($"Ȱ�� Ư������ ���� �ִ�ü�� {valueLV[level - 1]} ����");
    }
}
