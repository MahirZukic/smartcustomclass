using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HREngine.Bots
{
	[Serializable]
    public class bProfileBehavior : ProfileBehavior
    {
		public bProfileBehavior() : base()
        {
            
        }
		
		public override bool ShouldPlayMoreMinions(Board board)
        {
            return true;
        }
		
		public override bool ShouldAttackWithWeapon(Board board)
        {
            return true;
        }

        public override bool ShouldAttackTargetWithWeapon(Card weapon,Card target)
        {
            return true;
        }
		
    }
}
