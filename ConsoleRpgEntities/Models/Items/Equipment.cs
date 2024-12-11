namespace ConsoleRpgEntities.Models.Items
{
    public class Equipment
    {
        public int Id { get; set; }
        public int? WeaponId { get; set; } // Foreign key property
        public int? ArmorId { get; set; } // Foreign key property
        public virtual Weapon Weapon { get; set; } // Make this property virtual
        public virtual Armor Armor { get; set; } // Make this property virtual
    }

    public class Weapon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AttackPower { get; set; }
    }

    public class Armor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Defense { get; set; }
    }
}
