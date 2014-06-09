using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Dream
namespace HREngine.Bots
{
    [Serializable]
public class DREAM_04 : Card
    {
		public override Card Create()
{ return new DREAM_04();}
public DREAM_04() : base()
        {
            
        }
		
        public DREAM_04(CardTemplate newTemplate, bool isFriend, int id) : base(newTemplate,isFriend,id)
        {
            
        }

        public override void Init()
        {
            base.Init();
            TargetTypeOnPlay = TargetType.MINION_ENEMY;

        }

        public override void OnPlay(ref Board board, Card target = null,int index = 0,int choice = 0)
        {
            base.OnPlay(ref board, target,index);
            if (target != null)
            {
                board.MinionEnemy.Remove(target);
                board.EnemyCardDraw++;
            }
        }

        public override void OnDeath(ref Board board)
        {
            base.OnDeath(ref board);
        }

        public override void OnPlayOtherMinion(ref Board board, Card Minion)
        {
            base.OnPlayOtherMinion(ref board, Minion);
        }

        public override void OnCastSpell(ref Board board, Card Spell)
        {
		    base.OnCastSpell(ref board, Spell);
        }
		
	
		
    }
}