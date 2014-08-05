using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Big Game Hunter

namespace HREngine.Bots
{
	[Serializable]
    public class bEX1_005 : Behavior
    {
		public bEX1_005() : base()
        {
            
        }
		
		public override bool ShouldBePlayed(Board board)
        {
			bool potentialEnemyTarget = false;
			foreach(Card c in board.MinionEnemy)
			{
				if(ShouldBePlayedOnTarget(board,c))
					potentialEnemyTarget = true;
			}
			
			foreach(Card c in board.MinionFriend)
			{
				if(c.CurrentAtk >= 7 && !potentialEnemyTarget)
					return false;
			}
			
		
            foreach(Card c in board.MinionEnemy)
            {
                if (c.CurrentAtk >= 7)
                    return true;
            }

            int PlayableMinion = 0;
			
			foreach(Card cc in board.Hand)
			{
				if(cc.template.Id == "EX1_005")
					continue;
					
				if(cc.Type == Card.CType.MINION)
					if(cc.CurrentCost <= board.ManaAvailable)
						PlayableMinion ++;
			}
			
			if(PlayableMinion == 0 && board.EnemyCardCount < 3 && board.TurnCount > 10)
				return true;

				
				
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
			if(target.CurrentAtk < 7)
				return false;
            return true;
        }

        public override int GetPriorityPlay(Board board)
        {
            return 1;
        }
		
    }
}
