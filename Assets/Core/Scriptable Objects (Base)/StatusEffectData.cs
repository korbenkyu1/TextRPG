using UnityEngine;

public class StatusEffectData : ScriptableObject
{
    public int stack;
    public bool isPlayer;
    public Sprite Image;

    public virtual void OnTurnStart(CombatManager combatManager) { }
    public virtual void OnPlayerTurnStart(CombatManager combatManager) { }
    public virtual void BeforePlayerAttack(CombatManager combatManager) { }
    public virtual void AfterPlayerAttack(CombatManager combatManager) { }
    public virtual void OnPlayerTurnEnd(CombatManager combatManager) { }
    public virtual void OnEnemyTurnStart(CombatManager combatManager) { }
    public virtual void BeforeEnemyAttack(CombatManager combatManager) { }
    public virtual void AfterEnemyAttack(CombatManager combatManager) { }
    public virtual void OnEnemyTurnEnd(CombatManager combatManager) { }
    public virtual void OnTurnEnd(CombatManager combatManager) { }
}
