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

namespace D
{
    /// <summary>
    /// ucTemplate.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ucTemplate : UserControl
    {
        public event dUIDataChange eUIDataChange;

        public ucTemplate()
        {
            InitializeComponent();
        }

        private void txbValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (eUIDataChange == null) return;

            TextBox textBox = sender as TextBox;
            eUIDataChange(textBox.DataContext.GetType().Name, lblValue.Content.ToString(), textBox.Text);

            e.Handled = true;   // SetValue 이후에 PropertyChanged로 인한 Event 무한루프 방지
        }

        public void DataBinding(string sPropName)
        {
            lblValue.Content = sPropName;
            txbValue.SetBinding(TextBox.TextProperty, new Binding(sPropName));
        }
    }

    public delegate void dUIDataChange(string sTypeName, string sPropertyName, string sText);
}
