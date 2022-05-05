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

        [Required]
        public int AddressID { get; set; }

        [ForeignKey(nameof(AddressID))]

        public virtual Address Address { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        public int Food_Features_ID { get; set; }

        [ForeignKey(nameof(Food_Features_ID))]
        public virtual Food_Features Food_Features { get; set; }

        public int OrdersID { get; set; }

        [ForeignKey(nameof(OrdersID))]
        public virtual Orders Orders { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }


    }
}
