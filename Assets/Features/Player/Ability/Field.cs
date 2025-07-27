using UnityEngine;
[CreateAssetMenu(menuName = "Data/Ability/Field")]
public class Field : AbilityData
{
    public int[] valueLV = new int[7]{ 1, 2, 4, 5, 8, 10, 12 };
    public override void OnTurnStart(CombatManager combatManager)
    {
        combatManager.player.statusEffects["fortify"].stack += valueLV[level - 1];
        combatManager.Log($"결계로 플레이어는 철갑 {valueLV[level - 1]} 스택을 얻었다!");
    }
}
