using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Aldor Peacekeeper

namespace HREngine.Bots
{
	[Serializable]
    public class bEX1_382 : Behavior
    {
		private int boardEnemyCard = 0;
		private int OwnCards = 0;
		private int EnemyMinion = 0;
		
		public bEX1_382() : base()
        {
            
        }
		
		public override bool ShouldBePlayed(Board board)
        {
			boardEnemyCard = board.EnemyCardCount;
			OwnCards = board.Hand.Count;
			EnemyMinion = board.MinionEnemy.Count;
		
			if(board.EnemyCardCount < 4)
				return true;
			if(board.MinionEnemy.Count < 1)
				return false;
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
			if(target.CurrentAtk < 3)
				return false;
				
            return true;
        }

        public override int GetPriorityPlay(Board board)
        {
            return 1;
        }
		
		public override int GetMinionValue(Board board)
		{
			return 10;
		}
		
    }
}
