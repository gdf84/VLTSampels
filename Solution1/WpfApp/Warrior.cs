using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp
{
    public class Warrior
    {
        IWeapon weapon;
        public Warrior(IWeapon weapon)
        {
            this.weapon = weapon;
        }

        public string Hit()
        {
            return weapon.Hit();
        }
    }
}
