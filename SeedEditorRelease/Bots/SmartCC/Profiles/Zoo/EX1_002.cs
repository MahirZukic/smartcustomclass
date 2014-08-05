using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//The Black Knight

namespace HREngine.Bots
{
	[Serializable]
    public class bEX1_002 : Behavior
    {
		public bEX1_002() : base()
        {
            
        }
		
		public override bool ShouldBePlayed(Board board)
        {
			int PlayableMinion = 0;
			
			foreach(Card cc in board.Hand)
			{
				if(cc.template.Id == "EX1_002")
					continue;
					
				if(cc.Type == Card.CType.MINION)
					if(cc.CurrentCost <= board.ManaAvailable)
						PlayableMinion ++;
			}
			
			if(PlayableMinion == 0 && board.EnemyCardCount < 3 && board.TurnCount > 10)
				return true;
			
			foreach(Card c in board.MinionEnemy)
			{
				if(c.IsTaunt)
					return true;
			}
			
            return false;
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
            if (target.IsTaunt)
                return true;

            return false;
        }

        public override int GetPriorityPlay(Board board)
        {
            return 1;
        }
		
    }
}
