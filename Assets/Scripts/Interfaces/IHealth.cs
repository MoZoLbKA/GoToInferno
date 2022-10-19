using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Interfaces
{
    public interface IHealth
    {
        public int MaxHealth { get; }
        public void TakeDamage(int damage);
        public void Heal(int value);
    }
}
