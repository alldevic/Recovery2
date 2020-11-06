using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using Recovery2.Extensions;

namespace Recovery2.Models
{
    public class GlobalConfig : NotifyPropertyChangedBase
    {
        private string _title;
        private uint _count;
        private uint _defaultDelay;
        private bool _random;
        private bool _hideCursor;
        private bool _blackscreen;
        private ContestItem _blackscreenItem;
        private ObservableCollection<ContestItem> _items;
        private bool _contestDebug;
        private Keys _closeKey;
        private FrameSize _frameSize;

        [Category(@"Основные")]
        [Description(@"Заголовок для окна с тестом")]
        [DisplayName(@"Заголовок")]
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        [Category(@"Основные")]
        [Description(@"Количество кадров в тесте")]
        [DisplayName(@"Количество")]
        public uint Count
        {
            get => _count;
            set => SetProperty(ref _count, value);
        }

        [Category(@"Основные")]
        [Description(@"Скрывать курсор в режиме тестирования")]
        [DisplayName(@"Скрывать курсор")]
        [TypeConverter(typeof(BooleanToYesNoTypeConverter))]
        public bool HideCursor
        {
            get => _hideCursor;
            set => SetProperty(ref _hideCursor, value);
        }

        [Category(@"Основные")]
        [Description(@"Кнопка для прерывания тестирования")]
        [DisplayName(@"Кнопка прерывания")]
        [Editor(typeof(CustomShortcutKeysEditor), typeof(UITypeEditor))]
        public Keys CloseKey
        {
            get => _closeKey;
            set => SetProperty(ref _closeKey, value);
        }


        [Category(@"Алгоритм")]
        [Description(@"Время показа кадра по-умолчанию")]
        [DisplayName(@"Время показа")]
        public uint DefaultDelay
        {
            get => _defaultDelay;
            set => SetProperty(ref _defaultDelay, value);
        }
        
        [Category(@"Алгоритм")]
        [Description(@"Настройки размера кадра")]
        [DisplayName(@"Размер кадра")]
        public FrameSize FrameSize
        {
            get => _frameSize;
            set => SetProperty(ref _frameSize, value);
        }

        [Category(@"Алгоритм")]
        [Description(@"Кадры показываются в случайном порядке")]
        [DisplayName(@"Случайно")]
        [TypeConverter(typeof(BooleanToYesNoTypeConverter))]
        public bool Random
        {
            get => _random;
            set => SetProperty(ref _random, value);
        }

        [Category(@"Алгоритм")]
        [Description(@"Показ черного экрана между кдрами и переход сразу к следующему кадру")]
        [DisplayName(@"Черный экран")]
        [TypeConverter(typeof(BooleanToYesNoTypeConverter))]
        public bool Blackscreen
        {
            get => _blackscreen;
            set => SetProperty(ref _blackscreen, value);
        }

        [Category(@"Алгоритм")]
        [Description(@"Настройки черного экрана")]
        [DisplayName(@"Черный кадр")]
        [TypeConverter(typeof(BlackscreenExpandableConverter))]
        public ContestItem BlackscreenItem
        {
            get => _blackscreenItem;
            set => SetProperty(ref _blackscreenItem, value);
        }

        [Category(@"Алгоритм")]
        [Description(@"Описание кадров для алгоритма")]
        [DisplayName(@"Кадры")]
        [Editor(typeof(CustomCollectionEditor), typeof(UITypeEditor))]
        public ObservableCollection<ContestItem> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }

        [Category(@"Отладка")]
        [Description(@"Режим отладки для формы алгоритма")]
        [DisplayName(@"Отладка")]
        [TypeConverter(typeof(BooleanToYesNoTypeConverter))]
        public bool ContestDebug
        {
            get => _contestDebug;
            set => SetProperty(ref _contestDebug, value);
        }
    }
}