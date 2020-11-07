using System;
using System.Collections.ObjectModel;
using System.ComponentModel.Design;
using System.Reflection;
using System.Windows.Forms;
using Recovery2.Models;

namespace Recovery2.Extensions
{
    internal static class Store
    {
        public static object Data { get; set; }
    }

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

        protected override void CancelChanges()
        {
            ((GlobalConfig) Context.Instance).Items = (ObservableCollection<ContestItem>) Store.Data;
            base.CancelChanges();
        }

        protected override object[] GetItems(object editValue)
        {
            Store.Data = editValue.Copy();
            return base.GetItems(editValue);
        }
    }
}