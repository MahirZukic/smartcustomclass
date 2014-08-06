using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Keeper of the Grove

namespace HREngine.Bots
{
	[Serializable]
    public class bEX1_166 : Behavior
    {
		public bEX1_166() : base()
        {
            
        }
		
		public override bool ShouldBePlayed(Board board)
        {
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
			if(target.IsFriend)
			{
				if(!target.HasBadBuffs())
					return false;
			}
			
			if(target.Type == Card.CType.HERO && !target.IsFriend && board.GetHeroEnemyHpAndArmor() > 2)
				return false;
			
            return true;
        }

        public override int GetPriorityPlay(Board board)
        {
            return 1;
        }
		
		public override int GetMinionValue(Board board)
		{
			foreach(Card c in board.MinionEnemy)
			{
				if(c.template.Id == "FP1_007" && !c.IsSilenced)
					return 0;
			}
			
			return 20;
		}
		
    }
}
