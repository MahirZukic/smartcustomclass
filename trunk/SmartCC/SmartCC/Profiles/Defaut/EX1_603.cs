using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Cruel Taskmaster

namespace HREngine.Bots
{
	[Serializable]
    public class bEX1_603 : Behavior
    {
		public bEX1_603() : base()
        {
            
        }
		
		public override bool ShouldBePlayed(Board board)
        {
			if(board.MinionFriend.Count == 0 && board.MinionEnemy.Count == 0)
				return false;
				
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
			if(target.IsFriend && target.CurrentHealth == 1 && !target.IsDivineShield)
				return false;
			
			if(!target.CanAttack && target.IsFriend)
				return false;
			
            return true;
        }

        public override int GetPriorityPlay(Board board)
        {
            return 1;
        }
		
    }
}
