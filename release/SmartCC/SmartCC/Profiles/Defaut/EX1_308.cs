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
            int CountPlayable = 0;

			foreach(Card c in board.Hand)
			{	
				if(c.CurrentCost <= board.ManaAvailable && c.Type == Card.CType.MINION || c.Type == Card.CType.SPELL)
				{
					if(c.Type == Card.CType.SPELL)
					{
						foreach(Card cc in board.MinionEnemy)
						{
							if(c.Behavior.ShouldBePlayedOnTarget(cc))
							{
								CountPlayable++;
							}
						}
					}
					else
					{
						CountPlayable++;
					}
				}
			}
			
			int sum = 0;
			foreach(Card c in board.MinionFriend)
			{
				sum += c.CurrentAtk;
			}
				
		
			if(sum + 4 >= board.HeroEnemy.CurrentHealth + board.HeroEnemy.CurrentArmor && CountPlayable < 3)
				return true;
				
				
			if(CountPlayable > 3)
			{
				return false;
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
