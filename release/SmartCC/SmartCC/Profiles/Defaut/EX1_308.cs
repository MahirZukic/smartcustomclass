using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Soulfire

namespace HREngine.Bots
{
	[Serializable]
    public class bEX1_308 : Behavior
    {
		public bEX1_308() : base()
        {
            
        }
		
		public override bool ShouldBePlayed(Board board)
        {
			foreach(Card c in board.Hand)
			{
				if(c.CurrentCost <= board.ManaAvailable && c.Type == Card.CType.MINION)
				{
					return false;
				}
				
				
				if(c.Type == Card.CType.SPELL)
				{
					if(c.Behavior == this || c.template.Id == "EX1_308")
						continue;
					foreach(Card enemy in board.MinionEnemy)
					{
						if(c.Behavior.ShouldBePlayedOnTarget(enemy))
							return false;
					}
				
					if(c.Behavior.ShouldBePlayedOnTarget(board.HeroEnemy))
						return false;
				}
			}
			
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
			
            if (target.CurrentHealth > 4)
                    return false;

            return true;
        }

        public override int GetPriorityPlay(Board board)
        {
            return 1;
        }
		
    }
}
