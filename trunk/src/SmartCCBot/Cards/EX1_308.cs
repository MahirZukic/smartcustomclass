using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Soulfire
namespace HREngine.Bots
{
    [Serializable]
public class EX1_308 : Card
    {
        public override Card Create()
{ return new EX1_308();}
public EX1_308()
            : base()
        {

        }

        public EX1_308(CardTemplate newTemplate, bool isFriend, int id)
            : base(newTemplate, isFriend, id)
        {

        }

        public override void Init()
        {
            base.Init();
            TargetTypeOnPlay = TargetType.BOTH_ENEMY;
        }

        public override void OnPlay(ref Board board, Card target = null,int index = 0,int choice = 0)
        {
            base.OnPlay(ref board, target,index);
            target.Damage(4 + board.GetSpellPower(), ref board);
            if (board.Hand.Count <= 1)
                board.Hand.Clear();

            board.FriendCardDraw--;

            board.Resimulate();

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
