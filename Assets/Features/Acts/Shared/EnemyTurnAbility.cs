using UnityEngine;

[CreateAssetMenu(menuName = "Data/EnemyAbility/EnemyTurnAbility")]
public class EnemyTurnAbility : AbilityData
{
    private int count = 0;
    [SerializeField]
    public string statusEffectName;
    public int stack;
    public int cycle;
    public bool isTargetingPlayer = false;
    public override void OnTurnStart(CombatManager combatManager)
    {
        count++;
        if(count == cycle)
        {
            if(isTargetingPlayer)
                combatManager.player.statusEffects[statusEffectName].stack += stack;
            else
                combatManager.enemy.statusEffects[statusEffectName].stack += stack;
            count = 0;
        }
    }
}