using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.DisplayUI;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using Task1ForBasicLoad;
using System.Windows.Forms;
using Task1ForBasicLoad.Plugin;
namespace Task1ForBasicLoad.Plugin
{
    class LayerProperty
    {
        public ISymbol retSymbol = null; 
        private ILayer ChoosedLayer = null;
        private System.Windows.Forms.ContextMenuStrip PopMenuLayerPreoperty = new ContextMenuStrip();
        private SymbolFactory symbolFactory = new SymbolFactory();
        
        /*构造函数
         * 
         */
        public LayerProperty()
        { }
        public LayerProperty(ref ILayer lyr)
        {
            ChoosedLayer = lyr;
        }
      
        /*操作层设置
         * 
         */
        public SystemErrorType  SetLayer(ref ILayer lyr)
        {
            if (lyr == null)
                return SystemErrorType.enumParamIsNull;
            ChoosedLayer = lyr;
            return SystemErrorType.enumOK;
        }
        public ILayer getLayer()
        {
            return ChoosedLayer;
        }
        
        /*层类型判断
         * 
         */
        /// <summary>
        /// 根据传入的层返回其存储的符号类型
        /// </summary>
        /// <param name="lyr">层引用</param>
        /// <returns>符号样式枚举值</returns>
        public esriSymbologyStyleClass ElementShapeType2SymboloStyleType(ref ILayer lyr)
        {
            try
            {
                IFeatureLayer fl = lyr as IFeatureLayer;
                IFeatureClass fc = fl.FeatureClass;
                switch (fc.ShapeType)
                {
                    case esriGeometryType.esriGeometryPoint:return esriSymbologyStyleClass.esriStyleClassMarkerSymbols;
                    case esriGeometryType.esriGeometryPolyline: return esriSymbologyStyleClass.esriStyleClassLineSymbols;
                    case esriGeometryType.esriGeometryPolygon: return esriSymbologyStyleClass.esriStyleClassFillSymbols;
                    default: return esriSymbologyStyleClass.esriStyleClassTextSymbols;
                }
            }
            catch (Exception) 
            {
                return esriSymbologyStyleClass.esriStyleClassLegendItems;
            }
        }
        
        /*显示操作菜单
         * 
         */
        /// <summary>
        /// 显示菜单
        /// </summary>
        /// <param name="control">显示的父控件</param>
        /// <param name="x">x相对位置</param>
        /// <param name="y">y相对位置</param>
        /// <returns>系统错误类型枚举</returns>
        public SystemErrorType ShowMenus(Control control,int x,int y)
        {
            if (ChoosedLayer == null)
                return SystemErrorType.enumParamIsNull;
            try
            {
                CreateMenuItem();
                PopMenuLayerPreoperty.Show(control, x, y);
            }
            catch (Exception )
            {
                return SystemErrorType.enumSystemControlHandleFail;
            }
            return SystemErrorType.enumOK;
        }
        
        /*创建菜单条目
         * 
         */
        private void CreateMenuItem() 
        {
           try
            {
                PopMenuLayerPreoperty.Items.Clear();                                        //清空菜单
                /* 创建属性相关项 */
                if (ChoosedLayer != null)
                {
                    ToolStripItem SymbolItem = null;
                    switch (ElementShapeType2SymboloStyleType(ref ChoosedLayer))
                    {
                        case esriSymbologyStyleClass.esriStyleClassFillSymbols: SymbolItem = new ToolStripButton("ChangeFillSymbol"); break;
                        case esriSymbologyStyleClass.esriStyleClassMarkerSymbols: SymbolItem = new ToolStripButton("ChangeMarkerSymbol"); break;
                        case esriSymbologyStyleClass.esriStyleClassLineSymbols: SymbolItem = new ToolStripButton("ChangeLineSymbol"); break;
                        case esriSymbologyStyleClass.esriStyleClassLegendItems:
                        default: SymbolItem = new ToolStripButton("ChangeSymbolProperty"); break;
                    }
                    PopMenuLayerPreoperty.Items.Add(SymbolItem);
                    SymbolItem.Click += MenuItemEventHandler;
                }
                /* 帮助条目 */
                ToolStripItem HelpItem = new ToolStripButton("Help");
                PopMenuLayerPreoperty.Items.Add(HelpItem);
                HelpItem.Click += MenuItemEventHandler;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        /*菜单事件响应代码
         * 
         */
        private void MenuItemEventHandler(object sender, EventArgs e)
        {
            if(sender.ToString() == "ChangeMarkerSymbol") {
                retSymbol = symbolFactory.CreateSimpleMarkerSymbol() as ISymbol;
            }
            else if (sender.ToString() == "ChangeSymbolProperty")
            {
                retSymbol = symbolFactory.CreateSimpleFillSymbol() as ISymbol;
            }else if(sender.ToString() == "ChangeLineSymbol")  {
                retSymbol = symbolFactory.CreateSimpleLineSymbol() as ISymbol;
            }else if(sender.ToString() == "ChangeFillSymbol") {
                retSymbol = symbolFactory.CreateSimpleFillSymbol() as ISymbol;
            }
            else if (sender.ToString() == "Help") {
                MessageBox.Show("这里进一步实现其他如属性等功能。");
            }
            else {
                retSymbol = null;
            }
        }
    }
}
