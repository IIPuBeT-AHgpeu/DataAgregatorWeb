namespace DataAgregatorWeb.Models
{
    public class FromClientTripModel
    {
        /// <summary>
        /// Определяет: является ли день выходным.
        /// </summary>
        public bool IsWeekend { get; set; }
        /// <summary>
        /// Определяет значимость праздника в текущую дату.
        /// 0 - не праздник
        /// 1 - небольшой праздник (незначимый для нас, типа Хэллоуин, день Валентина и всякое такое)
        /// 2 - большой праздник, который активно празднуется горожанами
        /// </summary>
        public int Holiday { get; set; }
        /// <summary>
        /// День недели. От 1 до 7.
        /// </summary>
        public int WeekDay { get; set; }
        /// <summary>
        /// Пробки в баллах.
        /// </summary>
        public int? TrafficJams { get; set; }
        /// <summary>
        /// Количество вошедших пассажиров.
        /// </summary>
        public int Join { get; set; }
        /// <summary>
        /// Количесвто вышедших пассажиров.
        /// </summary>
        public int Left { get; set; }
        /// <summary>
        /// Информация об автобусе.
        /// </summary>
        public int BusId { get; set; }
        public int BusCount { get; set; }
        public int WayId { get; set; }
    }
}
