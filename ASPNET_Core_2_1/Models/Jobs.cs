namespace ASPNET_Core_2_1.Models
{
    public class Jobs
    {
        public int Id { get; set; }
        public int Score { get; set; }

        public Jobs(int id, int score)
        {
            id = Id;
            score = Score;

        }

    }
}
