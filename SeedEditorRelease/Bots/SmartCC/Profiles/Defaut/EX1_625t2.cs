using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Mind Shatter

namespace HREngine.Bots
{
	[Serializable]
    public class bEX1_625t2 : Behavior
    {
		public bEX1_625t2() : base()
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
		
    }
}
