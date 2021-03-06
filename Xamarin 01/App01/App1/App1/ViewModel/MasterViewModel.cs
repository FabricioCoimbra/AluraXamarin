﻿using App1.Model;
using System.Reflection;
using System.Windows.Input;
using Xamarin.Forms;

namespace App1.ViewModel
{
    public class MasterViewModel : BaseViewModel
    {
        private bool editando = false;

        public string Nome
        {
            get => Usuario.Nome; set
            {
                Usuario.Nome = value;
                OnPropertyChanged();
            }
        }
        public string DataNascimento
        {
            get => Usuario.DataNascimento; set
            {
                Usuario.DataNascimento = value;
                OnPropertyChanged();
            }
        }
        public string Telefone
        {
            get => Usuario.Telefone; set
            {
                Usuario.Telefone = value;
                OnPropertyChanged();
            }
        }
        public string Email
        {
            get => Usuario.Email; set
            {
                Usuario.Email = value;
                OnPropertyChanged();
            }
        }

        public bool Editando
        {
            get => editando; set
            {
                editando = value;
                OnPropertyChanged();
            }
        }

        private ImageSource fotoPerfil = ImageSource.FromResource("App1.img.perfil.png", typeof(MasterViewModel).GetTypeInfo().Assembly);

        public ImageSource FotoPerfil
        {
            get => fotoPerfil;
            private set
            {
                fotoPerfil = value;
                OnPropertyChanged();
            }
        }

        public Usuario Usuario { get; set; }
        public MasterViewModel(Usuario usuario)
        {
            Usuario = usuario;
            CriarCommands();
        }

        private void CriarCommands()
        {
            EditarPerfilCommand = new Command(() =>
            {
                MessagingCenter.Send<Usuario>(Usuario, "EditarPerfil");
            });

            SalvarCommand = new Command(() =>
            {
                Editando = false;
                MessagingCenter.Send<Usuario>(Usuario, "SalvarPerfil");
            });

            EditarCommand = new Command(() =>
            {
                Editando = true;
            });

            TirarFotoCommand = new Command(() =>
            {
                DependencyService.Get<App1.Media.ICamera>().TirarFoto();
            });
        }

        public ICommand EditarPerfilCommand { get; private set; }
        public ICommand SalvarCommand { get; private set; }
        public ICommand EditarCommand { get; private set; }
        public ICommand TirarFotoCommand { get; private set; }

    }
}
