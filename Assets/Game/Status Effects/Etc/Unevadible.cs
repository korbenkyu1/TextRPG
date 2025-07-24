using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/Etc/Unevadible")]
public class Unevadible : StatusEffectData
{
    public override void OnTurnStart(CombatManager combatManager)
    {
        if(stack > 0)
        {
            if(isPlayer)
            {
                combatManager.player.stats.dodgeChance -= stack * 100;
                Debug.Log($"회피불가로 인해 플레이어의 회피율 {stack * 100}%p 감소");
            }
            if(!isPlayer)
            {
                combatManager.enemy.stats.dodgeChance -= stack * 100;
                Debug.Log($"회피불가로 인해 상대의 회피율 {stack * 100}%p 감소");
            }
        }
    }
}