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
    class WorkShopEdit
    {
        private MapFunction m_Function = new MapFunction();
        private UtilTool m_util = new UtilTool();
        private RenderWorker m_rend = new RenderWorker();
        private bool b_isUnderEdit = false;
        public List<object> operationList;//操作类性质与结构有待进一步确定
        private List<AxMapControl> m_mapList;//改成装引用/指针
        //public  AxMapControl MapControl;
        /*管理工作空间的操作，包括开始编辑、结束编辑、Undo、Redo等操作的实现。
         */
        public IWorkspaceEdit WorkshopEdit(ILayer m_CurrentLayer) 
        {
            //throw new NotImplementedException("目前这一部份由ArcGIS系统实现");
            if (m_CurrentLayer == null) return null;

            IFeatureLayer m_FeatureLayer = (IFeatureLayer)m_CurrentLayer;
            IFeatureClass m_FeatureClass = m_FeatureLayer.FeatureClass;
            IDataset m_Dataset = (IDataset)m_FeatureClass;
            if (m_Dataset == null) return null;
            return (IWorkspaceEdit)m_Dataset.Workspace;
        }
        //这个函数以实现要素的删除为例
        public void DeleteEdit(ref AxMapControl mapControl ) 
        {
            ILayer lyr; //获取编辑图层
            if ((lyr=mapControl.Map.get_Layer(0)) == null) 
                return;
            IWorkspaceEdit pWorkspaceEdit = WorkshopEdit(lyr);//得到图层空间
            pWorkspaceEdit.StartEditOperation();
            IFeatureCursor pFeatureCursor = GetSelectedFeatures((IFeatureLayer)lyr);//获取游标
            IFeature pFeature = pFeatureCursor.NextFeature();
            while (pFeature != null)
            {
                pFeature.Delete();
                pFeature = pFeatureCursor.NextFeature();
            }
            pWorkspaceEdit.StopEditOperation();

            IActiveView pActiveView = (IActiveView)mapControl.Map;
            pActiveView.Refresh();
           
        }
        //获取被选中的要素
        private IFeatureCursor GetSelectedFeatures(IFeatureLayer m_CurrentLayer)
        {
            if (m_CurrentLayer == null) return null;

            // 检查是否有要素被选中，没有则MessageBox提醒
            IFeatureSelection pFeatSel = (IFeatureSelection)m_CurrentLayer;
            ISelectionSet pSelectionSet = pFeatSel.SelectionSet;
            if (pSelectionSet.Count == 0)
            {
                throw new Exception("为选中");//此处需要进一步处理
            }

            // 有则返回要素游标
            ICursor pCursor;
            pSelectionSet.Search(null, false, out pCursor);
            return (IFeatureCursor)pCursor;
        }
        public void AddEdit(ref AxMapControl mapControl)
        {
            //
        }
        public void ModifyEdit(ref AxMapControl mapControl)
        {

        }
        public void Undo(ref AxMapControl mapControl)
        {

        }
        public void Redo(ref AxMapControl mapControl)
        {
 
        }
        public void Edit(ref AxMapControl mapControl,int EditType)
        {
            //实现编辑的分配，映射到私有方法中
        }

    }
}
