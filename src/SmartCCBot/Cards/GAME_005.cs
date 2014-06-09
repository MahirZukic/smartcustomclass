using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//The Coin
namespace HREngine.Bots
{
    [Serializable]
public class GAME_005 : Card
    {
		public override Card Create()
{ return new GAME_005();}
public GAME_005() : base()
        {
            
        }
		
        public GAME_005(CardTemplate newTemplate, bool isFriend, int id) : base(newTemplate,isFriend,id)
        {
            
        }

        public override void Init()
        {
            base.Init();
            TargetTypeOnPlay = TargetType.NONE;
        }

        public override void OnPlay(ref Board board, Card target = null,int index = 0,int choice = 0)
        {
            base.OnPlay(ref board, target,index);
            board.ManaAvailable++;
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
