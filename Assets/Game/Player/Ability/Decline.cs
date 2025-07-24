using UnityEngine;

[CreateAssetMenu(menuName = "Data/Ability/Decline")]
public class Decline : AbilityData
{
    public int[] valueLV = new int[7]{ 1, 2, 4, 5, 6, 8, 10 };
    int turnCount = 7;
    public override void OnTurnStart(CombatManager combatManager)
    {
        if (turnCount == 0)
        {
            combatManager.enemy.statusEffects["corrosion"].stack += valueLV[level - 1];
            Debug.Log($"쇠락 특성 효과로 인해 상대에게 {valueLV[level - 1]}의 부식 스택 부여");
            turnCount = 7;
        }
    }
    public override void OnTurnEnd(CombatManager combatManager)
    {
        turnCount--;
    }
}
