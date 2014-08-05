using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Blood Imp

namespace HREngine.Bots
{
	[Serializable]
    public class bCS2_059 : Behavior
    {
		public bCS2_059() : base()
        {
            
        }
		
		public override bool ShouldBePlayed(Board board)
        {
            return true;
        }

        public override bool ShouldAttack(Board board)
        {
			Card me = null;
			
			foreach(Card c in board.MinionFriend)
			{
				if(c.Behavior == this)
					me = c;
			}
			
			if(me != null)
				if(board.GetHeroEnemyHpAndArmor() > me.CurrentAtk)
					return false;
					
            return true;
        }

        public override bool ShouldAttackTarget(Board board,Card target)
        {
			
            return true;
        }
		
		public override bool ShouldBePlayedOnTarget(Board board,Card target)
        {
            return true;
        }

        public override int GetPriorityPlay(Board board)
        {
            return 1;
        }
		
    }
}
