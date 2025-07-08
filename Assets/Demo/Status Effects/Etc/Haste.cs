using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/Etc/Haste")]
public class Haste : StatusEffectData
{
    // 일단 구현 안함
    public override void OnPlayerTurnStart(CombatManager combatManager)
    {
        if(stack > 0 && isPlayer)
        {

        }
    }
}