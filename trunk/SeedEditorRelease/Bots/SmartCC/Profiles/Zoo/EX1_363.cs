using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Blessing of Wisdom

namespace HREngine.Bots
{
	[Serializable]
    public class bEX1_363 : Behavior
    {
		public bEX1_363() : base()
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
			if(target.CurrentHealth < 3)
				return false;
				
            return target.CanAttack;
        }

        public override int GetPriorityPlay(Board board)
        {
            return 1;
        }
		
    }
}
