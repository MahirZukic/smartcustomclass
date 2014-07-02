using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Knife Juggler

namespace HREngine.Bots
{
	[Serializable]
    public class bNEW1_019 : Behavior
    {
		public bNEW1_019() : base()
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
		
    }
}
