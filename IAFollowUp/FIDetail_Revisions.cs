﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IAFollowUp
{
    public partial class FIDetail_Revisions : Form
    {
        public FIDetail_Revisions()
        {
            InitializeComponent();
        }

        public FIDetail_Revisions(Audit givenAudit, FIHeader givenHeader)
        {
            InitializeComponent();
        }
    }
}
