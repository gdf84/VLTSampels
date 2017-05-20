using Autodesk.Connectivity.Explorer.Extensibility;
using Autodesk.Connectivity.WebServices;
using Autodesk.Connectivity.WebServicesTools;
using Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VLTPlugin.Controls;
using VLTPlugin.Interface;

namespace VLTPlugin
{
    public class Main : IExplorerExtension {

        public static IVault VaultManager;

        public IEnumerable<CommandSite> CommandSites() {
            List<CommandSite> CommandSites = new List<CommandSite>();

            CommandSite pullDownMenu = new CommandSite("mainmenu", "Новая менюшка") {
                Location = CommandSiteLocation.ToolsMenu,
                DeployAsPulldownMenu = true
            };

            CommandItem ciHelloWorld  = new CommandItem("mainmenu.testwindow", "Hello world!!!") {
                MultiSelectEnabled = false,
                Description = "Описание команды",
                Hint = "Подсказка",
                Image = Images.Action
            };
            ciHelloWorld.Execute += Commands.HelloWorld;

            CommandItem ciSomeCommand = new CommandItem("mainmenu.somecommand", "Some Command") {
                MultiSelectEnabled = false,
                Description = "Описание команды",
                Hint = "Подсказка",
                Image = Images.Action
            };
            ciSomeCommand.Execute += Commands.SomeCommand;

            pullDownMenu.AddCommand(ciHelloWorld);
            pullDownMenu.AddCommand(ciSomeCommand);

            // Контекстное меню для папок
            CommandSite csCtx = new CommandSite("ctx", "Контекстное меню") {
                Location = CommandSiteLocation.FolderContextMenu,
                DeployAsPulldownMenu = true
            };

            CommandItem ciCtxSomeCommand = new CommandItem("ctx.ciCtxCommand", "Some command") {
                MultiSelectEnabled = false,                
                Image = Images.Action
            };

            ciCtxSomeCommand.Execute += Commands.SomeCommand;
            csCtx.AddCommand(ciCtxSomeCommand);

            CommandSites.Add(pullDownMenu);
            CommandSites.Add(csCtx);

            return CommandSites;
        }
        public IEnumerable<CustomEntityHandler> CustomEntityHandlers() {
            //var result = new List<CustomEntityHandler>();

            //CustomEntityHandler ceh = new CustomEntityHandler("FILE");
            //ceh.DeleteCustomEntity += Commands.SomeCommand;

            //result.Add(ceh);
            //return result;
            return null;
        }
       

        public IEnumerable<DetailPaneTab> DetailTabs() {
            var result = new List<DetailPaneTab>();
            var pan = new DetailPaneTab("adsk.sometab", "Новая закладка", SelectionTypeId.Folder, typeof(SomeControl));
            pan.SelectionChanged += Pan_SelectionChanged;
            result.Add(pan);
            //pan.
            return result;        
        }

        private void Pan_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        public IEnumerable<string> HiddenCommands() {
            var result = new List<string>();
            // IApplication.CommandIds можно получить список в OnLogon
            result.Add("File.Edit");
            //result.Add("No Company.VLTPlugin.mainmenu.somecommand");
            result.Add("Exit");
            return result;            
        }

        public void OnLogOff(IApplication application) {

        }

        public void OnLogOn(IApplication application) {

            var Connection = application.Connection;
            var WebMan = application.Connection.WebServiceManager;
            VaultManager.Initialize(WebMan);

            //WebMan.DocumentServiceExtensions.PostInvokeEvents += DocumentServiceExtensions_PostInvokeEvents;
            //WebMan.DocumentService.PostInvokeEvents += DocumentServiceExtensions_PostInvokeEvents;
            //WebMan.FilestoreService.PostInvokeEvents += DocumentServiceExtensions_PostInvokeEvents;
            //WebMan.FilestoreVaultService.PostInvokeEvents += DocumentServiceExtensions_PostInvokeEvents;

            
            //WebMan.ItemService.PostInvokeEvents += DocumentServiceExtensions_PostInvokeEvents;
            //WebMan.PackageService.PostInvokeEvents += DocumentServiceExtensions_PostInvokeEvents;

            DocumentServiceExtensions.UpdateFileLifecycleStateEvents.Post +=
                UpdateFileLifecycleStateEvents_Post;
        }

        private void UpdateFileLifecycleStateEvents_Post(object sender, UpdateFileLifeCycleStateCommandEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void DocumentServiceExtensions_PostInvokeEvents(object sender, WebServiceInvokeEventArgs e)
        {
            
        }

        public void OnShutdown(IApplication application) {
        }

        List<string> cmdIds;
#if VLT2017
        public void OnStartup(IApplication application) {
            cmdIds = application.CommandIds.ToList();
            application.CommandEnd += Application_CommandEnd;
            VaultManager = new VaultManager();
        }

        private void Application_CommandEnd(object sender, CommandEndEventArgs e)
        {
            //throw new NotImplementedException();
        }
#endif
#if VLT2018
        public void OnStarVault(IExtApplication application)
        {
            cmdIds = application.CommandIds.ToList();
        }
#endif
    }
}
