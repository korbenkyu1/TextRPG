using UnityEngine;

public enum SkillType
{
    Attack,
    Defense,
    Normal,
    Special,
    Ultimate,
}

public enum Rarity
{
    Common,
    Uncommon,
    Rare,
    Epic,
    Legendary,
    Mythical,
}

public abstract class PlayerSkillData : ScriptableObject
{
    public SkillType type;
    public Rarity rarity;
    public string skillName;
    public Sprite image;
    public string description;
    public string flavorText;
    public int maxUse;
    public int remainingUse;
    public int turnUsed;
    public bool dodgable;
    public int coolDown;
    public int coolDownCounter;
    public abstract void OnActivate(CombatManager combatManager);
}
