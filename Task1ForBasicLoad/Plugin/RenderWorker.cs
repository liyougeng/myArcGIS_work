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
namespace Task1ForBasicLoad.Plugin
{
    class RenderWorker
    {
        private SymbolFactory SymbolWorker = new SymbolFactory();
        private AxMapControl axMapControl = null;
        public RenderWorker() { }
        public RenderWorker(ref AxMapControl theMapControl)
        {
            axMapControl = theMapControl;
        }
        public void setMapControl(ref AxMapControl theMapControl)
        {
            axMapControl = theMapControl;
        }

        /*从文件按类型取符号
         * 
         */
        ///<summary>
        ///获取符号库中符号
        ///</summary>
        ///<param name="sServerStylePath">符号库全路径名称</param>
        ///<param name="sGalleryClassName">GalleryClass名称</param>
        ///<param name="symbolName">符号名称</param>
        ///<returns>正常：符号；异常：null</returns>
        private ISymbol GetSymbol(string sServerStylePath, string sGalleryClassName, string symbolName)
        {
            try
            {
                //ServerStyleGallery对象
                IStyleGallery pStyleGaller = new ServerStyleGalleryClass();
                IStyleGalleryStorage pStyleGalleryStorage = pStyleGaller as IStyleGalleryStorage;
                IEnumStyleGalleryItem pEnumSyleGalleryItem = null;
                IStyleGalleryItem pStyleGallerItem = null;
                IStyleGalleryClass pStyleGalleryClass = null;
                //使用IStyleGalleryStorage接口的AddFile方法加载ServerStyle文件
                pStyleGalleryStorage.AddFile(sServerStylePath);
                //遍历ServerGallery中的Class
                for (int i = 0; i < pStyleGaller.ClassCount; i++)
                {
                    pStyleGalleryClass = pStyleGaller.get_Class(i);
                    if (pStyleGalleryClass.Name != sGalleryClassName)
                        continue;
                    //获取EnumStyleGalleryItem对象
                    pEnumSyleGalleryItem = pStyleGaller.get_Items(sGalleryClassName, sServerStylePath, "");
                    pEnumSyleGalleryItem.Reset();
                    //遍历pEnumSyleGalleryItem
                    pStyleGallerItem = pEnumSyleGalleryItem.Next();
                    while (pStyleGallerItem != null)
                    {
                        if (pStyleGallerItem.Name == symbolName)
                        {
                            //获取符号
                            ISymbol pSymbol = pStyleGallerItem.Item as ISymbol;
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(pEnumSyleGalleryItem);
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(pStyleGalleryClass);
                            return pSymbol;
                        }
                        pStyleGallerItem = pEnumSyleGalleryItem.Next();
                    }
                }
                System.Runtime.InteropServices.Marshal.ReleaseComObject(pEnumSyleGalleryItem);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(pStyleGalleryClass);
                return null;
            }
            catch (Exception )
            {                
                return null;
            }
        }

        public IGeoFeatureLayer getGeoLayer(string layerName )
        {
            ILayer layer;
            IGeoFeatureLayer geoFeatureLayer;
            if (axMapControl == null)
                return null;
            for (int i = 0; i < axMapControl.LayerCount; i++)
            {
                layer = axMapControl.get_Layer(i);
                if (layer != null && layer.Name == layerName)
                {
                    geoFeatureLayer = layer as IGeoFeatureLayer;
                    return geoFeatureLayer;
                }
            }
            return null;
        }
        /*不同渲染方式
         * 
         */
        ///<summary>
        ///设置要素图层唯一值符号化
        ///</summary>
        ///<param name="pFeatureLayer">特征层</param>
        private void UniqueValueRenderFlyr()
        {
            IGeoFeatureLayer geoFeatureLayer = null;
            geoFeatureLayer = getGeoLayer("Continents");
            IUniqueValueRenderer uniqueValueRenderer = new UniqueValueRendererClass();
            uniqueValueRenderer.FieldCount = 1;
            uniqueValueRenderer.set_Field(0, "SQMI");
            ISimpleFillSymbol simpleFillSymbol = SymbolWorker.CreateSimpleFillSymbol() as ISimpleFillSymbol;
            IFeatureCursor featureCursor = geoFeatureLayer.FeatureClass.Search(null, false);
            IFeature feature;
            if (featureCursor != null)
            {
                IEnumColors enumColors = SymbolWorker.CreateAlgorithmicColorRamp(8).Colors;
                IColor dullColor = enumColors.Next();
                int fiedIndex = geoFeatureLayer.FeatureClass.Fields.FindField("SQMI");
                for (int i = 0; i < 7; i++)
                {
                    feature = featureCursor.NextFeature();
                    string nameValue = feature.get_Value(fiedIndex).ToString();
                    simpleFillSymbol = new SimpleFillSymbolClass();
                    simpleFillSymbol.Color = enumColors.Next();
                    uniqueValueRenderer.AddValue(nameValue, "SQMI", simpleFillSymbol as ISymbol);
                }
            }
            geoFeatureLayer.Renderer = uniqueValueRenderer as IFeatureRenderer;
        }
        private void SimpleRenderFlyr()
        {
            ISimpleFillSymbol simpleFillSymbol = SymbolWorker.CreateSimpleFillSymbol() as ISimpleFillSymbol;
            ISimpleRenderer simpleRender = new SimpleRendererClass();
            simpleRender.Symbol = simpleFillSymbol as ISymbol;
            simpleRender.Label = "Continents";
            simpleRender.Description = "简单渲染";
            IGeoFeatureLayer geoFeatureLayer;
            geoFeatureLayer = getGeoLayer("Continents");
            ITransparencyRenderer transRenderer;
            transRenderer = simpleRender as ITransparencyRenderer;
            transRenderer.TransparencyField = "SQMI";
            geoFeatureLayer.Renderer = transRenderer as IFeatureRenderer;
            
        }
        private void BreakClassRender()
        {
            IGeoFeatureLayer geoFeatureLayer;
            geoFeatureLayer = getGeoLayer("Continents");
            IUniqueValueRenderer uniqueValueRenderer = new UniqueValueRendererClass();
            uniqueValueRenderer.FieldCount = 1;
            uniqueValueRenderer.set_Field(0, "SQMI");
            ISimpleFillSymbol simpleFillSymbol = SymbolWorker.CreateSimpleFillSymbol() as ISimpleFillSymbol;
            IFeatureCursor featureCursor = geoFeatureLayer.FeatureClass.Search(null, false);
            IFeature feature;
            if (featureCursor != null)
            {
                IEnumColors enumColors = SymbolWorker.CreateAlgorithmicColorRamp(7).Colors;
                int fiedIndex = geoFeatureLayer.FeatureClass.Fields.FindField("SQMI");
                for (int i = 0; i < 7; i++)
                {
                    feature = featureCursor.NextFeature();
                    string nameValue = feature.get_Value(fiedIndex).ToString();
                    simpleFillSymbol = new SimpleFillSymbolClass();
                    simpleFillSymbol.Color = enumColors.Next();
                    uniqueValueRenderer.AddValue(nameValue, "SQMI", simpleFillSymbol as ISymbol);
                }
            }
            geoFeatureLayer.Renderer = uniqueValueRenderer as IFeatureRenderer;
        }
      
        /*公共渲染接口/函数
         * 
         */
        /// <summary>
        /// 层渲染函数
        /// </summary>
        /// <param name="layer">特征层</param>
        /// <param name="symbol">渲染符号</param>
        public void RendLayer(ref ILayer layer, ISymbol symbol)
        {
            IGeoFeatureLayer pGeoFeatureL = null;
            if (layer == null)
                return;
            else
                pGeoFeatureL = layer as IGeoFeatureLayer;
            ISimpleRenderer pSimpleRenderer = new SimpleRendererClass();
            if (symbol == null)
            {
                pSimpleRenderer.Symbol = SymbolWorker.CreateSimpleLineSymbol() as ISymbol;
            }
            else
            {
                pSimpleRenderer.Symbol = symbol;
            }
            pSimpleRenderer.Description = "USA";
            pSimpleRenderer.Label = "SimpleRenderer";
            ITransparencyRenderer pTransRenderer = pSimpleRenderer as ITransparencyRenderer;
            pTransRenderer.TransparencyField = "POP1999";
            pGeoFeatureL.Renderer = pTransRenderer as IFeatureRenderer;
        }
        public void RendLayer( int type = 0)
        {
            switch (type)
            {
                case 0: UniqueValueRenderFlyr(); break;
                case 1: SimpleRenderFlyr(); break;
                case 2: BreakClassRender(); break;
                default: SimpleRenderFlyr(); break;
            }
        }
    }
}
