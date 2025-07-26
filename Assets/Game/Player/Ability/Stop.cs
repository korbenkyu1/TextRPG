using UnityEngine;
[CreateAssetMenu(menuName = "Data/Ability/Stop")]
public class Stop : AbilityData
{
    public int[] valueLV = new int[7]{ 7, 7, 6, 6, 5, 5, 4 };
    public int turnCount = -1;
    public override void OnTurnStart(CombatManager combatManager)
    {
        if (turnCount == 0)
        {
            combatManager.enemy.statusEffects["paralyze"].stack++;
            combatManager.Log("정지로 적이 마비 1 스택을 얻었다!");
            turnCount = valueLV[level - 1];
        }
        else if(turnCount < 0)
            turnCount = valueLV[level - 1];
    }
    public override void OnTurnEnd(CombatManager combatManager)
    {
        turnCount--;
    }
}
