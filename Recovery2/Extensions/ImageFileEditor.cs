using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Recovery2.Extensions
{
    public class ImageFileEditor: FileNameEditor
    {
        protected override void InitializeDialog(OpenFileDialog ofd)
        {
            ofd.Multiselect = false;
            ofd.CheckFileExists = false;
            ofd.Filter = "";
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            var sep = string.Empty;
            foreach (ImageCodecInfo c in codecs)
            {
                var codecName = c.CodecName.Substring(8).Replace("Codec", "Файлы").Trim();
                ofd.Filter = $@"{ofd.Filter}{sep}{codecName} ({c.FilenameExtension})|{c.FilenameExtension}";
                sep = "|";
            }

            ofd.Filter = $@"{ofd.Filter}{sep}{"Все файлы"} ({"*.*"})|{"*.*"}";
        }
    }
}