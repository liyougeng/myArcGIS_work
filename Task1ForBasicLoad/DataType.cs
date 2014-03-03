/**
 * Summary:Contain DataType Enum defintion
 * Author:cz
 * ChangeLog:
 * Data:
 */
namespace Task1ForBasicLoad
{
    /*地图文件类型枚举
     * 
     */
    enum DataFileType { 
        enumShapeFile,
        enumAutoCADFile,
        enumMXDMapFile,
        enumAccessFile,
        enumRasterFile
    }
    /*控件工具条枚举
     * 
     */
    enum AxToolBarItem
    {
        enumControlsMapPanTool,
        enumControlsMapZoomInTool,
        enumControlsMapZoomOutTool,
        enumControlsMapLeftCommand,
        enumControlsMapRightCommand,
        enumControlsMapUpCommand,
        enumControlsMapDownCommand
    }
    /*符号类型枚举
     * 
     */
    enum SymbolType
    {
        None,
        MarkerSymbol,
        LineSymbol,
        FillSymbol
    }
    /*系统错误类型枚举
     * 
     */
    enum SystemErrorType
    {
        enumOK,
        enumFileNotExist,
        enumFilePathIsNull,
        enumDataIsIllegal,
        enumArcObjectHandleError,
        enumArcOjectLoadFail,
        enumSystemControlHandleFail,
        enumParamIsNull,
        enumTypeNotExist,
        enumUnknowError
    }
}