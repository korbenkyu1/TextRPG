using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/PlayerSkill/SilenceVeil")]
public class SilenceVeil: PlayerSkillData
{
    [SerializeField]
    int scalar1;
    public override void OnActivate(CombatManager combatManager)
    {
        int damageReduction = (int)(combatManager.player.stats.defense * scalar1 / 100f);
        
    }
}