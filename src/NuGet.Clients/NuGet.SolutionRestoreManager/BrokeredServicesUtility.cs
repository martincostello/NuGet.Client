// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Threading.Tasks;
using Microsoft.ServiceHub.Framework;
using Microsoft.VisualStudio.Shell.ServiceBroker;

namespace NuGet.SolutionRestoreManager
{
    internal static class BrokeredServicesUtility
    {
        // These service names and versions must be kept in sync with those in NuGet.VisualStudio.Internal.Contracts.NuGetServices.
        internal const string SolutionServiceName = "Microsoft.VisualStudio.NuGet.SolutionService";
        internal const string SolutionServiceVersion = "1.0.0";

        internal const string DeprecatedSolutionServiceName = "NuGetSolutionService";
        internal const string DeprecatedSolutionServiceVersion = "1.0.0";

        internal static readonly ServiceRpcDescriptor DeprecatedSolutionService = new ServiceJsonRpcDescriptor(
            new ServiceMoniker(DeprecatedSolutionServiceName, new Version(DeprecatedSolutionServiceVersion)),
            ServiceJsonRpcDescriptor.Formatters.UTF8,
            ServiceJsonRpcDescriptor.MessageDelimiters.HttpLikeHeaders);

        internal static readonly ServiceRpcDescriptor SolutionService = new ServiceJsonRpcDescriptor(
            new ServiceMoniker(SolutionServiceName, new Version(SolutionServiceVersion)),
            ServiceJsonRpcDescriptor.Formatters.UTF8,
            ServiceJsonRpcDescriptor.MessageDelimiters.HttpLikeHeaders);

        internal static BrokeredServiceFactory GetNuGetSolutionServicesFactory()
        {
            return (mk, options, sb, ct) => new ValueTask<object>(new NuGetSolutionService());
        }
    }
}
