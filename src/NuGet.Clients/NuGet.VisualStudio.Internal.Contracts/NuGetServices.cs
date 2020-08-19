// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

#nullable enable

using System;
using Microsoft.ServiceHub.Framework;

namespace NuGet.VisualStudio.Internal.Contracts
{
    public static class NuGetServices
    {
        // These service names and versions must be kept in sync with those elsewhere.
        private const string SolutionServiceName = "Microsoft.VisualStudio.NuGet.SolutionService";
        private const string SolutionServiceVersion = "1.0.0";
        private const string SolutionManagerServiceName = "Microsoft.VisualStudio.NuGet.SolutionManagerService";
        private const string SolutionManagerServiceVersion = "1.0.0";
        private const string SourceProviderServiceName = "Microsoft.VisualStudio.NuGet.SourceProviderService";
        private const string SourceProviderServiceVersion = "1.0.0";
        private const string ProjectManagerProviderServiceName = "Microsoft.VisualStudio.NuGet.ProjectManagerService";
        private const string ProjectManagerServiceVersion = "1.0.0";

        public static readonly ServiceRpcDescriptor SolutionService = new ServiceJsonRpcDescriptor(
            new ServiceMoniker(SolutionServiceName, new Version(SolutionServiceVersion)),
            ServiceJsonRpcDescriptor.Formatters.UTF8,
            ServiceJsonRpcDescriptor.MessageDelimiters.HttpLikeHeaders);
        public static readonly ServiceRpcDescriptor SourceProviderService = new NuGetServiceMessagePackRpcDescriptor(
            new ServiceMoniker(SourceProviderServiceName, new Version(SourceProviderServiceVersion)));
        public static readonly ServiceRpcDescriptor SolutionManagerService = new NuGetServiceMessagePackRpcDescriptor(
            new ServiceMoniker(SolutionManagerServiceName, new Version(SolutionManagerServiceVersion)));
        public static readonly ServiceRpcDescriptor ProjectManagerService = new NuGetServiceMessagePackRpcDescriptor(
            new ServiceMoniker(ProjectManagerProviderServiceName, new Version(ProjectManagerServiceVersion)));
    }
}
