using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/Attack/Pierce")]
public class Pierce : StatusEffectData
{
    public override void OnTurnStart(CombatManager combatManager)
    {
        if (stack > 0)
        {
            if (!isPlayer)
            {
                combatManager.enemy.stats.health -= stack;
                Debug.Log($"�������� ���� ���� {stack}�� �������� �Ծ���");
                stack = 0;
            }
            else if(isPlayer)
            {
                combatManager.player.stats.health -= stack;
                Debug.Log($"�������� ���� �÷��̾�� {stack}�� �������� �Ծ���");
                stack = 0;               
            }
        }
    }
}
