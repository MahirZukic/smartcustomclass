using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Consecration

namespace HREngine.Bots
{
	[Serializable]
    public class bCS2_093 : Behavior
    {
		public bCS2_093() : base()
        {
            
        }
		
		public override bool ShouldBePlayed(Board board)
        {
			int nbCards = 0;
			
			foreach(Card c in board.Hand)
			{
				if(c.template.Id == "CS2_093")
				{
					nbCards++;
				}
			}
			
			if(board.HeroEnemy.CurrentHealth + board.HeroEnemy.CurrentArmor <= nbCards *(2+board.GetSpellPower()))
				return true;
			
			
			if(board.MinionEnemy.Count < 2)
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
