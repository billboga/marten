﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Marten.Events.Projections.Async
{
    public interface IActiveProjections
    {
        IProjectionTrack TrackFor(string viewType);

        IProjectionTrack[] CoordinatedTracks { get; }

        IProjectionTrack[] AllTracks { get; }

        IProjectionTrack[] SelfGoverningTracks { get; set; }
    }


    // Will have a stream that feeds into Daemon
    public class Daemon
    {
        private readonly IFetcher _fetcher;
        private readonly IDictionary<string, ProjectionTrack> _tracks = new ConcurrentDictionary<string, ProjectionTrack>();

        // Should do this as a linked list. Make EventPage have a next?

        public Daemon(IDocumentStore store, IFetcher fetcher, IActiveProjections projections)
        {
            _fetcher = fetcher;
        }

        public void Start()
        {
            //_fetcher.Start();
        }

        





        public Task CachePage(EventPage page)
        {
            // TODO:
            /*
             * * store the page
             * * if this makes you go over the threshold for maximum items, latch the fetcher
             * * if it's the next page for any projection, send it on
             * 
             */
            throw new NotImplementedException();
        }

        public Task StoreProgress(string viewType, EventPage page)
        {
            // TODO -- Need to update projection status
            // * Trim off anything that's obsolete
            // * if under the maximum items stored, make sure that the fetcher is started
            // * if there is any more cached after this view, send the next page on
            // * if there are downstream projections from this one, send the page on
            //   to the next projection

            throw new NotImplementedException();
        }
    }
}