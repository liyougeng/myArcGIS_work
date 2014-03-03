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
    class Basic
    {
        private MapFunction m_Function = new MapFunction();
        private UtilTool m_util = new UtilTool();
        private RenderWorker m_rend = new RenderWorker();
        /*管理地图整饰的基本代码,新建、删除、修改其属性、修改其几何图形等。
         */
        /// <summary>
        /// 过滤出被操作的元素
        /// </summary>
        /// <param name="map"></param>
        /// <param name="filter"></param>
        public void GetMapElement(ref AxMapControl map,string filter)
        {
            throw new NotImplementedException("地图整饰，代码重构中");
        }
        public void AddMapElementLayer(ref AxMapControl map, ref ILayer layer)
        {
            throw new NotImplementedException("地图整饰，代码重构中");
        }
        public void DeleteElement(ref AxMapControl map, object element)
        {
            throw new NotImplementedException("地图整饰，代码重构中");
        }
        public void ModifyElement(ref AxMapControl map, object element)
        {
            throw new NotImplementedException("地图整饰，代码重构中");
        }
    }
}
