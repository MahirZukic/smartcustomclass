using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Imp Master
namespace HREngine.Bots
{
    [Serializable]
    public class EX1_597 : Card
    {
        public override Card Create()
{ return new EX1_597();}
public EX1_597()
            : base()
        {

        }

        public EX1_597(CardTemplate newTemplate, bool isFriend, int id)
            : base(newTemplate, isFriend, id)
        {

        }

        public override void Init()
        {
            base.Init();
        }

        public override void OnEndTurn(Board board)
        {
            base.OnEndTurn(board);
            /*
            board.AddCardToBoard("EX1_598", IsFriend);

            if(CurrentHealth > 0)
            {
                Damage(1, ref board);

            }*/
        }

        public override void OnPlay(ref Board board, Card target = null,int index = 0,int choice = 0)
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
