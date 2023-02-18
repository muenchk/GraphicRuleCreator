
using GraphicRuleCreator;
using System;
using System.Windows.Media.Effects;

public enum AlchemyEffect : UInt64
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
	kUnused1 = (UInt64)1 << 55,           // 80000000000000
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

    public static AlchemyEffect ConvertToAlchemyEffect(ActorValue val)
    {
        switch (val)
        {
            case global::ActorValue.kHealth:
                return (AlchemyEffect.kHealth);
                break;
            case global::ActorValue.kMagicka:
                return (AlchemyEffect.kMagicka);
                break;
            case global::ActorValue.kStamina:
                return (AlchemyEffect.kStamina);
                break;
            case global::ActorValue.kOneHanded:
            case global::ActorValue.kOneHandedModifier:
            case global::ActorValue.kOneHandedPowerModifier:
                return (AlchemyEffect.kOneHanded);
                break;
            case global::ActorValue.kTwoHanded:
            case global::ActorValue.kTwoHandedModifier:
            case global::ActorValue.kTwoHandedPowerModifier:
                return (AlchemyEffect.kTwoHanded);
                break;
            case global::ActorValue.kArchery:
            case global::ActorValue.kMarksmanModifier:
            case global::ActorValue.kMarksmanPowerModifier:
                return (AlchemyEffect.kArchery);
                break;
            case global::ActorValue.kBlock:
            case global::ActorValue.kBlockModifier:
            case global::ActorValue.kBlockPowerModifier:
                return (AlchemyEffect.kBlock);
                break;
            case global::ActorValue.kSmithing:
            case global::ActorValue.kSmithingModifier:
            case global::ActorValue.kSmithingPowerModifier:
                return (AlchemyEffect.kSmithing);
                break;
            case global::ActorValue.kHeavyArmor:
            case global::ActorValue.kHeavyArmorModifier:
            case global::ActorValue.kHeavyArmorPowerModifier:
                return (AlchemyEffect.kHeavyArmor);
                break;
            case global::ActorValue.kLightArmor:
            case global::ActorValue.kLightArmorModifier:
            case global::ActorValue.kLightArmorSkillAdvance:
                return (AlchemyEffect.kLightArmor);
                break;
            case global::ActorValue.kPickpocket:
            case global::ActorValue.kPickpocketModifier:
            case global::ActorValue.kPickpocketPowerModifier:
                return (AlchemyEffect.kPickpocket);
                break;
            case global::ActorValue.kLockpicking:
            case global::ActorValue.kLockpickingModifier:
            case global::ActorValue.kLockpickingPowerModifier:
                return (AlchemyEffect.kLockpicking);
                break;
            case global::ActorValue.kSneak:
            case global::ActorValue.kSneakingModifier:
            case global::ActorValue.kSneakingPowerModifier:
                return (AlchemyEffect.kSneak);
                break;
            case global::ActorValue.kAlchemy:
            case global::ActorValue.kAlchemyModifier:
            case global::ActorValue.kAlchemyPowerModifier:
                return (AlchemyEffect.kAlchemy);
                break;
            case global::ActorValue.kSpeech:
            case global::ActorValue.kSpeechcraftModifier:
            case global::ActorValue.kSpeechcraftPowerModifier:
                return (AlchemyEffect.kSpeech);
                break;
            case global::ActorValue.kAlteration:
            case global::ActorValue.kAlterationModifier:
            case global::ActorValue.kAlterationPowerModifier:
                return (AlchemyEffect.kAlteration);
                break;
            case global::ActorValue.kConjuration:
            case global::ActorValue.kConjurationModifier:
            case global::ActorValue.kConjurationPowerModifier:
                return (AlchemyEffect.kConjuration);
                break;
            case global::ActorValue.kDestruction:
            case global::ActorValue.kDestructionModifier:
            case global::ActorValue.kDestructionPowerModifier:
                return (AlchemyEffect.kDestruction);
                break;
            case global::ActorValue.kIllusion:
            case global::ActorValue.kIllusionModifier:
            case global::ActorValue.kIllusionPowerModifier:
                return (AlchemyEffect.kIllusion);
                break;
            case global::ActorValue.kRestoration:
            case global::ActorValue.kRestorationModifier:
            case global::ActorValue.kRestorationPowerModifier:
                return (AlchemyEffect.kRestoration);
                break;
            case global::ActorValue.kEnchanting:
            case global::ActorValue.kEnchantingModifier:
            case global::ActorValue.kEnchantingPowerModifier:
                return (AlchemyEffect.kEnchanting);
                break;
            case global::ActorValue.kHealRate:
                return (AlchemyEffect.kHealRate);
                break;
            case global::ActorValue.kMagickaRate:
                return (AlchemyEffect.kMagickaRate);
                break;
            case global::ActorValue.kStaminaRate:
                return (AlchemyEffect.kStaminaRate);
                break;
            case global::ActorValue.kSpeedMult:
                return (AlchemyEffect.kSpeedMult);
                break;
            //case global::ActorValue.kInventoryWeight:
            //	break;
            case global::ActorValue.kCarryWeight:
                return (AlchemyEffect.kCarryWeight);
                break;
            case global::ActorValue.kCriticalChance:
                return (AlchemyEffect.kCriticalChance);
                break;
            case global::ActorValue.kMeleeDamage:
                return (AlchemyEffect.kMeleeDamage);
                break;
            case global::ActorValue.kUnarmedDamage:
                return (AlchemyEffect.kUnarmedDamage);
                break;
            case global::ActorValue.kDamageResist:
                return (AlchemyEffect.kDamageResist);
                break;
            case global::ActorValue.kPoisonResist:
                return (AlchemyEffect.kPoisonResist);
                break;
            case global::ActorValue.kResistFire:
                return (AlchemyEffect.kResistFire);
                break;
            case global::ActorValue.kResistShock:
                return (AlchemyEffect.kResistShock);
                break;
            case global::ActorValue.kResistFrost:
                return (AlchemyEffect.kResistFrost);
                break;
            case global::ActorValue.kResistMagic:
                return (AlchemyEffect.kResistMagic);
                break;
            case global::ActorValue.kResistDisease:
                return (AlchemyEffect.kResistDisease);
                break;
            case global::ActorValue.kParalysis:
                return (AlchemyEffect.kParalysis);
                break;
            case global::ActorValue.kInvisibility:
                return (AlchemyEffect.kInvisibility);
                break;
            case global::ActorValue.kWeaponSpeedMult:
            case global::ActorValue.kLeftWeaponSpeedMultiply:
                return (AlchemyEffect.kWeaponSpeedMult);
                break;
            case global::ActorValue.kBowSpeedBonus:
                return (AlchemyEffect.kBowSpeed);
                break;
            case global::ActorValue.kAttackDamageMult:
                return (AlchemyEffect.kAttackDamageMult);
                break;
            case global::ActorValue.kHealRateMult:
                return (AlchemyEffect.kHealRateMult);
                break;
            case global::ActorValue.kMagickaRateMult:
                return (AlchemyEffect.kMagickaRateMult);
                break;
            case global::ActorValue.kStaminaRateMult:
                return (AlchemyEffect.kStaminaRateMult);
                break;
            case global::ActorValue.kAggression:
                return (AlchemyEffect.kFrenzy);
                break;
            case global::ActorValue.kConfidence:
                return (AlchemyEffect.kFear);
                break;
            case global::ActorValue.kReflectDamage:
                return (AlchemyEffect.kReflectDamage);
                break;
            case global::ActorValue.kWaterBreathing:
                return (AlchemyEffect.kWaterbreathing);
                break;
            default:
                return AlchemyEffect.kNone;
                break;
        }
    }


    public static string ToString(AlchemyEffect ae)
	{
		switch (ae)
		{
			case AlchemyEffect.kAlteration:
				return "Alteration";
			case AlchemyEffect.kAnyFood:
				return "AnyFood";
			case AlchemyEffect.kAnyFortify:
				return "AnyFortify";
			case AlchemyEffect.kAnyPoison:
				return "AnyPoison";
			case AlchemyEffect.kAnyPotion:
				return "AnyPotion";
			case AlchemyEffect.kArchery:
				return "Archery";
			case AlchemyEffect.kAttackDamageMult:
				return "AttackDamageMult";
			case AlchemyEffect.kBlock:
				return "Block";
			case AlchemyEffect.kBlood:
				return "Blood";
			case AlchemyEffect.kBowSpeed:
				return "BowSpeed";
			case AlchemyEffect.kConjuration:
				return "Conjuration";
			case AlchemyEffect.kCriticalChance:
				return "CriticalChance";
			case AlchemyEffect.kDamageResist:
				return "DamageResist";
			case AlchemyEffect.kDestruction:
				return "Destruction";
			case AlchemyEffect.kFear:
				return "Fear";
			case AlchemyEffect.kFrenzy:
				return "Frenzy";
			case AlchemyEffect.kHealRate:
				return "HealRate";
			case AlchemyEffect.kHealRateMult:
				return "HealRateMult";
			case AlchemyEffect.kHealth:
				return "Health";
			case AlchemyEffect.kHeavyArmor:
				return "HeavyArmor";
			case AlchemyEffect.kIllusion:
				return "Illusion";
			case AlchemyEffect.kInvisibility:
				return "Invisibility";
			case AlchemyEffect.kLightArmor:
				return "LightArmor";
			case AlchemyEffect.kLockpicking:
				return "Lockpicking";
			case AlchemyEffect.kMagicka:
				return "Magicka";
			case AlchemyEffect.kMagickaRate:
				return "MagickaRate";
			case AlchemyEffect.kMagickaRateMult:
				return "MagickaRateMult";
			case AlchemyEffect.kMeleeDamage:
				return "MeleeDamage";
			case AlchemyEffect.kNone:
				return "None";
			case AlchemyEffect.kOneHanded:
				return "OneHanded";
			case AlchemyEffect.kParalysis:
				return "Paralysis";
			case AlchemyEffect.kPickpocket:
				return "Pickpocket";
			case AlchemyEffect.kPoisonResist:
				return "PoisonResist";
			case AlchemyEffect.kReflectDamage:
				return "ReflectDamage";
			case AlchemyEffect.kResistDisease:
				return "ResistDisease";
			case AlchemyEffect.kResistFire:
				return "ResistFire";
			case AlchemyEffect.kResistFrost:
				return "ResistFrost";
			case AlchemyEffect.kResistMagic:
				return "ResistMagic";
			case AlchemyEffect.kResistShock:
				return "ResistShock";
			case AlchemyEffect.kRestoration:
				return "Restoration";
			case AlchemyEffect.kSneak:
				return "Sneak";
			case AlchemyEffect.kSpeedMult:
				return "SpeedMult";
			case AlchemyEffect.kStamina:
				return "Stamina";
			case AlchemyEffect.kStaminaRate:
				return "StaminaRate";
			case AlchemyEffect.kStaminaRateMult:
				return "StaminaRateMult";
			case AlchemyEffect.kTwoHanded:
				return "TwoHanded";
			case AlchemyEffect.kUnarmedDamage:
				return "UnarmedDamage";
			case AlchemyEffect.kWeaponSpeedMult:
				return "WeapenSpeedMult";
			case AlchemyEffect.kCureDisease:
				return "CureDisease";
			case AlchemyEffect.kCurePoison:
				return "CurePoison";
			case AlchemyEffect.kEnchanting:
				return "Enchanting";
			case AlchemyEffect.kWaterbreathing:
				return "Waterbreathing";
			case AlchemyEffect.kSmithing:
				return "Smithing";
			case AlchemyEffect.kSpeech:
				return "Speech";
			case AlchemyEffect.kCarryWeight:
				return "CarryWeight";
			case AlchemyEffect.kAlchemy:
				return "Alchemy";
			case AlchemyEffect.kPersuasion:
				return "Persuasion";
			case AlchemyEffect.kFortifyHealth:
				return "FortifyHealth";
			case AlchemyEffect.kFortifyMagicka:
				return "FortifyMagicka";
			case AlchemyEffect.kFortifyStamina:
				return "FortifyStamina";
			case AlchemyEffect.kCustom:
				return "Custom";
			default:
				return "Unknown";
		}
	}

    public static string ToString(UInt64 ae)
    {
        string ret = "|";
        if (((ae & (UInt64)(AlchemyEffect.kAlteration)) > 0))
            ret += "Alteration|";
        if ((ae & (UInt64)(AlchemyEffect.kArchery)) > 0)
            ret += "Archery|";
        if ((ae & (UInt64)(AlchemyEffect.kAttackDamageMult)) > 0)
            ret += "AttackDamageMult|";
        if ((ae & (UInt64)(AlchemyEffect.kBlock)) > 0)
            ret += "Block|";
        if ((ae & (UInt64)(AlchemyEffect.kBlood)) > 0)
            ret += "Blood|";
        if ((ae & (UInt64)(AlchemyEffect.kBowSpeed)) > 0)
            ret += "BowSpeed|";
        if ((ae & (UInt64)(AlchemyEffect.kConjuration)) > 0)
            ret += "Conjuration|";
        if ((ae & (UInt64)(AlchemyEffect.kCriticalChance)) > 0)
            ret += "CriticalChance|";
        if ((ae & (UInt64)(AlchemyEffect.kDamageResist)) > 0)
            ret += "DamageResist|";
        if ((ae & (UInt64)(AlchemyEffect.kDestruction)) > 0)
            ret += "Destruction|";
        if ((ae & (UInt64)(AlchemyEffect.kFear)) > 0)
            ret += "Fear|";
        if ((ae & (UInt64)(AlchemyEffect.kFrenzy)) > 0)
            ret += "Frenzy|";
        if ((ae & (UInt64)(AlchemyEffect.kHealRate)) > 0)
            ret += "HealRate|";
        if ((ae & (UInt64)(AlchemyEffect.kHealRateMult)) > 0)
            ret += "HealRateMult|";
        if ((ae & (UInt64)(AlchemyEffect.kHealth)) > 0)
            ret += "Health|";
        if ((ae & (UInt64)(AlchemyEffect.kHeavyArmor)) > 0)
            ret += "HeavyArmor|";
        if ((ae & (UInt64)(AlchemyEffect.kIllusion)) > 0)
            ret += "Illusion|";
        if ((ae & (UInt64)(AlchemyEffect.kInvisibility)) > 0)
            ret += "Invisibility|";
        if ((ae & (UInt64)(AlchemyEffect.kLightArmor)) > 0)
            ret += "LightArmor|";
        if ((ae & (UInt64)(AlchemyEffect.kLockpicking)) > 0)
            ret += "Lockpicking|";
        if ((ae & (UInt64)(AlchemyEffect.kMagicka)) > 0)
            ret += "Magicka|";
        if ((ae & (UInt64)(AlchemyEffect.kMagickaRate)) > 0)
            ret += "MagickaRate|";
        if ((ae & (UInt64)(AlchemyEffect.kMagickaRateMult)) > 0)
            ret += "MagickaRateMult|";
        if ((ae & (UInt64)(AlchemyEffect.kMeleeDamage)) > 0)
            ret += "MeleeDamage|";
        if ((ae & (UInt64)(AlchemyEffect.kNone)) > 0)
            ret += "None|";
        if ((ae & (UInt64)(AlchemyEffect.kOneHanded)) > 0)
            ret += "OneHanded|";
        if ((ae & (UInt64)(AlchemyEffect.kParalysis)) > 0)
            ret += "Paralysis|";
        if ((ae & (UInt64)(AlchemyEffect.kPickpocket)) > 0)
            ret += "Pickpocket|";
        if ((ae & (UInt64)(AlchemyEffect.kPoisonResist)) > 0)
            ret += "PoisonResist|";
        if ((ae & (UInt64)(AlchemyEffect.kReflectDamage)) > 0)
            ret += "ReflectDamage|";
        if ((ae & (UInt64)(AlchemyEffect.kResistDisease)) > 0)
            ret += "ResistDisease|";
        if ((ae & (UInt64)(AlchemyEffect.kResistFire)) > 0)
            ret += "ResistFire|";
        if ((ae & (UInt64)(AlchemyEffect.kResistFrost)) > 0)
            ret += "ResistFrost|";
        if ((ae & (UInt64)(AlchemyEffect.kResistMagic)) > 0)
            ret += "ResistMagic|";
        if ((ae & (UInt64)(AlchemyEffect.kResistShock)) > 0)
            ret += "ResistShock|";
        if ((ae & (UInt64)(AlchemyEffect.kRestoration)) > 0)
            ret += "Restoration|";
        if ((ae & (UInt64)(AlchemyEffect.kSneak)) > 0)
            ret += "Sneak|";
        if ((ae & (UInt64)(AlchemyEffect.kSpeedMult)) > 0)
            ret += "SpeedMult|";
        if ((ae & (UInt64)(AlchemyEffect.kStamina)) > 0)
            ret += "Stamina|";
        if ((ae & (UInt64)(AlchemyEffect.kStaminaRate)) > 0)
            ret += "StaminaRate|";
        if ((ae & (UInt64)(AlchemyEffect.kStaminaRateMult)) > 0)
            ret += "StaminaRateMult|";
        if ((ae & (UInt64)(AlchemyEffect.kTwoHanded)) > 0)
            ret += "TwoHanded|";
        if ((ae & (UInt64)(AlchemyEffect.kUnarmedDamage)) > 0)
            ret += "UnarmedDamage|";
        if ((ae & (UInt64)(AlchemyEffect.kWeaponSpeedMult)) > 0)
            ret += "WeapenSpeedMult|";
        if ((ae & (UInt64)(AlchemyEffect.kCureDisease)) > 0)
            ret += "CureDisease|";
        if ((ae & (UInt64)(AlchemyEffect.kCurePoison)) > 0)
            ret += "CurePoison|";
        if ((ae & (UInt64)(AlchemyEffect.kEnchanting)) > 0)
            ret += "Enchanting|";
        if ((ae & (UInt64)(AlchemyEffect.kWaterbreathing)) > 0)
            ret += "Waterbreathing|";
        if ((ae & (UInt64)(AlchemyEffect.kSmithing)) > 0)
            ret += "Smithing|";
        if ((ae & (UInt64)(AlchemyEffect.kSpeech)) > 0)
            ret += "Speech|";
        if ((ae & (UInt64)(AlchemyEffect.kCarryWeight)) > 0)
            ret += "CarryWeight|";
        if ((ae & (UInt64)(AlchemyEffect.kAlchemy)) > 0)
            ret += "Alchemy|";
        if ((ae & (UInt64)(AlchemyEffect.kPersuasion)) > 0)
            ret += "Persuasion|";
        if ((ae & (UInt64)(AlchemyEffect.kFortifyHealth)) > 0)
            ret += "FortifyHealth|";
        if ((ae & (UInt64)(AlchemyEffect.kFortifyMagicka)) > 0)
            ret += "FortifyMagicka|";
        if ((ae & (UInt64)(AlchemyEffect.kFortifyStamina)) > 0)
            ret += "FortifyStamina|";
        if ((ae & (UInt64)(AlchemyEffect.kCustom)) > 0)
            ret += "Custom|";

        if (ret == "|")
            return "|Unknown|";
        return ret;
    }

    public static int ToIndex(AlchemyEffect eff)
    {
        for (int i = 0; i <= 63; i++)
        {
            if ((eff & (AlchemyEffect)((UInt64)1 << i)) > 0) return i + 1;
        }
        return 0;
    }

    public static void CalcReferences(Effects eff)
    {
        // calculate references
        eff.References.Clear();
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
    }

    public static void CalcAllReferences()
    {
        foreach (var eff in Effects.effects)
        {
            CalcReferences(eff.Value);
        }
    }

}