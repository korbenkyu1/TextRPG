using UnityEngine;
[CreateAssetMenu(menuName = "Data/Ability/Erode")]
public class Erode : AbilityData
{
    public int[] valueLV = new int[7]{ 1, 2, 4, 7, 10, 12, 14 };
    public override void OnTurnStart(CombatManager combatManager)
    {
        combatManager.enemy.statusEffects["erode_stack"].stack += valueLV[level - 1];
        Debug.Log($"침식 특성으로 인해 적에게 침식 스택 {valueLV[level - 1]} 부여");
    }

}
