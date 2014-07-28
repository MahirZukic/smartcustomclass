using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Twisting Nether

namespace HREngine.Bots
{
	[Serializable]
    public class bEX1_312 : Behavior
    {
		public bEX1_312() : base()
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
