using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Infrastructure.States
{
    public interface IState
    {
        Task Enter();
        void Exit();
    }
}
