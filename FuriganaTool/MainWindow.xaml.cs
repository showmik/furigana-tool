﻿using Gem;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace FuriganaTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<TextBox> kanjiTextBoxList = new List<TextBox>();
        private List<TextBox> furiganaTextBoxList = new List<TextBox>();
        private int rowCounter;

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

            for (int i = 0; i < rowCounter; i++)
            {
                if (kanjiTextBoxList[i].Text != string.Empty && furiganaTextBoxList[i].Text != string.Empty)
                {
                    stringBuilder.Append($"{kanjiTextBoxList[i].Text.Trim()}[{furiganaTextBoxList[i].Text.Trim()}]");
                }
            }

            if (stringBuilder.ToString() != string.Empty)
            {
                var furigana = new Furigana(stringBuilder.ToString());
                ResultTextBox.Text = furigana.ResultRubySyntax;
            }
            else
            {
                ResultTextBox.Text = "Input both Kanji and Furigana!";
                SystemSounds.Exclamation.Play();
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < rowCounter; i++)
            {
                kanjiTextBoxList[i].Clear();
                furiganaTextBoxList[i].Clear();
            }
        }

        private void AddRowButton_Click(object sender, RoutedEventArgs e)
        {
            rowCounter++;
            kanjiTextBoxList.Add(new TextBox());
            Grid.SetRow(kanjiTextBoxList.Last(), rowCounter - 1);
            Grid.SetColumn(kanjiTextBoxList.Last(), 0);
            kanjiTextBoxList.Last().Height = 30;
            kanjiTextBoxList.Last().Margin = new Thickness(5);

            furiganaTextBoxList.Add(new TextBox());
            Grid.SetRow(furiganaTextBoxList.Last(), rowCounter - 1);
            Grid.SetColumn(furiganaTextBoxList.Last(), 1);
            furiganaTextBoxList.Last().Height = 30;
            furiganaTextBoxList.Last().Margin = new Thickness(5);

            kanjiTextBoxList[rowCounter - 1].Name = $"TextBoxR{rowCounter - 1}C0";
            furiganaTextBoxList[rowCounter - 1].Name = $"TextBoxR{rowCounter - 1}C1";

            TextBoxGrid.RowDefinitions.Add(new RowDefinition());
            TextBoxGrid.Children.Add(kanjiTextBoxList.Last());
            TextBoxGrid.Children.Add(furiganaTextBoxList.Last());
        }

        private void CopyButton_Click(object sender, RoutedEventArgs e)
        {
            ResultTextBox.SelectAll();
            ResultTextBox.Copy();
        }

        private void InitializeKanjiTextBoxList()
        {
            kanjiTextBoxList.Add(TextBoxR0C0);
            kanjiTextBoxList.Add(TextBoxR1C0);
            kanjiTextBoxList.Add(TextBoxR2C0);
            kanjiTextBoxList.Add(TextBoxR3C0);
        }

        private void InitializeFuriganaTextBoxList()
        {
            furiganaTextBoxList.Add(TextBoxR0C1);
            furiganaTextBoxList.Add(TextBoxR1C1);
            furiganaTextBoxList.Add(TextBoxR2C1);
            furiganaTextBoxList.Add(TextBoxR3C1);
        }
    }
}