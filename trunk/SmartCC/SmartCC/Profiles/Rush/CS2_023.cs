using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Arcane Intellect

namespace HREngine.Bots
{
	[Serializable]
    public class bCS2_023 : Behavior
    {
		public bCS2_023() : base()
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
            return 10;
        }
		
		public override int GetHandValue(Board board)
		{
			return 1;
		}
		
    }
}
