﻿using DishSysManager.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DishSysManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var data = SqlUtil.Inst.Catagories.FirstOrDefault(a => 1 != 1);
        }
    }
}
