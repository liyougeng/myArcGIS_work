using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


//arcGIS
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.DataSourcesNetCDF;
using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.DataSourcesOleDB;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Framework;

namespace Task1ForBasicLoad
{
    public partial class CustomSymbology : Form
    {
        private string strStyleFile = "C:\\Program Files (x86)\\ArcGIS\\Engine10.0\\Styles\\ESRI.ServerStyle";
        private UtilTool util = new UtilTool();
        public ISymbol tmpNoneSymbol = null;
        private IFillSymbol tmpFillSymbol = null;
        private ILineSymbol tmpLineSymbol = null;
        private IMarkerSymbol tmpMarkerSymbol = null;
        private SymbolType whichSymbolType = SymbolType.None;
        
        /// <summary>符号返回
        /// 返回所选的合格的符号ISymol
        /// </summary>
        /// <returns>通常：ISymbol；异常：null</returns>
        public ISymbol getChosedSymbol()
        {
            switch (whichSymbolType)
            {
                case SymbolType.FillSymbol: return tmpFillSymbol as ISymbol;
                case SymbolType.LineSymbol: return tmpLineSymbol as ISymbol;
                case SymbolType.MarkerSymbol: return tmpMarkerSymbol as ISymbol;
                case SymbolType.None: return tmpNoneSymbol;
                default: return null;
            }
        }
        public CustomSymbology()
        {
            InitializeComponent();
            whichSymbolType = SymbolType.None;
        }
        public CustomSymbology(esriSymbologyStyleClass enumStyle)
        {
            InitializeComponent();
            axSymbologyControl.StyleClass = enumStyle;
            ///* 匹配器，匹配符号类型,整个结构该改成arcGIS自身的累距类型
            switch (enumStyle)
            {
                case esriSymbologyStyleClass.esriStyleClassFillSymbols: whichSymbolType = SymbolType.FillSymbol; break;
                case esriSymbologyStyleClass.esriStyleClassLineSymbols: whichSymbolType = SymbolType.LineSymbol; break;
                case esriSymbologyStyleClass.esriStyleClassMarkerSymbols: whichSymbolType = SymbolType.MarkerSymbol; break;
                case esriSymbologyStyleClass.esriStyleClassLegendItems: whichSymbolType = SymbolType.None; break;
                default: break;
            }
        }
        private void CustomSymbology_Load(object sender, EventArgs e)
        {
            axSymbologyControl.LoadStyleFile(strStyleFile);                 //Load default style file 
        }

        /*从文件获取符号
         * 
         */
        private ISymbol getSymbolByName(string symbolstyle,string name)
        {
            ISymbol result=null;
            string stylepath=System.Configuration.ConfigurationSettings.AppSettings["SymbolPath"];
		    //符号管理对象
            IStyleGallery pStyleGallery =new StyleGalleryClass();
            //符号文件管理， 设定符号文件
            IStyleGalleryStorage pStyleStorage=pStyleGallery as IStyleGalleryStorage;
            IEnumStyleGalleryItem pEnumStyleGall;
            IStyleGalleryItem pStyleItem; 
            string pp=pStyleStorage.DefaultStylePath;
            pStyleStorage.AddFile(stylepath);    
		    //根据类型取得不同符号集
            if     (symbolstyle=="1")
            {                                                                                                                                       
                pEnumStyleGall = pStyleGallery.get_Items("Marker Symbols", stylepath, "");
            }
            else if(symbolstyle=="2") {
                pEnumStyleGall = pStyleGallery.get_Items("Line Symbols", stylepath, "");
            }
            else if(symbolstyle=="3") {
                pEnumStyleGall = pStyleGallery.get_Items("Fill Symbols", stylepath, "");
            } else  {return null;}
            pEnumStyleGall.Reset();
            pStyleItem = pEnumStyleGall.Next();

            while ( pStyleItem != null)  //Loop through and access each marker
            {
                if (pStyleItem.Name == name)    	//根据符号名称获取符号
                {
                    result = pStyleItem.Item as ISymbol; break;
                }
                
                pStyleItem = pEnumStyleGall.Next();
                
            }
            return result;
        }

        /*axSymbologyControl控件事件
         * 
         */
        private void axSymbologyControl_OnItemSelected(object sender, ISymbologyControlEvents_OnItemSelectedEvent e)
        {
            IStyleGalleryItem selectItem = e.styleGalleryItem as IStyleGalleryItem;
            LabelName.Text = "名称："+selectItem.Name+"\nID："+selectItem.ID+"\n类型："+selectItem.Category;
            previewSymbol(selectItem.Item);
        }
        private void axSymbologyControl_OnDoubleClick(object sender, ISymbologyControlEvents_OnDoubleClickEvent e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        /*管理symbol的类型，设置和预览
         * 
         */
        private void previewSymbol(object Item)
        {
            switch (axSymbologyControl.StyleClass)
            {
                case esriSymbologyStyleClass.esriStyleClassFillSymbols:
                    outColorBtn.Enabled = true; angleSpin.Enabled = false; whichSymbolType = SymbolType.FillSymbol;
                    tmpFillSymbol = Item as IFillSymbol;
                    break;
                case esriSymbologyStyleClass.esriStyleClassLineSymbols:
                    outColorBtn.Enabled = false; angleSpin.Enabled = false; whichSymbolType = SymbolType.LineSymbol;
                    tmpLineSymbol = Item as ILineSymbol;
                    break;                 
                case esriSymbologyStyleClass.esriStyleClassMarkerSymbols:
                    outColorBtn.Enabled = false; angleSpin.Enabled = true; whichSymbolType = SymbolType.MarkerSymbol;
                    tmpMarkerSymbol = Item as IMarkerSymbol;
                    break;
                case esriSymbologyStyleClass.esriStyleClassLegendItems:
                default:
                    tmpNoneSymbol = Item as ISymbol;
                    break;
            }
        }    

        /*呈现方式菜单项
         * 
         */
        private void ToolStripMenuItemIcon_Click(object sender, EventArgs e)
        {
            axSymbologyControl.DisplayStyle = esriSymbologyDisplayStyle.esriDisplayStyleIcon;
        }
        private void ToolStripMenuItemReport_Click(object sender, EventArgs e)
        {
            axSymbologyControl.DisplayStyle = esriSymbologyDisplayStyle.esriDisplayStyleReport;
        }
        private void ToolStripMenuItemSmallIcon_Click(object sender, EventArgs e)
        {
            axSymbologyControl.DisplayStyle = esriSymbologyDisplayStyle.esriDisplayStyleSmallIcon;
        }
        private void ToolStripMenuItemList_Click(object sender, EventArgs e)
        {
            axSymbologyControl.DisplayStyle = esriSymbologyDisplayStyle.esriDisplayStyleList;
        }

        /*符号类型菜单项
         *  
         */
        private void ToolStripMenuItemMakerSymbol_Click(object sender, EventArgs e)
        {
            axSymbologyControl.StyleClass = esriSymbologyStyleClass.esriStyleClassMarkerSymbols;
            whichSymbolType = SymbolType.MarkerSymbol;
        }
        private void ToolStripMenuItemLineSymbol_Click(object sender, EventArgs e)
        {
            axSymbologyControl.StyleClass = esriSymbologyStyleClass.esriStyleClassLineSymbols;
            whichSymbolType = SymbolType.LineSymbol;
        }
        private void ToolStripMenuItemFillSymbol_Click(object sender, EventArgs e)
        {
            axSymbologyControl.StyleClass = esriSymbologyStyleClass.esriStyleClassFillSymbols;
            whichSymbolType = SymbolType.FillSymbol;
        }
        private void ToolStripMenuItemLengdaClass_Click(object sender, EventArgs e)
        {
            axSymbologyControl.StyleClass = esriSymbologyStyleClass.esriStyleClassLegendItems;
            whichSymbolType = SymbolType.None;
        }

        /*确定与取消按钮
         *  
         */
        private void OKBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
        private void CancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        /*样式表加载与保存菜单项
         *   
         * 
         */
        private void MenuItemLoad_Click(object sender, EventArgs e)
        {
            try
            {
                string tmp = util.getSingleFilePathByDlg("打开样式文件", "样式文件(*.ServerStyle)|*.ServerStyle");
                if (tmp != "")
                    axSymbologyControl.LoadStyleFile(strStyleFile = tmp);
            }
            catch (Exception ex)
            {
                MessageBox.Show("文件加载出错，错误：" + ex.ToString());
            }
        }
        private void MenuItemSave_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implement");
        }


        /*符号配置的控件及其事件管理代码
         * 
         * 
         */
        private void colorBtn_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                colorBtn.ForeColor = colorDialog.Color;
                colorBtn.BackColor = colorDialog.Color;
            }
        }
        private void outColorBtn_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                outColorBtn.ForeColor = colorDialog.Color;
                outColorBtn.BackColor = colorDialog.Color;
            }
        }
        private void sizeSpin_ValueChanged(object sender, EventArgs e)
        {

        }
        private void angleSpin_ValueChanged(object sender, EventArgs e)
        {

        }

	




    }
}
