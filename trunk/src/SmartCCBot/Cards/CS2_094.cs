using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Hammer of Wrath
namespace HREngine.Bots
{
    [Serializable]
public class CS2_094 : Card
    {
		public CS2_094() : base()
        {
            
        }
		
        public CS2_094(CardTemplate newTemplate, bool isFriend, int id) : base(newTemplate,isFriend,id)
        {
            
        }

        public override void Init()
        {
            base.Init();
            TargetTypeOnPlay = TargetType.ALL;
        }

        public override void OnPlay(ref Board board, Card target = null,int index = 0)
        {
            base.OnPlay(ref board, target,index);
            if(target != null)
            {
                target.Damage(3 + board.GetSpellPower(), ref board);
                board.FriendCardDraw++;
                board.Resimulate();
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