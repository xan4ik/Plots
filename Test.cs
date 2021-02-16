using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plots
{
    class Controller
    {
        Model inner;
    }


    class Model 
    {
       public int a;
    }

    class View 
    {
        void Present(Model model) 
        {
        
        }
    }

    class component 
    {
        Controller controller;
        View View;
    }
}
