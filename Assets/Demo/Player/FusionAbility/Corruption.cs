using UnityEngine;

[CreateAssetMenu(menuName = "Data/FusionAbility/Corruption")]
public class Corruption : AbilityData
{
    public override void OnTurnEnd(CombatManager combatManager)
    {
        combatManager.enemy.stats.health -= 50;
        Debug.Log("���� ����Ư������ 50�� Ư������ �ο�");
    }
}