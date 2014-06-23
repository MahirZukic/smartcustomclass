using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Molten Giant
namespace HREngine.Bots
{
    [Serializable]
    public class EX1_620 : Card
    {
        public override Card Create()
        { return new EX1_620(); }
        public EX1_620()
            : base()
        {

        }

        public EX1_620(CardTemplate newTemplate, bool isFriend, int id)
            : base(newTemplate, isFriend, id)
        {

        }

        public override void OnUpdateHand(Board board)
        {
            base.OnUpdate(board);

            int hpUnderTwenty = (20 - board.HeroFriend.CurrentHealth);

            if (hpUnderTwenty < 0)
                CurrentCost = template.Cost;
            else if (hpUnderTwenty > 0)
            {
                if (hpUnderTwenty > template.Cost)
                {
                    CurrentCost = 0;
                }
                else
                {
                    CurrentCost = template.Cost - hpUnderTwenty;
                }
            }
            else
            {
                CurrentCost = template.Cost;
            }

        }

        public override void Init()
        {
            base.Init();
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
            base.OnPlayOtherMinion(ref board, ref Minion);
        }

        public override void OnCastSpell(ref Board board, Card Spell)
        {
            base.OnCastSpell(ref board, Spell);
        }

    }
}
