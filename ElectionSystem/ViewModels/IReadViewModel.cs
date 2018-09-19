﻿using System.Collections.ObjectModel;

namespace ElectionSystem.ViewModels
{
    public interface IReadViewModel<T>
    {
        ObservableCollection<T> Collection { get; set; }
        T Selected { get; set; }

        void Read();
        void Create();
        void Update();
        void Delete();
    }
}