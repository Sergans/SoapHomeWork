using LibraryServiceReference;
using System.ComponentModel.DataAnnotations;

namespace LibraryService.Web.Models
{
    public class BookViewModel
    {
        [Display(Name = "Идентификатор")]
        public string Id { get; set; }
        [Display(Name = "Заголовок")]
        public string Title { get; set; }
        [Display(Name = "Категория")]
        public string Category { get; set; }
        [Display(Name = "Язык")]
        public string Lang { get; set; }
        [Display(Name = "Количество страниц")]
        public int Pages { get; set; }
        [Display(Name = "Возрастное ограничение")]
        public int AgeLimit { get; set; }
        [Display(Name = "Авторы(Заполняются через запятую)")]
        public string Authors { get; set; }
        [Display(Name = "Дата публикации")]
        public int PublicationDate { get; set; }
    }
}
