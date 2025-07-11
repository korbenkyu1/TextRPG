using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/Defense/Fortify")]
public class Fortify : StatusEffectData
{
    public override void BeforePlayerAttack(CombatManager combatManager)
    {
        if(stack > 0 && !isPlayer)
        {
            for(int i = 0; i < combatManager.enemy.damages.Count; i++)
            {
                combatManager.enemy.damages[i] = Mathf.Max(0, combatManager.enemy.damages[i] - stack);
            }
            Debug.Log($"철갑으로 인해 상대가 받는 데미지 {stack} 감소");
        }
    }
    public override void BeforeEnemyAttack(CombatManager combatManager)
    {
        if (stack > 0 && isPlayer)
        {
            for (int i = 0; i < combatManager.player.damages.Count; i++)
            {
                combatManager.player.damages[i] = Mathf.Max(0, combatManager.player.damages[i] - stack);
            }
            Debug.Log($"철갑으로 인해 플레이어가 받는 데미지 {stack} 감소");
        }
    }
}