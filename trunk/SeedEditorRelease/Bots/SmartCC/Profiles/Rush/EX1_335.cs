using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Lightspawn

namespace HREngine.Bots
{
	[Serializable]
    public class bEX1_335 : Behavior
    {
		public bEX1_335() : base()
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
