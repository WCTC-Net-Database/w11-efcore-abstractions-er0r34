namespace ConsoleRpgEntities.Models.Items
{
    public class Weapon : Item
    {
        public int AttackPower { get; set; }
        public int Durability { get; set; }

        public override void Use()
        {
            // Implement specific behavior for using a weapon
            Console.WriteLine($"Using weapon: {Name} with {AttackPower} attack power.");
        }
    }
}
