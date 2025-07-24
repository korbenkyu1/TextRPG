using UnityEngine;

[CreateAssetMenu(menuName = "Data/FusionAbility/Collapse")]
public class Collapse : AbilityData
{
    public int count = 3;
    public int defenseReduction;
    public override void OnTurnStart(CombatManager combatManager)
    {
        if (count == 0)
        {
            defenseReduction += 10;
            combatManager.enemy.statusEffects["corrosion"].stack += 20;
            Debug.Log("�ر� ����Ư������ ���� ��뿡�� ���� 10 ���� �� �ν� 20 ���� �ο�");
            count = 3;
        }
        combatManager.enemy.stats.defense = Mathf.Max(0, combatManager.enemy.stats.defense - defenseReduction);
    }
    public override void OnTurnEnd(CombatManager combatManager)
    {
        count--;
    }
}