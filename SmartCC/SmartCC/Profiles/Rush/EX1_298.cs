using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Ragnaros the Firelord

namespace HREngine.Bots
{
	[Serializable]
    public class bEX1_298 : Behavior
    {
		public bEX1_298() : base()
        {
            
        }
		
		public override bool ShouldBePlayed(Board board)
        {
			int CountPlayable = 0;
			
			foreach(Card c in board.Hand)
			{
				if(c.template.Id == "EX1_298")
				{
					continue;
				}
					
				if(c.CurrentCost >= 4 && c.Type == Card.CType.MINION)
				{
					CountPlayable++;
				}
			}
			
			if(CountPlayable > 2 && board.MinionEnemy.Count > 3)
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
            return 1;
        }
		
    }
}
