﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor.Services;

namespace BlazorRedux
{
    public class Store<TState, TAction> : IDisposable
    {
        private readonly TState _initialState;
        private readonly Reducer<TState, TAction> _rootReducer;
        private readonly ReduxOptions<TState> _options;
        private IUriHelper _uriHelper;
        private string _currentLocation;
        private bool _timeTraveling;
        private readonly object _syncRoot = new object();

        public TState State { get; private set; }
        public IList<HistoricEntry<TState, object>> History { get; }
        public event EventHandler Change;

        public Store(TState initialState, Reducer<TState, TAction> rootReducer, ReduxOptions<TState> options)
        {
            _initialState = initialState;
            _rootReducer = rootReducer;
            _options = options;

            State = initialState;

            DevToolsInterop.Reset += OnDevToolsReset;
            DevToolsInterop.TimeTravel += OnDevToolsTimeTravel;

            Task.Run(async () => await DevToolsInterop.Log("initial", _options.StateSerializer(State)));

            History = new List<HistoricEntry<TState, object>>
            {
                new HistoricEntry<TState, object>(State)
            };
        }

        internal void Init(IUriHelper uriHelper)
        {
            if (_uriHelper != null || uriHelper == null) return;

            lock (_syncRoot)
            {
                _uriHelper = uriHelper;
                _uriHelper.OnLocationChanged += OnLocationChanged;
            }

            // TODO: Queue up any other actions, and let this apply to the initial state.
            DispatchLocation(new NewLocationAction { Location = _uriHelper.GetAbsoluteUri() });

            Console.WriteLine("Redux store initialized.");
        }

        public void Dispose()
        {
            if (_uriHelper != null)
                _uriHelper.OnLocationChanged -= OnLocationChanged;
            
            DevToolsInterop.Reset -= OnDevToolsReset;
            DevToolsInterop.TimeTravel -= OnDevToolsTimeTravel;
        }

        private void OnLocationChanged(object sender, string newAbsoluteUri)
        {
            if (_timeTraveling) return;
            if (newAbsoluteUri == _currentLocation) return;

            lock (_syncRoot)
            {
                _currentLocation = newAbsoluteUri;
            }

            DispatchLocation(new NewLocationAction { Location = newAbsoluteUri });
        }

        private void OnDevToolsReset(object sender, EventArgs e)
        {
            var state = _initialState;
            TimeTravel(state);
        }

        private void OnDevToolsTimeTravel(object sender, StringEventArgs e)
        {
            var state = _options.StateDeserializer(e.String);
            _timeTraveling = true;
            TimeTravel(state);
            _timeTraveling = false;
        }

        private void OnChange(EventArgs e)
        {
            var handler = Change;
            handler?.Invoke(this, e);

            var getLocation = _options.GetLocation;
            if (getLocation == null) return;
            var newLocation = getLocation(State);
            if (newLocation == _currentLocation || newLocation == null) return;

            lock (_syncRoot)
            {
                _currentLocation = newLocation;
            }

            _uriHelper.NavigateTo(newLocation);
        }

        public void Dispatch(TAction action)
        {
            lock (_syncRoot)
            {
                State = _rootReducer(State, action);

                Task.Run(async () => await DevToolsInterop.Log(action.ToString(), _options.StateSerializer(State)));
                History.Add(new HistoricEntry<TState, object>(State, action));
            }

            OnChange(null);
        }

        void DispatchLocation(NewLocationAction locationAction)
        {
            var locationReducer = _options.LocationReducer;

            if (locationReducer == null && locationAction is TAction)
            {
                // Just use the RootReducer unless the user has configured a LocationReducer
                var genericAction = (TAction)(object)locationAction;
                Dispatch(genericAction);
            }

            if (locationReducer == null) return;

            lock (_syncRoot)
            {
                State = locationReducer(State, locationAction);
                Task.Run(async () => await DevToolsInterop.Log(locationAction.ToString(), _options.StateSerializer(State)));
                History.Add(new HistoricEntry<TState, object>(State, locationAction));
            }

            OnChange(null);
        }

        public void TimeTravel(TState state)
        {
            lock (_syncRoot)
            {
                State = state;
            }

            OnChange(null);
        }
    }
}