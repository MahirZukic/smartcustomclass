using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Silence

namespace HREngine.Bots
{
	[Serializable]
    public class bEX1_332 : Behavior
    {
		public bEX1_332() : base()
        {
            
        }
		
		public override bool ShouldBePlayed(Board board)
        {
			foreach(Card c in board.MinionEnemy)
			{
				if(c.HasGoodBuffs() || c.IsBuffer)
					return true;
			}
            foreach(Card c in board.MinionFriend)
			{
				if(c.HasBadBuffs())
					return true;
			}
			
            return true;
        }

        public override bool ShouldAttack(Board board)
        {
            return true;
        }

        public override bool ShouldAttackTarget(Board board,Card target)
        {
            return true;
        }
		
		public override bool ShouldBePlayedOnTarget(Board board,Card target)
        {
			if(target.IsFriend)
			{
				if(!target.HasBadBuffs())
					return false;
					
				if(target.HasGoodBuffs())
					return false;
			}
			if(!target.IsFriend && !target.HasGoodBuffs() && !target.IsBuffer)
				return false;
			if(!target.IsFriend && target.HasBadBuffs())
				return false;
				
            return true;
        }

        public override int GetPriorityPlay(Board board)
        {
            return 1;
        }
	
		public override int GetHandValue(Board board)
		{
			return 7;
		}
    }
}
