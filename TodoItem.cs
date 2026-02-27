using System.ComponentModel.DataAnnotations;

namespace TodoListApp.Models
{
    public class TodoItem
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên công việc là bắt buộc")]
        [Display(Name = "Tên công việc")]
        public string Title { get; set; } = string.Empty;  

        [Display(Name = "Trạng thái hoàn thành")]
        public bool IsCompleted { get; set; }
    }
}
