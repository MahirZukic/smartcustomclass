using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Booty Bay Bodyguard
namespace HREngine.Bots
{
    [Serializable]
public class CS2_187 : Card
    {
		public override Card Create()
{ return new CS2_187();}
public CS2_187() : base()
        {
            
        }
		
        public CS2_187(CardTemplate newTemplate, bool isFriend, int id) : base(newTemplate,isFriend,id)
        {
            
        }

        public override void Init()
        {
            base.Init();
            IsTaunt = true;
        }

        public override void OnPlay(ref Board board, Card target = null,int index = 0,int choice = 0)
        {
            base.OnPlay(ref board, target,index);
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
