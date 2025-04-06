/*
' Copyright (c) 2025 ITElite
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/

using System.Collections.Generic;
//using System.Xml;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Search;

namespace PixelPress_DesignerPixelPress_Designer.Components
{

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The Controller class for PixelPress_Designer
    /// 
    /// The FeatureController class is defined as the BusinessController in the manifest file (.dnn)
    /// DotNetNuke will poll this class to find out which Interfaces the class implements. 
    /// 
    /// The IPortable interface is used to import/export content from a DNN module
    /// 
    /// The ISearchable interface is used by DNN to index the content of a module
    /// 
    /// The IUpgradeable interface allows module developers to execute code during the upgrade 
    /// process for a module.
    /// 
    /// Below you will find stubbed out implementations of each, uncomment and populate with your own data
    /// </summary>
    /// -----------------------------------------------------------------------------

    //uncomment the interfaces to add the support.
    public class FeatureController //: IPortable, ISearchable, IUpgradeable
    {


        #region Optional Interfaces

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// ExportModule implements the IPortable ExportModule Interface
        /// </summary>
        /// <param name="ModuleID">The Id of the module to be exported</param>
        /// -----------------------------------------------------------------------------
        //public string ExportModule(int ModuleID)
        //{
        //string strXML = "";

        //List<PixelPress_DesignerInfo> colPixelPress_Designers = GetPixelPress_Designers(ModuleID);
        //if (colPixelPress_Designers.Count != 0)
        //{
        //    strXML += "<PixelPress_Designers>";

        //    foreach (PixelPress_DesignerInfo objPixelPress_Designer in colPixelPress_Designers)
        //    {
        //        strXML += "<PixelPress_Designer>";
        //        strXML += "<content>" + DotNetNuke.Common.Utilities.XmlUtils.XMLEncode(objPixelPress_Designer.Content) + "</content>";
        //        strXML += "</PixelPress_Designer>";
        //    }
        //    strXML += "</PixelPress_Designers>";
        //}

        //return strXML;

        //	throw new System.NotImplementedException("The method or operation is not implemented.");
        //}

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// ImportModule implements the IPortable ImportModule Interface
        /// </summary>
        /// <param name="ModuleID">The Id of the module to be imported</param>
        /// <param name="Content">The content to be imported</param>
        /// <param name="Version">The version of the module to be imported</param>
        /// <param name="UserId">The Id of the user performing the import</param>
        /// -----------------------------------------------------------------------------
        //public void ImportModule(int ModuleID, string Content, string Version, int UserID)
        //{
        //XmlNode xmlPixelPress_Designers = DotNetNuke.Common.Globals.GetContent(Content, "PixelPress_Designers");
        //foreach (XmlNode xmlPixelPress_Designer in xmlPixelPress_Designers.SelectNodes("PixelPress_Designer"))
        //{
        //    PixelPress_DesignerInfo objPixelPress_Designer = new PixelPress_DesignerInfo();
        //    objPixelPress_Designer.ModuleId = ModuleID;
        //    objPixelPress_Designer.Content = xmlPixelPress_Designer.SelectSingleNode("content").InnerText;
        //    objPixelPress_Designer.CreatedByUser = UserID;
        //    AddPixelPress_Designer(objPixelPress_Designer);
        //}

        //	throw new System.NotImplementedException("The method or operation is not implemented.");
        //}

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// GetSearchItems implements the ISearchable Interface
        /// </summary>
        /// <param name="ModInfo">The ModuleInfo for the module to be Indexed</param>
        /// -----------------------------------------------------------------------------
        //public DotNetNuke.Services.Search.SearchItemInfoCollection GetSearchItems(DotNetNuke.Entities.Modules.ModuleInfo ModInfo)
        //{
        //SearchItemInfoCollection SearchItemCollection = new SearchItemInfoCollection();

        //List<PixelPress_DesignerInfo> colPixelPress_Designers = GetPixelPress_Designers(ModInfo.ModuleID);

        //foreach (PixelPress_DesignerInfo objPixelPress_Designer in colPixelPress_Designers)
        //{
        //    SearchItemInfo SearchItem = new SearchItemInfo(ModInfo.ModuleTitle, objPixelPress_Designer.Content, objPixelPress_Designer.CreatedByUser, objPixelPress_Designer.CreatedDate, ModInfo.ModuleID, objPixelPress_Designer.ItemId.ToString(), objPixelPress_Designer.Content, "ItemId=" + objPixelPress_Designer.ItemId.ToString());
        //    SearchItemCollection.Add(SearchItem);
        //}

        //return SearchItemCollection;

        //	throw new System.NotImplementedException("The method or operation is not implemented.");
        //}

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// UpgradeModule implements the IUpgradeable Interface
        /// </summary>
        /// <param name="Version">The current version of the module</param>
        /// -----------------------------------------------------------------------------
        //public string UpgradeModule(string Version)
        //{
        //	throw new System.NotImplementedException("The method or operation is not implemented.");
        //}

        #endregion

    }

}
