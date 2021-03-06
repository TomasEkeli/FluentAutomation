﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using FluentAutomation.API.Interfaces;

namespace FluentAutomation.RemoteCommands.Commands
{
    [CommandArgumentsType(typeof(ExpectElementArguments))]
    public class ExpectElement : IRemoteCommand
    {
        public void Execute(API.CommandManager manager, IRemoteCommandArguments arguments)
        {
            var args = (ExpectElementArguments)arguments;

            Guard.ArgumentNotNullForCommand<ExpectClass>(args.Selector);
            Guard.ArgumentNotNullForCommand<ExpectClass>(args.Expression);

            manager.Expect.Element(args.Expression).In(args.Selector);
        }
    }

    public class ExpectElementArguments : IRemoteCommandArguments
    {
        public string Selector { get; set; }
        public Expression<Func<IElementDetails, bool>> Expression { get; set; }
    }
}
