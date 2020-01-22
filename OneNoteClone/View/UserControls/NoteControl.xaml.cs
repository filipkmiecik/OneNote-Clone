﻿using OneNoteClone.Models;
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
    /// Creates template for the notes.
    /// </summary>
    public partial class NoteControl : UserControl
    {
       
        public Note ShowNote
        {
            get { return (Note)GetValue(MyPropertyProperty); }
            set { SetValue(MyPropertyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyPropertyProperty =
            DependencyProperty.Register("ShowNote", typeof(Note), typeof(NoteControl), new PropertyMetadata(null, SetValues));

        /// <summary>
        /// This method takes dependency object and assigns values 
        /// like title, and date of creation.
        /// </summary>
        /// <param name="d">Depedency Object</param>
        /// <param name="e">Event</param>
        private static void SetValues(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            NoteControl note = d as NoteControl;

            if(note != null)
            {
                note.TextBlockTitle.Text = (e.NewValue as Note).Title;
                note.TextBlockDate.Text = (e.NewValue as Note).UpdateDate.ToShortDateString();
                note.TextBlockContent.Text = (e.NewValue as Note).Title;
            }
        }

        /// <summary>
        /// This method initializes component
        /// </summary>
        public NoteControl()
        {
            InitializeComponent();
        }
    }
}
