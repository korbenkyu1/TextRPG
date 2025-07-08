using UnityEngine;

[CreateAssetMenu(menuName = "Data/PlayerSkill/SuppressiveMembrane")]
public class SuppressiveMembrane: PlayerSkillData
{
    [SerializeField]
    int scalar1;
   
    public override void OnActivate(CombatManager combatManager)
    {
        int damage = (int)(combatManager.player.stats.defense * scalar1 / 100f);

        combatManager.enemy.damages.Add(damage);
        combatManager.enemy.statusEffects["erode_stack"].stack += 3;
    }
}