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
            Debug.Log($"��� Ư�� ȿ���� ���� ��뿡�� {valueLV[level - 1]}�� �ν� ���� �ο�");
            turnCount = 7;
        }
    }
    public override void OnTurnEnd(CombatManager combatManager)
    {
        turnCount--;
    }
}
