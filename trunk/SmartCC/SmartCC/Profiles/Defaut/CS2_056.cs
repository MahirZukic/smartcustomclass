using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Life Tap

namespace HREngine.Bots
{
	[Serializable]
    public class bCS2_056 : Behavior
    {
		public bCS2_056() : base()
        {
            
        }
		
		public override bool ShouldBePlayed(Board board)
        {
			bool hasSoulfire = false;
			bool hasDoomguard = false;
			
			foreach(Card c in board.Hand)
			{
				if(c.template.Id == "EX1_308")
					hasSoulfire = true;
				if(c.template.Id == "EX1_310")
					hasDoomguard = true;
			}
			
			if(hasDoomguard && board.Hand.Count <= 3 && board.TurnCount > 5)
				return false;
			
             if (board.HeroFriend.CurrentHealth < 5 || board.Hand.Count > 5)
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
            return 2;
        }
		
    }
}
