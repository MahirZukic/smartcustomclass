using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Dispel
namespace HREngine.Bots
{
    [Serializable]
public class EX1_166b : Card
    {
		public override Card Create()
{ return new EX1_166b();}
public EX1_166b() : base()
        {
            
        }
		
        public EX1_166b(CardTemplate newTemplate, bool isFriend, int id) : base(newTemplate,isFriend,id)
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
