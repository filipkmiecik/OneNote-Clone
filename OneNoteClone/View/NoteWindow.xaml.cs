﻿using System;
using System.Collections.Generic;
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
        public NoteWindow()
        {
            InitializeComponent();

            var fonts = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            ComboBoxFontFamily.ItemsSource = fonts;

            List<double> sizes = new List<double>() { 6, 7, 8, 9, 10, 12, 15, 17, 19, 22, 25, 28, 35 };
            ComboBoxFontSize.ItemsSource = sizes;
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
            var weightSelection = noteRichTextBox.Selection.GetPropertyValue(Inline.FontWeightProperty);
            buttonBold.IsChecked = (weightSelection != DependencyProperty.UnsetValue) && (weightSelection.Equals(FontWeights.Bold));

            var styleSelection = noteRichTextBox.Selection.GetPropertyValue(Inline.FontStyleProperty);
            buttonItalic.IsChecked = (styleSelection != DependencyProperty.UnsetValue) && (styleSelection.Equals(FontStyles.Italic));

            var decorSelection = noteRichTextBox.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            buttonUnderline.IsChecked = (decorSelection != DependencyProperty.UnsetValue) && (decorSelection.Equals(TextDecorations.Underline));

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
                noteRichTextBox.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, ComboBoxFontFamily.SelectedItem);
            }
        }

        private void ComboBoxFontSize_TextChanged(object sender, TextChangedEventArgs e)
        {
            noteRichTextBox.Selection.ApplyPropertyValue(Inline.FontSizeProperty, ComboBoxFontSize.Text);
        }
    }
}
