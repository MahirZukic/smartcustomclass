using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Ancestral Healing
namespace HREngine.Bots
{
    [Serializable]
public class CS2_041 : Card
    {
		public override Card Create()
{ return new CS2_041();}
public CS2_041() : base()
        {
            
        }
		
        public CS2_041(CardTemplate newTemplate, bool isFriend, int id) : base(newTemplate,isFriend,id)
        {
            
        }

        public override void Init()
        {
            base.Init();
            TargetTypeOnPlay = TargetType.MINION_FRIEND;
        }

        public override void OnPlay(ref Board board, Card target = null,int index = 0,int choice = 0)
        {
            base.OnPlay(ref board, target,index);
            if(target != null)
            {
                target.CurrentHealth = target.MaxHealth;
                target.IsTaunt = true;
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
