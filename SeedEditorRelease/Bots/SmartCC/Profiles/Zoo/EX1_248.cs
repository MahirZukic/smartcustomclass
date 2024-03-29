using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Feral Spirit

namespace HREngine.Bots
{
	[Serializable]
    public class bEX1_248 : Behavior
    {
		public bEX1_248() : base()
        {
            
        }
		
		public override bool ShouldBePlayed(Board board)
        {
            if (board.MinionFriend.Count > 5)
                return false;
				
			int otherDrop = 0;
			foreach(Card c in board.Hand)
			{
				if(c.CurrentCost == 3)
				{
					otherDrop++;
				}
			}
			/*if(otherDrop > 0)
				return false;*/
			
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
            return true;
        }

        public override int GetPriorityPlay(Board board)
        {
            return 1;
        }
		
    }
}
