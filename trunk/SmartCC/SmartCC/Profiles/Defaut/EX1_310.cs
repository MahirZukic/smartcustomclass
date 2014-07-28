using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Doomguard

namespace HREngine.Bots
{
	[Serializable]
    public class bEX1_310 : Behavior
    {
		public bEX1_310() : base()
        {
            
        }
		
		public override bool ShouldBePlayed(Board board)
        {
			int CountPlayable = 0;
			int ValuePlayable = 0;
			int CostPlayable = 0;
			int MyValue = 0;

			foreach(Card c in board.Hand)
			{
				if(c.template.Id == "EX1_310")
				{
					MyValue = (int)c.GetValue(board);
					continue;
				}
					
				if(c.CurrentCost <= board.ManaAvailable && c.Type == Card.CType.MINION || c.Type == Card.CType.SPELL)
				{
					if(c.Type == Card.CType.SPELL)
					{
						foreach(Card cc in board.MinionEnemy)
						{
							if(c.Behavior.ShouldBePlayedOnTarget(board,cc))
							{
								CostPlayable += c.CurrentCost;
								CountPlayable++;
								ValuePlayable += (int)c.GetValue(board);
							}
						}
					}
					else
					{
						CostPlayable += c.CurrentCost;
						CountPlayable++;
						ValuePlayable += (int)c.GetValue(board);
					}
				}
			}
			
			int sum = 0;
			foreach(Card c in board.MinionFriend)
			{
				sum += c.CurrentAtk;
			}
				
		
			if(sum + 10 >= board.HeroEnemy.CurrentHealth + board.HeroEnemy.CurrentArmor)
				return true;
				
			if(CountPlayable < 2 && MyValue > ValuePlayable)
				return true;
				
			if(CountPlayable == 2 && CostPlayable >= 4)
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
		
		public override int GetHandValue(Board board)
		{
			if(board.Hand.Count == 1)
				return 0;
			
			if(board.Hand.Count == 2)
				return 50;
			
			return 75;
		}
		
    }
}
