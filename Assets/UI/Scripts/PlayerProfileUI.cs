using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProfileUI : MonoBehaviour
{
    [SerializeField] TMP_Text AttackStats, DefenseStats, CriticalStats, DodgeStats;
    [SerializeField] Transform AbilityContainer;
    [SerializeField] GameObject AbilityButtonPrefab;
    [SerializeField] TMP_Text PlayerName, PlayerDescription;

    void OnEnable()
    {
        var player = GameManager.Instance.playerData;
        AttackStats.text = player.attack.ToString();
        DefenseStats.text = player.defense.ToString();
        CriticalStats.text = player.critChance.ToString() + "%";
        DodgeStats.text = player.critChance.ToString() + "%";

        foreach(AbilityData ability in player.abilities)
        {
            var abilityButton = Instantiate(AbilityButtonPrefab, AbilityContainer);
            abilityButton.GetComponent<Image>().sprite = ability.Image;
            // abilityButton.GetComponent<Button>().onClick.AddListener
        }

        PlayerName.text = player.unitName;
        PlayerDescription.text = player.description;
    }
}
