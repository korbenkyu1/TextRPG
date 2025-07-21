using UnityEngine;

public class AbilityData : ScriptableObject
{
    public int level;
    public Sprite Image;
    public virtual void OnCombatStart(CombatManager combatManager) {}
    public virtual void OnTurnStart(CombatManager combatManager) {}
    public virtual void OnPlayerTurnStart(CombatManager combatManager) {}
    public virtual void BeforePlayerAttack(CombatManager combatManager) {}
    public virtual void AfterPlayerAttack(CombatManager combatManager) {}
    public virtual void OnPlayerTurnEnd(CombatManager combatManager) {}
    public virtual void OnEnemyTurnStart(CombatManager combatManager) {}
    public virtual void BeforeEnemyAttack(CombatManager combatManager) {}
    public virtual void AfterEnemyAttack(CombatManager combatManager) {}
    public virtual void OnEnemyTurnEnd(CombatManager combatManager) {}
    public virtual void OnTurnEnd(CombatManager combatManager) {}
}
