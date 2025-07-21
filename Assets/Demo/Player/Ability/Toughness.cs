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
        Debug.Log($"강인함 특성으로 인해 플레이어가 받는 데미지 {valueLV[level - 1]}% 감소");
    }
}
