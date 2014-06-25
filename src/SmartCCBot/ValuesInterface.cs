using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace HREngine.Bots
{
    public static class ValuesInterface
    {
        //Board
        public static int ValueHealthEnemy { get; set; }
        public static int ValueHealthFriend { get; set; }
        public static int ValueArmorEnemy { get; set; }
        public static int ValueArmorFriend { get; set; }
        public static int ValueSecret { get; set; }
        public static int ValueEnemyCardDraw { get; set; }
        public static int ValueEnemyMinionCount { get; set; }
        public static int ValueFriendMinionCount { get; set; }
        public static int ValueFriendCardDraw { get; set; }
        public static int ValueMana { get; set; }

        //Cards
        public static int ValueDurabilityWeapon { get; set; }
        public static int ValueHealthMinionFriend { get; set; }
        public static int ValueAttackMinionFriend { get; set; }
        public static int ValueHealthMinionEnemy { get; set; }
        public static int ValueAttackMinionEnemy { get; set; }
        public static int ValueTaunt { get; set; }
        public static int ValueDivineShield { get; set; }
        public static int ValueAttackWeapon { get; set; }
        public static int ValueFrozen { get; set; }
        public static int ValueOverload { get; set; }

        public static void LoadValuesFromFile()
        {
            string profileName = string.Empty;

            StreamReader reader = new StreamReader(CardTemplate.DatabasePath + Path.DirectorySeparatorChar + "Bots" + Path.DirectorySeparatorChar + "SmartCC" + Path.DirectorySeparatorChar + "Profile.current");
            profileName = reader.ReadLine();
            reader.Close();
            HREngine.API.Utilities.HRLog.Write("Loaded Profile :" + profileName);
            reader = new StreamReader(CardTemplate.DatabasePath + "" + Path.DirectorySeparatorChar + "Bots" + Path.DirectorySeparatorChar + "SmartCC" + Path.DirectorySeparatorChar + "Profiles" + Path.DirectorySeparatorChar + "" + profileName + "" + Path.DirectorySeparatorChar + "aValues");

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (line.Contains("ValueHealthEnemy"))
                {
                    ValueHealthEnemy = int.Parse(line.Split('=')[1]);
                }
                if (line.Contains("ValueHealthFriend"))
                {
                    ValueHealthFriend = int.Parse(line.Split('=')[1]);
                }
                if (line.Contains("ValueArmorEnemy"))
                {
                    ValueArmorEnemy = int.Parse(line.Split('=')[1]);
                }
                if (line.Contains("ValueArmorFriend"))
                {
                    ValueArmorFriend = int.Parse(line.Split('=')[1]);
                }
                if (line.Contains("ValueSecret"))
                {
                    ValueSecret = int.Parse(line.Split('=')[1]);
                }
                if (line.Contains("ValueEnemyCardDraw"))
                {
                    ValueEnemyCardDraw = int.Parse(line.Split('=')[1]);
                }
                if (line.Contains("ValueEnemyMinionCount"))
                {
                    ValueEnemyMinionCount = int.Parse(line.Split('=')[1]);
                }
                if (line.Contains("ValueFriendMinionCount"))
                {
                    ValueFriendMinionCount = int.Parse(line.Split('=')[1]);
                }
                if (line.Contains("ValueFriendCardDraw"))
                {
                    ValueFriendCardDraw = int.Parse(line.Split('=')[1]);
                }
                if (line.Contains("ValueDurabilityWeapon"))
                {
                    ValueDurabilityWeapon = int.Parse(line.Split('=')[1]);
                }
                if (line.Contains("ValueHealthMinionFriend"))
                {
                    ValueHealthMinionFriend = int.Parse(line.Split('=')[1]);
                }
                if (line.Contains("ValueAttackMinionFriend"))
                {
                    ValueAttackMinionFriend = int.Parse(line.Split('=')[1]);
                }
                if (line.Contains("ValueHealthMinionEnemy"))
                {
                    ValueHealthMinionEnemy = int.Parse(line.Split('=')[1]);
                }
                if (line.Contains("ValueAttackMinionEnemy"))
                {
                    ValueAttackMinionEnemy = int.Parse(line.Split('=')[1]);
                }
                if (line.Contains("ValueTaunt"))
                {
                    ValueTaunt = int.Parse(line.Split('=')[1]);
                }
                if (line.Contains("ValueDivineShield"))
                {
                    ValueDivineShield = int.Parse(line.Split('=')[1]);
                }
                if (line.Contains("ValueAttackWeapon"))
                {
                    ValueAttackWeapon = int.Parse(line.Split('=')[1]);
                }
                if (line.Contains("ValueFrozen"))
                {
                    ValueFrozen = int.Parse(line.Split('=')[1]);
                }
                if (line.Contains("ValueMana"))
                {
                    ValueMana = int.Parse(line.Split('=')[1]);
                }
                if (line.Contains("ValueOverload"))
                {
                    ValueOverload = int.Parse(line.Split('=')[1]);
                }
            }

            reader.Close();

        }

    }
}
