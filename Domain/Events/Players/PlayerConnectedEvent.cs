namespace Domain.Events.Players
{
    public class PlayerConnectedEvent
    {
        public DateTime ConnectionDateTime { get; set; }

        public string Id { get; set; }

    }
}