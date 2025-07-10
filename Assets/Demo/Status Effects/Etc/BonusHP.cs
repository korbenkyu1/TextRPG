using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/Etc/BonusHP")]
public class BonusHP : StatusEffectData
{
    public override void OnTurnStart(CombatManager combatManager)
    {
        if(stack > 0)
        {
            if(isPlayer)
            {
                combatManager.player.stats.maxHealth = Mathf.Min(900, combatManager.player.stats.maxHealth + stack);
                Debug.Log($"추가체력으로 인해 플레이어의 최대체력 {stack} 증가");
            }
            else if(!isPlayer)
            {
                combatManager.enemy.stats.maxHealth = Mathf.Min(900, combatManager.enemy.stats.maxHealth + stack);
                Debug.Log($"추가체력으로 인해 상대의 최대체력 {stack} 증가");
            }
        }
    }
}