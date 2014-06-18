using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Mana Tide Totem
namespace HREngine.Bots
{
    [Serializable]
public class EX1_575 : Card
    {
		public override Card Create()
{ return new EX1_575();}
public EX1_575() : base()
        {
            
        }
		
        public EX1_575(CardTemplate newTemplate, bool isFriend, int id) : base(newTemplate,isFriend,id)
        {
            
        }

        public override float GetValue(Board board)
        {
            if(!IsFriend)
            {
                return base.GetValue(board) + 5;
            }
            else
            {
                if (board.Hand.Count < 4)
                {
                    return base.GetValue(board) + 5;
                }

                return base.GetValue(board);
            }
        }
        public override void Init()
        {
            base.Init();
        }

        public override void OnEndTurn(Board board)
        {
            base.OnEndTurn(board);
            if(IsFriend)
            {
                //board.FriendCardDraw++;

            }
            else
            {
                board.EnemyCardDraw++;
            }
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
