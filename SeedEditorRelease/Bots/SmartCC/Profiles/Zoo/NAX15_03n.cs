using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Guardian of Icecrown

namespace HREngine.Bots
{
	[Serializable]
    public class bNAX15_03n : Behavior
    {
		public bNAX15_03n() : base()
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
		
		public override int GetHandValue(Board board)
		{
			return 5;
		}
    }
}
