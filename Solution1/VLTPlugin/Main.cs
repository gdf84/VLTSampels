using Autodesk.Connectivity.Explorer.Extensibility;
using Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VLTPlugin.Controls;

namespace VLTPlugin
{
    public class Main : IExplorerExtension {
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
            result.Add(pan);
            //pan.
            return result;        
        }

        public IEnumerable<string> HiddenCommands() {
            var result = new List<string>();

            // IApplication.CommandIds можно получить список в OnLogon
            result.Add("File.Edit");
            return result;
            
        }

        public void OnLogOff(IApplication application) {

        }

        public void OnLogOn(IApplication application) {

            var Connection = application.Connection;
            var WebMan = application.Connection.WebServiceManager;
            //VaultManager vm = new VaultManager(WebMan, application);
        }

        public void OnShutdown(IApplication application) {
        }

        public void OnStartup(IApplication application) {
        }
    }
}
