using ReadWriteFiles.ViewModels;
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
using System.Windows.Interactivity;

namespace ReadWriteFiles.Views
{
    /// <summary>
    /// Interaction logic for ProcessFiles.xaml
    /// </summary>
    public partial class ProcessFiles : UserControl
    {
        public ProcessFiles()
        {
            InitializeComponent();
            this.DataContext = new ProcessFilesViewModel();             
        }
    }
}
