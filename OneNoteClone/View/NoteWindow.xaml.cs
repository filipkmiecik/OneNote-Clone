using OneNoteClone.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OneNoteClone.View
{
    public partial class NoteWindow : Window
    {
        NoteVM viewModel;
        public NoteWindow()
        {
            InitializeComponent();

            viewModel = new NoteVM();
            mainContainer.DataContext = viewModel;
            viewModel.selectedNoteChanges += ViewModel_selectedNoteChanges;

            var fonts = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            ComboBoxFontFamily.ItemsSource = fonts;

            List<double> sizes = new List<double>() { 6, 7, 8, 9, 10, 12, 15, 17, 19, 22, 25, 28, 35 };
            ComboBoxFontSize.ItemsSource = sizes;
        }

        private void ViewModel_selectedNoteChanges(object sender, EventArgs e)
        {
            noteRichTextBox.Document.Blocks.Clear();
            if (viewModel.SelectedNote != null)
            {
                if (!string.IsNullOrEmpty(viewModel.SelectedNote.FileDirectory))
                {
                    using (FileStream fileStream = new FileStream(viewModel.SelectedNote.FileDirectory, FileMode.Open))
                    {
                        TextRange range = new TextRange(noteRichTextBox.Document.ContentStart, noteRichTextBox.Document.ContentEnd);
                        range.Load(fileStream, DataFormats.Rtf);
                    }                 
                }
            }
            else
            {
                noteRichTextBox.Document.Blocks.Clear();
            }
            
        }

        private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void NoteRichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int lengthOfNoteRichTextBox = new TextRange(noteRichTextBox.Document.ContentStart, noteRichTextBox.Document.ContentEnd).Text.Length;

            StatusBarText.Text = $"Note length: {lengthOfNoteRichTextBox} ";
        }

        private void NoteRichTextBox_SelectionChanged(object sender, RoutedEventArgs e)
        { 
            var boldSelection = noteRichTextBox.Selection.GetPropertyValue(Inline.FontWeightProperty);
            buttonBold.IsChecked = (boldSelection != DependencyProperty.UnsetValue) && (boldSelection.Equals(FontWeights.Bold));

            var italicSelection = noteRichTextBox.Selection.GetPropertyValue(Inline.FontStyleProperty);
            buttonItalic.IsChecked = (italicSelection != DependencyProperty.UnsetValue) && (italicSelection.Equals(FontStyles.Italic));

            var underSelection = noteRichTextBox.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            buttonUnderline.IsChecked = (underSelection != DependencyProperty.UnsetValue) && (underSelection.Equals(TextDecorations.Underline));

            ComboBoxFontFamily.SelectedItem = noteRichTextBox.Selection.GetPropertyValue(Inline.FontFamilyProperty);
            ComboBoxFontSize.Text = (noteRichTextBox.Selection.GetPropertyValue(Inline.FontSizeProperty)).ToString();
        }

        private void ButtonBold_Click(object sender, RoutedEventArgs e)
        {
            bool isButtonToggledOn = (sender as ToggleButton).IsChecked ?? false;

            if (isButtonToggledOn)
            {
                noteRichTextBox.Selection.ApplyPropertyValue(Inline.FontWeightProperty, FontWeights.Bold);
            }

            else
            {
                noteRichTextBox.Selection.ApplyPropertyValue(Inline.FontWeightProperty, FontWeights.Normal);
            }
        }

        private void ButtonItalic_Click(object sender, RoutedEventArgs e)
        {
            bool isButtonToggledOn = (sender as ToggleButton).IsChecked ?? false;

            if (isButtonToggledOn)
            {
                noteRichTextBox.Selection.ApplyPropertyValue(Inline.FontStyleProperty, FontStyles.Italic);
            }

            else
            {
                noteRichTextBox.Selection.ApplyPropertyValue(Inline.FontStyleProperty, FontStyles.Normal);
            }
        }

        private void ButtonUnderline_Click(object sender, RoutedEventArgs e)
        {
            bool isButtonToggledOn = (sender as ToggleButton).IsChecked ?? false;


            if (isButtonToggledOn)
            {
                noteRichTextBox.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Underline);
            }

            else
            {
                TextDecorationCollection textDecorations;
                (noteRichTextBox.Selection.GetPropertyValue(Inline.TextDecorationsProperty) as TextDecorationCollection).TryRemove(TextDecorations.Underline, out textDecorations);
                noteRichTextBox.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, textDecorations);
            }
        }

        private void ComboBoxFontFamily_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if(ComboBoxFontFamily.SelectedItem != null)
            {
                string xd = ComboBoxFontFamily.SelectedItem.ToString();
                bool isSomethingSelected = noteRichTextBox.Selection.IsEmpty;
                if (!isSomethingSelected)
                {
                    noteRichTextBox.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, ComboBoxFontFamily.SelectedItem);
                }
                else
                {
                    noteRichTextBox.Focus();
                    noteRichTextBox.FontFamily = new FontFamily(ComboBoxFontFamily.SelectedItem.ToString());
                    // Run r = new Run("", this.noteRichTextBox.CaretPosition);
                    // r.FontFamily = new FontFamily(ComboBoxFontFamily.SelectedItem.ToString());
                }
            }
        }

        private void ComboBoxFontSize_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool isSomethingSelected = noteRichTextBox.Selection.IsEmpty;
            if (!isSomethingSelected)
            {
                noteRichTextBox.Selection.ApplyPropertyValue(Inline.FontSizeProperty, ComboBoxFontSize.Text);
            }
            else
            {
                noteRichTextBox.Focus();
                if(ComboBoxFontSize.SelectedItem == null)
                {
                    noteRichTextBox.FontSize = 12;
                }
                else
                {
                    noteRichTextBox.FontSize = Convert.ToDouble(ComboBoxFontSize.SelectedItem);
                }

                //Run r = new Run("", this.noteRichTextBox.CaretPosition);
                //r.FontSize =  Convert.ToDouble(ComboBoxFontSize.SelectedItem);
            }


        }

        private void SaveFileBtn_Click(object sender, RoutedEventArgs e)
        {
            string rtfFile = System.IO.Path.Combine(Environment.CurrentDirectory, $"{viewModel.SelectedContainer.Id}{viewModel.SelectedNote.Id}.rtf");
            viewModel.SelectedNote.FileDirectory = rtfFile;

            using (FileStream fileStream = new FileStream(rtfFile, FileMode.Create))
            {
                TextRange range = new TextRange(noteRichTextBox.Document.ContentStart, noteRichTextBox.Document.ContentEnd);
                range.Save(fileStream, DataFormats.Rtf);
                viewModel.UpdateNoteThatIsSelected();
            }
           
            

            
        }
    }
}
