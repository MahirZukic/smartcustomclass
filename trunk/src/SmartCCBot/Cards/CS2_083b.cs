using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Dagger Mastery
namespace HREngine.Bots
{
    [Serializable]
public class CS2_083b : Card
    {
		public override Card Create()
{ return new CS2_083b();}
public CS2_083b() : base()
        {
            
        }
		
        public CS2_083b(CardTemplate newTemplate, bool isFriend, int id) : base(newTemplate,isFriend,id)
        {
            
        }

        public override void Init()
        {
            base.Init();
        }

        public override void OnPlay(ref Board board, Card target = null,int index = 0,int choice = 0)
        {
            base.OnPlay(ref board, target,index);

            if(IsFriend)
            {
                board.ReplaceWeapon("CS2_082");

            }
            else
            {
                board.ReplaceEnemyWeapon("CS2_082");

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
