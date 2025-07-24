using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/BonusEvasion")]
public class BonusEvasion : StatusEffectData
{
    public override void OnTurnEnd(CombatManager combatManager)
    {
        if(stack > 0)
        {
            stack = 0;
            Debug.Log("회피율 증가 없어짐");
        }    
    }
}