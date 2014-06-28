using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Loot Hoarder

namespace HREngine.Bots
{
	[Serializable]
    public class bEX1_096 : Behavior
    {
		public bEX1_096() : base()
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
		
		public override int GetPriorityAttack(Board board)
        {
            return 3;
        }
    }
}
