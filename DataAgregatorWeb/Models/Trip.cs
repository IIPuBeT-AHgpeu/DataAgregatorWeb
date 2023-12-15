namespace DataAgregatorWeb.Models
{
    public partial class Trip
    {
        public Trip()
        {
        }

        public Trip(FromWeatherAPIModel weather, FromClientTripModel fromClient)
        {
            Temperature = weather.Current.Temp_c;
            FeelsLike = weather.Current.Feelslike_c;
            Wind = weather.Current.Wind_kph * 1000 / 3600;
            Precipitation = weather.Current.Precip_mm;
            Pressure = weather.Current.Pressure_mb;
            Humidity = weather.Current.Humidity;

            IsWeekend = fromClient.IsWeekend;
            Holiday = fromClient.Holiday;
            WeekDay = fromClient.WeekDay;
            TrafficJams = fromClient.TrafficJams;
            Join = fromClient.Join;
            Left = fromClient.Left;
            BusCount = fromClient.BusCount;
            BusId = fromClient.BusId;
            WayId = fromClient.WayId;
        }

        public int Id { get; set; }
        /// <summary>
        /// Дата.
        /// </summary>
        public DateOnly Date { get; set; }
        /// <summary>
        /// Время.
        /// </summary>
        public TimeOnly Time { get; set; }
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
        /// Температура воздуха.
        /// </summary>
        public double Temperature { get; set; }
        /// <summary>
        /// Температура воздуха по ощущениям.
        /// </summary>
        public double FeelsLike { get; set; }
        /// <summary>
        /// Скорость ветра в м/с.
        /// </summary>
        public double Wind { get; set; }
        /// <summary>
        /// Количество осадков в мм.
        /// </summary>
        public double Precipitation { get; set; }
        /// <summary>
        /// Давление в миллибарах.
        /// </summary>
        public float Pressure { get; set; }
        /// <summary>
        /// Влажность в %.
        /// </summary>
        public float Humidity { get; set; }
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
        public virtual Bus? Bus { get; set; }
        /// <summary>
        /// Количество автобусов на маршруте на данный момент.
        /// </summary>
        public int BusCount { get; set; }
        public int WayId { get; set; }
        public virtual Way? Way { get; set; }

        public override string ToString()
        {
            return Id.ToString() + ";"
                + Way.Name + ";"
                + Date.ToString() + ";"
                + Time.ToString() + ";"
                + Holiday.ToString() + ";"
                + WeekDay.ToString() + ";"
                + IsWeekend.ToString() + ";"
                + Math.Round(Temperature, 1).ToString() + ";"
                + Math.Round(FeelsLike, 1).ToString() + ";"
                + Math.Round(Wind, 2).ToString() + ";"
                + Math.Round(Precipitation, 1).ToString() + ";"
                + Math.Round(Pressure, 0).ToString() + ";"
                + Math.Round(Humidity, 1).ToString() + ";"
                + TrafficJams.ToString() + ";"
                + Join.ToString() + ";"
                + Left.ToString() + ";"
                + Bus.Capacity.ToString() + ";"
                + BusCount.ToString() + ";";
        }

        public void Copy(Trip trip)
        {
            Id = trip.Id;
            Date = trip.Date;
            Time = trip.Time;
            IsWeekend = trip.IsWeekend;
            Holiday = trip.Holiday;
            WeekDay = trip.WeekDay;
            Temperature = trip.Temperature;
            FeelsLike = trip.FeelsLike;
            Wind = trip.Wind;
            Precipitation = trip.Precipitation;
            Pressure = trip.Pressure;
            Humidity = trip.Humidity;
            TrafficJams = trip.TrafficJams;
            Join = trip.Join;
            Left = trip.Left;
            BusId = trip.BusId;
            BusCount = trip.BusCount;
            WayId = WayId;
        }
    }
}
