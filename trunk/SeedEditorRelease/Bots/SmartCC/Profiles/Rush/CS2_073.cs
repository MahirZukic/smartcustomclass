using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Cold Blood

namespace HREngine.Bots
{
	[Serializable]
    public class bCS2_073 : Behavior
    {
		public bCS2_073() : base()
        {
            
        }
		
		public override bool ShouldBePlayed(Board board)
        {
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
		
		public override int GetHandValue(Board board)
		{
			foreach(Card c in board.MinionFriend)
			{
				if(c.template.Id == "EX1_008" && c.IsDivineShield && board.MinionFriend.Count == 1)
					return 4;
			}
			return 8;
		}
    }
}
