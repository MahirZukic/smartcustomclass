using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Abusive Sergeant

namespace HREngine.Bots
{
	[Serializable]
    public class bCS2_188 : Behavior
    {
		public bCS2_188() : base()
        {
            
        }
		
		public override bool ShouldBePlayed(Board board)
        {
			foreach(Card c in board.MinionFriend)
			{
				if(c.CanAttack || c.CurrentAtk == 0)
					return true;
			}
			
			if(board.TurnCount > 1 && board.MinionFriend.Count == 0)
				return true;
			
            return false;
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
