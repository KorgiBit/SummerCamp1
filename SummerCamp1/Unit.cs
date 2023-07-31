using System;

namespace SummerCamp1
{
    internal class Unit
    {
        private readonly string _name;
        private float _neutralAttackMultiplier = 1;
        private float _friendlyAttackMultiplier = 0.5f;
        private float _enemyAttackMultiplier = 1.5f;

        private float _berserkarmorMultiplier = 0.2f;


        private int _attackPower { get; set; }
        private int _armor { get; set; }
        private float _health;

        private bool _isBerserk;
        private Factions Faction;

        public Unit(string name, float heath, int attackPower, int armor, Factions faction, bool isBerserk = false)
        {
            _name = name;
            _health = heath;
            _attackPower = attackPower;
            _armor = armor;
            Faction = faction;
            _isBerserk = isBerserk;
        }


        public void Attack(Unit enemy)
        {
            TakeDamage(_attackPower, enemy);
        }

        private void TakeDamage(float attackPower, Unit attacker)
        {
            if (attackPower <= 0)
            {
                return;
            }
            float berserkMultiplier =  _isBerserk ? 2 : 1;
            


            float damageReduction = _armor / 100.0f;
            if (_isBerserk)
            {
                damageReduction *= _berserkarmorMultiplier;
            }

            float actualDamage = attackPower * berserkMultiplier * CalculateFractionMultiplier( attacker) * (1 - damageReduction);
            _health -= actualDamage;

            Console.WriteLine(_name + " получил урон : " + actualDamage);
            Console.WriteLine(_name + " осталось хп : " + _health);

        }

        public void PrintInfo()
        {
            Console.WriteLine("Сила атаки: ", _attackPower);
            Console.WriteLine("здоровье: ", _health);
            Console.WriteLine("броня: ", _armor);
        }

        private float CalculateFractionMultiplier(Unit attacker)
        {
            if (attacker.Faction == Factions.Neutral)
            {
                return _neutralAttackMultiplier;
            } else if (attacker.Faction == Faction) {
                
                return _friendlyAttackMultiplier;
            } else
            {
                
                return _enemyAttackMultiplier;
            }
            
        }
    }
}
