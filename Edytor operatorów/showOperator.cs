using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Edytor_operatorów
{
    public partial class showOperator : Form
    {
        public showOperator(List<startForm.Operator> operators)
        {
            InitializeComponent(operators);
        }


    }
}
