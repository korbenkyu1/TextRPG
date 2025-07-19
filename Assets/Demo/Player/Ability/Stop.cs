using UnityEngine;
public class Stop : AbilityData
{
    public int[] valueLV = new int[7]{ 7, 7, 6, 6, 5, 5, 4 };
    public int turnCount = -1;
    public override void OnTurnStart(CombatManager combatManager)
    {
        if (turnCount == 0)
        {
            combatManager.enemy.statusEffects["paralyze"].stack++;
            Debug.Log("정지 특성으로 인해 상대에게 마비 1 스택 부여");
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
