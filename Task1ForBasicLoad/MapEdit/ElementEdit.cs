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
using Task1ForBasicLoad.Plugin;
using Task1ForBasicLoad;
//该文件仍在重构中.
namespace Task1ForBasicLoad.MapEdit
{
    class ElementEdit
    {
        private MapFunction m_Function = new MapFunction();
        private UtilTool m_util = new UtilTool();
        private RenderWorker m_rend = new RenderWorker();
        private bool b_isUnderEdit = false;
        public List<object> operationList;//操作类性质与结构有待进一步确定
        private List<AxMapControl> m_mapList;//改成装引用/指针
        //public  AxMapControl MapControl;
        /*管理 元素的操作，包括开始编辑、结束编辑、Undo、Redo等操作的实现。
         */
        //具体，见WorkShopEdit
        public ElementEdit()
        {
            throw new NotImplementedException("元素的操作");
        }
    }
}
