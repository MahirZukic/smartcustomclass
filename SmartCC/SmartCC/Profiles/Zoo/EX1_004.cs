using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Young Priestess

namespace HREngine.Bots
{
	[Serializable]
    public class bEX1_004 : Behavior
    {
		public bEX1_004() : base()
        {
            
        }
		
		public override bool ShouldBePlayed(Board board)
        {
			if(board.TurnCount == 1 && !board.HasCardInHand("GAME_005") && board.MinionFriend.Count == 0 && (board.EnemyClass == Board.Class.ROGUE || board.EnemyClass == Board.Class.MAGE || board.EnemyClass == Board.Class.DRUID))
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
            return true;
        }

        public override int GetPriorityPlay(Board board)
        {
            return 1;
        }
		
    }
}