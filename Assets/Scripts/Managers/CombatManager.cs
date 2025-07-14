using UnityEngine;
using UnityEngine.EventSystems;

public class CombatManager : MonoBehaviour
{
    [Header("UI 클릭 영역")]
    [SerializeField] private RectTransform[] skillIconRects;
    [SerializeField] private Canvas canvas;

    private CombatState state;
    private PlayerData playerData;
    private EnemyData enemyData;

    void Start()
    {
        // 초기 설정...
        playerData = GameManager.Instance.playerData;
        enemyData = GameManager.Instance.enemyData;
        state = CombatState.PlayerTurn;
    }

    void Update()
    {
        if (state == CombatState.PlayerTurn)
        {
            for (int i = 1; i < skillIconRects.Length + 1; i++)
            {
                if (Input.GetKeyDown((KeyCode)((int)KeyCode.Alpha0 + i)))
                {
                    TryActivateSkill(i - 1);
                    return;
                }
            }

            if (Input.GetMouseButtonDown(0))
            {
                Vector2 mPos = Input.mousePosition;
                for (int i = 0; i < skillIconRects.Length; i++)
                {
                    if (RectTransformUtility.RectangleContainsScreenPoint(skillIconRects[i], mPos, canvas.worldCamera))
                    {
                        TryActivateSkill(i);
                        return;
                    }
                }
            }
        }
    }

    private void TryActivateSkill(int index)
    {
        var skill = playerData.skills[index];
        if (skill.coolDownCounter == 0)
        {
            ActivateSkill(index);
        }
    }

    private void ActivateSkill(int skillIndex)
    {
        // 스킬 실행 로직...
        Debug.Log($"스킬 {skillIndex} 활성화");
        // 이후 턴 처리...
    }
}

public enum CombatState
{
    PlayerTurn,
    EnemyTurn
}