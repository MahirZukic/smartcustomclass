using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Earth Shock

namespace HREngine.Bots
{
	[Serializable]
    public class bEX1_245 : Behavior
    {
		public bEX1_245() : base()
        {
            
        }
		
		public override bool ShouldBePlayed(Board board)
        {
			bool Killable = false;
			foreach(Card c in board.MinionEnemy)
			{
				if(c.CurrentHealth <= 1 + board.GetSpellPower())
					Killable = true;
				if(c.HasGoodBuffs() || c.IsBuffer)
					return true;
			}
            foreach(Card c in board.MinionFriend)
			{
				if(c.HasBadBuffs())
					return true;
			}
			
			if(Killable)
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
			if(target.IsFriend && !target.HasBadBuffs())
				return false;
				
            return true;
        }

        public override int GetPriorityPlay(Board board)
        {
            return 1;
        }
		
		public override int GetHandValue(Board board)
		{
			return 6;
		}
    }
}
