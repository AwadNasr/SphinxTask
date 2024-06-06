namespace SphinxTask.ViewModels
{
    public class ClientProductVM
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string License { get; set; }
    }
}
