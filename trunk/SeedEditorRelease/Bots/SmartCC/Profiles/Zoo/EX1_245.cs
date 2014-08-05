using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Earth Shock

namespace HREngine.Bots
{
	[Serializable]
    public class bEX1_245 : Behavior
    {
		private int spellPower = 0;
		public bEX1_245() : base()
        {
            
        }
		
		public override bool ShouldBePlayed(Board board)
        {
			spellPower = board.GetSpellPower();
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
		
    }
}
