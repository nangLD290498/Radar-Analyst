using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadarAnalyst.Factory
{
    internal class TabFactory
    {
        public static TabPage getTab(String tabCode)
        {
            Console.WriteLine("TabFactory::getTab");
            TabPage tabPage;

            tabPage = new UIComponent.KVCTDTabPage(tabCode.ToLower());

            switch (tabCode)
            {
                case Util.Constant.KVCTD:
                    tabPage = new UIComponent.KVCTDTabPage(Util.Constant.KVCTD_TEXT);
                    break;
                case Util.Constant.DCDD:
                    tabPage = new UIComponent.DCDDTabPage(Util.Constant.DCDD_TEXT);
                    break;
                case Util.Constant.KTMPX:
                    tabPage = new UIComponent.KTMPXTabPage(Util.Constant.KTMPX_TEXT);
                    break;
                case Util.Constant.DLL:
                    tabPage = new UIComponent.DLLTabPage(Util.Constant.DLL_TEXT);
                    break;
                case Util.Constant.DN:
                    tabPage = new UIComponent.DNTabPage(Util.Constant.DN_TEXT);
                    break;
                case Util.Constant.MCDH:
                    tabPage = new UIComponent.MCDHTabPage(Util.Constant.MCDH_TEXT);
                    break;
                case Util.Constant.GCK:
                    tabPage = new UIComponent.GCKTabPage(Util.Constant.GCK_TEXT);
                    break;
                case Util.Constant.PVPHMP:
                    tabPage = new UIComponent.PVPHMPTabPage(Util.Constant.PVPHMP_TEXT);
                    break;
                default:
                    tabPage = new TabPage();
                    break;
            }

            return tabPage;
        }
    }
}
