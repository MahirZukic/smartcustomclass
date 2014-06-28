using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Fireball

namespace HREngine.Bots
{
	[Serializable]
    public class bCS2_029 : Behavior
    {
		public bCS2_029() : base()
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

        public override bool ShouldAttackTarget(Card target)
        {
            return true;
        }
		
		public override bool ShouldBePlayedOnTarget(Card target)
        {
            return true;
        }

        public override int GetPriorityPlay(Board board)
        {
            return 1;
        }
		
		public override int GetHandValue(Board board)
		{
			int ret = 6;
			foreach(Card c in board.MinionFriend)
			{
				if(c.template.Id == "EX1_559")
				{
					ret += 4;
				}
			}
			
			return ret;
		}
		
    }
}
