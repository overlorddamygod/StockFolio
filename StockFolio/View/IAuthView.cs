using StockFolio.Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockFolio.View
{
    public interface IAuthView
    {
        String LoginEmail { get; set; }
        String LoginPassword { get; set; }
        String RegisterUsername { get; set; }
        String RegisterEmail { get; set; }
        String RegisterPassword { get; set; }
        TabControl TabControl { get; }
        AuthPresenter Presenter { get; set; }

        void HideView();
    }
}
