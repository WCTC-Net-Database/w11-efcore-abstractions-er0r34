using ConsoleRpgEntities.Models.Attributes;
using ConsoleRpgEntities.Models.Items;

namespace ConsoleRpgEntities.Models.Characters.Monsters
{
    public class Goblin : Monster
    {
        public int Sneakiness { get; set; }

        public override void Attack(ITargetable target)
        {
            // Goblin-specific attack logic
            Console.WriteLine($"{Name} sneaks up and attacks {target.Name}!");
        }
    }
}
