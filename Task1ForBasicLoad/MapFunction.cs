using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//ArcGIS
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
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.DisplayUI;

namespace Task1ForBasicLoad
{
    class MapFunction
    {
//private section        
        private IMapDocument m_MapDocument;
        private string lastMapDocumentPath = "C:\\Program Files (x86)\\ArcGIS\\DeveloperKit10.0\\Samples\\data\\World\\world.mxd";
        private UtilTool UtilObject = new UtilTool();
        /// <summary>
        /// 加载默认MXD文件
        /// </summary>
        /// <param name="axMapControl">axMapControl引用</param>
        /// <param name="strFilePath">地图文件路径</param>
        /// <returns>正常：“”；异常：异常字符串</returns>
        private SystemErrorType LoadMapDoc(ref AxMapControl axMapControl, string strFilePath)
        {
            //文件路径检验
            if (strFilePath == "")
                return SystemErrorType.enumFilePathIsNull;                               
            try
            {
                m_MapDocument = new MapDocumentClass();
                m_MapDocument.Open(strFilePath, "");
                for (int i = 0; i <= m_MapDocument.MapCount - 1; i++)
                    axMapControl.Map = m_MapDocument.get_Map(i);
                axMapControl.Refresh();
            }
            catch (Exception)
            {
                return SystemErrorType.enumArcObjectHandleError;
            }
            return SystemErrorType.enumOK;
        }
        /// <summary>
       /// 加载CAD文件
       /// </summary>
       /// <param name="axMapControl">地图控件引用</param>
       /// <param name="strFilePath">文件路径</param>
       /// <returns>正常：“”，异常：异常字符；</returns>
        private SystemErrorType LoadCADFile(ref AxMapControl axMapControl, string strFilePath)
        {
            if (strFilePath =="")
                return SystemErrorType.enumFilePathIsNull;
            try
            {
                //workspace声明
                IWorkspaceFactory pCadWorkspaceFactory = null;
                IWorkspace pWorkspace = null;
                ICadDrawingWorkspace pCadDrawingWorkspace = null;
                ICadDrawingDataset pCadDataset = null;
                ICadLayer pCadLayer = null;
                //地图数据操作
                pCadWorkspaceFactory = new CadWorkspaceFactoryClass();
                pWorkspace = pCadWorkspaceFactory.OpenFromFile(strFilePath, 0);
                pCadDrawingWorkspace = pWorkspace as ICadDrawingWorkspace;
                pCadDataset = pCadDrawingWorkspace.OpenCadDrawingDataset(strFilePath);
                pCadLayer = new CadLayerClass();
                pCadLayer.CadDrawingDataset = pCadDataset;
                //控件操作
                axMapControl.ClearLayers();
                axMapControl.AddLayer(pCadLayer, 0);
                axMapControl.Refresh();
            }
            catch (Exception )
            {
                return SystemErrorType.enumArcObjectHandleError;
            }
            return SystemErrorType.enumOK;
        }
        /// <summary>
        /// 加载Access文件
       /// </summary>
        /// <param name="axMapControl">地图控件引用</param>
        /// <param name="strFilePath">文件路径</param>
        /// <returns>正常：“”，异常：异常字符；</returns>
        private SystemErrorType LoadAccessFile(ref AxMapControl axMapControl, string strFilePath)
        {
            if (strFilePath == "")
                return SystemErrorType.enumFilePathIsNull;
            try
            {
                //声明区域,创建工作空间并遍历数据集
                IWorkspaceFactory   pAccessWorkspaceFactory =new AccessWorkspaceFactoryClass();
                IFeatureWorkspace   pFeatureWorkspace = null;
                IWorkspace          pWorkspace = pAccessWorkspaceFactory.OpenFromFile(strFilePath, 0);
                IEnumDataset        pEnumDataset = pWorkspace.get_Datasets(esriDatasetType.esriDTAny);
                                    pEnumDataset.Reset();
                IDataset pDataset =  pEnumDataset.Next();
                //如果数据集是IFeatureDataset则遍历它下面的子集
                if (pDataset is IFeatureDataset)
                {
                    pFeatureWorkspace =  pAccessWorkspaceFactory.OpenFromFile(strFilePath, 0) as IFeatureWorkspace;
                    IFeatureDataset      pFeatureDataset = pFeatureWorkspace.OpenFeatureDataset(pDataset.Name);
                    IEnumDataset        pEnumDataset1 = pFeatureDataset.Subsets;
                                        pEnumDataset1.Reset();
                    IDataset pDataset1 = pEnumDataset1.Next();
                    //如果子类是FeatureClass，则添加到地图控件中
                    if (pDataset1 is IFeatureClass)
                    {
                        IFeatureLayer pFeatureLayer = new FeatureLayerClass();
                        pFeatureLayer.FeatureClass = pFeatureWorkspace.OpenFeatureClass(pDataset1.Name);
                        pFeatureLayer.Name = pFeatureLayer.FeatureClass.AliasName;
                        axMapControl.ClearLayers();
                        axMapControl.Map.AddLayer(pFeatureLayer);
                        axMapControl.ActiveView.Refresh();
                    }
                    else
                        return SystemErrorType.enumDataIsIllegal;
                }
                else
                    return SystemErrorType.enumDataIsIllegal;
            }
            catch (Exception ) 
            {
                return SystemErrorType.enumArcObjectHandleError;
            }
            return SystemErrorType.enumOK;
        }
        /// <summary>
        /// 加载Shape文件
        /// </summary>
        /// <param name="axMapControl">地图控件引用</param>
        /// <param name="strFilePath">文件路径</param>
        /// <returns>正常：“”，异常：异常字符；</returns>
        private SystemErrorType LoadShapeFile(ref AxMapControl axMapControl, string strFilePath)
        {
            if (strFilePath == "")
                return SystemErrorType.enumFilePathIsNull;
            try
            {
                IWorkspaceFactory pWorkSpaceFactory = null;
                IFeatureWorkspace pFeatureWorkspace = null;
                IFeatureClass pFeatureClass = null;
                IFeatureLayer pFeatureLayer = null;
                String WorkSpacePath = strFilePath.Substring(0, strFilePath.LastIndexOf('\\'));//取文件夹路径
                string Layers = strFilePath.Substring(strFilePath.LastIndexOf('\\') + 1);        //取文件名
                //创建shape文件workspace，加载shape文件到地图控件
                pWorkSpaceFactory = new ShapefileWorkspaceFactory()  as IWorkspaceFactory;
                if (pWorkSpaceFactory.IsWorkspace(WorkSpacePath))
                {
                    pFeatureWorkspace = pWorkSpaceFactory.OpenFromFile(WorkSpacePath, 0) as IFeatureWorkspace;
                    pFeatureClass = pFeatureWorkspace.OpenFeatureClass(Layers);
                    pFeatureLayer = new FeatureLayer() as IFeatureLayer;
                    pFeatureLayer.Name = Layers.Substring(0, Layers.Length - 4);
                    pFeatureLayer.FeatureClass = pFeatureClass;
                    axMapControl.ClearLayers();
                    axMapControl.AddLayer(pFeatureLayer);
                    axMapControl.ActiveView.Refresh();
                }
                else
                    return SystemErrorType.enumDataIsIllegal;
            }
            catch (Exception )
            {
                return SystemErrorType.enumArcObjectHandleError;
            }
            return SystemErrorType.enumOK;
        }
        /// <summary>
        /// 加载栅格数据文件
        /// </summary>
        /// <param name="axMapControl">地图控件引用</param>
        /// <param name="strFilePath">文件路径</param>
        /// <returns>正常：“”，异常：异常字符；</returns>
        private SystemErrorType LoadRasterFile(ref AxMapControl axMapControl, string strFilePath)
        {
            if (strFilePath == "")
                return SystemErrorType.enumFilePathIsNull;
            try
            {
                IWorkspaceFactory pWorkspaceFactory = null;
                IRasterWorkspace pRasterWorkspace = null;
                IRasterDataset pRasterDataset = null;
                IRasterLayer pRasterLayer = null;
                String WorkspacePath = strFilePath.Substring(0,strFilePath.LastIndexOf('\\'));//e.g.     c:/data/a.shp
                pWorkspaceFactory = new RasterWorkspaceFactoryClass() as IWorkspaceFactory;
                //如果符合要求 ， 打开栅格数据文件并加载到地图控件中。
                if (pWorkspaceFactory.IsWorkspace(WorkspacePath))
                {
                    pRasterWorkspace = pWorkspaceFactory.OpenFromFile(WorkspacePath, 0) as IRasterWorkspace;
                    pRasterDataset = pRasterWorkspace.OpenRasterDataset(strFilePath.Substring(strFilePath.LastIndexOf('\\') + 1));
                    pRasterLayer = new RasterLayerClass() as IRasterLayer;
                    pRasterLayer.CreateFromDataset(pRasterDataset);
                    axMapControl.ClearLayers();
                    axMapControl.AddLayer(pRasterLayer);
                    axMapControl.ActiveView.Refresh();      //axMapControl.Extent = axMapControl.FullExtent;
                }
                else
                    return SystemErrorType.enumDataIsIllegal;
            }
            catch (Exception )
            {
                return SystemErrorType.enumArcObjectHandleError;
            }
            return SystemErrorType.enumOK;
        }


//public section
        /// <summary>
        /// LoadDataFile From File
        /// </summary>
        /// <param name="axMapControl">ref AxMapControl</param>
        /// <param name="enumDataFileType">enumDataFileType</param>
        /// <returns>status String</returns>
        public SystemErrorType LoadDataFromFile(ref AxMapControl axMapControl,DataFileType enumDataFileType)
        {
            switch (enumDataFileType)
            {
                case DataFileType.enumAccessFile:
                    return LoadAccessFile(ref axMapControl,UtilObject.getSingleFilePathByDlg("打开Access数据文件", "Access文件(*.mdb)|*.mdb") );
                case DataFileType.enumAutoCADFile:
                    return LoadCADFile(ref axMapControl, UtilObject.getSingleFilePathByDlg("打开CAD文件", "CAD数据(*.dwg)|*.dwg"));
                case DataFileType.enumMXDMapFile:
                    return LoadMapDoc(ref axMapControl, UtilObject.getSingleFilePathByDlg("打开Mxd地图文件", "地图文件(*.mxd;*.mxt;*.pmf)|*.mxd;*.mxt;*.pmf"));
                case DataFileType.enumRasterFile:
                    return LoadRasterFile(ref axMapControl, UtilObject.getSingleFilePathByDlg("打开栅格数据", "栅格数据(*.tif;*.bmp;*.jpg;*.tiff)|*.tif;*.bmp;*.jpg;*.tiff"));
                case DataFileType.enumShapeFile:
                    return LoadShapeFile(ref axMapControl,UtilObject.getSingleFilePathByDlg("打开shape文件", "ShapeFile(*.shp)|*.shp") );
                default:
                    return SystemErrorType.enumTypeNotExist;
            }
        }

        /// <summary>
        /// ToolControl中增加控件
        /// </summary>
        /// <param name="axToolbarControl">ToolControl控件引用</param>
        /// <returns>正常：“”；异常：异常字符串</returns>
        public SystemErrorType UIToolControlAddItemFix(ref AxToolbarControl axToolbarControl)
        {
            try
            {
                //添加控件中的item by UID
                UID uIDZoomInC = new UIDClass();
                uIDZoomInC.Value = "esriControlCommands.ControlsMapZoomInFixedCommand";
                axToolbarControl.AddItem(uIDZoomInC, -1, -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
                UID uIDZoomOutC = new UIDClass();
                uIDZoomOutC.Value = "esriControlCommands.ControlsMapZoomOutFixedCommand";
                axToolbarControl.AddItem(uIDZoomOutC, -1, -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);

                //添加控件中的item by progID; up down left right
                string UPprogID = "esriControlCommands.ControlsMapUpCommand";
                axToolbarControl.AddItem(UPprogID, -1, -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
                string DownprogID = "esriControlCommands.ControlsMapDownCommand";
                axToolbarControl.AddItem(DownprogID, -1, -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
                axToolbarControl.AddItem("esriControlCommands.ControlsMapLeftCommand");
                axToolbarControl.AddItem("esriControlCommands.ControlsMapRightCommand");

                //添加控件中的item by ICommand : zoomIn,ZoomOut,Gobal,Walk
                axToolbarControl.AddItem(new ControlsMapZoomInTool());
                axToolbarControl.AddItem(new ControlsMapZoomOutTool());
                ICommand command = new ControlsMapFullExtentCommandClass();
                axToolbarControl.AddItem(command, -1, -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
                axToolbarControl.AddItem(new ControlsMapPanTool());
            } catch (Exception ) 
            {
                return SystemErrorType.enumArcObjectHandleError;
            }
            return SystemErrorType.enumOK;
        }
        public SystemErrorType UIToolControlAddItem(ref AxToolbarControl axToolbarControl,AxToolBarItem enumAxBarItem)
        {
            try
            {
                switch (enumAxBarItem)
                {
                    case AxToolBarItem.enumControlsMapPanTool:
                        axToolbarControl.AddItem(new ControlsMapPanTool());break;
                    case AxToolBarItem.enumControlsMapDownCommand:
                        axToolbarControl.AddItem("esriControlCommands.ControlsMapDownCommandbreak");break;
                    case AxToolBarItem.enumControlsMapLeftCommand:
                        axToolbarControl.AddItem("esriControlCommands.ControlsMapLeftCommand");break;
                    case AxToolBarItem.enumControlsMapRightCommand:
                        axToolbarControl.AddItem("esriControlCommands.ControlsMapRightCommand");break;
                    case AxToolBarItem.enumControlsMapUpCommand:
                        axToolbarControl.AddItem("esriControlCommands.ControlsMapUpCommand");break;
                    case AxToolBarItem.enumControlsMapZoomInTool:
                        axToolbarControl.AddItem(new ControlsMapZoomInTool());break;
                    case AxToolBarItem.enumControlsMapZoomOutTool:
                        axToolbarControl.AddItem(new ControlsMapZoomOutTool());break;
                    default:
                        return SystemErrorType.enumTypeNotExist;
                }
                return SystemErrorType.enumOK;
            }catch (Exception )
            {
                return SystemErrorType.enumArcObjectHandleError;
            }
        }
        /// <summary>
        /// 按名称获得层序号
        /// </summary>
        /// <param name="map">地图控件</param>
        /// <param name="name">层名称</param>
        /// <returns>正常：层序号；异常：-1</returns>
        public int getLayerIndexByName(ref AxMapControl map, string name)
        {
            for (int i = 0; i < map.LayerCount; i++)
            {
                if (map.get_Layer(i).Name.Equals(name))
                    return i;
            }
            return -1;
        }
        
        public string getLastMapFilePath()
        {
            return lastMapDocumentPath = UtilObject.lastFilePath;
        }
        public string Test()
        {

            return "end";
        }

    }
}
