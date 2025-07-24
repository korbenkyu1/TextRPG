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
            Debug.Log("철벽 융합특성으로 인해 플레이어에게 경감 45 스택 부여");
            isAssigned = true;
        }
    }
}