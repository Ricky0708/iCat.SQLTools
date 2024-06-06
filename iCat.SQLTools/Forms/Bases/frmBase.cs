using iCat.SQLTools.Models;
using iCat.SQLTools.Services.Interfaces;
using iCat.SQLTools.Services.Managers;
using iCat.SQLTools.Shareds.Enums;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iCat.SQLTools.Forms
{
    public partial class frmBase : Form
    {
        public bool closeFlag = false;
        private readonly IServiceProvider _provider;
        public CurrencyManager CurrencyManager { get; set; }

        public frmBase()
        {
            InitializeComponent();
        }

        public frmBase(IServiceProvider provider)
        {
            InitializeComponent();
            _provider = provider ?? throw new ArgumentNullException(nameof(provider));
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected virtual void BindFrm() { }

        protected virtual void SetControlEnabled(DataSource dataSource) { }


        private void frmBase_Load(object sender, EventArgs e)
        {
            try
            {
                CurrencyManager.PositionChanged += CurrencyManager_PositionChanged;
                CurrencyManager_PositionChanged(null, null!);
            }
            catch (Exception ex)
            {
            }

        }

        private void frmBase_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                CurrencyManager.PositionChanged -= CurrencyManager_PositionChanged;
            }
            catch (Exception)
            {
            }
        }

        private void CurrencyManager_PositionChanged(object? sender, EventArgs e)
        {
            BindFrm();
            SetControlEnabled(((DatasetManager)CurrencyManager.Current).DataSource);
        }
    }
}
