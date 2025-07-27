using UnityEngine;
[CreateAssetMenu(menuName = "Data/FusionAbility/Corruption")]
public class Corruption : AbilityData
{
    public override void OnTurnEnd(CombatManager combatManager)
    {
        combatManager.enemy.stats.health -= 50;
        combatManager.Log("���з� ���� ü���� 50 ���ҵǾ���!");
    }
}