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
namespace Task1ForBasicLoad.MapDecorate
{
    class ExtFunction
    {
        private MapFunction m_Function = new MapFunction();
        private UtilTool m_util = new UtilTool();
        private RenderWorker m_rend = new RenderWorker();
        /*管理地图整饰的额外功能等，如 地图图例、指北针等的操作
         */
        public ExtFunction()
        {
            throw new NotImplementedException("还在测试代码");
        }
    }
}
