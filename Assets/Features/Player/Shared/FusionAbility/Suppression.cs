using UnityEngine;
[CreateAssetMenu(menuName = "Data/FusionAbility/Suppression")]
public class Suppression : AbilityData
{
    public bool isAssigned = false;
    public override void OnTurnStart(CombatManager combatManager)
    {
        if(!isAssigned)
        {
            combatManager.enemy.statusEffects["restrain"].stack += 30;
            combatManager.Log("적이 억압으로 인해 수갑 30 스택을 얻었다!");
            isAssigned = true;
        }
    }
}