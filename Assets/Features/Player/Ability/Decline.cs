using UnityEngine;
[CreateAssetMenu(menuName = "Data/Ability/Decline")]
public class Decline : AbilityData
{
    public int[] valueLV = new int[7]{ 1, 2, 4, 5, 6, 8, 10 };
    public int turnCount = 7;
    public override void OnTurnStart(CombatManager combatManager)
    {
        if (turnCount == 0)
        {
            combatManager.enemy.statusEffects["corrosion"].stack += valueLV[level - 1];
            combatManager.Log($"적이 쇠락으로 부식 {valueLV[level - 1]} 스택을 얻었다!");
            turnCount = 7;
        }
    }
    public override void OnTurnEnd(CombatManager combatManager)
    {
        turnCount--;
    }
}
