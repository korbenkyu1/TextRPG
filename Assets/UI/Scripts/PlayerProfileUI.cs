using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProfileUI : MonoBehaviour
{
    [SerializeField] TMP_Text AttackStats, DefenseStats, CriticalStats, DodgeStats;
    [SerializeField] Transform AbilityContainer;
    [SerializeField] GameObject AbilityButtonPrefab;
    [SerializeField] TMP_Text PlayerName, PlayerDescription;
    [SerializeField] Button[] SkillButtons = new Button[5];

    void OnEnable()
    {
        var player = GameManager.Instance.playerData;
        AttackStats.text = player.attack.ToString();
        DefenseStats.text = player.defense.ToString();
        CriticalStats.text = player.critChance.ToString() + "%";
        DodgeStats.text = player.critChance.ToString() + "%";


        foreach (Transform child in AbilityContainer) Destroy(child.gameObject);
        foreach (AbilityData ability in player.abilities)
        {
            var abilityButton = Instantiate(AbilityButtonPrefab, AbilityContainer);
            abilityButton.GetComponent<Image>().sprite = ability.Image;
        }

        PlayerName.text = player.unitName;
        PlayerDescription.text = player.description;

        for(int i = 0; i<5; i++)
        {
            if (!player.skills[i]) continue;
            var image = SkillButtons[i].GetComponentInChildren<Image>();
            image.sprite = player.skills[i].icon;
            image.gameObject.SetActive(true);
        }
    }
}
