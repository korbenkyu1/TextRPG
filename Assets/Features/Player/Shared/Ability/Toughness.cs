using UnityEngine;
[CreateAssetMenu(menuName = "Data/Ability/Toughness")]
public class Toughness : AbilityData
{
    public int[] valueLV = new int[7]{ 3, 5, 9, 13, 15, 18, 20 };
    public override void BeforeEnemyAttack(CombatManager combatManager)
    {
        for(int i = 0; i < combatManager.player.damages.Count; i++)
        {
            combatManager.player.damages[i] = (int)(combatManager.player.damages[i] * (100 - valueLV[level - 1]) / 100f);
        }
        combatManager.Log($"강인함으로 받는 데미지가 {valueLV[level - 1]}% 감소되었다!");
    }
}
