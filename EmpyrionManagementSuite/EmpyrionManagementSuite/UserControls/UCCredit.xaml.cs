using EMS.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace EmpyrionManagementSuite.UserControls
{
    /// <summary>
    /// Interaction logic for UCCredit.xaml
    /// </summary>
    public partial class UCCredit : UserControl
    {
        public UCCredit(AppCredit CREDIT)
        {
            InitializeComponent();

            DataContext = CREDIT;
        }
    }
}