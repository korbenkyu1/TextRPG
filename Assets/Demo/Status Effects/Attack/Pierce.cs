using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/Attack/Pierce")]
public class Pierce : StatusEffectData
{
    public override void OnTurnStart(CombatManager combatManager)
    {
        if (stack > 0)
        {
            if (!isPlayer)
            {
                combatManager.enemy.stats.health -= stack;
                Debug.Log($"관통으로 인해 상대는 {stack}의 데미지를 입었다");
                stack = 0;
            }
            else if(isPlayer)
            {
                combatManager.player.stats.health -= stack;
                Debug.Log($"관통으로 인해 플레이어는 {stack}의 데미지를 입었다");
                stack = 0;               
            }
        }
    }
}
