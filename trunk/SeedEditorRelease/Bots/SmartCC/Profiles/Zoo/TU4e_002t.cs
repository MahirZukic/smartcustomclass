using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Flame of Azzinoth

namespace HREngine.Bots
{
	[Serializable]
    public class bTU4e_002t : Behavior
    {
		public bTU4e_002t() : base()
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
