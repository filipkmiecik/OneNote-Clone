using OneNoteClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OneNoteClone.View.UserControls
{
    /// <summary>
    /// Interaction logic for NoteContainerControl.xaml
    /// </summary>
    public partial class NoteContainerControl : UserControl
    {
        public NoteContainer ShowContainer
        {
            get { return (NoteContainer)GetValue(containerProperty); }
            set { SetValue(containerProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty containerProperty =
            DependencyProperty.Register("ShowContainer", typeof(NoteContainer), typeof(NoteContainerControl), new PropertyMetadata(null, SetValues));

        private static void SetValues(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            NoteContainerControl container = d as NoteContainerControl;

            if(container != null)
            {
                container.TextBlockContainerName.Text = (e.NewValue as NoteContainer).Name;
            }
        }

        public NoteContainerControl()
        {
            InitializeComponent();
        }
    }
}
