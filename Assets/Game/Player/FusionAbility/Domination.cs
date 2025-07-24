using UnityEngine;

[CreateAssetMenu(menuName = "Data/FusionAbility/Domination")]
public class Domination : AbilityData
{
    int attackReduction;
    public override void OnTurnStart(CombatManager combatManager)
    {
        attackReduction += 4;
        combatManager.enemy.stats.attack = Mathf.Max(0, combatManager.enemy.stats.attack - attackReduction);
        Debug.Log("��� ����Ư������ ���� ����� ���ݷ� 4 ����");
    }
}