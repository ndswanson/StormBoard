using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace StormBoard
{
    public class Note : Thumb, INotifyPropertyChanged
    {
        #region Constructors

        public Note()
        {
            Initialize();
        }

        public Note(string text)
        {
            Initialize();
            NoteText = text;
        }

        #endregion

        #region Properties

        public string NoteText
        {
            get { return (string)GetValue(NoteTextProperty); }
            set
            {
                SetValue(NoteTextProperty, value);
                NotifyPropertyChanged("NoteText");
                EditEntry.RaiseCanExecuteChanged();
                CommitEntry.RaiseCanExecuteChanged();
                RemoveEntry.RaiseCanExecuteChanged();
            }
        }

        public bool Editing
        {
            get { return (bool)GetValue(EditingProperty); }
            set
            {
                SetValue(EditingProperty, value);
                NotifyPropertyChanged("Editing");
                EditEntry.RaiseCanExecuteChanged();
                CommitEntry.RaiseCanExecuteChanged();
                RemoveEntry.RaiseCanExecuteChanged();
            }
        }

        #endregion

        #region Commands

        public DelegateCommand EditEntry
        {
            get { return (DelegateCommand)GetValue(EditEntryProperty); }
            private set { SetValue(EditEntryProperty, value); }
        }

        public DelegateCommand RemoveEntry
        {
            get { return (DelegateCommand)GetValue(RemoveEntryProperty); }
            private set { SetValue(RemoveEntryProperty, value); }
        }

        public DelegateCommand CommitEntry
        {
            get { return (DelegateCommand)GetValue(CommitEntryProperty); }
            private set { SetValue(CommitEntryProperty, value); }
        }

        #endregion

        #region Dependancy Properties

        public static readonly DependencyProperty NoteTextProperty = DependencyProperty.Register("NoteText", typeof(string), typeof(Note));
        public static readonly DependencyProperty EditingProperty = DependencyProperty.Register("Editing", typeof(bool), typeof(Note));

        public static readonly DependencyProperty EditEntryProperty = DependencyProperty.Register("EditEntry", typeof(DelegateCommand), typeof(Note));
        public static readonly DependencyProperty CommitEntryProperty = DependencyProperty.Register("CommitEntry", typeof(DelegateCommand), typeof(Note));
        public static readonly DependencyProperty RemoveEntryProperty = DependencyProperty.Register("RemoveEntry", typeof(DelegateCommand), typeof(Note));

        #endregion


        #region Methods

        private void Initialize()
        {
            // Declare Delegate Commands
            EditEntry = new DelegateCommand(
                () => { Editing = true; },
                () => { return !Editing; }
            );

            CommitEntry = new DelegateCommand(
                () => { Editing = false; },
                () => { return Editing && !String.IsNullOrWhiteSpace(NoteText); }
            );

            RemoveEntry = new DelegateCommand(
                () => { ((Canvas)this.Parent).Children.Remove(this); },
                () => { return !Editing; }
            );

            // Set Editing False
            Editing = false;

            this.DragDelta += OnDragDelta;
        }

        private void OnDragDelta(object sender, DragDeltaEventArgs e)
        {
            var thumb = e.Source as Note;

            var left = Canvas.GetLeft(thumb) + e.HorizontalChange;
            var top = Canvas.GetTop(thumb) + e.VerticalChange;

            Canvas.SetLeft(thumb, left);
            Canvas.SetTop(thumb, top);        
        }

        #endregion


        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        #endregion
    }
}
