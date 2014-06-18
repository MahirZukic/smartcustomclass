using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Mortal Coil
namespace HREngine.Bots
{
    [Serializable]
public class EX1_302 : Card
    {
		public override Card Create()
{ return new EX1_302();}
public EX1_302() : base()
        {
            
        }
		
        public EX1_302(CardTemplate newTemplate, bool isFriend, int id) : base(newTemplate,isFriend,id)
        {
            
        }

        public override void Init()
        {
            base.Init();
            TargetTypeOnPlay = TargetType.MINION_ENEMY;
        }

        public override void OnPlay(ref Board board, Card target = null,int index = 0,int choice = 0)
        {
            base.OnPlay(ref board, target,index);
            if(target != null)
            {
                if (target.CurrentHealth == 1 && !target.IsDivineShield)
                    board.FriendCardDraw++;

                target.Damage(1 + board.GetSpellPower(), ref board);
                board.Resimulate();
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
