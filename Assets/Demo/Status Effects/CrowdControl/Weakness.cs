using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/CrowdControl/Weakness")]
public class Weakness : StatusEffectData
{
    public override void BeforePlayerAttack(CombatManager combatManager)
    {
        if(stack > 0 && isPlayer)
        {
            for(int i = 0; i < combatManager.player.damages.Count;  i++)
                combatManager.player.damages[i] = Mathf.Max(0, combatManager.player.damages[i] - stack);
        }
        Debug.Log($"약화로 인해 플레이어의 데미지 {stack}감소");
    }
    public override void BeforeEnemyAttack(CombatManager combatManager)
    {
        if(stack > 0  && !isPlayer)
        {
            for (int i = 0; i < combatManager.player.damages.Count; i++)
                combatManager.enemy.damages[i] = Mathf.Max(0, combatManager.player.damages[i] - stack);
        }
        Debug.Log($"약화로 인해 상대의 데미지 {stack} 감소");
    }
}
