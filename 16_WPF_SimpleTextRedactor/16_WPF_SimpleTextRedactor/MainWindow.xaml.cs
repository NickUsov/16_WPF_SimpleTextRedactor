using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace _16_WPF_SimpleTextRedactor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MenuItem FileContext = new MenuItem { Header = "File" };
            MenuItem FileOpenContext = new MenuItem { Header = "Open" };
            FileOpenContext.Click += FileOpenContext_Click;
            MenuItem FileSaveContext = new MenuItem { Header = "Save" };
            FileSaveContext.Click += FileSaveContext_Click;
            MenuItem FileExitContext = new MenuItem { Header = "Exit" };
            FileExitContext.Click += FileExitContext_Click;
            FileContext.Items.Add(FileOpenContext);
            FileContext.Items.Add(FileSaveContext);
            FileContext.Items.Add(FileExitContext);
            MenuItem EditContext = new MenuItem { Header = "Edit" };
            MenuItem EditCopyContext = new MenuItem { Header = "Copy" };
            EditCopyContext.Click += EditCopyContext_Click;
            MenuItem EditCutContext = new MenuItem { Header = "Cut" };
            EditCutContext.Click += EditCutContext_Click;
            MenuItem EditPasteContext = new MenuItem { Header = "Paste" };
            EditPasteContext.Click += EditPasteContext_Click;
            EditContext.Items.Add(EditCopyContext);
            EditContext.Items.Add(EditCutContext);
            EditContext.Items.Add(EditPasteContext);
            ContextMenu cc = new ContextMenu();
            cc.Items.Add(FileContext);
            cc.Items.Add(EditContext);
            textBox.ContextMenu = cc;

        }

        private void EditPasteContext_Click(object sender, RoutedEventArgs e)
        {
            textBox.Paste();
        }

        private void EditCutContext_Click(object sender, RoutedEventArgs e)
        {
            textBox.Cut();
        }

        private void EditCopyContext_Click(object sender, RoutedEventArgs e)
        {
            textBox.Copy();
        }

        private void FileExitContext_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void FileSaveContext_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "text files(*.txt)|*.txt|All files(*.*)|*.*";
            save.FilterIndex = 1;
            if (save.ShowDialog() == true)
            {
                string path = save.FileName;
                File.WriteAllText(path, textBox.Text, Encoding.Default);
            }
        }

        private void FileOpenContext_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "text files(*.txt)|*.txt|All files(*.*)|*.*";
            open.FilterIndex = 1;
            if (open.ShowDialog() == true)
            {
                string path = open.FileName;
                textBox.Text = File.ReadAllText(path, Encoding.Default);
            }
        }

        private void MenuFileNew_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuFileExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MenuFileOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "text files(*.txt)|*.txt|All files(*.*)|*.*";
            open.FilterIndex = 1;
            if (open.ShowDialog() == true)
            {
                string path = open.FileName;
                textBox.Text = File.ReadAllText(path, Encoding.Default);
            }
        }

        private void MenuFileSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();

            save.Filter = "text files(*.txt)|*.txt|All files(*.*)|*.*";
            save.FilterIndex = 1;
            if (save.ShowDialog() == true)
            {
                string path = save.FileName;
                File.WriteAllText(path, textBox.Text, Encoding.Default);
            }
        }

        private void MenuEditCopy_Click(object sender, RoutedEventArgs e)
        {
            textBox.Copy();
        }

        private void MenuEditCut_Click(object sender, RoutedEventArgs e)
        {
            textBox.Cut();
        }

        private void MenuEditPaste_Click(object sender, RoutedEventArgs e)
        {
            textBox.Paste();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

