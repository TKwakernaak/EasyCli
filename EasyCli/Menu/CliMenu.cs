using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyCli.Menu
{
    public class CliMenu
    {
        private readonly IEnumerable<ICliAction> _actions;

        public CliMenu(IEnumerable<ICliAction> actions)
        {
            _actions = actions.OrderBy(e => nameof(e.GetType));
        }

        public ICliAction ShowMenu()
        {
            Console.WriteLine("\n Available actions: \n");

            var menuList = _actions.Select((action, index) => $"Number: {index} Name: {action.GetType().Name} Description: {action.Description}");

            foreach (var menuAction in menuList)
            {
                Console.WriteLine(menuAction);
            }

            Console.WriteLine("\n Select the number of the action that you wish to perform.");

            //Return the cliAction based on the number that the user selected.
            return _actions.ElementAt(GetUserSelectedMenuAction());
        }

        private static int GetUserSelectedMenuAction()
        {
            string selectedAction = Console.ReadLine();
            bool isValidInput = int.TryParse(selectedAction, out int selectedIndex);

            if (!isValidInput)
            {
                Console.WriteLine($"action {selectedAction} is not valid");
                GetUserSelectedMenuAction();
            }

            return selectedIndex;
        }
    }
}
