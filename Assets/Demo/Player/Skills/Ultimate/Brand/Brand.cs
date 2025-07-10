using UnityEngine;

[CreateAssetMenu(menuName = "Data/PlayerSkill/Brand")]
public class Brand : PlayerSkillData
{
    [SerializeField]
    int scalar1;
    public override void OnActivate(CombatManager combatManager)
    {
        combatManager.player.statusEffects["brand"].stack += scalar1;
    }
}