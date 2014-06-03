using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Cleave

namespace HREngine.Bots
{
	[Serializable]
    public class bCS2_114 : Behavior
    {
		public bCS2_114() : base()
        {
            
        }
		
		public override bool ShouldBePlayed(Board board)
        {
			int countMinionBelow2Hp = 0;
			foreach(Card c in board.MinionEnemy)
			{
				if(c.CurrentHealth <= 2)
					countMinionBelow2Hp++;
			}
            if (board.MinionEnemy.Count >= 2 && countMinionBelow2Hp > 1)
                return true;
            return false;
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
