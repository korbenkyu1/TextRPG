using UnityEngine;

public class Field : AbilityData
{
    public int[] valueLV = new int[7]{ 1, 2, 4, 5, 8, 10, 12 };
    public override void OnTurnStart(CombatManager combatManager)
    {
        combatManager.player.statusEffects["fortify"].stack += valueLV[level - 1];
        Debug.Log($"��� Ư������ ���� �÷��̾�� ö�� {valueLV[level - 1]} ���� ȹ��");
    }

}
