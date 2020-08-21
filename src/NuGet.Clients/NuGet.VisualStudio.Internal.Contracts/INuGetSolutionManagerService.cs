// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

#nullable enable

using System;
using System.Threading;
using System.Threading.Tasks;

namespace NuGet.VisualStudio.Internal.Contracts
{
    public interface INuGetSolutionManagerService : IDisposable
    {
        event EventHandler<IProjectContextInfo> ProjectAdded;
        event EventHandler<IProjectContextInfo> ProjectRemoved;
        event EventHandler<IProjectContextInfo> ProjectRenamed;
        event EventHandler<IProjectContextInfo> ProjectUpdated;
        event EventHandler<IProjectContextInfo> AfterProjectRenamed;

        ValueTask<string> GetSolutionDirectoryAsync(CancellationToken cancellationToken);
    }
}
