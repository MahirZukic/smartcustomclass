using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Blessed Champion
namespace HREngine.Bots
{
    [Serializable]
public class EX1_355 : Card
    {
		public override Card Create()
{ return new EX1_355();}
public EX1_355() : base()
        {
            
        }
		
        public EX1_355(CardTemplate newTemplate, bool isFriend, int id) : base(newTemplate,isFriend,id)
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
                target.currentAtk = target.CurrentAtk*2;
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
