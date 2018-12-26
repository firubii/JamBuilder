using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KSALVL;

namespace JamBuilder
{
    public partial class YAMLEditor : Form
    {
        public Dictionary<string, string> obj;
        public int editorType;

        List<string> objectKind = new List<string>()
        {
            "StartPortal",
            "BGAltarCtrl",
            "DimensionHole",
            "AreaDollyCamera",
            "RippleField",
            "DoorAbility",
            "MoveLandController",
            "MoveLandPathNode",
            "WorldCameraLock",
            "FieldEffect",
            "EnemyGenerator",
            "Switch",
            "AIPursuitCloseZone",
            "ZoneSwitch",
            "GuideBoard",
            "GuideBoardAbilityIcon",
            "Slate",
            "ArrowBoard",
            "FuseCannonMini",
            "FuseGenerator",
            "FusePathNode",
            "MassWaddledeeFromFar",
            "Block",
            "BlockBreakWatcher",
            "BlockRegenerateCtrl",
            "Door",
            "MassWaddledee",
            "ChainStarter",
            "AirFlow",
            "StakeBattery",
            "Shutter",
            "Stake",
            "ChainConnector",
            "AIReaction",
            "RoomGuarder",
            "RoomGuarderPoint",
            "RoomGuarderEnemyList",
            "LockShutter",
            "FriendActionPedestal",
            "FriendBridgeTargetPoint",
            "FriendBridgeControler",
            "CannonBlow",
            "FriendBridgePole",
            "HangSwitch",
            "ItemBox",
            "AIForbidAttackZone",
            "AbilitySeat",
            "AreaBGMFadeOut",
            "WaterFlow",
            "FireBox",
            "CutRope",
            "AISearchIgnoreZone",
            "StakeIce",
            "FriendActionMove",
            "BreakableLandCtrl",
            "FriendActionFitWall",
            "FriendActionGoal",
            "WhiteBoard",
            "RopeBomb",
            "FuseDynamite",
            "FuseWater",
            "CutRopeStepHard",
            "ItemRegenerateCtrl",
            "FallenLeaves",
            "CutChainBurning",
            "BigMeteor",
            "GiantRollingBlade",
            "AreaLock",
            "AreaLockThrough",
            "TwinkleStarEndDemo",
            "ExecutivesEndDemo",
            "DoorGoal",
            "SwitchBig",
            "HelperGoItemHelperExclusive",
            "PopFlower",
            "GrassyPlace",
            "AreaBGMChange",
            "AIAttackPointForCook",
            "MovingSawBody",
            "MovingSawRail",
            "MovingSawRailNode",
            "AIAttackPoint",
            "SwitchWindmill",
            "OGenMarginExpander",
            "GuideBoardFriendAction",
            "HelperGoItemExcluder",
            "FriendActionDead",
            "HelperGoEnemyListHelperExclusive",
            "BlockAIReactionZone",
            "ResetAbilitySeat",
            "SecretPath",
            "EscapeEvent",
            "GoldKirbyStatue",
            "RockForMultiCannon",
            "AreaRotationCamera",
            "ArenaStepEnd",
            "PonKonGimmick",
            "ArenaRestStation",
            "AICantGetItemZone",
            "CreditManager",
            "CreditItemCtrl",
            "EndingDemo",
            "StandLight",
            "BgShaderParamChanger",
            "FriendRodDemoLocator",
            "MuseumFirstDemo",
            "DreamRodGenLocator",
            "ForbidRegenerateEnemy",
            "KibidangoDemo",
            "CorkPlug",
            "FruitTree",
            "AreaBlendCamera",
            "FriendCopyFirstDemo",
            "HelperGoPutItemOnNeedlessDoor",
            "DoorMulti",
            "CameraHeightLimitUnsetter",
            "CutChainStep",
            "ItemAIReactionZone",
            "AIReactionPathNode",
            "EscapeEventEnemyGenerator",
            "TwinkleStarEscapeEvent",
            "TwinkleStarBGMChanger",
            "BigBomb",
            "DarkHeart",
            "LastCloseContest"
        };
        Dictionary<string, string[]> objectSubKind = new Dictionary<string, string[]>()
        {
            { "FieldEffect", new string[] {"AnotherDimension", "Spark", "Grass", "AltarPlanet", "PlanetSpark", "Snow", "PlanetSnow", "Altar"} },
            { "GuideBoard", new string[] {"ThrowHelperBall", "Hover", "ThrowHelperBallNoThreeHelpers", "Drink", "Vomit", "Jump", "ThroughLand", "ThrowHelperBallNoHelper", "FriendCopyThenCutRope", "CreateHelperThenFriendCopy", "SlidingTime", "FriendCopyStone", "TwinkleStarHelperChange"} },
            { "FuseGenerator", new string[] {"Fuse", "Wire"} },
            { "FusePathNode", new string[] {"ForDynamite"} },
            { "Block", new string[] {"WoodBox", "BarrelBox"} },
            { "StakeBattery", new string[] {"Wire"} },
            { "Shutter", new string[] {"Up", "Left", "Right"} },
            { "FriendActionPedestal", new string[] {"Bridge", "Train", "Rolling", "StarRide", "FinalStarRide"} },
            { "SwitchBig", new string[] {"Lv1", "Lv2", "Lv3", "Lv4"} },
            { "GrassyPlace", new string[] {"S", "SS", "L", "XXL"} },
            { "CreditManager", new string[] {"Adc", "Extra", "Normal"} },
            { "StandLight", new string[] {"Red", "Green", "Blue", "Yellow"} },
            { "CorkPlug", new string[] {"S", "L"} }
        };
        Dictionary<string, string[]> objectVariation = new Dictionary<string, string[]>()
        {
            { "StartPortal", new string[] { "Normal", "FallNoControlTillLanding" } },
            { "DimensionHole", new string[] { "Normal" } },
            { "RippleField", new string[] { "DLC1", "DLC2" } },
            { "Switch", new string[] { "Once", "Return" } },
            { "ZoneSwitch", new string[] { "Once", "Return" } },
            { "MassWaddledeeFromFar", new string[] { "Normal" } },
            { "MassWaddledee", new string[] { "WaitSwitch", "AtOnce", "WaitEncount" } },
            { "AirFlow", new string[] { "Normal", "Snow" } },
            { "Stake", new string[] { "RightWall", "Roof", "Floor", "LeftWall" } },
            { "AIReaction", new string[] { "CreateThunderHammer", "CreateCoolingSlash", "CreateThunderLandPenetrate", "ThrowRight", "EsperStone", "CreateFlameSlash", "StoneChangeBlowRight", "CreateIceWaterCutter", "CreateFreezeSusie", "CreateWindCutter", "CreateIceWaterMarx", "CreateWindLandPenetrate", "CreateWindDarkMetaknight", "CreateThunderDarkMetaknight", "DuoElementAquaFreezeRight", "CreateAquaSusie", "CreateFlameHammer", "CreateThunderSusie", "SpiderJumpUp", "SpiderJumpRight", "StoneChangeBlowLeft", "CreateFlameLandPenetrate", "FuseWaterHoldBack", "DuoElementAquaFreezeLeft", "ThrowLeft", "CreateThunderBomb", "DuoElementFlameWindRight", "DuoElementFlameWindLeft", "DuoElementThunderAquaRight", "CreateFreezeLandPenetrate", "StoneChangeBlowLeftPriorClean" } },
            { "FriendBridgeTargetPoint", new string[] { "Failure", "Success", "Landing" } },
            { "CannonBlow", new string[] { "Manual", "Auto" } },
            { "HangSwitch", new string[] { "Once", "Return" } },
            { "AbilitySeat", new string[] { "Normal", "Hide" } },
            { "AreaBGMFadeOut", new string[] { "LtoR", "DtoU", "UtoD", "RtoL" } },
            { "StakeIce", new string[] { "Floor" } },
            { "WhiteBoard", new string[] { "Normal", "NoItem" } },
            { "CutRopeStepHard", new string[] { "H1W5", "H1W3" } },
            { "BigMeteor", new string[] { "WaitEncount", "FarEncount", "WaitSwitch", "Stay", "NearEncount" } },
            { "GiantRollingBlade", new string[] { "High", "Middle", "Ultra" } },
            { "AreaBGMChange", new string[] { "ECDLISK3LV1", "ECDLISSDXGING1", "ECDLISK2TITLE1", "ECDLK64MAP1", "ECDLDMETAMAP1", "ECDLDOROCHETITLE1", "ECDLMAGOLORCOOKIE1", "ECDLSUSIEROOM1", "ECDLTARANZA1", "ECBOSSLASMAE1", "ECYOUSAI3", "ECNTGBTITLE1" } },
            { "MovingSawBody", new string[] { "Small", "Big" } },
            { "AIAttackPoint", new string[] { "Normal", "Dash", "Charge" } },
            { "SwitchWindmill", new string[] { "Once" } },
            { "GuideBoardFriendAction", new string[] { "Rolling", "Bridge" } },
            { "BlockAIReactionZone", new string[] { "Break", "Cooling", "BreakForLandPenetrate" } },
            { "PonKonGimmick", new string[] { "Normal", "Ex" } },
            { "CutChainStep", new string[] { "Normal" } },
            { "ItemAIReactionZone", new string[] { "Gather" } },
            { "DarkHeart", new string[] { "Break3", "Break2" } },
        };
        List<string> guestItemKind = new List<string>()
        {
            "PointStarYellow",
            "PointStarGreen",
            "IllustPiece",
            "FriendSpeed",
            "PointStarRed",
            "Food",
            "FriendPower",
            "AllUp",
            "FriendDefense",
            "GenkiDrink",
            "PointStarBlue",
            "InvincibleCandy",
            "MTomato"
        };
        Dictionary<string, string[]> guestItemSubKind = new Dictionary<string, string[]>()
        {
            { "Food", new string[] { "SweetsDoughnut", "JunkRoastChicken", "DrinkBabyBottle", "VegetableCorn", "FruitMelon", "FruitWatermelon", "DrinkCoffee", "DinnerOmelet", "JunkTakoyaki", "DrinkMelonSoda", "SweetsIceCandy", "FruitCherry", "JunkHumburger", "DinnerOnigiri", "SweetsShortCake", "DrinkMilk", "DinnerMeat", "DinnerBread", "FruitOrange", "SweetsDaroachCake", "JunkHotdog", "SweetsPudding", "FruitBanana", "SweetsSoftCream", "SweetsMacaron" } }
        };
        List<string> itemKind = new List<string>()
        {
            "AdcHeart",
            "PointStarGreen",

            "IllustPiece",
            "PointStarRed",
            "PointStarBlue",
            "Food",
            "PointStarYellow",
            "OneUp",
            "DreamRod",
            "MTomato",
            "IllustPieceRare",
            "GenkiDrink",
            "InvincibleCandy"
        };
        Dictionary<string, string[]> itemSubKind = new Dictionary<string, string[]>()
        {
            { "Food", new string[] { "FruitOrange", "FruitMelon", "DrinkMilk", "SweetsDoughnut", "SweetsSoftCream", "FruitWatermelon", "FruitCherry", "DinnerSushi", "SweetsMacaron", "LightFriedEgg", "DinnerOnigiri", "DrinkCoffee", "JunkRoastChicken", "FruitBanana", "SweetsDaroachCake", "DrinkMelonSoda", "SweetsPudding", "DrinkBabyBottle", "SweetsShortCake", "VegetableGreenPepper", "JunkTakoyaki", "SweetsSusieAppleSherbet", "DinnerMeat", "DinnerBread", "DinnerOmelet", "VegetableCorn", "JunkHotdog", "JunkHumburger", "SweetsIceCandy", "VegetablePumpkin", "VegetableCarrot" } }
        };
        string[] itemVariation = { "Fixed", "Bound", "Fall", "FallNoCulling" };
        List<string> bossKind = new List<string>()
        {
            "Whispywoods",
            "Kracko",
            "MetaKnight",
            "Kingdedede",
            "ExecutiveThunder",
            "Hiness",
            "PonKon",
            "ExecutiveIce",
            "ExecutiveFire",
            "BKnight",
            "LastBoss",
            "Giantironmom"
        };
        Dictionary<string, string[]> bossVariation = new Dictionary<string, string[]>()
        {
            { "Whispywoods", new string[] { "Normal", "NormalZenza", "Ex", "ExTwinkleStar", "Ultimate" } },
            { "MetaKnight", new string[] { "Normal", "Ultimate" } },
            { "Kingdedede", new string[] { "Normal", "Ultimate" } },
            { "Kracko", new string[] { "Normal", "Ultimate" } },
            { "PonKon", new string[] { "Normal", "Ex", "Ex2" } },
            { "Giantironmom", new string[] { "Normal" } },
            { "ExecutiveIce", new string[] { "Normal", "Ex", "Ex2" } },
            { "ExecutiveFire", new string[] { "Normal", "Ex", "Ex2" } },
            { "ExecutiveThunder", new string[] { "Normal", "Ex", "Ex2", "Ultimate", "UltimateInitHide" } },
            { "Hiness", new string[] { "Normal", "PrayFar", "Ultimate", "UltimateDead" } },
            { "BKnight", new string[] { "Normal", "GalaDemo", "Ultimate", "UltimateGalaDemo" } },
            { "LastBoss", new string[] { "Normal", "Ex", "Ultimate" } }
        };
        List<string> enemyKind = new List<string>()
        {
            "Poppybrosjr",
            "Waddledee",
            "Brontoburt",
            "Bouncy",
            "Burningleo",
            "Puppetdee",
            "FloatSlime",
            "Waddledoo",
            "WaterEnemy",
            "Kabu",
            "ShieldEnemy",
            "Dekabu",
            "Broomhatter",
            "Chip",
            "Nruff",
            "ChefKawasaki",
            "Wonkey",
            "Chilly",
            "Sirkibble",
            "Scarfy",
            "Shotzo",
            "Cappy",
            "Gordo",
            "Coner",
            "Blipper",
            "Glunk",
            "Mamatee",
            "Squishy",
            "Gim",
            "Nesp",
            "Rocky",
            "Bugzzy",
            "StickEnemy",
            "Beetlie",
            "BioSpark",
            "Noddy",
            "Propeller",
            "Bonkers",
            "Como",
            "Wester",
            "Bomber",
            "BigBouncy",
            "Misterfrosty",
            "Bladeknight",
            "Gabon",
            "Jaharbeliever",
            "Knucklejoe",
            "Grizzo",
            "Birdon",
            "Vivitia",
            "Conce",
            "TwoFace",
            "MaskEnemy",
            "FestivalEnemy",
            "Walky"
        };
        Dictionary<string, string[]> enemyVariation = new Dictionary<string, string[]>()
        {
            { "Poppybrosjr", new string[] { "WaitLong", "Wait", "Move" } },
            { "Waddledee", new string[] { "WalkStraight", "WalkTurnCliff", "Sleep", "Parasol", "WalkAround", "Rolling", "ParasolWait", "Wait", "Jump3D_Walk", "SleepAndGetUp" } },
            { "Brontoburt", new string[] { "Sin", "Pursuit", "WaitPursuit", "Straight", "Fly", "UpDown", "TakeOffFlyStraight", "Fly_FlyStraight3D" } },
            { "Bouncy", new string[] { "Wait", "MoveStraight", "MoveStraightHigh", "WaitHigh" } },
            { "Burningleo", new string[] { "Wait", "WalkStraight", "WalkTurnCliff", "WaitLong", "WaitNear" } },
            { "Puppetdee", new string[] { "WalkStraight", "WalkTurnCliff", "Wait", "WalkAround" } },
            { "FloatSlime", new string[] { "Straight", "Pursuit", "FlyUD", "FlyLR", "Wait", "StraightUpDownBullet" } },
            { "Waddledoo", new string[] { "WalkTurnCliff", "Wait", "WalkStraight", "WalkAround" } },
            { "WaterEnemy", new string[] { "WaitWaveShotOnly", "Wait", "JumpOnly", "RoofWait", "WalkStraightOnly" } },
            { "Kabu", new string[] { "MoveAround", "MoveTurnCliff", "MoveStraight", "Jump" } },
            { "ShieldEnemy", new string[] { "WalkStraightFire", "WalkTurnCliffFire", "WaitFire", "WalkTurnCliffIce", "WaitIce", "WalkStraightIce" } },
            { "Dekabu", new string[] { "MoveStraight", "RequestChildKabu", "MoveTurnCliff", "Wait", "MoveAround" } },
            { "Broomhatter", new string[] { "WalkAroundAttack", "Wait" } },
            { "Chip", new string[] { "Random", "Straight", "Wait" } },
            { "Nruff", new string[] { "Run", "WaitToRun", "RunWithDee", "WaitToRunWithDee" } },
            { "ChefKawasaki", new string[] { "Ex", "Normal", "Ex2" } },
            { "Wonkey", new string[] { "RoomGuarderWalkTurnBlue", "RoomGuarderFriendBridge", "WalkJump", "WalkTurn", "WaitTurnWideHight", "RoomGuarderWalkJumpBlue", "RoomGuarderWalkJumpRed", "WaitTurn", "WaitJumpWideHight", "WaitJumpWide", "WaitTurnWide", "Wait", "RoomGuarderFriendBridgeRed", "RoomGuarderFriendBridgeBlue" } },
            { "Chilly", new string[] { "Move", "Wait" } },
            { "Sirkibble", new string[] { "Wait", "WaitLong", "Jump", "WalkTurnCliff" } },
            { "Scarfy", new string[] { "Pursuit", "Wait", "MoveAround" } },
            { "Shotzo", new string[] { "Pursuit", "Fix", "FarFix", "Parasol" } },
            { "Cappy", new string[] { "ThrowUp", "WalkTurnCliff", "WalkStraight", "Wait", "WalkAround" } },
            { "Gordo", new string[] { "Wait", "Straight", "MoveAround", "RotateCW", "MoveAroundGapFront", "MoveAroundGapBack", "ZWaitGapFront", "ZWaitGapBack" } },
            { "Coner", new string[] { "MoveStraight", "MoveAround" } },
            { "Blipper", new string[] { "Straight", "Pursuit", "MoveAround", "Jump" } },
            { "Glunk", new string[] { "Shot", "Wait" } },
            { "Mamatee", new string[] { "Pursuit", "MoveStraight", "MoveAround" } },
            { "Squishy", new string[] { "Pursuit", "UpDown", "MoveStraight" } },
            { "Gim", new string[] { "WalkStraight", "WalkTurnCliff", "Wait" } },
            { "Nesp", new string[] { "AttackNoMove", "Attack" } },
            { "Rocky", new string[] { "Walk", "WalkSliding", "Wait" } },
            { "Bugzzy", new string[] { "Ex", "Normal", "Ex2" } },
            { "StickEnemy", new string[] { "WalkTurnCliff", "Wait", "WalkStraight" } },
            { "Beetlie", new string[] { "Wait", "WalkTurnCliff", "WalkAround" } },
            { "BioSpark", new string[] { "Move", "Wait" } },
            { "Noddy", new string[] { "Wait" } },
            { "Propeller", new string[] { "Wait", "AngryImmidiately" } },
            { "Bonkers", new string[] { "Ex", "Normal", "Ex2" } },
            { "Como", new string[] { "Dive", "Wait" } },
            { "Wester", new string[] { "TurnCliff", "Wait" } },
            { "Bomber", new string[] { "Walk" } },
            { "BigBouncy", new string[] { "Wait" } },
            { "Misterfrosty", new string[] { "Ex", "Normal", "Ex2" } },
            { "Bladeknight", new string[] { "Wait", "Search", "WaitLong" } },
            { "Gabon", new string[] { "Wait" } },
            { "Jaharbeliever", new string[] { "WalkStraight", "WalkTurnCliff", "WalkAround", "Wait" } },
            { "Knucklejoe", new string[] { "WalkAdjust", "Wait", "WalkStraight" } },
            { "Grizzo", new string[] { "Walk", "Sleep" } },
            { "Birdon", new string[] { "Wait", "Move" } },
            { "Vivitia", new string[] { "Normal", "Ex", "Ex2", "ExNoSculpture" } },
            { "Conce", new string[] { "Wait", "WalkTurnCliff", "Pursuit", "PursuitThunderboltOnly" } },
            { "TwoFace", new string[] { "WideRight", "WideLeft", "WallMoveL", "WallMoveR", "Normal", "WideBottom" } },
            { "MaskEnemy", new string[] { "Wait", "WalkTurnCliff" } },
            { "FestivalEnemy", new string[] { "Sin", "Wait" } },
            { "Walky", new string[] { "WalkTurnCliff", "WalkJump" } }
        };

        public YAMLEditor()
        {
            InitializeComponent();
        }

        private void YAMLEditor_Load(object sender, EventArgs e)
        {
            foreach (KeyValuePair<string, string> pair in obj)
            {
                yamlDataList.Items.Add(pair.Key);
            }
        }

        private void yamlDataList_SelectedIndexChanged(object sender, EventArgs e)
        {
            valueSelect.Items.Clear();
            value.Text = obj[yamlDataList.SelectedItem.ToString()];
            if (yamlDataList.SelectedItem.ToString() == "4kind")
            {
                valueSelect.Enabled = true;
                switch (editorType)
                {
                    case 0:
                        {
                            valueSelect.Items.AddRange(objectKind.ToArray());
                            break;
                        }
                    case 1:
                        {
                            valueSelect.Items.AddRange(guestItemKind.ToArray());
                            break;
                        }
                    case 2:
                        {
                            valueSelect.Items.AddRange(itemKind.ToArray());
                            break;
                        }
                    case 3:
                        {
                            valueSelect.Items.AddRange(bossKind.ToArray());
                            break;
                        }
                    case 4:
                        {
                            valueSelect.Items.AddRange(enemyKind.ToArray());
                            break;
                        }
                }
                valueSelect.Text = value.Text;
            }
            else if (yamlDataList.SelectedItem.ToString() == "4subKind")
            {
                valueSelect.Enabled = true;
                switch (editorType)
                {
                    case 0:
                        {
                            if (objectSubKind.Keys.Contains(obj["4kind"]))
                            {
                                valueSelect.Items.AddRange(objectSubKind[obj["4kind"]]);
                                valueSelect.Text = value.Text;
                            }
                            break;
                        }
                    case 1:
                    case 2:
                        {
                            valueSelect.Items.AddRange(itemSubKind[obj["4kind"]]);
                            valueSelect.Text = value.Text;
                            break;
                        }
                }
            }
            else if (yamlDataList.SelectedItem.ToString() == "4variation")
            {
                valueSelect.Enabled = true;
                switch (editorType)
                {
                    case 0:
                        {
                            if (objectVariation.Keys.Contains(obj["4kind"]))
                            {
                                valueSelect.Items.AddRange(objectVariation[obj["4kind"]]);
                                valueSelect.Text = value.Text;
                            }
                            break;
                        }
                    case 1:
                    case 2:
                        {
                            valueSelect.Items.AddRange(itemVariation);
                            valueSelect.Text = value.Text;
                            break;
                        }
                    case 3:
                        {
                            if (bossVariation.Keys.Contains(obj["4kind"]))
                            {
                                valueSelect.Items.AddRange(bossVariation[obj["4kind"]]);
                                valueSelect.Text = value.Text;
                            }
                            break;
                        }
                    case 4:
                        {
                            if (enemyVariation.Keys.Contains(obj["4kind"]))
                            {
                                valueSelect.Items.AddRange(enemyVariation[obj["4kind"]]);
                                valueSelect.Text = value.Text;
                            }
                            break;
                        }
                }
            }
            else
            {
                valueSelect.Enabled = false;
            }
        }

        private void value_TextChanged(object sender, EventArgs e)
        {
            obj[yamlDataList.SelectedItem.ToString()] = value.Text;
        }

        private void save_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
