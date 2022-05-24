namespace Domain.Commands.Trophies
{
    public class UnlockTrophy
    {
        public string Id { get; set; }

        public DateTime UnlockedDateTime { get; set; }
    }
}