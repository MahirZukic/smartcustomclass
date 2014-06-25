using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Dagger Mastery

namespace HREngine.Bots
{
	[Serializable]
    public class bCS2_083b : Behavior
    {
		public bCS2_083b() : base()
        {
            
        }
		
		public override bool ShouldBePlayed(Board board)
        {
			if(board.WeaponFriend != null)
				if(board.WeaponFriend.CurrentAtk > 1)
					return false;
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
		
    }
}
