﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KozzionCore.Networking
{
    public interface IMessageHandler
    {
        void Handle(Message message);
    }
}
