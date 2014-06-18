using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Armorsmith
namespace HREngine.Bots
{
    [Serializable]
    public class EX1_402 : Card
    {
        public override Card Create()
        { return new EX1_402(); }
        public EX1_402()
            : base()
        {

        }

        public EX1_402(CardTemplate newTemplate, bool isFriend, int id)
            : base(newTemplate, isFriend, id)
        {

        }

        public override void Init()
        {
            base.Init();
        }

        public override void OnHit(ref Board board, Card actor)
        {
            base.OnHit(ref board, actor);
            if (IsFriend)
            {
                board.HeroFriend.CurrentArmor++;

            }
            else
            {
                board.HeroEnemy.CurrentArmor++;

            }
        }
        public override void OnOtherMinionDamage(ref Board board, Card minionDamaged)
        {
            base.OnOtherMinionDamage(ref board, minionDamaged);
            if (IsFriend && minionDamaged.IsFriend)
            {
                board.HeroFriend.CurrentArmor++;

            }
            else if (!IsFriend && !minionDamaged.IsFriend)
            {
                board.HeroEnemy.CurrentArmor++;

            }
        }

        public override void OnPlay(ref Board board, Card target = null, int index = 0, int choice = 0)
        {
            base.OnPlay(ref board, target, index);
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
