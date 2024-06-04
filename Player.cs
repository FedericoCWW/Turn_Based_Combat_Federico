using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedCombat
{
    public class Player
    {
        public string Name { get; set; }
        public int Attack { get; set; }
        public int Defense{ get; set; }
        public int HitPoints{ get; set; }
        public bool isDefending { get; set; }
        public bool IsDefending {
            get { return isDefending; }
            set { isDefending = false; }
        }

        public override string ToString()
        {
            return ($"- Clase: {Name}\n- Puntos de ataque: {Attack}\n- Puntos de defensa: {Defense}\n- Puntos de vida: {HitPoints}");
        }

    }
}
