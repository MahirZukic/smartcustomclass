using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Flamestrike

namespace HREngine.Bots
{
	[Serializable]
    public class bCS2_032 : Behavior
    {
		public bCS2_032() : base()
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
			return 6;
		}
    }
}