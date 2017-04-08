namespace OrangeBricks.Web.Controllers.Property.Commands
{
    public class ContactAgentCommand
    {
        public int PropertyId { get; set; }

        public string BuyerUserId { get; set; }

        public string BuyerName { get; set; }

        public string StreetName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Message { get; set; }
    }
}