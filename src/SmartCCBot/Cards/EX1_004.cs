using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Young Priestess
namespace HREngine.Bots
{
    [Serializable]
public class EX1_004 : Card
    {
		public override Card Create()
{ return new EX1_004();}
public EX1_004() : base()
        {
            
        }
		
        public EX1_004(CardTemplate newTemplate, bool isFriend, int id) : base(newTemplate,isFriend,id)
        {
            
        }

        public override void OnEndTurn(Board board)
        {
            if(IsFriend)
            {
                Card MinionToBuff = board.GetWorstMinion();
                if(MinionToBuff != null)
                {
                    MinionToBuff.maxHealth += 1;
                    MinionToBuff.CurrentHealth += 1;
                }
            }
            else
            {
                Card MinionToBuff = board.GetWorstEnemyMinion();
                if (MinionToBuff != null)
                {
                    MinionToBuff.maxHealth += 1;
                    MinionToBuff.CurrentHealth += 1;
                }
            }
        }
        public override void Init()
        {
            base.Init();
        }

        public override void OnPlay(ref Board board, Card target = null,int index = 0,int choice = 0)
        {
            base.OnPlay(ref board, target,index);
        }

        public override void OnDeath(ref Board board)
        {
            base.OnDeath(ref board);
        }

        public override void OnPlayOtherMinion(ref Board board, ref Card Minion)
        {
            base.OnPlayOtherMinion(ref board,ref Minion);
        }

        public override void OnCastSpell(ref Board board, Card Spell)
        {
		    base.OnCastSpell(ref board, Spell);
        }
		
    }
}
