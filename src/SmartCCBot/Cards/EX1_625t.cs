using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Mind Spike
namespace HREngine.Bots
{
    [Serializable]
public class EX1_625t : Card
    {
		public override Card Create()
{ return new EX1_625t();}
public EX1_625t() : base()
        {
            
        }
		
        public EX1_625t(CardTemplate newTemplate, bool isFriend, int id) : base(newTemplate,isFriend,id)
        {
            
        }

        public override void Init()
        {
            base.Init();
            TargetTypeOnPlay = TargetType.ALL;
        }

        public override void OnPlay(ref Board board, Card target = null,int index = 0,int choice = 0)
        {
            base.OnPlay(ref board, target,index);
            if(target != null)
            {
                target.Damage(2, ref board);
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
