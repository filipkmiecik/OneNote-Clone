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
using System.Windows.Shapes;

namespace OneNoteClone.View
{
    /// <summary>
    /// Interaction logic for NoteWindow.xaml
    /// </summary>
    public partial class NoteWindow : Window
    {
        public NoteWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This method access Appication
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void NoteRichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int lengthOfNoteRichTextBox = new TextRange(noteRichTextBox.Document.ContentStart, noteRichTextBox.Document.ContentEnd).Text.Length;

            StatusBarText.Text = $"Note length: {lengthOfNoteRichTextBox} ";
        }

        private void ButtonBold_Click(object sender, RoutedEventArgs e)
        {
            var selectedText = new TextRange(noteRichTextBox.Selection.Start, noteRichTextBox.Selection.End);
            selectedText.ApplyPropertyValue(Inline.FontWeightProperty, FontWeights.Bold);

            //Todo toggle
        }
    }
}
