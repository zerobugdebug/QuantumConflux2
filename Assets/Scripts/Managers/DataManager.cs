using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set; }

    public EffectDB EffectDB { get; private set; } = new EffectDB();
    public AbilityDB AbilityDB { get; private set; } = new AbilityDB();
    public HeroCardDB HeroCardDB { get; private set; } = new HeroCardDB();
    public HeroDB HeroDB { get; private set; } = new HeroDB();
    public ItemDB ItemDB { get; private set; } = new ItemDB();
    public RoleDB RoleDB { get; private set; } = new RoleDB();
    public SlotDB SlotDB { get; private set; } = new SlotDB();
    public TraitDB TraitDB { get; private set; } = new TraitDB();

    private EffectFactory effectFactory = new();
    private AbilityFactory abilityFactory = new();
    private HeroCardFactory heroCardFactory = new();
    private HeroFactory heroFactory = new();
    private ItemFactory itemFactory = new();
    private RoleFactory roleFactory = new();
    private SlotFactory slotFactory = new();
    private TraitFactory traitFactory = new();

    [Header("JSON Files")]
    [SerializeField] private TextAsset effectJson;
    [SerializeField] private TextAsset traitJson;
    [SerializeField] private TextAsset abilityJson;
    [SerializeField] private TextAsset roleJson;
    [SerializeField] private TextAsset heroJson;
    [SerializeField] private TextAsset heroCardJson;
    [SerializeField] private TextAsset itemJson;
    [SerializeField] private TextAsset slotJson;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadAllData();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void LoadAllData()
    {
        LoadEffects();
        LoadTraits();
        LoadAbilities();
        LoadRoles();
        LoadHeroes();
        LoadItems();
        LoadHeroCards();
        LoadSlots();
    }

    private void LoadEffects()
    {
        List<EffectData> effectData = LoadData<EffectData>(effectJson);
        List<EffectModel> effects = new();
        foreach (EffectData data in effectData)
        {
            effects.Add(new EffectModel(data.id, data.name, data.luaScriptPath));
        }
        EffectDB.SetEffects(effects);
    }

    private void LoadTraits()
    {
        List<TraitData> traitData = LoadData<TraitData>(traitJson);
        List<TraitModel> traits = new();
        foreach (TraitData data in traitData)
        {
            EffectModel effect = EffectDB.GetEffectById(data.effectId);
            EffectController effectController = effectFactory.CreateEffect(effect.GetId(), effect.GetName(), effect.GetLuaScriptPath());
            traits.Add(new TraitModel(data.id, data.name, effectController));
        }
        TraitDB.SetTraits(traits);
    }

    private void LoadAbilities()
    {
        List<AbilityData> abilityData = LoadData<AbilityData>(abilityJson);
        List<AbilityModel> abilities = new();
        foreach (AbilityData data in abilityData)
        {
            EffectModel effect = EffectDB.GetEffectById(data.effectId);
            EffectController effectController = effectFactory.CreateEffect(effect.GetId(), effect.GetName(), effect.GetLuaScriptPath());
            abilities.Add(new AbilityModel(data.id, data.name, effectController));
        }
        AbilityDB.SetAbilities(abilities);
    }

    private void LoadRoles()
    {
        List<RoleData> roleData = LoadData<RoleData>(roleJson);
        List<RoleModel> roles = new();
        foreach (RoleData data in roleData)
        {
            AbilityModel ability = AbilityDB.GetAbilityById(data.abilityId);
            AbilityController abilityController = abilityFactory.CreateAbility(ability.GetId(), ability.GetName(), ability.GetEffect());
            roles.Add(new RoleModel(data.id, data.name, abilityController, new List<SlotController>()));
        }
        RoleDB.SetRoles(roles);
    }

    private void LoadHeroes()
    {
        List<HeroData> heroData = LoadData<HeroData>(heroJson);
        List<HeroModel> heroes = new();
        foreach (HeroData data in heroData)
        {
            TraitModel trait = TraitDB.GetTraitById(data.traitId);
            TraitController traitController = traitFactory.CreateTrait(trait.GetId(), trait.GetName(), trait.GetEffect());
            heroes.Add(new HeroModel(data.id, data.name, (Rarity)Enum.Parse(typeof(Rarity), data.rarity), data.speed, data.might, data.damage, traitController));
        }
        HeroDB.SetHeroes(heroes);
    }

    private void LoadHeroCards()
    {
        List<HeroCardData> heroCardData = LoadData<HeroCardData>(heroCardJson);
        List<HeroCardModel> heroCards = new();
        foreach (HeroCardData data in heroCardData)
        {
            HeroModel hero = HeroDB.GetHeroById(data.heroId);
            RoleModel role = RoleDB.GetRoleById(data.roleId);
            HeroController heroController = heroFactory.CreateHero(hero.GetId(), hero.GetName(), hero.GetRarity(), hero.GetSpeed(), hero.GetMight(), hero.GetDamage(), hero.GetTrait());
            RoleController roleController = roleFactory.CreateRole(role.GetId(), role.GetName(), role.GetAbility(), role.GetSlots());
            heroCards.Add(new HeroCardModel(data.id, heroController, roleController));
        }
        HeroCardDB.SetHeroCards(heroCards);
    }

    private void LoadItems()
    {
        List<ItemData> itemData = LoadData<ItemData>(itemJson);
        List<ItemModel> items = new();
        foreach (ItemData data in itemData)
        {
            items.Add(new ItemModel(data.id, data.name, (Rarity)Enum.Parse(typeof(Rarity), data.rarity), (ItemCategory)Enum.Parse(typeof(ItemCategory), data.category), data.speedModifier, data.mightModifier, data.damageModifier));
        }
        ItemDB.SetItems(items);
    }

    private void LoadSlots()
    {
        List<SlotData> slotData = LoadData<SlotData>(slotJson);
        List<SlotModel> slots = new();
        foreach (SlotData data in slotData)
        {
            List<ItemCategory> allowedCategories = new();
            foreach (string category in data.allowedCategories)
            {
                allowedCategories.Add((ItemCategory)Enum.Parse(typeof(ItemCategory), category));
            }
            slots.Add(new SlotModel(data.id, data.name, allowedCategories));
        }
        SlotDB.SetSlots(slots);
    }

    private List<T> LoadData<T>(TextAsset jsonData)
    {
        return JsonConvert.DeserializeObject<List<T>>(jsonData.text);
    }
}
