using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Arcane Missiles

namespace HREngine.Bots
{
	[Serializable]
    public class bEX1_277 : Behavior
    {
		public bEX1_277() : base()
        {
            
        }
		
		public override bool ShouldBePlayed(Board board)
        {
            if (board.MinionEnemy.Count == 0 && board.HeroEnemy.CurrentHealth > 15)
                return false;
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
