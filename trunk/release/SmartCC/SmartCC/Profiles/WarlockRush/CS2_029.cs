using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Fireball

namespace HREngine.Bots
{
	[Serializable]
    public class bCS2_029 : Behavior
    {
		public bCS2_029() : base()
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
            if (target.CurrentHealth > 4)
                return true;
            return false;
        }

        public override int GetPriorityPlay(Board board)
        {
            return 1;
        }
		
    }
}
