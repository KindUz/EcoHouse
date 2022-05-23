namespace EcoHouse.Storage.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        public int? AddressID { get; set; }

        [ForeignKey(nameof(AddressID))]

        public virtual Main_Address? Main_Address { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }
        public int? OrdersID { get; set; }

        [ForeignKey(nameof(OrdersID))]
        public virtual Order? Order { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        public string? Photo { get; set; }


    }
}
