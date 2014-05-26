using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Ice Lance
namespace HREngine.Bots
{
    [Serializable]
public class CS2_031 : Card
    {
		public CS2_031() : base()
        {
            
        }
		
        public CS2_031(CardTemplate newTemplate, bool isFriend, int id) : base(newTemplate,isFriend,id)
        {
            
        }

        public override void Init()
        {
            base.Init();
            TargetTypeOnPlay = TargetType.BOTH_ENEMY;
        }

        public override void OnPlay(ref Board board, Card target = null,int index = 0)
        {
            base.OnPlay(ref board, target,index);
            if(target != null)
            {
                if(target.IsFrozen)
                {
                    target.Damage(4 + board.GetSpellPower(), ref board);
                }
                else
                {
                    target.IsFrozen = true;
                }
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
