using UnityEngine;
using UnityEngine.SceneManagement;



public class ResultManager : MonoBehaviour
{
    ResultData result;
    void Start()
    {
        result = GameManager.Instance.resultData;
        Debug.Log(result.message);
        Debug.Log("아무 키나 눌러 계속.");
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            GameManager.Instance.actIndex++;
            SceneManager.LoadScene("ActScene");
        }
    }
}
