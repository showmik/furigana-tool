using Gem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FuriganaTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<TextBox> kanjiTextBoxList = new List<TextBox>();
        private List<TextBox> furiganaTextBoxList = new List<TextBox>();
        private List<TextBlock> rowCounterTextList = new List<TextBlock>();
        private int rowCounter;
        private int maxRow = 20;
        private string IncorrectInputWarningText = "Must Enter Kanji!";
        private string maxRowReachedWarningText = "Maximum (20) Row Reached!";

        public MainWindow()
        {
            InitializeComponent();
            InitializeKanjiTextBoxList();
            InitializeFuriganaTextBoxList();
            rowCounter = TextBoxGrid.RowDefinitions.Count;
        }

        private void RunButton_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < kanjiTextBoxList.Count; i++)
            {
                if (kanjiTextBoxList[i].Text != string.Empty)
                {
                    if (furiganaTextBoxList[i].Text == string.Empty)
                    {
                        stringBuilder.Append($"{kanjiTextBoxList[i].Text.Trim()}[ ]");
                    }
                    else
                    {
                        stringBuilder.Append($"{kanjiTextBoxList[i].Text.Trim()}[{furiganaTextBoxList[i].Text}]");
                    }
                }
            }

            if (stringBuilder.ToString() != string.Empty)
            {
                var furigana = new Furigana(stringBuilder.ToString());
                ResultTextBox.Text = furigana.RubySyntaxResult;
                //ResultTextBox.Text = stringBuilder.ToString();
            }
            else
            {
                ResultTextBox.Text = IncorrectInputWarningText;
                try
                {
                    if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                    {
                        SystemSounds.Exclamation.Play();
                    }
                }
                catch { }
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < kanjiTextBoxList.Count; i++)
            {
                kanjiTextBoxList[i].Clear();
                furiganaTextBoxList[i].Clear();
            }
        }

        private void AddRowButton_Click(object sender, RoutedEventArgs e)
        {
            rowCounter++;

            if (rowCounter <= maxRow)
            {
                TextBoxGrid.RowDefinitions.Add(new RowDefinition());

                AddRowCounterText();
                AddKanjiTextBox();
                AddFuriganaTextBox();
            }
            else
            {
                ResultTextBox.Text = maxRowReachedWarningText;
                try
                {
                    if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                    {
                        SystemSounds.Exclamation.Play();
                    }
                }
                catch { }
            }
        }

        private void AddRowCounterText()
        {
            rowCounterTextList.Add(new TextBlock());
            TextBlock currentRowCounterText = rowCounterTextList.Last();

            Grid.SetRow(currentRowCounterText, rowCounter - 1);
            Grid.SetColumn(currentRowCounterText, 0);
            currentRowCounterText.Text = rowCounter.ToString();
            currentRowCounterText.FontFamily = new FontFamily("Consolas");
            currentRowCounterText.FontSize = 14;
            currentRowCounterText.Foreground = new SolidColorBrush(Color.FromRgb(33, 150, 243));
            currentRowCounterText.HorizontalAlignment = HorizontalAlignment.Center;
            currentRowCounterText.VerticalAlignment = VerticalAlignment.Center;
            currentRowCounterText.Margin = new Thickness(0, 0, 5, 0);

            TextBoxGrid.Children.Add(currentRowCounterText);
        }

        private void AddFuriganaTextBox()
        {
            furiganaTextBoxList.Add(new TextBox());
            TextBox currentFuriganaTextBox = furiganaTextBoxList.Last();
            Grid.SetRow(currentFuriganaTextBox, rowCounter - 1);
            Grid.SetColumn(currentFuriganaTextBox, 2);
            currentFuriganaTextBox.Height = 30;
            currentFuriganaTextBox.Margin = new Thickness(5);
            TextBoxGrid.Children.Add(currentFuriganaTextBox);
        }

        private void AddKanjiTextBox()
        {
            kanjiTextBoxList.Add(new TextBox());
            TextBox currentKanjiTextBox = kanjiTextBoxList.Last();
            Grid.SetRow(currentKanjiTextBox, rowCounter - 1);
            Grid.SetColumn(currentKanjiTextBox, 1);
            currentKanjiTextBox.Height = 30;
            currentKanjiTextBox.Margin = new Thickness(5);
            TextBoxGrid.Children.Add(currentKanjiTextBox);
        }

        private void CopyButton_Click(object sender, RoutedEventArgs e)
        {
            ResultTextBox.SelectAll();
            ResultTextBox.Copy();
        }

        private void InitializeKanjiTextBoxList()
        {
            kanjiTextBoxList.Add(TextBoxR0C1);
            kanjiTextBoxList.Add(TextBoxR1C1);
            kanjiTextBoxList.Add(TextBoxR2C1);
            kanjiTextBoxList.Add(TextBoxR3C1);
        }

        private void InitializeFuriganaTextBoxList()
        {
            furiganaTextBoxList.Add(TextBoxR0C2);
            furiganaTextBoxList.Add(TextBoxR1C2);
            furiganaTextBoxList.Add(TextBoxR2C2);
            furiganaTextBoxList.Add(TextBoxR3C2);
        }
    }
}