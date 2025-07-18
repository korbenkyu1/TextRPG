using System.Runtime.InteropServices;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/FusionAbility/Rupture")]
public class Rupture : AbilityData
{
    public int count;
    public override void BeforePlayerAttack(CombatManager combatManager)
    {
        count = combatManager.enemy.damages.Count;
    }
    public override void AfterPlayerAttack(CombatManager combatManager)
    {
        combatManager.enemy.stats.health -= count * 40;
        Debug.Log($"�Ŀ� ����Ư������ ���� ��뿡�� Ư������ {count * 40} �ο�");
        count = 0;
    }
}