using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

class PlayerSkill
{
    public PlayerSkillData[] skill = new PlayerSkillData[6];
}



public class ResultManager : MonoBehaviour
{
    [SerializeField] PlayerSkill[] attackSkills, defenseSkills, normalSkills, specialSkills, ultimateSkills;
    [SerializeField] FoodData[] commonFoods, uncommonFoods, rareFoods, epicFoods, legendaryFoods, mythicFoods;

    public int state;
    PlayerSkillData[] skillRewards = new PlayerSkillData[3];

    ResultData result;

    T[] ChooseThree<T>(T[] array)
    {
        if (array.Length < 3) return array;
        T[] t = new T[3];

        for (int i = 0; i < 3; i++)
        {
            int j = Random.Range(0, array.Length - i - 1);
            t[i - 1] = array[j];
            array[j] = array[array.Length - i - 1];
        }

        return t;
    }

    void Start()
    {
        result = GameManager.Instance.resultData;
        Debug.Log(result.message);
        GameManager.Instance.coin += result.coin;
        GameManager.Instance.playerData.maxHealth += result.maxHealth;
        GameManager.Instance.playerData.health += result.health;
        GameManager.Instance.playerData.attack += result.attack;
        GameManager.Instance.playerData.defense += result.defense;
        GameManager.Instance.playerData.critChance += result.critChance;
        GameManager.Instance.playerData.dodgeChance += result.dodgeChance;

        switch(result.type)
        {
            case RewardType.Skill:
                PlayerSkill[][] playerSkills = new PlayerSkill[][] { attackSkills, defenseSkills, normalSkills, specialSkills, ultimateSkills };
                PlayerSkillData[] currentSkills = GameManager.Instance.playerData.skills;

                int skillType = Random.Range(0, 4);
                int skillRarity = currentSkills[skillType] ? (int)currentSkills[skillType].rarity : 0;
                string skillName = currentSkills[skillType] ? currentSkills[skillType].skillName : "";

                PlayerSkill[] s = ChooseThree<PlayerSkill>(playerSkills[skillType]);
                for(int i = 0; i<3; i++) skillRewards[i] = s[i].skill[skillRarity].name == skillName ? s[i].skill[Mathf.Min(5, skillRarity+1)] : s[i].skill[skillRarity];
                state = 1;
                break;
            case RewardType.Item:
                state = 2;
                break;

            case RewardType.Food:
                state = 3;
                break;
        }

    }

    void Update()
    {
        switch(state)
        {
            case 0:
                if (Input.anyKeyDown)
                {
                    GameManager.Instance.actIndex++;
                    SceneManager.LoadScene("ActScene");
                }
                break;
            case 1:
                for (int i = 1; i < 3; i++)
                {
                    if (Input.GetKeyDown((KeyCode)((int)KeyCode.Alpha0 + i)))
                    {
                        PlayerSkillData s = skillRewards[i];
                        GameManager.Instance.playerData.skills[(int)s.type] = s;
                        Debug.Log("아무 키나 눌러 계속.");
                        state = 0;
                        return;
                    }
                }
                break;
            case 2:
                for (int i = 1; i < 3; i++)
                {
                    if (Input.GetKeyDown((KeyCode)((int)KeyCode.Alpha0 + i)))
                    {
                        Debug.Log("아무 키나 눌러 계속.");
                        state = 0;
                        return;
                    }
                }
                break;
            case 3:
                for (int i = 1; i < 3; i++)
                {
                    if (Input.GetKeyDown((KeyCode)((int)KeyCode.Alpha0 + i)))
                    {
                        Debug.Log("아무 키나 눌러 계속.");
                        state = 0;
                        return;
                    }
                }
                break;

        }

    }
}
