using B;
using C;
using D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace A
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        GUI _cGUI;
        Human _cHuman;
        Study _cStudy;

        public MainWindow()
        {
            InitializeComponent();

            _cGUI = new GUI();
            _cGUI.eUIDataChange += cGUI_eUIDataChange;

            Width = _cGUI.Width;
            Height = _cGUI.Height;

            _cGUI = PropertyBinding(_cGUI);
            MainGrid.Children.Add(_cGUI);
        }
        
        private void cGUI_eUIDataChange(string sTypeName, string sPropertyName, string sText)
        {
            string sChangedTypeName;

            dynamic instance = null;
            Type type = null;
            PropertyInfo property = null;

            // swap
            if (sTypeName == _cHuman.GetType().Name)
                instance = _cStudy;
            else if (sTypeName == _cStudy.GetType().Name)
                instance = _cHuman;

            type = instance.GetType();
            property = type.GetProperty(sPropertyName);
            if (property == null) return;
            property.SetValue(instance, sText);

            sChangedTypeName = type.Name;
            _cGUI.Description(sTypeName, sChangedTypeName, sPropertyName, sText);
        }

        private GUI PropertyBinding(GUI cGUI)
        {
            _cHuman = new Human();
            List<string> cHumanPropertyName = _cHuman.GetType().GetProperties().AsEnumerable().Select(item => item.Name).ToList();
            cGUI.HumanStackAdd(_cHuman, cHumanPropertyName);

            _cStudy = new Study();
            List<string> cStudyPropertyName = _cStudy.GetType().GetProperties().AsEnumerable().Select(item => item.Name).ToList();
            cGUI.StudyStackAdd(_cStudy, cStudyPropertyName);

            return cGUI;
        }
    }
}
