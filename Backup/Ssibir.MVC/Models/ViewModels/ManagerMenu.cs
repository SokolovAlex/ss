using Ssibir.DAL.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ssibir.MVC.Models.ViewModels
{
    public class ManagerMenu
    {
        public IEnumerable<int> pageTypes;

        public ManagerMenu()
        {
            pageTypes = Enum.GetValues(typeof(PageType)).Cast<int>();
        }
    }
}