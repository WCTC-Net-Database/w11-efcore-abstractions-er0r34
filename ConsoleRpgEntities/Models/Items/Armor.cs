namespace ConsoleRpgEntities.Models.Items
{
    public class Armor : Item
    {
        public int DefenseRating { get; set; }
        public int Durability { get; set; }

        public override void Use()
        {
            // Implement specific behavior for using armor
            Console.WriteLine($"Using armor: {Name} with {DefenseRating} defense rating.");
        }
    }
}
