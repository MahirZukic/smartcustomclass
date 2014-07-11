using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Aldor Peacekeeper

namespace HREngine.Bots
{
	[Serializable]
    public class bEX1_382 : Behavior
    {
		public bEX1_382() : base()
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
			if(target.CurrentAtk < 4)
				return false;
            return true;
        }

        public override int GetPriorityPlay(Board board)
        {
            return 1;
        }
		
    }
}
