using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Core.StateStackPackage
{
    public interface State
    {
        void OnPressed();

        void OnPushed();

        void OnPoped();

        void OnReturnTop();
    }
}
