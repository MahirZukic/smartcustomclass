using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Inner Fire
namespace HREngine.Bots
{
    [Serializable]
public class CS1_129 : Card
    {
		public override Card Create()
{ return new CS1_129();}
public CS1_129() : base()
        {
            
        }
		
        public CS1_129(CardTemplate newTemplate, bool isFriend, int id) : base(newTemplate,isFriend,id)
        {
            
        }

        public override void Init()
        {
            base.Init();
            TargetTypeOnPlay = TargetType.MINION_BOTH;
        }

        public override void OnPlay(ref Board board, Card target = null,int index = 0,int choice = 0)
        {
            base.OnPlay(ref board, target,index);
            if(target != null)
            {
                target.CurrentAtk = target.CurrentHealth;
            }

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
