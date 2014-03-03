using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.DisplayUI;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesGDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Task1ForBasicLoad
{
    public partial class Link2SDE : Form
    {
        private IPropertySet CProperty = new PropertySetClass();
        private IWorkspace mWorkspace;
        private bool bState;//连接状态管理
        private string fileLocation;
        public Link2SDE()
        {
            InitializeComponent(); stateMgr(true);
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            fillInfo();
            IWorkspaceFactory mWorksapceFactory = new SdeWorkspaceFactoryClass();
            try
            {
                mWorkspace=mWorksapceFactory.Open(CProperty, 0);
            }
            catch(System.Runtime.InteropServices.COMException comExc) { 
               MessageBox.Show(comExc.Message, "SDE.连接出错", MessageBoxButtons.OK, MessageBoxIcon.Stop);
               stateMgr(true);
                return;
            }
            if (mWorkspace != null)
            {
                stateMgr(false);//stateMgr(bool isFailed);
            }
            else {
                stateMgr(true);
            }
        }
        private void fillInfo()
        {//填充信息
            CProperty.SetProperty("SERVER", textServer.Text.ToString());
            CProperty.SetProperty("INSTANCE", textService.Text.ToString());
            CProperty.SetProperty("USER", textUserName.Text.ToString());
            CProperty.SetProperty("PASSWORD", textPasswd.Text.ToString());
            CProperty.SetProperty("DATABASE", textDatabase.Text.ToString());
            CProperty.SetProperty("VERSION", textVersion.Text.ToString());
        }

        private void btn_OpenFile_Click(object sender, EventArgs e)
        {
            openShpFileDlg.ShowDialog();
            fileLocation= textFileLocation.Text = openShpFileDlg.FileName.ToString();

        }
        private void stateMgr(bool isFailed) 
        {
            if (isFailed) {
                bState = false; labelState.Text = "状态：连接失败";
                btn_OpenFile.Enabled = false;
                btn_Write2Sde.Enabled = false;
            } else {
                bState = true;
                labelState.Text = "状态：连接成功";
                btn_OpenFile.Enabled = true;
                btn_Write2Sde.Enabled = true;
            }
        }

        private void btn_Write2Sde_Click(object sender, EventArgs e)
        {
            MessageBox.Show( "成功导入","信息");
            //需要进一步实现
        }

    }
}
