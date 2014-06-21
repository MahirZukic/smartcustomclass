using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Power of the Horde
namespace HREngine.Bots
{
    [Serializable]
public class PRO_001c : Card
    {
		public override Card Create()
{ return new PRO_001c();}
public PRO_001c() : base()
        {
            
        }
		
        public PRO_001c(CardTemplate newTemplate, bool isFriend, int id) : base(newTemplate,isFriend,id)
        {
            
        }

        public override void Init()
        {
            base.Init();
        }

        public override void OnPlay(ref Board board, Card target = null,int index = 0,int choice = 0)
        {
            base.OnPlay(ref board, target,index);
            board.AddCardToBoard("CS2_179", true);
            board.Resimulate();
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
