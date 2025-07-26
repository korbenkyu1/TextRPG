using UnityEngine;
[CreateAssetMenu(menuName = "Data/Ability/Erode")]
public class Erode : AbilityData
{
    public int[] valueLV = new int[7]{ 1, 2, 4, 7, 10, 12, 14 };
    public override void OnTurnStart(CombatManager combatManager)
    {
        combatManager.enemy.statusEffects["erode_stack"].stack += valueLV[level - 1];
        combatManager.Log($"���� ħ������ ħ�� {valueLV[level - 1]} ������ �����!");
    }

}
