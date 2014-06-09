using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Nourish
namespace HREngine.Bots
{
    [Serializable]
public class EX1_164 : Card
    {
		public override Card Create()
{ return new EX1_164();}
public EX1_164() : base()
        {
            
        }
		
        public EX1_164(CardTemplate newTemplate, bool isFriend, int id) : base(newTemplate,isFriend,id)
        {
            
        }

        public override void Init()
        {
            base.Init();
            HasChoices = true;
        }

        public override void OnPlay(ref Board board, Card target = null,int index = 0,int choice = 0)
        {
            base.OnPlay(ref board, target,index);
            if(choice == 1)
            {

            }
            else if(choice == 2)
            {
                board.FriendCardDraw += 3;
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
