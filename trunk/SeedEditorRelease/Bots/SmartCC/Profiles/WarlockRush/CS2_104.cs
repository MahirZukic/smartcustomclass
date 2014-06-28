using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Rampage

namespace HREngine.Bots
{
	[Serializable]
    public class bCS2_104 : Behavior
    {
		public bCS2_104() : base()
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
            if (target.CurrentHealth < target.MaxHealth)
                return true;
            return false;
        }

        public override int GetPriorityPlay(Board board)
        {
            return 1;
        }
		
    }
}
