using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Alarm-o-Bot

namespace HREngine.Bots
{
	[Serializable]
    public class bEX1_006 : Behavior
    {
		public bEX1_006() : base()
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
