namespace WolleWinkel.Domain.Entities
{
    public class CustomerEntity:Entity
    {
        public string Mail { get; set; }
        
        public string Phone { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
    }
}