using UnityEngine;
[CreateAssetMenu(menuName = "Data/FusionAbility/Proliferation")]
public class Proliferation : AbilityData
{
    public int count = 3;
    public override void OnTurnStart(CombatManager combatManager)
    {
        if(count == 0)
        {
            combatManager.enemy.statusEffects["erode_stack"].stack += 12;
            combatManager.Log("적이 생식으로 침식 12 스택을 얻었다!");
            count = 0;
        }
    }
    public override void OnTurnEnd(CombatManager combatManager)
    {
        count--;
    }
}