using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ResultManager : MonoBehaviour
{
    [Header("UI 클릭 영역")]
    [SerializeField] private RectTransform continueButtonRect;
    [SerializeField] private RectTransform[] rewardRects;
    [SerializeField] private Canvas canvas;

    private int state = 0;
    private ResultData resultData;

    void Start()
    {
        resultData = GameManager.Instance.resultData;
        Debug.Log("아무 키나 눌러 계속");
    }

    void Update()
    {
        if (state == 0)
        {
            if (Input.anyKeyDown ||
                (Input.GetMouseButtonDown(0) && RectTransformUtility.RectangleContainsScreenPoint(continueButtonRect, Input.mousePosition, canvas.worldCamera)))
            {
                ContinueToAct();
            }
        }
        else if (state >= 1 && state <= rewardRects.Length)
        {
            for (int i = 1; i < rewardRects.Length + 1; i++)
            {
                if (Input.GetKeyDown((KeyCode)((int)KeyCode.Alpha0 + i)))
                {
                    PickReward(i - 1);
                    return;
                }
            }
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 mPos = Input.mousePosition;
                for (int i = 0; i < rewardRects.Length; i++)
                {
                    if (RectTransformUtility.RectangleContainsScreenPoint(rewardRects[i], mPos, canvas.worldCamera))
                    {
                        PickReward(i);
                        return;
                    }
                }
            }
        }
    }

    private void ContinueToAct()
    {
        GameManager.Instance.actIndex++;
        SceneManager.LoadScene("ActScene");
    }

    private void PickReward(int idx)
    {
        Debug.Log($"보상 {idx+1} 선택됨");
        // 보상 처리 로직...
        state = 0;
    }
}