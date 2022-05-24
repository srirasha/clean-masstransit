namespace Domain.Events.Players
{
    public class PlayerConnected
    {
        public DateTime ConnectionDateTime { get; set; }

        public string Id { get; set; }
    }
}