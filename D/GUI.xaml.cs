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

namespace D
{
    /// <summary>
    /// GUI.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class GUI : UserControl
    {
        public event dUIDataChange eUIDataChange;

        public GUI()
        {
            InitializeComponent();
        }

        public void HumanStackAdd(dynamic dInstance, List<string> cPropertyNameList)
        {
            foreach (string value in cPropertyNameList)
            {
                ucTemplate cUcTemplate = new ucTemplate();
                cUcTemplate.DataBinding(value);
                cUcTemplate.eUIDataChange += cUcTemplate_eUIDataChange;

                HumanStack.Children.Add(cUcTemplate);
            }
            HumanStack.DataContext = dInstance;
        }

        public void StudyStackAdd(dynamic dInstance, List<string> cPropertyNameList)
        {
            foreach (string value in cPropertyNameList)
            {
                ucTemplate cUcTemplate = new ucTemplate();
                cUcTemplate.DataBinding(value);
                cUcTemplate.eUIDataChange += cUcTemplate_eUIDataChange;

                StudyStack.Children.Add(cUcTemplate);
            }
            StudyStack.DataContext = dInstance;
        }

        public void Description(string sTypeName, string sChangedTypeName, string sPropertyName, string sText)
        {
            //lblD.Content = string.Format("{0}(으)로 인해 {1}의 {2}이(가) {3}(으)로 바뀌었습니다.", sTypeName, sChangedTypeName, sPropertyName, sText);
            lblD.Content = $"{sTypeName}(으)로 인해 {sChangedTypeName}의 {sPropertyName}이(가) {sText}(으)로 바뀌었습니다.";
        }

        private void cUcTemplate_eUIDataChange(string sTypeName, string sPropertyName, string sText)
        {
            eUIDataChange(sTypeName, sPropertyName, sText);
        }
    }
}
