
using GraphicRuleCreator;
using System;
using System.ComponentModel.DataAnnotations;
using System.Windows;
using System.Windows.Media.Effects;

public class Alchem
{
    public bool firstenum = false;

    public AlchemyBaseEffectFirst _first;
    public AlchemyBaseEffectSecond _second;

    public Alchem(AlchemyBaseEffectFirst first, AlchemyBaseEffectSecond second)
    {
        _first = first;
        _second = second;
        if (_first == AlchemyBaseEffectFirst.kNone)
        {
            firstenum = false;
        }
        else if (_second == AlchemyBaseEffectSecond.kNone)
        {
            firstenum = true;
        }
        else
        {
            _first = AlchemyBaseEffectFirst.kNone;
            firstenum = false;
        }
    }

    public static bool operator==(Alchem lhs, Alchem rhs)
    {
        return lhs._first == rhs._first && lhs._second == rhs._second;
    }

    public static bool operator!=(Alchem lhs, Alchem rhs)
    {
        return lhs._first != rhs._first || lhs._second != rhs._second;  
    }

    public override string ToString()
    {
        if (firstenum)
            return ((UInt64)_first).ToString("X") + ((UInt64)_second).ToString("X16");
        else
            return ((UInt64)_second).ToString("X");
    }
}


public enum AlchemyBaseEffectFirst : UInt64
{
    kNone = 0,
}

public enum AlchemyBaseEffectSecond : UInt64
{
    kNone = 0,                                      // 0
	kHealth = 1 << 0,                               // 1
	kMagicka = 1 << 1,                              // 2
	kStamina = 1 << 2,                              // 4
	kOneHanded = 1 << 3,                            // 8
	kTwoHanded = 1 << 4,                            // 10
	kArchery = 1 << 5,                              // 20
	kBlock = 1 << 6,                                // 40
	kHeavyArmor = 1 << 7,                           // 80
	kLightArmor = 1 << 8,                           // 100
	kAlteration = 1 << 9,                           // 200
	kConjuration = 1 << 10,                         // 400
	kDestruction = 1 << 11,                         // 800
	kIllusion = 1 << 12,                            // 1000
	kRestoration = 1 << 13,                         // 2000
	kHealRate = 1 << 14,                            // 4000
	kMagickaRate = 1 << 15,                         // 8000
	kStaminaRate = 1 << 16,                         // 10000
	kSpeedMult = 1 << 17,                           // 20000
	kCriticalChance = 1 << 18,                      // 40000
	kMeleeDamage = 1 << 19,                         // 80000
	kUnarmedDamage = 1 << 20,                       // 100000
	kDamageResist = 1 << 21,                        // 200000
	kPoisonResist = 1 << 22,                        // 400000
	kResistFire = 1 << 23,                          // 800000
	kResistShock = 1 << 24,                         // 1000000
	kResistFrost = 1 << 25,                         // 2000000
	kResistMagic = 1 << 26,                         // 4000000
	kResistDisease = 1 << 27,                       // 8000000
	kParalysis = 1 << 28,                           // 10000000
	kInvisibility = 1 << 29,                        // 20000000
	kWeaponSpeedMult = 1 << 30,                     // 40000000
	kAttackDamageMult = (UInt64)1 << 31,  // 80000000
	kHealRateMult = (UInt64)1 << 32,      // 100000000
	kMagickaRateMult = (UInt64)1 << 33,   // 200000000
	kStaminaRateMult = (UInt64)1 << 34,   // 400000000
	kBlood = (UInt64)1 << 35,             // 800000000
	kPickpocket = (UInt64)1 << 36,        // 1000000000
	kLockpicking = (UInt64)1 << 37,       // 2000000000
	kSneak = (UInt64)1 << 38,             // 4000000000
	kFrenzy = (UInt64)1 << 39,            // 8000000000
	kFear = (UInt64)1 << 40,              // 10000000000
	kBowSpeed = (UInt64)1 << 41,          // 20000000000
	kReflectDamage = (UInt64)1 << 42,     // 40000000000
	kCureDisease = (UInt64)1 << 43,       // 80000000000
	kCurePoison = (UInt64)1 << 44,        // 100000000000
	kEnchanting = (UInt64)1 << 45,        // 200000000000
	kWaterbreathing = (UInt64)1 << 46,    // 400000000000
	kSmithing = (UInt64)1 << 47,          // 800000000000
	kSpeech = (UInt64)1 << 48,            // 1000000000000
	kCarryWeight = (UInt64)1 << 49,       // 2000000000000
	kPersuasion = (UInt64)1 << 50,        // 4000000000000
	kAlchemy = (UInt64)1 << 51,           // 8000000000000
	kFortifyHealth = (UInt64)1 << 52,     // 10000000000000
	kFortifyMagicka = (UInt64)1 << 53,    // 20000000000000
	kFortifyStamina = (UInt64)1 << 54,    // 40000000000000
	kShield = (UInt64)1 << 55,           // 80000000000000
	kUnused2 = (UInt64)1 << 56,           // 100000000000000
	kUnused3 = (UInt64)1 << 57,           // 200000000000000
	kUnused4 = (UInt64)1 << 58,           // 300000000000000
	kUnused5 = (UInt64)1 << 59,           // 400000000000000
	kUnused6 = (UInt64)1 << 60,           // 800000000000000
	kUnused7 = (UInt64)1 << 61,           // 1000000000000000
	kUnused8 = (UInt64)1 << 62,           // 2000000000000000
	kCustom = (UInt64)1 << 63,            // 4000000000000000

	// 2000007
	kAnyPotion = (kHealth) |
	             (kMagicka) |
	             (kStamina) |
	             (kInvisibility),

	// 720387DFFBFFFF
	kAnyPoison = (kHealth) |
	             (kMagicka) |
	             (kStamina) |
	             (kOneHanded) |
	             (kTwoHanded) |
	             (kArchery) |
	             (kBlock) |
	             (kHeavyArmor) |
	             (kLightArmor) |
	             (kAlteration) |
	             (kConjuration) | 
	             (kDestruction) |
	             (kIllusion) |
	             (kRestoration) |
	             (kHealRate) |
	             (kMagickaRate) |
	             (kStaminaRate) |
	             (kSpeedMult) |
	             (kMeleeDamage) |
	             (kUnarmedDamage) |
	             (kDamageResist) |
	             (kPoisonResist) |
	             (kResistFire) |
	             (kResistShock) |
	             (kResistFrost) |
	             (kResistMagic) |
	             (kResistDisease) |
	             (kParalysis) |
	             (kWeaponSpeedMult) |
	             (kAttackDamageMult) |
	             (kHealRateMult) |
	             (kMagickaRateMult) |
	             (kStaminaRateMult) |
	             (kFrenzy) |
	             (kFear) |
	             (kBowSpeed) |
	             (kCarryWeight) |
	             (kFortifyHealth) |
	             (kFortifyMagicka) |
	             (kFortifyStamina),

	// 70001C000
	kAnyRegen = (kHealRate) |
	            (kMagickaRate) |
	            (kStaminaRate) |
	            (kHealRateMult) |
	            (kMagickaRateMult) |
	            (kStaminaRateMult),

	// 7FE670CFFE3FF8
	kAnyFortify = (kOneHanded) |
	              (kTwoHanded) |
	              (kArchery) |
	              (kBlock) |
	              (kHeavyArmor) |
	              (kLightArmor) |
	              (kAlteration) |
	              (kConjuration) |
	              (kDestruction) |
	              (kIllusion) |
	              (kRestoration) |
	              (kSpeedMult) |
	              (kCriticalChance) |
	              (kMeleeDamage) |
	              (kUnarmedDamage) |
	              (kDamageResist) |
	              (kPoisonResist) |
	              (kResistFire) |
	              (kResistShock) |
	              (kResistFrost) |
	              (kResistMagic) |
	              (kResistDisease) |
	              (kWeaponSpeedMult) |
	              (kAttackDamageMult) |
	              (kPickpocket) |
	              (kLockpicking) |
	              (kSneak) |
	              (kBowSpeed) |
	              (kReflectDamage) |
	              (kEnchanting) |
	              (kWaterbreathing) |
	              (kSmithing) |
	              (kSpeech) |
	              (kCarryWeight) |
	              (kPersuasion) |
	              (kAlchemy) |
	              (kFortifyHealth) |
	              (kFortifyMagicka) |
	              (kFortifyStamina),

	// 7FE677EFFFFFFF
	kAnyFood = (kAnyPotion) |
	           (kAnyRegen) |
	           (kAnyFortify),

};

public enum ActorValue : Int64
{
    kNone = -1,
    kAggression = 0,
    kConfidence = 1,
    kEnergy = 2,
    kMorality = 3,
    kMood = 4,
    kAssistance = 5,
    kOneHanded = 6,
    kTwoHanded = 7,
    kArchery = 8,
    kBlock = 9,
    kSmithing = 10,
    kHeavyArmor = 11,
    kLightArmor = 12,
    kPickpocket = 13,
    kLockpicking = 14,
    kSneak = 15,
    kAlchemy = 16,
    kSpeech = 17,
    kAlteration = 18,
    kConjuration = 19,
    kDestruction = 20,
    kIllusion = 21,
    kRestoration = 22,
    kEnchanting = 23,
    kHealth = 24,
    kMagicka = 25,
    kStamina = 26,
    kHealRate = 27,
    kMagickaRate = 28,
    kStaminaRate = 29,
    kSpeedMult = 30,
    kInventoryWeight = 31,
    kCarryWeight = 32,
    kCriticalChance = 33,
    kMeleeDamage = 34,
    kUnarmedDamage = 35,
    kMass = 36,
    kVoicePoints = 37,
    kVoiceRate = 38,
    kDamageResist = 39,
    kPoisonResist = 40,
    kResistFire = 41,
    kResistShock = 42,
    kResistFrost = 43,
    kResistMagic = 44,
    kResistDisease = 45,
    kPerceptionCondition = 46,
    kEnduranceCondition = 47,
    kLeftAttackCondition = 48,
    kRightAttackCondition = 49,
    kLeftMobilityCondition = 50,
    kRightMobilityCondition = 51,
    kBrainCondition = 52,
    kParalysis = 53,
    kInvisibility = 54,
    kNightEye = 55,
    kDetectLifeRange = 56,
    kWaterBreathing = 57,
    kWaterWalking = 58,
    kIgnoreCrippledLimbs = 59,
    kFame = 60,
    kInfamy = 61,
    kJumpingBonus = 62,
    kWardPower = 63,
    kRightItemCharge = 64,
    kArmorPerks = 65,
    kShieldPerks = 66,
    kWardDeflection = 67,
    kVariable01 = 68,
    kVariable02 = 69,
    kVariable03 = 70,
    kVariable04 = 71,
    kVariable05 = 72,
    kVariable06 = 73,
    kVariable07 = 74,
    kVariable08 = 75,
    kVariable09 = 76,
    kVariable10 = 77,
    kBowSpeedBonus = 78,
    kFavorActive = 79,
    kFavorsPerDay = 80,
    kFavorsPerDayTimer = 81,
    kLeftItemCharge = 82,
    kAbsorbChance = 83,
    kBlindness = 84,
    kWeaponSpeedMult = 85,
    kShoutRecoveryMult = 86,
    kBowStaggerBonus = 87,
    kTelekinesis = 88,
    kFavorPointsBonus = 89,
    kLastBribedIntimidated = 90,
    kLastFlattered = 91,
    kMovementNoiseMult = 92,
    kBypassVendorStolenCheck = 93,
    kBypassVendorKeywordCheck = 94,
    kWaitingForPlayer = 95,
    kOneHandedModifier = 96,
    kTwoHandedModifier = 97,
    kMarksmanModifier = 98,
    kBlockModifier = 99,
    kSmithingModifier = 100,
    kHeavyArmorModifier = 101,
    kLightArmorModifier = 102,
    kPickpocketModifier = 103,
    kLockpickingModifier = 104,
    kSneakingModifier = 105,
    kAlchemyModifier = 106,
    kSpeechcraftModifier = 107,
    kAlterationModifier = 108,
    kConjurationModifier = 109,
    kDestructionModifier = 110,
    kIllusionModifier = 111,
    kRestorationModifier = 112,
    kEnchantingModifier = 113,
    kOneHandedSkillAdvance = 114,
    kTwoHandedSkillAdvance = 115,
    kMarksmanSkillAdvance = 116,
    kBlockSkillAdvance = 117,
    kSmithingSkillAdvance = 118,
    kHeavyArmorSkillAdvance = 119,
    kLightArmorSkillAdvance = 120,
    kPickpocketSkillAdvance = 121,
    kLockpickingSkillAdvance = 122,
    kSneakingSkillAdvance = 123,
    kAlchemySkillAdvance = 124,
    kSpeechcraftSkillAdvance = 125,
    kAlterationSkillAdvance = 126,
    kConjurationSkillAdvance = 127,
    kDestructionSkillAdvance = 128,
    kIllusionSkillAdvance = 129,
    kRestorationSkillAdvance = 130,
    kEnchantingSkillAdvance = 131,
    kLeftWeaponSpeedMultiply = 132,
    kDragonSouls = 133,
    kCombatHealthRegenMultiply = 134,
    kOneHandedPowerModifier = 135,
    kTwoHandedPowerModifier = 136,
    kMarksmanPowerModifier = 137,
    kBlockPowerModifier = 138,
    kSmithingPowerModifier = 139,
    kHeavyArmorPowerModifier = 140,
    kLightArmorPowerModifier = 141,
    kPickpocketPowerModifier = 142,
    kLockpickingPowerModifier = 143,
    kSneakingPowerModifier = 144,
    kAlchemyPowerModifier = 145,
    kSpeechcraftPowerModifier = 146,
    kAlterationPowerModifier = 147,
    kConjurationPowerModifier = 148,
    kDestructionPowerModifier = 149,
    kIllusionPowerModifier = 150,
    kRestorationPowerModifier = 151,
    kEnchantingPowerModifier = 152,
    kDragonRend = 153,
    kAttackDamageMult = 154,
    kHealRateMult = 155,
    kMagickaRateMult = 156,
    kStaminaRateMult = 157,
    kWerewolfPerks = 158,
    kVampirePerks = 159,
    kGrabActorOffset = 160,
    kGrabbed = 161,
    kDEPRECATED05 = 162,
    kReflectDamage = 163,

    kTotal
}

public class Utility
{
    public static string[] ActorValue =
    {
        "kNone",
        "kAggression",
        "kConfidence",
        "kEnergy",
        "kMorality",
        "kMood",
        "kAssistance",
        "kOneHanded",
        "kTwoHanded",
        "kArchery",
        "kBlock",
        "kSmithing",
        "kHeavyArmor",
        "kLightArmor",
        "kPickpocket",
        "kLockpicking",
        "kSneak",
        "kAlchemy",
        "kSpeech",
        "kAlteration",
        "kConjuration",
        "kDestruction",
        "kIllusion",
        "kRestoration",
        "kEnchanting",
        "kHealth",
        "kMagicka",
        "kStamina",
        "kHealRate",
        "kMagickaRate",
        "kStaminaRate",
        "kSpeedMult",
        "kInventoryWeight",
        "kCarryWeight",
        "kCriticalChance",
        "kMeleeDamage",
        "kUnarmedDamage",
        "kMass",
        "kVoicePoints",
        "kVoiceRate",
        "kDamageResist",
        "kPoisonResist",
        "kResistFire",
        "kResistShock",
        "kResistFrost",
        "kResistMagic",
        "kResistDisease",
        "kPerceptionCondition",
        "kEnduranceCondition",
        "kLeftAttackCondition",
        "kRightAttackCondition",
        "kLeftMobilityCondition",
        "kRightMobilityCondition",
        "kBrainCondition",
        "kParalysis",
        "kInvisibility",
        "kNightEye",
        "kDetectLifeRange",
        "kWaterBreathing",
        "kWaterWalking",
        "kIgnoreCrippledLimbs",
        "kFame",
        "kInfamy",
        "kJumpingBonus",
        "kWardPower",
        "kRightItemCharge",
        "kArmorPerks",
        "kShieldPerks",
        "kWardDeflection",
        "kVariable01",
        "kVariable02",
        "kVariable03",
        "kVariable04",
        "kVariable05",
        "kVariable06",
        "kVariable07",
        "kVariable08",
        "kVariable09",
        "kVariable10",
        "kBowSpeedBonus",
        "kFavorActive",
        "kFavorsPerDay",
        "kFavorsPerDayTimer",
        "kLeftItemCharge",
        "kAbsorbChance",
        "kBlindness",
        "kWeaponSpeedMult",
        "kShoutRecoveryMult",
        "kBowStaggerBonus",
        "kTelekinesis",
        "kFavorPointsBonus",
        "kLastBribedIntimidated",
        "kLastFlattered",
        "kMovementNoiseMult",
        "kBypassVendorStolenCheck",
        "kBypassVendorKeywordCheck",
        "kWaitingForPlayer",
        "kOneHandedModifier",
        "kTwoHandedModifier",
        "kMarksmanModifier",
        "kBlockModifier",
        "kSmithingModifier",
        "kHeavyArmorModifier",
        "kLightArmorModifier",
        "kPickpocketModifier",
        "kLockpickingModifier",
        "kSneakingModifier",
        "kAlchemyModifier",
        "kSpeechcraftModifier",
        "kAlterationModifier",
        "kConjurationModifier",
        "kDestructionModifier",
        "kIllusionModifier",
        "kRestorationModifier",
        "kEnchantingModifier",
        "kOneHandedSkillAdvance",
        "kTwoHandedSkillAdvance",
        "kMarksmanSkillAdvance",
        "kBlockSkillAdvance",
        "kSmithingSkillAdvance",
        "kHeavyArmorSkillAdvance",
        "kLightArmorSkillAdvance",
        "kPickpocketSkillAdvance",
        "kLockpickingSkillAdvance",
        "kSneakingSkillAdvance",
        "kAlchemySkillAdvance",
        "kSpeechcraftSkillAdvance",
        "kAlterationSkillAdvance",
        "kConjurationSkillAdvance",
        "kDestructionSkillAdvance",
        "kIllusionSkillAdvance",
        "kRestorationSkillAdvance",
        "kEnchantingSkillAdvance",
        "kLeftWeaponSpeedMultiply",
        "kDragonSouls",
        "kCombatHealthRegenMultiply",
        "kOneHandedPowerModifier",
        "kTwoHandedPowerModifier",
        "kMarksmanPowerModifier",
        "kBlockPowerModifier",
        "kSmithingPowerModifier",
        "kHeavyArmorPowerModifier",
        "kLightArmorPowerModifier",
        "kPickpocketPowerModifier",
        "kLockpickingPowerModifier",
        "kSneakingPowerModifier",
        "kAlchemyPowerModifier",
        "kSpeechcraftPowerModifier",
        "kAlterationPowerModifier",
        "kConjurationPowerModifier",
        "kDestructionPowerModifier",
        "kIllusionPowerModifier",
        "kRestorationPowerModifier",
        "kEnchantingPowerModifier",
        "kDragonRend",
        "kAttackDamageMult",
        "kHealRateMult",
        "kMagickaRateMult",
        "kStaminaRateMult",
        "kWerewolfPerks",
        "kVampirePerks",
        "kGrabActorOffset",
        "kGrabbed",
        "kDEPRECATED05",
        "kReflectDamage",
    };

    public static string ToString(ActorValue av)
    {
        return ActorValue[(Int64)av + 1];
    }

    public static ActorValue ToActorValue(string av)
    {
        for (int i = 0; i < ActorValue.Length; i++)
        {
            if (ActorValue[i] == av)
                return (ActorValue)(i - 1);
        }
        return global::ActorValue.kNone;
    }

    public static Alchem ConvertToAlchemyEffect(ActorValue val)
    {
        switch (val)
        {
            case global::ActorValue.kHealth:
                return new Alchem(AlchemyBaseEffectFirst.kNone, AlchemyBaseEffectSecond.kHealth);
                break;
            case global::ActorValue.kMagicka:
                return new Alchem(AlchemyBaseEffectFirst.kNone, AlchemyBaseEffectSecond.kMagicka);
                break;
            case global::ActorValue.kStamina:
                return new Alchem(AlchemyBaseEffectFirst.kNone, AlchemyBaseEffectSecond.kStamina);
                break;
            case global::ActorValue.kOneHanded:
            case global::ActorValue.kOneHandedModifier:
            case global::ActorValue.kOneHandedPowerModifier:
                return new Alchem(AlchemyBaseEffectFirst.kNone, AlchemyBaseEffectSecond.kOneHanded);
                break;
            case global::ActorValue.kTwoHanded:
            case global::ActorValue.kTwoHandedModifier:
            case global::ActorValue.kTwoHandedPowerModifier:
                return new Alchem(AlchemyBaseEffectFirst.kNone, AlchemyBaseEffectSecond.kTwoHanded);
                break;
            case global::ActorValue.kArchery:
            case global::ActorValue.kMarksmanModifier:
            case global::ActorValue.kMarksmanPowerModifier:
                return new Alchem(AlchemyBaseEffectFirst.kNone, AlchemyBaseEffectSecond.kArchery);
                break;
            case global::ActorValue.kBlock:
            case global::ActorValue.kBlockModifier:
            case global::ActorValue.kBlockPowerModifier:
                return new Alchem(AlchemyBaseEffectFirst.kNone, AlchemyBaseEffectSecond.kBlock);
                break;
            case global::ActorValue.kSmithing:
            case global::ActorValue.kSmithingModifier:
            case global::ActorValue.kSmithingPowerModifier:
                return new Alchem(AlchemyBaseEffectFirst.kNone, AlchemyBaseEffectSecond.kSmithing);
                break;
            case global::ActorValue.kHeavyArmor:
            case global::ActorValue.kHeavyArmorModifier:
            case global::ActorValue.kHeavyArmorPowerModifier:
                return new Alchem(AlchemyBaseEffectFirst.kNone, AlchemyBaseEffectSecond.kHeavyArmor);
                break;
            case global::ActorValue.kLightArmor:
            case global::ActorValue.kLightArmorModifier:
            case global::ActorValue.kLightArmorSkillAdvance:
                return new Alchem(AlchemyBaseEffectFirst.kNone, AlchemyBaseEffectSecond.kLightArmor);
                break;
            case global::ActorValue.kPickpocket:
            case global::ActorValue.kPickpocketModifier:
            case global::ActorValue.kPickpocketPowerModifier:
                return new Alchem(AlchemyBaseEffectFirst.kNone, AlchemyBaseEffectSecond.kPickpocket);
                break;
            case global::ActorValue.kLockpicking:
            case global::ActorValue.kLockpickingModifier:
            case global::ActorValue.kLockpickingPowerModifier:
                return new Alchem(AlchemyBaseEffectFirst.kNone, AlchemyBaseEffectSecond.kLockpicking);
                break;
            case global::ActorValue.kSneak:
            case global::ActorValue.kSneakingModifier:
            case global::ActorValue.kSneakingPowerModifier:
                return new Alchem(AlchemyBaseEffectFirst.kNone, AlchemyBaseEffectSecond.kSneak);
                break;
            case global::ActorValue.kAlchemy:
            case global::ActorValue.kAlchemyModifier:
            case global::ActorValue.kAlchemyPowerModifier:
                return new Alchem(AlchemyBaseEffectFirst.kNone, AlchemyBaseEffectSecond.kAlchemy);
                break;
            case global::ActorValue.kSpeech:
            case global::ActorValue.kSpeechcraftModifier:
            case global::ActorValue.kSpeechcraftPowerModifier:
                return new Alchem(AlchemyBaseEffectFirst.kNone, AlchemyBaseEffectSecond.kSpeech);
                break;
            case global::ActorValue.kAlteration:
            case global::ActorValue.kAlterationModifier:
            case global::ActorValue.kAlterationPowerModifier:
                return new Alchem(AlchemyBaseEffectFirst.kNone, AlchemyBaseEffectSecond.kAlteration);
                break;
            case global::ActorValue.kConjuration:
            case global::ActorValue.kConjurationModifier:
            case global::ActorValue.kConjurationPowerModifier:
                return new Alchem(AlchemyBaseEffectFirst.kNone, AlchemyBaseEffectSecond.kConjuration);
                break;
            case global::ActorValue.kDestruction:
            case global::ActorValue.kDestructionModifier:
            case global::ActorValue.kDestructionPowerModifier:
                return new Alchem(AlchemyBaseEffectFirst.kNone, AlchemyBaseEffectSecond.kDestruction);
                break;
            case global::ActorValue.kIllusion:
            case global::ActorValue.kIllusionModifier:
            case global::ActorValue.kIllusionPowerModifier:
                return new Alchem(AlchemyBaseEffectFirst.kNone, AlchemyBaseEffectSecond.kIllusion);
                break;
            case global::ActorValue.kRestoration:
            case global::ActorValue.kRestorationModifier:
            case global::ActorValue.kRestorationPowerModifier:
                return new Alchem(AlchemyBaseEffectFirst.kNone, AlchemyBaseEffectSecond.kRestoration);
                break;
            case global::ActorValue.kEnchanting:
            case global::ActorValue.kEnchantingModifier:
            case global::ActorValue.kEnchantingPowerModifier:
                return new Alchem(AlchemyBaseEffectFirst.kNone, AlchemyBaseEffectSecond.kEnchanting);
                break;
            case global::ActorValue.kHealRate:
                return new Alchem(AlchemyBaseEffectFirst.kNone, AlchemyBaseEffectSecond.kHealRate);
                break;
            case global::ActorValue.kMagickaRate:
                return new Alchem(AlchemyBaseEffectFirst.kNone, AlchemyBaseEffectSecond.kMagickaRate);
                break;
            case global::ActorValue.kStaminaRate:
                return new Alchem(AlchemyBaseEffectFirst.kNone, AlchemyBaseEffectSecond.kStaminaRate);
                break;
            case global::ActorValue.kSpeedMult:
                return new Alchem(AlchemyBaseEffectFirst.kNone, AlchemyBaseEffectSecond.kSpeedMult);
                break;
            //case global::ActorValue.kInventoryWeight:
            //	break;
            case global::ActorValue.kCarryWeight:
                return new Alchem(AlchemyBaseEffectFirst.kNone, AlchemyBaseEffectSecond.kCarryWeight);
                break;
            case global::ActorValue.kCriticalChance:
                return new Alchem(AlchemyBaseEffectFirst.kNone, AlchemyBaseEffectSecond.kCriticalChance);
                break;
            case global::ActorValue.kMeleeDamage:
                return new Alchem(AlchemyBaseEffectFirst.kNone, AlchemyBaseEffectSecond.kMeleeDamage);
                break;
            case global::ActorValue.kUnarmedDamage:
                return new Alchem(AlchemyBaseEffectFirst.kNone, AlchemyBaseEffectSecond.kUnarmedDamage);
                break;
            case global::ActorValue.kDamageResist:
                return new Alchem(AlchemyBaseEffectFirst.kNone, AlchemyBaseEffectSecond.kDamageResist);
                break;
            case global::ActorValue.kPoisonResist:
                return new Alchem(AlchemyBaseEffectFirst.kNone, AlchemyBaseEffectSecond.kPoisonResist);
                break;
            case global::ActorValue.kResistFire:
                return new Alchem(AlchemyBaseEffectFirst.kNone, AlchemyBaseEffectSecond.kResistFire);
                break;
            case global::ActorValue.kResistShock:
                return new Alchem(AlchemyBaseEffectFirst.kNone, AlchemyBaseEffectSecond.kResistShock);
                break;
            case global::ActorValue.kResistFrost:
                return new Alchem(AlchemyBaseEffectFirst.kNone, AlchemyBaseEffectSecond.kResistFrost);
                break;
            case global::ActorValue.kResistMagic:
                return new Alchem(AlchemyBaseEffectFirst.kNone, AlchemyBaseEffectSecond.kResistMagic);
                break;
            case global::ActorValue.kResistDisease:
                return new Alchem(AlchemyBaseEffectFirst.kNone, AlchemyBaseEffectSecond.kResistDisease);
                break;
            case global::ActorValue.kParalysis:
                return new Alchem(AlchemyBaseEffectFirst.kNone, AlchemyBaseEffectSecond.kParalysis);
                break;
            case global::ActorValue.kInvisibility:
                return new Alchem(AlchemyBaseEffectFirst.kNone, AlchemyBaseEffectSecond.kInvisibility);
                break;
            case global::ActorValue.kWeaponSpeedMult:
            case global::ActorValue.kLeftWeaponSpeedMultiply:
                return new Alchem(AlchemyBaseEffectFirst.kNone, AlchemyBaseEffectSecond.kWeaponSpeedMult);
                break;
            case global::ActorValue.kBowSpeedBonus:
                return new Alchem(AlchemyBaseEffectFirst.kNone, AlchemyBaseEffectSecond.kBowSpeed);
                break;
            case global::ActorValue.kAttackDamageMult:
                return new Alchem(AlchemyBaseEffectFirst.kNone, AlchemyBaseEffectSecond.kAttackDamageMult);
                break;
            case global::ActorValue.kHealRateMult:
                return new Alchem(AlchemyBaseEffectFirst.kNone, AlchemyBaseEffectSecond.kHealRateMult);
                break;
            case global::ActorValue.kMagickaRateMult:
                return new Alchem(AlchemyBaseEffectFirst.kNone, AlchemyBaseEffectSecond.kMagickaRateMult);
                break;
            case global::ActorValue.kStaminaRateMult:
                return new Alchem(AlchemyBaseEffectFirst.kNone, AlchemyBaseEffectSecond.kStaminaRateMult);
                break;
            case global::ActorValue.kAggression:
                return new Alchem(AlchemyBaseEffectFirst.kNone, AlchemyBaseEffectSecond.kFrenzy);
                break;
            case global::ActorValue.kConfidence:
                return new Alchem(AlchemyBaseEffectFirst.kNone, AlchemyBaseEffectSecond.kFear);
                break;
            case global::ActorValue.kReflectDamage:
                return new Alchem(AlchemyBaseEffectFirst.kNone, AlchemyBaseEffectSecond.kReflectDamage);
                break;
            case global::ActorValue.kWaterBreathing:
                return new Alchem(AlchemyBaseEffectFirst.kNone, AlchemyBaseEffectSecond.kWaterbreathing);
                break;
            default:
                return new Alchem(AlchemyBaseEffectFirst.kNone, AlchemyBaseEffectSecond.kNone);
                break;
        }
    }


    public static string ToString(Alchem ae)
	{
        if (ae.firstenum)
        {
            switch (ae._first)
            {
                case AlchemyBaseEffectFirst.kNone:
                    return "None";
                default:
                    return "Unknown";
            }
        }
        else
        {
            switch (ae._second)
            {
                case AlchemyBaseEffectSecond.kAlteration:
                    return "Alteration";
                case AlchemyBaseEffectSecond.kAnyFood:
                    return "AnyFood";
                case AlchemyBaseEffectSecond.kAnyFortify:
                    return "AnyFortify";
                case AlchemyBaseEffectSecond.kAnyPoison:
                    return "AnyPoison";
                case AlchemyBaseEffectSecond.kAnyPotion:
                    return "AnyPotion";
                case AlchemyBaseEffectSecond.kArchery:
                    return "Archery";
                case AlchemyBaseEffectSecond.kAttackDamageMult:
                    return "AttackDamageMult";
                case AlchemyBaseEffectSecond.kBlock:
                    return "Block";
                case AlchemyBaseEffectSecond.kBlood:
                    return "Blood";
                case AlchemyBaseEffectSecond.kBowSpeed:
                    return "BowSpeed";
                case AlchemyBaseEffectSecond.kConjuration:
                    return "Conjuration";
                case AlchemyBaseEffectSecond.kCriticalChance:
                    return "CriticalChance";
                case AlchemyBaseEffectSecond.kDamageResist:
                    return "DamageResist";
                case AlchemyBaseEffectSecond.kDestruction:
                    return "Destruction";
                case AlchemyBaseEffectSecond.kFear:
                    return "Fear";
                case AlchemyBaseEffectSecond.kFrenzy:
                    return "Frenzy";
                case AlchemyBaseEffectSecond.kHealRate:
                    return "HealRate";
                case AlchemyBaseEffectSecond.kHealRateMult:
                    return "HealRateMult";
                case AlchemyBaseEffectSecond.kHealth:
                    return "Health";
                case AlchemyBaseEffectSecond.kHeavyArmor:
                    return "HeavyArmor";
                case AlchemyBaseEffectSecond.kIllusion:
                    return "Illusion";
                case AlchemyBaseEffectSecond.kInvisibility:
                    return "Invisibility";
                case AlchemyBaseEffectSecond.kLightArmor:
                    return "LightArmor";
                case AlchemyBaseEffectSecond.kLockpicking:
                    return "Lockpicking";
                case AlchemyBaseEffectSecond.kMagicka:
                    return "Magicka";
                case AlchemyBaseEffectSecond.kMagickaRate:
                    return "MagickaRate";
                case AlchemyBaseEffectSecond.kMagickaRateMult:
                    return "MagickaRateMult";
                case AlchemyBaseEffectSecond.kMeleeDamage:
                    return "MeleeDamage";
                case AlchemyBaseEffectSecond.kNone:
                    return "None";
                case AlchemyBaseEffectSecond.kOneHanded:
                    return "OneHanded";
                case AlchemyBaseEffectSecond.kParalysis:
                    return "Paralysis";
                case AlchemyBaseEffectSecond.kPickpocket:
                    return "Pickpocket";
                case AlchemyBaseEffectSecond.kPoisonResist:
                    return "PoisonResist";
                case AlchemyBaseEffectSecond.kReflectDamage:
                    return "ReflectDamage";
                case AlchemyBaseEffectSecond.kResistDisease:
                    return "ResistDisease";
                case AlchemyBaseEffectSecond.kResistFire:
                    return "ResistFire";
                case AlchemyBaseEffectSecond.kResistFrost:
                    return "ResistFrost";
                case AlchemyBaseEffectSecond.kResistMagic:
                    return "ResistMagic";
                case AlchemyBaseEffectSecond.kResistShock:
                    return "ResistShock";
                case AlchemyBaseEffectSecond.kRestoration:
                    return "Restoration";
                case AlchemyBaseEffectSecond.kSneak:
                    return "Sneak";
                case AlchemyBaseEffectSecond.kSpeedMult:
                    return "SpeedMult";
                case AlchemyBaseEffectSecond.kStamina:
                    return "Stamina";
                case AlchemyBaseEffectSecond.kStaminaRate:
                    return "StaminaRate";
                case AlchemyBaseEffectSecond.kStaminaRateMult:
                    return "StaminaRateMult";
                case AlchemyBaseEffectSecond.kTwoHanded:
                    return "TwoHanded";
                case AlchemyBaseEffectSecond.kUnarmedDamage:
                    return "UnarmedDamage";
                case AlchemyBaseEffectSecond.kWeaponSpeedMult:
                    return "WeapenSpeedMult";
                case AlchemyBaseEffectSecond.kCureDisease:
                    return "CureDisease";
                case AlchemyBaseEffectSecond.kCurePoison:
                    return "CurePoison";
                case AlchemyBaseEffectSecond.kEnchanting:
                    return "Enchanting";
                case AlchemyBaseEffectSecond.kWaterbreathing:
                    return "Waterbreathing";
                case AlchemyBaseEffectSecond.kSmithing:
                    return "Smithing";
                case AlchemyBaseEffectSecond.kSpeech:
                    return "Speech";
                case AlchemyBaseEffectSecond.kCarryWeight:
                    return "CarryWeight";
                case AlchemyBaseEffectSecond.kAlchemy:
                    return "Alchemy";
                case AlchemyBaseEffectSecond.kPersuasion:
                    return "Persuasion";
                case AlchemyBaseEffectSecond.kFortifyHealth:
                    return "FortifyHealth";
                case AlchemyBaseEffectSecond.kFortifyMagicka:
                    return "FortifyMagicka";
                case AlchemyBaseEffectSecond.kFortifyStamina:
                    return "FortifyStamina";
                case AlchemyBaseEffectSecond.kShield:
                    return "Shield";
                case AlchemyBaseEffectSecond.kCustom:
                    return "Custom";
                default:
                    return "Unknown";
            }
        }
	}

    /*public static string ToString(Alchem alch)
    {
        string ret = "|";
        if (alch.firstenum)
        {
            UInt64 ae = (UInt64)alch._first;
        }
        else
        {
            UInt64 ae = (UInt64)alch._second;
            if (((ae & (UInt64)(AlchemyBaseEffectSecond.kAlteration)) > 0))
                ret += "Alteration|";
            if ((ae & (UInt64)(AlchemyBaseEffectSecond.kArchery)) > 0)
                ret += "Archery|";
            if ((ae & (UInt64)(AlchemyBaseEffectSecond.kAttackDamageMult)) > 0)
                ret += "AttackDamageMult|";
            if ((ae & (UInt64)(AlchemyBaseEffectSecond.kBlock)) > 0)
                ret += "Block|";
            if ((ae & (UInt64)(AlchemyBaseEffectSecond.kBlood)) > 0)
                ret += "Blood|";
            if ((ae & (UInt64)(AlchemyBaseEffectSecond.kBowSpeed)) > 0)
                ret += "BowSpeed|";
            if ((ae & (UInt64)(AlchemyBaseEffectSecond.kConjuration)) > 0)
                ret += "Conjuration|";
            if ((ae & (UInt64)(AlchemyBaseEffectSecond.kCriticalChance)) > 0)
                ret += "CriticalChance|";
            if ((ae & (UInt64)(AlchemyBaseEffectSecond.kDamageResist)) > 0)
                ret += "DamageResist|";
            if ((ae & (UInt64)(AlchemyBaseEffectSecond.kDestruction)) > 0)
                ret += "Destruction|";
            if ((ae & (UInt64)(AlchemyBaseEffectSecond.kFear)) > 0)
                ret += "Fear|";
            if ((ae & (UInt64)(AlchemyBaseEffectSecond.kFrenzy)) > 0)
                ret += "Frenzy|";
            if ((ae & (UInt64)(AlchemyBaseEffectSecond.kHealRate)) > 0)
                ret += "HealRate|";
            if ((ae & (UInt64)(AlchemyBaseEffectSecond.kHealRateMult)) > 0)
                ret += "HealRateMult|";
            if ((ae & (UInt64)(AlchemyBaseEffectSecond.kHealth)) > 0)
                ret += "Health|";
            if ((ae & (UInt64)(AlchemyBaseEffectSecond.kHeavyArmor)) > 0)
                ret += "HeavyArmor|";
            if ((ae & (UInt64)(AlchemyBaseEffectSecond.kIllusion)) > 0)
                ret += "Illusion|";
            if ((ae & (UInt64)(AlchemyBaseEffectSecond.kInvisibility)) > 0)
                ret += "Invisibility|";
            if ((ae & (UInt64)(AlchemyBaseEffectSecond.kLightArmor)) > 0)
                ret += "LightArmor|";
            if ((ae & (UInt64)(AlchemyBaseEffectSecond.kLockpicking)) > 0)
                ret += "Lockpicking|";
            if ((ae & (UInt64)(AlchemyBaseEffectSecond.kMagicka)) > 0)
                ret += "Magicka|";
            if ((ae & (UInt64)(AlchemyBaseEffectSecond.kMagickaRate)) > 0)
                ret += "MagickaRate|";
            if ((ae & (UInt64)(AlchemyBaseEffectSecond.kMagickaRateMult)) > 0)
                ret += "MagickaRateMult|";
            if ((ae & (UInt64)(AlchemyBaseEffectSecond.kMeleeDamage)) > 0)
                ret += "MeleeDamage|";
            if ((ae & (UInt64)(AlchemyBaseEffectSecond.kNone)) > 0)
                ret += "None|";
            if ((ae & (UInt64)(AlchemyBaseEffectSecond.kOneHanded)) > 0)
                ret += "OneHanded|";
            if ((ae & (UInt64)(AlchemyBaseEffectSecond.kParalysis)) > 0)
                ret += "Paralysis|";
            if ((ae & (UInt64)(AlchemyBaseEffectSecond.kPickpocket)) > 0)
                ret += "Pickpocket|";
            if ((ae & (UInt64)(AlchemyBaseEffectSecond.kPoisonResist)) > 0)
                ret += "PoisonResist|";
            if ((ae & (UInt64)(AlchemyBaseEffectSecond.kReflectDamage)) > 0)
                ret += "ReflectDamage|";
            if ((ae & (UInt64)(AlchemyBaseEffectSecond.kResistDisease)) > 0)
                ret += "ResistDisease|";
            if ((ae & (UInt64)(AlchemyBaseEffectSecond.kResistFire)) > 0)
                ret += "ResistFire|";
            if ((ae & (UInt64)(AlchemyBaseEffectSecond.kResistFrost)) > 0)
                ret += "ResistFrost|";
            if ((ae & (UInt64)(AlchemyBaseEffectSecond.kResistMagic)) > 0)
                ret += "ResistMagic|";
            if ((ae & (UInt64)(AlchemyBaseEffectSecond.kResistShock)) > 0)
                ret += "ResistShock|";
            if ((ae & (UInt64)(AlchemyBaseEffectSecond.kRestoration)) > 0)
                ret += "Restoration|";
            if ((ae & (UInt64)(AlchemyBaseEffectSecond.kSneak)) > 0)
                ret += "Sneak|";
            if ((ae & (UInt64)(AlchemyBaseEffectSecond.kSpeedMult)) > 0)
                ret += "SpeedMult|";
            if ((ae & (UInt64)(AlchemyBaseEffectSecond.kStamina)) > 0)
                ret += "Stamina|";
            if ((ae & (UInt64)(AlchemyBaseEffectSecond.kStaminaRate)) > 0)
                ret += "StaminaRate|";
            if ((ae & (UInt64)(AlchemyBaseEffectSecond.kStaminaRateMult)) > 0)
                ret += "StaminaRateMult|";
            if ((ae & (UInt64)(AlchemyBaseEffectSecond.kTwoHanded)) > 0)
                ret += "TwoHanded|";
            if ((ae & (UInt64)(AlchemyBaseEffectSecond.kUnarmedDamage)) > 0)
                ret += "UnarmedDamage|";
            if ((ae & (UInt64)(AlchemyBaseEffectSecond.kWeaponSpeedMult)) > 0)
                ret += "WeapenSpeedMult|";
            if ((ae & (UInt64)(AlchemyBaseEffectSecond.kCureDisease)) > 0)
                ret += "CureDisease|";
            if ((ae & (UInt64)(AlchemyBaseEffectSecond.kCurePoison)) > 0)
                ret += "CurePoison|";
            if ((ae & (UInt64)(AlchemyBaseEffectSecond.kEnchanting)) > 0)
                ret += "Enchanting|";
            if ((ae & (UInt64)(AlchemyBaseEffectSecond.kWaterbreathing)) > 0)
                ret += "Waterbreathing|";
            if ((ae & (UInt64)(AlchemyBaseEffectSecond.kSmithing)) > 0)
                ret += "Smithing|";
            if ((ae & (UInt64)(AlchemyBaseEffectSecond.kSpeech)) > 0)
                ret += "Speech|";
            if ((ae & (UInt64)(AlchemyBaseEffectSecond.kCarryWeight)) > 0)
                ret += "CarryWeight|";
            if ((ae & (UInt64)(AlchemyBaseEffectSecond.kAlchemy)) > 0)
                ret += "Alchemy|";
            if ((ae & (UInt64)(AlchemyBaseEffectSecond.kPersuasion)) > 0)
                ret += "Persuasion|";
            if ((ae & (UInt64)(AlchemyBaseEffectSecond.kFortifyHealth)) > 0)
                ret += "FortifyHealth|";
            if ((ae & (UInt64)(AlchemyBaseEffectSecond.kFortifyMagicka)) > 0)
                ret += "FortifyMagicka|";
            if ((ae & (UInt64)(AlchemyBaseEffectSecond.kFortifyStamina)) > 0)
                ret += "FortifyStamina|";
            if ((ae & (UInt64)(AlchemyBaseEffectSecond.kShield)) > 0)
                ret += "Shield|";
            if ((ae & (UInt64)(AlchemyBaseEffectSecond.kCustom)) > 0)
                ret += "Custom|";
        }
        if (ret == "|")
            return "|Unknown|";
        return ret;
    }*/

    public static int ToIndex(Alchem eff)
    {
        if (eff.firstenum == false)
        {
            for (int i = 0; i <= 63; i++)
            {
                if ((eff._second & (AlchemyBaseEffectSecond)((UInt64)1 << i)) > 0) return i + 1;
            }
        }
        else
        {
            for (int i = 0; i <= 63; i++)
            {
                if ((eff._first & (AlchemyBaseEffectFirst)((UInt64)1 << i)) > 0) return i + 1;
            }
        }
        return 0;
    }

    public static void CalcReferences(Effects eff)
    {
        // calculate references
        eff.References.Clear();
        eff.ReferencesPotions.Clear();
        foreach (var ing in Ingredient.ingredients)
        {
            if (ing.Effect1 == eff.name)
                eff.References.Add(ing);
            else if (ing.Effect2 == eff.name)
                eff.References.Add(ing);
            else if (ing.Effect3 == eff.name)
                eff.References.Add(ing);
            else if (ing.Effect4 == eff.name)
                eff.References.Add(ing);
        }
        foreach (var pot in Potion.potions)
        {
            if (pot.Effect1 == eff.name)
                eff.ReferencesPotions.Add(pot);
            else if (pot.Effect2 == eff.name)
                eff.ReferencesPotions.Add(pot);
            else if (pot.Effect3 == eff.name)
                eff.ReferencesPotions.Add(pot);
            else if (pot.Effect4 == eff.name)
                eff.ReferencesPotions.Add(pot);
            else if (pot.Effect5 == eff.name)
                eff.ReferencesPotions.Add(pot);
            else if (pot.Effect6 == eff.name)
                eff.ReferencesPotions.Add(pot);
        }
    }

    public static void CalcAllReferences()
    {
        foreach (var eff in Effects.effects)
        {
            CalcReferences(eff.Value);
        }
    }

}

public class Settings
{
    public struct Effects
    {

        public enum Identifier
        {
            _None = 0,
            _MagPositiveScaleBasicIdent = 0xFFFFF00,
            _MagPositiveScaleBasicRareIdent = 0xFFFFF01,
            _MagPositiveScaleBasicTimeIdent = 0xFFFFF02,
            _MagPositiveScaleTimeIdent = 0xFFFFF03,
            _MagPositiveScaleTimeRareIdent = 0xFFFFF04,
            _MagPositiveScaleTimeEpicIdent = 0xFFFFF05,
            _MagNegativeScaleBasicIdent = 0xFFFFF06,
            _MagNegativeScaleBasicRareIdent = 0xFFFFF07,
            _MagNegativeScaleBasicTimeIdent = 0xFFFFF08,
            _MagNegativeScaleTimeIdent = 0xFFFFF09,
            _MagNegativeScaleTimeRareIdent = 0xFFFFF0A,
            _MagNegativeScaleTimeEpicIdent = 0xFFFFF0B,
            _DurPositiveBasicIdent = 0xFFFFF0C,
            _DurPositiveBasicTimeIdent = 0xFFFFF0D,
            _DurPositiveTimeIdent = 0xFFFFF0E,
            _DurPositiveTimeAltIdent = 0xFFFFF17,
            _DurPositiveTimeRareIdent = 0xFFFFF0F,
            _DurPositiveTimeEpicIdent = 0xFFFFF10,
            _DurNegativeBasicIdent = 0xFFFFF11,
            _DurNegativeBasicTimeIdent = 0xFFFFF12,
            _DurNegativeTimeIdent = 0xFFFFF13,
            _DurNegativeTimeAltIdent = 0xFFFFF16,
            _DurNegativeTimeRareIdent = 0xFFFFF14,
            _DurNegativeTimeEpicIdent = 0xFFFFF15,

            // max : 0xFFFFF17
        }

        /// <summary>
        /// Magnitude scale factor for positive basic effects (e.g. Restore Health)
        /// </summary>
        static readonly float _MagPositiveScaleBasic;
        /// <summary>
        /// Magnitude scale factor for rare positive basic effects (e.g. stronger Restore Health)
        /// </summary>
        static readonly float _MagPositiveScaleBasicRare;
        /// <summary>
        /// Magnitude scale factor for positive basic effects over time (e.g. Regenerate Health)
        /// </summary>
        static readonly float _MagPositiveScaleBasicTime;
        /// <summary>
        /// Magnitude scale factor for positive long-term effects (e.g. Fortify Block)
        /// </summary>
        static readonly float _MagPositiveScaleTime;
        /// <summary>
        /// Magnitude scale factor for rare positive long-term effects (e.g. Quick Drawing)
        /// </summary>
        static readonly float _MagPositiveScaleTimeRare;
        /// <summary>
        /// Magnitude scale factor for epic positive long-term effects (e.g. Reflect Damage)
        /// </summary>
        static readonly float _MagPositiveScaleTimeEpic;

        /// <summary>
        /// Magnitude scale for basic negative effects (e.g. Damage Health)
        /// </summary>
        static readonly float _MagNegativeScaleBasic;
        /// <summary>
        /// Magnitude scale for basic negative effects (e.g. Ravage Health)
        /// </summary>
        static readonly float _MagNegativeScaleBasicRare;
        /// <summary>
        /// Magnitude scale for basic negative effects (e.g. Lingering Damage Health)
        /// </summary>
        static readonly float _MagNegativeScaleBasicTime;
        /// <summary>
        /// Magnitude scale for negative long-term effects (e.g. Damage Block)
        /// </summary>
        static readonly float _MagNegativeScaleTime;
        /// <summary>
        /// Magnitude scale for rare negative long-term effects (e.g. Frailty)
        /// </summary>
        static readonly float _MagNegativeScaleTimeRare;
        /// <summary>
        /// Magnitude scale for epic negative long-term effects (e.g. )
        /// </summary>
        static readonly float _MagNegativeScaleTimeEpic;

        /// <summary>
        /// Duration for basic positive effects (e.g. Restore Health)
        /// </summary>
        static readonly float _DurPositiveBasic;
        /// <summary>
        /// Duration for basic positive effects over time (e.g. Regenerate Health)
        /// </summary>
        static readonly float _DurPositiveBasicTime;
        /// <summary>
        /// Duration for positive long-term effects (e.g. Fortify Block)
        /// </summary>
        static readonly float _DurPositiveTime;
        /// <summary>
        /// Duration for alternative positive long-term effects (e.g. Fortify Health Regeneration)
        /// </summary>
        static readonly float _DurPositiveTimeAlt;
        /// <summary>
        /// Duration for Rare positive long-term effects (e.g. Quick Drawing)
        /// </summary>
        static readonly float _DurPositiveTimeRare;
        /// <summary>
        /// Duration for Epic positive long-term effects (e.g. Reflect Damage)
        /// </summary>
        static readonly float _DurPositiveTimeEpic;

        /// <summary>
        /// Duration for basic negative effects (e.g. Damage Health)
        /// </summary>
        static readonly float _DurNegativeBasic;
        /// <summary>
        /// Duration for basic negative effects (e.g. Lingering Damage Health)
        /// </summary>
        static readonly float _DurNegativeBasicTime;
        /// <summary>
        /// Duration for negative long-term effects (e.g. Damage Block)
        /// </summary>
        static readonly float _DurNegativeTime;
        /// <summary>
        /// Duration for alternative negative long-term effects (e.g. Reduce Health Regen)
        /// </summary>
        static readonly float _DurNegativeTimeAlt;
        /// <summary>
        /// Duration for rare negative long-term effects (e.g. Frailty)
        /// </summary>
        static readonly float _DurNegativeTimeRare;
        /// <summary>
        /// Duration for epic negative long-term effects (e.g. )
        /// </summary>
        static readonly float _DurNegativeTimeEpic;

        public static Identifier GetType(int value)
        {
            switch (value)
            {
                case (int)(Identifier._MagPositiveScaleBasicIdent):
                    return Identifier._MagPositiveScaleBasicIdent;
                case (int)(Identifier._MagPositiveScaleBasicRareIdent):
                    return Identifier._MagPositiveScaleBasicRareIdent;
                case (int)(Identifier._MagPositiveScaleBasicTimeIdent):
                    return Identifier._MagPositiveScaleBasicTimeIdent;
                case (int)(Identifier._MagPositiveScaleTimeIdent):
                    return Identifier._MagPositiveScaleTimeIdent;
                case (int)(Identifier._MagPositiveScaleTimeRareIdent):
                    return Identifier._MagPositiveScaleTimeRareIdent;
                case (int)(Identifier._MagPositiveScaleTimeEpicIdent):
                    return Identifier._MagPositiveScaleTimeEpicIdent;
                case (int)(Identifier._MagNegativeScaleBasicIdent):
                    return Identifier._MagNegativeScaleBasicIdent;
                case (int)(Identifier._MagNegativeScaleBasicRareIdent):
                    return Identifier._MagNegativeScaleBasicRareIdent;
                case (int)(Identifier._MagNegativeScaleBasicTimeIdent):
                    return Identifier._MagNegativeScaleBasicTimeIdent;
                case (int)(Identifier._MagNegativeScaleTimeIdent):
                    return Identifier._MagNegativeScaleTimeIdent;
                case (int)(Identifier._MagNegativeScaleTimeRareIdent):
                    return Identifier._MagNegativeScaleTimeRareIdent;
                case (int)(Identifier._MagNegativeScaleTimeEpicIdent):
                    return Identifier._MagNegativeScaleTimeEpicIdent;
                case (int)(Identifier._DurPositiveBasicIdent):
                    return Identifier._DurPositiveBasicIdent;
                case (int)(Identifier._DurPositiveBasicTimeIdent):
                    return Identifier._DurPositiveBasicTimeIdent;
                case (int)(Identifier._DurPositiveTimeIdent):
                    return Identifier._DurPositiveTimeIdent;
                case (int)(Identifier._DurPositiveTimeAltIdent):
                    return Identifier._DurPositiveTimeAltIdent;
                case (int)(Identifier._DurPositiveTimeRareIdent):
                    return Identifier._DurPositiveTimeRareIdent;
                case (int)(Identifier._DurPositiveTimeEpicIdent):
                    return Identifier._DurPositiveTimeEpicIdent;
                case (int)(Identifier._DurNegativeBasicIdent):
                    return Identifier._DurNegativeBasicIdent;
                case (int)(Identifier._DurNegativeBasicTimeIdent):
                    return Identifier._DurNegativeBasicTimeIdent;
                case (int)(Identifier._DurNegativeTimeIdent):
                    return Identifier._DurNegativeTimeIdent;
                case (int)(Identifier._DurNegativeTimeAltIdent):
                    return Identifier._DurNegativeTimeAltIdent;
                case (int)(Identifier._DurNegativeTimeRareIdent):
                    return Identifier._DurNegativeTimeRareIdent;
                case (int)(Identifier._DurNegativeTimeEpicIdent):
                    return Identifier._DurNegativeTimeEpicIdent;
                default:
                    return Identifier._None;
            }
        }

        public static float GetValue(Identifier ident)
        {
            switch (ident)
            {
                case Identifier._MagPositiveScaleBasicIdent:
                    return _MagPositiveScaleBasic;
                case Identifier._MagPositiveScaleBasicRareIdent:
                    return _MagPositiveScaleBasicRare;
                case Identifier._MagPositiveScaleBasicTimeIdent:
                    return _MagPositiveScaleBasicTime;
                case Identifier._MagPositiveScaleTimeIdent:
                    return _MagPositiveScaleTime;
                case Identifier._MagPositiveScaleTimeRareIdent:
                    return _MagPositiveScaleTimeRare;
                case Identifier._MagPositiveScaleTimeEpicIdent:
                    return _MagPositiveScaleTimeEpic;
                case Identifier._MagNegativeScaleBasicIdent:
                    return _MagNegativeScaleBasic;
                case Identifier._MagNegativeScaleBasicRareIdent:
                    return _MagNegativeScaleBasicRare;
                case Identifier._MagNegativeScaleBasicTimeIdent:
                    return _MagNegativeScaleBasicTime;
                case Identifier._MagNegativeScaleTimeIdent:
                    return _MagNegativeScaleTime;
                case Identifier._MagNegativeScaleTimeRareIdent:
                    return _MagNegativeScaleTimeRare;
                case Identifier._MagNegativeScaleTimeEpicIdent:
                    return _MagNegativeScaleTimeEpic;
                case Identifier._DurPositiveBasicIdent:
                    return _DurPositiveBasic;
                case Identifier._DurPositiveBasicTimeIdent:
                    return _DurPositiveBasicTime;
                case Identifier._DurPositiveTimeIdent:
                    return _DurPositiveTime;
                case Identifier._DurPositiveTimeAltIdent:
                    return _DurPositiveTimeAlt;
                case Identifier._DurPositiveTimeRareIdent:
                    return _DurPositiveTimeRare;
                case Identifier._DurPositiveTimeEpicIdent:
                    return _DurPositiveTimeEpic;
                case Identifier._DurNegativeBasicIdent:
                    return _DurNegativeBasic;
                case Identifier._DurNegativeBasicTimeIdent:
                    return _DurNegativeBasicTime;
                case Identifier._DurNegativeTimeIdent:
                    return _DurNegativeTime;
                case Identifier._DurNegativeTimeAltIdent:
                    return _DurNegativeTimeAlt;
                case Identifier._DurNegativeTimeRareIdent:
                    return _DurNegativeTimeRare;
                case Identifier._DurNegativeTimeEpicIdent:
                    return _DurNegativeTimeEpic;
                default:
                    return 0;
            }
        }

        public static string[] conversion = {
            "MagPositiveScaleBasic".ToLower(),
            "MagPositiveScaleBasicRare".ToLower(),
            "MagPositiveScaleBasicTime".ToLower(),
            "MagPositiveScaleTime".ToLower(),
            "MagPositiveScaleTimeRare".ToLower(),
            "MagPositiveScaleTimeEpic".ToLower(),
            "MagNegativeScaleBasic".ToLower(),
            "MagNegativeScaleBasicRare".ToLower(),
            "MagNegativeScaleBasicTime".ToLower(),
            "MagNegativeScaleTime".ToLower(),
            "MagNegativeScaleTimeRare".ToLower(),
            "MagNegativeScaleTimeEpic".ToLower(),
            "DurPositiveBasic".ToLower(),
            "DurPositiveBasicTime".ToLower(),
            "DurPositiveTime".ToLower(),
            "DurPositiveTimeAlt".ToLower(),
            "DurPositiveTimeRare".ToLower(),
            "DurPositiveTimeEpic".ToLower(),
            "DurNegativeBasic".ToLower(),
            "DurNegativeBasicTime".ToLower(),
            "DurNegativeTime".ToLower(),
            "DurNegativeTimeAlt".ToLower(),
            "DurNegativeTimeRare".ToLower(),
            "DurNegativeTimeEpic".ToLower()
        };

        public static string ToString(Identifier ident)
        {
            switch (ident)
            {
                case Identifier._MagPositiveScaleBasicIdent:
                    return conversion[0];
                case Identifier._MagPositiveScaleBasicRareIdent:
                    return conversion[1];
                case Identifier._MagPositiveScaleBasicTimeIdent:
                    return conversion[2];
                case Identifier._MagPositiveScaleTimeIdent:
                    return conversion[3];
                case Identifier._MagPositiveScaleTimeRareIdent:
                    return conversion[4];
                case Identifier._MagPositiveScaleTimeEpicIdent:
                    return conversion[5];
                case Identifier._MagNegativeScaleBasicIdent:
                    return conversion[6];
                case Identifier._MagNegativeScaleBasicRareIdent:
                    return conversion[7];
                case Identifier._MagNegativeScaleBasicTimeIdent:
                    return conversion[8];
                case Identifier._MagNegativeScaleTimeIdent:
                    return conversion[9];
                case Identifier._MagNegativeScaleTimeRareIdent:
                    return conversion[10];
                case Identifier._MagNegativeScaleTimeEpicIdent:
                    return conversion[11];
                case Identifier._DurPositiveBasicIdent:
                    return conversion[12];
                case Identifier._DurPositiveBasicTimeIdent:
                    return conversion[13];
                case Identifier._DurPositiveTimeIdent:
                    return conversion[14];
                case Identifier._DurPositiveTimeAltIdent:
                    return conversion[15];
                case Identifier._DurPositiveTimeRareIdent:
                    return conversion[16];
                case Identifier._DurPositiveTimeEpicIdent:
                    return conversion[17];
                case Identifier._DurNegativeBasicIdent:
                    return conversion[18];
                case Identifier._DurNegativeBasicTimeIdent:
                    return conversion[19];
                case Identifier._DurNegativeTimeIdent:
                    return conversion[20];
                case Identifier._DurNegativeTimeAltIdent:
                    return conversion[21];
                case Identifier._DurNegativeTimeRareIdent:
                    return conversion[22];
                case Identifier._DurNegativeTimeEpicIdent:
                    return conversion[23];
                default:
                    return "";
            }
        }

        public static Identifier FromString(string str)
        {
            int index = int.MaxValue;
            for (int i = 0; i < conversion.Length; i++)
            {
                if (conversion[i] == str.ToLower())
                {
                    index = i;
                    break;
                }
            }
            switch (index)
            {
                case 0:
                    return Identifier._MagPositiveScaleBasicIdent;
                case 1:
                    return Identifier._MagPositiveScaleBasicRareIdent;
                case 2:
                    return Identifier._MagPositiveScaleBasicTimeIdent;
                case 3:
                    return Identifier._MagPositiveScaleTimeIdent;
                case 4:
                    return Identifier._MagPositiveScaleTimeRareIdent;
                case 5:
                    return Identifier._MagPositiveScaleTimeEpicIdent;
                case 6:
                    return Identifier._MagNegativeScaleBasicIdent;
                case 7:
                    return Identifier._MagNegativeScaleBasicRareIdent;
                case 8:
                    return Identifier._MagNegativeScaleBasicTimeIdent;
                case 9:
                    return Identifier._MagNegativeScaleTimeIdent;
                case 10:
                    return Identifier._MagNegativeScaleTimeRareIdent;
                case 11:
                    return Identifier._MagNegativeScaleTimeEpicIdent;
                case 12:
                    return Identifier._DurPositiveBasicIdent;
                case 13:
                    return Identifier._DurPositiveBasicTimeIdent;
                case 14:
                    return Identifier._DurPositiveTimeIdent;
                case 15:
                    return Identifier._DurPositiveTimeAltIdent;
                case 16:
                    return Identifier._DurPositiveTimeRareIdent;
                case 17:
                    return Identifier._DurPositiveTimeEpicIdent;
                case 18:
                    return Identifier._DurNegativeBasicIdent;
                case 19:
                    return Identifier._DurNegativeBasicTimeIdent;
                case 20:
                    return Identifier._DurNegativeTimeIdent;
                case 21:
                    return Identifier._DurNegativeTimeAltIdent;
                case 22:
                    return Identifier._DurNegativeTimeRareIdent;
                case 23:
                    return Identifier._DurNegativeTimeEpicIdent;
                default:
                    return Identifier._None;
            }
        }
    }
}