using UnityEngine;

[CreateAssetMenu(menuName = "Data/FusionAbility/Proliferation")]
public class Proliferation : AbilityData
{
    int count = 3;
    public override void OnTurnStart(CombatManager combatManager)
    {
        if(count == 0)
        {
            combatManager.enemy.statusEffects["erode_stack"].stack += 12;
            Debug.Log("생식 융합특성으로 인해 상대에게 침식 스택 12 부여");
            count = 0;
        }
    }
    public override void OnTurnEnd(CombatManager combatManager)
    {
        count--;
    }
}