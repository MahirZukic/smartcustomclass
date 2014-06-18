using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Arcane Explosion
namespace HREngine.Bots
{
    [Serializable]
public class CS2_025 : Card
    {
		public override Card Create()
{ return new CS2_025();}
public CS2_025() : base()
        {
            
        }
		
        public CS2_025(CardTemplate newTemplate, bool isFriend, int id) : base(newTemplate,isFriend,id)
        {
            
        }

        public override void Init()
        {
            base.Init();
        }

        public override void OnPlay(ref Board board, Card target = null,int index = 0,int choice = 0)
        {
            base.OnPlay(ref board, target,index);
            foreach(Card c in board.MinionEnemy)
            {
                c.Damage(1 + board.GetSpellPower(), ref board);
            }
        }

        public override void OnDeath(ref Board board)
        {
            base.OnDeath(ref board);
        }

        public override void OnPlayOtherMinion(ref Board board, ref Card Minion)
        {
            base.OnPlayOtherMinion(ref board,ref Minion);
        }

        public override void OnCastSpell(ref Board board, Card Spell)
        {
		    base.OnCastSpell(ref board, Spell);
        }

    }
}
