using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/Etc/EvasionChance")]
public class EvasionChance : StatusEffectData
{
    public override void OnTurnStart(CombatManager combatManager)
    {
        if(stack > 0)
        {
            if(!isPlayer)
            {
                combatManager.enemy.stats.dodgeChance = Mathf.Min(70, combatManager.enemy.stats.dodgeChance + stack);
                Debug.Log($"회피로 인해 상대의 회피율 {stack}%p 증가");
            }
            else if (isPlayer)
            {
                combatManager.player.stats.dodgeChance = Mathf.Min(70, combatManager.player.stats.dodgeChance + stack);
                Debug.Log($"회피로 인해 플레이어의 회피율 {stack}%p 증가");
            }
        }
    }
}