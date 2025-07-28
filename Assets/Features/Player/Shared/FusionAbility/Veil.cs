using UnityEngine;
[CreateAssetMenu(menuName = "Data/FusionAbility/Veil")]
public class Veil : AbilityData
{
    public bool isAssigned = false;
    public override void OnTurnStart(CombatManager combatManager)
    {
        if(!isAssigned)
        {
            combatManager.player.statusEffects["shield"].stack += 30;
            combatManager.Log("장막으로 보호 30 스택을 얻었다!");
            isAssigned = true;
        }
    }
}