using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Steady Shot

namespace HREngine.Bots
{
	[Serializable]
    public class bDS1h_292 : Behavior
    {
		public bDS1h_292() : base()
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
