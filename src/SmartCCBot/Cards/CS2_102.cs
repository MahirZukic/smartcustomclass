using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Armor Up!
namespace HREngine.Bots
{
    [Serializable]
public class CS2_102 : Card
    {
		public override Card Create()
{ return new CS2_102();}
public CS2_102() : base()
        {
            
        }
		
        public CS2_102(CardTemplate newTemplate, bool isFriend, int id) : base(newTemplate,isFriend,id)
        {
            
        }

        public override void Init()
        {
            base.Init();
        }

        public override void OnPlay(ref Board board, Card target = null,int index = 0,int choice = 0)
        {
            base.OnPlay(ref board, target,index);
            //Console.WriteLine("Ondpelayarmorup");
            if(IsFriend)
            {
                board.HeroFriend.CurrentArmor += 2;

            }
            else
            {
                board.HeroEnemy.CurrentArmor += 2;
            }
        }

        public override void OnDeath(ref Board board)
        {
            base.OnDeath(ref board);
        }

        public override void OnPlayOtherMinion(ref Board board, Card Minion)
        {
            base.OnPlayOtherMinion(ref board, Minion);
        }

        public override void OnCastSpell(ref Board board, Card Spell)
        {
		    base.OnCastSpell(ref board, Spell);
        }

    }
}
