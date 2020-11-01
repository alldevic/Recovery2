using System;
using System.ComponentModel.Design;
using System.Reflection;
using System.Windows.Forms;

namespace Recovery2.Extensions
{
    internal class CustomCollectionEditor : CollectionEditor
    {
        public CustomCollectionEditor(Type type)
            : base(type)
        {
        }

        protected override CollectionForm CreateCollectionForm()
        {
            var form = base.CreateCollectionForm();
            form.StartPosition = FormStartPosition.CenterParent;
            form.HelpButton = false;
            var formType = form.GetType();
            var fieldInfo = formType.GetField("propertyBrowser", BindingFlags.NonPublic | BindingFlags.Instance);

            if (fieldInfo == null)
            {
                return form;
            }

            var propertyGrid = (PropertyGrid) fieldInfo.GetValue(form);
            if (propertyGrid == null)
            {
                return form;
            }

            propertyGrid.PropertySort = PropertySort.NoSort;
            propertyGrid.ToolbarVisible = false;
            propertyGrid.HelpVisible = true;

            return form;
        }
    }
}