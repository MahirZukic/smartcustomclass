using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Captain\'s Parrot

namespace HREngine.Bots
{
	[Serializable]
    public class bNEW1_016 : Behavior
    {
		public bNEW1_016() : base()
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
