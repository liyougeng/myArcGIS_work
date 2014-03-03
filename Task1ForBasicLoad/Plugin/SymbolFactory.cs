using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Controls;

//ArcGIS
//using ESRI.ArcGIS.Controls;
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

namespace Task1ForBasicLoad.Plugin
{
    class SymbolFactory
    {
        /*创建枚举色彩
         * 
         */
        public IColorRamp CreateAlgorithmicColorRamp(int size = 2,
                                                IRgbColor fromcolor =null,
                                                IRgbColor tocolor   =null,
                                                esriColorRampAlgorithm alogrithm = esriColorRampAlgorithm.esriCIELabAlgorithm)
        {
            if (fromcolor == null)
                fromcolor = getRGB(25, 96, 200) as IRgbColor;
            if (tocolor == null)
                tocolor = getRGB(0, 55, 66) as IRgbColor;
            IAlgorithmicColorRamp algColorRamp = new AlgorithmicColorRamp();
            algColorRamp.FromColor = fromcolor;
            algColorRamp.ToColor = tocolor;
            algColorRamp.Algorithm = alogrithm;
            algColorRamp.Size = size;
            bool btrue = true;
            algColorRamp.CreateRamp(out btrue);
            return algColorRamp;
        }
        /*创建各种符号的公共函数
         * 
         */
        /// <summary>
        /// 创建一个简单符号
        /// </summary>
        /// <param name="color">色彩</param>
        /// <param name="size">大小</param>
        /// <param name="bOutLine">是否外线</param>
        /// <param name="OutColor">外线色彩</param>
        /// <param name="OutLineSize">外线大小</param>
        /// <param name="style">样式</param>
        /// <returns>正常：返回符号；异常：null</returns>
        public ISimpleMarkerSymbol CreateSimpleMarkerSymbol(IRgbColor color = null,
                                                        double size = 7,
                                                        bool bOutLine = true,
                                                        IRgbColor OutColor = null,
                                                        double OutLineSize = 2,
                                                        esriSimpleMarkerStyle style = esriSimpleMarkerStyle.esriSMSCircle)
        {
            try
            {
                if (color == null)
                    color = getRGB(156, 200, 180) as IRgbColor;
                if (OutColor == null)                                                        
                    OutColor = getRGB(70, 90, 160) as IRgbColor;
                ISimpleMarkerSymbol pSimpleMarkerSymbol = new SimpleMarkerSymbolClass();        //创建SimpleMarkerSymbolClass对象
                pSimpleMarkerSymbol.Color = color as IColor;
                pSimpleMarkerSymbol.Style = style;                                            //设置pSimpleMarkerSymbol对象的符号类型，选择钻石
                pSimpleMarkerSymbol.Size = size;                                              //设置pSimpleMarkerSymbol对象大小，设置为５
                pSimpleMarkerSymbol.Outline = bOutLine;                                       //显示外框线
                pSimpleMarkerSymbol.OutlineColor = OutColor as IColor;                          //为外框线设置颜色
                pSimpleMarkerSymbol.OutlineSize = OutLineSize;                                 //设置外框线的宽度
                return pSimpleMarkerSymbol;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public IArrowMarkerSymbol CreateArrowMarkerSymbol(IRgbColor color = null, 
                                                        double      length = 5,
                                                        int          angle = 90,
                                                        double      width  = 1)
        {
            IArrowMarkerSymbol arrowMarkerSymbol = new ArrowMarkerSymbol();
            arrowMarkerSymbol.Angle = angle;
            arrowMarkerSymbol.Style = esriArrowMarkerStyle.esriAMSPlain;
            if (color == null)
                color = getRGB(50, 96, 220) as IRgbColor;
            arrowMarkerSymbol.Color = color;
            arrowMarkerSymbol.Width = width;
            arrowMarkerSymbol.Length = length;
            return arrowMarkerSymbol;
        }

        /// <summary>
        /// CreateSimpleLineSymbol
        /// </summary>
        /// <param name="color"></param>
        /// <param name="width"></param>
        /// <param name="style"></param>
        /// <returns>ISimpleLineSymbol</returns>
        public ISimpleLineSymbol CreateSimpleLineSymbol(IRgbColor color = null, 
                                                     double width     = 3,
                                                     esriSimpleLineStyle style = esriSimpleLineStyle.esriSLSDashDot)
        {
            ISimpleLineSymbol simpleLineSymbol = new SimpleLineSymbol();
            if (color == null)
                color = getRGB(55, 66, 77) as IRgbColor;
            simpleLineSymbol.Color = color;
            simpleLineSymbol.Width = width;
            simpleLineSymbol.Style = style;
            return simpleLineSymbol;
        }
        public IMultiLayerLineSymbol CreateMultiLayerLineSymbol(ILineSymbol symbol1 = null,
                                                          ILineSymbol symbol2 = null,
                                                          ILineSymbol symbol3 = null,
                                                          ILineSymbol symbol4 = null)   
        {
            if (symbol1 == null)
                symbol1 = CreateSimpleLineSymbol(null,2);
            if (symbol2 == null)
                symbol2 = CreateSimpleLineSymbol(getRGB(120,180,22)as IRgbColor,4,esriSimpleLineStyle.esriSLSDot);
            IMultiLayerLineSymbol multiLayerLineSymbol = new MultiLayerLineSymbol();
            multiLayerLineSymbol.AddLayer(symbol1);
            multiLayerLineSymbol.AddLayer(symbol2);
            multiLayerLineSymbol.AddLayer(symbol3);
            return multiLayerLineSymbol;
        }
        /// <summary>
        /// CreateSimpleFillSymbol
        /// </summary>
        /// <param name="color">color</param>
        /// <param name="outline">outline</param>
        /// <param name="style">style</param>
        /// <returns>IFillSymbol</returns>
        public IFillSymbol CreateSimpleFillSymbol(IRgbColor color =null,
                                             ILineSymbol outline = null,
                                             esriSimpleFillStyle style = esriSimpleFillStyle.esriSFSCross)
        {
            ISimpleFillSymbol simpleFillSymbol = new SimpleFillSymbol();
            if (color == null)
                color = getRGB(63, 99, 150) as IRgbColor;
            if (outline == null)
                outline = CreateSimpleLineSymbol(getRGB(99, 99, 240) as IRgbColor, 2);
            simpleFillSymbol.Style = style;
            simpleFillSymbol.Color = color;
            simpleFillSymbol.Outline = outline;
            return simpleFillSymbol;
        }
        /// <summary>
        /// getLineFillSymbol
        /// </summary>
        /// <param name="color">color</param>
        /// <param name="angle">angle</param>
        /// <param name="offset">offset</param>
        /// <param name="separation">separation</param>
        /// <param name="linesymbol">linesymbol</param>
        /// <param name="outline">outline</param>
        /// <returns>ILineFillSymbol</returns>
        public ILineFillSymbol getLineFillSymbol(
                                            IRgbColor color= null,
                                            double angle   = 60 , 
                                            double offset  =1   ,
                                            double separation=1  ,
                                            ILineSymbol linesymbol= null,
                                            ILineSymbol outline   = null)
        {
            ILineFillSymbol lineFillSymbol = new LineFillSymbol();
            if (color == null)
                color = getRGB(210, 36, 240) as IRgbColor;
            if (linesymbol == null)
                linesymbol = CreateSimpleLineSymbol(getRGB(55, 90, 180) as IRgbColor, 2, esriSimpleLineStyle.esriSLSDot);
            if (outline == null)
                outline = CreateSimpleLineSymbol(getRGB(155, 190, 180) as IRgbColor, 3, esriSimpleLineStyle.esriSLSDash);
            lineFillSymbol.Color = color;
            lineFillSymbol.Angle = angle;
            lineFillSymbol.Offset = offset;
            lineFillSymbol.Separation = separation;
            lineFillSymbol.Outline = outline;
            lineFillSymbol.LineSymbol = linesymbol;
            return lineFillSymbol;
        }

        /// <summary>
        /// 创建高级渐变符号
        /// </summary>
        /// <returns>正常：返回符号；异常：null</returns>
        public IGradientFillSymbol CreateAdvancedSymbol()
        {
            try
            {
                //为填充符号创建外框线符号
                IColor pLineColor = new RgbColorClass();
                pLineColor.RGB = 220;
                IGradientFillSymbol pGradientFillSymbol = new GradientFillSymbolClass();
                pGradientFillSymbol.IntervalCount = 1;
                pGradientFillSymbol.Color = pLineColor;
                //创建一个填充符号
                //ISimpleFillSymbol pSmplFillSymbol = new SimpleFillSymbol();
                //设置填充符号的属性
                // IColor pRgbClr = new RgbColorClass();
                //IFillSymbol pFillSymbol = pSmplFillSymbol;
                //pFillSymbol.Color = pRgbClr;
                //pFillSymbol.Outline = pGradientFillSymbol;
                return pGradientFillSymbol;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /*共享函数，取色
         * 
         */
        public IColor getRGB(int R = 0, int G = 0, int B = 0)
        {
            IRgbColor c = new RgbColorClass();
            c.Blue = B; c.Red = R; c.Green = G;
            return c as IColor;
        }
        public IColor getHVS(int H = 0, int S = 0, int V = 0)
        {
            IHsvColor pHsvColor;
            pHsvColor = new HsvColorClass();
            pHsvColor.Hue = H;
            pHsvColor.Saturation = S;
            pHsvColor.Value = V;
            return pHsvColor as IColor;
        }

    }
}
