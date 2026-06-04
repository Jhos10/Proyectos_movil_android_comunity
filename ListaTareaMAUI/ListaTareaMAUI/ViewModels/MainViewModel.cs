using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ListaTareaMAUI.Models;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Linq;
using Microsoft.Maui.Storage;
using System;
using System.Collections.Generic;

namespace ListaTareaMAUI.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<TaskItem> tasks = new ObservableCollection<TaskItem>();

        [ObservableProperty]
        private string newTaskName = string.Empty;

        public MainViewModel()
        {
            CargarTareas();
        }

        [RelayCommand]
        private void AddTask()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(NewTaskName))
                {
                    var nextId = Tasks.Any() ? Tasks.Max(t => t.Id) + 1 : 1;
                    Tasks.Add(new TaskItem
                    {
                        Id = nextId,
                        Name = NewTaskName,
                        IsCompleted = false,
                        CreatedAt = DateTime.Now
                    });

                    NewTaskName = string.Empty;
                    GuardarTareas();
                }
            }
            catch (Exception ex)
            {
                Shell.Current.DisplayAlert("Error", $"No se pudo agregar: {ex.Message}", "OK");
            }
        }

        [RelayCommand]
        private void DeleteTask(TaskItem task)
        {
            if (task != null)
            {
                Tasks.Remove(task);
                GuardarTareas();
            }
        }

        private void GuardarTareas()
        {
            try
            {
                string json = JsonSerializer.Serialize(Tasks);
                Preferences.Set("MisTareas", json);
            }
            catch (Exception ex)
            {
                Shell.Current.DisplayAlert("Error", $"No se pudo guardar: {ex.Message}", "OK");
            }
        }

        private void CargarTareas()
        {
            try
            {
                string json = Preferences.Get("MisTareas", string.Empty);

                if (!string.IsNullOrEmpty(json))
                {
                    var tareas = JsonSerializer.Deserialize<List<TaskItem>>(json);
                    if (tareas != null)
                    {
                        Tasks = new ObservableCollection<TaskItem>(tareas);
                    }
                }
                else
                {
                    Tasks.Add(new TaskItem { Id = 1, Name = "Hacer mercado en el D1 de Belmonte", IsCompleted = false, CreatedAt = DateTime.Now });
                    Tasks.Add(new TaskItem { Id = 2, Name = "Estudiar MAUI para RaulSaurio", IsCompleted = true, CreatedAt = DateTime.Now });
                    Tasks.Add(new TaskItem { Id = 3, Name = "Revisar documento del proyecto con Samuel", IsCompleted = false, CreatedAt = DateTime.Now });
                    Tasks.Add(new TaskItem { Id = 4, Name = "Planear nuevas funciones de temporizador para FlowTick", IsCompleted = false, CreatedAt = DateTime.Now });
                }
            }
            catch (Exception ex)
            {
                Shell.Current.DisplayAlert("Error", $"No se pudieron cargar las tareas: {ex.Message}", "OK");
            }
        }
    }
}
