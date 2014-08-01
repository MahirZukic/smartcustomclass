using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Timber Wolf

namespace HREngine.Bots
{
	[Serializable]
    public class bDS1_175 : Behavior
    {
		public bDS1_175() : base()
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
			return 40;
		}
    }
}
