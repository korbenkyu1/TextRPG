using UnityEngine;
[CreateAssetMenu(menuName = "Data/FusionAbility/Aegis")]
public class Aegis : AbilityData
{
    public bool isAssigned = false;
    public override void OnTurnStart(CombatManager combatManager)
    {
        if (!isAssigned)
        {
            combatManager.player.statusEffects["reduction"].stack += 45;
            combatManager.Log("철벽으로 경감 45 스택을 얻었다!");
            isAssigned = true;
        }
    }
}