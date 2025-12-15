namespace DataGridView.Web.Models
{
    /// <summary>
    /// Модель отображения ошибки
    /// </summary>
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
