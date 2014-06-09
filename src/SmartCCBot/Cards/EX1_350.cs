using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Prophet Velen
namespace HREngine.Bots
{
    [Serializable]
public class EX1_350 : Card
    {
		public override Card Create()
{ return new EX1_350();}
public EX1_350() : base()
        {
            
        }
		
        public EX1_350(CardTemplate newTemplate, bool isFriend, int id) : base(newTemplate,isFriend,id)
        {
            
        }

        public override void Init()
        {
            base.Init();
        }

        public override void OnPlay(ref Board board, Card target = null,int index = 0,int choice = 0)
        {
            base.OnPlay(ref board, target,index);

            if (IsFriend)
            {
                board.HealFactor *= 2;
            }
            
        }

        public override void OnUpdate(Board board)
        {
            base.OnUpdate(board);

            if(!IsFriend && board.EnemyHealFactor == 1 || board.EnemyHealFactor == -1)
            {
                board.EnemyHealFactor *= 2;
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
