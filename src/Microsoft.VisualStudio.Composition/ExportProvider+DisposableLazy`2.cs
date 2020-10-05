﻿// Copyright (c) Microsoft. All rights reserved.

namespace Microsoft.VisualStudio.Composition
{
    using System;

    public partial class ExportProvider
    {
        private interface INonSharedLazy
        {
            NonSharedExport NonSharedExport { get; }
        }

        private class NonSharedLazy<T, TMetadata> : Lazy<T, TMetadata>, INonSharedLazy
        {
            internal NonSharedLazy(Func<T> valueFactory, TMetadata metadata, NonSharedExport chainDisposable)
                : base(valueFactory, metadata)
            {
                Requires.NotNull(chainDisposable, nameof(chainDisposable));
                this.NonSharedExport = chainDisposable;
            }

            public NonSharedExport NonSharedExport { get; }
        }
    }
}
