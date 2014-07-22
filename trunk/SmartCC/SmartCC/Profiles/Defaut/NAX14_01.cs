using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Sapphiron

namespace HREngine.Bots
{
	[Serializable]
    public class bNAX14_01 : Behavior
    {
		public bNAX14_01() : base()
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
