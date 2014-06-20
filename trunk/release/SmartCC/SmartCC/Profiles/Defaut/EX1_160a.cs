using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Summon a Panther

namespace HREngine.Bots
{
	[Serializable]
    public class bEX1_160a : Behavior
    {
		public bEX1_160a() : base()
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
		
    }
}
