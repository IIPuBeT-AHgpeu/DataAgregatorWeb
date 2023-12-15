namespace DataAgregatorWeb.Models
{
    public partial class Bus
    {
        public int Id { get; set; }
        /// <summary>
        /// Наименование модели автобуса.
        /// </summary>
        public string Model { get; set; }
        /// <summary>
        /// Общее количество мест в автобусе (сидячие + стоячие).
        /// </summary>
        public int Capacity { get; set; }
        public virtual ICollection<Trip> Trips { get; } = new List<Trip>();
    }
}
