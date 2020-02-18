using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assign_3
{
    public partial class Form1 : Form
    {
        //community objects to hold data
        private static Community currentCommunity;
        private static Community DekalbCommunity;
        private static Community SycamoreCommunity;

        public Form1()
        {
            InitializeComponent();
            initActiveCommunity();
        }

        //sets the communities to active
        private void initActiveCommunity()
        {
            //dekalb active
            ActiveDekalb activeDekalb = new ActiveDekalb();
            DekalbCommunity = activeDekalb.ActiveDekalb_Files();

            //sycamore active
            ActiveSycamore activeSycamore = new ActiveSycamore();
            SycamoreCommunity = activeSycamore.ActiveSycamore_Files();
        }
    }
}
