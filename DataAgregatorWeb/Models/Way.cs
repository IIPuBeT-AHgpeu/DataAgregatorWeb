namespace DataAgregatorWeb.Models
{
    public partial class Way
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Trip> Trips { get; } = new List<Trip>();
    }
}
