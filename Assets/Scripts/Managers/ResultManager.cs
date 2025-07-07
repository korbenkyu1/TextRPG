using UnityEngine;
using UnityEngine.SceneManagement;



public class ResultManager : MonoBehaviour
{
    ResultData result;
    void Start()
    {
        result = GameManager.Instance.resultData;
        Debug.Log(result.message);
        Debug.Log("�ƹ� Ű�� ���� ���.");
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
