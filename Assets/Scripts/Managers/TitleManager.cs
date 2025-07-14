using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TitleManager : MonoBehaviour
{
    [SerializeField] private RectTransform startButtonRect;
    [SerializeField] private Canvas canvas;

    void Start()
    {
        GameManager.Instance.stageIndex = 0;
        GameManager.Instance.actIndex = 0;
        Debug.Log("아무 키나 눌러 시작");
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene("ActScene");
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Input.mousePosition;
            if (RectTransformUtility.RectangleContainsScreenPoint(startButtonRect, mousePos, canvas.worldCamera))
            {
                SceneManager.LoadScene("ActScene");
            }
        }
    }
}