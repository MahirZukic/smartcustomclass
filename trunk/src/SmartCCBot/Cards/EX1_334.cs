using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Shadow Madness
namespace HREngine.Bots
{
    [Serializable]
public class EX1_334 : Card
    {
        public override Card Create()
{ return new EX1_334();}
public EX1_334()
            : base()
        {

        }

        public EX1_334(CardTemplate newTemplate, bool isFriend, int id)
            : base(newTemplate, isFriend, id)
        {

        }

        public override void Init()
        {
            base.Init();
            TargetTypeOnPlay = TargetType.MINION_ENEMY;
        }


        public override void OnPlay(ref Board board, Card target = null,int index = 0,int choice = 0)
        {
            base.OnPlay(ref board, target, index);
            if (target != null)
            {
                board.MinionEnemy.Remove(target);
                board.MinionFriend.Add(target);
            }
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
