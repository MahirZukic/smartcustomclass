using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Northshire Cleric
namespace HREngine.Bots
{
    [Serializable]
public class CS2_235 : Card
    {
		public override Card Create()
{ return new CS2_235();}
public CS2_235() : base()
        {
            
        }
		
        public CS2_235(CardTemplate newTemplate, bool isFriend, int id) : base(newTemplate,isFriend,id)
        {
            
        }

        public override float GetValue(Board board)
        {
            if (!IsFriend)
            {
                return base.GetValue(board) + 5;
            }
            else
            {
                return base.GetValue(board);
            }
        }

        public override void Init()
        {
            base.Init();
        }
        public override void OnOtherMinionHeal()
        {
            base.OnOtherMinionHeal();

        }
        public override void OnPlay(ref Board board, Card target = null,int index = 0,int choice = 0)
        {
            base.OnPlay(ref board, target,index);
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
