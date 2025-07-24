using UnityEngine;
[CreateAssetMenu(menuName = "Data/Ability/Sharpness")]
public class Sharpness : AbilityData
{
    public int[] valueLV = new int[7]{ 2, 4, 8, 10, 14, 18, 25 };
    public int count;
    public override void BeforePlayerAttack(CombatManager combatManager)
    {
        count = combatManager.enemy.damages.Count;
    }
    public override void AfterPlayerAttack(CombatManager combatManager)
    {
        combatManager.enemy.statusEffects["pierce"].stack += count * valueLV[level - 1];
        Debug.Log($"예리함 특성으로 인해 상대에게 관통 {count * valueLV[level - 1]} 스택 부여");
        count = 0;
    }
}
