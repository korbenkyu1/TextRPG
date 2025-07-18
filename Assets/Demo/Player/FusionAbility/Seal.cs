using UnityEngine;

[CreateAssetMenu(menuName = "Data/FusionAbility/Seal")]
public class Seal : AbilityData
{
    public int count = 5;
    public override void BeforeEnemyAttack(CombatManager combatManager)
    {
        if(count > 0)
        {
            if (combatManager.player.damages.Count != 0)
                combatManager.player.damages.Clear();
            Debug.Log("���� ����Ư������ ���� ����� ������ ��ȿȭ");
        }
    }
    public override void OnTurnEnd(CombatManager combatManager)
    {
        count--;
    }
}