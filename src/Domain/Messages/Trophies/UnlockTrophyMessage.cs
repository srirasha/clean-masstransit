namespace Domain.Messages.Trophies
{
    public class UnlockTrophyMessage
    {
        public string Id { get; set; }

        public DateTime UnlockedDateTime { get; set; }
    }
}