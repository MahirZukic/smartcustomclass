using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Shadowstep
namespace HREngine.Bots
{
    [Serializable]
public class EX1_144 : Card
    {
		public override Card Create()
{ return new EX1_144();}
public EX1_144() : base()
        {
            
        }
		
        public EX1_144(CardTemplate newTemplate, bool isFriend, int id) : base(newTemplate,isFriend,id)
        {
            
        }

        public override void Init()
        {
            base.Init();
            TargetTypeOnPlay = TargetType.MINION_FRIEND;
        }

        public override void OnPlay(ref Board board, Card target = null,int index = 0,int choice = 0)
        {
            base.OnPlay(ref board, target,index);
            if(target != null)
            {
                board.MinionFriend.Remove(target);
                board.Hand.Add(target);
                target.CurrentCost -= 2;
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
