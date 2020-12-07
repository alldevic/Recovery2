using System;
using System.ComponentModel.Design;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Recovery2.Extensions
{
    internal class CustomCollectionEditor : CollectionEditor
    {
        private object _originalContext;

        public CustomCollectionEditor(Type type) : base(type)
        {
        }

        protected override CollectionForm CreateCollectionForm()
        {
            _originalContext = Context.GetType().GetProperty("PropertyValue")?.GetValue(Context).Copy();

            var form = base.CreateCollectionForm();
            form.StartPosition = FormStartPosition.CenterParent;
            form.HelpButton = false;
            form.Font = new Font(form.Font.FontFamily, 12, form.Font.Style, form.Font.Unit, form.Font.GdiCharSet,
                form.Font.GdiVerticalFont);
            var gridInfo = form.GetType().GetField("propertyBrowser", BindingFlags.NonPublic | BindingFlags.Instance);
            var propertyGrid = (PropertyGrid) gridInfo?.GetValue(form);

            if (propertyGrid == null)
            {
                return form;
            }

            propertyGrid.PropertySort = PropertySort.NoSort;
            propertyGrid.ToolbarVisible = false;
            propertyGrid.HelpVisible = true;

            return form;
        }

        protected override void CancelChanges()
        {
            Context.GetType().GetProperty("PropertyValue")?.SetValue(Context, _originalContext);
            base.CancelChanges();
        }
    }
}