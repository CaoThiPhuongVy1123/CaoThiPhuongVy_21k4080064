namespace CaoThiPhuongVy_21k4080064.Data
{
    public class WeatherForecast
    {
        public int Id { get; set; } // Thêm thuộc tính Id làm khóa chính
        public DateTime Date { get; set; }
        public int TemperatureC { get; set; }
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
        public string? Summary { get; set; }
    }
}
