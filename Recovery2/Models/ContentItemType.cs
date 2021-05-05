using System.ComponentModel;

namespace Recovery2.Models
{
    public enum ContentItemType
    {
        [Description("Цвет")]
        Color,
        [Description("Текст")]
        Text,
        [Description("Изображение")]
        Image
    }
}