using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Anub\'Rekhan

namespace HREngine.Bots
{
	[Serializable]
    public class bNAX1_01 : Behavior
    {
		public bNAX1_01() : base()
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
