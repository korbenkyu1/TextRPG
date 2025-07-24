using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/PenetrationDamage/Mark")]
public class Mark : StatusEffectData
{
    public override void BeforePlayerAttack(CombatManager combatManager)
    {
        if(stack > 0 && !isPlayer)
        {
            for(int i = 0; i < stack && i < combatManager.enemy.damages.Count; i++)
            {
                combatManager.enemy.damages[i] = (int)(combatManager.enemy.damages[i] * 1.3f);
                Debug.Log("표식으로 인해 상대는 30% 추가 데미지를 입는다");
            }
        }
    }
    public override void BeforeEnemyAttack(CombatManager combatManager)
    {
        if (stack > 0 && isPlayer)
        {
            for (int i = 0; i < stack && i < combatManager.player.damages.Count; i++)
            {
                combatManager.player.damages[i] = (int)(combatManager.player.damages[i] * 1.3f);
                Debug.Log("표식으로 인해 플레이어는 30% 추가 데미지를 입는다");
            }
        }
    }
    public override void OnTurnEnd(CombatManager combatManager)
    {
        if(stack > 0)
        {
            stack--;
            Debug.Log("표식 스택 1 감소");
        }
    }
}