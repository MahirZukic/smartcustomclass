using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Rogues Do It...
namespace HREngine.Bots
{
    [Serializable]
public class PRO_001b : Card
    {
		public override Card Create()
{ return new PRO_001b();}
public PRO_001b() : base()
        {
            
        }
		
        public PRO_001b(CardTemplate newTemplate, bool isFriend, int id) : base(newTemplate,isFriend,id)
        {
            
        }

        public override void Init()
        {
            base.Init();
            TargetTypeOnPlay = TargetType.BOTH_ENEMY;
        }

        public override void OnPlay(ref Board board, Card target = null,int index = 0,int choice = 0)
        {
            base.OnPlay(ref board, target,index);
            if(target != null)
            {
                target.Damage(4, ref board);
                board.FriendCardDraw++;
                board.Resimulate();
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
