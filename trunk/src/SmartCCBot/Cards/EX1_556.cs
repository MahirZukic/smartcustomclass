using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Harvest Golem
namespace HREngine.Bots
{
    [Serializable]
public class EX1_556 : Card
    {
		public override Card Create()
{ return new EX1_556();}
public EX1_556() : base()
        {
            
        }
		
        public EX1_556(CardTemplate newTemplate, bool isFriend, int id) : base(newTemplate,isFriend,id)
        {
            
        }

        public override void Init()
        {
            base.Init();
        }

        public override float GetValue(Board board)
        {
            return base.GetValue(board) + 5;
        }

        public override void OnPlay(ref Board board, Card target = null,int index = 0,int choice = 0)
        {
            base.OnPlay(ref board, target,index);
        }

        public override void OnDeath(ref Board board)
        {
            base.OnDeath(ref board);
            board.AddCardToBoard("skele21", IsFriend);
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
