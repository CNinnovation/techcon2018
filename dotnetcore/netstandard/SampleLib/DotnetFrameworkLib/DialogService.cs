﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotnetFrameworkLib
{
    public class DialogService
    {
        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
