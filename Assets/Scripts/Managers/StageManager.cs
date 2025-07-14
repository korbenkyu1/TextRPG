using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class StageManager : MonoBehaviour
{
    [SerializeField] private RectTransform[] optionRects;
    [SerializeField] private Canvas canvas;

    private ActData currentAct;

    void Start()
    {
        currentAct = GameManager.Instance.act;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SkipAct();
            return;
        }

        for (int i = 1; i <= currentAct.options.Length && i < 10; i++)
        {
            if (Input.GetKeyDown((KeyCode)((int)KeyCode.Alpha0 + i)))
            {
                ChooseOption(i - 1);
                return;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Input.mousePosition;
            for (int i = 0; i < optionRects.Length && i < currentAct.options.Length; i++)
            {
                if (RectTransformUtility.RectangleContainsScreenPoint(optionRects[i], mousePos, canvas.worldCamera))
                {
                    ChooseOption(i);
                    return;
                }
            }
        }
    }

    private void SkipAct()
    {
        GameManager.Instance.actIndex++;
        SceneManager.LoadScene("ActScene");
    }

    private void ChooseOption(int idx)
    {
        var option = currentAct.options[idx];
        Debug.Log($"선택지 {idx+1} ({option.label}) 선택됨");

        GameManager.Instance.coin -= option.requiredCoin;
        GameManager.Instance.playerData.health -= option.requiredHealth;
        GameManager.Instance.enemyData = option.enemy;
        GameManager.Instance.resultData = option.result;

        if (option.enemy != null) SceneManager.LoadScene("CombatScene");
        else SceneManager.LoadScene("ResultScene");
    }
}