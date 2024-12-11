using ConsoleRpgEntities.Models.Abilities.PlayerAbilities;
using ConsoleRpgEntities.Models.Attributes;
using ConsoleRpgEntities.Models.Items;

namespace ConsoleRpgEntities.Models.Characters
{
    public class Player : ITargetable, IPlayer
    {
        public int Experience { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public virtual IEnumerable<Ability> Abilities { get; set; }
        public virtual Equipment Equipment { get; set; } // Make this property virtual
        public int? EquipmentId { get; set; } // Foreign key property
        public ICollection<Item> Inventory { get; set; } = new List<Item>();


        public void Attack(ITargetable target)
        {
            int attackPower = Equipment?.Weapon?.AttackPower ?? 0;
            Console.WriteLine($"{Name} attacks {target.Name} with {Equipment?.Weapon?.Name ?? "bare hands"} for {attackPower} damage!");
        }

        public void UseAbility(IAbility ability, ITargetable target)
        {
            if (Abilities.Contains(ability))
            {
                ability.Activate(this, target);
            }
            else
            {
                Console.WriteLine($"{Name} does not have the ability {ability.Name}!");
            }
        }
    }
}
