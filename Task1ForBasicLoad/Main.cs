using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.DisplayUI;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using Task1ForBasicLoad.Plugin;

namespace Task1ForBasicLoad
{
    public partial class Main : Form
    {
        MapFunction ArcObject = new MapFunction();
        UtilTool util = new UtilTool();
        RenderWorker RenderWorkerObject = null;
        SymbolFactory SymbolSuppler = new SymbolFactory();
        LayerProperty LPMenu = new LayerProperty();
        ILayer choosedLayer = null;
        object choosedIndex = null;
        /*窗体与类启动函数
         * 
         */
        public Main()
        {
            InitializeComponent();
            RenderWorkerObject = new RenderWorker(ref axMapControl);
            statusTipLabel.Text = util.handleSystemError(
                                    ArcObject.UIToolControlAddItemFix(ref axToolbarControl));
        }
        private void Main_Load(object sender, EventArgs e)
        {
            RenderWorkerObject.setMapControl(ref axMapControl);
        }

        /*文件菜单项单击事件响应函数
         * 
         */
        private void MenuItem_ShapeFile_Load_Click(object sender, EventArgs e)
        {
            statusTipLabel.Text = util.handleSystemError(
                                    ArcObject.LoadDataFromFile(ref axMapControl, DataFileType.enumShapeFile));
        }
        private void MenuItem_MxdFile_Load_Click(object sender, EventArgs e)
        {
            statusTipLabel.Text = util.handleSystemError(
                                    ArcObject.LoadDataFromFile(ref axMapControl, DataFileType.enumMXDMapFile));
        }
        private void MenuItem_AccessFile_Load_Click(object sender, EventArgs e)
        {
            statusTipLabel.Text = util.handleSystemError(
                                    ArcObject.LoadDataFromFile(ref axMapControl, DataFileType.enumAccessFile));
        }
        private void MenuItem_RasterFile_Load_Click(object sender, EventArgs e)
        {
            statusTipLabel.Text = util.handleSystemError(
                                    ArcObject.LoadDataFromFile(ref axMapControl, DataFileType.enumRasterFile));
        }
        private void MenuItem_CADFile_Load_Click(object sender, EventArgs e)
        {
            statusTipLabel.Text = util.handleSystemError(
                                    ArcObject.LoadDataFromFile(ref axMapControl, DataFileType.enumAutoCADFile));
        }

        /*地图放缩操作菜单项事件响应函数
         * 
         */
        private void panMenuItem_Click(object sender, EventArgs e)
        {
            statusTipLabel.Text = util.handleSystemError(
                                    ArcObject.UIToolControlAddItem(ref axToolbarControl, AxToolBarItem.enumControlsMapPanTool));
        }
        private void zoomInMenuItem_Click(object sender, EventArgs e)
        {
            statusTipLabel.Text = util.handleSystemError(
                                    ArcObject.UIToolControlAddItem(ref axToolbarControl, AxToolBarItem.enumControlsMapZoomInTool));
        }
        private void zoomOutMenuItem_Click(object sender, EventArgs e)
        {
            statusTipLabel.Text = util.handleSystemError(
                                    ArcObject.UIToolControlAddItem(ref axToolbarControl, AxToolBarItem.enumControlsMapZoomOutTool));
        }

        /*地图控件事件响应
         * 
         */
        private void axMapControl_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            return;
            ISimpleLineSymbol pSimpleLineSymbol;
            pSimpleLineSymbol = new SimpleLineSymbolClass();

            pSimpleLineSymbol.Color = SymbolSuppler.getRGB(230,10,60);

            pSimpleLineSymbol.Style = esriSimpleLineStyle.esriSLSDot;
            pSimpleLineSymbol.Width = 3;
            IGeometry pGeo;
            pGeo = axMapControl.TrackLine();
            object oLineSymbol = pSimpleLineSymbol;
            axMapControl.DrawShape(pGeo, ref oLineSymbol);
        }

        private IRgbColor getRGB(int r, int g, int b)
      {
            IRgbColor pColor;
            pColor = new RgbColorClass();
            pColor.Red = r;
            pColor.Green = g;
            pColor.Blue = b;
            return pColor;
      }


        /*地图符号，图层属性的显示与修改筛选
         * 
         */
        private void axTOCControl_OnMouseDown(object sender, ITOCControlEvents_OnMouseDownEvent e)
      {
            esriTOCControlItem item = esriTOCControlItem.esriTOCControlItemNone;
            IBasicMap map = null;
            ILayer layer = null;
            object other = null;
            object index = null;
            axTOCControl.HitTest(e.x, e.y, ref item, ref map, ref layer, ref other, ref index);
            //确定选定的菜单类型，Map或是图层菜单，元素
            if (item == esriTOCControlItem.esriTOCControlItemMap) {return;}
            else if (item == esriTOCControlItem.esriTOCControlItemLayer){
                if (e.button == 2)
                {//right click
                    choosedLayer = layer; choosedIndex = index;
                    LayerContextMenuStrip.Show(axTOCControl, e.x, e.y);
                    return;
                }
            } else if (item == esriTOCControlItem.esriTOCControlItemLegendClass)
            {
                if (e.button == 1)                                                //鼠标左键  
                {
                    CustomSymbology dlgCSymbol = new CustomSymbology(LPMenu.ElementShapeType2SymboloStyleType(ref layer));
                    if(dlgCSymbol.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        RenderWorkerObject.RendLayer(ref layer, dlgCSymbol.getChosedSymbol());
                    else
                        return;
                }
                else if (e.button == 2)                                            //鼠标右键
                {
                    LPMenu.SetLayer(ref layer);
                    LPMenu.ShowMenus(axTOCControl, e.x, e.y);
                    RenderWorkerObject.RendLayer(ref layer,LPMenu.retSymbol);
                }
            }
            axTOCControl.Refresh();
            axMapControl.Refresh();
	        axMapControl.CustomProperty = layer;
        }

        /*渲染方式菜单项
         * 
         */
        private void SimpleRendItem_Click(object sender, EventArgs e)
        {
            if (!ArcObject.getLastMapFilePath().Contains("World.mxd"))
            {
                MessageBox.Show("调试：\n渲染请打开 C:\\Program Files (x86)\\ArcGIS\\DeveloperKit10.0\\Samples\\data\\World\\world.mxd  文件");
                return;
            }
            RenderWorkerObject.RendLayer();
            axMapControl.ActiveView.Refresh();
        }
        private void UniquRendItem_Click(object sender, EventArgs e)
        {
            if (!ArcObject.getLastMapFilePath().Contains("orld.mxd"))
            {
                MessageBox.Show("调试：\n渲染请打开 C:\\Program Files (x86)\\ArcGIS\\DeveloperKit10.0\\Samples\\data\\World\\world.mxd  文件");
                return;
            }
            RenderWorkerObject.RendLayer(1);
            axMapControl.ActiveView.Refresh();
        }
        private void BreakClassItem_Click(object sender, EventArgs e)
        {
            if (!ArcObject.getLastMapFilePath().Contains("World.mxd"))
            {
                MessageBox.Show("调试：\n渲染请打开 C:\\Program Files (x86)\\ArcGIS\\DeveloperKit10.0\\Samples\\data\\World\\world.mxd  文件");
                return;
            }
            RenderWorkerObject.RendLayer(2);
            axMapControl.ActiveView.Refresh();

        }

        /*地图层的删除，上移，下移，操作
         */
        private void handleLayer_Click(object sender, EventArgs e)
        {
            if (choosedLayer != null) {
                int i = ArcObject.getLayerIndexByName(ref axMapControl,choosedLayer.Name);
                if(i>-1)
                    axMapControl.DeleteLayer(i);
            }
        }
        private void menu_uplayer_Click(object sender, EventArgs e)
        {
            if (choosedLayer != null) {
                int i = ArcObject.getLayerIndexByName(ref axMapControl,choosedLayer.Name);
                if(i>0)
                    axMapControl.MoveLayerTo(i,i-1);
        }
        }
        private void menu_downlayer_Click(object sender, EventArgs e)
        {
            if (choosedLayer != null)
            {
                int i = ArcObject.getLayerIndexByName(ref axMapControl, choosedLayer.Name);
                if (i > -1 && i < axMapControl.LayerCount-1)
                    axMapControl.MoveLayerTo(i, i + 1);
            }
        }
        private void LayerMenuItemInfo_Click(object sender, EventArgs e)
        {
            if (choosedLayer != null)
            {
                int i = ArcObject.getLayerIndexByName(ref axMapControl, choosedLayer.Name);
                string info = "最大scale:" + choosedLayer.MaximumScale + ";最小Scale:" + choosedLayer.MinimumScale + "\n名称:" + choosedLayer.Name
                    + "\n空间参考:" + "null";
                
                MessageBox.Show(info);
            }
        }

        /***打开连接SDE对话框，实现SDE连接
         * 
         */
        private void btnConnect2SDE_Click(object sender, EventArgs e)
        {
            Link2SDE dlg = new Link2SDE();
            dlg.ShowDialog();
        }

        private void btnChoosePoint_Click(object sender, EventArgs e)
        {
            axToolbarControl.CurrentTool = null;
            if (btnChoosePoint.Text == "点要素选取")
            {
                btnChoosePoint.Text = "停止选取";
                axToolbarControl.CurrentTool = null;
                axMapControl.Map.ClearSelection();
                axMapControl.Refresh();
            }
            else {//stop choose 
                btnChoosePoint.Text = "点要素选取";
                axMapControl.Map.ClearSelection();
                axMapControl.Refresh();
            }
        }

        private void axMapControl_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            toolStripStatusLabel1.Text= " 当前坐标 X = " + e.mapX.ToString() + " Y = " + e.mapY.ToString() + " " + axMapControl.MapUnits;
        }
    }
}