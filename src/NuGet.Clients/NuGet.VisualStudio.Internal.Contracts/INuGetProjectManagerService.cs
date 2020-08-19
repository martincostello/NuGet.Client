// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

#nullable enable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NuGet.PackageManagement;
using NuGet.Packaging;
using NuGet.Packaging.Core;
using NuGet.Resolver;

namespace NuGet.VisualStudio.Internal.Contracts
{
    public interface INuGetProjectManagerService : IDisposable
    {
        ValueTask<IReadOnlyCollection<PackageReference>> GetInstalledPackagesAsync(IReadOnlyCollection<string> projectIds, CancellationToken cancellationToken);
        ValueTask<object> GetMetadataAsync(string projectId, string key, CancellationToken cancellationToken);
        ValueTask<(bool, object)> TryGetMetadataAsync(string projectId, string key, CancellationToken cancellationToken);
        ValueTask<IProjectContextInfo> GetProjectAsync(string projectId, CancellationToken cancellationToken);
        ValueTask<IReadOnlyCollection<IProjectContextInfo>> GetProjectsAsync(CancellationToken cancellationToken);
        ValueTask<bool> IsProjectUpgradeableAsync(string projectId, CancellationToken cancellationToken);
        ValueTask<IReadOnlyCollection<IProjectContextInfo>> GetUpgradeableProjectsAsync(IReadOnlyCollection<string> projectIds, CancellationToken cancellationToken);
        ValueTask<IProjectContextInfo> UpgradeProjectToPackageReferenceAsync(string projectId, CancellationToken cancellationToken);
        ValueTask<IReadOnlyCollection<IProjectContextInfo>> GetProjectsWithDeprecatedDotnetFrameworkAsync(CancellationToken cancellationToken);

        ValueTask BeginOperationAsync();
        ValueTask EndOperationAsync();
        ValueTask ExecuteActionsAsync(IReadOnlyList<ProjectAction> actions, CancellationToken cancellationToken);

        ValueTask<IReadOnlyList<ProjectAction>> GetInstallActionsAsync(
            string projectId,
            PackageIdentity packageIdentity,
            VersionConstraints versionConstraints,
            bool includePrelease,
            DependencyBehavior dependencyBehavior,
            IReadOnlyList<string> packageSourceNames,
            CancellationToken cancellationToken);

        ValueTask<IReadOnlyList<ProjectAction>> GetUninstallActionsAsync(
            string projectId,
            string packageId,
            bool removeDependencies,
            bool forceRemove,
            CancellationToken cancellationToken);

        ValueTask<IReadOnlyList<ProjectAction>> GetUpdateActionsAsync(
            IReadOnlyCollection<string> projectIds,
            IReadOnlyCollection<PackageIdentity> packageIdentities,
            VersionConstraints versionConstraints,
            bool includePrelease,
            DependencyBehavior dependencyBehavior,
            IReadOnlyList<string> packageSourceNames,
            CancellationToken cancellationToken);
    }
}