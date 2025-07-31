using UnityEngine;

[CreateAssetMenu(menuName = "Data/EnemyAbility/EnemyTurnStartAbility")]
public class EnemyTurnStartAbility : AbilityData
{
    public bool isUsed = false;
    [SerializeField]
    public string statusEffectName;
    public int stack;
    public bool isTargetingPlayer = false;
    public override void OnTurnStart(CombatManager combatManager)
    {
        if(!isUsed)
        {
            if (isTargetingPlayer)
                combatManager.player.statusEffects[statusEffectName].stack += stack;
            else
                combatManager.enemy.statusEffects[statusEffectName].stack += stack;
            isUsed = true;
        }
    }
}