using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Acolyte of Pain

namespace HREngine.Bots
{
	[Serializable]
    public class bEX1_007 : Behavior
    {
		public bEX1_007() : base()
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