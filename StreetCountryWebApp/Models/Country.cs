using System.ComponentModel.DataAnnotations;

namespace StreetCountryWebApp.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле названия не должно оставаться пустым. Название товара может содержать от 1 до 200 символов.")]
        [StringLength(200, MinimumLength = 1)]
        public string Name { get; set; }
    }
}
