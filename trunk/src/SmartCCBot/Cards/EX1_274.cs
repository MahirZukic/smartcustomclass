using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Ethereal Arcanist
namespace HREngine.Bots
{
    [Serializable]
public class EX1_274 : Card
    {
		public EX1_274() : base()
        {
            
        }
		
        public EX1_274(CardTemplate newTemplate, bool isFriend, int id) : base(newTemplate,isFriend,id)
        {
            
        }

        public override void Init()
        {
            base.Init();
        }

        public override void OnEndTurn(Board board)
        {
            if(IsFriend)
            {
                if (board.Secret.Count > 0)
                {
                    currentAtk += 2;
                    maxHealth += 2;
                    CurrentHealth += 2;
                }
               
            }
            else
            {
                if (board.SecretEnemy)
                {
                    currentAtk += 2;
                    maxHealth += 2;
                    CurrentHealth += 2;
                }
            }
           
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
