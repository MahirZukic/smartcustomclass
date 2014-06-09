using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Master Swordsmith
namespace HREngine.Bots
{
    [Serializable]
public class NEW1_037 : Card
    {
		public override Card Create()
{ return new NEW1_037();}
public NEW1_037() : base()
        {
            
        }
		
        public NEW1_037(CardTemplate newTemplate, bool isFriend, int id) : base(newTemplate,isFriend,id)
        {
            
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