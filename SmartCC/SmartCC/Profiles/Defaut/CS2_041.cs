using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Ancestral Healing

namespace HREngine.Bots
{
	[Serializable]
    public class bCS2_041 : Behavior
    {
		public bCS2_041() : base()
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
			return 3;
		}
		
    }
}