using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using AssemblyBrowserWPF.commands;
using Microsoft.Win32;
using System.Windows;
using AssemblyBrowser;

namespace AssemblyBrowserWPF.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private List<IAssemblyNode> tree;
        public List<IAssemblyNode> Tree
        {
            get
            {
                return tree;
            }
            set
            {
                tree = value;
                OnPropertyChanged("Tree");
            }
        }

        private RelayCommand openFile;
        public RelayCommand OpenFIle
        {
            get
            {
                return openFile ?? 
                    (openFile = new RelayCommand(obj =>
                    {
                        OpenFileDialog openFileDialog = new OpenFileDialog();
                        if (openFileDialog.ShowDialog() == true)
                        {
                            string FilePath = openFileDialog.FileName;
                            var browser = new AsmBrowser();
                            Tree = browser.getInfo(FilePath);
                        }
                    }));
            }

        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
