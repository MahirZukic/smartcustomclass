using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace HREngine.Bots
{
    [Serializable]
    public class CardTemplate
    {
        public static string DatabasePath { get; set; }

        public string Id { get; set; }

        public int Cost { get; set; }

        public string Name { get; set; }

        public Card.CType Type { get; set; }

        public Card.CRace Race { get; set; }

        public int Atk { get; set; }

        public int Health { get; set; }

        public int Durability { get; set; }
        public bool  HasDeathrattle { get; set; }
        public bool IsBuffer { get; set; }

        public List<string> Mechanics { get; set; }

        static public List<CardTemplate> templateList = new List<CardTemplate>();

        public CardTemplate()
        {
            Id = String.Empty;
            Cost = 0;
            Name = String.Empty;
            Atk = 0;
            Health = 0;
            IsBuffer = false;
            Mechanics = new List<string>();
        }

        public static CardTemplate LoadFromId(string id)
        {

            foreach (CardTemplate ct in templateList)
            {
                if (ct.Id == id)
                    return ct;
            }

            return null;
        }

        public static void LoadAll()
        {

            if (DatabasePath == null)
                return;

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(DatabasePath + "" + Path.DirectorySeparatorChar + "Bots" + Path.DirectorySeparatorChar + "SmartCC" + Path.DirectorySeparatorChar + "" + "Database.xml");

            foreach (XmlNode xmlNode in xmlDoc.DocumentElement.ChildNodes)
            {
                CardTemplate template = new CardTemplate();

                foreach (XmlNode node in xmlNode.ChildNodes)
                {
                    if (node.Name == "Id")
                    {
                        template.Id = node.InnerText;
                    }
                    else if (node.Name == "Name")
                    {
                        template.Name = node.InnerText;
                    }
                    else if (node.Name == "Cost")
                    {
                        template.Cost = int.Parse(node.InnerText);
                    }
                    else if (node.Name == "Type")
                    {
                        if (node.InnerText.Contains("Minion"))
                        {
                            template.Type = Card.CType.MINION;
                        }
                        else if (node.InnerText.Contains("Spell"))
                        {
                            template.Type = Card.CType.SPELL;
                        }
                        else if (node.InnerText.Contains("Weapon"))
                        {
                            template.Type = Card.CType.WEAPON;
                        }
                        else if (node.InnerText.Contains("Hero") && !node.InnerText.Contains("Power"))
                        {
                            template.Type = Card.CType.HERO;
                        }
                        else if (node.InnerText.Contains("Hero Power"))
                        {
                            template.Type = Card.CType.HERO_POWER;
                        }
                    }
                    else if (node.Name == "Race")
                    {
                        template.Race = Card.CRace.NONE;

                        if (node.InnerText.Contains("Murloc"))
                        {
                            template.Race = Card.CRace.MURLOC;
                        }
                        else if (node.InnerText.Contains("Beast"))
                        {
                            template.Race = Card.CRace.BEAST;
                        }
                        else if (node.InnerText.Contains("Demon"))
                        {
                            template.Race = Card.CRace.DEMON;
                        }
                        else if (node.InnerText.Contains("Pirate"))
                        {
                            template.Race = Card.CRace.PIRATE;
                        }
                        else if (node.InnerText.Contains("Totem"))
                        {
                            template.Race = Card.CRace.TOTEM;
                        }
                        else if (node.InnerText.Contains("Dragon"))
                        {
                            template.Race = Card.CRace.DRAGON;
                        }
                    }
                    else if (node.Name == "Atk")
                    {
                        template.Atk = int.Parse(node.InnerText);
                    }
                    else if (node.Name == "Health")
                    {
                        template.Health = int.Parse(node.InnerText);
                    }
                    else if (node.Name == "Durability")
                    {
                        template.Durability = int.Parse(node.InnerText);
                    }
                    else if (node.Name == "Mechanics")
                    {
                        foreach (XmlNode mec in node.ChildNodes)
                        {
                            string m = mec.InnerText;
                            template.Mechanics.Add(m);
                            if (m.Contains("Deathrattle"))
                                template.HasDeathrattle = true;
                        }

                    }
                }
                templateList.Add(template);
                if (Buff.GetBuffById(template.Id) != null)
                    template.IsBuffer = true;
            }
        }

        public override string ToString()
        {
            string ret = "";

            ret += "CardTemplate{[" + Id + "][" + Name + "][" + Cost.ToString() + "][" + Type + "]";

            if (Type == Card.CType.MINION)
            {
                if (Race != Card.CRace.NONE)
                {
                    ret += "[" + Race + "]";
                }
                ret += "[" + Atk.ToString() + "]";
                ret += "[" + Health.ToString() + "]";
            }
            else if (Type == Card.CType.WEAPON)
            {
                ret += "[" + Atk.ToString() + "]";
                ret += "[" + Durability.ToString() + "]";
            }


            ret += "}";


            return ret;
        }
    }
}
