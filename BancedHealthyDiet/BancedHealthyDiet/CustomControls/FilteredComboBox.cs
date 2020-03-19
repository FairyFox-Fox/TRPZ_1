using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace BancedHealthyDiet.CustomControls
{

    public class FilteredComboBox : ComboBox
    {

        public FilteredComboBox()
        {

        }
        private string oldFilter = string.Empty;
        private string currentFilter = string.Empty;
        [Description("Длинна строки для поиска.")]
        [Category("Filtered ComboBox")]
        [DefaultValue(2)]
        public int MinimumSearchLength
        {
            [System.Diagnostics.DebuggerStepThrough]
            get
            {
                return (int)this.GetValue(MinimumSearchLengthProperty);
            }

            [System.Diagnostics.DebuggerStepThrough]
            set
            {
                this.SetValue(MinimumSearchLengthProperty, value);
            }
        }
        protected TextBox EditableTextBox
        {
            get
            {
                return this.GetTemplateChild("PART_EditableTextBox") as TextBox;
            }
        }

        protected override void OnItemsSourceChanged(IEnumerable oldValue, IEnumerable newValue)
        {
            if (newValue != null)
            {
                ICollectionView view = CollectionViewSource.GetDefaultView(newValue);
                view.Filter += this.FilterPredicate;
            }
            if (oldValue != null)
            {
                ICollectionView view = CollectionViewSource.GetDefaultView(oldValue);
                view.Filter -= this.FilterPredicate;
            }
            base.OnItemsSourceChanged(oldValue, newValue);
        }
  
       
        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                this.IsDropDownOpen = false;
            }
            else if (e.Key == Key.Escape)
            {
                this.IsDropDownOpen = false;
                this.SelectedIndex = -1;
                this.Text = this.currentFilter;
            }
            else
            {
                if (e.Key == Key.Down)
                {
                    this.IsDropDownOpen = true;
                }
                base.OnPreviewKeyDown(e);
            }
            this.oldFilter = this.Text;
        }
        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (e.Key == Key.Up || e.Key == Key.Down) { }
            else if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                this.ClearFilter();
            }
            else
            {
                if (this.Text != this.oldFilter)
                {
                    if (this.Text.Length == 0 || this.Text.Length >= this.MinimumSearchLength)
                    {
                        this.RefreshFilter();
                        this.IsDropDownOpen = true;
                        this.EditableTextBox.SelectionStart = int.MaxValue;
                    }
                }
                base.OnKeyUp(e);
                this.currentFilter = this.Text;
            }
        }
        protected override void OnPreviewLostKeyboardFocus(KeyboardFocusChangedEventArgs e)
        {
            this.ClearFilter();
            int temp = this.SelectedIndex;
            this.SelectedIndex = -1;
            this.Text = String.Empty;
            this.SelectedIndex = temp;
            base.OnPreviewLostKeyboardFocus(e);
        }
        private void RefreshFilter()
        {
            if (this.ItemsSource != null)
            {
                ICollectionView view = CollectionViewSource.GetDefaultView(this.ItemsSource);
                view.Refresh();
            }
        }

        private void ClearFilter()
        {
            this.currentFilter = string.Empty;
            this.RefreshFilter();
        }

        private bool FilterPredicate(object value)
        {
            if (value == null)
            {
                return false;
            }
            if (this.Text.Length == 0)
            {
                return true;//return all from combobox
            }
            return value.ToString().ToLower().Contains(this.Text.ToLower());
        }
        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinimumSearchLengthProperty =
            DependencyProperty.Register("MinimumSearchLength", typeof(int), typeof(FilteredComboBox), new PropertyMetadata(2));


    }
}

