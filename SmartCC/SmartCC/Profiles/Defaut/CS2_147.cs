using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Gnomish Inventor

namespace HREngine.Bots
{
	[Serializable]
    public class bCS2_147 : Behavior
    {
		public bCS2_147() : base()
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
            return 11;
        }
		
    }
}