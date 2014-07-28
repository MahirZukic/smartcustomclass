using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Arcane Missiles

namespace HREngine.Bots
{
	[Serializable]
    public class bEX1_277 : Behavior
    {
		public bEX1_277() : base()
        {
            
        }
		
		public override bool ShouldBePlayed(Board board)
        {
			int cardInHand = 0;
			
			foreach(Card c in board.Hand)
			{
				if(c.template.Id == "EX1_277")
					cardInHand++;
			}
			
			if(board.HeroEnemy.CurrentHealth + board.HeroEnemy.CurrentArmor <= cardInHand * (3 + board.GetSpellPower()))
				return true;
			
			
            if (board.MinionEnemy.Count == 0 && board.HeroEnemy.CurrentHealth > 15)
                return false;
				
			int nbTarget = 0;
			int targetHp = 2;
			if(board.MinionEnemy.Count > 2)
			{
				targetHp = 1;
			}
			
			foreach(Card c in board.MinionEnemy)
			{
				if(c.CurrentHealth <= targetHp)
				{
					nbTarget++;
				}
			}
			
			if(nbTarget < 1)
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
            return 11;
        }
		
    }
}
